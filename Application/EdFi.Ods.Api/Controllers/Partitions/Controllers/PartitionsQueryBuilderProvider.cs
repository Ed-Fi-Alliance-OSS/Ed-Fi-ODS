// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac.Features.AttributeFilters;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

public class PartitionsQueryBuilderProvider : IPartitionsQueryBuilderProvider
{
    private readonly Dialect _dialect;
    private readonly IAggregateRootQueryBuilderProvider _partitionRowNumbersCteQueryBuilderProvider;
    private readonly IPartitionsQueryBuilderPartitionsApplicator _partitionsApplicator;

    public PartitionsQueryBuilderProvider(
        [KeyFilter(PartitionRowNumbersCteQueryBuilderProvider.RegistrationKey)]
        IAggregateRootQueryBuilderProvider partitionRowNumbersCteQueryBuilderProvider,
        IPartitionsQueryBuilderPartitionsApplicator partitionsApplicator,
        Dialect dialect)
    {
        _partitionRowNumbersCteQueryBuilderProvider = partitionRowNumbersCteQueryBuilderProvider;
        _partitionsApplicator = partitionsApplicator;
        _dialect = dialect;
    }

    public QueryBuilder GetQueryBuilder(
        int? numberOfPartitions,
        Entity aggregateRootEntity,
        AggregateRootWithCompositeKey specification,
        QueryParameters queryParameters,
        IDictionary<string, string> additionalParameters)
    {
        // Get the CTE "row numbers" query
        var rowNumberCteQuery = BuildRowNumbersAndCountQuery();
        rowNumberCteQuery.ApplyChangeVersionCriteria(queryParameters);

        // Build the final query
        var queryBuilder = new QueryBuilder(_dialect)
            .With("Ranked", rowNumberCteQuery)
            .From("Ranked")
            .Select("AggregateId")
            .WhereRaw($"(RowNumber - 1) % v.PartitionSize = 0")
            .OrderBy("AggregateId");

        // Apply DB engine-specific partitions query components
        _partitionsApplicator.ApplyPartitions(queryBuilder, numberOfPartitions, additionalParameters);

        return queryBuilder;

        QueryBuilder BuildRowNumbersAndCountQuery()
        {
            var cteQueryBuilder1 = _partitionRowNumbersCteQueryBuilderProvider.GetQueryBuilder(
                aggregateRootEntity,
                specification,
                queryParameters,
                additionalParameters);

            return cteQueryBuilder1;
        }
    }
}
