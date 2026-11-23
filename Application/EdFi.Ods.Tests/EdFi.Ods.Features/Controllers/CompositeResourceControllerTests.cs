// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Metadata.Composites;
using EdFi.Ods.Common.ProblemDetails;
using EdFi.Ods.Features.Composites.Infrastructure;
using EdFi.Ods.Features.Controllers;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Controllers
{
    [TestFixture]
    public class CompositeResourceControllerTests
    {
        private const string SchoolYearTemplate = "{schoolYearFromRoute:range(2000,2099)}";

        [Test]
        public void Should_accept_the_tenant_route_value_when_multitenancy_is_enabled()
        {
            Get(CreateController(multiTenancy: true), ("tenantIdentifier", "tenant1")).ShouldBeOfType<OkObjectResult>();
        }

        [Test]
        public void Should_accept_the_ods_context_route_values_from_the_route_template()
        {
            Get(CreateController(odsContextRouteTemplate: SchoolYearTemplate), ("schoolYearFromRoute", "2025"))
                .ShouldBeOfType<OkObjectResult>();
        }

        [Test]
        public void Should_not_carry_the_route_keys_of_one_controller_over_to_another()
        {
            // Before the fix, these constructors added their keys to a set shared by every instance
            CreateController(multiTenancy: true);
            CreateController(odsContextRouteTemplate: SchoolYearTemplate);

            var controller = CreateController();

            Get(controller, ("tenantIdentifier", "tenant1")).ShouldBeOfType<NotFoundResult>();
            Get(controller, ("schoolYearFromRoute", "2025")).ShouldBeOfType<NotFoundResult>();
        }

        [Test]
        public void Should_keep_the_route_keys_of_each_controller_when_they_are_created_concurrently()
        {
            var controllers = Enumerable.Range(0, 64)
                .AsParallel()
                .Select(i => (multiTenancy: i % 2 == 0, controller: CreateController(multiTenancy: i % 2 == 0)))
                .ToList();

            foreach (var (multiTenancy, controller) in controllers)
            {
                var result = Get(controller, ("tenantIdentifier", "tenant1"));

                if (multiTenancy)
                {
                    result.ShouldBeOfType<OkObjectResult>();
                }
                else
                {
                    result.ShouldBeOfType<NotFoundResult>();
                }
            }
        }

        private static CompositeResourceController CreateController(
            bool multiTenancy = false,
            string odsContextRouteTemplate = null)
        {
            var featureManager = multiTenancy
                ? new FakeFeatureManager()
                : new FakeFeatureManager(true, ApiFeature.MultiTenancy);

            var metadataProvider = A.Fake<ICompositesMetadataProvider>();
            XElement definition = new XElement("Composite");

            A.CallTo(() => metadataProvider.TryGetCompositeDefinition(A<string>._, A<string>._, A<string>._, out definition))
                .Returns(true)
                .AssignsOutAndRefParameters(definition);

            var responseProvider = A.Fake<ICompositeResourceResponseProvider>();

            A.CallTo(
                    () => responseProvider.Get(
                        A<XElement>._,
                        A<IDictionary<string, CompositeSpecificationParameter>>._,
                        A<IDictionary<string, object>>._,
                        A<NullValueHandling>._))
                .Returns(new object());

            return new CompositeResourceController(
                responseProvider,
                metadataProvider,
                A.Fake<IEdFiProblemDetailsProvider>(),
                A.Fake<ILogContextAccessor>(),
                featureManager,
                new ApiSettings { OdsContextRouteTemplate = odsContextRouteTemplate });
        }

        private static IActionResult Get(CompositeResourceController controller, (string key, string value) extraRouteValue)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.RouteValues["organizationCode"] = "ed-fi";
            httpContext.Request.RouteValues["compositeCategory"] = "enrollment";
            httpContext.Request.RouteValues["compositeName"] = "students";
            httpContext.Request.RouteValues[extraRouteValue.key] = extraRouteValue.value;

            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };

            return controller.Get();
        }
    }
}
