// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Metadata.StreamProviders.Composites;
using FluentValidation.Results;
using log4net;

namespace EdFi.Ods.Common.Metadata.Composites;

public class CompositesMetadataProvider : ICompositesMetadataProvider
{
    private readonly ICompositesMetadataStreamsProvider[] _compositeMetadataStreamsProviders;
    private readonly Lazy<IReadOnlyList<XDocument>> _allDocs;
    private readonly Lazy<IReadOnlyList<CompositeCategory>> _compositeCategories;
    private readonly Lazy<IDictionary<CompositeCategory, IEnumerable<Composite>>> _compositesByCompositeCategory;
    private readonly Lazy<IDictionary<CompositeCategory, IReadOnlyList<XElement>>> _routeDefinitionsByCompositeCategory;

    private readonly ILog _logger = LogManager.GetLogger(typeof(CompositesMetadataProvider));
    
    public CompositesMetadataProvider(ICompositesMetadataStreamsProvider[] compositeMetadataStreamsProviders)
    {
        _compositeMetadataStreamsProviders = compositeMetadataStreamsProviders;
            
        _allDocs = new Lazy<IReadOnlyList<XDocument>>(LazyInitializeXDocuments);

        _compositeCategories = new Lazy<IReadOnlyList<CompositeCategory>>(LazyInitializeCompositeCategories);

        _compositesByCompositeCategory = new Lazy<IDictionary<CompositeCategory, IEnumerable<Composite>>>(LazyInitializeComposites);

        _routeDefinitionsByCompositeCategory = new Lazy<IDictionary<CompositeCategory, IReadOnlyList<XElement>>>(LazyInitializeCompositeRoutes);
    }

    private readonly ConcurrentDictionary<(string name, string source), ValidationResult> _validationResultsByMetadataStream = new();

    /// <inheritdoc cref="IProfileMetadataProvider.GetValidationResults" />
    public MetadataValidationResult[] GetValidationResults()
        => _validationResultsByMetadataStream
            .Select(kvp => new MetadataValidationResult(kvp.Key.name, kvp.Key.source, kvp.Value))
            .ToArray();

    private XDocument[] LazyInitializeXDocuments()
    {
        return _compositeMetadataStreamsProviders
            .SelectMany(p => p.GetStreams())
            .Select(
                s =>
                {
                    using var reader = new StreamReader(s.Stream);
                    var metadataXDoc = XDocument.Load(reader);

                    var validator = new CompositeMetadataValidator();
                    var validationResult = validator.Validate(metadataXDoc);

                    _validationResultsByMetadataStream.AddOrUpdate(
                        (s.Name, s.Source),
                        validationResult,
                        (key, existingResult) => validationResult); 

                    if (validationResult.IsValid)
                    {
                        return metadataXDoc;
                    }

                    _logger.Error($"Composites schema validation failed: {validationResult}");
                    
                    return null;
                })
            .Where(d => d != null)
            .ToArray();
    }

    /// <summary>
    /// Gets a list of names of all the composite categories available.
    /// </summary>
    /// <returns>A list of composite category names.</returns>
    public IReadOnlyList<CompositeCategory> GetAllCategories()
    {
        return _compositeCategories.Value;
    }

    /// <summary>
    /// Attempts to retrieve all the composite definitions for a composite category by name.
    /// </summary>
    /// <param name="organizationCode">The name of the composite organization code.</param>
    /// <param name="compositeCategoryName">The name of the composite category.</param>
    /// <param name="compositeDefinitions">Upon return, contains the list of composite definitions <see cref="XElement"/>, if found.</param>
    /// <returns><b>true</b> if found; otherwise <b>false</b>.</returns>
    public bool TryGetCompositeDefinitions(
        string organizationCode,
        string compositeCategoryName,
        out IReadOnlyList<XElement> compositeDefinitions)
    {
        compositeDefinitions = null;

        var compositeCategory = new CompositeCategory(organizationCode, compositeCategoryName);

        IEnumerable<Composite> composites;

        if (!_compositesByCompositeCategory.Value.TryGetValue(compositeCategory, out composites))
        {
            return false;
        }

        compositeDefinitions = composites
            .Select(c => c.Definition)
            .ToList();

        return true;
    }

    /// <summary>
    /// Attempts to retrieve a specific composite definition by composite category and name.
    /// </summary>
    /// <param name="organizationCode">A code representing the organization that created the composite definition.</param>
    /// <param name="compositeCategoryName">The name of the composite category.</param>
    /// <param name="compositeName">The name of the composite.</param>
    /// <param name="compositeDefinition">Upon return, contains the composite definition <see cref="XElement"/>, if found.</param>
    /// <returns><b>true</b> if found; otherwise <b>false</b>.</returns>
    public bool TryGetCompositeDefinition(
        string organizationCode,
        string compositeCategoryName,
        string compositeName,
        out XElement compositeDefinition)
    {
        compositeDefinition = null;

        var compositeCategory = new CompositeCategory(organizationCode, compositeCategoryName);

        IEnumerable<Composite> composites;

        if (!_compositesByCompositeCategory.Value.TryGetValue(compositeCategory, out composites))
        {
            return false;
        }

        compositeDefinition = composites
            ?.FirstOrDefault(c => c.Name.EqualsIgnoreCase(compositeName))
            ?.Definition;

        return compositeDefinition != null;
    }

    /// <summary>
    /// Gets lists of composite metadata route definitions grouped by composite category name.
    /// </summary>
    /// <returns></returns>
    public IReadOnlyDictionary<CompositeCategory, IReadOnlyList<XElement>> GetAllRoutes()
    {
        return new ReadOnlyDictionary<CompositeCategory, IReadOnlyList<XElement>>(_routeDefinitionsByCompositeCategory.Value);
    }

    /// <summary>
    /// Gets lists of composite metadata route definitions grouped by composite category name.
    /// </summary>
    /// <returns></returns>
    public bool TryGetRoutes(string organizationCode, string categoryName, out IReadOnlyList<XElement> routeDefinitions)
    {
        return _routeDefinitionsByCompositeCategory.Value.TryGetValue(
            new CompositeCategory(organizationCode, categoryName),
            out routeDefinitions);
    }

    private IReadOnlyList<CompositeCategory> LazyInitializeCompositeCategories()
    {
        return
            (from doc in _allDocs.Value
                let organizationCode = doc.XPathSelectElement("CompositeMetadata")
                        .AttributeValue("organizationCode")
                    ?? EdFiConventions.OrganizationCode
                from category in doc.XPathSelectElements("CompositeMetadata/Category")
                select new CompositeCategory(
                    organizationCode,
                    category.AttributeValue("name"),
                    category.AttributeValue("displayName"))).ToList();
    }

    private IDictionary<CompositeCategory, IEnumerable<Composite>> LazyInitializeComposites()
    {
        return
            (from doc in _allDocs.Value
                let organizationCode = doc.XPathSelectElement("CompositeMetadata")
                        .AttributeValue("organizationCode")
                    ?? EdFiConventions.OrganizationCode
                from category in doc.XPathSelectElements("CompositeMetadata/Category")
                let categoryName = category.AttributeValue("name")
                let categoryDisplayName = category.AttributeValue("displayName")
                let composites = category.XPathSelectElements("Composites/Composite")
                select new
                {
                    CompositeCategory = new CompositeCategory(organizationCode, categoryName, categoryDisplayName), Composites =
                        composites.Select(
                            c => new Composite
                            {
                                Name = c.AttributeValue("name"), Definition = c
                            })
                })
            .ToDictionary(k => k.CompositeCategory, v => v.Composites, new CompositeCategoryEqualityComparer());
    }

    private IDictionary<CompositeCategory, IReadOnlyList<XElement>> LazyInitializeCompositeRoutes()
    {
        return (from doc in _allDocs.Value
                let organizationCode = doc.XPathSelectElement("CompositeMetadata")
                        .AttributeValue("organizationCode")
                    ?? EdFiConventions.OrganizationCode
                from category in doc.XPathSelectElements("CompositeMetadata/Category")
                let categoryName = category.AttributeValue("name")
                let categoryDisplayName = category.AttributeValue("displayName")
                let routes = category.XPathSelectElements("Routes/Route")
                select new
                {
                    CompositeCategory = new CompositeCategory(organizationCode, categoryName, categoryDisplayName),
                    RouteDefinitions = routes
                })
            .ToDictionary(k => k.CompositeCategory, v => v.RouteDefinitions.ToReadOnlyList(), new CompositeCategoryEqualityComparer());
    }
}