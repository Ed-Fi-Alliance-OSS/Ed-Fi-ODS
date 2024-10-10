// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Criteria;

namespace EdFi.Ods.Common.Providers.Queries.Criteria;

/// <summary>
/// Applies criteria to a query based on identification codes property values
/// </summary>
public class IdentificationCodeAggregateQueryCriteriaApplicator : IAggregateRootQueryCriteriaApplicator
{
    private readonly IDescriptorResolver _descriptorResolver;
    private readonly DatabaseEngine _databaseEngine;
    private const string IdentificationCodeTableAlias = "idct";

    public IdentificationCodeAggregateQueryCriteriaApplicator(
        IDescriptorResolver descriptorResolver,
        DatabaseEngine databaseEngine)
    {
        _descriptorResolver = descriptorResolver;
        _databaseEngine = databaseEngine;
    }

    public void ApplyAdditionalParameters(QueryBuilder queryBuilder, Entity entity, AggregateRootWithCompositeKey specification,
        IDictionary<string, string> additionalParameters)
    {
        if (additionalParameters == null || !additionalParameters.Any() || additionalParameters.All(
                ap => AggregateRootCriteriaProviderHelpers.PropertiesToIgnore.Contains(ap.Key, StringComparer.OrdinalIgnoreCase)))
            return;

        var entityIdentificationCodeProperty = AggregateRootCriteriaProviderHelpers.FindIdentificationCodeProperty(entity);

        //If the entity does not have an identificationCodes collection, return
        if (entityIdentificationCodeProperty == null)
            return;

        string alias = entity.IsDerived
            ? "b"
            : "r";

        var identificationCodeTableJoin = CreateIdentificationCodeTableJoin(entityIdentificationCodeProperty, alias);
        queryBuilder.Join(identificationCodeTableJoin.TableName, _ => identificationCodeTableJoin, JoinType.LeftOuterJoin);

        ApplyParameterValuesToQueryBuilder(
            queryBuilder, additionalParameters, GetIdentificationCodeParameters(entityIdentificationCodeProperty));
    }

    private void ApplyParameterValuesToQueryBuilder(QueryBuilder queryBuilder, IDictionary<string, string> additionalParameters,
        IDictionary<string, EntityProperty> identificationCodeParameters)
    {
        foreach (KeyValuePair<string, string> parameter in additionalParameters)
        {
            if (identificationCodeParameters.TryGetValue(parameter.Key, out var property))
            {
                var queryParameterValue = GetQueryParameterValueForProperty(property, parameter.Value);

                if (property.IsDescriptorUsage && queryParameterValue == null)
                {
                    // Descriptor did not match any value -- criteria should exclude all entries
                    // Since no additional criteria need to be applied, exit the loop
                    queryBuilder.WhereRaw("1 = 0");
                    break;
                }

                queryBuilder.Where($"{IdentificationCodeTableAlias}.{property.PropertyName}", queryParameterValue);
            }
        }
        
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

    private Join CreateIdentificationCodeTableJoin(EntityProperty entityIdentificationCodeProperty, string alias)
    {
        var join = new Join(
            $"{entityIdentificationCodeProperty.Entity.Schema}.{entityIdentificationCodeProperty.Entity.TableName(_databaseEngine)}"
                .Alias(IdentificationCodeTableAlias));

        foreach (var entityIdentificationCodePropertyColumnName in GetIdentificationCodeEntityTableJoinColumnNames(
                     entityIdentificationCodeProperty.Entity, _databaseEngine))
        {
            join.On($"{alias}.{entityIdentificationCodePropertyColumnName}", $"{IdentificationCodeTableAlias}.{entityIdentificationCodePropertyColumnName}");
        }

        return join;

        IEnumerable<string> GetIdentificationCodeEntityTableJoinColumnNames(Entity identificationCodeEntity,
            DatabaseEngine databaseEngine)
        {
            return identificationCodeEntity.Identifier.Properties
                .Where(p => p.IsFromParent && p.IsIdentifying)
                .Select(p => p.ColumnName(databaseEngine, p.PropertyName));
        }
    }

    private IDictionary<string, EntityProperty> GetIdentificationCodeParameters(EntityProperty entityIdentificationCodeProperty)
    {
        return entityIdentificationCodeProperty.Entity.Properties
            .Where(IsQueryableIdentificationCodeProperty)
            .ToDictionary(GetParameterNameForIdentificationCodeProperty, StringComparer.OrdinalIgnoreCase);

        string GetParameterNameForIdentificationCodeProperty(EntityProperty property)
        {
            return property.DescriptorEntity?.Name ?? property.PropertyName;
        }
        
        bool IsQueryableIdentificationCodeProperty(EntityProperty property)
        {
            return property.PropertyName.Equals("IdentificationCode") ||
                   !(property.IsFromParent || property.IsAlreadyDefinedInCSharpEntityBaseClasses());
        }
    }
}
