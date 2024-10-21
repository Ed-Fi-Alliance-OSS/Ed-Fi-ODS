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

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

public class PartitionsQueryBuilderProvider : IPartitionsQueryBuilderProvider
{
    private readonly Dialect _dialect;
    private readonly IAggregateRootQueryBuilderProvider _partitionRowNumbersCteQueryBuilderProvider;

    public PartitionsQueryBuilderProvider(
        [KeyFilter(PartitionRowNumbersCteQueryBuilderProvider.RegistrationKey)]
        IAggregateRootQueryBuilderProvider partitionRowNumbersCteQueryBuilderProvider,
        Dialect dialect)
    {
        _partitionRowNumbersCteQueryBuilderProvider = partitionRowNumbersCteQueryBuilderProvider;
        _dialect = dialect;
    }

    public QueryBuilder GetQueryBuilder(
        int numberOfPartitions,
        Entity aggregateRootEntity,
        AggregateRootWithCompositeKey specification,
        IDictionary<string, string> additionalParameters)
    {
        // Get the CTE "row numbers" query
        var cteQueryBuilder = _partitionRowNumbersCteQueryBuilderProvider.GetQueryBuilder(
            aggregateRootEntity,
            specification,
            QueryParameters.Empty,
            additionalParameters);

        var cteCountQueryBuilder = cteQueryBuilder.Clone();
        bool hasDistinct = cteCountQueryBuilder.HasDistinct();
        cteCountQueryBuilder.ClearSelect();
        cteCountQueryBuilder.ClearWith();
        cteCountQueryBuilder.SelectRaw($"COUNT({(hasDistinct ? "DISTINCT " : null)}AggregateId) AS CountOfRows");

        var queryBuilder = new QueryBuilder(_dialect)
            .With("Numbered", cteQueryBuilder)
            .With("Counts", cteCountQueryBuilder)
            .From("Numbered, Counts")
            .Select("AggregateId")

            // For Partitions no smaller than 1, use this logic
            .WhereRaw(
                $"(RowNumber - 1) % (CASE WHEN (SELECT CountOfRows FROM Counts) < {numberOfPartitions} THEN 1 ELSE (SELECT CountOfRows FROM Counts) / {numberOfPartitions} END) = 0")

            // NOTE: For Partitions no smaller than default page limit size, use this logic:
            // .WhereRaw($"(RowNumber - 1) % (CASE WHEN ((SELECT CountOfRows FROM Counts) / {numberOfPartitions}) < {_defaultPageSizeLimit} THEN {_defaultPageSizeLimit} ELSE (SELECT CountOfRows FROM Counts) / {numberOfPartitions} END) = 0")

            .OrderBy("AggregateId");

        return queryBuilder;
    }
}
