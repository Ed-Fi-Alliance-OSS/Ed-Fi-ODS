// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security;
using FakeItEasy;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Api.Middleware.Tests
{
    // NOTE: Initial test fixture generated using ChatGPT
    public class OdsInstanceSelectorTests
    {
        private IApiKeyContextProvider _apiKeyContextProvider;
        private IOdsInstanceConfigurationProvider _odsInstanceConfigurationProvider;
        private OdsInstanceSelector _odsInstanceSelector;
        private RouteValueDictionary _routeValueDictionary;

        [SetUp]
        public void SetUp()
        {
            _apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();
            _odsInstanceConfigurationProvider = A.Fake<IOdsInstanceConfigurationProvider>();
            _odsInstanceSelector = new OdsInstanceSelector(_apiKeyContextProvider, _odsInstanceConfigurationProvider);
            _routeValueDictionary = new RouteValueDictionary();
        }

        [Test]
        public async Task GetOdsInstanceAsync_ReturnsNull_WhenApiKeyContextIsNull()
        {
            // Arrange
            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(null);

            // Act
            var result = await _odsInstanceSelector.GetOdsInstanceAsync(_routeValueDictionary);

            // Assert
            result.ShouldBeNull();
        }

        [Test]
        public void GetOdsInstanceAsync_ThrowsException_WhenApiKeyContextHasNoOdsInstanceIds()
        {
            // Arrange
            var apiKeyContext = CreateApiKeyContext();
            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);

            // Act + Assert
            Assert.ThrowsAsync<ApiSecurityConfigurationException>(() => _odsInstanceSelector.GetOdsInstanceAsync(_routeValueDictionary));
        }

        [Test]
        public async Task GetOdsInstanceAsync_ReturnsOdsInstanceConfiguration_WhenApiKeyContextHasOneOdsInstanceId()
        {
            // Arrange
            var odsInstanceId = 1;
            
            var apiKeyContext = CreateApiKeyContext(odsInstanceId);

            var odsInstanceConfiguration = new OdsInstanceConfiguration(
                odsInstanceId,
                (ulong)odsInstanceId,
                "TheConnectionString",
                new Dictionary<string, string>(),
                new Dictionary<DerivativeType, string>());
            
            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(odsInstanceId)).Returns(odsInstanceConfiguration);

            // Act
            var result = await _odsInstanceSelector.GetOdsInstanceAsync(_routeValueDictionary);

            // Assert
            result.ShouldBe(odsInstanceConfiguration);
        }

        [Test]
        public async Task GetOdsInstanceAsync_ReturnsOdsInstanceConfiguration_WhenApiKeyContextHasMoreThanOneOdsInstanceId_AndOneMatchingRouteKeyAndValue()
        {
            // Arrange
            var odsInstanceIds = new[] { 1, 2 };

            var apiKeyContext = CreateApiKeyContext(odsInstanceIds);

            var odsInstanceConfiguration_1 = new OdsInstanceConfiguration(
                1,
                (ulong)1,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2022" } },
                new Dictionary<DerivativeType, string>());

            var odsInstanceConfiguration_2 = new OdsInstanceConfiguration(
                2,
                (ulong)2,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2023"} },
                new Dictionary<DerivativeType, string>());

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(1)).Returns(odsInstanceConfiguration_1);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(2)).Returns(odsInstanceConfiguration_2);

            _routeValueDictionary.Add("schoolYear", "2023");

            // Act
            var result = await _odsInstanceSelector.GetOdsInstanceAsync(_routeValueDictionary);

            // Assert
            result.ShouldBe(odsInstanceConfiguration_2);
        }

        [Test]
        public async Task GetOdsInstanceAsync_ReturnsNull_WhenApiKeyContextHasMultipleOdsInstanceIds_AndNoMatchingRouteKeyAndValue()
        {
            // Arrange
            var odsInstanceIds = new[] { 1, 2 };

            var apiKeyContext = CreateApiKeyContext(odsInstanceIds);

            var odsInstanceConfiguration_1 = new OdsInstanceConfiguration(
                1,
                (ulong)1,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2022" } },
                new Dictionary<DerivativeType, string>());

            var odsInstanceConfiguration_2 = new OdsInstanceConfiguration(
                2,
                (ulong)2,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2023" } },
                new Dictionary<DerivativeType, string>());

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(1)).Returns(odsInstanceConfiguration_1);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(2)).Returns(odsInstanceConfiguration_2);

            _routeValueDictionary.Add("schoolYear", "2024");

            // Act 
            var result = await _odsInstanceSelector.GetOdsInstanceAsync(_routeValueDictionary);

            // Assert
            result.ShouldBeNull();
        }

        private static ApiKeyContext CreateApiKeyContext(params int[] odsInstanceIds)
        {
            return new ApiKeyContext(
                odsInstanceIds: odsInstanceIds,
                apiKey: "abc",
                claimSetName: "TestClaimSet",
                educationOrganizationIds: new [] { 1 },
                namespacePrefixes: Array.Empty<string>(),
                profiles: Array.Empty<string>(),
                studentIdentificationSystemDescriptor: null,
                creatorOwnershipTokenId: null,
                ownershipTokenIds: Array.Empty<short>(),
                apiClientId: 123);
        }
    }
}
