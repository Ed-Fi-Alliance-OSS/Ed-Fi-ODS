// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models.Resource;
using NUnit.Framework;
using Shouldly;
using Test.Common;

// Fully qualified: EdFi.Ods.Common.Providers.Queries also declares a QueryBuilderExtensions, and
// importing that namespace would make the type under test ambiguous.
using AliasConstants = EdFi.Ods.Common.Providers.Queries.AliasConstants;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    [TestFixture]
    public class QueryBuilderExtensionsTests
    {
        private const string EdOrgToEdOrgViewName = "EducationOrganizationIdToEducationOrganizationId";

        private const string ResourceFullName = "edfi.studentSectionAssociation";

        [Test]
        public void Should_recognize_the_forward_education_organization_expansion()
        {
            QueryBuilderExtensions.IsForwardEducationOrganizationExpansion(
                    EdOrgToEdOrgViewName,
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    EducationOrganizationAuthorizationViewConstants.TargetColumnName)
                .ShouldBeTrue();
        }

        [Test]
        public void Should_not_recognize_the_inverted_orientation_of_the_same_view()
        {
            // The inverted relationship strategies pass the same view with the columns swapped. Treating that as the
            // forward expansion would authorize the wrong set of education organizations.
            QueryBuilderExtensions.IsForwardEducationOrganizationExpansion(
                    EdOrgToEdOrgViewName,
                    EducationOrganizationAuthorizationViewConstants.TargetColumnName,
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName)
                .ShouldBeFalse();
        }

        [Test]
        public void Should_land_the_education_organization_expansion_for_the_forward_orientation()
        {
            string sql = BuildAuthorizedQuerySql(
                EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                EducationOrganizationAuthorizationViewConstants.TargetColumnName);

            sql.ShouldContain(SqlServerDialect.ClaimsTempTableLandingSql);
            sql.ShouldContain(SqlServerDialect.AuthEdOrgsTempTableLandingSql);
            sql.ShouldContain($"FROM {SqlServerDialect.AuthEdOrgsTempTableName} AS av");

            // The expansion replaces reading the view directly; leaving both in would mean the landing was
            // emitted but never consumed.
            sql.ShouldNotContain($"FROM auth.{EdOrgToEdOrgViewName} AS av");
        }

        [Test]
        public void Should_not_land_the_expansion_for_the_inverted_orientation()
        {
            // Negative control: the inverted strategies pass the same view with the columns swapped, and the
            // landing statement is written for one direction only.
            string sql = BuildAuthorizedQuerySql(
                EducationOrganizationAuthorizationViewConstants.TargetColumnName,
                EducationOrganizationAuthorizationViewConstants.SourceColumnName);

            sql.ShouldNotContain(SqlServerDialect.AuthEdOrgsTempTableLandingSql);
            sql.ShouldContain($"FROM auth.{EdOrgToEdOrgViewName} AS av");
        }

        private static string BuildAuthorizedQuerySql(string viewSourceEndpointName, string viewTargetEndpointName)
        {
            var resource = DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(ResourceFullName);

            var queryBuilder = new QueryBuilder(new SqlServerDialect());
            queryBuilder.From($"edfi.StudentSectionAssociation AS {AliasConstants.RootAlias}");
            queryBuilder.Select($"{AliasConstants.RootAlias}.*");

            var parameters = new Dictionary<string, object>
            {
                [RelationshipAuthorizationConventions.ClaimsParameterName] = new object[] { 255901L, 255902L }
            };

            queryBuilder.ApplySingleColumnJoinFilter(
                resource,
                parameters,
                EdOrgToEdOrgViewName,
                "SchoolId",
                viewSourceEndpointName,
                viewTargetEndpointName,
                JoinType.InnerJoin);

            return queryBuilder.BuildTemplate().RawSql;
        }

        [Test]
        public void Should_not_recognize_a_different_authorization_view()
        {
            QueryBuilderExtensions.IsForwardEducationOrganizationExpansion(
                    "EducationOrganizationIdToStudentUSI",
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    "StudentUSI")
                .ShouldBeFalse();
        }
    }
}
