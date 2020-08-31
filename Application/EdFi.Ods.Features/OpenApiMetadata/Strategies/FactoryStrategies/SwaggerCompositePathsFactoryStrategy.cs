// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies.FactoryStrategies
{
    public class SwaggerCompositePathsFactoryStrategy : ISwaggerPathsFactorySelectorStrategy
    {
        private readonly XElement _defaultCollectionRoute = XElement.Parse("<Route relativeRouteTemplate='/{compositeName}' />");
        private readonly XElement _defaultItemRoute = XElement.Parse("<Route relativeRouteTemplate='/{compositeName}/{id}' />");
        private readonly SwaggerDocumentContext _swaggerDocumentContext;

        public SwaggerCompositePathsFactoryStrategy(SwaggerDocumentContext swaggerDocumentContext)
        {
            _swaggerDocumentContext = swaggerDocumentContext;
        }

        public IEnumerable<SwaggerPathsResource> ApplyStrategy(IEnumerable<SwaggerResource> swaggerResources)
        {
            var swaggerResourceList = swaggerResources.Select(
                                                           r => new SwaggerPathsResource(r.Resource)
                                                                {
                                                                    CompositeResourceContext =
                                                                        r.CompositeResourceContext,
                                                                    Readable = true, Path =
                                                                        $"/{_swaggerDocumentContext.CompositeContext.CategoryName}/{r.Resource.PluralName}",
                                                                    RequestProperties = GetMetaDataPropertiesForCurrentResource(r)
                                                                })
                                                      .ToList();

            return swaggerResourceList
               .Concat(
                    swaggerResourceList
                       .Where(r => r.IsCompositeResource)
                       .SelectMany(GetContainedResources));
        }

        public bool HasTotalCount => false;

        private IEnumerable<SwaggerPathsResource> GetContainedResources(
            SwaggerResource swaggerResource)
        {
            return _swaggerDocumentContext.CompositeContext.RouteElements
                                          .Where(
                                               route =>
                                                   !IsDefaultRoute(route)
                                                   && RouteAppliesToResource(route, swaggerResource))
                                          .SelectMany(
                                               d =>
                                               {
                                                   var operationSpecSuffix = GetOperationSpecNickname(swaggerResource.Resource, d);

                                                   var swaggerResources = new List<SwaggerPathsResource>();

                                                   if (operationSpecSuffix.EqualsIgnoreCase("All"))
                                                   {
                                                       swaggerResources.Add(CreateGetByExampleEndpoint(swaggerResource, d));
                                                       swaggerResources.Add(CreateGetByIdEndpoint(swaggerResource, d));
                                                   }

                                                   if (!operationSpecSuffix.StartsWith("By"))
                                                   {
                                                       return swaggerResources;
                                                   }

                                                   swaggerResources.Add(
                                                       operationSpecSuffix.Equals("ById")
                                                           ? CreateGetByIdEndpoint(swaggerResource, d)
                                                           : CreateGetByExampleEndpoint(swaggerResource, d, true));

                                                   return swaggerResources;
                                               });
        }

        private SwaggerPathsResource CreateGetByExampleEndpoint(
            SwaggerResource swagggerResource,
            XElement routeDefinition,
            bool withIdParameters = false)
        {
            return new SwaggerPathsResource(swagggerResource.Resource)
                   {
                       Name = swagggerResource.Resource.Name,
                       Path = ToSwaggerIdentifier($"/{GetResourcePathValue(swagggerResource, routeDefinition)}"), CompositeResourceContext =
                           new CompositeResourceContext
                           {
                               OrganizationCode = _swaggerDocumentContext.CompositeContext.OrganizationCode, BaseResource = swagggerResource.Name,
                               Specification = routeDefinition
                           },
                       OperationId =
                           $"get{swagggerResource.Resource.PluralName}{GetOperationSpecNickname(swagggerResource.Resource, routeDefinition)}",
                       RequestProperties =
                           GetSwaggerEndpointGetByExampleParameters(swagggerResource)
                              .Concat(
                                   withIdParameters
                                       ? GetSwaggerEndpointGetByIdParameters(
                                           swagggerResource,
                                           routeDefinition)
                                       : Enumerable.Empty<ResourceProperty>()),
                       Readable = true, Writable = false
                   };
        }

        private string GetResourcePathValue(SwaggerResource swagggerResource, XElement routeDefinition)
        {
            string regexPattern = @"\{([^)]*)\}";

            var resourcePathValue = _swaggerDocumentContext.CompositeContext.CategoryName
                                    + routeDefinition.AttributeValue("relativeRouteTemplate")
                                                     .Replace("{compositeName}", swagggerResource.Resource.PluralName.ToCamelCase());

            var parameterValue = Regex.Match(resourcePathValue, regexPattern)
                                      .Groups[1]
                                      .Value;

            return Regex.Replace(resourcePathValue, regexPattern, $"{{{parameterValue.ToCamelCase()}}}");
        }

        private IEnumerable<ResourceProperty> GetSwaggerEndpointGetByExampleParameters(SwaggerResource swagggerResource)
        {
            var resourceSpecification = swagggerResource.CompositeResourceContext.Specification;

            var queryParameters = resourceSpecification.Elements("Parameter")
                                                       .Where(
                                                            e => e.AttributeValue("queryable")
                                                                  .EqualsIgnoreCase("true"))
                                                       .ToList();

            var swaggerQueryParameters =
                (from p in queryParameters
                 where swagggerResource.Resource != null
                 select
                     new ResourceProperty(
                         swagggerResource.Resource,
                         ToSwaggerIdentifier(p.AttributeValue("name")),
                         new PropertyType(
                             GetSwaggerTypeForQueryParameter(swagggerResource.Resource, p)
                             ?? DbType.String),
                         new PropertyCharacteristics(
                             false,
                             false,
                             false,
                             false,
                             false,
                             swagggerResource.Resource.FullName),
                         swagggerResource.Description ?? p.AttributeValue("description")))
               .ToList();

            return swaggerQueryParameters.Concat(GetMetaDataPropertiesForCurrentResource(swagggerResource));
        }

        private IEnumerable<ResourceProperty> GetMetaDataPropertiesForCurrentResource(SwaggerResource swagggerResource)
        {
            var currentResourceBaseAndSpec = swagggerResource.CompositeResourceContext;

            //  This value will be calculated differently as a part of the Phase 4 work.
            var physicalName = EdFiConventions.PhysicalSchemaName;

            var resource =
                _swaggerDocumentContext.ResourceModel.GetResourceByFullName(
                    new FullName(physicalName, currentResourceBaseAndSpec.BaseResource));

            return resource
                  .AllProperties
                  .Where(p => p.EntityProperty?.IsIdentifying ?? false)
                  .Select(p => CreateResourcePropertyForQueryStringParameter(swagggerResource.Resource, p));
        }

        private ResourceProperty CreateResourcePropertyForQueryStringParameter(
            Resource containingResource,
            ResourceProperty fullModelResourceProperty)
        {
            var entityProperty = fullModelResourceProperty.EntityProperty;

            // All projected properties are "local" properties on the new object
            return new ResourceProperty(
                containingResource,
                fullModelResourceProperty.PropertyName.ToCamelCase(),
                fullModelResourceProperty.PropertyType,
                new PropertyCharacteristics(
                    entityProperty.IsLookup,
                    entityProperty.IsDirectLookup,
                    entityProperty.IsIdentifying,
                    true,
                    entityProperty.IsServerAssigned,
                    entityProperty.LookupEntity?.FullName),
                fullModelResourceProperty.Description);
        }

        private SwaggerPathsResource CreateGetByIdEndpoint(SwaggerResource swagggerResource, XElement routeDefinition)
        {
            return new SwaggerPathsResource(swagggerResource.Resource)
                   {
                       Name = swagggerResource.Resource.Name,
                       Path = ToSwaggerIdentifier($"{GetResourcePathValue(swagggerResource, routeDefinition)}"), CompositeResourceContext =
                           new CompositeResourceContext
                           {
                               OrganizationCode = _swaggerDocumentContext.CompositeContext.OrganizationCode, BaseResource = swagggerResource.Name,
                               Specification = routeDefinition
                           },
                       OperationId =
                           $"get{swagggerResource.Resource.PluralName}{GetOperationSpecNickname(swagggerResource.Resource, routeDefinition)}",
                       RequestProperties =
                           GetSwaggerEndpointGetByIdParameters(
                               swagggerResource,
                               routeDefinition),
                       Readable = true, Writable = false
                   };
        }

        private IEnumerable<ResourceProperty> GetSwaggerEndpointGetByIdParameters(
            SwaggerResource swagggerResource,
            XElement routeDefinition)
        {
            string path = "/" + _swaggerDocumentContext.CompositeContext.CategoryName
                              + routeDefinition.AttributeValue("relativeRouteTemplate")
                                               .Replace(
                                                    "{compositeName}",
                                                    swagggerResource.Resource.PluralName.ToCamelCase());

            var matches = Regex.Matches(path, @"\{(?<Parameter>[\w\.]+)\}");

            return
                (from m in matches.Cast<Match>()
                 select new ResourceProperty(
                     swagggerResource.Resource,
                     ToSwaggerIdentifier(
                         m.Groups["Parameter"]
                          .Value),
                     new PropertyType(DbType.String),
                     new PropertyCharacteristics(
                         false,
                         false,
                         false,
                         false,
                         false,
                         new FullName(
                             EdFiConventions.PhysicalSchemaName,
                             swagggerResource.Resource.Name)),
                     swagggerResource.Description))
               .ToList();
        }

        private string ToSwaggerIdentifier(string identifier)
        {
            // Ensures that Swagger identifiers use underscores (for code generation compatibility) 
            // and the terms are individual camelcased.
            return string.Join(
                "_",
                identifier
                   .Replace('.', '_')
                   .Split('_')
                   .Select(x => x.ToCamelCase()));
        }

        private DbType? GetSwaggerTypeForQueryParameter(Resource resource, XElement parameter)
        {
            DbType? swaggerType = null;

            new ResourceJoinPathExpressionProcessor().ProcessPath(
                resource,
                parameter.AttributeValue("name"),
                parameter.AttributeValue("filterPath"),
                (prop, part) => swaggerType = prop.PropertyType.DbType);

            if (swaggerType == null)
            {
                throw new Exception(
                    string.Format(
                        "Unable to determine Swagger type for parameter '{0}' with filter path expression '{1}'.",
                        parameter.AttributeValue("name"),
                        parameter.AttributeValue("filterPath")));
            }

            return swaggerType;
        }

        private string GetOperationSpecNickname(Resource resource, XElement routeDefinition, bool includeSuffix = true)
        {
            var parametersNames =
                GetApiSpecPathParameters(resource, routeDefinition)
                   .Select(GetSwaggerOperationNicknameContribution)
                   .ToList();

            if (parametersNames.Count == 1)
            {
                var suffix = includeSuffix
                    ? "By"
                    : string.Empty;

                return $"{suffix}{parametersNames.First().ToMixedCase()}";
            }

            if (parametersNames.Count == 0)
            {
                return includeSuffix
                    ? "All"
                    : null;
            }

            throw new NotSupportedException(
                "Building operation nickname suffixes where more than 1 parameter exists in the route definition is not supported.");
        }

        private string GetSwaggerOperationNicknameContribution(string parameterName)
        {
            if (!parameterName.Contains("_") && !parameterName.Contains("."))
            {
                return parameterName;
            }

            if (!parameterName.EndsWithIgnoreCase("_Id") && !parameterName.EndsWithIgnoreCase(".Id"))
            {
                throw new Exception(
                    "Two part parameter names are expected to refer to the resource's identifier (i.e. the 'Id' property).");
            }

            return parameterName.Split('_', '.')[0]
                                .ToMixedCase();
        }

        private IEnumerable<string> GetApiSpecPathParameters(Resource resource, XElement routeDefinition)
        {
            string path = GetApiSpecPath(resource, routeDefinition);

            var matches = Regex.Matches(path, @"\{(?<Parameter>[\w\.]+)\}");

            return matches.Cast<Match>()
                          .Select(
                               m => ToSwaggerIdentifier(
                                   m.Groups["Parameter"]
                                    .Value));
        }

        private string GetApiSpecPath(Resource resource, XElement routeDefinition)
        {
            string template = routeDefinition.AttributeValue("relativeRouteTemplate");

            return "/" + _swaggerDocumentContext.CompositeContext.CategoryName
                       + template.Replace("{compositeName}", resource.PluralName.ToCamelCase());
        }

        private bool IsDefaultRoute(XElement route)
        {
            return route.AttributeValue("relativeRouteTemplate")
                   == _defaultCollectionRoute.AttributeValue("relativeRouteTemplate")
                   || route.AttributeValue("relativeRouteTemplate")
                   == _defaultItemRoute.AttributeValue("relativeRouteTemplate");
        }

        private bool RouteAppliesToResource(
            XElement routeDefinition,
            SwaggerResource swaggerResource)
        {
            string routeTemplateToTest = routeDefinition.AttributeValue("relativeRouteTemplate");

            // ASSUMPTION: Routes will only contain a single GUID parameter. If there are multiple parameters 
            // in the route, then the logic will have to be rewritten to drive off the route template's contents
            // to identify all the parameters that need to be defined in the specification, and fail to match the
            // route if any of the route's parameters aren't defined in the resource specification.

            // Get the specification parameters
            // Match this route if any of the parameters are present
            return swaggerResource.CompositeResourceContext.Specification != null
                   && swaggerResource.CompositeResourceContext.Specification
                                     .Elements("Parameter")
                                     .Any(
                                          p => routeTemplateToTest
                                             .Contains("{" + p.AttributeValue("name") + "}"));
        }
    }
}
