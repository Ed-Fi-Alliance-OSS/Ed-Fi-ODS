// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries.Criteria;

/// <summary>
/// Applies criteria to a query based on identification codes property values
/// </summary>
public class IdentificationCodeAggregateQueryCriteriaApplicator : IAggregateRootQueryCriteriaApplicator
{
    private readonly IDescriptorResolver _descriptorResolver;
    private readonly IEntityIdentificationCodeQueryablePropertiesProvider _entityIdentificationCodeQueryablePropertiesProvider;
    private readonly DatabaseEngine _databaseEngine;

    private const string IdentificationCodeTableAlias = "idct";
    private readonly ConcurrentDictionary<FullName, Join> _identificationCodeTableJoinByRootEntityName = new();

    public IdentificationCodeAggregateQueryCriteriaApplicator(
        IDescriptorResolver descriptorResolver,
        IEntityIdentificationCodeQueryablePropertiesProvider entityIdentificationCodeQueryablePropertiesProvider,
        DatabaseEngine databaseEngine)
    {
        _descriptorResolver = descriptorResolver;
        _entityIdentificationCodeQueryablePropertiesProvider = entityIdentificationCodeQueryablePropertiesProvider;
        _databaseEngine = databaseEngine;
    }

    public void ApplyAdditionalParameters(QueryBuilder queryBuilder, Entity entity, AggregateRootWithCompositeKey specification,
        IDictionary<string, string> additionalParameters)
    {
        if (additionalParameters == null || !additionalParameters.Any())
            return;

        // If the entity does not have an identificationCodes collection with queryable properties, return
        if (!_entityIdentificationCodeQueryablePropertiesProvider.TryGetIdentificationCodePropertiesByParameterName(
                entity, out Dictionary<string, EntityProperty> identificationCodePropertiesByParameterName))
            return;

        // Find any supplied additionalParameters with a non-default value and name matching that of a queryable identificationCode property, if none then return
        var applicableAdditionalParameters = additionalParameters
            .Where(x => !x.Value.IsDefaultValue() && identificationCodePropertiesByParameterName.ContainsKey(x.Key))
            .ToArray();

        if (applicableAdditionalParameters.Length == 0)
            return;

        var identificationCodeTableJoin =
            GetIdentificationCodeEntityTableJoin(identificationCodePropertiesByParameterName.Values.First().Entity);

        queryBuilder.Join(identificationCodeTableJoin.TableName, _ => identificationCodeTableJoin);

        ApplyParameterValuesToQueryBuilder(
            queryBuilder, applicableAdditionalParameters, identificationCodePropertiesByParameterName);
    }

    private void ApplyParameterValuesToQueryBuilder(QueryBuilder queryBuilder,
        IEnumerable<KeyValuePair<string, string>> parameterValuesByName,
        IDictionary<string, EntityProperty> identificationCodePropertiesByParameter)
    {
        foreach (KeyValuePair<string, string> parameterKeyValuePair in parameterValuesByName)
        {
            if (!identificationCodePropertiesByParameter.TryGetValue(parameterKeyValuePair.Key, out var property))
            {
                continue;
            }

            var queryParameterValue = GetQueryParameterValueForProperty(property, parameterKeyValuePair.Value);

            if (property.IsDescriptorUsage && queryParameterValue == null)
            {
                // Descriptor did not match any value -- criteria should exclude all entries
                // Since no additional criteria need to be applied, exit the loop
                queryBuilder.WhereRaw("1 = 0");
                break;
            }

            queryBuilder.Where($"{IdentificationCodeTableAlias}.{property.PropertyName}", queryParameterValue);
        }

        return;

        object GetQueryParameterValueForProperty(EntityProperty property, string parameterValue)
        {
            if (!property.IsDescriptorUsage)
            {
                return parameterValue;
            }

            var lookupId = _descriptorResolver.GetDescriptorId(property.DescriptorEntity.Name, parameterValue);

            return lookupId == 0
                ? null
                : lookupId;
        }
    }

    private Join GetIdentificationCodeEntityTableJoin(Entity identificationCodeEntity)
    {
        return _identificationCodeTableJoinByRootEntityName.GetOrAdd(
            identificationCodeEntity.FullName, _ =>
            {
                string alias = identificationCodeEntity.IsDerived
                    ? "b"
                    : "r";

                var join = new Join(
                    $"{identificationCodeEntity.Schema}.{identificationCodeEntity.TableName(_databaseEngine)}"
                        .Alias(IdentificationCodeTableAlias));

                foreach (var entityIdentificationCodePropertyColumnName in GetIdentificationCodeEntityTableJoinColumnNames(
                             identificationCodeEntity, _databaseEngine))
                {
                    join.On(
                        $"{alias}.{entityIdentificationCodePropertyColumnName}",
                        $"{IdentificationCodeTableAlias}.{entityIdentificationCodePropertyColumnName}");
                }

                return join;
            });

        IEnumerable<string> GetIdentificationCodeEntityTableJoinColumnNames(Entity identificationCodeEntity,
            DatabaseEngine databaseEngine)
        {
            return identificationCodeEntity.Identifier.Properties
                .Where(p => p.IsFromParent && p.IsIdentifying)
                .Select(p => p.ColumnName(databaseEngine, p.PropertyName));
        }
    }
}
