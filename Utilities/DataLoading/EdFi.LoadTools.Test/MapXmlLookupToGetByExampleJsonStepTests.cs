// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using EdFi.LoadTools.Test.MappingFactories;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class MapXmlLookupToGetByExampleJsonStepTests
    {
        private MapXmlLookupToGetByExampleJsonStep _mapStep;

        [SetUp]
        public void Setup()
        {
            var mappings = new[]
                           {
                               new MetadataMapping
                               {
                                   RootName = "Simple", SourceName = "Abc", TargetName = "alphabet", Properties = new List<PropertyMapping>
                                                                                                                  {
                                                                                                                      new PropertyMapping
                                                                                                                      {
                                                                                                                          IsArray = false,
                                                                                                                          SourceName = "A",
                                                                                                                          SourceType = "String",
                                                                                                                          TargetName = "a",
                                                                                                                          TargetType = "string",
                                                                                                                          MappingStrategy =
                                                                                                                              new
                                                                                                                                  CopySimplePropertyMappingStrategy()
                                                                                                                      },
                                                                                                                      new PropertyMapping
                                                                                                                      {
                                                                                                                          IsArray = false,
                                                                                                                          SourceName = "B",
                                                                                                                          SourceType = "String",
                                                                                                                          TargetName = "b",
                                                                                                                          TargetType = "string",
                                                                                                                          MappingStrategy =
                                                                                                                              new
                                                                                                                                  CopySimplePropertyMappingStrategy()
                                                                                                                      },
                                                                                                                      new PropertyMapping
                                                                                                                      {
                                                                                                                          IsArray = false,
                                                                                                                          SourceName = "C",
                                                                                                                          SourceType = "String",
                                                                                                                          TargetName = "c",
                                                                                                                          TargetType = "string",
                                                                                                                          MappingStrategy =
                                                                                                                              new
                                                                                                                                  CopySimplePropertyMappingStrategy()
                                                                                                                      }
                                                                                                                  }
                               },
                               new MetadataMapping
                               {
                                   RootName = "Descriptor", SourceName = "Foo", TargetName = "foo", Properties = new List<PropertyMapping>
                                                                                                                 {
                                                                                                                     new PropertyMapping
                                                                                                                     {
                                                                                                                         IsArray = false,
                                                                                                                         SourceName = "FooDescriptor",
                                                                                                                         SourceType =
                                                                                                                             "FooDescriptorReferenceType",
                                                                                                                         TargetName = "fooDescriptor",
                                                                                                                         TargetType = "string",
                                                                                                                         MappingStrategy =
                                                                                                                             new
                                                                                                                                 DescriptorReferenceTypeToStringMappingStrategy()
                                                                                                                     },
                                                                                                                     new PropertyMapping
                                                                                                                     {
                                                                                                                         IsArray = false, SourceName =
                                                                                                                             "FooDescriptor/Namespace",
                                                                                                                         SourceType = "String",
                                                                                                                         TargetName = "{none}",
                                                                                                                         TargetType = "{none}",
                                                                                                                         MappingStrategy =
                                                                                                                             new
                                                                                                                                 NoOperationMappingStrategy()
                                                                                                                     },
                                                                                                                     new PropertyMapping
                                                                                                                     {
                                                                                                                         IsArray = false, SourceName =
                                                                                                                             "FooDescriptor/CodeValue",
                                                                                                                         SourceType = "String",
                                                                                                                         TargetName = "{none}",
                                                                                                                         TargetType = "{none}",
                                                                                                                         MappingStrategy =
                                                                                                                             new
                                                                                                                                 NoOperationMappingStrategy()
                                                                                                                     }
                                                                                                                 }
                               },
                               new MetadataMapping
                               {
                                   RootName = "Array", SourceName = "MyArray", TargetName = "myArray", Properties = new List<PropertyMapping>
                                                                                                                    {
                                                                                                                        new PropertyMapping
                                                                                                                        {
                                                                                                                            IsArray = true,
                                                                                                                            SourceName = "A",
                                                                                                                            SourceType = "String",
                                                                                                                            TargetName = "a",
                                                                                                                            TargetType = "string",
                                                                                                                            MappingStrategy =
                                                                                                                                new
                                                                                                                                    ArrayToArrayMappingStrategy()
                                                                                                                        },
                                                                                                                        new PropertyMapping
                                                                                                                        {
                                                                                                                            IsArray = true,
                                                                                                                            SourceName = "A/B",
                                                                                                                            SourceType = "String",
                                                                                                                            TargetName = "a/b",
                                                                                                                            TargetType = "string",
                                                                                                                            MappingStrategy =
                                                                                                                                new
                                                                                                                                    CopySimplePropertyMappingStrategy()
                                                                                                                        }
                                                                                                                    }
                               }
                           };

            var mappingFactory = new MockMetadataMappingFactory(mappings);

            _mapStep = new MapXmlLookupToGetByExampleJsonStep(mappingFactory);
        }

        [Test]
        public void Should_perform_simple_element_name_translations()
        {
            var xelement = new XElement(
                "Abc", new XElement("A", "hello"), new XElement("B", "world"),
                new XElement("C", "!!!"));

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "Simple"
                       };

            Console.WriteLine(item.LookupXElement);
            var success = _mapStep.Process(item).Result;
            Assert.IsTrue(success);
            Console.WriteLine(item.GetByExampleXElement);

            var expected = new XElement(
                "alphabet", new XElement("a", "hello"), new XElement("b", "world"),
                new XElement("c", "!!!"));

            Assert.AreEqual(expected.ToString(), item.GetByExampleXElement.ToString());
        }

        [Test]
        public void Should_perform_reference_type_translations()
        {
            var xelement = new XElement("Foo", new XElement("FooDescriptor", "NameSpace#descriptor"));

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "Descriptor"
                       };

            Console.WriteLine(item.LookupXElement);
            var success = _mapStep.Process(item).Result;
            Assert.IsTrue(success);
            Console.WriteLine(item.GetByExampleXElement);
            var expected = new XElement("foo", new XElement("fooDescriptor", "NameSpace#descriptor"));
            Assert.AreEqual(expected.ToString(), item.GetByExampleXElement.ToString());
        }

        [Test]
        public void Should_perform_array_translations()
        {
            XNamespace json = "http://james.newtonking.com/projects/json";

            var xelement = new XElement(
                "MyArray",
                new XElement("A", new XElement("B", "1"), new XElement("B", "2"), new XElement("B", "3")));

            var item = new XmlLookupWorkItem(xelement)
                       {
                           ResourceName = "Array"
                       };

            Console.WriteLine(item.LookupXElement);
            var success = _mapStep.Process(item).Result;
            Assert.IsTrue(success);
            Console.WriteLine(item.GetByExampleXElement);

            var expected = new XElement(
                "myArray",
                new XElement(
                    "a", new XAttribute(json + "Array", true), new XElement("b", "1"), new XElement("b", "2"),
                    new XElement("b", "3")));

            Assert.AreEqual(expected.ToString(), item.GetByExampleXElement.ToString());
        }
    }
}
