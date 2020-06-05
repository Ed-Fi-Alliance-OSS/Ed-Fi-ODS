// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Strategies.FactoryStrategies
{
    [TestFixture]
    public class SwaggerCompositePathsFactoryStrategyTests
    {
        private static readonly IResourceModelProvider _resourceModelProvider = DomainModelDefinitionsProviderHelper.ResourceModelProvider;

        private class SwaggerPathsResourceComparer : IEqualityComparer<SwaggerPathsResource>
        {
            public bool Equals(SwaggerPathsResource x, SwaggerPathsResource y)
            {
                return x.Name == y.Name
                       && x.Readable == y.Readable
                       && x.Writable == y.Writable
                       && x.IsCompositeResource == y.IsCompositeResource
                       && x.Path.EqualsIgnoreCase(y.Path);
            }

            public int GetHashCode(SwaggerPathsResource obj)
            {
                return obj.GetHashCode();
            }
        }

        public class When_the_swagger_composite_paths_factory_strategy_is_applied_to_a_list_of_swagger_resources : TestFixtureBase
        {
            private ICompositesMetadataProvider _compositesMetadataProvider;
            private IEnumerable<SwaggerResource> _filteredResources;
            private IEnumerable<SwaggerPathsResource> _actualStrategyAppliedResources;
            private IEnumerable<SwaggerPathsResource> _expectedStrategyAppliedResources;
            private SwaggerDocumentContext _swaggerDocumentContext;

            protected override void Arrange()
            {
                _compositesMetadataProvider = Stub<ICompositesMetadataProvider>();

                var definitions = new List<XElement>(OpenApiCompositeHelper.CompositeDefinitions).ToReadOnlyList();
                var routes = new List<XElement>(OpenApiCompositeHelper.Routes).ToReadOnlyList();

                A.CallTo(
                      () => _compositesMetadataProvider.TryGetCompositeDefinitions(
                          A<string>._,
                          A<string>._,
                          out definitions))
                 .Returns(true);

                A.CallTo(
                      () => _compositesMetadataProvider.TryGetRoutes(
                          A<string>._,
                          A<string>._,
                          out routes))
                 .Returns(true);
                
                _swaggerDocumentContext = new SwaggerDocumentContext(
                                              _resourceModelProvider.GetResourceModel())
                                          {
                                              CompositeContext = new SwaggerCompositeContext
                                                                 {
                                                                     CategoryName =
                                                                         OpenApiCompositeHelper
                                                                            .CategoryName
                                                                 }
                                          };

                _filteredResources =
                    new OpenApiCompositeStrategy(_compositesMetadataProvider)
                       .GetFilteredResources(_swaggerDocumentContext);

                var assessmentResource = _resourceModelProvider
                                        .GetResourceModel()
                                        .GetResourceByFullName(new FullName(EdFiConventions.PhysicalSchemaName, "Assessment"));

                _expectedStrategyAppliedResources =
                    OpenApiCompositeHelper.Routes
                                          .Where(r => !IsBaseResourceRoute(r))
                                          .Select(
                                               r => new SwaggerPathsResource(assessmentResource)
                                                    {
                                                        CompositeResourceContext =
                                                            new CompositeResourceContext(),
                                                        Path =
                                                            GetCompositeResourcePath(
                                                                    assessmentResource,
                                                                    r)
                                                               .ToCamelCase(),
                                                        OperationId =
                                                            GetCompositeResourceOperationId(
                                                                assessmentResource,
                                                                r),
                                                        Readable = true, Writable = false
                                                    })
                                          .Concat(
                                               new[]
                                               {
                                                   new SwaggerPathsResource(assessmentResource)
                                                   {
                                                       CompositeResourceContext = new CompositeResourceContext(), Path =
                                                           $"{_swaggerDocumentContext.CompositeContext.CategoryName}/{assessmentResource.PluralName}",
                                                       OperationId = "getAssessments", Readable = true, Writable = false
                                                   }
                                               });
            }

            protected override void Act()
            {
                _actualStrategyAppliedResources =
                    new SwaggerCompositePathsFactoryStrategy(_swaggerDocumentContext)
                       .ApplyStrategy(_filteredResources)
                       .ToList();
            }

            [Assert]
            public void Should_not_return_empty_list_of_swagger_paths_resources()
            {
                _actualStrategyAppliedResources.ShouldNotBeEmpty();
            }

            private string GetCompositeResourcePath(Resource baseResource, XElement routeDefinition) =>

                // <Route relativeRouteTemplate='/localEducationAgencies/{LocalEducationAgency.Id}/{compositeName}' />
                // localEducationAgencies/{LocalEducationAgency_Id}/assessments
                string.Format(
                    @"{0}{1}",
                    OpenApiCompositeHelper.CategoryName,
                    routeDefinition.AttributeValue("relativeRouteTemplate")
                                   .Replace("{compositeName}", baseResource.PluralName.ToCamelCase())
                                   .Replace(".", "_"));

            private string GetCompositeResourceOperationId(Resource baseResource, XElement routeDefinition)
            {
                // <Route relativeRouteTemplate='/localEducationAgencies/{LocalEducationAgency.Id}/{compositeName}' />
                var routeResource = routeDefinition
                                   .AttributeValue("relativeRouteTemplate")
                                   .Split('/')
                                   .Skip(2)

                                    // LocalEducationAgency.Id
                                   .First()
                                   .Split('.')

                                    // {LocalEducationAgency}
                                   .First()
                                   .Replace("{", string.Empty)
                                   .Replace("}", string.Empty);

                // getAssessmentsByLocalEducationAgency
                return $"get{baseResource.PluralName}By{routeResource}";
            }

            private bool IsBaseResourceRoute(XElement routeDefinition)
            {
                return routeDefinition.AttributeValue("relativeRouteTemplate")
                                      .Contains("Assessment.Id");
            }
        }
    }
}
