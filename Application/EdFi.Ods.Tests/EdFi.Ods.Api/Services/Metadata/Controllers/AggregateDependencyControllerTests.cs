// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Xml;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Models.GraphML;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.AggregateDependencies;
using EdFi.Ods.Features.OpenApiMetadata.Controllers;
using Newtonsoft.Json;
using NUnit.Framework;
using QuickGraph;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Controllers
{
    [TestFixture]
    public class AggregateDependencyControllerTests
    {
        public class When_getting_the_dependencies_for_loading_data : LegacyTestFixtureBase
        {
            private IResourceLoadGraphFactory _resourceLoadGraphFactory;
            private AggregateDependencyController _controller;
            private HttpResponseMessage _actualResult;

            protected override void Arrange()
            {
                _resourceLoadGraphFactory = MockRepository.GenerateMock<IResourceLoadGraphFactory>();

                var graph = new BidirectionalGraph<Resource, AssociationViewEdge>();
                graph.AddVertex(new Resource("Test"));

                _resourceLoadGraphFactory.Stub(x => x.CreateResourceLoadGraph())
                    .Return(graph);

                _controller = CreateController(_resourceLoadGraphFactory);
            }

            protected override void Act()
            {
                _actualResult = _controller.Get().ExecuteAsync(CancellationToken.None).GetResultSafely();
            }

            [Test]
            public void Should_get_the_resource_model_for_building_the_output()
            {
                _resourceLoadGraphFactory.AssertWasCalled(x => x.CreateResourceLoadGraph());
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

        public class When_getting_the_dependency_graph : LegacyTestFixtureBase
        {
            private IResourceLoadGraphFactory _resourceLoadGraphFactory;
            private AggregateDependencyController _controller;
            private HttpResponseMessage _actualResult;
            private string _actualResultContent;

            protected override void Arrange()
            {
                _resourceLoadGraphFactory = MockRepository.GenerateMock<IResourceLoadGraphFactory>();

                var graph = new BidirectionalGraph<Resource, AssociationViewEdge>();
                graph.AddVertex(new Resource("Test"));

                _resourceLoadGraphFactory.Stub(x => x.CreateResourceLoadGraph())
                    .Return(graph);

                _controller = CreateController(_resourceLoadGraphFactory, true);
            }

            protected override void Act()
            {
                _actualResult = _controller.Get().ExecuteAsync(CancellationToken.None).GetResultSafely();
                _actualResultContent = _actualResult.Content.ReadAsStringAsync().GetResultSafely();
            }

            [Test]
            public void Should_call_the_resource_model_provider_to_get_the_model_for_building_the_output()
            {
                _resourceLoadGraphFactory.AssertWasCalled(x => x.CreateResourceLoadGraph());
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
            var config = new HttpConfiguration();

            config.Formatters.Add(new GraphMLMediaTypeFormatter());

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/metadata/data/v3/dependencies");

            if (isGraphRequest)
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(CustomMediaContentTypes.GraphML));
            }

            var route = config.Routes.MapHttpRoute(RouteConstants.Dependencies, "metadata/data/v3/dependencies");

            var controller = new AggregateDependencyController(graphFactory);

            var routeData = new HttpRouteData(
                route,
                new HttpRouteValueDictionary {{"controller", "aggregatedependency"}});

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Url = new UrlHelper(request);
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.RequestContext.VirtualPathRoot = "/";

            return controller;
        }
    }
}
