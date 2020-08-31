// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Metadata
{
    public interface ICompositesMetadataProvider
    {
        bool TryGetCompositeDefinition(string organizationCode, string compositeCategoryName, string compositeName, out XElement compositeDefinition);

        /// <summary>
        /// Gets lists of composite metadata route definitions grouped by composite category name.
        /// </summary>
        /// <returns></returns>
        IReadOnlyDictionary<CompositeCategory, IReadOnlyList<XElement>> GetAllRoutes();

        /// <summary>
        /// Gets a list of names of all the composite categories available.
        /// </summary>
        /// <returns>A list of composite category names.</returns>
        IReadOnlyList<CompositeCategory> GetAllCategories();

        /// <summary>
        /// Attempts to retrieve all the composite definitions for a composite category by name.
        /// </summary>
        /// <param name="organizationCode">A code representing the organization that created the composite definition.</param>
        /// <param name="compositeCategoryName">The name of the composite category.</param>
        /// <param name="compositeDefinitions">Upon return, contains the list of composite definitions <see cref="XElement"/>, if found.</param>
        /// <returns><b>true</b> if found; otherwise <b>false</b>.</returns>
        bool TryGetCompositeDefinitions(
            string organizationCode,
            string compositeCategoryName,
            out IReadOnlyList<XElement> compositeDefinitions);

        /// <summary>
        /// Gets lists of composite metadata route definitions grouped by composite category name.
        /// </summary>
        /// <returns></returns>
        bool TryGetRoutes(string organizationCode, string categoryName, out IReadOnlyList<XElement> routeDefinitions);
    }

    public class CompositesMetadataProvider : MetadataDocumentProviderBase, ICompositesMetadataProvider
    {
        private const string ValidationSchemaResourceName =
            @"EdFi.Ods.Common.Metadata.Schemas.Ed-Fi-ODS-API-Composites.xsd";
        private readonly Lazy<IReadOnlyList<XDocument>> _allDocs;
        private readonly Lazy<IReadOnlyList<CompositeCategory>> _compositeCategories;
        private readonly Lazy<IDictionary<CompositeCategory, IEnumerable<Composite>>> _compositesByCompositeCategory;
        private readonly Lazy<IDictionary<CompositeCategory, IReadOnlyList<XElement>>> _routeDefinitionsByCompositeCategory;

        public CompositesMetadataProvider()
        {
            _allDocs = new Lazy<IReadOnlyList<XDocument>>(() => GetAllMetadataDocumentsInAppDomain(IsCompositesAssembly, "Composites.xml"));

            _compositeCategories = new Lazy<IReadOnlyList<CompositeCategory>>(LazyInitializeCompositeCategories);

            _compositesByCompositeCategory = new Lazy<IDictionary<CompositeCategory, IEnumerable<Composite>>>(LazyInitializeComposites);

            _routeDefinitionsByCompositeCategory = new Lazy<IDictionary<CompositeCategory, IReadOnlyList<XElement>>>(LazyInitializeCompositeRoutes);
        }

        public CompositesMetadataProvider(XDocument compositeMetadata)
        {
            _allDocs = new Lazy<IReadOnlyList<XDocument>>(
                () => new[]
                      {
                          compositeMetadata
                      });

            _compositeCategories = new Lazy<IReadOnlyList<CompositeCategory>>(LazyInitializeCompositeCategories);

            _compositesByCompositeCategory = new Lazy<IDictionary<CompositeCategory, IEnumerable<Composite>>>(LazyInitializeComposites);

            _routeDefinitionsByCompositeCategory = new Lazy<IDictionary<CompositeCategory, IReadOnlyList<XElement>>>(LazyInitializeCompositeRoutes);
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

        private static bool IsCompositesAssembly(Assembly assembly)
        {
            return assembly.FullName.StartsWithIgnoreCase("EdFi.Ods.Composites"); // TODO: Embedded convention
        }
    }

    public class CompositeCategoryEqualityComparer : IEqualityComparer<CompositeCategory>
    {
        public bool Equals(CompositeCategory x, CompositeCategory y)
        {
            return x.Name.EqualsIgnoreCase(y.Name) && x.OrganizationCode.EqualsIgnoreCase(y.OrganizationCode);
        }

        public int GetHashCode(CompositeCategory obj)
        {
            int hash = 17;

            unchecked
            {
                hash = hash * 23 + obj.Name.ToLower()
                                      .GetHashCode();

                hash = hash * 23 + obj.OrganizationCode.ToLower()
                                      .GetHashCode();

                return hash;
            }
        }
    }

    public class CompositeCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CompositeCategory"/> class.
        /// </summary>
        public CompositeCategory(string organizationCode, string name, string displayName)
        {
            OrganizationCode = organizationCode;
            Name = name;
            DisplayName = displayName;
        }

        public CompositeCategory(string organizationCode, string name)
        {
            OrganizationCode = organizationCode;
            Name = name;
        }

        public string OrganizationCode { get; }

        public string Name { get; }

        public string DisplayName { get; }
    }

    public class Composite
    {
        public string Name { get; set; }

        public XElement Definition { get; set; }
    }
}
