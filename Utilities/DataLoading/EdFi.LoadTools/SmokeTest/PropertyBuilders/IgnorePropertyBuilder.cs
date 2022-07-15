// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Don't populate a value for Ids, _eTags, links
    /// </summary>
    public class IgnorePropertyBuilder : BaseBuilder
    {
        private static readonly List<string> _ignoredPropertyNames = new List<string>
        {
            "id",
            "_etag",
            "link"
        };

        public IgnorePropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            return _ignoredPropertyNames.Contains(propertyInfo.Name, StringComparer.OrdinalIgnoreCase);
        }
    }
}
