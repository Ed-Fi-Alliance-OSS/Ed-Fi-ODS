// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization
{
    [TestFixture]
    public class ResourceClaimUriProviderTests
    {
        private ISchemaNameMapProvider _schemaNameMapProvider;
        private ResourceClaimUriProvider _uriProvider;

        [SetUp]
        public void SetUp()
        {
            _schemaNameMapProvider = A.Fake<ISchemaNameMapProvider>();
            _uriProvider = new ResourceClaimUriProvider(_schemaNameMapProvider);
        }

        [Test]
        public void GetResourceClaimUris_WithNullResourceType_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Should.Throw<ArgumentNullException>(() => _uriProvider.GetResourceClaimUris(null as Type))
                .ParamName.ShouldBe("resourceType");
        }

        [Test]
        public void GetResourceClaimUris_CallsGetResourceClaimUrisWithType_ReturnsResourceClaimUriAndLegacyResourceClaimUri()
        {
            // Arrange
            var resourceType = typeof(global::EdFi.Ods.Api.Common.Models.Resources.TestResource.TestSchema.TestResource);
            var schemaNameMap = new SchemaNameMap("Test Schema", "testschema", "testSchema", "TestSchema");
            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByProperCaseName("TestSchema"))
                .Returns(schemaNameMap);

            // Act
            var uris = _uriProvider.GetResourceClaimUris(resourceType);

            // Assert
            uris[0].ShouldBe("http://ed-fi.org/ods/identity/claims/testSchema/testResource");
            uris[1].ShouldBe("http://ed-fi.org/ods/identity/claims/testResource");
        }

        [Test]
        public void GetResourceClaimUris_CallsGetResourceClaimUrisWithTypeMultipleTimes_ReturnsSameArrayInstanceOfUris()
        {
            // Arrange
            var resourceType = typeof(global::EdFi.Ods.Api.Common.Models.Resources.TestResource.TestSchema.TestResource);
            var schemaNameMap = new SchemaNameMap("Test Schema", "testschema", "testSchema", "TestSchema");
            A.CallTo(() => _schemaNameMapProvider.GetSchemaMapByProperCaseName("TestSchema"))
                .Returns(schemaNameMap);

            // Act
            var uris = _uriProvider.GetResourceClaimUris(resourceType);
            var uris2 = _uriProvider.GetResourceClaimUris(resourceType);

            // Assert
            uris2.ShouldBeSameAs(uris);
        }
    }
}

namespace EdFi.Ods.Api.Common.Models.Resources.TestResource.TestSchema
{
    public class TestResource { }
}
