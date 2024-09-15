// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Api.Security.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization
{
    /// <summary>
    /// Provides methods for building resource claim URIs for authorization purposes.
    /// </summary>
    public class ResourceClaimUriProvider : IResourceClaimUriProvider
    {
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;
        private readonly ConcurrentDictionary<Type, string[]> _resourceUrisByResourceType = new();
        private readonly ConcurrentDictionary<FullName, string[]> _resourceUrisByResourceFullName = new();
        private readonly Lazy<ConcurrentDictionary<string, FullName>> _resourceFullNameByResourceUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceClaimUriProvider" /> class using the supplied schema name map provider.
        /// </summary>
        /// <param name="schemaNameMapProvider">The provider for mapping between schema names.</param>
        /// <param name="resourceModelProvider"></param>
        public ResourceClaimUriProvider(ISchemaNameMapProvider schemaNameMapProvider, IResourceModelProvider resourceModelProvider)
        {
            ArgumentNullException.ThrowIfNull(schemaNameMapProvider, nameof(schemaNameMapProvider));
            _schemaNameMapProvider = schemaNameMapProvider;

            _resourceFullNameByResourceUri = new Lazy<ConcurrentDictionary<string, FullName>>(
                () =>
                {
                    var resourceFullNameByResourceUri = new ConcurrentDictionary<string, FullName>();

                    foreach (var resource in resourceModelProvider.GetResourceModel().GetAllResources())
                    {
                        resourceFullNameByResourceUri.TryAdd(
                            CreateSchemaBasedResourceClaimUri(resource.SchemaUriSegment(), resource.Name),
                            resource.FullName);

                        // Add legacy representation for Ed-Fi Standard resources
                        if (resource.FullName.Schema == EdFiConventions.PhysicalSchemaName)
                        {
                            resourceFullNameByResourceUri.TryAdd(CreateLegacyResourceClaimUri(resource.Name), resource.FullName);
                        }
                    }

                    return resourceFullNameByResourceUri;
                });
        }

        /// <summary>
        /// Gets the resource URIs for the specified resource Type using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="resourceType">The resource Type for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        public string[] GetResourceClaimUris(Type resourceType)
        {
            ArgumentNullException.ThrowIfNull(resourceType, nameof(resourceType));

            return _resourceUrisByResourceType.GetOrAdd(
                resourceType,
                (t, args) =>
                {
                    var (schemaNameMapProvider, resourceUrisByResourceFullName) = args;
                    
                    string schemaProperCaseName = t.ParseResourceSchemaProperCaseName();
                    string resourceName = t.Name;

                    var schemaNameMap = schemaNameMapProvider.GetSchemaMapByProperCaseName(schemaProperCaseName);

                    // Include legacy representation for Ed-Fi Standard resources only
                    var uris = (schemaNameMap.PhysicalName == EdFiConventions.PhysicalSchemaName)
                        ? new[]
                        {
                            // Schema-based URI format
                            CreateSchemaBasedResourceClaimUri(schemaNameMap.UriSegment, resourceName),

                            // Legacy URI format
                            CreateLegacyResourceClaimUri(resourceName),
                        }
                        : new[]
                        {
                            // Schema-based URI format
                            CreateSchemaBasedResourceClaimUri(schemaNameMap.UriSegment, resourceName),
                        };

                    // Opportunistic assignment to map keyed by resource full name
                    resourceUrisByResourceFullName.TryAdd(new FullName(schemaNameMap.PhysicalName, resourceName), uris);

                    return uris;
                },
                (_schemaNameMapProvider, _resourceUrisByResourceFullName));
        }

        /// <summary>
        /// Gets the resource URIs for the specified entity class using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="entity">The <see cref="EdFi.Ods.Common.Models.Domain.Entity" /> for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        public string[] GetResourceClaimUris(Entity entity)
        {
            return GetResourceClaimUris(entity.FullName, entity.SchemaUriSegment());
        }

        /// <summary>
        /// Gets the resource URIs for the specified Resource class using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="resource">The <see cref="EdFi.Ods.Common.Models.Resource.Resource" /> for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        public string[] GetResourceClaimUris(Resource resource)
        {
            return GetResourceClaimUris(resource.FullName, resource.SchemaUriSegment());
        }

        /// <summary>
        /// Gets the resource URIs for the specified Resource class using Ed-Fi schema-based and legacy URI conventions.
        /// </summary>
        /// <param name="fullName">The <see cref="FullName" /> of the <see cref="EdFi.Ods.Common.Models.Resource.Resource" /> for which to build the resource URIs.</param>
        /// <returns>The resource claim URIs.</returns>
        private string[] GetResourceClaimUris(FullName fullName, string schemaUriSegment)
        {
            return _resourceUrisByResourceFullName.GetOrAdd(
                fullName,
                static (fn, segment) =>
                {
                    // Include legacy representation for Ed-Fi Standard resources only
                    return (fn.Schema == EdFiConventions.PhysicalSchemaName)
                        ? new[]
                        {
                            // Schema-based URI format
                            CreateSchemaBasedResourceClaimUri(segment, fn.Name),

                            // Legacy URI format
                            CreateLegacyResourceClaimUri(fn.Name),
                        }
                        : new[]
                        {
                            // Schema-based URI format
                            CreateSchemaBasedResourceClaimUri(segment, fn.Name),
                        };
                },
                schemaUriSegment);
        }

        public FullName GetResourceFullName(string[] resourceClaimUris)
        {
            ArgumentNullException.ThrowIfNull(resourceClaimUris, nameof(resourceClaimUris));

            foreach (string resourceClaimUri in resourceClaimUris)
            {
                if (_resourceFullNameByResourceUri.Value.TryGetValue(resourceClaimUri, out var resourceName))
                {
                    return resourceName;
                }
            }

            throw new Exception($"Unable to identify resource from supplied '{nameof(resourceClaimUris)}' argument.");
        }

        /// <summary>
        /// Gets the resource URI for the supplied resource name, based on convention of the resource's schema URI segment followed by the camel-cased resource name as a suffix on the Ed-Fi resource URI base value.
        /// </summary>
        /// <param name="resourceName">The name of the resource for which to build the full resource URI.</param>
        /// <returns>The resource URI.</returns>
        private static string CreateLegacyResourceClaimUri(string resourceName)
        {
            return $"{EdFiConventions.EdFiOdsResourceClaimBaseUri}/{resourceName.ToCamelCase()}";
        }

        /// <summary>
        /// Gets the resource URI for the supplied resource name, based on convention of the resource's schema URI segment followed by the camel-cased resource name as a suffix on the Ed-Fi resource URI base value.
        /// </summary>
        /// <param name="schemaUriSegment">The schema URI segment to use when creating the claim URI.</param>
        /// <param name="resourceName">The name of the resource for which to build the full resource URI.</param>
        /// <returns>The resource URI.</returns>
        private static string CreateSchemaBasedResourceClaimUri(string schemaUriSegment, string resourceName)
        {
            return CreateSegmentedClaimUri(schemaUriSegment, resourceName);
        }

        private static string CreateSegmentedClaimUri(string uriSegment, string resourceName)
        {
            return $"{EdFiConventions.EdFiOdsResourceClaimBaseUri}/{uriSegment}/{resourceName.ToCamelCase()}";
        }
    }
}