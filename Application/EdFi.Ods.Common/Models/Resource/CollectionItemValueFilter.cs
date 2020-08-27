// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Models.Resource
{
    public class CollectionItemValueFilter
    {
        internal CollectionItemValueFilter(XElement itemFilterElement)
        {
            if (itemFilterElement.Name != "Filter")
            {
                throw new ArgumentException("Supplied XElement was not a collection item filter definition.");
            }

            PropertyName = itemFilterElement.AttributeValue("propertyName");
            FilterMode = (ItemFilterMode) Enum.Parse(typeof(ItemFilterMode), itemFilterElement.AttributeValue("filterMode"));

            Values = itemFilterElement.Elements("Value")
                                      .Select(e => e.Value)
                                      .ToArray();
        }

        public string PropertyName { get; }

        public ItemFilterMode FilterMode { get; }

        public string[] Values { get; }
    }
}
