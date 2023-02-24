// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;
using EdFi.Ods.Features.Profiles;
using log4net;
using MediatR;
using OpenApiMetadataSections = EdFi.Ods.Api.Constants.OpenApiMetadataSections;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers
{
    public class OpenApiMetadataCacheProvider : IOpenApiMetadataCacheProvider, INotificationHandler<ProfileMetadataCacheExpired>
    {
        private const string Descriptors = "descriptors";
        private const string Resources = "resources";
        private const string All = "all";

        private static readonly string _odsDataBasePath = $"data/v{ApiVersionConstants.Ods}";

        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataCacheProvider));
        private readonly IList<IOpenApiContentProvider> _openApiContentProviders;
        private readonly IDictionary<string, IOpenApiMetadataResourceStrategy> _openApiMetadataResourceFilters;
        private readonly IList<IOpenApiMetadataRouteInformation> _openApiMetadataRouteInformations;
        private readonly IOpenApiMetadataDocumentFactory _openApiMetadataDocumentFactory;

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
        
        private Lazy<ConcurrentDictionary<string, OpenApiContent>> _openApiMetadataMetadataCache;

        public OpenApiMetadataCacheProvider(
            IResourceModelProvider resourceModelProvider,
            IList<IOpenApiMetadataRouteInformation> openApiMetadataRouteInformations,
            IList<IOpenApiContentProvider> openApiContentProviders,
            IOpenApiMetadataDocumentFactory openApiMetadataDocumentFactory)
        {
            _openApiMetadataRouteInformations = openApiMetadataRouteInformations;
            _openApiContentProviders = openApiContentProviders;
            _resourceModelProvider = resourceModelProvider;

            _openApiMetadataResourceFilters =
                new Dictionary<string, IOpenApiMetadataResourceStrategy>(StringComparer.InvariantCultureIgnoreCase)
                {
                    {Descriptors, new OpenApiMetadataUiDescriptorOnlyStrategy()},
                    {Resources, new OpenApiMetadataUiResourceOnlyStrategy()},
                    {All, new SdkGenAllResourceStrategy()}
                };

            _openApiMetadataMetadataCache = new Lazy<ConcurrentDictionary<string, OpenApiContent>>(LazyInitializeCache);

            _openApiMetadataDocumentFactory = openApiMetadataDocumentFactory;
        }

        public IList<OpenApiContent> GetAllSectionDocuments(bool sdk)
        {
            var sections = _openApiMetadataMetadataCache.Value.Values
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
            if (!_openApiMetadataMetadataCache.Value.TryGetValue(feedName, out OpenApiContent document))
            {
                _logger.Warn($"Unable to find OpenApiContent for {feedName}");
            }

            return document;
        }

        public void ResetCacheInitialization()
        {
            // Reset the underlying cache
            _openApiMetadataMetadataCache = new Lazy<ConcurrentDictionary<string, OpenApiContent>>(LazyInitializeCache);
        }
        
        private ConcurrentDictionary<string, OpenApiContent> LazyInitializeCache()
        {
            var sw = new Stopwatch();
            sw.Start();

            var newCache = new ConcurrentDictionary<string, OpenApiContent>();
            
            foreach (IOpenApiMetadataRouteInformation openApiMetadataRouteInformation in _openApiMetadataRouteInformations)
            {
                var routeInformation = openApiMetadataRouteInformation.GetRouteInformation();

                if (routeInformation.Name.EqualsIgnoreCase(MetadataRouteConstants.All))
                {
                    AddToCache(CreateSdkGenAllSection());
                }
                else if (routeInformation.Name.EqualsIgnoreCase(MetadataRouteConstants.ResourceTypes))
                {
                    AddToCache(CreateOpenApiMetadataUiSection());
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

            return newCache;
            
            IEnumerable<OpenApiContent> CreateOpenApiMetadataUiSection()
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
                                    _openApiMetadataDocumentFactory
                                        .Create(
                                            x.Value,
                                            new OpenApiMetadataDocumentContext(_resourceModelProvider.GetResourceModel()))),
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
                                _openApiMetadataDocumentFactory
                                    .Create(
                                        _openApiMetadataResourceFilters[All],
                                        new OpenApiMetadataDocumentContext(_resourceModelProvider.GetResourceModel()))),
                        _odsDataBasePath,
                        string.Empty)
                };

            void AddToCache(IEnumerable<OpenApiContent> openApiContents)
            {
                foreach (var openApiContent in openApiContents)
                {
                    // we want to force an update if the document has changed.
                    newCache.AddOrUpdate(
                        $"{openApiContent.Section}-{openApiContent.Name}",
                        openApiContent,
                        (key, existing) => existing.GetHashCode() != openApiContent.GetHashCode()
                            ? openApiContent
                            : existing);
                }
            }
        }

        public Task Handle(ProfileMetadataCacheExpired notification, CancellationToken cancellationToken)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug("Resetting OpenApiMetadata initialization due to profile metadata cache expiration...");
            }

            ResetCacheInitialization();

            return Task.CompletedTask;
        }
    }
}