// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class SchoolYearTypeReferencePropertyBuilder :
        BaseBuilder
    {
        private readonly IApiConfiguration _config;

        public SchoolYearTypeReferencePropertyBuilder(IPropertyInfoMetadataLookup metadataLookup, IApiConfiguration config)
            : base(metadataLookup)
        {
            _config = config;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType.Name != "EdFiSchoolYearTypeReference")
            {
                return false;
            }

            var target = Activator.CreateInstance(propertyInfo.PropertyType, true);

            var schoolYear = target.GetType()
                .GetProperties()
                .Single(x => x.Name == "SchoolYear");

            schoolYear.SetValue(target,  _config.SchoolYear ?? DateTime.Today.Year);

            propertyInfo.SetValue(obj, target);
            return true;
        }
    }
}
