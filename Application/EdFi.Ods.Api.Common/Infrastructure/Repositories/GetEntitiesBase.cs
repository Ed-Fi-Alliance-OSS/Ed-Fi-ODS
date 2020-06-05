// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using NHibernate;
using NHibernate.Context;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    /// <summary>
    /// Provides a base class for implementing <see cref="NHibernateRepositoryOperationBase"/>-derived classes
    /// that need to load persistent entities using NHibernate, allowing them to use the HQL query batch optimization
    /// to load all data in a single round trip to the database.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of the aggregate root entity.</typeparam>
    public abstract class GetEntitiesBase<TEntity> : NHibernateRepositoryOperationBase
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly Lazy<Aggregate> _aggregate;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly Lazy<List<string>> _aggregateHqlStatementsForReads;
        private readonly Lazy<List<string>> _aggregateHqlStatementsForWrites;
        private readonly Lazy<string> _mainHqlStatementBaseForReads;
        private readonly Lazy<string> _mainHqlStatementBaseForWrites;

        // Authorization is optional configuration -- container will initialize this property if registered
        public IAuthorizationContextProvider AuthorizationContextProvider { get; set; }

        // Static members, not shared between concrete generic types
        private static readonly string _aggregateRootEntityTypeName = typeof(TEntity).FullName;

        private static readonly string[] _queryAliases =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w",
            "x", "y", "z", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp",
            "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"
        };

        protected GetEntitiesBase(
            ISessionFactory sessionFactory, 
            IDomainModelProvider domainModelProvider)
            : base(sessionFactory)
        {
            _domainModelProvider = domainModelProvider;
            _aggregate = new Lazy<Aggregate>(GetAggregate);

            _aggregateHqlStatementsForReads = new Lazy<List<string>>(
                () => CreateAggregateHqlStatements(includeReferenceData: true), true);

            _aggregateHqlStatementsForWrites = new Lazy<List<string>>(
                () => CreateAggregateHqlStatements(includeReferenceData: false), true);

            _mainHqlStatementBaseForReads = new Lazy<string>(() => GetMainHqlStatement(includeReferenceData: true), true);
            _mainHqlStatementBaseForWrites = new Lazy<string>(() => GetMainHqlStatement(includeReferenceData: false), true);
        }

        private string GetMainHqlStatement(bool includeReferenceData)
        {
            string referenceDataJoins = includeReferenceData
                ? GetReferenceDataJoinsHql(0, _aggregate.Value.AggregateRoot)
                : string.Empty;

            return $"from {_aggregateRootEntityTypeName} a {referenceDataJoins}".TrimEnd();
        }

        /// <summary>
        /// Get the aggregate results, applying the specified HQL where clause and optional order by clause,
        /// and applying parameters with the provided function.
        /// </summary>
        /// <param name="whereClause">The HQL where clause for the query.</param>
        /// <param name="applyParameters">The function that applies parameter values to the query.</param>
        /// <param name="orderByClause">An optional order by clause to be applied (for multi-record results).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An enumerable collection of hydrated aggregates.</returns>
        protected async Task<IEnumerable<TEntity>> GetAggregateResultsAsync(
            string whereClause,
            Action<IQuery> applyParameters,
            CancellationToken cancellationToken,
            string orderByClause = null)
        {
            // Determine if this is a Read or Write request (default to "read" behavior if authorization context isn't available)
            var action = AuthorizationContextProvider?.GetAction() ?? RequestActions.ReadActionUri;

            bool isReadRequest = (action == RequestActions.ReadActionUri);

            string mainHqlBase = isReadRequest
                ? _mainHqlStatementBaseForReads.Value
                : _mainHqlStatementBaseForWrites.Value;

            string mainHql = $"{mainHqlBase} {whereClause} {orderByClause}".TrimEnd();

            using (new SessionScope(SessionFactory))
            {
                var query = Session.CreateQuery(mainHql);
                applyParameters(query);

                var futureEnumerable = query.Future<TEntity>();

                var aggregateStatements = isReadRequest
                    ? _aggregateHqlStatementsForReads.Value
                    : _aggregateHqlStatementsForWrites.Value;

                foreach (string hql in aggregateStatements)
                {
                    var childQuery = Session.CreateQuery(hql + whereClause);
                    applyParameters(childQuery);
                    childQuery.Future<TEntity>();
                }

                return await futureEnumerable.GetEnumerableAsync(cancellationToken);
            }
        }

        private List<string> CreateAggregateHqlStatements(bool includeReferenceData)
        {
            var hqlStatements = new List<string>();

            var entity = _aggregate.Value.AggregateRoot;

            AddChildCollectionJoinQueries(
                hqlStatements,
                GetChildCollectionAssociations(entity), 
                ancestorHqlQuery: null, 
                aliasIndex: 0,
                includeReferenceData: includeReferenceData);

            return hqlStatements;
        }

        private static List<AssociationView> GetChildCollectionAssociations(Entity entity)
        {
            var associations = entity.ExtensionAssociations
                .Concat(entity.NavigableChildren)
                .Concat(entity.NavigableOneToOnes)
                .Concat(entity.InheritedNavigableChildren)
                .Concat(entity.InheritedNavigableOneToOnes)
                .ToList();

            return associations;
        }

        private static void AddChildCollectionJoinQueries(
            List<string> hqlStatements,
            List<AssociationView> associations,
            string ancestorHqlQuery,
            int aliasIndex,
            bool includeReferenceData)
        {
            int parentAliasIndex = aliasIndex;
            int currentAliasIndex = aliasIndex + 1;

            foreach (var association in associations)
            {
                string currentHqlQuery = ancestorHqlQuery ?? $"from {_aggregateRootEntityTypeName} a ";

                string hqlMemberPath = GetHqlMemberPath(association);

                currentHqlQuery += $"left join fetch {_queryAliases[parentAliasIndex]}.{hqlMemberPath} {_queryAliases[currentAliasIndex]} ";

                var childQueryBases = GetChildCollectionAssociations(association.OtherEntity);

                string referenceDataHql = includeReferenceData
                    ? GetReferenceDataJoinsHql(currentAliasIndex, association.OtherEntity)
                    : null;

                hqlStatements.Add(currentHqlQuery + referenceDataHql);

                if (childQueryBases.Any())
                {
                    AddChildCollectionJoinQueries(
                        hqlStatements,
                        childQueryBases,
                        currentHqlQuery,
                        currentAliasIndex,
                        includeReferenceData);
                }
            }
        }

        /// <summary>
        /// Gets HQL containing the necessary left joins to obtain reference data for building links for outbound resource models.
        /// </summary>
        /// <param name="currentAliasIndex"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static string GetReferenceDataJoinsHql(int currentAliasIndex, Entity entity)
        {
            int referenceAliasIndex = currentAliasIndex + 1;

            var referenceDataAssociations = entity.NonNavigableParents
              .Concat(entity.InheritedNonNavigableParents)
              .Where(a => a.OtherEntity.IsReferenceable());

            string referenceDataHql = null;

            foreach (var referenceDataAssociation in referenceDataAssociations)
            {
                string referenceHqlMemberPath = GetHqlMemberPath(referenceDataAssociation);

                referenceDataHql +=
                    $"left join fetch {_queryAliases[currentAliasIndex]}.{referenceHqlMemberPath} {_queryAliases[referenceAliasIndex++]} ";
            }

            return referenceDataHql;
        }

        private static string GetHqlMemberPath(AssociationView association)
        {
            string hqlMemberPath;

            if (association.OtherEntity.IsAggregateExtensionTopLevelEntity)
                hqlMemberPath = $"AggregateExtensions.{association.GetAggregateExtensionBagName()}";
            else if (association.AssociationType == AssociationViewType.ToExtension)
                hqlMemberPath = $"Extensions.{association.OtherEntity.SchemaProperCaseName()}";
            else if (!association.IsNavigable)
                hqlMemberPath = association.Name + "ReferenceData";
            else
                hqlMemberPath = association.Name;

            return hqlMemberPath;
        }

        private Aggregate GetAggregate()
        {
            string schema = typeof(TEntity).GetCustomAttribute<SchemaAttribute>().Schema;
            var fullName = new FullName(schema, typeof(TEntity).Name);

            Aggregate aggregate;

            if (!_domainModelProvider.GetDomainModel().AggregateByName.TryGetValue(fullName, out aggregate))
                throw new Exception($"Unable to find aggregate for '{fullName}'.");

            return aggregate;
        }
    }
}