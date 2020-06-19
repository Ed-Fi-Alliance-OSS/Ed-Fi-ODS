// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Xml.Linq;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.ResourcePipeline;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace EdFi.LoadTools.Test
{
    public class XmlResourcePipelineTests
    {
        [TestFixture]
        public class WhenRunningTheMapElementStep
        {
            private MapElementStep _step;

            [OneTimeSetUp]
            public void SetUp()
            {
                var metadataMappingFactory = new FakeMetadataMappingFactory();
                _step = new MapElementStep(metadataMappingFactory);
            }

            [Test]
            public void Should_map_to_shallow_elements()
            {
                const string data = "value";
                var sourceElement = XElement.Parse($"<A><B>{data}</B></A>");
                var resourceWorkItem = new ApiLoaderWorkItem("source.xml", 1, sourceElement, 1);
                Assert.IsTrue(_step.Process(resourceWorkItem));
                dynamic result = JObject.Parse(resourceWorkItem.Json);
                Assert.AreEqual(data, result.B.Value);
            }

            [Test]
            public void Should_map_to_deep_elements()
            {
                const string data = "value";
                var sourceElement = XElement.Parse($"<A><C>{data}</C></A>");
                var resourceWorkItem = new ApiLoaderWorkItem("source.xml", 1, sourceElement, 1);
                Assert.IsTrue(_step.Process(resourceWorkItem));
                dynamic result = JObject.Parse(resourceWorkItem.Json);
                Assert.AreEqual(data, result.C.D.E.F.Value);
            }

            private class FakeMetadataMappingFactory : IMetadataMappingFactory
            {
                public IEnumerable<MetadataMapping> GetMetadataMappings()
                {
                    yield return new MetadataMapping
                    {
                        RootName = "A",
                        SourceName = "A",
                        TargetName = "A",
                        Properties = new List<PropertyMapping>
                                                                                                      {
                                                                                                          new PropertyMapping
                                                                                                          {
                                                                                                              IsArray = false, MappingStrategy =
                                                                                                                  new
                                                                                                                      CopySimplePropertyMappingStrategy(),
                                                                                                              SourceName = "B", TargetName = "B",
                                                                                                              SourceType = "string",
                                                                                                              TargetType = "string"
                                                                                                          },
                                                                                                          new PropertyMapping
                                                                                                          {
                                                                                                              IsArray = false, MappingStrategy =
                                                                                                                  new
                                                                                                                      CopySimplePropertyMappingStrategy(),
                                                                                                              SourceName = "C",
                                                                                                              TargetName = @"C/D/E/F",
                                                                                                              SourceType = "string",
                                                                                                              TargetType = "string"
                                                                                                          }
                                                                                                      }
                    };
                }
            }
        }
    }
}
