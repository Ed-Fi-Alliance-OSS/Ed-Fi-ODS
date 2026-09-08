// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Infrastructure.Activities;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Features.ChangeQueries;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Covers the authorization criteria applied to the change query endpoints (/deletes and /keyChanges). They route
    /// through the tracked changes criteria applicator rather than the CTE and EXISTS applicators used by the resource
    /// endpoints, so what they emit has to be asserted on this path separately.
    /// </summary>
    [TestFixture]
    public class TrackedChangesAuthorizationCriteriaTests
    {
        private const string EducationOrganizationFilterName = "ClaimEducationOrganizationIdsToSchoolId";

        private const string InvertedEducationOrganizationFilterName = "ClaimEducationOrganizationIdsToSchoolIdInverted";

        private const string PersonFilterName = "ClaimEducationOrganizationIdsToStudentUSI";

        private const string PersonViewName = "EducationOrganizationIdToStudentUSI";

        private const string EducationOrganizationViewName = "EducationOrganizationIdToEducationOrganizationId";

        private const string ResourceFullName = "edfi.studentSectionAssociation";

        private const string TrackedChangesTableName = "tracked_changes_edfi.StudentSectionAssociation";

        private static readonly object[] ClaimValues = { 255901L, 255902L };

        private static readonly string PersonLandingSql = SqlServerDialect.GetAuthPersonsTempTableLandingSql(
            PersonViewName,
            EducationOrganizationAuthorizationViewConstants.SourceColumnName,
            "StudentUSI");

        private IResourceModel _resourceModel;

        [SetUp]
        public void SetUp()
        {
            _resourceModel = DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();
        }

        [TestCase(true, TestName = "Should_land_the_claims_tvp_for_an_education_organization_filter_using_outer_joins")]
        [TestCase(false, TestName = "Should_land_the_claims_tvp_for_an_education_organization_filter_using_inner_joins")]
        public void Should_land_the_claims_tvp_into_the_temp_table_for_an_education_organization_filter(bool useOuterJoins)
        {
            string sql = BuildTrackedChangesSql(new SqlServerDialect(), EducationOrganizationFilterName, "SchoolId", useOuterJoins);

            sql.ShouldContain(SqlServerDialect.ClaimsTempTableLandingSql);
            sql.ShouldContain($"IN (SELECT Id FROM {SqlServerDialect.ClaimsTempTableName})");

            // Before the claims parameter was named on this path, the dialect took the plain TVP branch and the IN
            // clause read straight from the table-valued parameter instead of the temp table.
            sql.ShouldNotContain("IN (SELECT Id FROM @");

            // The education organization expansion is not landed here: it is not the side that is misestimated, and
            // the inverted strategies reuse this view with the columns swapped.
            sql.ShouldNotContain(SqlServerDialect.GetAuthPersonsTempTableName(EducationOrganizationViewName));
        }

        [Test]
        public void Should_not_land_an_expansion_for_the_inverted_education_organization_filter()
        {
            // The inverted strategies pass the same view with source and target swapped. A landing written for one
            // orientation would authorize the wrong set of education organizations.
            string sql = BuildTrackedChangesSql(
                new SqlServerDialect(),
                InvertedEducationOrganizationFilterName,
                "SchoolId",
                useOuterJoins: false);

            sql.ShouldContain(SqlServerDialect.ClaimsTempTableLandingSql);
            sql.ShouldNotContain(SqlServerDialect.GetAuthPersonsTempTableName(EducationOrganizationViewName));
        }

        [TestCase(true, TestName = "Should_land_the_person_expansion_using_outer_joins")]
        [TestCase(false, TestName = "Should_land_the_person_expansion_using_inner_joins")]
        public void Should_land_the_person_expansion_and_read_it_as_a_semi_join(bool useOuterJoins)
        {
            string sql = BuildTrackedChangesSql(new SqlServerDialect(), PersonFilterName, "StudentUSI", useOuterJoins);

            // Both statements, in order: the person landing reads from the claims temp table.
            sql.ShouldContain(SqlServerDialect.ClaimsTempTableLandingSql);
            sql.ShouldContain(PersonLandingSql);
            sql.IndexOf(SqlServerDialect.ClaimsTempTableLandingSql).ShouldBeLessThan(sql.IndexOf(PersonLandingSql));

            sql.ShouldContain($"EXISTS (SELECT 1 FROM {SqlServerDialect.GetAuthPersonsTempTableName(PersonViewName)}");

            // The view is no longer joined to the tracked changes table. Asserting on the JOIN rather than on the
            // view name, because the landing statement itself selects from the view.
            sql.ShouldNotContain($"JOIN auth.{PersonViewName}");
        }

        [Test]
        public void Should_not_emit_the_landing_for_a_dialect_that_does_not_use_it()
        {
            // Negative control for the assertions above: the landings are a SQL Server construct, so the same filter
            // on PostgreSQL must keep the original join shape. Without this, a test asserting only the SQL Server
            // shape would still pass on a change that emitted the landings unconditionally.
            string sql = BuildTrackedChangesSql(new PostgreSqlDialect(), PersonFilterName, "StudentUSI", useOuterJoins: false);

            sql.ShouldNotContain(SqlServerDialect.ClaimsTempTableName);
            sql.ShouldNotContain(SqlServerDialect.GetAuthPersonsTempTableName(PersonViewName));
            sql.ShouldContain($"JOIN auth.{PersonViewName}");
        }

        [Test]
        public void Should_emit_each_landing_once_when_several_filters_are_applied()
        {
            // Multiple relationship-based strategies combined with OR run the applicator more than once per query.
            // Both landings must still be emitted once each.
            var resource = _resourceModel.GetResourceByFullName(ResourceFullName);

            var queryBuilder = CreateTrackedChangesQueryBuilder(new SqlServerDialect());

            queryBuilder.OrWhere(
                nestedQueryBuilder =>
                {
                    ApplyFilter(nestedQueryBuilder, resource, EducationOrganizationFilterName, "SchoolId", 0, useOuterJoins: true);
                    ApplyFilter(nestedQueryBuilder, resource, PersonFilterName, "StudentUSI", 1, useOuterJoins: true);

                    return nestedQueryBuilder;
                });

            string sql = queryBuilder.BuildTemplate().RawSql;

            Regex.Matches(sql, Regex.Escape(SqlServerDialect.ClaimsTempTableLandingSql)).Count.ShouldBe(1);
            Regex.Matches(sql, Regex.Escape(PersonLandingSql)).Count.ShouldBe(1);
        }

        private string BuildTrackedChangesSql(Dialect dialect, string filterName, string subjectEndpointName, bool useOuterJoins)
        {
            var resource = _resourceModel.GetResourceByFullName(ResourceFullName);

            var queryBuilder = CreateTrackedChangesQueryBuilder(dialect);

            // The change query authorization decorator applies the filters inside a nested scope, so exercise that
            // path here: the landing statements only reach the outermost statement if the nested scope's prologue is
            // hoisted up to it.
            if (useOuterJoins)
            {
                queryBuilder.OrWhere(
                    nestedQueryBuilder =>
                    {
                        ApplyFilter(nestedQueryBuilder, resource, filterName, subjectEndpointName, 0, useOuterJoins: true);

                        return nestedQueryBuilder;
                    });
            }
            else
            {
                queryBuilder.Where(
                    nestedQueryBuilder =>
                    {
                        ApplyFilter(nestedQueryBuilder, resource, filterName, subjectEndpointName, 0, useOuterJoins: false);

                        return nestedQueryBuilder;
                    });
            }

            return queryBuilder.BuildTemplate().RawSql;
        }

        private static QueryBuilder CreateTrackedChangesQueryBuilder(Dialect dialect)
        {
            var queryBuilder = new QueryBuilder(dialect);

            queryBuilder.From($"{TrackedChangesTableName} AS {ChangeQueriesDatabaseConstants.TrackedChangesAlias}");
            queryBuilder.Select($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.*");

            return queryBuilder;
        }

        private static void ApplyFilter(
            QueryBuilder queryBuilder,
            Resource resource,
            string filterName,
            string subjectEndpointName,
            int filterIndex,
            bool useOuterJoins)
        {
            var filterDefinition = GetFilterDefinition(filterName);

            var filterContext = new AuthorizationFilterContext
            {
                FilterName = filterName,
                SubjectEndpointName = subjectEndpointName,
                ClaimParameterName = RelationshipAuthorizationConventions.ClaimsParameterName,
                ClaimEndpointValues = ClaimValues
            };

            filterDefinition.TrackedChangesCriteriaApplicator(
                filterDefinition,
                filterContext,
                resource,
                filterIndex,
                queryBuilder,
                useOuterJoins);
        }

        private static AuthorizationFilterDefinition GetFilterDefinition(string filterName)
        {
            var educationOrganizationIdNamesProvider = A.Fake<IEducationOrganizationIdNamesProvider>();
            A.CallTo(() => educationOrganizationIdNamesProvider.GetAllNames()).Returns(new[] { "SchoolId" });

            var personTypesProvider = A.Fake<IPersonTypesProvider>();
            A.CallTo(() => personTypesProvider.PersonTypes).Returns(new[] { "Student" });

            var factory = new RelationshipsAuthorizationStrategyFilterDefinitionsFactory(
                educationOrganizationIdNamesProvider,
                A.Fake<IApiClientContextProvider>(),
                A.Fake<IViewBasedSingleItemAuthorizationQuerySupport>(),
                personTypesProvider,
                A.Fake<IMultiValueRestrictions>());

            return factory.CreatePredefinedAuthorizationFilterDefinitions()
                .Single(filterDefinition => filterDefinition.FilterName == filterName);
        }
    }
}
