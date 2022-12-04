// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Xml.Linq;
using System.Xml.XPath;

namespace EdFi.Ods.Common.Models.Resource
{
    public class FilterContext
    {
        public static readonly FilterContext NullFilterContext = new();
        private readonly IResourceMembersFilterProvider _filterProvider;

        private FilterContext() { }

        public FilterContext(IResourceMembersFilterProvider filterProvider, XElement definition, ResourceClassBase unfilteredResourceClass)
        {
            if (filterProvider == null)
            {
                throw new ArgumentNullException(nameof(filterProvider));
            }

            _filterProvider = filterProvider;

            UnfilteredResourceClass = unfilteredResourceClass;

            Definition = definition;
        }

        public XElement Definition { get; }

        /// <summary>
        /// Gets the underlying, unfiltered resource class to which the filter is to be applied.
        /// </summary>
        public ResourceClassBase UnfilteredResourceClass { get; }

        public IMemberFilter MemberFilter
        {
            get
            {
                if (_filterProvider == null)
                {
                    return IncludeAllMemberFilter.Instance;
                }

                return _filterProvider.GetMemberFilter(UnfilteredResourceClass, Definition);
            }
        }

        public FilterContext GetExtensionContext(string properCaseName)
        {
            // Supports the NullFilterContext usage
            if (_filterProvider == null)
            {
                return this;
            }

            ISchemaNameMapProvider schemaNameMapProvider = UnfilteredResourceClass.ResourceModel.SchemaNameMapProvider;

            if (schemaNameMapProvider == null)
            {
                return this;
            }

            var logicalName = schemaNameMapProvider.GetSchemaMapByProperCaseName(properCaseName).LogicalName;

            var extensionDefinition = Definition.XPathSelectElement(
                $"Extension[@name='{logicalName}']");

            if (extensionDefinition == null)
            {
                return null;
            }

            if (!UnfilteredResourceClass.ExtensionByName.TryGetValue(properCaseName, out Extension extensionMember))
            {
                throw new Exception(
                    $"Unable to find extension '{properCaseName}' of resource class '{UnfilteredResourceClass.Name}'.");
            }

            return new FilterContext(_filterProvider, extensionDefinition, extensionMember.ObjectType);
        }

        public FilterContext GetChildContext(string childMemberName)
        {
            // Supports the NullFilterContext usage
            if (_filterProvider == null)
            {
                return this;
            }

            // Modified XPath expression to exclude the newly added "Extension" element
            var memberDefinition = Definition.XPathSelectElement(
                $"*[not(self::Extension)][@name='{childMemberName}']");

            if (memberDefinition == null)
            {
                return null;
            }

            if (!UnfilteredResourceClass.MemberByName.TryGetValue(childMemberName, out ResourceMemberBase childResourceMember))
            {
                throw new Exception(
                    $"Unable to find member '{childMemberName}' of resource class '{UnfilteredResourceClass.Name}'.");
            }

            ResourceClassBase childResourceClass;

            var collectionMember = childResourceMember as Collection;

            if (collectionMember != null)
            {
                childResourceClass = collectionMember.ItemType;
            }
            else
            {
                var embeddedObjectMember = childResourceMember as EmbeddedObject;

                if (embeddedObjectMember != null)
                {
                    childResourceClass = embeddedObjectMember.ObjectType;
                }
                else
                {
                    throw new NotSupportedException(
                        string.Format(
                            "Unsupported child member type '{0}' encountered while attempting to create a child member filtering context.",
                            childResourceMember.GetType()));
                }
            }

            return new FilterContext(_filterProvider, memberDefinition, childResourceClass);
        }
    }
}
