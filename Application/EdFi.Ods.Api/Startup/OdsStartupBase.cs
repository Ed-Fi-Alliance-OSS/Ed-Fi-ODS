// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using EdFi.Common.InversionOfControl;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Helpers;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Api.Jobs.Extensions;
using EdFi.Ods.Api.MediaTypeFormatters;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Configuration.Validation;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using NHibernate.Engine;

namespace EdFi.Ods.Api.Startup
{
    public abstract class OdsStartupBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string CorsPolicyName = "_development_";

        private static readonly string _identityManagementClaimType = $"{EdFiConventions.EdFiOdsResourceClaimBaseUri}/services/identity";

        private readonly ILog _logger = LogManager.GetLogger(typeof(OdsStartupBase));
        private ApiSettings _apiSettings;

        protected OdsStartupBase(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;

            Configuration = (IConfigurationRoot) configuration;

            GlobalContext.Properties["ApiClientId"] = null;
            GlobalContext.Properties["ProfilesHeader"] = null;

            _logger.Debug($"built configuration = {Configuration}");
        }

        private IConfigurationRoot Configuration { get; }

        private IServiceCollection Services { get; set; }
        
        private ILifetimeScope Container { get; set; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            Services = services;

            // Provide access to the web host environment through the container
            services.AddSingleton(_webHostEnvironment);

            // Bind configuration objects to sections 
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
            services.Configure<Plugin>(Configuration.GetSection("Plugin"));
            
            // Register sections related to external connection strings configuration
            services.Configure<TenantsSection>(Configuration);
            services.Configure<OdsInstancesSection>(Configuration);

            try
            {
                _apiSettings = new ApiSettings();
                Configuration.Bind("ApiSettings", _apiSettings);

                // Validate the API settings
                var apiSettingsValidator = new ApiSettingsValidator();
                var validationResult = apiSettingsValidator.Validate(_apiSettings);

                if (!validationResult.IsValid)
                {
                    _logger.Fatal(validationResult.ToString());
                    Environment.Exit(1);
                }
            }
            catch (ConfigurationException invalidConfiguration)
            {
                _logger.Fatal(invalidConfiguration);
                Environment.Exit(1);
            }

            services.AddFeatureManagement();
            var pluginSettings = new Plugin();
            Configuration.Bind("Plugin", pluginSettings);
            
            // Legacy configuration support through the container
            services.AddSingleton(_apiSettings);
            services.AddSingleton(_apiSettings.GetDatabaseEngine());
            services.AddSingleton(Configuration);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped(
                serviceProvider =>
                {
                    var actionContext = serviceProvider.GetRequiredService<IActionContextAccessor>().ActionContext;
                    var factory = serviceProvider.GetRequiredService<IUrlHelperFactory>();
                    return factory.GetUrlHelper(actionContext);
                });

            AssemblyLoaderHelper.LoadAssembliesFromFolder();

            // Build a temporary service provider
            var temporaryServiceProvider = services.BuildServiceProvider();

            // Resolve the feature manager
            var featureManager = temporaryServiceProvider.GetService<IFeatureManager>();
            var pluginInfos = LoadPlugins(pluginSettings, featureManager);
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

            mvcBuilder.Services.ConfigureOptions<ApiBehaviorOptionsConfigurator>();
            
            services.AddMvc();

            services.AddAuthentication(EdFiAuthenticationTypes.OAuth)
                .AddScheme<AuthenticationSchemeOptions, EdFiOAuthAuthenticationHandler>(EdFiAuthenticationTypes.OAuth, null);

            services.AddApplicationInsightsTelemetry(
                options => { options.ApplicationVersion = ApiVersionConstants.Version; });

            services.AddAuthorization(
                options =>
                {
                    if (featureManager.IsFeatureEnabled(ApiFeature.IdentityManagement))
                    {
                        options.AddPolicy(
                            "IdentityManagement",
                            policy => policy.RequireAssertion(
                                context =>
                                {
                                    return context.User
                                        .HasClaim(c => c.Type == _identityManagementClaimType);
                                }
                            ));
                    }
                    else
                    {
                        options.AddPolicy(
                            "IdentityManagement", policy => policy.RequireAssertion(_ => false));
                    }
                });

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

            services.AddHealthCheck(Configuration, featureManager, _apiSettings.GetDatabaseEngine());
            services.AddScheduledJobs();

            // Identify all EdFi.Ods.* assemblies
            var mediatorAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name.StartsWith("EdFi.Ods."))
                .ToArray();

            // Add all the MediatR services from the Ed-Fi assemblies
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(mediatorAssemblies));

            ConfigurePluginsServices();

            void ConfigurePluginsServices()
            {
                _logger.Debug("Configuring services in plugins:");
                
                foreach (var servicesConfigurationActivityType in TypeHelper.GetAssemblyTypes<IServicesConfigurationActivity>())
                {
                    _logger.Debug($"Executing services configuration activity '{servicesConfigurationActivityType.Name}'...");

                    try
                    {
                        var servicesConfigurationActivity = (IServicesConfigurationActivity) Activator.CreateInstance(servicesConfigurationActivityType);
                        servicesConfigurationActivity?.ConfigureServices(Configuration, services, _apiSettings);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Error occured during service configuration activity '{servicesConfigurationActivityType.Name}': ", ex);
                    }
                }
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            _logger.Debug("Building Autofac container");

            // Disable automatic validation during ASP.NET model binding for data management requests
            builder.RegisterDecorator<DataManagementObjectModelValidatorDecorator, IObjectModelValidator>();

            // For pipelines we need a service locator. Note this is an anti-pattern
            builder.Register(c => new AutofacServiceLocator(new Lazy<ILifetimeScope>(() => Container)))
                .As<IServiceLocator>()
                .SingleInstance();

            RegisterModulesDynamically();

            _logger.Debug("Container loaded.");

            void RegisterModulesDynamically()
            {
                _logger.Debug("Installing modules:");

                var moduleTypes = TypeHelper.GetModuleTypes().ToList();

                // Add the module types to the services collection so we can resolve their dependencies using DI
                foreach (var type in moduleTypes)
                {
                    Services.AddTransient(type);
                }

                // Build a temporary ServiceProvider to resolve the modules with their specific dependencies (must be available in initial service collection)
                var temporaryServiceProvider = Services.BuildServiceProvider();

                // Instantiate and invoke module registrations
                foreach (var moduleType in moduleTypes)
                {
                    _logger.Debug($"Module {moduleType.Name}");

                    try
                    {
                        var module = (IModule) temporaryServiceProvider.GetService(moduleType);
                        builder.RegisterModule(module);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Error registering module '{moduleType.Name}'.", ex);
                    }
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IOptions<ApiSettings> apiSettingsOptions,
            IApplicationConfigurationActivity[] configurationActivities)
        {
            // Process headers and query string arguments for correlation ids, and add to log messages
            app.UseRequestCorrelation();

            app.UseOAuthContentTypeValidation();

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

            // Identifies the current ODS instance for the request (if enabled)
            app.UseTenantIdentification();

            app.UseEdFiApiAuthentication();

            app.UseProblemDetailsEnrichment();

            app.UseAuthorization();

            // Identifies the current ODS instance for the request
            app.UseOdsInstanceIdentification();

            // Perform additional registered configuration activities 
            foreach (var configurationActivity in configurationActivities)
            {
                configurationActivity.Configure(app);
            }

            // Serves Open API Metadata json files (if enabled)
            app.UseOpenApiMetadata();

            app.UseWhen(context => 
                context.Request.Path.StartsWithSegments("/data") ||
                context.Request.Path.StartsWithSegments("/composites"),
                builder => builder.UseRequestResponseDetailsLogger());

            // required to get the base controller working
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health");
            });

            SetStaticResolvers();

            RunStartupCommands();

            void RunStartupCommands()
            {
                List<Task> tasks = new();

                foreach (IStartupCommand startupCommand in Container.Resolve<IEnumerable<IStartupCommand>>())
                {
                    _logger.Info($"Running startup command '{startupCommand.GetType().Name}'...");

                    tasks.Add(startupCommand.ExecuteAsync());
                }

                try
                {
                    // Wait for all tasks to complete, catch all exceptions in an AggregateException
                    Task.WaitAll(tasks.ToArray());
                }
                catch (AggregateException ex)
                {
                    // Log any exceptions that occurred
                    foreach (var innerEx in ex.InnerExceptions)
                    {
                        _logger.Error("Unhandled exception during startup commands execution.", innerEx);
                    }
                }
                finally
                {
                    _logger.Info("Startup commands complete.");
                }
            }

            void SetStaticResolvers()
            {
                // Make this dependency available to generated artifacts
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IResourceModelProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IProfileResourceModelProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IDomainModelProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IAuthorizationContextProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IETagProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IMappingContractProvider>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IContextProvider<ProfileContentTypeContext>>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IContextProvider<UniqueIdLookupsByUsiContext>>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IContextProvider<UsiLookupsByUniqueIdContext>>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => (StringComparer) Container.Resolve<IDatabaseEngineSpecificEqualityComparerProvider<string>>().GetEqualityComparer());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IDescriptorResolver>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<IContextProvider<DataPolicyException>>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<ISessionFactoryImplementor>());
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => Container.Resolve<ApiSettings>().Behaviors);

                // netcore has removed the claims principal from the thread, to be on the controller.
                // as a workaround for our current application we can resolve the IHttpContextAccessor.
                // c.f. https://docs.microsoft.com/en-us/aspnet/core/migration/claimsprincipal-current?view=aspnetcore-3.1
                ClaimsPrincipal.ClaimsPrincipalSelector = () => Container.Resolve<IHttpContextAccessor>()
                    .HttpContext?.User;

                ResourceModelHelper.ResourceModel =
                    new Lazy<IResourceModel>(
                        () => Container.Resolve<IResourceModelProvider>()
                            .GetResourceModel());

                // Set NHibernate to use Autofac to resolve its dependencies
                NHibernate.Cfg.Environment.ObjectsFactory = new NHibernateAutofacObjectsFactory(Container);
            }
        }

        private PluginInfo[] LoadPlugins(Plugin pluginSettings, IFeatureManager featureManager)
        {
            var pluginFolder = AssemblyLoaderHelper.GetPluginFolder(pluginSettings.Folder);
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
                    $"To configure plugins update the '{pluginFolderSettingsName}' setting with either an absolute path, a path relative to the 'Application/EdFi.Ods.WebApi/', or a path relative to the deployed EdFi.Ods.WebApi executable.");

                return Array.Empty<PluginInfo>();
            }

            try
            {
                _logger.Info($"Loading plugins from: '{pluginFolder}'");

                var assemblyFiles = AssemblyLoaderHelper.FindPluginAssemblies(
                    pluginFolder,
                    false,
                    featureManager.IsFeatureEnabled(ApiFeature.Extensions));

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
