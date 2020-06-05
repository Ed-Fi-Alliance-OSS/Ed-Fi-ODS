// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using log4net;

namespace EdFi.Ods.WebService.Tests
{
    [Obsolete("Replaced with OpenApiMetadataCacheProvider.cs to be used with Startup.cs")]
    public class LegacyOpenApiMetadataCacheProvider : IOpenApiMetadataCacheProvider
    {
        private const string Descriptors = "descriptors";
        private const string Resources = "resources";
        private const string Extensions = "extensions";
        private const string Profiles = "profiles";
        private const string Composites = "composites";
        private const string All = "all";
        private const string EdFi = "ed-fi";

        private static readonly string _odsDataBasePath = $"data/v{ApiVersionConstants.Ods}";
        private readonly ICompositesMetadataProvider _compositesMetadataProvider;
        private readonly IDomainModelProvider _domainModelProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(LegacyOpenApiMetadataCacheProvider));
        private readonly IDictionary<string, IOpenApiMetadataResourceStrategy> _openApiMetadataResourceFilters;
        private readonly IOpenApiMetadataRouteProvider _openApiMetadataRouteProvider;
        private readonly IDictionary<string, Func<IEnumerable<OpenApiContent>>> _openApiMetadataSectionByRoute;
        private readonly IProfileResourceModelProvider _profileResourceModelProvider;
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;
        private readonly IResourceModelProvider _resourceModelProvider;
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;

        private readonly IEnumerable<string> _sdkGenSections = new[]
        {
            OpenApiMetadataSections.Composites,
            OpenApiMetadataSections.Profiles,
            OpenApiMetadataSections.Extensions,
            OpenApiMetadataSections.SdkGen,
            OpenApiMetadataSections.Other
        };
        private readonly ConcurrentDictionary<string, OpenApiContent> _swaggerMetadataCache;

        public LegacyOpenApiMetadataCacheProvider(
            IDomainModelProvider domainModelProvider,
            IResourceModelProvider resourceModelProvider,
            IProfileResourceModelProvider profileResourceModelProvider,
            IProfileResourceNamesProvider profileResourceNamesProvider,
            ICompositesMetadataProvider compositesMetadataProvider,
            ISchemaNameMapProvider schemaNameMapProvider,
            IOpenApiMetadataRouteProvider openApiMetadataRouteProvider,
            IOpenApiContentProvider[] openApiContentProviders)
        {
            _domainModelProvider = domainModelProvider;
            _resourceModelProvider = resourceModelProvider;
            _compositesMetadataProvider = compositesMetadataProvider;
            _schemaNameMapProvider = schemaNameMapProvider;
            _openApiMetadataRouteProvider = openApiMetadataRouteProvider;
            _profileResourceModelProvider = profileResourceModelProvider;
            _profileResourceNamesProvider = profileResourceNamesProvider;

            _openApiMetadataResourceFilters =
                new Dictionary<string, IOpenApiMetadataResourceStrategy>(StringComparer.InvariantCultureIgnoreCase)
                {
                    {Descriptors, new SwaggerUiDescriptorOnlyStrategy()},
                    {Resources, new SwaggerUiResourceOnlyStrategy()},
                    {Extensions, new SdkGenExtensionResourceStrategy()},
                    {EdFi, new SdkGenAllEdFiResourceStrategy()},
                    {Profiles, new OpenApiProfileStrategy()},
                    {Composites, new OpenApiCompositeStrategy(_compositesMetadataProvider)},
                    {All, new SdkGenAllResourceStrategy()}
                };

            _openApiMetadataSectionByRoute =
                new Dictionary<string, Func<IEnumerable<OpenApiContent>>>
                {
                    {MetadataRouteConstants.Schema, CreateSchemaSpecificSections},
                    {MetadataRouteConstants.All, CreateSdkGenAllSection},
                    {MetadataRouteConstants.Profiles, CreateProfileSection},
                    {MetadataRouteConstants.Composites, CreateCompositeSection},
                    {MetadataRouteConstants.ResourceTypes, CreateSwaggerUiSection}
                };

            foreach (var openApiContentProvider in openApiContentProviders)
            {
                var routeName = openApiContentProvider.RouteName;

                if (_openApiMetadataSectionByRoute.ContainsKey(routeName))
                {
                    throw new InvalidOperationException(
                        $"Duplicate metadata route '{routeName}' encountered during initialization.  Source: {openApiContentProvider.GetType().FullName}");
                }

                _openApiMetadataSectionByRoute.Add(routeName, openApiContentProvider.GetOpenApiContent);
            }

            _swaggerMetadataCache =
                new ConcurrentDictionary<string, OpenApiContent>(StringComparer.InvariantCultureIgnoreCase);
        }

        public IList<OpenApiContent> GetAllSectionDocuments(bool sdk)
        {
            var sections = _swaggerMetadataCache.Values.Where(
                    c => sdk
                        ? _sdkGenSections.Contains(c.Section)
                        : !c.Section.Equals(
                              OpenApiMetadataSections.SdkGen)
                          && !c.Section.Equals(
                              OpenApiMetadataSections
                                  .Extensions))
                .ToList();

            return sections.Where(x => x.Section.Equals(OpenApiMetadataSections.SwaggerUi))
                .Concat(
                    sections.Where(
                            x =>
                                !x.Section.Equals(OpenApiMetadataSections.SwaggerUi))
                        .OrderBy(x => OpenApiMetadataSections.GetSort(x.Section))
                        .ThenBy(x => x.Name))
                .ToList();
        }

        public OpenApiContent GetOpenApiContentByFeedName(string feedName)
        {
            if (!_swaggerMetadataCache.TryGetValue(feedName, out OpenApiContent document))
            {
                _logger.Warn($"Unable to find OpenApiContent for {feedName}");
            }

            return document;
        }

        public void InitializeCache()
        {
            var sw = new Stopwatch();
            sw.Start();

            _openApiMetadataRouteProvider.GetAllRoutes()
                .ForEach(
                    r =>
                    {
                        string routeName = r.GetDataTokenRouteName();

                        if (_openApiMetadataSectionByRoute.TryGetValue(
                            routeName,
                            out Func<IEnumerable<OpenApiContent>> sectionAction))
                        {
                            AddToCache(sectionAction());
                            _logger.Debug($"Populated the {routeName} sections at {sw.Elapsed:c}");
                        }
                        else
                        {
                            throw new Exception($"Unknown metadata route '{routeName}' encountered during initialization.");
                        }
                    });

            sw.Stop();

            _logger.Debug($"Populated the complete document cache in {sw.Elapsed:c}");
        }

        private void AddToCache(IEnumerable<OpenApiContent> openApiContents)
        {
            foreach (var openApiContent in openApiContents)
            {
                // we want to force an update if the document has changed.
                _swaggerMetadataCache.AddOrUpdate(
                    GetCacheKey(openApiContent),
                    openApiContent,
                    (key, existing) => existing.GetHashCode() != openApiContent.GetHashCode()
                        ? openApiContent
                        : existing);
            }
        }

        private string GetCacheKey(OpenApiContent openApiContent)
        {
            return $"{openApiContent.Section}-{openApiContent.Name}";
        }

        private IEnumerable<OpenApiContent> CreateCompositeSection()
        {
            // composites using tightly coupled extensions
            var resourceFilter = _openApiMetadataResourceFilters
                .FirstOrDefault(x => x.Key.Equals(Composites));

            return _compositesMetadataProvider
                .GetAllCategories()
                .Select(
                    x => new SwaggerCompositeContext
                    {
                        OrganizationCode = x.OrganizationCode,
                        CategoryName = x.Name
                    })
                .Select(
                    x => new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel())
                    {
                        CompositeContext = x
                    })
                .Select(
                    c =>
                        new OpenApiContent(
                            OpenApiMetadataSections.Composites,
                            c.CompositeContext.CategoryName,
                            new Lazy<string>(() => new SwaggerDocumentFactory(c).Create(resourceFilter.Value)),
                            $"{OpenApiMetadataSections.Composites.ToLowerInvariant()}/v{ApiVersionConstants.Composite}",
                            $"{c.CompositeContext.OrganizationCode}/{c.CompositeContext.CategoryName}"));
        }

        private IEnumerable<OpenApiContent> CreateProfileSection()
        {
            // profiles using tightly coupled extensions
            var resourceFilter = _openApiMetadataResourceFilters
                .FirstOrDefault(x => x.Key.Equals(Profiles));

            return _profileResourceNamesProvider
                .GetProfileResourceNames()
                .Select(x => x.ProfileName)
                .Select(
                    x => new SwaggerProfileContext
                    {
                        ProfileName = x,
                        ProfileResourceModel = _profileResourceModelProvider
                            .GetProfileResourceModel(x)
                    })
                .Select(
                    x => new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel())
                    {
                        ProfileContext = x,
                        IsIncludedExtension = r => true
                    })
                .Select(
                    c =>
                        new OpenApiContent(
                            OpenApiMetadataSections.Profiles,
                            c.ProfileContext.ProfileName,
                            new Lazy<string>(() => new SwaggerDocumentFactory(c).Create(resourceFilter.Value)),
                            _odsDataBasePath,
                            $"{OpenApiMetadataSections.Profiles}/{c.ProfileContext.ProfileName}"));
        }

        private IEnumerable<OpenApiContent> CreateSwaggerUiSection()
        {
            // resources, types, descriptors using tightly coupled extensions
            return _openApiMetadataResourceFilters
                .Where(x => x.Key.Equals(Descriptors) || x.Key.Equals(Resources))

                // Force Descriptors first
                .OrderBy(
                    x => x.Key.Equals(Descriptors)
                        ? 1
                        : 2)
                .Select(
                    x =>
                    {
                        return new OpenApiContent(
                            OpenApiMetadataSections.SwaggerUi,
                            x.Key,
                            new Lazy<string>(
                                () => new SwaggerDocumentFactory(
                                    new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel())).Create(x.Value)),
                            _odsDataBasePath);
                    });
        }

        private IEnumerable<OpenApiContent> CreateSdkGenAllSection()
        {
            return new[]
            {
                new OpenApiContent(
                    OpenApiMetadataSections.SdkGen,
                    All,
                    new Lazy<string>(
                        () => new SwaggerDocumentFactory(
                            new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel())
                        ).Create(_openApiMetadataResourceFilters[All])),
                    _odsDataBasePath,
                    string.Empty)
            };
        }

        private IEnumerable<OpenApiContent> CreateSchemaSpecificSections()
        {
            return new[]
            {
                new OpenApiContent(
                    OpenApiMetadataSections.SdkGen,
                    EdFi,
                    new Lazy<string>(
                        () =>
                            new SwaggerDocumentFactory(
                                new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel())
                                {
                                    RenderType = RenderType.GeneralizedExtensions,
                                    IsIncludedExtension = x => x.FullName.Schema.Equals(EdFiConventions.PhysicalSchemaName)
                                }).Create(_openApiMetadataResourceFilters[EdFi])),
                    _odsDataBasePath)
            }.Concat(
                _domainModelProvider.GetDomainModel()

                    // All the extension schemas.
                    .Schemas.Where(
                        x => !x.LogicalName.EqualsIgnoreCase(EdFiConventions.LogicalName))
                    .Select(
                        schema =>
                            new
                            {
                                UriSegment = _schemaNameMapProvider.GetSchemaMapByLogicalName(schema.LogicalName)
                                    .UriSegment,
                                Factory =
                                    SwaggerDocumentFactoryHelper.GetExtensionOnlySwaggerDocumentFactory(
                                        _resourceModelProvider.GetResourceModel(),
                                        schema)
                            })
                    .Select(
                        sf =>
                            new OpenApiContent(
                                OpenApiMetadataSections.Extensions,
                                sf.UriSegment,
                                new Lazy<string>(() => sf.Factory.Create(_openApiMetadataResourceFilters[Extensions])),
                                _odsDataBasePath))
            );
        }
    }
}
