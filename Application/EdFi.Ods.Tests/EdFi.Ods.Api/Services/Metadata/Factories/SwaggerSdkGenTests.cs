// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;
using EdFiSchema = EdFi.Ods.Common.Models.Domain.Schema;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Factories
{
    [TestFixture]
    public class SwaggerSdkGenTests
    {
        public class When_Generating_Extension_Only_As_Root_Aggregate_Document : TestFixtureBase
        {
            private SwaggerDocumentFactory _extensionOnlySwaggerDocumentFactory;
            private SdkGenExtensionResourceStrategy _resourceStrategy;
            private string _actualMetadataText;
            private readonly string requestedExtensionPhysicalName = "gb";
            private OpenApiMetadataDocument _actualMetadataObject;

            protected override void Arrange()
            {
                var schemaDefinition = DomainModelDefinitionsProviderHelper
                                      .DefinitionProviders
                                      .Select(
                                           x => x.GetDomainModelDefinitions()
                                                 .SchemaDefinition)
                                      .Where(s => s.PhysicalName == requestedExtensionPhysicalName)
                                      .Select(s => new EdFiSchema(s.LogicalName, s.PhysicalName))
                                      .First();

                _extensionOnlySwaggerDocumentFactory = SwaggerDocumentFactoryHelper
                   .GetExtensionOnlySwaggerDocumentFactory(
                        DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel(),
                        schemaDefinition);

                _resourceStrategy = new SdkGenExtensionResourceStrategy();
            }

            protected override void Act()
            {
                _actualMetadataText = _extensionOnlySwaggerDocumentFactory.Create(_resourceStrategy);
                _actualMetadataObject = OpenApiMetadataHelper.DeserializeSwaggerDocument(_actualMetadataText);
            }

            [Assert]
            public void Should_Only_Contain_Paths_For_The_Requested_Extension()
            {
                var pathsWithErrantNames = DomainModelDefinitionsProviderHelper
                                          .ResourceModelProvider
                                          .GetResourceModel()
                                          .GetAllResources()
                                          .SelectMany(r => r.AllContainedItemTypes)
                                          .Where(r => r.SchemaProperCaseName.ToLowerInvariant() == requestedExtensionPhysicalName)
                                          .SelectMany(
                                               d =>
                                               {
                                                   var schemaPath = "/" +
                                                                    DomainModelDefinitionsProviderHelper
                                                                       .SchemaNameMapProvider
                                                                       .GetSchemaMapByPhysicalName(d.SchemaProperCaseName)
                                                                       .UriSegment + "/";

                                                   return _actualMetadataObject.paths.Keys.Where(x => x.StartsWith(schemaPath));
                                               });

                AssertHelper.All(
                    () => Assert.That(_actualMetadataObject.paths.Keys, Is.Not.Empty),
                    () => Assert.That(pathsWithErrantNames, Is.Empty));
            }

            [Assert]
            public void Should_Contain_All_Definitions_For_The_Requested_Extension()
            {
                var entityDefinitions =
                    DomainModelDefinitionsProviderHelper
                       .DefinitionProviders
                       .Select(y => y.GetDomainModelDefinitions())
                       .Single(x => x.SchemaDefinition.PhysicalName == requestedExtensionPhysicalName)
                       .EntityDefinitions;

                Assert.That(_actualMetadataObject.definitions.Keys, Is.Not.Empty);

                _actualMetadataObject.definitions.Keys
                                     .Select(x => x.ToUpperInvariant())
                                     .Except(
                                          entityDefinitions
                                             .Select(
                                                  x =>
                                                      string.Format(
                                                                 "{0}_{1}",
                                                                 DomainModelDefinitionsProviderHelper
                                                                    .SchemaNameMapProvider
                                                                    .GetSchemaMapByPhysicalName(x.Schema)
                                                                    .ProperCaseName,
                                                                 x.Name)
                                                            .ToUpperInvariant())
                                             .Concat(
                                                  new[]
                                                  {
                                                      "LINK"
                                                  }));

                Assert.That(
                    entityDefinitions.Select(
                        x =>
                            string.Format(
                                       "{0}_{1}",
                                       DomainModelDefinitionsProviderHelper
                                          .SchemaNameMapProvider.GetSchemaMapByPhysicalName(x.Schema)
                                          .ProperCaseName,
                                       x.Name)
                                  .ToUpperInvariant()),
                    Is.SubsetOf(_actualMetadataObject.definitions.Keys.Select(x => x.ToUpperInvariant())));
            }
        }

        public class When_Generating_Extension_Only_Document : LegacyTestFixtureBase
        {
            private SwaggerDocumentFactory _extensionOnlySwaggerDocumentFactory;
            private SdkGenExtensionResourceStrategy _resourceStrategy;
            private string _actualMetadataText;
            private readonly string requestedExtensionPhysicalName = "sample";
            private OpenApiMetadataDocument _actualMetadataObject;

            protected override void Arrange()
            {
                var schemaDefinition = DomainModelDefinitionsProviderHelper
                                      .DefinitionProviders
                                      .Select(
                                           x => x.GetDomainModelDefinitions()
                                                 .SchemaDefinition)
                                      .Where(s => s.PhysicalName == requestedExtensionPhysicalName)
                                      .Select(s => new EdFiSchema(s.LogicalName, s.PhysicalName))
                                      .First();

                _extensionOnlySwaggerDocumentFactory = SwaggerDocumentFactoryHelper
                   .GetExtensionOnlySwaggerDocumentFactory(
                        DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel(),
                        schemaDefinition);

                _resourceStrategy = new SdkGenExtensionResourceStrategy();
            }

            protected override void Act()
            {
                _actualMetadataText = _extensionOnlySwaggerDocumentFactory.Create(_resourceStrategy);
                _actualMetadataObject = OpenApiMetadataHelper.DeserializeSwaggerDocument(_actualMetadataText);
            }

            [Assert]
            public void Should_Contain_All_Definitions_For_The_Requested_Extension()
            {
                var entityDefinitions =
                    DomainModelDefinitionsProviderHelper
                       .DefinitionProviders
                       .Select(y => y.GetDomainModelDefinitions())
                       .Single(x => x.SchemaDefinition.PhysicalName == requestedExtensionPhysicalName)
                       .EntityDefinitions;

                _actualMetadataObject.definitions.Keys
                                     .Select(x => x.ToUpperInvariant())
                                     .Except(
                                          entityDefinitions
                                             .Select(
                                                  x =>
                                                      string.Format(
                                                                 "{0}_{1}",
                                                                 DomainModelDefinitionsProviderHelper
                                                                    .SchemaNameMapProvider
                                                                    .GetSchemaMapByPhysicalName(x.Schema)
                                                                    .ProperCaseName,
                                                                 x.Name)
                                                            .ToUpperInvariant())
                                             .Concat(
                                                  new[]
                                                  {
                                                      "LINK"
                                                  }));

                Assert.That(
                    entityDefinitions.Select(
                        x =>
                            string.Format(
                                       "{0}_{1}",
                                       DomainModelDefinitionsProviderHelper
                                          .SchemaNameMapProvider.GetSchemaMapByPhysicalName(x.Schema)
                                          .ProperCaseName,
                                       x.Name)
                                  .ToUpperInvariant()),
                    Is.SubsetOf(_actualMetadataObject.definitions.Keys.Select(x => x.ToUpperInvariant())));
            }

            [Assert]
            public void Should_Contain_Only_Definitions_For_The_Requested_Extension()
            {
                var entityDefinitions =
                    DomainModelDefinitionsProviderHelper
                       .ResourceModelProvider
                       .GetResourceModel()
                       .GetAllResources()
                       .SelectMany(r => r.AllContainedItemTypes)
                       .Where(r => r.SchemaProperCaseName.ToLowerInvariant() == requestedExtensionPhysicalName);

                var nonBelongingDefinitions = _actualMetadataObject
                                             .definitions
                                             .Keys
                                             .Where(x => !x.EndsWith("Reference"))
                                             .Select(x => x.ToUpperInvariant())
                                             .Except(
                                                  entityDefinitions
                                                     .Select(
                                                          x => string.Format(
                                                                          @"{0}_{1}",
                                                                          DomainModelDefinitionsProviderHelper
                                                                             .SchemaNameMapProvider
                                                                             .GetSchemaMapByPhysicalName(x.SchemaProperCaseName)
                                                                             .ProperCaseName,
                                                                          x.Name)
                                                                     .ToUpperInvariant())
                                                     .Concat(
                                                          new[]
                                                          {
                                                              "LINK"
                                                          }));

                Assert.That(nonBelongingDefinitions, Is.Empty);
            }
        }

        public class When_Generating_Sdk_Gen_EdFi_Only_Document : LegacyTestFixtureBase
        {
            private SwaggerDefinitionsFactory _genericSwaggerDefinitionFactory;
            private SwaggerDocumentContext _swaggerDocumentContext;
            private IDictionary<string, Schema> _actualDefinitions;

            protected override void Arrange()
            {
                _swaggerDocumentContext = new SwaggerDocumentContext(
                                              DomainModelDefinitionsProviderHelper
                                                 .ResourceModelProvider
                                                 .GetResourceModel())
                                          {
                                              RenderType = RenderType.GeneralizedExtensions,
                                              IsIncludedExtension = x => x.FullName.Schema.Equals(EdFiConventions.PhysicalSchemaName)
                                          };

                _genericSwaggerDefinitionFactory =
                    SwaggerDocumentFactoryHelper.CreateSwaggerDefinitionsFactory(
                        _swaggerDocumentContext);
            }

            protected override void Act()
            {
                var d1 = new SdkGenAllEdFiResourceStrategy()
                        .GetFilteredResources(_swaggerDocumentContext)
                        .Select(d => d.Resource.Entity)
                        .ToList();

                _actualDefinitions = _genericSwaggerDefinitionFactory
                   .Create(
                        new SdkGenAllEdFiResourceStrategy()
                           .GetFilteredResources(_swaggerDocumentContext)
                           .ToList());
            }

            [Assert]
            public void Should_Contain_Only_EdFi_Resource_Definitions()
            {
                var edFiSchemaPrefix = "edFi_";

                AssertHelper.All(
                    _actualDefinitions.Keys
                                      .Except(
                                           new[]
                                           {
                                               "link"
                                           })
                                      .Select(
                                           d =>
                                               (Action)
                                               (() =>
                                                    Assert.That(
                                                        d.StartsWith(edFiSchemaPrefix),
                                                        Is.True,
                                                        $@"Definition name {d} does not belong with '{edFiSchemaPrefix}' schema prefix.")))
                                      .ToArray());
            }

            [Assert]
            public void Should_Contain_Extended_EdFi_Resources_With_Generic_Extension_Collection()
            {
                Schema extendedEdFiResource;

                if (!_actualDefinitions.TryGetValue("edFi_staff", out extendedEdFiResource))
                {
                    Assert.Fail("The \'edFi_staff\' definition could not be found for evaluation.");
                }

                var extendedEdFiResourceProperties = extendedEdFiResource.properties;

                AssertHelper.All(
                    () =>
                        Assert.That(
                            extendedEdFiResourceProperties.ContainsKey("_ext"),
                            "Generic extension collection '_ext' not found as a property on extended EdFi resource Staff"),
                    () =>
                        Assert.That(
                            extendedEdFiResourceProperties["_ext"]
                               .@ref,
                            Is.Null,
                            "Extension collection property '_ext' @ref was not null"));
            }
        }

        public class When_Generating_Sdk_Gen_All_Document : LegacyTestFixtureBase
        {
            private SwaggerDefinitionsFactory _genericSwaggerDefinitionFactory;
            private SwaggerDocumentContext _swaggerDocumentContext;
            private IDictionary<string, Schema> _actualDefinitions;
            private IDomainModelProvider _domainModelProvider;
            private ISchemaNameMapProvider _schemaNameMapProvider;

            protected override void Arrange()
            {
                _swaggerDocumentContext = new SwaggerDocumentContext(
                    DomainModelDefinitionsProviderHelper
                       .ResourceModelProvider
                       .GetResourceModel());

                _genericSwaggerDefinitionFactory =
                    SwaggerDocumentFactoryHelper.CreateSwaggerDefinitionsFactory(
                        _swaggerDocumentContext);

                _domainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;

                _schemaNameMapProvider = _domainModelProvider.GetDomainModel()
                                                             .SchemaNameMapProvider;
            }

            protected override void Act()
            {
                _actualDefinitions = _genericSwaggerDefinitionFactory
                   .Create(
                        new SdkGenAllResourceStrategy()
                           .GetFilteredResources(_swaggerDocumentContext)
                           .ToList());
            }

            [Assert]
            public void Should_Contain_Resource_Definitions_For_All_Schemas()
            {
                var expectedSchemaPrefixes = DomainModelDefinitionsProviderHelper
                                            .DomainModelProvider
                                            .GetDomainModel()
                                            .Schemas
                                            .Select(
                                                 d => _schemaNameMapProvider.GetSchemaMapByLogicalName(d.LogicalName)
                                                                            .ProperCaseName)
                                            .Select(p => $"{p}".ToCamelCase())
                                            .ToList();

                var actualSchemaPrefixes = _actualDefinitions.Select(d => d.Key)
                                                             .Where(
                                                                  d =>
                                                                      !d.EndsWithIgnoreCase(
                                                                          "Extensions"))
                                                             .Except(
                                                                  new[]
                                                                  {
                                                                      "link"
                                                                  })
                                                             .Select(
                                                                  d => d.Split('_')
                                                                        .First())
                                                             .Distinct()
                                                             .ToList();

                var missingSchemaPrefixes = expectedSchemaPrefixes.Except(actualSchemaPrefixes);
                var extraSchemaPrefixes = actualSchemaPrefixes.Except(expectedSchemaPrefixes);

                Assert.That(
                    missingSchemaPrefixes,
                    Is.Empty,
                    $"The following schemas were not found in actual definitions: {string.Join(", ", missingSchemaPrefixes)}");

                Assert.That(
                    extraSchemaPrefixes,
                    Is.Empty,
                    $"The following schemas should not have been included in actual definitions: {string.Join(", ", extraSchemaPrefixes)}");
            }

            [Assert]
            public void Should_Contain_Extended_EdFi_Resources_With_Default_Extension_Collection()
            {
                var extendedEdFiResource = _actualDefinitions["edFi_staff"];
                var extendedEdFiResourceProperties = extendedEdFiResource.properties;

                var expectedExtensionCollectionReference = "#/definitions/staffExtensions";

                AssertHelper.All(
                    () =>
                        Assert.That(
                            extendedEdFiResourceProperties.ContainsKey("_ext"),
                            "Generic extension collection '_ext' not found as a property on extended EdFi resource Staff"),
                    () =>
                        Assert.That(
                            extendedEdFiResourceProperties["_ext"]
                               .@ref,
                            Is.EqualTo(expectedExtensionCollectionReference),
                            $"Extension collection property '_ext' @ref was not equal to expected: {expectedExtensionCollectionReference}"));
            }

            [Assert]
            public void Should_Contain_Extended_EdFi_Resource_Bridge_Definition()
            {
                Assert.That(
                    _actualDefinitions.ContainsKey("staffExtensions"),
                    Is.True,
                    "Extension bridge schema for staff does not exists, expected was staffExtensions");
            }

            [Assert]
            public void Should_Contain_Extended_EdFi_Resource_Bridge_Definition_With_A_Definition_Reference_For_Each_Extension()
            {
                var expectedExtensions = DomainModelDefinitionsProviderHelper
                                        .DomainModelProvider
                                        .GetDomainModel()
                                        .Entities
                                        .Where(e => e.IsEntityExtension && e.EdFiStandardEntityAssociation.OtherEntity.Name == "Staff")
                                        .ToList();

                var expectedBridgeSchemaExtensions = expectedExtensions
                                                    .Select(e => e.Schema)
                                                    .Select(
                                                         l => _schemaNameMapProvider.GetSchemaMapByPhysicalName(l)
                                                                                    .ProperCaseName);

                var expectedBridgeSchemaExtensionReferences = expectedExtensions
                                                             .Select(e => e.Schema)
                                                             .Select(
                                                                  l => _schemaNameMapProvider.GetSchemaMapByPhysicalName(l)
                                                                                             .ProperCaseName)
                                                             .Select(p => $"#/definitions/{p.ToCamelCase()}_staffExtension");

                var extendedEdFiResource = _actualDefinitions["staffExtensions"];

                var extendedEdFiResourcePropertyNames = extendedEdFiResource.properties.Select(p => p.Key);
                var extendedEdFiResourcePropertyReferences = extendedEdFiResource.properties.Select(p => p.Value.@ref);

                AssertHelper.All(
                    () =>
                        Assert.That(
                            extendedEdFiResourcePropertyNames,
                            Is.EquivalentTo(expectedBridgeSchemaExtensions),
                            "Actual Bridge Schema properties do not match expected Bridge Schema properties"),
                    () =>
                        Assert.That(
                            extendedEdFiResourcePropertyReferences,
                            Is.EqualTo(expectedBridgeSchemaExtensionReferences),
                            "Actual Bridge Schema property references do not match expected Bridge Schema property definition references"));
            }

            [Assert]
            public void Should_Contain_Extended_EdFi_Resource_Extension_Definition_For_Each_Extension()
            {
                var expectedExtensions = DomainModelDefinitionsProviderHelper
                                        .DomainModelProvider
                                        .GetDomainModel()
                                        .Entities
                                        .Where(e => e.IsEntityExtension && e.EdFiStandardEntityAssociation.OtherEntity.Name == "Staff")
                                        .ToList();

                var expectedExtensionDefinitions = expectedExtensions
                                                  .Select(e => e.Schema)
                                                  .Select(
                                                       l => _schemaNameMapProvider.GetSchemaMapByPhysicalName(l)
                                                                                  .ProperCaseName)
                                                  .Select(p => $"{p.ToCamelCase()}_staffExtension");

                var actualExtensionDefitions = _actualDefinitions.Where(
                                                                      d =>
                                                                          d.Key.EndsWith(
                                                                              "_staffExtension"))
                                                                 .Select(d => d.Key);

                AssertHelper.All(
                    () =>
                        Assert.That(
                            actualExtensionDefitions,
                            Is.EquivalentTo(expectedExtensionDefinitions),
                            "Actual extension definitions does not matched expected extension definitions for Staff"));
            }
        }
    }
}
