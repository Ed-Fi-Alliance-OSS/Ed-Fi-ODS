// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.CreateOrUpdate;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Profiles.Test;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Standard;
using EdFi.Ods.Standard.Container.Installers;
using EdFi.Ods.WebService.Tests._Installers;
using EdFi.Ods.WebService.Tests.Owin;
using EdFi.TestObjects;
using EdFi.TestObjects.Builders;
using FakeItEasy;
using log4net.Config;
using Microsoft.Owin.Logging;
using Owin;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public class ProfilesTestStartup : WebServiceTestsStartupBase
    {
        public const string EdFiNamespacePrefix = "uri://ed-fi.org";
        public static readonly List<string> DefaultTestNamespacePrefixes = new List<string> { EdFiNamespacePrefix };

        public IWindsorContainer InternalContainer
        {
            get { return Container; }
        }

        /// <summary>
        /// Provides the startup class with the ability to install security components.  Suggested implementation is to instantiate and invoke the <b>SecurityComponentsInstaller</b> from the host process.
        /// </summary>
        /// <param name="container">The IoC container for performing service registrations.</param>
        /// <example>
        /// protected override void InstallSecurityComponents(IWindsorContainer container)
        /// {
        ///     container.Install(new SecurityComponentsInstaller());
        /// }
        /// </example>
        protected override void InstallSecurityComponents(IWindsorContainer container)
        {
            // No security components
        }

        protected override void InstallOpenApiMetadata(IWindsorContainer container)
        {
            // No OpenApiMetadata installation required.
        }

        public override void Configuration(IAppBuilder appBuilder)
        {
            InitializeContainer(Container);
            InstallWebApiComponents();

            // TODO: GKM - Profiles - Need to register additional controllers for the test profiles
            // Controllers
            Container.Register(
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Profiles_Test>()
                    .BasedOn<ApiController>()
                    .LifestyleTransient());

            InstallConfigurationSpecificInstaller(Container);

            // TODO: GKM - No NHibernate desired for testing
            // NHibernate initialization
            //(new NHibernateConfigurator()).Configure(Container);

            var httpConfig = new HttpConfiguration { DependencyResolver = Container.Resolve<IDependencyResolver>() };

            // Replace the default controller selector with one based on the final namespace segment (to enable support of Profiles)
            httpConfig.Services.Replace(
                typeof(IHttpControllerSelector),
                new ProfilesAwareHttpControllerSelector(
                    httpConfig,
                    Container.Resolve<IProfileResourceNamesProvider>(),
                    Container.Resolve<ISchemaNameMapProvider>()));

            //httpConfig.EnableSystemDiagnosticsTracing();
            httpConfig.EnableCors(new EnableCorsAttribute("*", "*", "*", "*"));
            ConfigureFormatters(httpConfig);
            ConfigureRoutes(httpConfig);
            ConfigureDelegatingHandlers(httpConfig, Container.ResolveAll<DelegatingHandler>());
            RegisterFilters(httpConfig);
            RegisterAuthenticationProvider(Container);

            appBuilder.UseWebApi(httpConfig);

            XmlConfigurator.Configure();
            appBuilder.SetLoggerFactory(new Log4NetLoggerFactory());

            InstallOpenApiMetadata(Container);
        }

        protected override void InstallWebApiComponents()
        {
            // TODO: GKM - Profiles - Modified installer in use for testing purposes
            Container.Install(new ProfilesTestingWebApiInstaller());

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

        protected override void InstallConfigurationSpecificInstaller(IWindsorContainer container)
        {
            container.Register(
                Component.For<IConfigConnectionStringsProvider>()
                    .ImplementedBy<AppConfigConnectionStringsProvider>());

            container.Register(
                Component.For<IConfigValueProvider>()
                    .ImplementedBy<AppConfigValueProvider>());

            container.Register(
                Component.For<IConfigSectionProvider>()
                    .ImplementedBy<AppConfigSectionProvider>());

            container.Register(
                Component.For<ICacheProvider>()
                    .ImplementedBy<AspNetCacheProvider>());

            var suppliedApiKeyContextProvider = A.Fake<IApiKeyContextProvider>();

            A.CallTo(() => suppliedApiKeyContextProvider.GetApiKeyContext())
                .ReturnsLazily(GetSuppliedApiKeyContext);

            container.Register(
                Component.For<IApiKeyContextProvider>()
                    .Instance(suppliedApiKeyContextProvider)
                    .IsDefault());

            container.Register(
                Component.For<IContextStorage>()
                    .ImplementedBy<HashtableContextStorage>()
                    .IsDefault());

            container.Register(
                Component
                    .For<ITestObjectFactory>()
                    .Instance(CreateTestObjectFactory()));

            RegisterFakeRepository(container);

            container.Install(new EdFiOdsStandardInstaller());

            var domainModelProvider = Container.Resolve<IDomainModelProvider>();

            Container.Register(
                Component.For<ISchemaNameMapProvider>()
                    .ImplementedBy<SchemaNameMapProvider>()
                    .DependsOn(
                        Dependency.OnValue(
                            "schemas",
                            domainModelProvider.GetDomainModel()
                                .Schemas)));

            DescriptorsCache.GetCache = () => new FakeDescriptorsCache();
            PersonUniqueIdToUsiCache.GetCache = () => new FakePersonUniqueIdToUsiCache();

            container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                    .Named("IDatabaseConnectionStringProvider.Admin")
                    .ImplementedBy<NamedDatabaseConnectionStringProvider>()
                    .DependsOn(Dependency.OnValue("connectionStringName", "EdFi_Admin")));

            container.Register(
                Component.For<IDatabaseEngineProvider>()
                    .ImplementedBy<DatabaseEngineProvider>());

            container.Register(
                Component.For<IApiConfigurationProvider>()
                    .ImplementedBy<ApiConfigurationProvider>());

            container.Register(
                Component
                    .For<ISecurityContextFactory>()
                    .ImplementedBy<SecurityContextFactory>());

            container.Register(
                Component.For<IOAuthTokenValidator>()
                    .Instance(CreateOAuthTokenValidator())
                    .IsDefault());

            container.Register(
                Component.For<ISecurityRepository>()
                    .ImplementedBy<SecurityRepository>());
        }

        protected IOAuthTokenValidator CreateOAuthTokenValidator()
        {
            var oAuthTokenValidator = A.Fake<IOAuthTokenValidator>();

            A.CallTo(() => oAuthTokenValidator.GetClientDetailsForTokenAsync(A<string>.Ignored))
                .Returns(
                    Task.FromResult(
                        new ApiClientDetails
                        {
                            ApiKey = Guid.NewGuid()
                                .ToString("n"),
                            ApplicationId = 999,
                            ClaimSetName = "SomeClaimSet",
                            NamespacePrefixes = DefaultTestNamespacePrefixes,
                            EducationOrganizationIds = new List<int>
                            {
                                123,
                                234
                            }
                        }));

            return oAuthTokenValidator;
        }

        protected virtual void RegisterFakeRepository(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(IUpsertEntity<>))
                    .Forward(typeof(IGetEntityById<>))
                    .Forward(typeof(IGetEntitiesBySpecification<>))
                    .ImplementedBy(typeof(FakeRepository<>)));
        }

        private static TestObjectFactory CreateTestObjectFactory()
        {
            var builderFactory = new BuilderFactory();

            builderFactory.AddToFront<EntityParentBackreferenceValueBuilder>();
            builderFactory.AddToFront<FakeEdFiTypeValueBuilder>();
            builderFactory.AddToFront<FakeEdFiDescriptorValueBuilder>();
            builderFactory.AddToFront<FakePersonIdentifierValueBuilder>();
            builderFactory.AddToFront<ClassicDictionaryEmptyValueBuilder>();
            StringValueBuilder.GenerateEmptyStrings = false;
            StringValueBuilder.GenerateNulls = false;

            var testObjectFactory = new TestObjectFactory(
                builderFactory.GetBuilders(),
                new SystemActivator(),
                new CustomAttributeProvider());

            return testObjectFactory;
        }

        protected override void RegisterFilters(HttpConfiguration config)
        {
            RegisterCoreFilters(config);

            config.Filters.Add(
                new ProfilesAuthorizationFilter(
                    Container.Resolve<IApiKeyContextProvider>(),
                    Container.Resolve<IProfileResourceNamesProvider>()));
        }

        private ApiKeyContext GetSuppliedApiKeyContext()
        {
            if (ScenarioContext.Current == null || !ScenarioContext.Current.TryGetValue(
                    ScenarioContextKeys.AssignedProfiles, out List<string> profiles))
            {
                profiles = new List<string>();
            }

            return new ApiKeyContext(null, null, null, null, profiles, null, null, null);
        }

        // Provides empty overrides to disable certain components for testing purposes.
        internal class ProfilesTestingWebApiInstaller : WebApiInstaller
        {
            protected override void RegisterNHibernateComponents(IWindsorContainer container) { }
        }
    }
}
