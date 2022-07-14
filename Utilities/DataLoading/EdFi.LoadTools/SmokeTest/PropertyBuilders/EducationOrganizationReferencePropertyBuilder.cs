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
    ///     Special case for Education Organizations.
    /// </summary>
    public class EducationOrganizationReferencePropertyBuilder : BaseBuilder
    {
        private readonly Dictionary<string, List<object>> _resultsDictionary;

        public EducationOrganizationReferencePropertyBuilder(
            Dictionary<string, List<object>> resultsDictionary,
            IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup)
        {
            _resultsDictionary = resultsDictionary;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (!propertyType.Name.EndsWith("EducationOrganizationReference"))
            {
                return false;
            }

            var source = _resultsDictionary["EdFiSchool"]
                .FirstOrDefault();

            if (source == null)
            {
                return true;
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap(source.GetType(), propertyType));
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            var target = mapper.Map(source, propertyType);
            propertyInfo.SetValue(obj, target);
            return true;
        }
    }
}
