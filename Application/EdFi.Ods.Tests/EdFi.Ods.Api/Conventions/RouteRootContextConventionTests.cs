// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Reflection;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Conventions;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Conventions;

[TestFixture]
public class RouteRootContextConventionTests
{
    [Test]
    public void Apply_WhenControllerHasRouteRootContextAttribute_ShouldSetAttributeRouteModelWithCorrectTemplate()
    {
        // Arrange
        var controller = new ControllerModel(
            typeof(TestController).GetTypeInfo(),
            new List<object>() { new ApplyOdsRouteRootTemplateAttribute() });

        var application = new ApplicationModel();
        application.Controllers.Add(controller);

        var routeRootTemplateProvider = A.Fake<IOdsRouteRootTemplateProvider>();
        A.CallTo(() => routeRootTemplateProvider.GetOdsRouteRootTemplate()).Returns("ods/");

        var selectorModel = new SelectorModel();
        selectorModel.AttributeRouteModel = new AttributeRouteModel { Template = "template" };
        controller.Selectors.Add(selectorModel);

        var convention = new OdsRouteRootTemplateConvention(routeRootTemplateProvider);

        // Act
        convention.Apply(application);

        // Assert
        selectorModel.AttributeRouteModel.Template.ShouldBe("ods/template");
    }

    [Test]
    public void Apply_WhenControllerHasNoRouteRootContextAttribute_ShouldNotSetAttributeRouteModel()
    {
        // Arrange
        var controller = new ControllerModel(
            typeof(TestController).GetTypeInfo(),
            new List<object>()); // No ApplyOdsRootRouteTemplateAttribute defined

        var application = new ApplicationModel();
        application.Controllers.Add(controller);

        var routeRootTemplateProvider = A.Fake<IOdsRouteRootTemplateProvider>();

        var selectorModel = new SelectorModel();
        selectorModel.AttributeRouteModel = new AttributeRouteModel();
        selectorModel.AttributeRouteModel.Template = "template";

        controller.Selectors.Add(selectorModel);

        var convention = new OdsRouteRootTemplateConvention(routeRootTemplateProvider);

        // Act
        convention.Apply(application);

        // Assert
        selectorModel.AttributeRouteModel.Template.ShouldBe("template");
        A.CallTo(() => routeRootTemplateProvider.GetOdsRouteRootTemplate()).MustNotHaveHappened();
    }

    public class TestController : ControllerBase { }
}
