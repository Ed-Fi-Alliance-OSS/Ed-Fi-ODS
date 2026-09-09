// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Text.RegularExpressions;
using Dapper;
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

        private const string ChangeKindColumnName = "NewBeginDate";

        private const string TrackedChangesPersonColumn = "OldStudentUSI";

        // A /deletes query selects the rows whose new key values are absent.
        private static readonly TrackedChangesRestriction DeletesRestriction = new(
            TrackedChangesTableName,
            ChangeKindColumnName,
            selectsNewValues: false);

        // What a change query emits: it knows its tracked changes table and which kind of change it selects, so
        // the expansion is restricted to the persons that table holds under that same criterion.
        private static readonly string PersonLandingSql = SqlServerDialect.GetAuthPersonsTempTableLandingSql(
            PersonViewName,
            EducationOrganizationAuthorizationViewConstants.SourceColumnName,
            "StudentUSI",
            DeletesRestriction.ForPersonColumn(TrackedChangesPersonColumn));

        // The fallback, for a caller that did not record its tracked changes table.
        private static readonly string UnrestrictedPersonLandingSql = SqlServerDialect.GetAuthPersonsTempTableLandingSql(
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

            sql.ShouldContain(
                "EXISTS (SELECT 1 FROM "
                + SqlServerDialect.GetAuthPersonsTempTableName(
                    PersonViewName,
                    DeletesRestriction.ForPersonColumn(TrackedChangesPersonColumn)));

            // The view is no longer joined to the tracked changes table. Asserting on the JOIN rather than on the
            // view name, because the landing statement itself selects from the view.
            sql.ShouldNotContain($"JOIN auth.{PersonViewName}");
        }

        [Test]
        public void Should_restrict_the_person_expansion_to_the_tracked_changes_table()
        {
            string sql = BuildTrackedChangesSql(new SqlServerDialect(), PersonFilterName, "StudentUSI", useOuterJoins: false);

            sql.ShouldContain(
                $"EXISTS (SELECT 1 FROM {TrackedChangesTableName} AS tc"
                + $" WHERE tc.OldStudentUSI = av.StudentUSI AND tc.{ChangeKindColumnName} IS NULL)");

            sql.ShouldNotContain(UnrestrictedPersonLandingSql);

            // The row-goal hint ODS-6862 added for the resource endpoints is deliberately not applied here:
            // suppressing the row goal was measured on this path and changed nothing.
            sql.ShouldNotContain(SqlServerDialect.PersonOnlyAuthorizationQueryHint);
        }

        [Test]
        public void Should_land_one_table_per_tracked_changes_column_over_the_same_view()
        {
            // A resource can carry two role-named references to one person type, which resolve to one view but two
            // tracked changes columns. Naming the landed table for the view alone would have both statements target
            // one table, and the second would silently replace the first's contents with a set restricted on the
            // wrong column. That is a wrong authorization result rather than an error.
            var resource = _resourceModel.GetResourceByFullName(ResourceFullName);

            var queryBuilder = CreateTrackedChangesQueryBuilder(new SqlServerDialect());

            queryBuilder.OrWhere(
                nestedQueryBuilder =>
                {
                    ApplyFilter(nestedQueryBuilder, resource, PersonFilterName, "StudentUSI", 0, useOuterJoins: true);
                    ApplyFilter(nestedQueryBuilder, resource, PersonFilterName, "AlternateStudentUSI", 1, useOuterJoins: true);

                    return nestedQueryBuilder;
                });

            string sql = queryBuilder.BuildTemplate().RawSql;

            string firstTable = SqlServerDialect.GetAuthPersonsTempTableName(
                PersonViewName,
                DeletesRestriction.ForPersonColumn("OldStudentUSI"));

            string secondTable = SqlServerDialect.GetAuthPersonsTempTableName(
                PersonViewName,
                DeletesRestriction.ForPersonColumn("OldAlternateStudentUSI"));

            firstTable.ShouldNotBe(secondTable);

            sql.ShouldContain($"CREATE TABLE {firstTable} ");
            sql.ShouldContain($"CREATE TABLE {secondTable} ");
            sql.ShouldContain($"EXISTS (SELECT 1 FROM {firstTable} AS ap0");
            sql.ShouldContain($"EXISTS (SELECT 1 FROM {secondTable} AS ap1");
        }

        [Test]
        public void Should_restrict_using_the_base_property_for_a_derived_resource()
        {
            // A derived resource reads its base entity's tracked changes table, and the subject endpoint resolves to
            // the base property. The restriction has to pair that column with that table, and this is the only test
            // that runs the derived branch at all.
            var resource = _resourceModel.GetResourceByFullName("edfi.studentCTEProgramAssociation");

            var queryBuilder = CreateTrackedChangesQueryBuilder(
                new SqlServerDialect(),
                new TrackedChangesRestriction(
                    "tracked_changes_edfi.GeneralStudentProgramAssociation",
                    ChangeKindColumnName,
                    selectsNewValues: false));

            queryBuilder.Where(
                nestedQueryBuilder =>
                {
                    ApplyFilter(nestedQueryBuilder, resource, PersonFilterName, "StudentUSI", 0, useOuterJoins: false);

                    return nestedQueryBuilder;
                });

            string sql = queryBuilder.BuildTemplate().RawSql;

            sql.ShouldContain(
                "EXISTS (SELECT 1 FROM tracked_changes_edfi.GeneralStudentProgramAssociation AS tc"
                + " WHERE tc.OldStudentUSI = av.StudentUSI");
        }

        [TestCase(false, "IS NULL", TestName = "Should_restrict_a_deletes_query_to_the_rows_with_no_new_key_values")]
        [TestCase(true, "IS NOT NULL", TestName = "Should_restrict_a_key_changes_query_to_the_rows_with_new_key_values")]
        public void Should_carry_the_change_kind_into_the_restriction(bool selectsNewValues, string expectedPredicate)
        {
            // Deletes and key changes read the same table and are told apart only here. Without the change kind, a
            // table holding only deletes looks like work to a key changes query that will discard every one of
            // those rows.
            var resource = _resourceModel.GetResourceByFullName(ResourceFullName);

            var queryBuilder = CreateTrackedChangesQueryBuilder(
                new SqlServerDialect(),
                new TrackedChangesRestriction(TrackedChangesTableName, ChangeKindColumnName, selectsNewValues));

            queryBuilder.Where(
                nestedQueryBuilder =>
                {
                    ApplyFilter(nestedQueryBuilder, resource, PersonFilterName, "StudentUSI", 0, useOuterJoins: false);

                    return nestedQueryBuilder;
                });

            string sql = queryBuilder.BuildTemplate().RawSql;

            sql.ShouldContain($"AND tc.{ChangeKindColumnName} {expectedPredicate})");
        }

        [Test]
        public void Should_land_the_whole_expansion_when_the_tracked_changes_table_is_not_known()
        {
            // Falling back is what keeps the filter usable by any future caller that does not record its table.
            var resource = _resourceModel.GetResourceByFullName(ResourceFullName);

            var queryBuilder = CreateTrackedChangesQueryBuilder(new SqlServerDialect(), restriction: null);

            queryBuilder.Where(
                nestedQueryBuilder =>
                {
                    ApplyFilter(nestedQueryBuilder, resource, PersonFilterName, "StudentUSI", 0, useOuterJoins: false);

                    return nestedQueryBuilder;
                });

            string sql = queryBuilder.BuildTemplate().RawSql;

            sql.ShouldContain(UnrestrictedPersonLandingSql);
            sql.ShouldNotContain("AS tc WHERE");
        }

        [TestCase(true, TestName = "Should_bind_the_claims_parameter_on_the_person_path_using_outer_joins")]
        [TestCase(false, TestName = "Should_bind_the_claims_parameter_on_the_person_path_using_inner_joins")]
        public void Should_bind_the_claims_parameter_on_the_person_path(bool useOuterJoins)
        {
            // This path returns before the WhereIn that used to register the table-valued parameter, so the only
            // registration left is the one carried by the landing statement. Nothing else in the query references
            // it, and asserting the SQL alone would not notice it going missing.
            var template = BuildTrackedChangesTemplate(new SqlServerDialect(), PersonFilterName, "StudentUSI", useOuterJoins);

            var parameters = template.Parameters as DynamicParameters;

            parameters.ShouldNotBeNull();
            parameters.ParameterNames.ShouldContain(RelationshipAuthorizationConventions.ClaimsParameterName);
        }

        [Test]
        public void Should_build_the_person_expansion_landing_statement()
        {
            // Pinned as a literal rather than against the generator, so a change to the emitted statement shows up
            // as a diff in review instead of passing because both sides moved together.
            SqlServerDialect.GetAuthPersonsTempTableLandingSql(
                    PersonViewName,
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    "StudentUSI",
                    DeletesRestriction.ForPersonColumn(TrackedChangesPersonColumn))
                .ShouldBe(
                    "DROP TABLE IF EXISTS #AuthEducationOrganizationIdToStudentUSI_OldStudentUSI; "
                    + "CREATE TABLE #AuthEducationOrganizationIdToStudentUSI_OldStudentUSI (StudentUSI INT PRIMARY KEY); "
                    + "INSERT INTO #AuthEducationOrganizationIdToStudentUSI_OldStudentUSI (StudentUSI) SELECT DISTINCT av.StudentUSI "
                    + "FROM auth.EducationOrganizationIdToStudentUSI AS av "
                    + "WHERE av.SourceEducationOrganizationId IN (SELECT Id FROM #ClaimEdOrgIds) "
                    + "AND EXISTS (SELECT 1 FROM tracked_changes_edfi.StudentSectionAssociation AS tc "
                    + "WHERE tc.OldStudentUSI = av.StudentUSI AND tc.NewBeginDate IS NULL);");
        }

        [Test]
        public void Should_build_the_unrestricted_person_expansion_landing_statement()
        {
            SqlServerDialect.GetAuthPersonsTempTableLandingSql(
                    PersonViewName,
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    "StudentUSI")
                .ShouldBe(
                    "DROP TABLE IF EXISTS #AuthEducationOrganizationIdToStudentUSI; "
                    + "CREATE TABLE #AuthEducationOrganizationIdToStudentUSI (StudentUSI INT PRIMARY KEY); "
                    + "INSERT INTO #AuthEducationOrganizationIdToStudentUSI (StudentUSI) SELECT DISTINCT av.StudentUSI "
                    + "FROM auth.EducationOrganizationIdToStudentUSI AS av "
                    + "WHERE av.SourceEducationOrganizationId IN (SELECT Id FROM #ClaimEdOrgIds);");
        }

        [TestCase(PersonFilterName, "StudentUSI", TestName = "Should_land_nothing_for_an_empty_claim_on_a_person_filter")]
        [TestCase(EducationOrganizationFilterName, "SchoolId", TestName = "Should_land_nothing_for_an_empty_claim_on_an_education_organization_filter")]
        public void Should_land_nothing_when_the_claim_list_is_empty(string filterName, string subjectEndpointName)
        {
            var resource = _resourceModel.GetResourceByFullName(ResourceFullName);

            var queryBuilder = CreateTrackedChangesQueryBuilder(new SqlServerDialect());

            queryBuilder.Where(
                nestedQueryBuilder =>
                {
                    ApplyFilter(nestedQueryBuilder, resource, filterName, subjectEndpointName, 0, useOuterJoins: false, claimValues: []);

                    return nestedQueryBuilder;
                });

            string sql = queryBuilder.BuildTemplate().RawSql;

            // An empty claim authorizes nothing, so there is nothing to land and the dialect short circuits.
            sql.ShouldContain("1 = 0");
            sql.ShouldNotContain(SqlServerDialect.ClaimsTempTableName);
            sql.ShouldNotContain(SqlServerDialect.GetAuthPersonsTempTableName(PersonViewName));
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
            return BuildTrackedChangesTemplate(dialect, filterName, subjectEndpointName, useOuterJoins).RawSql;
        }

        private SqlBuilder.Template BuildTrackedChangesTemplate(Dialect dialect, string filterName, string subjectEndpointName, bool useOuterJoins)
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

            return queryBuilder.BuildTemplate();
        }

        private static QueryBuilder CreateTrackedChangesQueryBuilder(Dialect dialect)
        {
            return CreateTrackedChangesQueryBuilder(dialect, DeletesRestriction);
        }

        private static QueryBuilder CreateTrackedChangesQueryBuilder(Dialect dialect, TrackedChangesRestriction restriction)
        {
            var queryBuilder = new QueryBuilder(dialect);

            queryBuilder.From($"{TrackedChangesTableName} AS {ChangeQueriesDatabaseConstants.TrackedChangesAlias}");
            queryBuilder.Select($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.*");

            if (restriction != null)
            {
                queryBuilder.Context.SetTrackedChangesRestriction(restriction);
            }

            return queryBuilder;
        }

        private static void ApplyFilter(
            QueryBuilder queryBuilder,
            Resource resource,
            string filterName,
            string subjectEndpointName,
            int filterIndex,
            bool useOuterJoins,
            object[] claimValues = null)
        {
            var filterDefinition = GetFilterDefinition(filterName);

            var filterContext = new AuthorizationFilterContext
            {
                FilterName = filterName,
                SubjectEndpointName = subjectEndpointName,
                ClaimParameterName = RelationshipAuthorizationConventions.ClaimsParameterName,
                ClaimEndpointValues = claimValues ?? ClaimValues
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
