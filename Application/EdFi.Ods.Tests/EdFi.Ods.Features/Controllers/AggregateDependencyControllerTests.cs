// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models.GraphML;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.Controllers;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using QuickGraph;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Controllers
{
    [TestFixture]
    public class AggregateDependencyControllerTests
    {
        public class When_getting_the_dependencies_for_loading_data : TestFixtureBase
        {
            private IResourceLoadGraphFactory _resourceLoadGraphFactory;
            private AggregateDependencyController _controller;
            private HttpResponseMessage _actualResult;

            protected override void Arrange()
            {
                _resourceLoadGraphFactory = Stub<IResourceLoadGraphFactory>();

                var graph = new BidirectionalGraph<Resource, AssociationViewEdge>();
                graph.AddVertex(new Resource("Test"));

                A.CallTo(()=> _resourceLoadGraphFactory.CreateResourceLoadGraph())
                    .Returns(graph);

                _controller = CreateController(_resourceLoadGraphFactory);
            }

            protected override void Act()
            {
                var actioncontext = new ActionContext();

                var t = _controller.Get();


            }

            [Test]
            public void Should_get_the_resource_model_for_building_the_output()
            {
                A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph())
                    .MustHaveHappened();
            }

            [Test]
            public void Should_have_content_type_of_AggregateLoadOrder()
            {
                var actualContent =
                    JsonConvert.DeserializeObject<List<ResourceLoadOrder>>(_actualResult.Content.ReadAsStringAsync().Result);

                Assert.That(actualContent, Is.Not.Null);
            }

            [Test]
            public void Should_return_an_ok_status()
            {
                Assert.That(_actualResult.IsSuccessStatusCode, Is.True);
            }
        }

        public class When_getting_the_dependency_graph : TestFixtureBase
        {
            private IResourceLoadGraphFactory _resourceLoadGraphFactory;
            private AggregateDependencyController _controller;
            private HttpResponseMessage _actualResult;
            private string _actualResultContent;

            protected override void Arrange()
            {
                _resourceLoadGraphFactory = Stub<IResourceLoadGraphFactory>();

                var graph = new BidirectionalGraph<Resource, AssociationViewEdge>();
                graph.AddVertex(new Resource("Test"));
                A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph())
                    .Returns(graph);

                _controller = CreateController(_resourceLoadGraphFactory, true);
            }

            protected override void Act()
            {
                var result = _controller.Get();
                _actualResultContent = _actualResult.Content.ReadAsStringAsync().GetResultSafely();
            }

            [Test]
            public void Should_call_the_resource_model_provider_to_get_the_model_for_building_the_output()
            {
                A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).MustHaveHappened();
            }

            [Test]
            public void Should_have_result_content_of_xml()
            {
                var doc = new XmlDocument();
                doc.LoadXml(_actualResultContent);

                Assert.That(doc.ChildNodes.Count, Is.GreaterThan(1));
            }

            [Test]
            public void Should_return_an_ok_status()
            {
                Assert.That(_actualResult.IsSuccessStatusCode, Is.True);
            }
        }

        private static AggregateDependencyController CreateController(IResourceLoadGraphFactory graphFactory,
            bool isGraphRequest = false)
        {

            var apiSettings = new ApiSettings { Mode = ApiMode.SharedInstance.Value };
            Feature item = new Feature();
            item.IsEnabled = true;
            item.Name = "aggregatedependency";
            apiSettings.Features.Add(item);

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/metadata/data/v3/dependencies");

            if (isGraphRequest)
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(CustomMediaContentTypes.GraphML));
            }

            // var route = apiSettings.rou.MapHttpRoute(RouteConstants.Dependencies, "metadata/data/v3/dependencies");

            var controller = new AggregateDependencyController(apiSettings, graphFactory);

            //var routeData = new HttpRouteData(
            //    route,
            //    new HttpRouteValueDictionary { { "controller", "aggregatedependency" } });

            //controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            //controller.Request = request;
            //controller.Url = new UrlHelper(request);
            //controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            //controller.RequestContext.VirtualPathRoot = "/";

            return controller;
        }
    }
}
#endif