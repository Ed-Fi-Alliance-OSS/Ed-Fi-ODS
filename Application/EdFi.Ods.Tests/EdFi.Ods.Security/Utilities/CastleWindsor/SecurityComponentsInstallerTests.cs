// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Security.Authorization.ContextDataProviders.EdFi;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Security.Container.Installers;
using EdFi.Ods.Standard;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using Test.Common;
using Test.Common._Stubs;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Utilities.CastleWindsor
{
    // Fake/Null Dependency needed for container testing.
    public class NullDatabaseConnectionStringProvider : IDatabaseConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return null;
        }
    }

    public class SecurityComponentsInstallerTests
    {
        [TestFixture]
        public class When_registering_in_the_container : TestBase
        {
            private IWindsorContainer testContainer;

            [OneTimeSetUp]
            public void Setup()
            {
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Standard>();

                var factory = new InversionOfControlContainerFactory();
                testContainer = factory.CreateContainer(c => { c.Kernel.Resolver.AddSubResolver(new ArrayResolver(c.Kernel, true)); });

                testContainer.AddFacility<TypedFactoryFacility>();

                testContainer.Register(
                    Component
                       .For<IConfigValueProvider>()
                       .ImplementedBy<NameValueCollectionConfigValueProvider>());

                testContainer.Register(
                    Component
                       .For<ICacheProvider>()
                       .ImplementedBy<MemoryCacheProvider>());

                testContainer.Register(
                    Component
                       .For<IDatabaseConnectionStringProvider>()
                       .ImplementedBy<NullDatabaseConnectionStringProvider>());

                testContainer.Register(
                    Component
                       .For<IContextStorage>()
                       .ImplementedBy<HashtableContextStorage>());

                testContainer.Register(
                    Component
                       .For<IApiKeyContextProvider>()
                       .ImplementedBy<ApiKeyContextProvider>());

                testContainer.Register(
                    Component
                       .For<ISecurityRepository>()
                       .ImplementedBy<StubSecurityRepository>());

                testContainer.Register(
                    Component
                       .For<ISessionFactory>()
                       .Instance(MockRepository.GenerateStub<ISessionFactory>()));

                testContainer.Register(
                    Component.For<IEdFiOdsInstanceIdentificationProvider>()
                             .Instance(MockRepository.GenerateStub<IEdFiOdsInstanceIdentificationProvider>()));

                testContainer.Install(new SecurityComponentsInstaller());
            }

            [Test]
            public void Should_resolve_the_EdFi_authorization_provider_and_all_of_its_dependencies()
            {
                // These should not throw exceptions.
                var edFiAuthorizationProvider = testContainer.Resolve<IEdFiAuthorizationProvider>();
            }

            [Test]
            public void Should_resolve_the_EdFi_authorization_strategies_and_all_of_its_dependencies()
            {
                var expectedTypes =
                    (from t in typeof(SecurityComponentsInstaller).Assembly.GetTypes()
                     where !t.IsAbstract
                           && typeof(IEdFiAuthorizationStrategy).IsAssignableFrom(t)
                     orderby t.FullName
                     select t.FullName.TrimAt('`'))
                   .ToList();

                var edFiAuthorizationStrategies = testContainer.ResolveAll<IEdFiAuthorizationStrategy>();

                var actualTypes = edFiAuthorizationStrategies
                                 .Select(
                                      x => x.GetType()
                                            .FullName.TrimAt('`'))
                                 .OrderBy(x => x)
                                 .ToList();

                Assert.That(actualTypes, Is.EquivalentTo(expectedTypes));
            }

            [Test]
            public void Should_resolve_the_relationship_based_authorization_context_providers_for_the_corresponding_entity_types()
            {
                var provider =
                    testContainer.Resolve<IRelationshipsAuthorizationContextDataProvider<IStudent, RelationshipsAuthorizationContextData>>();

                provider.GetType()
                        .ShouldBe(typeof(StudentRelationshipsAuthorizationContextDataProvider<RelationshipsAuthorizationContextData>));
            }
        }
    }
}
