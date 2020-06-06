// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Sandbox.Security;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.HttpRouteConfigurations;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Api.Services;
using EdFi.Ods.Api.Services.ActionFilters;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.ChangeQueries.Container.Installers;
using EdFi.Ods.Common;
using EdFi.Ods.Common._Installers;
using EdFi.Ods.Common.ChainOfResponsibility;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Features.Container.Installers;
using EdFi.Ods.Security.Authorization;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Security.Container.Installers;
using EdFi.Ods.Security.Profiles;
using EdFi.Ods.Standard;
using EdFi.Ods.WebService.Tests._Installers;
using log4net;
using log4net.Config;
using Microsoft.Owin.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using ChangeQueryFeature = EdFi.Ods.Api.ChangeQueries.ChangeQueryFeature;
using OpenApiMetadataInstaller = EdFi.Ods.WebService.Tests._Installers.OpenApiMetadataInstaller;

namespace EdFi.Ods.WebService.Tests.Owin
{
    public abstract class WebServiceTestsStartupBase : IDisposable
    {
        protected readonly IWindsorContainer Container = new WindsorContainerEx();
        protected ILog Logger = LogManager.GetLogger(typeof(WebServiceTestsStartupBase));

        public void Dispose()
        {
            Container.Dispose();
        }

        /// <summary>
        /// Provides the startup class with the ability to install security components.  Suggested implementation is to instantiate and invoke the <b>SecurityComponentsInstaller</b> from the host process.
        /// </summary>
        /// <param name="container">The IoC container for performing service registrations.</param>
        protected virtual void InstallSecurityComponents(IWindsorContainer container)
        {
            //ensure assembly reference:
            AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Standard>();
            container.Install(new SecurityComponentsInstaller());

            container.Register(
                Component.For<IResourceLoadGraphTransformer>()
                    .ImplementedBy<PersonResourceLoadGraphTransformer>());
        }

        protected virtual void InstallSecretVerifier(IWindsorContainer container)
        {
            container.Register(
                Component.For<ISecretVerifier>()
                         .ImplementedBy<AutoUpgradingHashedSecretVerifierDecorator>());

            container.Register(
                Component.For<ISecretVerifier>()
                         .ImplementedBy<SecureHashAwareSecretVerifier>());
        }

        protected virtual void InstallHashConfigProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IHashConfigurationProvider>()
                         .ImplementedBy<DefaultHashConfigurationProvider>()
            );
        }

        protected virtual void InstallSecureHasher(IWindsorContainer container)
        {
            container.Register(
                Component.For<ISecureHasher>()
                         .ImplementedBy<Pbkdf2HmacSha1SecureHasher>()
            );
        }

        protected virtual void InstallSecretHashingSupport(IWindsorContainer container)
        {
            container.Register(
                Component.For<IApiClientAuthenticator>()
                         .ImplementedBy<ApiClientAuthenticator>(),
                Component.For<IApiClientIdentityProvider, IApiClientSecretProvider>()
                         .ImplementedBy<EdFiAdminApiClientIdentityProvider>(),
                Component.For<IPackedHashConverter>()
                         .ImplementedBy<PackedHashConverter>(),
                Component.For<ISecurePackedHashProvider>()
                         .ImplementedBy<SecurePackedHashProvider>()
            );

            InstallSecureHasher(container);
            InstallSecretVerifier(container);
            InstallHashConfigProvider(container);
        }

        public virtual void FinalizeContainer(IWindsorContainer container)
        {
            container.Kernel.GetFacilities()
                     .OfType<ChainOfResponsibilityFacility>()
                     .SingleOrDefault()
                    ?.FinalizeChains();
        }

        public virtual void Configuration(IAppBuilder appBuilder)
        {
            EnsureAssembliesLoaded();
            InitializeContainer(Container);
            InstallSecurityComponents(Container);
            InstallWebApiComponents();
            InstallSecretHashingSupport(Container);
            InstallConfigurationSpecificInstaller(Container);

            if (!Container.Kernel.HasComponent(typeof(IEntityExtensionsFactory)))
            {
                // add default extensions to be disabled and to allow activator to behave.
                Container.Register(
                    Component.For<IEntityExtensionsFactory>().ImplementedBy<NoEntityExtensionsFactory>().IsFallback()
                        .LifestyleSingleton());
            }

            InstallExtensions(Container);

            if (ChangeQueryFeature.IsEnabled)
            {
                Container.Install(new ChangeQueriesInstaller());
            }

            // NHibernate initialization

#pragma warning disable 618
            Container.Register(Component.For<IAssembliesProvider>().ImplementedBy<AssembliesProvider>());

            Container.Register(Component.For<IOrmMappingFileDataProvider>()
                .ImplementedBy<OrmMappingFileDataProvider>()
                .DependsOn(Dependency.OnValue<string>(OrmMappingFileConventions.OrmMappingAssembly))
                .DependsOn(Dependency.OnValue<DatabaseEngine>(DatabaseEngine.SqlServer)));

            new LegacyNHibernateConfigurator().Configure(Container);
#pragma warning restore 618

            var httpConfig = new HttpConfiguration
                             {
                                 DependencyResolver = Container.Resolve<IDependencyResolver>()
                             };

            var domainModelProvider = Container.Resolve<IDomainModelProvider>();

            Container.Register(
                Component.For<ISchemaNameMapProvider>()
                         .ImplementedBy<SchemaNameMapProvider>()
                         .DependsOn(
                              Dependency.OnValue(
                                  "schemas",
                                  domainModelProvider.GetDomainModel()
                                                     .Schemas)));

            // Replace the default controller selector with one based on the final namespace segment (to enable support of Profiles)
            httpConfig.Services.Replace(
                typeof(IHttpControllerSelector),
                new ProfilesAwareHttpControllerSelector(
                    httpConfig,
                    Container.Resolve<IProfileResourceNamesProvider>(),
                    Container.Resolve<ISchemaNameMapProvider>()));

            //httpConfig.EnableSystemDiagnosticsTracing();
            httpConfig.EnableCors(new EnableCorsAttribute("*", "*", "*", "*"));
            ConfigureRoutes(httpConfig);
            ConfigureFormatters(httpConfig);
            ConfigureDelegatingHandlers(httpConfig, Container.ResolveAll<DelegatingHandler>());
            RegisterFilters(httpConfig);
            RegisterAuthenticationProvider(Container);

            appBuilder.Use(
                           (context, next) =>
                           {
                               context.Response.Headers.Remove("Server");
                               return next();
                           })
                      .UseWebApi(httpConfig);

            XmlConfigurator.Configure();
            appBuilder.SetLoggerFactory(new Log4NetLoggerFactory());

            // Populate the Profiles in the Admin Database if the IAdminProfileNamesPublisher has been registered
            // since it is registered in the security components installer and that may not always be registered.
            if (Container.Kernel.HasComponent(typeof(IAdminProfileNamesPublisher)))
            {
                var adminProfileNamesPublisher = Container.Resolve<IAdminProfileNamesPublisher>();
                adminProfileNamesPublisher.PublishProfilesAsync();
            }

            httpConfig.EnsureInitialized();

            Container.Register(
                Component.For<HttpRouteCollection>()
                         .Instance(httpConfig.Routes));

            InstallOpenApiMetadata(Container);

            FinalizeContainer(Container);

            if (!Container.Kernel.HasComponent(typeof(IEntityExtensionsFactory)))
            {
                EntityExtensionsFactory.Instance = new NoEntityExtensionsFactory();
            }
        }

        protected virtual void InstallOpenApiMetadata(IWindsorContainer container)
        {
            container.Install(new OpenApiMetadataInstaller());
        }

        protected virtual void InstallExtensions(IWindsorContainer container)
        {
            container.Install(
                new EdFiExtensionsInstaller(
                    new AssembliesProvider(),
                    new AppConfigValueProvider()));

            EntityExtensionsFactory.Instance = Container.Resolve<IEntityExtensionsFactory>();
        }

        protected virtual void InstallWebApiComponents()
        {
            Container.Install(new WebApiInstaller());

            // Register all pipeline steps
            Container.Register(
                Component
                    .For<IPipelineFactory>()
                    .ImplementedBy<PipelineFactory>()
                    .DependsOn(
                        new
                        {
                            locator = Container
                        })
            );

            Container.Register(
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Standard>()
                    .BasedOn(typeof(ICreateOrUpdatePipeline<,>))
                    .WithService.AllInterfaces()
            );

            Container.Register(
                Classes
                    .FromAssemblyContaining<Marker_EdFi_Ods_Api_Common>()
                    .BasedOn(typeof(IStep<,>))
                    .WithService
                    .Self());

            // Register the providers of the core pipeline steps
            Container.Register(
                Classes
                    .FromAssemblyContaining<Marker_EdFi_Ods_Api_Common>()
                    .BasedOn<IPipelineStepsProvider>()
                    .WithServiceFirstInterface());
        }

        protected virtual void ConfigureDelegatingHandlers(
            HttpConfiguration httpConfig,
            IEnumerable<DelegatingHandler> handlers)
        {
            if (handlers == null)
            {
                return;
            }

            foreach (var delegatingHandler in handlers)
            {
                httpConfig.MessageHandlers.Add(delegatingHandler);
            }
        }

        /// <summary>
        /// Location to reference types in assemblies to ensure the assemblies are loaded.
        /// </summary>
        protected virtual void EnsureAssembliesLoaded()
        {
        }

        protected virtual void InitializeContainer(IWindsorContainer container)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.AddFacility<DatabaseConnectionStringProviderFacility>();
            container.AddFacility<ChainOfResponsibilityFacility>();
            container.AddSupportForEmptyCollections();

            // Web API Dependency Injection
            container.Register(
                Component.For<IDependencyResolver>()
                         .Instance(new WindsorDependencyResolver(Container))
            );
        }

        protected abstract void InstallConfigurationSpecificInstaller(IWindsorContainer container);

        protected virtual void ConfigureFormatters(HttpConfiguration config)
        {
            // Replace existing JSON formatter to be profiles-aware
            var existingJsonFormatter = config.Formatters.SingleOrDefault(f => f is JsonMediaTypeFormatter);

            // Remove the original one
            if (existingJsonFormatter != null)
            {
                config.Formatters.Remove(existingJsonFormatter);
            }

            // Add our customized one, supporting dynamic addition of media types for deserializing messages
            config.Formatters.Insert(0, new ProfilesContentTypeAwareJsonMediaTypeFormatter());

            // Add support for graphml format
            config.Formatters.Insert(1, new GraphMLMediaTypeFormatter());

            // Make Json the default response type for api requests
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // configure JSON serialization
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            config.Formatters.JsonFormatter.SerializerSettings.DateParseHandling = DateParseHandling.None;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.RequiredMemberSelector = new NoRequiredMemberSelector();
        }

        protected virtual void RegisterFilters(HttpConfiguration config)
        {
            RegisterCoreFilters(config);
            RegisterAuthorizationFilters(config);
        }

        protected void RegisterCoreFilters(HttpConfiguration config)
        {
            var showErrors = config.IncludeErrorDetailPolicy != IncludeErrorDetailPolicy.Never;
            config.Filters.Add(new ExceptionHandlingFilter(showErrors));
            config.Filters.Add(new SchoolYearContextFilter(Container.Resolve<ISchoolYearContextProvider>()));
        }

        protected void RegisterAuthorizationFilters(HttpConfiguration config)
        {
            config.Filters.Add(
                new EdFiAuthorizationFilter(
                    Container.Resolve<IEdFiAuthorizationProvider>(),
                    Container.Resolve<ISecurityRepository>(),
                    Container.Resolve<IRESTErrorProvider>()));

            config.Filters.Add(
                new ProfilesAuthorizationFilter(
                    Container.Resolve<IApiKeyContextProvider>(),
                    Container.Resolve<IProfileResourceNamesProvider>()));
        }

        protected virtual void RegisterAuthenticationProvider(IWindsorContainer container)
        {
            // TODO: Remove with ODS-2973, deprecated by ODS-2874
            container.Register(
                Component.For<IAuthenticationProvider>()
                         .ImplementedBy<OAuthAuthenticationProvider>());
        }

        private void IncludeAuthorizationRoute(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "OAuthToken",
                routeTemplate: "oauth/token",
                defaults: new
                          {
                              controller = "Token"
                          }
            );
        }

        private void ConfigureMetadataRoutes(HttpConfiguration config, bool useSchoolYear = false)
        {
            // TODO: Remove with ODS-2973, deprecated by ODS-2874
            var domainModelProvider = Container.Resolve<IDomainModelProvider>();

            var schemaNameConstraints = string.Join("|", domainModelProvider.GetDomainModel().Schemas.Select(s => s.PhysicalName));

            var schoolYearConstraint = useSchoolYear
                ? new
                  {
                      schoolYearFromRoute = @"^\d{4}$"
                  }
                : null;

            var schemaNameConstraint = useSchoolYear
                ? (object) new
                           {
                               schoolYearFromRoute = @"^\d{4}$", schemaName = $@"({schemaNameConstraints})"
                           }
                : new
                  {
                      schemaName = $@"({schemaNameConstraints})"
                  };

            config.Routes.MapHttpRoute(
                name: "MetadataSections",
                routeTemplate: "metadata/" + (useSchoolYear
                                   ? "{schoolYearFromRoute}"
                                   : string.Empty),
                defaults: new
                          {
                              controller = "openapimetadata", action = "getsections", apiVersion = ApiVersionConstants.Ods, identityVersion = ApiVersionConstants.Identity
                          },
                constraints: schoolYearConstraint
            );

            var resourceTypesConstraint = useSchoolYear
                ? (object) new
                           {
                               resourceType = @"(resources|descriptors)", schoolYearFromRoute = @"^\d{4}$"
                           }
                : new
                  {
                      resourceType = @"(resources|descriptors)"
                  };

            var apiDefaults = new
                              {
                                  controller = "openapimetadata", apiVersion = ApiVersionConstants.Ods,
                                  identityVersion = ApiVersionConstants.Identity, compositeVersion = ApiVersionConstants.Composite, action = "get"
                              };

            string schoolYearRoute = useSchoolYear
                ? "{schoolYearFromRoute}/"
                : string.Empty;

            ConfigureResourceTypeMetadataRoutes(config, apiDefaults, resourceTypesConstraint, schoolYearRoute);
            ConfigureProfileMetadataRoutes(config, apiDefaults, schoolYearConstraint, schoolYearRoute);
            ConfigureCompositeMetadataRoutes(config, apiDefaults, schoolYearConstraint, schoolYearRoute);
            ConfigureSchemaSpecificMetadataRoutes(config, apiDefaults, schemaNameConstraint, schoolYearRoute);
            ConfigureComprehensiveMetadataRoute(config, apiDefaults, schoolYearConstraint, schoolYearRoute);
            ConfigureBulkMetadataRoute(config, apiDefaults, schoolYearConstraint, schoolYearRoute);
            ConfigureIdentityMetadataRoute(config, apiDefaults, schoolYearConstraint, schoolYearRoute);
            ConfigureDependencyMetadataRoute(config, schoolYearConstraint, schoolYearRoute);
        }

        protected virtual void ConfigureDependencyMetadataRoute(HttpConfiguration config, object constraints, string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "AggregateDependencies",
                       routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "dependencies",
                       defaults: new
                                 {
                                     controller = "aggregatedependency", apiVersion = ApiVersionConstants.Ods, action = "get"
                                 },
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(RouteConstants.Dependencies);
        }

        protected virtual void ConfigureResourceTypeMetadataRoutes(
            HttpConfiguration config,
            object defaults,
            object constraints,
            string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadataResourceTypes",
                       routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "{resourceType}/swagger.json",
                       defaults: defaults,
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.ResourceTypes);
        }

        protected virtual void ConfigureProfileMetadataRoutes(HttpConfiguration config, object defaults, object constraints, string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadataProfiles",
                       routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "profiles/{profileName}/swagger.json",
                       defaults: defaults,
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.Profiles);
        }

        // TODO: Remove with ODS-2973, deprecated by CompositesRouteConfiguration
        protected virtual void ConfigureCompositeMetadataRoutes(
            HttpConfiguration config,
            object defaults,
            object constraints,
            string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadataComposites",
                       routeTemplate: "metadata/composites/v{compositeVersion}/" + schoolYearSegment
                                                                                 + "{organizationCode}/{compositeCategoryName}/swagger.json",
                       defaults: defaults,
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.Composites);
        }

        protected virtual void ConfigureSchemaSpecificMetadataRoutes(
            HttpConfiguration config,
            object defaults,
            object constraints,
            string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadataSchema",
                       routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "{schemaName}/swagger.json",
                       defaults: defaults,
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.Schema);
        }

        protected virtual void ConfigureComprehensiveMetadataRoute(
            HttpConfiguration config,
            object defaults,
            object constraints,
            string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadata",
                       routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "swagger.json",
                       defaults: defaults,
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.All);
        }

        protected virtual void ConfigureBulkMetadataRoute(HttpConfiguration config, object defaults, object constraints, string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadataBulk",
                       routeTemplate: "metadata/{otherName}/v{bulkVersion}/" + schoolYearSegment + "swagger.json",
                       defaults: defaults,
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.Bulk);
        }

        protected virtual void ConfigureIdentityMetadataRoute(HttpConfiguration config, object defaults, object constraints, string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadataIdentity",
                       routeTemplate: "metadata/{otherName}/v{identityVersion}/" + schoolYearSegment + "swagger.json",
                       defaults: defaults,
                       constraints: constraints
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.Identity);
        }

        private void ConfigureDefaultRoute(HttpConfiguration config, bool useSchoolYear = false)
        {
            var apiDefaults = new
                              {
                                  apiVersion = ApiVersionConstants.Ods,
                                  identityVersion = ApiVersionConstants.Identity
                              };

            config.Routes.MapHttpRoute(
                name: "DefaultApiCollection",
                routeTemplate: "data/v{apiVersion}/" + (useSchoolYear
                                   ? "{schoolYearFromRoute}/"
                                   : string.Empty) + "{schema}/{controller}",
                defaults: apiDefaults,
                constraints: useSchoolYear
                    ? CreateSchoolYearRouteConstraints()
                    : CreateRouteConstraints());

            config.Routes.MapHttpRoute(
                name: "DefaultApiItem",
                routeTemplate: "data/v{apiVersion}/" + (useSchoolYear
                                   ? "{schoolYearFromRoute}/"
                                   : string.Empty) + "{schema}/{controller}/{id}",
                defaults: apiDefaults,
                constraints: useSchoolYear
                    ? CreateSchoolYearWithIdRouteConstraints()
                    : CreateIdRouteConstraints());

            config.Routes.MapHttpRoute(
                name: "Root",
                routeTemplate: "",
                defaults: new
                          {
                              controller = "Version", action = "Index"
                          });
        }

        protected virtual void ConfigureIdentityRoutes(HttpConfiguration config, bool useSchoolYear = false)
        {
            var routeConfiguration = new IdentityRouteConfiguration();

            routeConfiguration.ConfigureRoutes(config, useSchoolYear);
        }

        private static object CreateRouteConstraints()
        {
            return new
                   {
                       controller = @"^((?!(identities)).)*$",
                   };
        }

        private static object CreateIdRouteConstraints()
        {
            return new
                   {
                       controller = @"^((?!(identities)).)*$",
                       id = @"^((?!(deletes)).)*$",
                   };
        }

        private static object CreateSchoolYearRouteConstraints()
        {
            return new
                   {
                       //do not use this path for the swagger, and other controllers not needing school year
                       controller = @"^((?!(identities)).)*$",
                       schoolYearFromRoute = @"^\d{4}$",
                   };
        }

        private static object CreateSchoolYearWithIdRouteConstraints()
        {
            return new
                   {
                       //do not use this path for the swagger, and other controllers not needing school year
                       controller = @"^((?!(identities)).)*$",
                       schoolYearFromRoute = @"^\d{4}$",
                       id = @"^((?!(deletes)).)*$",
                   };
        }

        private static object CreateSchoolYearConstraint(bool useSchoolYear)
        {
            return useSchoolYear
                ? new
                {
                    schoolYearFromRoute = @"^\d{4}$"
                }
                : null;
        }

        protected void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            // Map all attribute routes (Web 2.0 feature)
            // Note - MapHttpAttributeRoutes only maps attribute base routes in the current assembly;
            // In order to register attribute base routes in other assemblies we have to call MapHttpAttributeRoutes in that specific assembly
            config.MapHttpAttributeRoutes();
            IncludeAuthorizationRoute(config);
            ConfigureMetadataRoutes(config, useSchoolYear);
            ConfigureCompositeRoutes(config, useSchoolYear);
            // ConfigureBulkRoutes(config, useSchoolYear);
            ConfigureIdentityRoutes(config, useSchoolYear);
            ConfigureDefaultRoute(config, useSchoolYear);

            var configurationResolver = Container.ResolveAll<IRouteConfiguration>();

            foreach (var routeConfiguration in configurationResolver)
            {
                routeConfiguration.ConfigureRoutes(config, useSchoolYear);
            }
        }

        protected virtual void ConfigureRoutes(HttpConfiguration config)
        {
            // We are defaulting to a standard ODS instance.
            ConfigureRoutes(config, useSchoolYear: false);
        }

        // TODO: Remove with ODS-2973, deprecated by CompositesRouteConfiguration
        private void ConfigureCompositeRoutes(HttpConfiguration httpConfig, bool useSchoolYear = false)
        {
            var compositeMetadataProvider = Container.Resolve<ICompositesMetadataProvider>();

            string compositeRouteBase = "composites/v{compositeVersion}/" + (useSchoolYear
                                            ? "{schoolYearFromRoute}/"
                                            : string.Empty) + "{organizationCode}/{compositeCategory}/";

            // Construct the route constraint pattern for the composite categories defined.
            var compositeCategoryNames = compositeMetadataProvider.GetAllCategories()
                                                                  .Select(x => x.Name)
                                                                  .ToList();

            // Don't add routes for composites, if none exit.
            if (!compositeCategoryNames.Any())
            {
                return;
            }

            string allCompositeCategoriesConstraintExpression = string.Format(
                @"^(?i)({0})$",
                string.Join("|", compositeCategoryNames));

            // Define default route for all composites
            httpConfig.Routes.MapHttpRoute(
                name: "Composites",
                routeTemplate: compositeRouteBase + "{compositeName}/{id}",
                defaults: new
                          {
                              id = RouteParameter.Optional, controller = "CompositeResource"
                          },
                constraints: useSchoolYear
                    ? (object) new
                               {
                                   compositeCategory = allCompositeCategoriesConstraintExpression, schoolYearFromRoute = @"^\d{4}$"
                               }
                    : new
                      {
                          compositeCategory = allCompositeCategoriesConstraintExpression
                      }
            );

            var routeMetadataGroupedByCompositeCategory = compositeMetadataProvider.GetAllRoutes();

            foreach (var routeGrouping in routeMetadataGroupedByCompositeCategory)
            {
                string categoryName = routeGrouping.Key.Name;
                int routeNumber = 1;

                foreach (var routeElt in routeGrouping.Value)
                {
                    string relativeRouteTemplate = routeElt.AttributeValue("relativeRouteTemplate")
                                                           .TrimStart('/');

                    httpConfig.Routes.MapHttpRoute(
                        name: $"{categoryName}Composites{routeNumber++}",
                        routeTemplate: compositeRouteBase + relativeRouteTemplate,
                        defaults: new
                                  {
                                      controller = "CompositeResource"
                                  },
                        constraints: new
                                     {
                                         compositeCategory = categoryName
                                     });
                }
            }
        }
    }
}
