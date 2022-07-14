// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Mapping;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class ParentLocalEducationAgencyReferenceBuilder : BaseBuilder
    {
        private readonly IDestructiveTestConfiguration _configuration;

        public ParentLocalEducationAgencyReferenceBuilder(
            IPropertyInfoMetadataLookup metadataLookup,
            IDestructiveTestConfiguration configuration)
            : base(metadataLookup)
        {
            _configuration = configuration;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.Name != "ParentLocalEducationAgencyReference")
            {
                return false;
            }

            // While creating an LEA, link it to an existing LEA to inherit its authorization privileges
            var propertyType = propertyInfo.PropertyType;

            var source = new
            {
                LocalEducationAgencyId = _configuration.ParentEdOrgId ?? EdFiConstants.TestEdOrgId
            };

            var config = new MapperConfiguration(cfg => cfg.CreateMap(source.GetType(), propertyType));
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            var target = mapper.Map(source, propertyType);
            propertyInfo.SetValue(obj, target);
            return true;
        }
    }
}
