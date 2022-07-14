// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Contains the pertinent Ed-Fi data necessary for making authorization decisions.
    /// </summary>
    public class RelationshipsAuthorizationContextData
    {
        private static class PropertyNames
        {
            public const string EducationOrganizationId = "EducationOrganizationId";
            public const string StateEducationAgencyId = "StateEducationAgencyId";
            public const string EducationServiceCenterId = "EducationServiceCenterId";
            public const string LocalEducationAgencyId = "LocalEducationAgencyId";
            public const string SchoolId = "SchoolId";
            public const string EducationOrganizationNetworkId = "EducationOrganizationNetworkId";
            public const string CommunityOrganizationId = "CommunityOrganizationId";
            public const string CommunityProviderId = "CommunityProviderId";
            public const string OrganizationDepartmentId = "OrganizationDepartmentId";
            public const string PostSecondaryInstitutionId = "PostSecondaryInstitutionId";
            public const string StaffUSI = "StaffUSI";
            public const string StudentUSI = "StudentUSI";
            public const string ParentUSI = "ParentUSI";
        }

        // Education Organizations
        public int? EducationOrganizationId { get; set; }

        public int? StateEducationAgencyId { get; set; }

        public int? EducationServiceCenterId { get; set; }

        public int? LocalEducationAgencyId { get; set; }

        public int? SchoolId { get; set; }

        public int? EducationOrganizationNetworkId { get; set; }

        public int? CommunityOrganizationId { get; set; }

        public int? CommunityProviderId { get; set; }

        public int? OrganizationDepartmentId { get; set; }

        public int? PostSecondaryInstitutionId { get; set; }

        // People
        public int? StaffUSI { get; set; }

        public int? StudentUSI { get; set; }

        public int? ParentUSI { get; set; }

        public IEnumerable<(string propertyName, object value)> GetAuthorizationContextTuples(
            (string roleNamed, string nonRoleNamed)[] authorizationContextPropertyNames)
        {
            foreach (var authorizationContextPropertyName in authorizationContextPropertyNames)
            {
                foreach ((string propertyName, object value) valueTuple in GetAuthorizationContextValueTuple(
                             authorizationContextPropertyName.roleNamed,
                             authorizationContextPropertyName.nonRoleNamed))
                {
                    yield return valueTuple;
                }
            }
        }

        protected virtual IEnumerable<(string propertyName, object value)> GetAuthorizationContextValueTuple(string authorizationContextPropertyName, 
            string authorizationContextNonRoleNamedProperty)
        {
            switch (authorizationContextNonRoleNamedProperty)
            {
                case PropertyNames.EducationOrganizationId:
                    yield return (authorizationContextPropertyName, EducationOrganizationId);

                    break;

                case PropertyNames.StateEducationAgencyId:
                    yield return (authorizationContextPropertyName, StateEducationAgencyId);

                    break;

                case PropertyNames.EducationServiceCenterId:
                    yield return (authorizationContextPropertyName, EducationServiceCenterId);

                    break;

                case PropertyNames.LocalEducationAgencyId:
                    yield return (authorizationContextPropertyName, LocalEducationAgencyId);

                    break;

                case PropertyNames.SchoolId:
                    yield return (authorizationContextPropertyName, SchoolId);

                    break;

                case PropertyNames.EducationOrganizationNetworkId:
                    yield return (authorizationContextPropertyName, EducationOrganizationNetworkId);

                    break;

                case PropertyNames.CommunityOrganizationId:
                    yield return (authorizationContextPropertyName, CommunityOrganizationId);

                    break;

                case PropertyNames.CommunityProviderId:
                    yield return (authorizationContextPropertyName, CommunityProviderId);

                    break;

                case PropertyNames.OrganizationDepartmentId:
                    yield return (authorizationContextPropertyName, OrganizationDepartmentId);

                    break;

                case PropertyNames.PostSecondaryInstitutionId:
                    yield return (authorizationContextPropertyName, PostSecondaryInstitutionId);

                    break;

                case PropertyNames.StaffUSI:
                    yield return (authorizationContextPropertyName, StaffUSI);

                    break;

                case PropertyNames.StudentUSI:
                    yield return (authorizationContextPropertyName, StudentUSI);

                    break;

                case PropertyNames.ParentUSI:
                    yield return (authorizationContextPropertyName, ParentUSI);

                    break;

                default:
                    throw new NotSupportedException(
                        $"Authorization context property '{authorizationContextPropertyName}' is not supported.");
            }
        }
    }
}
