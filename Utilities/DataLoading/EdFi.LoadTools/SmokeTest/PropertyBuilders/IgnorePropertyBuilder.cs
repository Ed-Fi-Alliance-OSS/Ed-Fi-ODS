// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Don't populate a value for Ids, _eTags, links
    /// </summary>
    public class IgnorePropertyBuilder : BaseBuilder
    {
        private static readonly List<string> IgnoredPropertyNames = new List<string>
        {
            "id",
            "_etag",
            "link"
        };

        public IgnorePropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            return IgnoredPropertyNames.Contains(propertyInfo.Name, StringComparer.OrdinalIgnoreCase)
                   // Ignore properties that are marked as optional in the model
                   || (!propertyInfo.GetCustomAttribute<DataMemberAttribute>()?.IsRequired ?? false);
        }
    }
}
