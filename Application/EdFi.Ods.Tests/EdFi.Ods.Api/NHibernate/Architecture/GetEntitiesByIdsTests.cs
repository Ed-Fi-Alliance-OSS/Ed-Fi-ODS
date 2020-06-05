// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.Activities;
using EdFi.Ods.Api.Common.Infrastructure.Repositories;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.EdFi;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NHibernate;
using NHibernate.Context;
using NHibernate.Engine;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.NHibernate.Architecture
{
    [TestFixture]
    public class GetEntitiesByIds : LegacyTestFixtureBase
    {
        public class When_getting_entities_by_ids_and_the_aggregate_root_is_derived
            : TestFixtureBase
        {
            private ISessionFactoryImplementor _sessionFactory;
            private IDomainModelProvider _domainModelProvider;

            private readonly List<string> _actualHqlQueries = new List<string>();
            private IParameterListSetter _parameterListSetter;

            protected override void Arrange()
            {
                _domainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;

                _sessionFactory = GetSessionFactoryStub<School>(_actualHqlQueries);

                _parameterListSetter = Stub<IParameterListSetter>();
            }

            protected override void Act()
            {
                var getEntitiesByIds = new GetEntitiesByIds<School>(
                    _sessionFactory,
                    _domainModelProvider,
                    _parameterListSetter);

                getEntitiesByIds.GetByIdsAsync(
                    new[]
                    {
                        Guid.NewGuid()
                    },
                    CancellationToken.None)
                    .GetResultSafely();
            }

            [Assert]
            public void Should_generate_a_query_for_the_top_level_entity_with_reference_data_filtered_by_id()
            {
                Assert.That(
                    _actualHqlQueries.First(),
                    Is.EqualTo($"from {typeof(School).FullName} a" +
                        $" left join fetch a.LocalEducationAgencyReferenceData b" +
                        $" left join fetch a.CharterApprovalSchoolYearTypeReferenceData c" +
                        $" where a.Id = :id"));
            }

            [Assert]
            public void Should_generate_a_query_for_each_child_entity_type_in_the_aggregate()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<School>();

                var aggregateChildEntities = entity.Aggregate.Members
                                                   .Concat(entity.BaseEntity.Aggregate.Members)
                                                   .Where(e => !e.IsAggregateRoot)
                                                   .ToList();

                var expectedQueries = aggregateChildEntities
                                     .Select(e => GetExpectedQuery(e, entity.Aggregate))
                                     .OrderBy(x => x)
                                     .ToList();

                var expectedHqlQueriesText = string.Join("\r\n", expectedQueries);
                var actualHqlQueriesText = string.Join("\r\n", _actualHqlQueries.Skip(1).OrderBy(x => x));

                Assert.That(
                    actualHqlQueriesText,
                    Is.EqualTo(expectedHqlQueriesText),
                    $@"Expected:
{expectedHqlQueriesText}
Actual:
{actualHqlQueriesText}");
            }

            [Assert]
            public void Should_generate_queries_for_all_inherited_child_types()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<School>();

                var inheritedAggregateEntities = entity.BaseEntity.Aggregate.Members.Where(e => !e.IsAggregateRoot);

                var assertions = inheritedAggregateEntities
                                .Select<Entity, Action>(
                                     e => () => Assert.That(_actualHqlQueries.Any(hql => hql.Contains("." + e.ParentAssociation.Name))))
                                .ToArray();

                AssertHelper.All(assertions);
            }
        }

        public class When_getting_entities_by_ids_and_aggregate_extension_collections_exist_in_the_aggregate : LegacyTestFixtureBase
        {
            private ISessionFactoryImplementor _sessionFactory;
            private IDomainModelProvider _domainModelProvider;
            private IParameterListSetter _parameterListSetter;

            private readonly List<string> _actualHqlQueries = new List<string>();

            protected override void Arrange()
            {
                _domainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;

                _sessionFactory = GetSessionFactoryStub<Student>(_actualHqlQueries);

                _parameterListSetter = Stub<IParameterListSetter>();
            }

            protected override void Act()
            {
                var getEntitiesByIds = new GetEntitiesByIds<Student>(
                    _sessionFactory,
                    _domainModelProvider,
                    _parameterListSetter);

                getEntitiesByIds.GetByIdsAsync(
                    new[]
                    {
                        Guid.NewGuid()
                    },
                    CancellationToken.None)
                    .GetResultSafely();
            }

            [Assert]
            public void Should_generate_a_query_for_the_top_level_entity_filtered_by_id()
            {
                Assert.That(
                    _actualHqlQueries.First(),
                    Is.EqualTo($"from {typeof(Student).FullName} a left join fetch a.PersonReferenceData b where a.Id = :id"));
            }

            [Assert]
            public void Should_generate_a_query_for_each_child_entity_type_in_the_aggregate()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<Student>();

                var aggregateChildEntities = entity.Aggregate
                                                   .Members
                                                   .Where(e => !e.IsAggregateRoot)
                                                   .ToList();

                var expectedQueries = aggregateChildEntities
                                     .Select(GetExpectedQuery)
                                     .OrderBy(x => x)
                                     .ToList();

                var expectedHqlQueriesText = string.Join("\r\n", expectedQueries);
                var actualHqlQueriesText = string.Join("\r\n", _actualHqlQueries.Skip(1).OrderBy(x => x));

                Assert.That(
                    actualHqlQueriesText,
                    Is.EqualTo(expectedHqlQueriesText));
            }

            [Assert]
            public void Should_generate_queries_for_aggregate_extensions()
            {
                Assert.That(_actualHqlQueries.Any(hql => hql.Contains(".AggregateExtensions.")));
            }
        }

        public class When_getting_entities_by_ids_and_deeply_nested_child_collections_exist_in_the_aggregate : LegacyTestFixtureBase
        {
            private ISessionFactoryImplementor _sessionFactory;
            private IDomainModelProvider _domainModelProvider;
            private IParameterListSetter _parameterListSetter;

            private readonly List<string> _actualHqlQueries = new List<string>();

            protected override void Arrange()
            {
                _domainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;

                // NOTE: To find third-level (or greater) entities in the domain model, use the following code:
                // var grandChildEntities = _domainModelProvider.GetDomainModel().Entities.Where(e => e.Parent != null && e.Parent != e.Aggregate.AggregateRoot).ToList();
                // Console.WriteLine("Grandchild Entities: " + string.Join(", ", grandChildEntities.Select(x => x.FullName)));

                _sessionFactory = GetSessionFactoryStub<StudentEducationOrganizationAssociation>(_actualHqlQueries);

                _parameterListSetter = Stub<IParameterListSetter>();
            }

            protected override void Act()
            {
                var getEntitiesByIds = new GetEntitiesByIds<StudentEducationOrganizationAssociation>(
                    _sessionFactory,
                    _domainModelProvider,
                    _parameterListSetter);

                getEntitiesByIds.GetByIdsAsync(
                    new[]
                    {
                        Guid.NewGuid()
                    },
                    CancellationToken.None)
                    .GetResultSafely();
            }

            [Assert]
            public void Should_generate_a_query_for_each_entity_in_the_aggregate()
            {
                var domainModel = _domainModelProvider.GetDomainModel();
                var entity = domainModel.GetEntity<StudentEducationOrganizationAssociation>();

                var aggregateChildEntities = entity.Aggregate
                                                   .Members
                                                   .ToList();

                var expectedQueries = aggregateChildEntities
                                     .Select(GetExpectedQuery)
                                     .ToList();

                Assert.That(
                    _actualHqlQueries.OrderBy(x => x.Length),
                    Is.EquivalentTo(expectedQueries.OrderBy(x => x.Length)));
            }

            [Assert]
            public void Should_include_left_joins_for_obtaining_reference_data()
            {
                Assert.That(
                    _actualHqlQueries.Any(hql =>
                    Regex.IsMatch(hql, "left join fetch [a-z]{1,2}\\.\\w+ReferenceData")),
                    "No joins for reference data were found in the aggregate's HQL statements.");
            }

            [Assert]
            public void Should_generate_the_query_for_the_aggregate_root_as_the_first_query_in_the_batch()
            {
                Assert.That(
                    _actualHqlQueries.First(),
                    Is.EqualTo($"from {typeof(StudentEducationOrganizationAssociation).FullName} a " +
                               $"left join fetch a.EducationOrganizationReferenceData b " +
                               $"left join fetch a.StudentReferenceData c " +
                               $"where a.Id = :id"));
            }

            [Assert]
            public void Should_include_queries_for_parent_entities_before_their_children_so_that_NHibernate_does_not_perform_lazy_loading()
            {
                var domainModel = _domainModelProvider.GetDomainModel();

                var queryIndexByChildEntityName = _actualHqlQueries
                    // Skip the aggregate root query
                    .Skip(1)
                    // Use Regex to match the child entity collection names from the HQL
                    .Select(
                         (hql, i) =>
                             new
                             {
                                 Index = i,
                                 Matches = Regex.Matches(
                                     hql, "left join fetch [a-z]{1,2}\\.(?<EntityCollection>\\w+(?<!ReferenceData)) ")
                             })
                    // Extract the child entity name from the HQL
                    .Select(
                         x =>
                             new
                             {
                                 Index = x.Index,
                                 EntityName = CompositeTermInflector.MakeSingular(
                                     x.Matches[x.Matches.Count - 1]
                                      .Groups["EntityCollection"]
                                      .Value),
                             }
                    )
                    // Create a map of query indices by child entity name
                    .ToDictionary(x => x.EntityName, x => x.Index);

                var aggregateFullName = new FullName(EdFiConventions.PhysicalSchemaName, "StudentEducationOrganizationAssociation");

                Aggregate aggregate = domainModel.AggregateByName[aggregateFullName];
                var aggregateRoot = aggregate.AggregateRoot;
                var aggregateChildEntities = aggregate.Members.Except(new[] { aggregateRoot });

                // Assign the aggregate root to the known index (asserted by previous test)
                queryIndexByChildEntityName[aggregateRoot.Name] = 0;

                // Ensure that all child entity queries appear AFTER their parent's query in the batch
                // This prevents N+1 behavior where NHibernate performs lazy loading on child records
                Assert.That(
                    aggregateChildEntities
                       .Where(childEntity => queryIndexByChildEntityName[childEntity.Name] < queryIndexByChildEntityName[childEntity.Parent.Name])
                       .Select(childEntity => childEntity.FullName),
                    Is.Empty,
                    "Queries for some child entities in the aggregate appeared before their parents in the batch. This will cause NHibernate to perform lazy loading (i.e. the ORM \"n+1\" issue), breaking the optimized query batch behavior.");
            }
        }

        private class FakeFutureEnumerable<TEntity> : IFutureEnumerable<TEntity>
        {
            public Task<IEnumerable<TEntity>> GetEnumerableAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                return Task.FromResult(Enumerable.Empty<TEntity>());
            }

            public IEnumerable<TEntity> GetEnumerable()
            {
                return Enumerable.Empty<TEntity>();
            }

            IEnumerator<TEntity> IFutureEnumerable<TEntity>.GetEnumerator()
            {
                return Enumerable.Empty<TEntity>()
                                 .GetEnumerator();
            }

            IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
            {
                return Enumerable.Empty<TEntity>()
                                 .GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Enumerable.Empty<TEntity>()
                                 .GetEnumerator();
            }
        }

        private static ISessionFactoryImplementor GetSessionFactoryStub<TEntity>(List<string> queries)
        {
            var sessionFactoryStub = A.Fake<ISessionFactoryImplementor>();

            var sessionStub = A.Fake<ISession>();

            var queryStub = A.Fake<IQuery>();

            A.CallTo(() => sessionStub.SessionFactory)
                       .Returns(sessionFactoryStub);

            A.CallTo(() => sessionStub.CreateQuery(A<string>._))
                .Invokes((string query) => { queries.Add(query); })
                       .Returns(queryStub);


            A.CallTo(() => sessionStub.IsOpen).Returns(true);

            A.CallTo(() => queryStub.SetParameter(A<string>._, A<Guid>._))
                     .Returns(queryStub);

            A.CallTo(() => queryStub.Future<TEntity>())
                     .Returns(new FakeFutureEnumerable<TEntity>());

            A.CallTo(() => sessionFactoryStub.OpenSession())
                              .Returns(sessionStub);

            A.CallTo(() => sessionFactoryStub.CurrentSessionContext)
                              .Returns(new ThreadStaticSessionContext(sessionFactoryStub));

            A.CallTo(() => sessionFactoryStub.GetCurrentSession())
                              .Returns(sessionStub);

            return sessionFactoryStub;
        }

        private static string GetExpectedQuery(Entity entity)
        {
            return GetExpectedQuery(entity, entity.Aggregate);
        }

        private static string GetExpectedQuery(Entity entity, Aggregate aggregate)
        {
            var associations = entity.AncestorsOrSelf.Select(e => e.ParentAssociation?.Inverse).Reverse().Skip(1).ToList();

            string[] aliases = { "a", "b", "c", "d", "e" };

            string query =
                $"from {GetEntityFullTypeName(aggregate.AggregateRoot)} a"
                // Add joins for aggregate root reference data
                + (entity == aggregate.AggregateRoot
                    ? string.Join("", aggregate.AggregateRoot.NonNavigableParents
                        .Where(a2 => a2.OtherEntity.IsReferenceable())
                        .Select((a2, i) => $" left join fetch a.{a2.OtherEntity.TypeHierarchyRootEntity.Name}ReferenceData {aliases[i+1]}"))
                    : string.Empty)
                + string.Join("", associations.Select(a =>
                                                           a.OtherEntity.IsAggregateExtension
                                                               ? $" left join fetch {aliases[GetDepth(a.ThisEntity)]}.AggregateExtensions.{a.GetAggregateExtensionBagName()} {aliases[GetDepth(a.OtherEntity)]}"
                                                               : $" left join fetch {aliases[GetDepth(a.ThisEntity)]}.{a.Name} {aliases[GetDepth(a.OtherEntity)]}"
                                                                // Add joins for reference data
                                                               + string.Join("", a.OtherEntity.NonNavigableParents
                                                                   .Where(a2 => a2.OtherEntity.IsReferenceable())
                                                                   .Select((a2, i) => $" left join fetch {aliases[GetDepth(a.OtherEntity)]}.{a2.OtherEntity.TypeHierarchyRootEntity.Name}ReferenceData {aliases[GetDepth(a.OtherEntity) + i + 1]}"))
                        ))
                + " where a.Id = :id";

            return query;
        }

        private static int GetDepth(Entity entity)
        {
            int depth = 0;

            while (entity.Parent != null)
            {
                entity = entity.Parent;
                depth++;
            }

            return depth;
        }

        private static string GetEntityFullTypeName(Entity entity) =>
            Namespaces.Entities.NHibernate.AggregateNamespaceForEntity(
                Namespaces.Entities.NHibernate.BaseNamespace,
                entity.Aggregate.Name,
                entity.SchemaProperCaseName()) + "." + entity.Name;
    }
}
