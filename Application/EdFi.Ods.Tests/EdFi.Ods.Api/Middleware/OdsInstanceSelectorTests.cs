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
        private Dictionary<string, object> _routeValueDictionary;

        [SetUp]
        public void SetUp()
        {
            _apiKeyContextProvider = A.Fake<IApiKeyContextProvider>();
            _odsInstanceConfigurationProvider = A.Fake<IOdsInstanceConfigurationProvider>();
            _odsInstanceSelector = new OdsInstanceSelector(_apiKeyContextProvider, _odsInstanceConfigurationProvider);
            _routeValueDictionary = new Dictionary<string, object>();
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
        public async Task GetOdsInstanceAsync_ReturnsOdsInstanceConfiguration_WhenApiKeyContextHasMoreThanOneOdsInstanceId_AndOneMatchingAllContextValues()
        {
            // Arrange
            var odsInstanceIds = new[] { 1, 2, 3 };

            var apiKeyContext = CreateApiKeyContext(odsInstanceIds);

            var odsInstanceConfiguration_1 = new OdsInstanceConfiguration(
                1,
                1UL,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2022" }, { "secondKey", "Abc" } },
                new Dictionary<DerivativeType, string>());

            var odsInstanceConfiguration_2 = new OdsInstanceConfiguration(
                2,
                2UL,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2022"}, { "secondKey", "Xyz" } },
                new Dictionary<DerivativeType, string>());

            var odsInstanceConfiguration_3 = new OdsInstanceConfiguration(
                3,
                3UL,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2023"}, { "secondKey", "Abc" } },
                new Dictionary<DerivativeType, string>());

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(1)).Returns(odsInstanceConfiguration_1);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(2)).Returns(odsInstanceConfiguration_2);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(3)).Returns(odsInstanceConfiguration_3);

            _routeValueDictionary.Add("schoolYear", "2022");
            _routeValueDictionary.Add("secondKey", "Xyz");

            // Act
            var result = await _odsInstanceSelector.GetOdsInstanceAsync(_routeValueDictionary);

            // Assert
            result.ShouldBe(odsInstanceConfiguration_2);
        }
        
        [TestCase("2022", "NoMatch")]
        [TestCase("2024", "Abc")]
        public async Task GetOdsInstanceAsync_ReturnsNotFoundException_WhenApiKeyContextHasMultipleOdsInstanceIds_AndNoneMatchingAllContextValues(
            string schoolYearRouteValue, string secondKeyRouteValue)
        {
            // Arrange
            var odsInstanceIds = new[] { 1, 2, 3 };

            var apiKeyContext = CreateApiKeyContext(odsInstanceIds);

            var odsInstanceConfiguration_1 = new OdsInstanceConfiguration(
                1,
                1UL,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2022" }, { "secondKey", "Abc" } },
                new Dictionary<DerivativeType, string>());

            var odsInstanceConfiguration_2 = new OdsInstanceConfiguration(
                2,
                2UL,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2022"}, { "secondKey", "Xyz" } },
                new Dictionary<DerivativeType, string>());

            var odsInstanceConfiguration_3 = new OdsInstanceConfiguration(
                3,
                3UL,
                "TheConnectionString",
                new Dictionary<string, string> { { "schoolYear", "2023"}, { "secondKey", "Abc" } },
                new Dictionary<DerivativeType, string>());

            A.CallTo(() => _apiKeyContextProvider.GetApiKeyContext()).Returns(apiKeyContext);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(1)).Returns(odsInstanceConfiguration_1);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(2)).Returns(odsInstanceConfiguration_2);
            A.CallTo(() => _odsInstanceConfigurationProvider.GetByIdAsync(3)).Returns(odsInstanceConfiguration_3);

            _routeValueDictionary.Add("schoolYear", schoolYearRouteValue);
            _routeValueDictionary.Add("secondKey", secondKeyRouteValue);

            // Act & Assert
             Assert.ThrowsAsync<NotFoundException>(async () => await _odsInstanceSelector.GetOdsInstanceAsync(_routeValueDictionary));
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
