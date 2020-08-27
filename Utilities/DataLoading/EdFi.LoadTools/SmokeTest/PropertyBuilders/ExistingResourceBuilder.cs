// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Retrieve an existing resource from the the object cache
    /// </summary>
    public class ExistingResourceBuilder : BaseBuilder
    {
        private readonly Dictionary<string, List<object>> _resultsDictionary;

        public ExistingResourceBuilder(
            Dictionary<string, List<object>> resultsDictionary,
            IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup)
        {
            _resultsDictionary = resultsDictionary;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (_resultsDictionary.ContainsKey(propertyType.Name) && _resultsDictionary[propertyType.Name]
                    .Count > 0)
            {
                propertyInfo.SetValue(
                    obj,
                    _resultsDictionary[propertyType.Name]
                        .First());

                return true;
            }

            return false;
        }
    }
}
