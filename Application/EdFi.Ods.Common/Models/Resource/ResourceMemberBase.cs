// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Models.Resource
{
    public abstract class ResourceMemberBase : IHasNameContext, IHasParent
    {
        private readonly Lazy<string> _jsonPropertyName;

        protected ResourceMemberBase(ResourceClassBase resourceClass, string propertyName)
        {
            ResourceClass = resourceClass;
            PropertyName = propertyName;

            _jsonPropertyName = new Lazy<string>(
                () =>
                {
                    var jsonPropertyName =
                        ResourceClass.AllProperties.Any(x => x.PropertyName == PropertyName)
                        || ResourceClass.MemberNamesInvolvedInJsonCollisions.Contains(PropertyName)
                            ? PropertyName.ToCamelCase()
                            : JsonNamingConvention.ProposeJsonPropertyName(ParentFullName.Name, PropertyName);

                    return UniqueIdSpecification.IsUSI(jsonPropertyName)
                        ? UniqueIdSpecification.GetUniqueIdPropertyName(jsonPropertyName)
                        : jsonPropertyName;
                });
        }

        protected ResourceMemberBase(ResourceClassBase resourceClass, string propertyName, string jsonPropertyName)
        {
            ResourceClass = resourceClass;
            PropertyName = propertyName;

            _jsonPropertyName = new Lazy<string>(() => jsonPropertyName);
        }

        internal ResourceClassBase ResourceClass { get; }

        public string JsonPropertyName => _jsonPropertyName.Value;

        /// <summary>
        /// Gets the name of the resource class containing the current member.
        /// </summary>
        public abstract FullName ParentFullName { get; }

        public string PropertyName { get; }

        public IEnumerable<ResourceClassBase> GetLineage()
        {
            // Return the parent resource child item's lineage
            if (Parent is IHasParent)
            {
                return (Parent as IHasParent).GetLineage();
            }

            // Just return the parent resource
            return new[]
                   {
                       Parent
                   };
        }

        /// <summary>
        /// Returns the <see cref="ResourceClassBase"/> instance containing the current member.
        /// </summary>
        public ResourceClassBase Parent => ResourceClass;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => PropertyName;
    }

    public static class JsonNamingConvention
    {
        public static string ProposeJsonPropertyName(string parentName, string memberName)
        {
            return ApplyParentPrefixRemovalConvention(parentName, memberName)
               .ToCamelCase();
        }

        public static string ApplyParentPrefixRemovalConvention(string parentName, string memberName)
        {
            var parentNameNoExtension = parentName.ReplaceSuffix("Extension", "");

            if (memberName.StartsWith(parentNameNoExtension) && !memberName.Equals(parentNameNoExtension))
            {
                // Don't trim prefixes off known identifiers
                if (memberName.EndsWith("Id") || memberName.EndsWith("USI") || memberName.EndsWith("TypeId"))
                {
                    return memberName;
                }

                return memberName.Substring(parentNameNoExtension.Length);
            }

            return memberName;
        }
    }
}
