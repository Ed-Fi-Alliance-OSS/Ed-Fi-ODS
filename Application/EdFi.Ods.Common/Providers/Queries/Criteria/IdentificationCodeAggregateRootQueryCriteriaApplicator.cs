// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Providers.Criteria;

namespace EdFi.Ods.Common.Providers.Queries.Criteria;

/// <summary>
/// Applies criteria to a query based on identification codes property values
/// </summary>
public class IdentificationCodeAggregateRootQueryCriteriaApplicator : IAggregateRootQueryCriteriaApplicator
{
    private readonly IDescriptorResolver _descriptorResolver;
    private readonly IResourceModelProvider _resourceModelProvider;
    private readonly IResourceIdentificationCodePropertiesProvider _resourceIdentificationCodePropertiesProvider;
    private readonly DatabaseEngine _databaseEngine;

    private const string IdentificationCodeTableAlias = "idct";
    private readonly ConcurrentDictionary<FullName, Join> _identificationCodeTableJoinByRootEntityName = new();

    public IdentificationCodeAggregateRootQueryCriteriaApplicator(
        IDescriptorResolver descriptorResolver,
        IResourceModelProvider resourceModelProvider,
        IResourceIdentificationCodePropertiesProvider resourceIdentificationCodePropertiesProvider,
        DatabaseEngine databaseEngine)
    {
        _descriptorResolver = descriptorResolver;
        _resourceIdentificationCodePropertiesProvider = resourceIdentificationCodePropertiesProvider;
        _resourceModelProvider = resourceModelProvider;
        _databaseEngine = databaseEngine;
    }

    public void ApplyAdditionalParameters(QueryBuilder queryBuilder, Entity entity, AggregateRootWithCompositeKey specification,
        IDictionary<string, string> additionalParameters)
    {
        if (additionalParameters == null
            || !additionalParameters.Any()
            || additionalParameters.All(
                ap => AggregateRootCriteriaProviderHelpers.PropertiesToIgnore.Contains(ap.Key, StringComparer.OrdinalIgnoreCase)))
        {
            return;
        }

        var resource = _resourceModelProvider.GetResourceModel().GetResourceByFullName(entity.FullName);

        // If the entity does not have an identificationCodes collection with queryable properties, return
        if (!_resourceIdentificationCodePropertiesProvider.TryGetIdentificationCodeProperties(
                resource, out List<ResourceProperty> identificationCodeProperties))
        {
            return;
        }

        // Find any supplied additionalParameters with a non-default value and name matching that of a queryable identificationCode property, if none then return
        var applicableAdditionalParameters = additionalParameters
            .Where(
                x => !x.Value.IsDefaultValue()
                     && identificationCodeProperties.Any(y => y.PropertyName.Equals(x.Key, StringComparison.OrdinalIgnoreCase)))
            .ToArray();

        if (applicableAdditionalParameters.Length == 0)
        {
            return;
        }

        var identificationCodeTableJoin =
            GetIdentificationCodeEntityTableJoin(entity, identificationCodeProperties.First().EntityProperty.Entity);

        queryBuilder.Join(identificationCodeTableJoin.TableName, _ => identificationCodeTableJoin);

        ApplyParameterValuesToQueryBuilder(
            queryBuilder, applicableAdditionalParameters, identificationCodeProperties);
    }

    private void ApplyParameterValuesToQueryBuilder(QueryBuilder queryBuilder,
        IEnumerable<KeyValuePair<string, string>> parameterValuesByName,
        List<ResourceProperty> identificationCodeProperties)
    {
        foreach (KeyValuePair<string, string> parameterKeyValuePair in parameterValuesByName)
        {
            var identificationCodeProperty =
                identificationCodeProperties.FirstOrDefault(
                    p => p.PropertyName.Equals(parameterKeyValuePair.Key, StringComparison.OrdinalIgnoreCase));

            if (identificationCodeProperty == null)
            {
                continue;
            }

            var queryParameterValue = GetQueryParameterValueForProperty(identificationCodeProperty, parameterKeyValuePair.Value);

            if (identificationCodeProperty.IsDescriptorUsage && queryParameterValue == null)
            {
                // Descriptor did not match any value -- criteria should exclude all entries
                // Since no additional criteria need to be applied, exit the loop
                queryBuilder.WhereRaw("1 = 0");
                break;
            }

            queryBuilder.Where(
                $"{IdentificationCodeTableAlias}.{identificationCodeProperty.EntityProperty}", queryParameterValue);
        }

        return;

        object GetQueryParameterValueForProperty(ResourceProperty property, string parameterValue)
        {
            if (!property.IsDescriptorUsage)
            {
                return parameterValue;
            }

            var lookupId = _descriptorResolver.GetDescriptorId(property.DescriptorName, parameterValue);

            return lookupId == 0
                ? null
                : lookupId;
        }
    }

    private Join GetIdentificationCodeEntityTableJoin(Entity rootEntity, Entity identificationCodeEntity)
    {
        return _identificationCodeTableJoinByRootEntityName.GetOrAdd(
            rootEntity.FullName, _ =>
            {
                string alias = rootEntity.RootTableAlias();
                
                var join = new Join(
                    $"{identificationCodeEntity.Schema}.{identificationCodeEntity.TableName(_databaseEngine)}"
                        .Alias(IdentificationCodeTableAlias));

                foreach (var entityIdentificationCodePropertyColumnName in GetIdentificationCodeEntityTableJoinColumnNames(
                             identificationCodeEntity))
                {
                    join.On(
                        $"{alias}.{entityIdentificationCodePropertyColumnName}",
                        $"{IdentificationCodeTableAlias}.{entityIdentificationCodePropertyColumnName}");
                }

                return join;
            });

        IEnumerable<string> GetIdentificationCodeEntityTableJoinColumnNames(Entity identificationCodeEntity)
        {
            return identificationCodeEntity.Identifier.Properties
                .Where(p => p.IsFromParent && p.IsIdentifying)
                .Select(p => p.ColumnName(_databaseEngine, p.PropertyName)).ToArray();
        }
    }

    public static string IdentificationCodeEntityTableAlias() => IdentificationCodeTableAlias;
}
