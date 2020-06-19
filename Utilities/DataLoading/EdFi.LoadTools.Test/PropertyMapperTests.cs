// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine.Mapping;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class DoNotMapPropertyMapperTests
    {
        private List<ModelMetadata> _jsonModels;
        private List<ModelMetadata> _xmlModels;

        [SetUp]
        public void SetUp()
        {
            _jsonModels = new List<ModelMetadata>
                          {
                              new JsonModelMetadata
                              {
                                  Model = "jsonType", PropertyPath = "json/property/path"
                              },
                              new JsonModelMetadata
                              {
                                  Model = "jsonType", PropertyPath = "another"
                              }
                          };

            _xmlModels = new List<ModelMetadata>
                         {
                             new XmlModelMetadata
                             {
                                 Model = "XmlType", PropertyPath = "Xml/Property/Path"
                             },
                             new XmlModelMetadata
                             {
                                 Model = "XmlType", PropertyPath = "Another"
                             }
                         };
        }

        [Test]
        public void Should_remove_all_properties()
        {
            var mapper = new TestDoNotMapPropertyMapper();
            Assert.IsTrue(_jsonModels.Count == 2);
            Assert.IsTrue(_xmlModels.Count == 2);

            mapper.CreateMetadataMappings(null, _xmlModels, _jsonModels);

            Assert.IsTrue(_jsonModels.Count == 0);
            Assert.IsTrue(_xmlModels.Count == 1);
        }

        private class TestDoNotMapPropertyMapper : DoNotMapPropertyMapper
        {
            protected override UnmappedProperty[] JsonProperties => new[]
                                                                    {
                                                                        new UnmappedProperty("jsonType", "json/property/path", "another")
                                                                    };

            protected override UnmappedProperty[] XmlProperties => new[]
                                                                   {
                                                                       new UnmappedProperty("XmlType", "Xml/Property/Path", "NotAMatch")
                                                                   };
        }
    }
}
