// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Web.Http;
using Castle.Windsor;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.Dependencies;
using EdFi.Ods.Api.ContainerBuilders;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Standard;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Startup.ContainerBuilders
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class WindsorContainerBuilderTests
    {
        public class When_building_the_container : TestFixtureBase
        {
            private WindsorContainerBuilder _systemUnderTest;
            private IWindsorContainer _result;

            protected override void Arrange()
            {
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Standard>();
                _systemUnderTest = new WindsorContainerBuilder();
            }

            protected override void Act()
            {
                _result = _systemUnderTest.Build();
            }

            [Test]
            public void Should_build_with_success()
                => AssertHelper.All(
                    () => _result.ShouldNotBeNull(),
                    () => _result.ShouldBeOfType<WindsorContainerEx>());

            [Test]
            public void Should_contain_a_registration_for_HttpConfiguration()
                => _result.Kernel.HasComponent(typeof(HttpConfiguration));

            [Test]
            public void Should_contain_a_registration_for_HttpRouteCollection()
                => _result.Kernel.HasComponent(typeof(HttpRouteCollection));

            [Test]
            public void Should_contain_facilities() => _result.Kernel.GetFacilities().Length.ShouldBeGreaterThan(0);

            [Test]
            public void Should_set_the_ClaimsPrincipalSelector() => ClaimsPrincipal.ClaimsPrincipalSelector.ShouldNotBeNull();

            [Test]
            public void Should_set_the_DescriptorsCache() => DescriptorsCache.GetCache.ShouldNotBeNull();

            [Test]
            public void Should_set_the_generated_artifacts()
                => AssertHelper.All(
                    () => GeneratedArtifactStaticDependencies.AuthorizationContextProvider.ShouldNotBeNull(),
                    () => GeneratedArtifactStaticDependencies.ResourceModelProvider.ShouldNotBeNull());

            [Test]
            public void Should_set_the_PersonIdToUsiCache() => PersonUniqueIdToUsiCache.GetCache.ShouldNotBeNull();

            [Test]
            public void Should_set_the_ResourceModel() => ResourceModelHelper.ResourceModel.ShouldNotBeNull();
        }
    }
}
