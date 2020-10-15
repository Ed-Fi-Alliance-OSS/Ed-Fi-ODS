// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
using Antlr.Runtime.Misc;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Models.GraphML;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.Controllers;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
            private IActionResult _actionResult;
            private OkObjectResult objectResult;

            protected override void Arrange()
            {
                _resourceLoadGraphFactory = Stub<IResourceLoadGraphFactory>();

                var graph = new BidirectionalGraph<Resource, AssociationViewEdge>();
                graph.AddVertex(new Resource("Test"));

                A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph())
                    .Returns(graph);

                _controller = CreateController(_resourceLoadGraphFactory);
            }

            protected override void Act()
            {
                _actionResult = _controller.Get();
                objectResult = (OkObjectResult)_actionResult;
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
                var oo = objectResult.Value;
                Assert.That(objectResult.Value, Is.Not.Null);
                //Not executing method in aggregatecontroller even the value is false
                //Assert.IsTrue(false);
            }

            [Test]
            public void Should_return_an_ok_status()
            {
                Assert.AreEqual(objectResult.StatusCode, 200);
            }
        }

        public class When_getting_the_dependency_graph : TestFixtureBase
        {
            private IResourceLoadGraphFactory _resourceLoadGraphFactory;
            private AggregateDependencyController _controller;
            private IActionResult _actionResult;
            private OkObjectResult objectResult;

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
                _actionResult = _controller.Get();

                objectResult = (OkObjectResult)_actionResult;
            }

            [Test]
            public void Should_call_the_resource_model_provider_to_get_the_model_for_building_the_output()
            {
                A.CallTo(() => _resourceLoadGraphFactory.CreateResourceLoadGraph()).MustHaveHappened();
            }

            [Test]
            public void Should_have_result_content_of_xml()
            {
                var resultvalue = (GraphML)objectResult.Value;
                string stringcontent = Serialize(resultvalue.Nodes);
                var doc = new XmlDocument();
                doc.LoadXml(stringcontent);

                Assert.That(doc.ChildNodes.Count, Is.GreaterThan(1));
            }

            [Test]
            public void Should_return_an_ok_status()
            {
                Assert.AreEqual(objectResult.StatusCode, 200);
            }
            public static string Serialize(object dataToSerialize)
            {
                if (dataToSerialize == null) return null;

                using (StringWriter stringwriter = new System.IO.StringWriter())
                {
                    var serializer = new XmlSerializer(dataToSerialize.GetType());
                    serializer.Serialize(stringwriter, dataToSerialize);
                    return stringwriter.ToString();
                }
            }

        }

        private static AggregateDependencyController CreateController(IResourceLoadGraphFactory graphFactory,
            bool isGraphRequest = false)
        {
            var apiSettings = new ApiSettings { Mode = ApiMode.SharedInstance.Value };
            Feature item = new Feature();
            item.IsEnabled = true;
            item.Name = "aggregateDependencies";
            apiSettings.Features.Add(item);

            var controller = new AggregateDependencyController(apiSettings, graphFactory);
            var request = A.Fake<HttpRequest>();
            var headerDictionary = A.Fake<IHeaderDictionary>();
            HeaderDictionary dict = new HeaderDictionary();

            if (isGraphRequest)
            {
                dict.Add("Accept", CustomMediaContentTypes.GraphML);
            }

            A.CallTo(() => request.Headers).Returns(dict);

            var httpContext = A.Fake<HttpContext>();
            A.CallTo(() => httpContext.Request).Returns(request);

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            controller.ControllerContext = controllerContext;

            return controller;
        }
    }
}
