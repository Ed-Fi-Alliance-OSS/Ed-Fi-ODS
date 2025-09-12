// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers
{
    [TestFixture]
    public class VersionControllerTests
    {
        private IDomainModelProvider _domainModelProvider;
        private IApiVersionProvider _apiVersionProvider;
        private ApiSettings _apiSettings;
        private VersionController _controller;
        private FakeFeatureManager _featureManager;

        [SetUp]
        public void SetUp()
        {
            // Create mocks
            _apiVersionProvider = A.Fake<IApiVersionProvider>();
            _domainModelProvider = A.Fake<IDomainModelProvider>();

            // IApiVersionProvider
            A.CallTo(() => _apiVersionProvider.ApplicationName).Returns("Ed-Fi Alliance ODS/API");
            A.CallTo(() => _apiVersionProvider.Version).Returns("1.0.0");
            A.CallTo(() => _apiVersionProvider.InformationalVersion).Returns("1.0.0-beta");
            A.CallTo(() => _apiVersionProvider.Suite).Returns("EdFi");
            A.CallTo(() => _apiVersionProvider.Build).Returns("12345");

            // IDomainModelProvider
            var builder = new DomainModelBuilder();
            builder.AddSchema(new SchemaDefinition("Schema1", "schema1", "1.0.0", "1.0.0-beta"));
            builder.AddSchema(new SchemaDefinition("Schema2", "schema2", "2.0.0", "2.0.0-beta"));
            var domainModel = builder.Build();

            A.CallTo(() => _domainModelProvider.GetDomainModel()).Returns(domainModel);

            // Initialize API with all features enabled
            _apiSettings = new ApiSettings();
            _featureManager = new FakeFeatureManager();

            // Request context initialization
            var httpContext = new DefaultHttpContext
            {
                Request =
                {
                    Scheme = "http",
                    Host = new HostString("localhost"), 
                    RouteValues = new RouteValueDictionary(), 
                }
            };

            // Controller needs a controller context 
            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            _controller = new VersionController(_domainModelProvider, _apiVersionProvider, _featureManager, _apiSettings)
            {
                ControllerContext = controllerContext
            };
        }

        // Test cases are combination of single/multi tenant, with/without ODS context, and ODS context with one or more segments/keys
        [TestCase(false, null, null, null, null)]
        [TestCase(false, "{schoolYearFromRoute:range(2000,2099)}", null, null, "{schoolYearFromRoute}/")]
        [TestCase(false, "{schoolYearFromRoute:range(2000,2099)}", null, new [] {"2023"}, "2023/")]
        [TestCase(false, "{schoolYearFromRoute}/{ssn:regex(^(\\d{{3}}-)?\\d{{2}}-\\d{{4}}$)}", null, null, "{schoolYearFromRoute}/{ssn}/")]
        [TestCase(false, "{schoolYearFromRoute}/{ssn:regex(^(\\d{{3}}-)?\\d{{2}}-\\d{{4}}$)}", null, new[] {"2023", null}, "2023/{ssn}/")]
        [TestCase(false, "{schoolYearFromRoute}/{ssn:regex(^(\\d{{3}}-)?\\d{{2}}-\\d{{4}}$)}", null, new[] {"2023", "TheSSN"}, "2023/TheSSN/")]
        [TestCase(true, null, null, null, "{tenantIdentifier}/")]
        [TestCase(true, null, "Tenant1", null, "Tenant1/")]
        [TestCase(true, "{schoolYearFromRoute}", "Tenant1", null, "Tenant1/{schoolYearFromRoute}/")]
        [TestCase(true, "{schoolYearFromRoute}", "Tenant1", new [] {"2023"}, "Tenant1/2023/")]
        [TestCase(true, "{schoolYearFromRoute}/{somethingElse}", "Tenant1", new[] {"2023", "TheThing"}, "Tenant1/2023/TheThing/")]
        [TestCase(true, "{schoolYearFromRoute}/{ssn:regex(^(\\d{{3}}-)?\\d{{2}}-\\d{{4}}$)}", "Tenant1", null, "Tenant1/{schoolYearFromRoute}/{ssn}/")]
        [TestCase(true, "{schoolYearFromRoute}/{ssn:regex(^(\\d{{3}}-)?\\d{{2}}-\\d{{4}}$)}", "Tenant1", new[] {"2023", null}, "Tenant1/2023/{ssn}/")]
        [TestCase(true, "{schoolYearFromRoute}/{ssn:regex(^(\\d{{3}}-)?\\d{{2}}-\\d{{4}}$)}", "Tenant1", new[] {"2023", "TheSSN"}, "Tenant1/2023/TheSSN/")]
        public void Get_WithProvidedMultTenancyAndOdsRouteContextSettings_ShouldBuildRoutesWithCorrectRootPathSegments(
            bool isMultiTenant, string odsContextRouteTemplate, 
            string tenantIdentifierRouteValue, string[] suppliedOdsContextRouteValues, 
            string expectedPathRootSegment)
        {
            // Arrange

            // Configure ApiSettings (no multi-tenancy, no ODS context)
            if (!isMultiTenant)
            {
                DisableFeatures(ApiFeature.MultiTenancy.GetConfigKeyName());
            }

            if (!string.IsNullOrEmpty(odsContextRouteTemplate))
            {
                _apiSettings.OdsContextRouteTemplate = odsContextRouteTemplate;
            }

            // Initialize Route data
            if (!string.IsNullOrEmpty(tenantIdentifierRouteValue))
            {
                SetRouteValue("tenantIdentifier", tenantIdentifierRouteValue); 
            }

            if (suppliedOdsContextRouteValues is { Length: > 0 })
            {
                // See https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-7.0#route-constraints
                var templateRouteKeys = OdsContextRouteTemplateHelpers.GetRouteTemplateKeys(_apiSettings.OdsContextRouteTemplate);

                // Set the supplied route values
                for (int i = 0; i < templateRouteKeys.Length; i++)
                {
                    var routeKey = templateRouteKeys[i];

                    // Only apply the route value if a positional value is provided, and is not null 
                    if (suppliedOdsContextRouteValues.Length > i && suppliedOdsContextRouteValues[i] != null)
                    {
                        SetRouteValue(routeKey, suppliedOdsContextRouteValues[i]); 
                    }
                }
            }

            var expectedContent = new VersionController.VersionResponse(
                "1.0.0",
                "Ed-Fi Alliance ODS/API",
                "1.0.0-beta",
                "EdFi",
                "12345",
                new VersionController.DataModelVersion[]
                {
                    new("Schema1", "1.0.0", "1.0.0-beta"),
                    new("Schema2", "2.0.0", "2.0.0-beta"),
                },
                new Dictionary<string, string>
                {
                    { "dependencies", $"http://localhost/{expectedPathRootSegment}metadata/data/v3/dependencies" },
                    { "openApiMetadata", $"http://localhost/{expectedPathRootSegment}metadata/" },
                    { "oauth", $"http://localhost/{expectedPathRootSegment}oauth/token" },
                    { "oauthTokenIntrospection", $"http://localhost/{expectedPathRootSegment}oauth/token_info" },
                    { "dataManagementApi", $"http://localhost/{expectedPathRootSegment}data/v3/" },
                    { "xsdMetadata", $"http://localhost/{expectedPathRootSegment}metadata/xsd" },
                    { "changeQueries", $"http://localhost/{expectedPathRootSegment}changeQueries/v1/" },
                    { "composites", $"http://localhost/{expectedPathRootSegment}composites/v1/" },
                    { "identity", $"http://localhost/{expectedPathRootSegment}identity/v2/" }
                });

            // Act
            var result = _controller.Get() as OkObjectResult;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result.Value.ShouldBeEquivalentTo(expectedContent);
        }

        private void SetRouteValue(string key, string value)
        {
            _controller.Request.RouteValues[key] = value;
        }

        private void DisableFeatures(params string[] disabledFeatureNames)
        {
            foreach (string featureName in disabledFeatureNames)
            {
                _featureManager.SetState(featureName, false);
            }
        }
    }
}
