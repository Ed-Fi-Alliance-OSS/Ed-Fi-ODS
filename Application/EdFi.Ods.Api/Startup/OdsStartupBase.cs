// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using EdFi.Common.Configuration;
using EdFi.Common.InversionOfControl;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Api.Helpers;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Api.MediaTypeFormatters;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Infrastructure.Extensibility;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Security.Claims;
using EdFi.Admin.DataAccess.DbConfigurations;
using EdFi.Ods.Api.Jobs.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Profiles;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Startup
{
    public abstract class OdsStartupBase
    {
        private const string CorsPolicyName = "_development_";

        private static readonly string _identityManagementClaimType = $"{EdFiConventions.EdFiOdsResourceClaimBaseUri}/services/identity";

        private readonly ILog _logger = LogManager.GetLogger(typeof(OdsStartupBase));
        private ApiSettings _apiSettings;

        protected OdsStartupBase(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = (IConfigurationRoot) configuration;

            GlobalContext.Properties["ApiClientId"] = null;
            GlobalContext.Properties["ProfilesHeader"] = null;

            _logger.Debug($"built configuration = {Configuration}");
        }

        private IConfigurationRoot Configuration { get; }

        private ILifetimeScope Container { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Bind configuration objects to sections 
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
            services.Configure<Plugin>(Configuration.GetSection("Plugin"));
            
            // Register sections related to external connection strings configuration
            services.Configure<TenantsSection>(Configuration);
            services.Configure<OdsInstancesSection>(Configuration);

            _apiSettings = new ApiSettings();
            Configuration.Bind("ApiSettings", _apiSettings);
            
            var pluginSettings = new Plugin();
            Configuration.Bind("Plugin", pluginSettings);
            
            // Legacy configuration support through the container
            services.AddSingleton(_apiSettings);
            services.AddSingleton(Configuration);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped(
                serviceProvider =>
                {
                    var actionContext = serviceProvider.GetRequiredService<IActionContextAccessor>().ActionContext;
                    var factory = serviceProvider.GetRequiredService<IUrlHelperFactory>();
                    return factory.GetUrlHelper(actionContext);
                });

            AssemblyLoaderHelper.LoadAssembliesFromExecutingFolder();

            var pluginInfos = LoadPlugins(pluginSettings);

            services.AddSingleton(pluginInfos);

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
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithExposedHeaders("*"));
                });

            // will apply the MvcConfigurator at runtime.
            var mvcBuilder = services
                .AddControllers(options => options.OutputFormatters.Add(new GraphMLMediaTypeOutputFormatter()))
                .AddNewtonsoftJson();

            // Configure the JSON serializer, and assign the Profiles-aware contract resolver
            // NOTE: We may want to make this an extensibility point to fully isolate Profiles-related logic from the core.
            mvcBuilder.Services.ConfigureOptions<NewtonsoftJsonOptionConfigurator>();

            // Add controllers for the plugins
            foreach (var pluginInfo in pluginInfos)
            {
                var pluginAssembly = pluginInfo.Assembly;

                // This loads MVC application parts from plugin assemblies
                var partFactory = ApplicationPartFactory.GetApplicationPartFactory(pluginAssembly);

                foreach (var part in partFactory.GetApplicationParts(pluginAssembly))
                {
                    mvcBuilder.PartManager.ApplicationParts.Add(part);
                }
            }

            mvcBuilder.AddControllersAsServices();

            services.AddMvc()
                .ConfigureApiBehaviorOptions(
                    options =>
                    {
                        options.InvalidModelStateResponseFactory = actionContext
                            => new BadRequestObjectResult(ErrorTranslator.GetErrorMessage(actionContext.ModelState));
                    });

            services.AddAuthentication(EdFiAuthenticationTypes.OAuth)
                .AddScheme<AuthenticationSchemeOptions, EdFiOAuthAuthenticationHandler>(EdFiAuthenticationTypes.OAuth, null);

            services.AddApplicationInsightsTelemetry(
                options => { options.ApplicationVersion = ApiVersionConstants.Version; });

            if (_apiSettings.IsFeatureEnabled(ApiFeature.IdentityManagement.GetConfigKeyName()))
            {
                services.AddAuthorization(
                    options =>
                    {
                        options.AddPolicy(
                            "IdentityManagement",
                            policy => policy.RequireAssertion(
                                context => context.User
                                    .HasClaim(c => c.Type == _identityManagementClaimType)));
                    });
            }

            if (_apiSettings.UseReverseProxyHeaders.HasValue && _apiSettings.UseReverseProxyHeaders.Value)
            {
                services.Configure<ForwardedHeadersOptions>(
                    options =>
                    {
                        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
                                                   & ForwardedHeaders.XForwardedHost
                                                   & ForwardedHeaders.XForwardedProto;
                    });
            }

            services.AddHealthCheck(Configuration.GetConnectionString("EdFi_Admin"), IsSqlServer(_apiSettings.Engine));
            services.AddScheduledJobs();
        }

        private static bool IsSqlServer(string databaseEngine) => "SQLServer".Equals(databaseEngine, StringComparison.OrdinalIgnoreCase);

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
                _logger.Debug("Installing modules:");

                foreach (var type in TypeHelper.GetTypesWithModules())
                {
                    _logger.Debug($"Module {type.Name}");

                    if (type.IsSubclassOf(typeof(ConditionalModule)))
                    {
                        builder.RegisterModule((IModule) Activator.CreateInstance(type, _apiSettings));
                    }
                    else
                    {
                        builder.RegisterModule((IModule) Activator.CreateInstance(type));
                    }
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            IOptions<ApiSettings> apiSettingsOptions,
            IApplicationConfigurationActivity[] configurationActivities)
        {
            var apiSettings = apiSettingsOptions.Value;

            if (!string.IsNullOrEmpty(apiSettings.PathBase))
            {
                var pathBase = apiSettings.PathBase.Trim('/');
                pathBase = "/" + pathBase;
                app.UsePathBase(pathBase);
            }

            Container = app.ApplicationServices.GetAutofacRoot();

            if (_apiSettings.UseReverseProxyHeaders.HasValue && _apiSettings.UseReverseProxyHeaders.Value)
            {
                app.UseForwardedHeaders();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors(CorsPolicyName);

            // Identifies the current ODS instance for the request
            if (apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()))
            {
                app.UseTenantIdentification();
            }

            app.UseEdFiApiAuthentication();
            app.UseAuthorization();

            // Identifies the current ODS instance for the request
            app.UseOdsInstanceIdentification();

            // Perform additional registered configuration activities 
            foreach (var configurationActivity in configurationActivities)
            {
                configurationActivity.Configure(app);
            }

            // Serves Open API Metadata json files when enabled.
            if (_apiSettings.IsFeatureEnabled(ApiFeature.OpenApiMetadata.GetConfigKeyName()))
            {
                app.UseOpenApiMetadata();
            }

            if (_apiSettings.IsFeatureEnabled(ApiFeature.XsdMetadata.GetConfigKeyName()))
            {
                app.UseXsdMetadata();
            }

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/data"),
                builder => builder.UseRequestResponseDetailsLogger());

            // required to get the base controller working
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health");
            });

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
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IDomainModelProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IAuthorizationContextProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IETagProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IMappingContractProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IContextProvider<ProfileContentTypeContext>>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IDatabaseEngineSpecificEqualityComparerProvider<string>>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IDescriptorResolver>());

                // netcore has removed the claims principal from the thread, to be on the controller.
                // as a workaround for our current application we can resolve the IHttpContextAccessor.
                // c.f. https://docs.microsoft.com/en-us/aspnet/core/migration/claimsprincipal-current?view=aspnetcore-3.1
                ClaimsPrincipal.ClaimsPrincipalSelector = () => Container.Resolve<IHttpContextAccessor>()
                    .HttpContext?.User;

                // Provide cache using a closure rather than repeated invocations to the container
                IPersonUniqueIdToUsiCache personUniqueIdToUsiCache = null;

                PersonUniqueIdToUsiCache.GetCache = ()
                    => personUniqueIdToUsiCache ??= Container.Resolve<IPersonUniqueIdToUsiCache>();

                ResourceModelHelper.ResourceModel =
                    new Lazy<ResourceModel>(
                        () => Container.Resolve<IResourceModelProvider>()
                            .GetResourceModel());

                EntityExtensionsFactory.Instance = Container.Resolve<IEntityExtensionsFactory>();

                DbConfiguration.SetConfiguration(new DatabaseEngineDbConfiguration(Container.Resolve<DatabaseEngine>()));

                // Set NHibernate to use Autofac to resolve its dependencies
                NHibernate.Cfg.Environment.ObjectsFactory = new NHibernateAutofacObjectsFactory(Container);
            }
        }
        
        private string GetPluginFolder(Plugin pluginSettings)
        {
            if (string.IsNullOrWhiteSpace(pluginSettings.Folder))
            {
                return string.Empty;
            }

            if (Path.IsPathRooted(pluginSettings.Folder))
            {
                return pluginSettings.Folder;
            }

            // in a developer environment the plugin folder is relative to the WebApi project
            // "Ed-Fi-ODS-Implementation/Application/EdFi.Ods.WebApi/bin/Debug/net6.0/../../../" => "Ed-Fi-ODS-Implementation/Application/EdFi.Ods.WebApi"
            var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory!, "../../../"));
            var relativeToProject = Path.GetFullPath(Path.Combine(projectDirectory, pluginSettings.Folder));

            if (Directory.Exists(relativeToProject))
            {
                return relativeToProject;
            }

            // in a deployment environment the plugin folder is relative to the executable
            // "C:/inetpub/Ed-Fi/WebApi"
            var relativeToExecutable = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory!, pluginSettings.Folder));

            if (Directory.Exists(relativeToExecutable))
            {
                return relativeToExecutable;
            }

            // last attempt to get directory relative to the working directory
            var relativeToWorkingDirectory = Path.GetFullPath(pluginSettings.Folder);

            if (Directory.Exists(relativeToWorkingDirectory))
            {
                return relativeToWorkingDirectory;
            }

            return pluginSettings.Folder;
        }

        private PluginInfo[] LoadPlugins(Plugin pluginSettings)
        {
            var pluginFolder = GetPluginFolder(pluginSettings);
            var pluginFolderSettingsName = $"{nameof(Plugin)}:{nameof(Plugin.Folder)}";

            if (string.IsNullOrWhiteSpace(pluginFolder))
            {
                _logger.Info($"'{pluginFolderSettingsName}' setting not configured. No plugins will be loaded.");
                return Array.Empty<PluginInfo>();
            }

            if (!Directory.Exists(pluginFolder))
            {
                _logger.Warn($"Plugin folder '{pluginFolder}' does not exist. No plugins will be loaded.");

                _logger.Warn(
                    $"To configure plugins update the '{pluginFolderSettingsName}' setting with either an absolute path, a path relative to the 'Ed-Fi-ODS-Implementation/Application/EdFi.Ods.WebApi/', or a path relative to the deployed EdFi.Ods.WebApi executable.");

                return Array.Empty<PluginInfo>();
            }

            try
            {
                _logger.Info($"Loading plugins from: '{pluginFolder}'");
                var assemblyFiles = AssemblyLoaderHelper.FindPluginAssemblies(pluginFolder);

                // IMPORTANT: Load the plug-in assembly into the Default context
                return assemblyFiles
                    .Select(
                        assemblyFile => new PluginInfo
                        {
                            AssemblyFileName = assemblyFile,
                            Assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyFile)
                        })
                    .ToArray();
            }
            finally
            {
                // LoadPluginAssemblies method creates a pluginFinderAssemblyContext and loads assembles in it to
                // determine plugins to load in the app domain. Need to force a garbage collection to unload
                // the pluginFinderAssemblyContext immediately or else assemblies loaded in this context will
                // be in the current app domain.
                GC.Collect();
            }
        }
    }
}
