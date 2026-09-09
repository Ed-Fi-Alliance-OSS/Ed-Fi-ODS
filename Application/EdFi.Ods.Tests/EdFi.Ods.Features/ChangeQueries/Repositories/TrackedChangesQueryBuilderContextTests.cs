// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Features.ChangeQueries.Repositories;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ChangeQueries.Repositories
{
    /// <summary>
    /// The authorization filters restrict what they materialize to the rows the change query is about, and they learn
    /// those rows through the query builder context. When the restriction does not arrive the filters fall back to
    /// landing the client's entire authorized population, which is correct but is the cost the restriction exists to
    /// remove, and it fails as a slow query rather than as an error. These tests hold the producing end of that
    /// contract.
    /// </summary>
    [TestFixture]
    public class TrackedChangesQueryBuilderContextTests
    {
        // A resource whose identifier carries a person, so the deletes factory takes its USI translation branch and
        // returns an outer query builder that is not the one the restriction was first recorded on.
        private const string PersonKeyedResource = "edfi.studentSectionAssociation";

        // A resource with no person in its identifier, so the deletes factory returns the base query builder itself.
        private const string EducationOrganizationKeyedResource = "edfi.section";

        private IResourceModel _resourceModel;
        private SqlServerDatabaseNamingConvention _namingConvention;

        [SetUp]
        public void SetUp()
        {
            _resourceModel = DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();
            _namingConvention = new SqlServerDatabaseNamingConvention();
        }

        [TestCase(PersonKeyedResource, "tracked_changes_edfi.StudentSectionAssociation", "NewBeginDate")]
        [TestCase(EducationOrganizationKeyedResource, "tracked_changes_edfi.Section", "NewLocalCourseCode")]
        public void Deletes_should_record_the_restriction_on_the_returned_query_builder(
            string resourceFullName,
            string expectedTableName,
            string expectedChangeKindColumnName)
        {
            var queryBuilder = CreateDeletedItemsQueryBuilderFactory()
                .CreateQueryBuilder(_resourceModel.GetResourceByFullName(resourceFullName));

            queryBuilder.Context.TryGetTrackedChangesRestriction(out var restriction).ShouldBeTrue();

            restriction.TableName.ShouldBe(expectedTableName);
            restriction.ChangeKindColumnName.ShouldBe(expectedChangeKindColumnName);
            restriction.SelectsNewValues.ShouldBeFalse();
        }

        [TestCase(PersonKeyedResource, "tracked_changes_edfi.StudentSectionAssociation", "NewBeginDate")]
        [TestCase(EducationOrganizationKeyedResource, "tracked_changes_edfi.Section", "NewLocalCourseCode")]
        public void Key_changes_should_record_the_restriction_on_the_returned_query_builder(
            string resourceFullName,
            string expectedTableName,
            string expectedChangeKindColumnName)
        {
            var queryBuilder = new KeyChangesQueryBuilderFactory(_namingConvention, CreateQueryBuilder)
                .CreateQueryBuilder(_resourceModel.GetResourceByFullName(resourceFullName));

            queryBuilder.Context.TryGetTrackedChangesRestriction(out var restriction).ShouldBeTrue();

            restriction.TableName.ShouldBe(expectedTableName);
            restriction.ChangeKindColumnName.ShouldBe(expectedChangeKindColumnName);
            restriction.SelectsNewValues.ShouldBeTrue();
        }

        [Test]
        public void Deletes_and_key_changes_should_record_opposite_change_kinds_for_the_same_resource()
        {
            // The two endpoints read the same table and are told apart only by this flag. If they ever agreed, one of
            // them would be restricting its expansion to the other's rows.
            var resource = _resourceModel.GetResourceByFullName(PersonKeyedResource);

            CreateDeletedItemsQueryBuilderFactory().CreateQueryBuilder(resource)
                .Context.TryGetTrackedChangesRestriction(out var deletesRestriction);

            new KeyChangesQueryBuilderFactory(_namingConvention, CreateQueryBuilder).CreateQueryBuilder(resource)
                .Context.TryGetTrackedChangesRestriction(out var keyChangesRestriction);

            deletesRestriction.ChangeKindColumnName.ShouldBe(keyChangesRestriction.ChangeKindColumnName);
            deletesRestriction.SelectsNewValues.ShouldBeFalse();
            keyChangesRestriction.SelectsNewValues.ShouldBeTrue();
        }

        [Test]
        public void Should_carry_the_context_across_the_clone_the_factories_hand_out()
        {
            // The factories cache one builder per resource and return a clone of it, so a clone that dropped the
            // context would leave every request after the first without the restriction.
            var factory = CreateDeletedItemsQueryBuilderFactory();
            var resource = _resourceModel.GetResourceByFullName(PersonKeyedResource);

            factory.CreateQueryBuilder(resource);

            var second = factory.CreateQueryBuilder(resource);

            second.Context.TryGetTrackedChangesRestriction(out _).ShouldBeTrue();
        }

        private DeletedItemsQueryBuilderFactory CreateDeletedItemsQueryBuilderFactory()
        {
            return new DeletedItemsQueryBuilderFactory(
                _namingConvention,
                new TrackedChangesIdentifierProjectionsProvider(_namingConvention),
                CreateQueryBuilder,
                indexer => new QueryBuilder(new SqlServerDialect(), indexer));
        }

        private static QueryBuilder CreateQueryBuilder() => new(new SqlServerDialect());
    }
}
