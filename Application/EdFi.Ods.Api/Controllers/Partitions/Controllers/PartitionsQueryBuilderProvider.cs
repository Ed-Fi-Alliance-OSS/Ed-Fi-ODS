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

        var cteCountQueryBuilder = cteQueryBuilder.Clone();
        bool hasDistinct = cteCountQueryBuilder.HasDistinct();
        cteCountQueryBuilder.ClearSelect();
        cteCountQueryBuilder.SelectRaw($"COUNT({(hasDistinct ? "DISTINCT " : null)}AggregateId) AS CountOfRows");

        var queryBuilder = new QueryBuilder(_dialect)
            .With("Numbered", cteQueryBuilder)
            .With("Counts", cteCountQueryBuilder)
            .From("Numbered, Counts")
            .Select("AggregateId")
            .WhereRaw($"RowNumber % ((SELECT CountOfRows FROM Counts) / {number}) = 0")
            .OrderBy("AggregateId");

        return queryBuilder;
    }
}
