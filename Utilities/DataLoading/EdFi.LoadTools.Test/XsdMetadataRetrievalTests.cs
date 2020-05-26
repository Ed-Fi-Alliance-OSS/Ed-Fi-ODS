// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace EdFi.LoadTools.Test
{
    public class XsdMetadataRetrievalTests
    {
        [TestClass]
        public class When_using_the_XsdMetadataFactory
        {
            protected IEnumerable<XmlModelMetadata> _metadata;

            protected SchemaSetFactory ssBuilder =
                new SchemaSetFactory(new XsdStreamsRetriever(JsonMetadataTests.XmlMetadataConfiguration));

            protected virtual XsdMetadataFactory Factory => new XsdMetadataFactory(ssBuilder.GetSchemaSet());

            [TestInitialize]
            public virtual void Initialize()
            {
                _metadata = Factory.GetMetadata();
            }

            [TestMethod]
            [TestCategory("Run Manually")]
            public void Should_display_all_Xml_metadata()
            {
                Assert.IsTrue(_metadata.Any());
                Console.WriteLine(@"Model,Property,Type,IsArray,IsRequired,IsSimpleType");

                foreach (var metadata in _metadata.OrderBy(x => x.Model))
                {
                    Console.WriteLine(
                        $"{metadata.Model},{metadata.Property},{metadata.Type},{metadata.IsArray},{metadata.IsRequired},{metadata.IsSimpleType}");
                }
            }
        }

        [TestClass]
        public class When_using_the_XsdApiTypesMetadataFactory : When_using_the_XsdMetadataFactory
        {
            protected override XsdMetadataFactory Factory => new XsdApiTypesMetadataFactory(ssBuilder.GetSchemaSet());
        }
    }
}
