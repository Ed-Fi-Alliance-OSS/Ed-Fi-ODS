// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Strategies.ResourceStrategies
{
    [TestFixture]
    public class OpenApiCompositeStrategyTests
    {
        private static readonly IResourceModelProvider _resourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        public class When_list_of_resources_is_filtered_with_composite_strategy : TestFixtureBase
        {
            private ICompositesMetadataProvider _compositesMetadataProvider;
            private SwaggerResource _compositeResource;
            private SwaggerDocumentContext _swaggerDocumentContext;

            protected override void Arrange()
            {
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                var routes = new  List<XElement>(OpenApiCompositeHelper.Routes).ToReadOnlyList();
                var definitions = new List<XElement>(OpenApiCompositeHelper.CompositeDefinitions).ToReadOnlyList();

                A.CallTo(() => _compositesMetadataProvider.TryGetRoutes(
                             A<string>._, 
                             A<string>._, 
                             out routes))
                 .Returns(true);

                A.CallTo(() => _compositesMetadataProvider.TryGetCompositeDefinitions(
                             A<string>._, 
                             A<string>._, 
                             out definitions))
                 .Returns(true);

                _swaggerDocumentContext = new SwaggerDocumentContext(
                                              _resourceModelProvider.GetResourceModel())
                                          {
                                              CompositeContext = new SwaggerCompositeContext
                                                                 {
                                                                     CategoryName = OpenApiCompositeHelper.CategoryName
                                                                 }
                                          };
            }

            protected override void Act()
            {
                _compositeResource =
                    new OpenApiCompositeStrategy(_compositesMetadataProvider).GetFilteredResources(
                                                                                  _swaggerDocumentContext)
                                                                             .FirstOrDefault();
            }

            [Assert]
            public void Should_populate_composite_context_route_definitions()
            {
                _swaggerDocumentContext.CompositeContext.RouteElements.ShouldNotBeEmpty();
            }

            [Assert]
            public void Should_construct_valid_composite_swagger_resource_from_the_provided_composite_definition()
            {
                AssertHelper.All(
                    () => _compositeResource.Name.ShouldBe(OpenApiCompositeHelper.CategoryName.ToMixedCase()),
                    () => _compositeResource.ShouldNotBeNull(),
                    () => _compositeResource.Readable.ShouldBeTrue(),
                    () => _compositeResource.IsCompositeResource.ShouldBeTrue(),
                    () => _compositeResource.CompositeResourceContext.BaseResource.ShouldNotBeNull(),
                    () => _compositeResource.CompositeResourceContext.Specification.ShouldNotBeNull());
            }
        }
    }
}
