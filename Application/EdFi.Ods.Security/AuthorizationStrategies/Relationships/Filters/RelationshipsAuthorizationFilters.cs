// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Api.NHibernate.Filtering;
using EdFi.Ods.Common;
using EdFi.Ods.Security.AuthorizationStrategies.NHibernateConfiguration;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships.Filters
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

        private static FilterApplicationDetails CreateClaimValuePropertyFilter(string propertyName)
        {
            return new FilterApplicationDetails(
                $"{propertyName}To{propertyName}",
                $"{propertyName} IN (:{propertyName})",
                $"{{currentAlias}}.{propertyName} IN (:{propertyName})",
                (c, w, p, jt) => w.ApplyPropertyFilters(p, propertyName),
                (t, p) => p.HasPropertyNamed(propertyName));
        }

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStudentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToStudentUSI",
                        @"StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM [auth].[LocalEducationAgencyIdToStudentUSI] {newAlias1} 
                            WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        @"{currentAlias}.StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM " + "auth_LocalEducationAgencyIdToStudentUSI".GetFullNameForView() + @" {newAlias1} 
                            WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "LocalEducationAgencyIdToStudentUSI", "StudentUSI", "LocalEducationAgencyId", jt),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStudentUSIThroughEdOrgAssociation
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation",
                        @"StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM [auth].[LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation] {newAlias1} 
                            WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        @"{currentAlias}.StudentUSI IN (
                            SELECT {newAlias1}.StudentUSI 
                            FROM " + "auth_LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation".GetFullNameForView() + @" {newAlias1} 
                            WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation", "StudentUSI", "LocalEducationAgencyId", jt),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStudentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "SchoolIdToStudentUSI",
                        @"StudentUSI IN (
                        SELECT {newAlias1}.StudentUSI 
                        FROM [auth].[SchoolIdToStudentUSI] {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        @"{currentAlias}.StudentUSI IN (
                        SELECT {newAlias1}.StudentUSI 
                        FROM " + "auth_SchoolIdToStudentUSI".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "SchoolIdToStudentUSI", "StudentUSI", "SchoolId", jt),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStudentUSIThroughEdOrgAssociation
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "SchoolIdToStudentUSIThroughEdOrgAssociation",
                        @"StudentUSI IN (
                        SELECT {newAlias1}.StudentUSI 
                        FROM [auth].[SchoolIdToStudentUSIThroughEdOrgAssociation] {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        @"{currentAlias}.StudentUSI IN (
                        SELECT {newAlias1}.StudentUSI 
                        FROM " + "auth_SchoolIdToStudentUSIThroughEdOrgAssociation".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "SchoolIdToStudentUSIThroughEdOrgAssociation", "StudentUSI", "SchoolId", jt),
                        (t, p) => p.HasPropertyNamed("StudentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToStaffUSI",
                        @"StaffUSI IN (
                        SELECT {newAlias1}.StaffUSI 
                        FROM [auth].[LocalEducationAgencyIdToStaffUSI] {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        @"{currentAlias}.StaffUSI IN (
                        SELECT {newAlias1}.StaffUSI 
                        FROM " + "auth_LocalEducationAgencyIdToStaffUSI".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "LocalEducationAgencyIdToStaffUSI", "StaffUSI", "LocalEducationAgencyId", jt),
                        (t, p) => p.HasPropertyNamed("StaffUSI")));

        private static readonly Lazy<FilterApplicationDetails> _schoolIdToStaffUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "SchoolIdToStaffUSI",
                        @"StaffUSI IN (
                    SELECT {newAlias1}.StaffUSI 
                    FROM [auth].[SchoolIdToStaffUSI] {newAlias1} 
                    WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        @"{currentAlias}.StaffUSI IN (
                    SELECT {newAlias1}.StaffUSI 
                    FROM " + "auth_SchoolIdToStaffUSI".GetFullNameForView() + @" {newAlias1} 
                    WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "SchoolIdToStaffUSI", "StaffUSI", "SchoolId", jt),
                        (t, p) => p.HasPropertyNamed("StaffUSI")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToParentUSI
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToParentUSI",
                        @"ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM [auth].[LocalEducationAgencyIdToParentUSI] {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        @"{currentAlias}.ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM " + "auth_LocalEducationAgencyIdToParentUSI".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "LocalEducationAgencyIdToParentUSI", "ParentUSI", "LocalEducationAgencyId", jt),
                        (t, p) => p.HasPropertyNamed("ParentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _parentUSIToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "ParentUSIToSchoolId",
                        @"ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM [auth].[ParentUSIToSchoolId] {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        @"{currentAlias}.ParentUSI IN (
                        SELECT {newAlias1}.ParentUSI 
                        FROM " + "auth_ParentUSIToSchoolId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "ParentUSIToSchoolId", "ParentUSI", "SchoolId", jt),
                        (t, p) => p.HasPropertyNamed("ParentUSI")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToLocalEducationAgencyId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToLocalEducationAgencyId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM [auth].[EducationOrganizationIdToLocalEducationAgencyId] {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToLocalEducationAgencyId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToLocalEducationAgencyId", "EducationOrganizationId", "LocalEducationAgencyId", jt),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToSchoolId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM [auth].[EducationOrganizationIdToSchoolId] {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToSchoolId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.SchoolId IN (:SchoolId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToSchoolId", "EducationOrganizationId", "SchoolId", jt),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _localEducationAgencyIdToSchoolId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "LocalEducationAgencyIdToSchoolId",
                        @"SchoolId IN (
                        SELECT {newAlias1}.SchoolId 
                        FROM [auth].[LocalEducationAgencyIdToSchoolId] {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        @"{currentAlias}.SchoolId IN (
                        SELECT {newAlias1}.SchoolId 
                        FROM " + "auth_LocalEducationAgencyIdToSchoolId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.LocalEducationAgencyId IN (:LocalEducationAgencyId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "LocalEducationAgencyIdToSchoolId", "SchoolId", "LocalEducationAgencyId", jt),
                        (t, p) => p.HasPropertyNamed("SchoolId")));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToEducationOrganizationId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "CommunityOrganizationIdToEducationOrganizationId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM [auth].[CommunityOrganizationIdToEducationOrganizationId] {newAlias1} 
                        WHERE {newAlias1}.CommunityOrganizationId IN (:CommunityOrganizationId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM " + "auth_CommunityOrganizationIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.CommunityOrganizationId IN (:CommunityOrganizationId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "CommunityOrganizationIdToEducationOrganizationId", "EducationOrganizationId", "CommunityOrganizationId", jt),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _communityProviderIdToEducationOrganizationId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "CommunityProviderIdToEducationOrganizationId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM [auth].[CommunityProviderIdToEducationOrganizationId] {newAlias1} 
                        WHERE {newAlias1}.CommunityProviderId IN (:CommunityProviderId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM " + "auth_CommunityProviderIdToEducationOrganizationId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.CommunityProviderId IN (:CommunityProviderId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "CommunityProviderIdToEducationOrganizationId", "EducationOrganizationId", "CommunityProviderId", jt),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _communityOrganizationIdToCommunityProviderId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "CommunityOrganizationIdToCommunityProviderId",
                        @"CommunityProviderId IN (
                        SELECT {newAlias1}.CommunityProviderId 
                        FROM [auth].[CommunityOrganizationIdToCommunityProviderId] {newAlias1} 
                        WHERE {newAlias1}.CommunityOrganizationId IN (:CommunityOrganizationId))",
                        @"{currentAlias}.CommunityProviderId IN (
                        SELECT {newAlias1}.CommunityProviderId 
                        FROM " + "auth_CommunityOrganizationIdToCommunityProviderId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.CommunityOrganizationId IN (:CommunityOrganizationId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "CommunityOrganizationIdToCommunityProviderId", "CommunityProviderId", "CommunityOrganizationId", jt),
                        (t, p) => p.HasPropertyNamed("CommunityProviderId")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToPostSecondaryInstitutionId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToPostSecondaryInstitutionId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM [auth].[EducationOrganizationIdToPostSecondaryInstitutionId] {newAlias1} 
                        WHERE {newAlias1}.PostSecondaryInstitutionId IN (:PostSecondaryInstitutionId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToPostSecondaryInstitutionId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.PostSecondaryInstitutionId IN (:PostSecondaryInstitutionId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToPostSecondaryInstitutionId", "EducationOrganizationId", "PostSecondaryInstitutionId", jt),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

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
        
        public static FilterApplicationDetails LocalEducationAgencyIdToStudentUSI => _localEducationAgencyIdToStudentUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation
            => _localEducationAgencyIdToStudentUSIThroughEdOrgAssociation.Value;

        public static FilterApplicationDetails SchoolIdToStudentUSI => _schoolIdToStudentUSI.Value;

        public static FilterApplicationDetails SchoolIdToStudentUSIThroughEdOrgAssociation => _schoolIdToStudentUSIThroughEdOrgAssociation.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToStaffUSI => _localEducationAgencyIdToStaffUSI.Value;

        public static FilterApplicationDetails SchoolIdToStaffUSI => _schoolIdToStaffUSI.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToParentUSI => _localEducationAgencyIdToParentUSI.Value;

        public static FilterApplicationDetails ParentUSIToSchoolId => _parentUSIToSchoolId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToLocalEducationAgencyId
            => _educationOrganizationIdToLocalEducationAgencyId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToSchoolId => _educationOrganizationIdToSchoolId.Value;

        public static FilterApplicationDetails LocalEducationAgencyIdToSchoolId => _localEducationAgencyIdToSchoolId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToEducationOrganizationId
            => _communityOrganizationIdToEducationOrganizationId.Value;

        public static FilterApplicationDetails CommunityProviderIdToEducationOrganizationId => _communityProviderIdToEducationOrganizationId.Value;

        public static FilterApplicationDetails CommunityOrganizationIdToCommunityProviderId => _communityOrganizationIdToCommunityProviderId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToPostSecondaryInstitutionId
            => _educationOrganizationIdToPostSecondaryInstitutionId.Value;

        private static readonly Lazy<FilterApplicationDetails> _universityIdToUniversityId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("UniversityId"));

        private static readonly Lazy<FilterApplicationDetails> _teacherPreparationProviderIdToTeacherPreparationProviderId =
            new Lazy<FilterApplicationDetails>(() => CreateClaimValuePropertyFilter("TeacherPreparationProviderId"));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToUniversityId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToUniversityId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM [auth].[EducationOrganizationIdToUniversityId] {newAlias1} 
                        WHERE {newAlias1}.UniversityId IN (:UniversityId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToUniversityId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.UniversityId IN (:UniversityId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToUniversityId", "EducationOrganizationId", "UniversityId", jt),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        private static readonly Lazy<FilterApplicationDetails> _educationOrganizationIdToTeacherPreparationProviderId
            = new Lazy<FilterApplicationDetails>(
                () =>
                    new FilterApplicationDetails(
                        "EducationOrganizationIdToTeacherPreparationProviderId",
                        @"EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM [auth].[EducationOrganizationIdToTeacherPreparationProviderId] {newAlias1} 
                        WHERE {newAlias1}.TeacherPreparationProviderId IN (:TeacherPreparationProviderId))",
                        @"{currentAlias}.EducationOrganizationId IN (
                        SELECT {newAlias1}.EducationOrganizationId 
                        FROM " + "auth_EducationOrganizationIdToTeacherPreparationProviderId".GetFullNameForView() + @" {newAlias1} 
                        WHERE {newAlias1}.TeacherPreparationProviderId IN (:TeacherPreparationProviderId))",
                        (c, w, p, jt) => c.ApplyJoinFilter(w, p, "EducationOrganizationIdToTeacherPreparationProviderId", "EducationOrganizationId", "TeacherPreparationProviderId", jt),
                        (t, p) => p.HasPropertyNamed("EducationOrganizationId")));

        public static FilterApplicationDetails UniversityIdToUniversityId
            => _universityIdToUniversityId.Value;

        public static FilterApplicationDetails TeacherPreparationProviderIdToTeacherPreparationProviderId
            => _teacherPreparationProviderIdToTeacherPreparationProviderId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToUniversityId
            => _educationOrganizationIdToUniversityId.Value;

        public static FilterApplicationDetails EducationOrganizationIdToTeacherPreparationProviderId
            => _educationOrganizationIdToTeacherPreparationProviderId.Value;

        private static string GetFullNameForView(this string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }
    }
}
