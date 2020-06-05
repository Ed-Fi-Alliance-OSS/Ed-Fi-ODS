// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.NetCore.Routing;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using log4net;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers
{
    public class OpenApiMetadataCacheProvider : IOpenApiMetadataCacheProvider
    {
        private const string Descriptors = "descriptors";
        private const string Resources = "resources";
        private const string All = "all";

        private static readonly string _odsDataBasePath = $"data/v{ApiVersionConstants.Ods}";

        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataCacheProvider));
        private readonly IList<IOpenApiContentProvider> _openApiContentProviders;
        private readonly IDictionary<string, IOpenApiMetadataResourceStrategy> _openApiMetadataResourceFilters;
        private readonly IList<IOpenApiMetadataRouteInformation> _openApiMetadataRouteInformations;

        // private readonly IOpenApiMetadataRouteProvider _openApiMetadataRouteProvider;
        private readonly IResourceModelProvider _resourceModelProvider;

        private readonly IEnumerable<string> _sdkGenSections = new[]
        {
            OpenApiMetadataSections.Composites,
            OpenApiMetadataSections.Profiles,
            OpenApiMetadataSections.Extensions,
            OpenApiMetadataSections.SdkGen,
            OpenApiMetadataSections.Other
        };
        private readonly ConcurrentDictionary<string, OpenApiContent> _swaggerMetadataCache;

        public OpenApiMetadataCacheProvider(
            IResourceModelProvider resourceModelProvider,
            IList<IOpenApiMetadataRouteInformation> openApiMetadataRouteInformations,
            IList<IOpenApiContentProvider> openApiContentProviders)
        {
            _openApiMetadataRouteInformations = openApiMetadataRouteInformations;
            _openApiContentProviders = openApiContentProviders;
            _resourceModelProvider = resourceModelProvider;

            _openApiMetadataResourceFilters =
                new Dictionary<string, IOpenApiMetadataResourceStrategy>(StringComparer.InvariantCultureIgnoreCase)
                {
                    {Descriptors, new SwaggerUiDescriptorOnlyStrategy()},
                    {Resources, new SwaggerUiResourceOnlyStrategy()},
                    {All, new SdkGenAllResourceStrategy()}
                };

            _swaggerMetadataCache = new ConcurrentDictionary<string, OpenApiContent>(StringComparer.InvariantCultureIgnoreCase);
        }

        public IList<OpenApiContent> GetAllSectionDocuments(bool sdk)
        {
            var sections = _swaggerMetadataCache.Values
                .Where(
                    c => sdk
                        ? _sdkGenSections.Contains(c.Section)
                        : !c.Section.Equals(OpenApiMetadataSections.SdkGen) &&
                          !c.Section.Equals(OpenApiMetadataSections.Extensions))
                .ToList();

            return sections.Where(x => x.Section.Equals(OpenApiMetadataSections.SwaggerUi))
                .Concat(
                    sections
                        .Where(x => !x.Section.Equals(OpenApiMetadataSections.SwaggerUi))
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

            foreach (IOpenApiMetadataRouteInformation openApiMetadataRouteInformation in _openApiMetadataRouteInformations)
            {
                var routeInformation = openApiMetadataRouteInformation.GetRouteInformation();

                if (routeInformation.Name.EqualsIgnoreCase(MetadataRouteConstants.All))
                {
                    AddToCache(CreateSdkGenAllSection());
                }
                else if (routeInformation.Name.EqualsIgnoreCase(MetadataRouteConstants.ResourceTypes))
                {
                    AddToCache(CreateSwaggerUiSection());
                }
                else
                {
                    foreach (IGrouping<string, IOpenApiContentProvider> apiContentProvidersByRouteName in
                        _openApiContentProviders.GroupBy(g => g.RouteName.ToLowerInvariant()))
                    {
                        foreach (IOpenApiContentProvider openApiContentProvider in apiContentProvidersByRouteName)
                        {
                            AddToCache(openApiContentProvider.GetOpenApiContent());
                        }
                    }
                }

                _logger.Debug($"Populated the {routeInformation.Name} sections at {sw.Elapsed:c}");
            }

            sw.Stop();

            _logger.Debug($"Populated the complete document cache in {sw.Elapsed:c}");

            IEnumerable<OpenApiContent> CreateSwaggerUiSection()
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
                        x => new OpenApiContent(
                            OpenApiMetadataSections.SwaggerUi,
                            x.Key,
                            new Lazy<string>(
                                () =>
                                    new SwaggerDocumentFactory(
                                            new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel()))
                                        .Create(x.Value)),
                            _odsDataBasePath));
            }

            IEnumerable<OpenApiContent> CreateSdkGenAllSection()
                => new[]
                {
                    new OpenApiContent(
                        OpenApiMetadataSections.SdkGen,
                        All,
                        new Lazy<string>(
                            () =>
                                new SwaggerDocumentFactory(
                                        new SwaggerDocumentContext(_resourceModelProvider.GetResourceModel()))
                                    .Create(_openApiMetadataResourceFilters[All])),
                        _odsDataBasePath,
                        string.Empty)
                };

            void AddToCache(IEnumerable<OpenApiContent> openApiContents)
            {
                foreach (var openApiContent in openApiContents)
                {
                    // we want to force an update if the document has changed.
                    _swaggerMetadataCache
                        .AddOrUpdate(
                            $"{openApiContent.Section}-{openApiContent.Name}",
                            openApiContent,
                            (key, existing) => existing.GetHashCode() != openApiContent.GetHashCode()
                                ? openApiContent
                                : existing);
                }
            }
        }
    }
}
#endif
