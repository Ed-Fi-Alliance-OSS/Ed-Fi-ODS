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
    public class ResourceToResourceMetadataMappingFactoryTests
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

            var ssbuilder = new SchemaSetFactory(new XsdStreamsRetriever(JsonMetadataTests.XmlMetadataConfiguration));
            var xfactory = new XsdApiTypesMetadataFactory(ssbuilder.GetSchemaSet());
            _xmlMetadata = xfactory.GetMetadata().ToList();

            var jfactory = new JsonMetadataFactory(metadataRetriever);
            _jsonMetadata = jfactory.GetMetadata().ToList();

            var strategies = new List<IMetadataMapper>
                             {
                                 new ArrayMetadataMapper(), new DescriptorReferenceMetadataMapper(), new NameMatchingMetadataMapper()
                             };

            var factory = new ResourceToResourceMetadataMappingFactory(_xmlMetadata, _jsonMetadata, strategies);

            _mappings = factory.GetMetadataMappings().ToArray();
        }

        [Test]
        [Category("RunManually")]
        public void Should_map_resource_to_resource()
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

                foreach (var p in m.Properties.OrderBy(x => x.SourceName))
                {
                    Console.WriteLine(
                        p.IsArray
                            ? $"\t{p.SourceName} ({p.SourceType}[]), {p.TargetName} ({p.TargetType}[])\t{p.MappingStrategy.GetType().Name}"
                            : $"\t{p.SourceName} ({p.SourceType}), {p.TargetName} ({p.TargetType})\t{p.MappingStrategy.GetType().Name}");
                }

                if (unmappedJsonProperties.Any())
                {
                    Console.WriteLine("\tUnmapped Json Properties:");

                    foreach (var unmappedProperty in unmappedJsonProperties.Select(up => up.PropertyPath).Distinct())
                    {
                        Console.WriteLine($"\t\t{unmappedProperty}");
                    }
                }

                if (unmappedXmlProperties.Any())
                {
                    Console.WriteLine("\tUnmapped Xml Properties:");

                    foreach (var unmappedProperty in unmappedXmlProperties.Select(up => up.PropertyPath).Distinct())
                    {
                        Console.WriteLine($"\t\t{unmappedProperty}");
                    }
                }

                Console.WriteLine();
            }
        }
    }

    /// <summary>
    ///     Regression tests for DMS-1215: a scalar source property must not be fuzzy-mapped onto a JSON
    ///     property nested under an array unless the source is in a compatible array context. Scalar mapping
    ///     strategies emit XML elements without the json:Array marker, so such a mapping serializes as a JSON
    ///     object where the API expects an array, and the POST is rejected.
    /// </summary>
    [TestFixture]
    public class ResourceToResourceArrayContextMappingTests
    {
        private static MetadataMapping GetSingleMapping(
            List<XmlModelMetadata> xmlMetadata,
            List<JsonModelMetadata> jsonMetadata)
        {
            var strategies = new List<IMetadataMapper>
                             {
                                 new ArrayMetadataMapper(), new DescriptorReferenceMetadataMapper(), new NameMatchingMetadataMapper()
                             };

            var factory = new ResourceToResourceMetadataMappingFactory(xmlMetadata, jsonMetadata, strategies);

            return factory.GetMetadataMappings().Single();
        }

        [Test]
        public void Should_not_map_student_program_reason_exited_to_sample_related_general_student_program_associations()
        {
            // DS 5.2 interchange metadata: ReasonExited is a scalar descriptor reference
            var xmlMetadata = new List<XmlModelMetadata>
                              {
                                  new XmlModelMetadata
                                  {
                                      Model = "StudentProgramAssociation", Property = "BeginDate", Type = "Date"
                                  },
                                  new XmlModelMetadata
                                  {
                                      Model = "StudentProgramAssociation", Property = "ReasonExited", Type = "String",
                                      TypeName = "ReasonExitedDescriptorReferenceType"
                                  }
                              };

            // Sample-extended OpenAPI metadata: the Sample extension contributes the
            // relatedGeneralStudentProgramAssociations collection to the program association resource
            var jsonMetadata = new List<JsonModelMetadata>
                               {
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_studentProgramAssociation", Property = "beginDate", Type = "string", Format = "date"
                                   },
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_studentProgramAssociation", Property = "relatedGeneralStudentProgramAssociations",
                                       Type = "sample_studentProgramAssociationRelatedGeneralStudentProgramAssociation", IsArray = true
                                   },
                                   new JsonModelMetadata
                                   {
                                       Model = "sample_studentProgramAssociationRelatedGeneralStudentProgramAssociation",
                                       Property = "relatedGeneralStudentProgramAssociationReference",
                                       Type = "edFi_generalStudentProgramAssociationReference"
                                   },
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_generalStudentProgramAssociationReference", Property = "programTypeDescriptor",
                                       Type = "string"
                                   }
                               };

            var mapping = GetSingleMapping(xmlMetadata, jsonMetadata);

            var mappingsIntoSampleArray = mapping.Properties
                                                 .Where(
                                                      p => p.TargetName.StartsWith(
                                                          "relatedGeneralStudentProgramAssociations/", StringComparison.Ordinal))
                                                 .Select(p => $"{p.SourceName} -> {p.TargetName} ({p.MappingStrategy.GetType().Name})")
                                                 .ToList();

            Assert.That(
                mappingsIntoSampleArray, Is.Empty,
                "Scalar source properties must not be mapped to properties nested under the Sample extension array");
        }

        [Test]
        public void Should_not_map_scalar_property_to_property_nested_under_array()
        {
            var xmlMetadata = new List<XmlModelMetadata>
                              {
                                  new XmlModelMetadata
                                  {
                                      Model = "Course", Property = "GradeLevel", Type = "String"
                                  }
                              };

            var jsonMetadata = new List<JsonModelMetadata>
                               {
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_course", Property = "gradeLevels", Type = "edFi_courseGradeLevel", IsArray = true
                                   },
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_courseGradeLevel", Property = "gradeLevelDescriptor", Type = "string"
                                   }
                               };

            var mapping = GetSingleMapping(xmlMetadata, jsonMetadata);

            var mappingsIntoArray = mapping.Properties
                                           .Where(p => p.TargetName.StartsWith("gradeLevels/", StringComparison.Ordinal))
                                           .Select(p => $"{p.SourceName} -> {p.TargetName} ({p.MappingStrategy.GetType().Name})")
                                           .ToList();

            Assert.That(
                mappingsIntoArray, Is.Empty,
                "A scalar source property must not be mapped to a property nested under a target array");
        }

        [Test]
        public void Should_map_array_descriptor_reference_to_descriptor_nested_under_array()
        {
            var xmlMetadata = new List<XmlModelMetadata>
                              {
                                  new XmlModelMetadata
                                  {
                                      Model = "Staff", Property = "Race", Type = "String",
                                      TypeName = "RaceDescriptorReferenceType", IsArray = true
                                  }
                              };

            var jsonMetadata = new List<JsonModelMetadata>
                               {
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_staff", Property = "races", Type = "edFi_staffRace", IsArray = true
                                   },
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_staffRace", Property = "raceDescriptor", Type = "string"
                                   }
                               };

            var mapping = GetSingleMapping(xmlMetadata, jsonMetadata);

            Assert.That(
                mapping.Properties.Any(
                    p => p.SourceName == "Race"
                         && p.TargetName == "races/raceDescriptor"
                         && p.MappingStrategy is DescriptorReferenceTypeToStringMappingStrategy),
                Is.True,
                "An array descriptor reference must still map to the descriptor property nested under the matching target array");
        }

        [Test]
        public void Should_map_scalar_property_nested_under_array_to_property_nested_under_array()
        {
            var xmlMetadata = new List<XmlModelMetadata>
                              {
                                  new XmlModelMetadata
                                  {
                                      Model = "Staff", Property = "ElectronicMail", Type = "ElectronicMailType", IsArray = true
                                  },
                                  new XmlModelMetadata
                                  {
                                      Model = "ElectronicMailType", Property = "ElectronicMailAddress", Type = "String"
                                  }
                              };

            var jsonMetadata = new List<JsonModelMetadata>
                               {
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_staff", Property = "electronicMails", Type = "edFi_staffElectronicMail", IsArray = true
                                   },
                                   new JsonModelMetadata
                                   {
                                       Model = "edFi_staffElectronicMail", Property = "electronicMailAddress", Type = "string"
                                   }
                               };

            var mapping = GetSingleMapping(xmlMetadata, jsonMetadata);

            Assert.That(
                mapping.Properties.Any(
                    p => p.SourceName == "ElectronicMail/ElectronicMailAddress"
                         && p.TargetName == "electronicMails/electronicMailAddress"
                         && p.MappingStrategy is CopySimplePropertyMappingStrategy),
                Is.True,
                "A scalar source property nested under an array must still map to the property nested under the matching target array");
        }
    }
}
