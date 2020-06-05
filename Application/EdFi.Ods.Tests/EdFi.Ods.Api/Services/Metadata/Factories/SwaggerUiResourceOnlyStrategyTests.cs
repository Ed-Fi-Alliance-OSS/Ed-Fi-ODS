// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Factories
{
    [TestFixture]
    public class SwaggerUiResourceOnlyStrategyTests
    {
        protected static IResourceModelProvider ResourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        protected static ISchemaNameMapProvider SchemaNameMapProvider = DomainModelDefinitionsProviderHelper.SchemaNameMapProvider;

        public class When_filtering_resources_with_resource_only_strategy : TestFixtureBase
        {
            private IEnumerable<Resource> _resources;
            private SwaggerUiResourceOnlyStrategy _swaggerUiResourceOnlyStrategy;
            private string[] _expectedResources;

            protected override void Arrange()
            {
                _expectedResources = ResourceModelProvider.GetResourceModel()
                                                          .GetAllResources()
                                                          .Where(x => !x.IsDescriptorEntity() && !x.IsAbstract())
                                                          .Select(x => x.Name)
                                                          .ToArray();

                _swaggerUiResourceOnlyStrategy = new SwaggerUiResourceOnlyStrategy();
            }

            protected override void Act()
            {
                _resources = _swaggerUiResourceOnlyStrategy.GetFilteredResources(
                                                                DomainModelDefinitionsProviderHelper.DefaultSwaggerDocumentContext)
                                                           .Select(x => x.Resource);
            }

            [Assert]
            public void Should_contain_only_resources()
            {
                Assert.That(
                    _resources.Select(x => x.Name)
                              .ToArray(),
                    Is.EquivalentTo(_expectedResources));
            }
        }
    }
}
