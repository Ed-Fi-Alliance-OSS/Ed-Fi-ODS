// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.OpenApiMetadata.Dtos
{
    public class SwaggerPathsResource : SwaggerResource
    {
        private static readonly Regex _isCompositeRouteTemplatePath = new Regex("/{(\\w+)}/");

        private string _path;

        public SwaggerPathsResource(Resource resource)
            : base(resource) { }

        public SwaggerPathsResource(SwaggerResource swaggerResource)
            : base(swaggerResource) { }

        public string OperationId { get; set; }

        public bool IsDeprecated => Resource.IsDeprecated;

        public string Path
        {
            get { return _path ?? string.Empty; }
            set { _path = value; }
        }

        public bool SupportsIdAccessOperations => !_isCompositeRouteTemplatePath.IsMatch(Path)
                                                  || _isCompositeRouteTemplatePath.IsMatch(Path) && Path.EndsWith("{{id}}");

        public bool SupportsAccessNonIdAccessOperations => !_isCompositeRouteTemplatePath.IsMatch(Path)
                                                           || _isCompositeRouteTemplatePath.IsMatch(Path) && !Path.EndsWith("{{id}}");

        // TODO - JSM ODS-1699 changed the routes to include the edfi schema name, which implies that composites will only be Ed-Fi specific.
        // StartupBase has the route defined as a parameter in composites so in the future this may need to be abstracted appropriately.
        public string ResourceSchema => IsCompositeResource
            ? CompositeResourceContext.OrganizationCode
            : Resource.ResourceModel.SchemaNameMapProvider
                      .GetSchemaMapByPhysicalName(Resource.Entity.Schema)
                      .UriSegment;

        public IEnumerable<string> DefaultGetByIdParameters => IsCompositeResource
            ? new[]
              {
                  "fields"
              }
            : Enumerable.Empty<string>();

        public IEnumerable<string> DefaultGetByExampleParameters => IsCompositeResource
            ? new[]
              {
                  "fields", "queryExpression"
              }
            : Enumerable.Empty<string>();

        private IEnumerable<ResourceProperty> PathParameters => RequestProperties.Where(p => Path.ContainsIgnoreCase($"{{{p.PropertyName}}}"));

        public bool IsPathParameter(ResourceProperty resourceProperty)
            => PathParameters.Contains(resourceProperty, ModelComparers.ResourcePropertyNameOnly);
    }
}
