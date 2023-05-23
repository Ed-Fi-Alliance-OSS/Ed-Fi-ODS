// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Conventions;

[TestFixture]
public class RouteRootTemplateProviderTests
{
    private ApiSettings _apiSettings;
    private RouteRootTemplateProvider _routeRootTemplateProvider;

    [SetUp]
    public void SetUp()
    {
        _apiSettings = new ApiSettings();
        _routeRootTemplateProvider = new RouteRootTemplateProvider(_apiSettings);
    }

    [Test]
    public void GetRouteRootTemplate_WithTenantContextAndMultiTenancyEnabled_ReturnsTenantIdentifierRoutePrefix()
    {
        // Arrange
        _apiSettings.Features = new List<Feature>
        {
            new()
            {
                Name = ApiFeature.MultiTenancy.Value,
                IsEnabled = true
            }
        };

        // Act
        var result = _routeRootTemplateProvider.GetRouteRootTemplate(RouteContextType.Tenant);

        // Assert
        result.ShouldBe(RouteConstants.TenantIdentifierRoutePrefix);
    }

    [Test]
    public void GetRouteRootTemplate_WithTenantContextAndMultiTenancyDisabled_ReturnsNull()
    {
        // Arrange
        _apiSettings.Features = new List<Feature>
        {
            new()
            {
                Name = ApiFeature.MultiTenancy.Value,
                IsEnabled = false
            }
        };

        // Act
        var result = _routeRootTemplateProvider.GetRouteRootTemplate(RouteContextType.Tenant);

        // Assert
        result.ShouldBeNull();
    }

    [Test]
    public void GetRouteRootTemplate_WithOdsContextDefinedAndMultiTenancyEnabled_ReturnsTenantIdentifierRoutePrefixWithOdsContextRouteTemplate()
    {
        const string odsContextRouteTemplate = "{ods-context-template}";

        // Arrange
        _apiSettings.Features = new List<Feature>
        {
            new()
            {
                Name = ApiFeature.MultiTenancy.Value,
                IsEnabled = true
            }
        };

        _apiSettings.OdsContextRouteTemplate = odsContextRouteTemplate; 

        // Act
        var result = _routeRootTemplateProvider.GetRouteRootTemplate(RouteContextType.Ods);

        // Assert
        result.ShouldBe($"{RouteConstants.TenantIdentifierRoutePrefix}{{ods-context-template?}}/");
    }

    [Test]
    public void GetRouteRootTemplate_WithOdsContextDefinedAndMultiTenancyDisabled_ReturnsOdsContextRouteTemplate()
    {
        const string odsContextRouteTemplate = "{ods-context-template}";

        // Arrange
        _apiSettings.Features = new List<Feature>
        {
            new()
            {
                Name = ApiFeature.MultiTenancy.Value,
                IsEnabled = false
            }
        };

        _apiSettings.OdsContextRouteTemplate = odsContextRouteTemplate;

        // Act
        var result = _routeRootTemplateProvider.GetRouteRootTemplate(RouteContextType.Ods);

        // Assert
        result.ShouldBe($"{{ods-context-template?}}/");
    }

    [TestCase("")]
    [TestCase(null)]
    public void GetRouteRootTemplate_WithOdsContextUndefinedAndMultiTenancyDisabled_ReturnsNull(string undefinedValue)
    {
        string odsContextRouteTemplate = undefinedValue;

        // Arrange
        _apiSettings.Features = new List<Feature>
        {
            new()
            {
                Name = ApiFeature.MultiTenancy.Value,
                IsEnabled = false
            }
        };

        _apiSettings.OdsContextRouteTemplate = odsContextRouteTemplate;

        // Act
        var result = _routeRootTemplateProvider.GetRouteRootTemplate(RouteContextType.Ods);

        // Assert
        result.ShouldBe(null);
    }

    [Test]
    public void GetRouteRootTemplate_WithUnknownContext_ReturnsNull()
    {
        // Act
        var result = _routeRootTemplateProvider.GetRouteRootTemplate((RouteContextType) 42);

        // Assert
        result.ShouldBeNull();
    }
}
