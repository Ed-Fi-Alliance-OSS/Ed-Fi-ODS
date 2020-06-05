// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Security.Conventions;

namespace EdFi.Ods.Security.Authorization
{
    /// <summary>
    /// Provides extension methods for building resource claim URIs for authorization purposes.
    /// </summary>
    public class ResourceClaimUriProvider : IResourceClaimUriProvider
    {
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceClaimUriProvider" /> class using the supplied schema name map provider.
        /// </summary>
        /// <param name="schemaNameMapProvider">The provider for mapping between schema names.</param>
        public ResourceClaimUriProvider(ISchemaNameMapProvider schemaNameMapProvider)
        {
            _schemaNameMapProvider = Preconditions.ThrowIfNull(schemaNameMapProvider, nameof(schemaNameMapProvider));
        }

        /// <summary>
        /// Gets the resource URIs for the specified resource Type using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="resourceType">The resource Type for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        public string[] GetResourceClaimUris(Type resourceType)
        {
            Preconditions.ThrowIfNull(resourceType, nameof(resourceType));
            
            string schemaProperCaseName = resourceType.ParseResourceSchemaProperCaseName();
            string resourceName = resourceType.Name;

            string schemaUriSegment = _schemaNameMapProvider
                .GetSchemaMapByProperCaseName(schemaProperCaseName)
                .UriSegment;
            
            return new []
            {
                // Schema-based URI format
                CreateSchemaBasedResourceClaimUri(schemaUriSegment, resourceName),
                
                // Legacy URI format
                CreateLegacyResourceClaimUri(resourceName),
            };
        }

        /// <summary>
        /// Gets the resource URIs for the specified Resource class using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="resource">The <see cref="EdFi.Ods.Common.Models.Resource.Resource" /> for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        public string[] GetResourceClaimUris(Resource resource)
        {
            Preconditions.ThrowIfNull(resource, nameof(resource));
            
            return new []
            {
                // Schema-based URI format
                CreateSchemaBasedResourceClaimUri(resource.SchemaUriSegment(), resource.Name),
                
                // Legacy URI format
                CreateLegacyResourceClaimUri(resource.Name),
            };
        }
        
        /// <summary>
        /// Gets the resource URIs for the specified Entity class using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="entity">The <see cref="EdFi.Ods.Common.Models.Domain.Entity" /> for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        public string[] GetResourceClaimUris(Entity entity)
        {
            Preconditions.ThrowIfNull(entity, nameof(entity));
            
            return new []
            {
                // Schema-based URI format
                CreateSchemaBasedResourceClaimUri(entity.SchemaUriSegment(), entity.Name),
                
                // Legacy URI format
                CreateLegacyResourceClaimUri(entity.Name),
            };
        }
        
        /// <summary>
        /// Gets the resource URI for the supplied resource name, based on convention of the resource's schema URI segment followed by the camel-cased resource name as a suffix on the Ed-Fi resource URI base value.
        /// </summary>
        /// <param name="resourceName">The name of the resource for which to build the full resource URI.</param>
        /// <returns>The resource URI.</returns>
        private string CreateLegacyResourceClaimUri(string resourceName)
        {
            return $"{EdFiConventions.EdFiOdsResourceClaimBaseUri}/{resourceName.ToCamelCase()}";
        }

        /// <summary>
        /// Gets the resource URI for the supplied resource name, based on convention of the resource's schema URI segment followed by the camel-cased resource name as a suffix on the Ed-Fi resource URI base value.
        /// </summary>
        /// <param name="schemaUriSegment">The schema URI segment to use when creating the claim URI.</param>
        /// <param name="resourceName">The name of the resource for which to build the full resource URI.</param>
        /// <returns>The resource URI.</returns>
        private string CreateSchemaBasedResourceClaimUri(string schemaUriSegment, string resourceName)
        {
            return CreateSegmentedClaimUri(schemaUriSegment, resourceName);
        }

        private static string CreateSegmentedClaimUri(string uriSegment, string resourceName)
        {
            return $"{EdFiConventions.EdFiOdsResourceClaimBaseUri}/{uriSegment}/{resourceName.ToCamelCase()}"; 
        } 
    }
}