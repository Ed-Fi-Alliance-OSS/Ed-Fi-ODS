// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.Mapping;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Create references from real objects
    /// </summary>
    public class ReferencePropertyBuilder : BaseBuilder
    {
        private readonly Dictionary<string, List<object>> _resultsDictionary;

        public ReferencePropertyBuilder(Dictionary<string, List<object>> resultsDictionary, IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup)
        {
            _resultsDictionary = resultsDictionary;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (!propertyType.Name.EndsWith("Reference"))
            {
                return false;
            }

            var referencedTypeName = propertyType.Name.Replace("Reference", string.Empty);

            if (_resultsDictionary.ContainsKey(referencedTypeName)
                && _resultsDictionary[referencedTypeName].Count > 0)
            {
                var source = _resultsDictionary[referencedTypeName].First();
                var config = new MapperConfiguration(cfg => cfg.CreateMap(source.GetType(), propertyType));
                config.AssertConfigurationIsValid();
                var mapper = config.CreateMapper();
                var target = mapper.Map(source, propertyType);
                propertyInfo.SetValue(obj, target);
                return true;
            }

            Log.Warn($"No {referencedTypeName} resources available to create a {propertyType.Name}. This warning can be ignored if the reference points to itself.");
            return true;
        }
    }
}
