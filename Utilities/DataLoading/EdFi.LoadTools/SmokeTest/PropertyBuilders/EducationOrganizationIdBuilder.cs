// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class EducationOrganizationIdBuilder : BaseBuilder
    {
        private readonly IDestructiveTestConfiguration _configuration;

        public EducationOrganizationIdBuilder(
            IPropertyInfoMetadataLookup metadataLookup,
            IDestructiveTestConfiguration configuration)
            : base(metadataLookup)
        {
            _configuration = configuration;
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            int edOrgId;

            switch (propertyInfo.Name)
            {
                case nameof(_configuration.LocalEducationAgencyId):
                    edOrgId = _configuration.LocalEducationAgencyId!.Value;
                    break;

                case nameof(_configuration.CommunityProviderId):
                    edOrgId = _configuration.CommunityProviderId!.Value;
                    break;

                default:
                    // EdOrg ids that aren't relevant for authorization are initialized in the SimplePropertyBuilder
                    return false;
            }

            propertyInfo.SetValue(obj, edOrgId);
            return true;
        }
    }
}
