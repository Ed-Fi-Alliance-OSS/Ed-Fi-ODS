// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.Factories;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.LoadTools.Engine.MappingFactories;
using NUnit.Framework;

// ReSharper disable LocalizableElement

namespace EdFi.LoadTools.Test.MappingFactories
{
    [TestFixture]
    public class LookupToGetByExampleMetadataMappingFactoryTests
    {
        private List<JsonModelMetadata> _jsonMetadata;
        private MetadataMapping[] _mappings;
        private List<XmlModelMetadata> _xmlMetadata;

        [OneTimeSetUp]
        public void SetUp()
        {
            var retriever = new SwaggerRetriever(JsonMetadataTests.ApiMetadataConfiguration);

            var metadataRetriever = new SwaggerMetadataRetriever(
                JsonMetadataTests.ApiMetadataConfiguration, retriever,
                new List<string>());

            var jfactory = new JsonMetadataFactory(metadataRetriever);
            _jsonMetadata = jfactory.GetMetadata().ToList();

            var ssbuilder = new SchemaSetFactory(new XsdStreamsRetriever(JsonMetadataTests.XmlMetadataConfiguration));
            var xfactory = new XsdMetadataFactory(ssbuilder.GetSchemaSet());
            _xmlMetadata = xfactory.GetMetadata().ToList();

            var strategies = new List<IMetadataMapper>
                             {
                                 //new DiminishingMetadataMapper(),
                                 new PremappedLookupMetadataMapper(), new LookupDoNotMapPropertyMapper(),

                                 //new ArrayMetadataMapper(),
                                 new DescriptorReferenceMetadataMapper(), new NameMatchingMetadataMapper()

                                 //new SchoolIdBugFixMetadataMapper()
                             };

            var factory = new LookupToGetByExampleMetadataMappingFactory(_xmlMetadata, _jsonMetadata, strategies);

            _mappings = factory.GetMetadataMappings().ToArray();
        }

        [Test]
        [Category("RunManually")]
        public void Should_map_lookup_to_getByExample()
        {
            foreach (var m in _mappings.OrderBy(x => x.SourceName))
            {
                var xmlModels = new List<ModelMetadata>();
                MetadataMappingFactoryBase.PopulateModelMetadata(_xmlMetadata, xmlModels, m.SourceName);

                var unmappedXmlProperties = xmlModels
                                           .Where(xm => xm.IsSimpleType && m.Properties.All(p => p.SourceName != xm.PropertyPath)).ToList();

                var jsonModels = new List<ModelMetadata>();
                MetadataMappingFactoryBase.PopulateModelMetadata(_jsonMetadata, jsonModels, m.TargetName);

                var unmappedJsonProperties = jsonModels
                                            .Where(jm => jm.IsSimpleType && m.Properties.All(p => p.TargetName != jm.PropertyPath)).ToList();

                // Uncomment to only see resources with missing mappings
                //if (!unmappedXmlProperties.Any() && !unmappedJsonProperties.Any())
                //    continue;

                Console.WriteLine($"{m.SourceName}, {m.TargetName}");

                //Console.WriteLine(JsonConvert.SerializeObject(m));

                foreach (var p in m.Properties.OrderBy(x => x.SourceName))
                {
                    Console.WriteLine(
                        p.IsArray
                            ? $"\t{p.SourceName} ({p.SourceType}[]), {p.TargetName} ({p.TargetType}[])\t{p.MappingStrategy.GetType().Name}"
                            : $"\t{p.SourceName} ({p.SourceType}), {p.TargetName} ({p.TargetType})\t{p.MappingStrategy.GetType().Name}");
                }

                if (unmappedXmlProperties.Any())
                {
                    Console.WriteLine("\tUnmapped Xml Properties:");

                    foreach (var unmappedProperty in unmappedXmlProperties /*.Select(up => up.PropertyPath).Distinct()*/
                    )
                    {
                        Console.WriteLine(
                            $"\t\t{unmappedProperty.PropertyPath} ({unmappedProperty.Type}, {unmappedProperty.IsRequired})");
                    }
                }

                if (unmappedJsonProperties.Any())
                {
                    Console.WriteLine("\tUnmapped Json Properties:");

                    foreach (var unmappedProperty in
                        unmappedJsonProperties /*.Select(up => up.PropertyPath).Distinct()*/)
                    {
                        Console.WriteLine(
                            $"\t\t{unmappedProperty.PropertyPath} ({unmappedProperty.Type}, {unmappedProperty.IsRequired})");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
