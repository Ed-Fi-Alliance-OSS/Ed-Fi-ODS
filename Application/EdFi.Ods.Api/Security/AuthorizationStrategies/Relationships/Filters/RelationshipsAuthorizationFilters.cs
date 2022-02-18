// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Common.Infrastructure.Filtering;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public static class RelationshipsAuthorizationFilters
    {
        private static readonly Lazy<FilterApplicationDetails> _schoolIdToSchoolId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("SchoolId"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToLocalEducationAgencyId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("LocalEducationAgencyId"));

        private static readonly Lazy<FilterApplicationDetails> _communityProviderIdToCommunityProviderId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("CommunityProviderId"));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToCommunityOrganizationId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("CommunityOrganizationId"));

        private static readonly Lazy<FilterApplicationDetails> _postSecondaryInstitutionIdToPostSecondaryInstitutionId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("PostSecondaryInstitutionId"));

        private static readonly Lazy<FilterApplicationDetails> _stateEducationAgencyIdToStateEducationAgencyId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("StateEducationAgencyId"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToEducationServiceCenterId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("EducationServiceCenterId"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToStudentUSI =
            new Lazy<FilterApplicationDetails>(() => new ViewFilterApplicationDetails(
                "EducationServiceCenterIdToStudentUSI",
                "EducationOrganizationIdToStudentUSI",
                "SourceEducationOrganizationId",
                "StudentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToStudentUSIThroughResponsibility
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationServiceCenterIdToStudentUSIThroughResponsibility",
                        "EducationOrganizationIdToStudentUSIThroughResponsibility",
                        "SourceEducationOrganizationId",
                        "StudentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStudentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "LocalEducationAgencyIdToStudentUSI",
                        "EducationOrganizationIdToStudentUSI",
                        "SourceEducationOrganizationId",
                        "StudentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStudentUSIThroughResponsibility
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "LocalEducationAgencyIdToStudentUSIThroughResponsibility",
                        "EducationOrganizationIdToStudentUSIThroughResponsibility",
                        "SourceEducationOrganizationId",
                        "StudentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStudentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "SchoolIdToStudentUSI",
                        "EducationOrganizationIdToStudentUSI",
                        "SourceEducationOrganizationId",
                        "StudentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStudentUSIThroughResponsibility
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "SchoolIdToStudentUSIThroughResponsibility",
                        "EducationOrganizationIdToStudentUSIThroughResponsibility",
                        "SourceEducationOrganizationId",
                        "StudentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationServiceCenterIdToStaffUSI",
                        "EducationOrganizationIdToStaffUSI",
                        "SourceEducationOrganizationId",
                        "StaffUSI"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "LocalEducationAgencyIdToStaffUSI",
                        "EducationOrganizationIdToStaffUSI",
                        "SourceEducationOrganizationId",
                        "StaffUSI"));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "SchoolIdToStaffUSI",
                        "EducationOrganizationIdToStaffUSI",
                        "SourceEducationOrganizationId",
                        "StaffUSI"));


        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToParentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationServiceCenterIdToParentUSI",
                        "EducationOrganizationIdToParentUSI",
                        "SourceEducationOrganizationId",
                        "ParentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToParentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "LocalEducationAgencyIdToParentUSI",
                        "EducationOrganizationIdToParentUSI",
                        "SourceEducationOrganizationId",
                        "ParentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _parentUSIToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "ParentUSIToSchoolId",
                        "EducationOrganizationIdToParentUSI",
                        "SourceEducationOrganizationId",
                        "ParentUSI"));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToEducationServiceCenterId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationOrganizationIdToEducationServiceCenterId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "EducationOrganizationId"));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToLocalEducationAgencyId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationOrganizationIdToLocalEducationAgencyId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "EducationOrganizationId"));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationOrganizationIdToSchoolId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "EducationOrganizationId"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToLocalEducationAgencyId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationServiceCenterIdToLocalEducationAgencyId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "LocalEducationAgencyId"));

        private static readonly Lazy<FilterApplicationDetails> _educationServiceCenterIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationServiceCenterIdToSchoolId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "SchoolId"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "LocalEducationAgencyIdToSchoolId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "SchoolId"));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToOrganizationDepartmentId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "LocalEducationAgencyIdToOrganizationDepartmentId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "OrganizationDepartmentId"));

        private static readonly Lazy<FilterApplicationDetails> _organizationDepartmentIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "OrganizationDepartmentIdToSchoolId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "OrganizationDepartmentId"));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToEducationOrganizationId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "CommunityOrganizationIdToEducationOrganizationId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "EducationOrganizationId"));

        private static readonly Lazy<FilterApplicationDetails> _communityProviderIdToEducationOrganizationId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "CommunityProviderIdToEducationOrganizationId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "EducationOrganizationId"));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToCommunityProviderId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "CommunityOrganizationIdToCommunityProviderId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "CommunityProviderId"));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToPostSecondaryInstitutionId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new ViewFilterApplicationDetails(
                        "EducationOrganizationIdToPostSecondaryInstitutionId",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "SourceEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        "EducationOrganizationId"));

        // Add non-join authorization entries for each EdOrg which can be associated with an API client

        public static FilterApplicationDetails SchoolIdToSchoolId => _schoolIdToSchoolId.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToLocalEducationAgencyId
            => _localEducationAgencyIdToLocalEducationAgencyId.Value;

        public static FilterApplicationDetails CommunityProviderIdToCommunityProviderId
            => _communityProviderIdToCommunityProviderId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToCommunityOrganizationId
            => _communityOrganizationIdToCommunityOrganizationId.Value;

        public static FilterApplicationDetails PostSecondaryInstitutionIdToPostSecondaryInstitutionId
            => _postSecondaryInstitutionIdToPostSecondaryInstitutionId.Value;

        public static FilterApplicationDetails StateEducationAgencyIdToStateEducationAgencyId
            => _stateEducationAgencyIdToStateEducationAgencyId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToEducationServiceCenterId
            => _educationServiceCenterIdToEducationServiceCenterId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToStudentUSI => _educationServiceCenterIdToStudentUSI.Value;
        
        public static FilterApplicationDetails EducationServiceCenterIdToStudentUSIThroughResponsibility 
            => _educationServiceCenterIdToStudentUSIThroughResponsibility.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStudentUSI => _localEducationAgencyIdToStudentUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStudentUSIThroughResponsibility
            => _localEducationAgencyIdToStudentUSIThroughResponsibility.Value;

        public static FilterApplicationDetails SchoolIdToStudentUSI => _schoolIdToStudentUSI.Value;

        public static FilterApplicationDetails SchoolIdToStudentUSIThroughResponsibility
            => _schoolIdToStudentUSIThroughResponsibility.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToStaffUSI => _educationServiceCenterIdToStaffUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStaffUSI => _localEducationAgencyIdToStaffUSI.Value;

        public static FilterApplicationDetails SchoolIdToStaffUSI => _schoolIdToStaffUSI.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToParentUSI => _educationServiceCenterIdToParentUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToParentUSI => _localEducationAgencyIdToParentUSI.Value;

        public static FilterApplicationDetails ParentUSIToSchoolId => _parentUSIToSchoolId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToEducationServiceCenterId
            => _educationOrganizationIdToEducationServiceCenterId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToLocalEducationAgencyId
            => _educationOrganizationIdToLocalEducationAgencyId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToSchoolId => _educationOrganizationIdToSchoolId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToLocalEducationAgencyId => _educationServiceCenterIdToLocalEducationAgencyId.Value;

        public static FilterApplicationDetails EducationServiceCenterIdToSchoolId => _educationServiceCenterIdToSchoolId.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToSchoolId => _localEducationAgencyIdToSchoolId.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToOrganizationDepartmentId
            => _localEducationAgencyIdToOrganizationDepartmentId.Value;

        public static FilterApplicationDetails OrganizationDepartmentIdToSchoolId => _organizationDepartmentIdToSchoolId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToEducationOrganizationId
            => _communityOrganizationIdToEducationOrganizationId.Value;

        public static FilterApplicationDetails CommunityProviderIdToEducationOrganizationId
            => _communityProviderIdToEducationOrganizationId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToCommunityProviderId
            => _communityOrganizationIdToCommunityProviderId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToPostSecondaryInstitutionId
            => _educationOrganizationIdToPostSecondaryInstitutionId.Value;

        private static FilterApplicationDetails CreateClaimValuePropertyFilter(string propertyName)
        {
            return new FilterApplicationDetails(
                $"{propertyName}To{propertyName}",
                $"{propertyName} IN (:{propertyName})",
                $"{{currentAlias}}.{propertyName} IN (:{propertyName})",
                (c, w, p, jt) => w.ApplyPropertyFilters(p, propertyName),
                (t, p) => p.HasPropertyNamed(propertyName));
        }

        private static readonly Lazy<IDictionary<string, ViewFilterApplicationDetails>> _viewFilterByName;

        static RelationshipsAuthorizationFilters()
        {
            _viewFilterByName = new Lazy<IDictionary<string, ViewFilterApplicationDetails>>(
                () =>
                    typeof(RelationshipsAuthorizationFilters).GetProperties(BindingFlags.Public | BindingFlags.Static)
                        .Select(p => new { Name = p.Name, Value = p.GetValue(null) as ViewFilterApplicationDetails })
                        .Where(x => x.Value != null)
                        .ToDictionary(x => x.Name, x => x.Value));
        }
        
        public static ViewFilterApplicationDetails GetViewFilterApplicationDetails(string filterName)
        {
            if (_viewFilterByName.Value.TryGetValue(filterName, out var filter))
            {
                return filter;
            }

            throw new Exception($"View-based filter '{filterName}' not found.");
        }
    }
}
