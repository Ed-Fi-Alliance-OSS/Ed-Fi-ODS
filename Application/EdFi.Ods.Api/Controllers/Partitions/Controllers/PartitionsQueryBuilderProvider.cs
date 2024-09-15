// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac.Features.AttributeFilters;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Providers.Queries;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

public class PartitionsQueryBuilderProvider : IPartitionsQueryBuilderProvider
{
    private readonly IAggregateRootQueryBuilderProvider _partitionRowNumbersCteQueryBuilderProvider;
    private readonly Dialect _dialect;

    public PartitionsQueryBuilderProvider(
        [KeyFilter(PartitionRowNumbersCteQueryBuilderProvider.RegistrationKey)]
        IAggregateRootQueryBuilderProvider partitionRowNumbersCteQueryBuilderProvider,
        Dialect dialect)
    {
        _partitionRowNumbersCteQueryBuilderProvider = partitionRowNumbersCteQueryBuilderProvider;
        _dialect = dialect;
    }

    public QueryBuilder GetQueryBuilder(Entity aggregateRootEntity, int number)
    {
        // Get the CTE "row numbers" query
        var cteQueryBuilder = _partitionRowNumbersCteQueryBuilderProvider.GetQueryBuilder(aggregateRootEntity, null, new QueryParameters());

        Entity queryEntity = aggregateRootEntity;
        string discriminator = null;

        // For a derived entity, redirect the count query to the base table
        if (aggregateRootEntity.IsDerived)
        {
            queryEntity = aggregateRootEntity.BaseEntity;
            discriminator = aggregateRootEntity.FullName.ToString();
        }

        // TODO: ODS-6432 - Count query needs to be subjected to the same authorization filtering, as a second CTE

        var queryBuilder = new QueryBuilder(_dialect).With("Numbered", cteQueryBuilder).From("Numbered")
            .Select("AggregateId")
            .WhereRaw($"RowNumber % ((SELECT COUNT(1) FROM {queryEntity.FullName}) / {number}) = 0")
            .OrderBy("AggregateId");

        if (discriminator != null)
        {
            queryBuilder.Where("Discriminator", discriminator);
        }

        return queryBuilder;
    }
}
