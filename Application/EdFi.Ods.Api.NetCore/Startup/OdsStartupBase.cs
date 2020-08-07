// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Dependencies;
using EdFi.Ods.Api.Common.ExternalTasks;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Api.NetCore.Helpers;
using EdFi.Ods.Api.NetCore.InversionOfControl;
using EdFi.Ods.Api.NetCore.MediaTypeFormatters;
using EdFi.Ods.Api.NetCore.Middleware;
using EdFi.Ods.Api.NetCore.Extensions;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EdFi.Ods.Api.NetCore.Startup
{
    public abstract class OdsStartupBase
    {
        private const string CorsPolicyName = "_development_";
        private readonly ILog _logger = LogManager.GetLogger(typeof(OdsStartupBase));

        public OdsStartupBase(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = (IConfigurationRoot) configuration;

            ApiSettings = new ApiSettings();

            Configuration.Bind("ApiSettings", ApiSettings);

            _logger.Debug($"built configuration = {Configuration}");
        }

        public ApiSettings ApiSettings { get; }

        public IConfigurationRoot Configuration { get; }

        public ILifetimeScope Container { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            _logger.Debug("Building services collection");

            services.AddSingleton(ApiSettings);
            services.AddSingleton(Configuration);

            LoadPlugins();
            AssemblyLoaderHelper.LoadAssembliesFromExecutingFolder();

            // this allows the solution to resolve the claims principal. this is not best practice defined by the
            // netcore team, as the claims principal is on the controllers.
            // c.f. https://docs.microsoft.com/en-us/aspnet/core/migration/claimsprincipal-current?view=aspnetcore-3.1
            services.AddHttpContextAccessor();

            // this is opening up all sites to connect to the server. this should probably be reviewed.
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        CorsPolicyName,
                        builder => builder
                            .WithOrigins("http://localhost:56641")
                            .AllowAnyHeader()
                            .AllowAnyMethod());
                });

            // will apply the MvcConfigurator at runtime.
            services.AddControllers(options => options.OutputFormatters.Add(new GraphMLMediaTypeOutputFormatter()))
                .AddNewtonsoftJson(
                    options =>
                    {
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                        options.SerializerSettings.DateParseHandling = DateParseHandling.None;
                        options.SerializerSettings.Formatting = Formatting.Indented;
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    })
                .AddControllersAsServices();

            services.AddAuthentication(EdFiAuthenticationTypes.OAuth)
                .AddScheme<AuthenticationSchemeOptions, EdFiOAuthAuthenticationHandler>(EdFiAuthenticationTypes.OAuth, null);
        }

        // This method gets called by the runtime. Use this method to add services to the container.

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            _logger.Debug("Building Autofac container");

            // For pipelines we need a service locator. Note this is an anti-pattern
            builder.Register(c => new AutofacServiceLocator(new Lazy<ILifetimeScope>(() => Container)))
                .As<IServiceLocator>()
                .SingleInstance();

            RegisterModulesDynamically();

            _logger.Debug("Container loaded.");

            void RegisterModulesDynamically()
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .ToList();

                _logger.Debug("Installing modules:");

                foreach (var type in TypeHelper.GetTypesWithModules())
                {
                    _logger.Debug($"Module {type.Name}");

                    if (type.IsSubclassOf(typeof(ConditionalModule)))
                    {
                        builder.RegisterModule((IModule)Activator.CreateInstance(type, ApiSettings));
                    }
                    else
                    {
                        builder.RegisterModule((IModule)Activator.CreateInstance(type));
                    }
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            Container = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors(CorsPolicyName);

            app.UseAuthentication();
            app.UseAuthorization();

            // Serves Open API Metadata json files when enabled.
            if (ApiSettings.IsFeatureEnabled(ApiFeature.OpenApiMetadata.GetConfigKeyName()))
            {
                app.UseOpenApiMetadata();
            }

            // required to get the base controller working
            app.UseEndpoints(
                endpoints => { endpoints.MapControllers(); });

            SetStaticResolvers();

            RunExternalTasks();

            void RunExternalTasks()
            {
                foreach (IExternalTask externalTask in Container.Resolve<IEnumerable<IExternalTask>>())
                {
                    _logger.Debug($"Running external task {externalTask.GetType().Name}");
                    externalTask.Execute();
                }
            }

            void SetStaticResolvers()
            {
                // Make this dependency available to generated artifacts
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IResourceModelProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IAuthorizationContextProvider>());

                // netcore has removed the claims principal from the thread, to be on the controller.
                // as a workaround for our current application we can resolve the IHttpContextAccessor.
                // c.f. https://docs.microsoft.com/en-us/aspnet/core/migration/claimsprincipal-current?view=aspnetcore-3.1
                ClaimsPrincipal.ClaimsPrincipalSelector = () => Container.Resolve<IHttpContextAccessor>()
                    .HttpContext?.User;

                // Provide cache using a closure rather than repeated invocations to the container
                IPersonUniqueIdToUsiCache personUniqueIdToUsiCache = null;

                PersonUniqueIdToUsiCache.GetCache = ()
                    => personUniqueIdToUsiCache ??= Container.Resolve<IPersonUniqueIdToUsiCache>();

                // Provide cache using a closure rather than repeated invocations to the container
                IDescriptorsCache cache = null;
                DescriptorsCache.GetCache = () => cache ??= Container.Resolve<IDescriptorsCache>();

                ResourceModelHelper.ResourceModel =
                    new Lazy<ResourceModel>(
                        () => Container.Resolve<IResourceModelProvider>()
                            .GetResourceModel());

                EntityExtensionsFactory.Instance = Container.Resolve<IEntityExtensionsFactory>();
            }
        }

        private void LoadPlugins()
        {
            var pluginFolder = ApiSettings.PluginFolder;

            _logger.Debug($"Loading plugins from folder {pluginFolder}.");
            AssemblyLoaderHelper.LoadPluginAssemblies(pluginFolder);
        }
    }
}
