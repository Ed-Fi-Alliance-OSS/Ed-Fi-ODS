// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common._Installers.ComponentNaming;
using EdFi.Ods.Composites.Enrollment;
using EdFi.Ods.Composites.Test;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Standard.Container.Installers;
using EdFi.Ods.WebService.Tests.Owin;
using EdFi.Ods.WebService.Tests.Profiles;
using EdFi.TestObjects;
using EdFi.TestObjects.Builders;
using log4net;
using Rhino.Mocks;

namespace EdFi.Ods.WebService.Tests.Composites
{
    public class CompositesTestStartup : WebServiceTestsStartupBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(CompositesTestStartup));

        public CompositesTestStartup()
        {
            // Ensure assembly containing Composites specification is loaded
            AssemblyLoader.EnsureLoaded<
                Marker_EdFi_Ods_Composites_Test,
                Marker_EdFi_Ods_Composites_Enrollment>();
        }

        public IWindsorContainer InternalContainer
        {
            get { return Container; }
        }

        /// <summary>
        /// Provides the startup class with the ability to install security components.  Suggested implementation is to instantiate and invoke the <b>SecurityComponentsInstaller</b> from the host process.
        /// </summary>
        /// <param name="container">The IoC container for performing service registrations.</param>
        protected override void InstallSecurityComponents(IWindsorContainer container) { }

        protected override void RegisterFilters(HttpConfiguration config)
        {
            RegisterCoreFilters(config);

            // Note:  Not registered --> RegisterAuthorizationFilters(config);
        }

        protected override void InstallOpenApiMetadata(IWindsorContainer container)
        {
            // No OpenApiMetadata installation required.
        }

        protected override void InstallExtensions(IWindsorContainer container)
        {
            // No Extension installation required.
        }

        protected IOAuthTokenValidator CreateOAuthTokenValidator()
        {
            var oAuthTokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

            oAuthTokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                               .Return(
                                    Task.FromResult(
                                        new ApiClientDetails
                                        {
                                            ApiKey = Guid.NewGuid()
                                                         .ToString("n"),
                                            ApplicationId = 999, ClaimSetName = "SomeClaimSet",
                                            NamespacePrefixes = OwinTestBase.DefaultTestNamespacePrefixes, EducationOrganizationIds = new List<int>
                                                                                                                                      {
                                                                                                                                          123, 234
                                                                                                                                      }
                                        }));

            return oAuthTokenValidator;
        }

        protected ISecurityRepository CreateSecurityRepository()
        {
            return new OwinSecurityRepository();
        }

        protected override void InstallConfigurationSpecificInstaller(IWindsorContainer container)
        {
            container.Register(
                Component.For<IConfigConnectionStringsProvider>()
                         .ImplementedBy<AppConfigConnectionStringsProvider>());

            container.Register(
                Component.For<IConfigValueProvider>()
                         .ImplementedBy<NameValueCollectionConfigValueProvider>());

            container.Register(
                Component.For<IConfigValueProvider>()
                         .ImplementedBy<AppConfigValueProvider>());

            container.Register(
                Component.For<IConfigSectionProvider>()
                         .ImplementedBy<AppConfigSectionProvider>());

            container.Register(
                Component.For<ICacheProvider>()
                         .ImplementedBy<AspNetCacheProvider>());

            // Mock ApikeyContextProvider for the ProfilesAuthorizationFilter Tests
            var suppliedApiKeyContextProvider = MockRepository.GenerateStub<IApiKeyContextProvider>();

            container.Register(
                Component.For<IApiKeyContextProvider>()
                         .Instance(suppliedApiKeyContextProvider)
                         .IsDefault());

            container.Register(
                Component.For<IContextStorage>()
                         .ImplementedBy<HashtableContextStorage>()
                         .IsDefault());

            RegisterOdsDatabase(container);

            container.Register(
                Component
                   .For<ITestObjectFactory>()
                   .Instance(CreateTestObjectFactory()));

            container.Register(
                Component.For<IOAuthTokenValidator>()
                         .Instance(CreateOAuthTokenValidator())
                         .IsDefault());

            container.Register(
                Component.For<ISecurityRepository>()
                         .Instance(CreateSecurityRepository())
                         .IsDefault());

            container.Install(new EdFiOdsStandardInstaller());
        }

        private static TestObjectFactory CreateTestObjectFactory()
        {
            var builderFactory = new BuilderFactory();

            builderFactory.AddToFront<EntityParentBackreferenceValueBuilder>();
            builderFactory.AddToFront<FakeEdFiTypeValueBuilder>();
            builderFactory.AddToFront<FakeEdFiDescriptorValueBuilder>();
            builderFactory.AddToFront<FakePersonIdentifierValueBuilder>();
            StringValueBuilder.GenerateEmptyStrings = false;
            StringValueBuilder.GenerateNulls = false;

            var testObjectFactory = new TestObjectFactory(
                builderFactory.GetBuilders(),
                new SystemActivator(),
                new CustomAttributeProvider());

            return testObjectFactory;
        }

        protected virtual void RegisterOdsDatabase(IWindsorContainer container)
        {
            var connectionStringProvider =
                new LiteralDatabaseConnectionStringProvider(GlobalDatabaseSetupFixture.SpecFlowDatabaseConnectionString);

            container.Register(
                Component.For<IDatabaseConnectionStringProvider>()
                         .Named("IDatabaseConnectionStringProvider.Ods")
                         .Instance(connectionStringProvider));
        }
    }
}
