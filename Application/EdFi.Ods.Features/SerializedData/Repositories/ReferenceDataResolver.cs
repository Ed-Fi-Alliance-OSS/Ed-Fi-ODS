// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using log4net;
using NHibernate;

namespace EdFi.Ods.Features.SerializedData.Repositories;

public class ReferenceDataResolver : IReferenceDataResolver
{
    private readonly IContextProvider<ReferenceDataLookupContext> _referenceDataLookupContextProvider;
    private readonly Dialect _dialect;
    private readonly DatabaseEngine _databaseEngine;
    private readonly ISessionFactory _sessionFactory;
    private readonly DomainModel _domainModel;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ReferenceDataResolver));
    
    public ReferenceDataResolver(
        IDomainModelProvider domainModelProvider,
        IContextProvider<ReferenceDataLookupContext> referenceDataLookupContextProvider,
        Dialect dialect,
        DatabaseEngine databaseEngine,
        ISessionFactory sessionFactory)
    {
        _referenceDataLookupContextProvider = referenceDataLookupContextProvider;
        _dialect = dialect;
        _databaseEngine = databaseEngine;
        _sessionFactory = sessionFactory;
        _domainModel = domainModelProvider.GetDomainModel();
    }

    public async Task ResolveReferenceDataAsync()
    {
        var referenceDataLookupContext = _referenceDataLookupContextProvider.Get();

        // Quit now if there's no work to do
        if (referenceDataLookupContext.IsSuppressed() || !referenceDataLookupContext.Any())
        {
            return;
        }

        var resolvableReferenceDataItems = referenceDataLookupContext.Items
            .Where(rd => rd.IsFullyDefined())
            .ToList();

        // Quit now if there's no resolvable items
        if (!resolvableReferenceDataItems.Any())
        {
            return;
        }

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug($"Resolving {resolvableReferenceDataItems.Count} reference data items...");
        }

        var queryTemplates = GetQueryTemplates();

        using var scope = new SessionScope(_sessionFactory);
        var conn = scope.Session.Connection;

        StringBuilder sb = new StringBuilder();
        DynamicParameters parameters = null;
        int statementIndex = 0;
        int lastQueryIndex = -1;
        
        foreach ((int queryIndex, SqlBuilder.Template template) queryTemplate in queryTemplates)
        {
            // If the query index has advanced, resolve values, reset variables and continue
            if (queryTemplate.queryIndex > lastQueryIndex)
            {
                if (sb.Length > 0)
                {
                    // Execute the first query, resolve the values
                    await ResolveValuesAsync();
                }

                // Reinitialize variables for next query
                sb = sb.Clear();
                parameters = new DynamicParameters();
                statementIndex = 0;
                lastQueryIndex = queryTemplate.queryIndex;
            }

            // On the first statement of each query, skips the "UNION ALL" statement
            if (statementIndex++ > 0)
            {
                sb.AppendLine("UNION ALL");
            }

            // Add the statement's SQL and parameters
            sb.AppendLine(queryTemplate.template.RawSql);
            parameters!.AddDynamicParams(queryTemplate.template.Parameters);
        }

        if (sb.Length > 0)
        {
            await ResolveValuesAsync();
        }

        async Task ResolveValuesAsync()
        {
            var results = await conn.QueryAsync<ReferenceDataValues>(sb.ToString(), parameters);

            foreach (var result in results)
            {
                var referenceDataItem = resolvableReferenceDataItems[result.Idx];
                referenceDataItem.Id = result.Id;
                referenceDataItem.Discriminator = result.Discriminator;
            }
        }

        IEnumerable<(int queryIndex, SqlBuilder.Template template)> GetQueryTemplates()
        {
            int queryIndex = 0;
            
            var parameterNameByValue = new Dictionary<object, string>();

            for (int i = 0; i < resolvableReferenceDataItems.Count; i++)
            {
                var referenceData = resolvableReferenceDataItems[i];
                
                var entity = _domainModel.EntityByFullName[referenceData.FullName];
                
                var qb = GetQueryBuilder(entity);
                qb.Select(GetIdxSelect(i));
                
                var pks = referenceData.GetPrimaryKeyValues();

                // Can the current statement accommodate the parameters (based on DB engine/dialect)
                if (parameterNameByValue.Count + pks.Count > _dialect.GetMaxParameterCount())
                {
                    // Break the query into a new template
                    parameterNameByValue.Clear();
                    queryIndex++;
                }

                int parameterOrdinal = 1;

                foreach (DictionaryEntry pk in pks)
                {
                    string columnName = entity.PropertyByName[pk.Key.ToString()].ColumnNameByDatabaseEngine[_databaseEngine];

                    if (parameterNameByValue.TryGetValue(pk.Value, out string parameterName))
                    {
                        qb.WhereRaw($"{columnName} = {parameterName}");
                    }
                    else
                    {
                        parameterName = $"@p{parameterOrdinal++}_{i}";
                        parameterNameByValue.Add(pk.Value, parameterName);
                        qb.Where(columnName, pk.Value, parameterName);
                    }
                }

                yield return (queryIndex, qb.BuildTemplate());
            }
        }
    }

    private readonly ConcurrentDictionary<Entity, QueryBuilder> _queryBuilderByEntity = new();
    
    private readonly List<string> _idxSelects = new();

    private string GetIdxSelect(int index)
    {
        if (index >= _idxSelects.Count)
        {
            for (int i = _idxSelects.Count; i <= index; i++)
            {
                _idxSelects.Add($"{i} AS Idx");
            }
        }

        return _idxSelects[index];
    }
    
    private QueryBuilder GetQueryBuilder(Entity entity)
    {
        var baselineQueryBuilder = _queryBuilderByEntity.GetOrAdd(
            entity,
            e =>
            {
                string schemaName = entity.Schema;
                string tableName = entity.TableNameByDatabaseEngine[_databaseEngine];

                var qb = new QueryBuilder(_dialect).From($"{schemaName}.{tableName}");
                qb.Select("Id");

                if (entity.HasDiscriminator())
                {
                    qb.Select("Discriminator");
                }
                else
                {
                    qb.Select("NULL AS Discriminator");
                }

                return qb;
            });
        
        return baselineQueryBuilder.Clone();
    }

    private class ReferenceDataValues
    {
        public int Idx { get; set; }

        public Guid Id { get; set; }

        public string Discriminator { get; set; }
    }
}
