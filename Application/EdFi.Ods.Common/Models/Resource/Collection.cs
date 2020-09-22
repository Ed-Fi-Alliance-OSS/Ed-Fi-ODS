// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public class Collection : ResourceMemberBase
    {
        internal Collection(ResourceClassBase resourceClass, AssociationView association, FilterContext filterContext)
            : base(resourceClass, association.Name)
        {
            Association = association;
            FilterContext = filterContext ?? FilterContext.NullFilterContext;

            ItemType = new ResourceChildItem(resourceClass.ResourceModel, association.OtherEntity, FilterContext, resourceClass);

            if (FilterContext.Definition != null)
            {
                // Make sure the XML element matches what we are expecting
                if (FilterContext.Definition.Name != "Collection")
                {
                    throw new ArgumentException(
                        string.Format(
                            "The filter context definition XML element reference was a '{0}' element rather than the expected 'Collection' element.",
                            FilterContext.Definition.Name));
                }

                var filterElt = FilterContext.Definition.Element("Filter");

                if (filterElt != null)
                {
                    ValueFilters = new[]
                                   {
                                       new CollectionItemValueFilter(filterElt)
                                   };
                }
                else
                {
                    ValueFilters = new CollectionItemValueFilter[0];
                }
            }
        }

        internal Collection(Collection[] collections)
            : base(
                collections.Select(c => c.ResourceClass)
                           .FirstOrDefault(), // TODO: These won't be the same, ever.  Seems like we should just pass the ResourceModel.
                collections.Select(c => c.Association.Name)
                           .FirstOrDefault())

        // No need to pass on a filter because the composite already consists of filtered collections
        {
            // Make sure all the collections are truly derived from the same association
            ValidateCompositeCollectionArguments(collections);

            Association = collections.Select(c => c.Association)
                                     .FirstOrDefault();

            ItemType = new ResourceChildItem(
                collections.Select(c => c.ItemType)
                           .ToArray(),
                ResourceClass);

            // Combine all the value filters from all the composed collections.
            ValueFilters = collections.SelectMany(c => c.ValueFilters)
                                      .ToArray();
        }

        public Collection(ResourceClassBase resourceClass, ResourceChildItem itemType, AssociationView association, string memberDisplayName)
            : base(resourceClass, memberDisplayName, memberDisplayName.ToCamelCase())
        {
            ItemType = itemType;
            Association = association;
        }

        public CollectionItemValueFilter[] ValueFilters { get; } = new CollectionItemValueFilter[0];

        public AssociationView Association { get; }

        public FilterContext FilterContext { get; }

        public ResourceChildItem ItemType { get; }

        public override FullName ParentFullName
        {
            get
            {
                // Detect collections based on an association that spans schemas, and use the Parent's FullName (the implicit/explicit "extension" class)
                if (!Association.ThisEntity.Schema.Equals(Association.OtherEntity.Schema))
                {
                    return Parent.FullName;
                }

                return Association.ThisEntity.FullName;
            }
        }

        /// <summary>
        /// Indicates whether the collection is based on a <see cref="Collection"/> inherited from a base entity type.
        /// </summary>
        public bool IsInherited
        {
            get
            {
                if (Association == null)
                {
                    return false;
                }

                return
                    Parent.Entity?.InheritedNavigableChildren.Contains(Association, ModelComparers.AssociationView) == true;
            }
        }

        private void ValidateCompositeCollectionArguments(Collection[] collections)
        {
            if (!collections.Any())
            {
                throw new ArgumentException(
                    "At least 1 collection must be supplied in order to create a composite collection.");
            }

            // Ensure that all collections refer to a common Association
            var distinctAssociations = collections.Select(r => r.Association)
                                                  .Distinct(ModelComparers.AssociationView)
                                                  .ToList();

            if (distinctAssociations.Count() != 1)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "All collections supplied for a composite collection must be derived from the same Association.  Associations found: '{0}'",
                        string.Join("', '", distinctAssociations.Select(a => a.Name))));
            }
        }

        public override string JsonPath
        {
            get => $"{Parent.JsonPath}.{JsonPropertyName}[*]";
        }
    }
}
