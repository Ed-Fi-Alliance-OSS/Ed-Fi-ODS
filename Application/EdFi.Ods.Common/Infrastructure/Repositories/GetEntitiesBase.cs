// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
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
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private readonly Lazy<List<string>> _aggregateHqlStatementsWithReferenceData;
        private readonly Lazy<List<string>> _aggregateHqlStatements;
        private readonly Lazy<string> _mainHqlStatementBaseWithReferenceData;
        private readonly Lazy<string> _mainHqlStatementBase;

        private readonly Dialect _dialect;
        private readonly DatabaseEngine _databaseEngine;
        protected readonly bool SerializationEnabled;
        private readonly bool _resourceLinksEnabled;

        // Holds pre-built HQL queries to avoid string allocations for each execution 
        private readonly ConcurrentDictionary<(bool needReferenceData, string whereClause, string orderByClause), string> _hqlByScenario = new ();
        private readonly ConcurrentDictionary<(bool needReferenceData, int childIndex, string whereClause), string> _childHqlByScenario = new();

        private QueryBuilder _queryBuilder;

        // Static members, not shared between concrete generic types
        private static readonly string _aggregateRootEntityTypeName = typeof(TEntity).FullName;

        protected GetEntitiesBase(
            ISessionFactory sessionFactory, 
            IDomainModelProvider domainModelProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IFeatureManager featureManager,
            Dialect dialect,
            DatabaseEngine databaseEngine)
            : base(sessionFactory)
        {
            SerializationEnabled = featureManager.IsFeatureEnabled(ApiFeature.SerializedData);
            _resourceLinksEnabled = featureManager.IsFeatureEnabled(ApiFeature.ResourceLinks);

            _dialect = dialect;
            _databaseEngine = databaseEngine;

            _domainModelProvider = domainModelProvider;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
            _aggregate = new Lazy<Aggregate>(() => dataManagementResourceContextProvider.Get().Resource.Entity.Aggregate);

            _aggregateHqlStatementsWithReferenceData = new Lazy<List<string>>(
                () => CreateAggregateHqlStatements(includeReferenceData: true), true);

            _aggregateHqlStatements = new Lazy<List<string>>(
                () => CreateAggregateHqlStatements(includeReferenceData: false), true);

            _mainHqlStatementBaseWithReferenceData = new Lazy<string>(() => GetMainHqlStatement(includeReferenceData: true), true);
            _mainHqlStatementBase = new Lazy<string>(() => GetMainHqlStatement(includeReferenceData: false), true);
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
            ArgumentNullException.ThrowIfNull(whereClause);

            // Determine if this is a Read or Write request (default to "read" behavior if context isn't available)
            string httpMethod = _dataManagementResourceContextProvider.Get()?.HttpMethod ?? HttpMethods.Get;

            bool needReferenceData = (httpMethod == HttpMethods.Get && _resourceLinksEnabled);
            bool isShallow = (httpMethod == HttpMethods.Delete);

            string mainHql = GetMainHql();

            using (new SessionScope(SessionFactory))
            {
                var query = Session.CreateQuery(mainHql);
                applyParameters(query);

                var futureEnumerable = query.Future<TEntity>();

                if (!isShallow)
                {
                    var aggregateStatements = needReferenceData
                        ? _aggregateHqlStatementsWithReferenceData.Value
                        : _aggregateHqlStatements.Value;

                    int childIndex = 0;
                    
                    foreach (string childBaseHql in aggregateStatements)
                    {
                        string childHql = GetChildHql(childIndex++, childBaseHql);
                        
                        var childQuery = Session.CreateQuery(childHql);
                        applyParameters(childQuery);
                        childQuery.Future<TEntity>();
                    }
                }

                return await futureEnumerable.GetEnumerableAsync(cancellationToken);
            }

            string GetMainHql()
            {
                return _hqlByScenario.GetOrAdd(
                    (needReferenceData, whereClause, orderByClause),
                    static (key, args) =>
                    {
                        string mainHqlBase = (key.needReferenceData)
                            ? args._mainHqlStatementBaseWithReferenceData.Value
                            : args._mainHqlStatementBase.Value;

                        return string.IsNullOrEmpty(key.orderByClause)
                            ? $"{mainHqlBase} {key.whereClause}"
                            : $"{mainHqlBase} {key.whereClause} {key.orderByClause}";
                    },
                    (_mainHqlStatementBaseWithReferenceData, _mainHqlStatementBase));
            }

            string GetChildHql(int childIndex, string childBaseHql)
            {
                string childHql = _childHqlByScenario.GetOrAdd(
                    (needReferenceData, childIndex, whereClause),
                    static (key, arg) => $"{arg}{key.whereClause}",
                    childBaseHql);

                return childHql;
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

                currentHqlQuery += $"left join fetch {HqlConstants.QueryAliases[parentAliasIndex]}.{hqlMemberPath} {HqlConstants.QueryAliases[currentAliasIndex]} ";

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
                    $"left join fetch {HqlConstants.QueryAliases[currentAliasIndex]}.{referenceHqlMemberPath} {HqlConstants.QueryAliases[referenceAliasIndex++]} ";
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

        protected QueryBuilder GetSingleItemQueryBuilder()
        {
            // Get the fully qualified physical table name
            Entity aggregateRootEntity = _aggregate.Value.AggregateRoot;
            string rootTableAlias = aggregateRootEntity.IsDerived ? "b" : "r";

            if (_queryBuilder != null)
            {
                return _queryBuilder.Clone();
            }

            var idQueryBuilder = new QueryBuilder(_dialect);

            var schemaTableName = $"{aggregateRootEntity.Schema}.{aggregateRootEntity.TableName(_databaseEngine)}";

            idQueryBuilder
                .From(schemaTableName.Alias("r"))
                .Select($"{rootTableAlias}.{ColumnNames.AggregateId}");

            if (SerializationEnabled)
            {
                idQueryBuilder
                    .Select($"{rootTableAlias}.{ColumnNames.AggregateData}")
                    .Select($"{rootTableAlias}.{ColumnNames.LastModifiedDate}");

                // Consider these could be refactored out into separate components
                if (aggregateRootEntity.IsPersonEntity())
                {
                    idQueryBuilder.Select($"{rootTableAlias}.{aggregateRootEntity.Name}Usi AS SurrogateId");
                }
                
                if (aggregateRootEntity.IsDescriptorEntity)
                {
                    idQueryBuilder.Select($"{rootTableAlias}.DescriptorId AS SurrogateId");
                }
            }

            // NOTE: Optimization opportunity - the derived entity may not be needed unless there is criteria to be applied that uses the derived type.
            // This would eliminate a join with every page. Will need to include Discriminator value in join in lieu of join to base.

            // Add the join to the base type
            if (aggregateRootEntity.IsDerived)
            {
                idQueryBuilder.Join(
                    $"{aggregateRootEntity.BaseEntity.Schema}.{aggregateRootEntity.BaseEntity.TableName(_databaseEngine)} AS b",
                    j =>
                    {
                        foreach (var propertyMapping in aggregateRootEntity.BaseAssociation.PropertyMappings)
                        {
                            j.On(
                                $"r.{propertyMapping.ThisProperty.ColumnNameByDatabaseEngine[_databaseEngine]}",
                                $"b.{propertyMapping.OtherProperty.ColumnNameByDatabaseEngine[_databaseEngine]}");
                        }

                        return j;
                    });
            }

            _queryBuilder = idQueryBuilder;

            return idQueryBuilder.Clone();
        }
    }

    internal static class HqlConstants
    {
        public static readonly string[] QueryAliases;

        static HqlConstants()
        {
            QueryAliases = new[] {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w",
                "x", "y", "z", "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj", "kk", "ll", "mm", "nn", "oo", "pp",
                "qq", "rr", "ss", "tt", "uu", "vv", "ww", "xx", "yy", "zz"
            };
        }
    }
}
