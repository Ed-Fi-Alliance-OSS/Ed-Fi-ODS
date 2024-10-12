// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac.Features.AttributeFilters;
using Dapper;
using EdFi.Ods.Common.Configuration;
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
    private readonly int _defaultPartitionCount;
    private readonly int _maxPageLimit;

    public PartitionsQueryBuilderProvider(
        [KeyFilter(PartitionRowNumbersCteQueryBuilderProvider.RegistrationKey)]
        IAggregateRootQueryBuilderProvider partitionRowNumbersCteQueryBuilderProvider,
        IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
        int defaultPartitionCount,
        Dialect dialect)
    {
        _partitionRowNumbersCteQueryBuilderProvider = partitionRowNumbersCteQueryBuilderProvider;
        _defaultPartitionCount = defaultPartitionCount;
        _maxPageLimit = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
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
        var cteQueryBuilder = BuildRowNumbersCte();

        // Build the count query
        var cteCountQueryBuilder = BuildCountCte();

        // Build the PartitionSizes query
        var ctePartitionSizeQueryBuilder = BuildPartitionSizeCte();

        // Build the final query
        var queryBuilder = new QueryBuilder(_dialect).With("Numbered", cteQueryBuilder)
            .With("Counts", cteCountQueryBuilder)
            .With("PartitionSizes", ctePartitionSizeQueryBuilder)
            .From("Numbered, PartitionSizes")
            .Select("AggregateId")
            .WhereRaw($"(RowNumber - 1) % PartitionSize = 0")
            .OrderBy("AggregateId");

        return queryBuilder;

        QueryBuilder BuildRowNumbersCte()
        {
            var cteQueryBuilder1 = _partitionRowNumbersCteQueryBuilderProvider.GetQueryBuilder(
                aggregateRootEntity,
                specification,
                queryParameters,
                additionalParameters);

        cteQueryBuilder.ApplyChangeVersionCriteria(queryParameters);

            return cteQueryBuilder1;
        }

        QueryBuilder BuildCountCte()
        {
            var cteCountQueryBuilder1 = cteQueryBuilder.Clone();
            bool hasDistinct = cteCountQueryBuilder1.HasDistinct();
            cteCountQueryBuilder1.ClearSelect();
            cteCountQueryBuilder1.ClearWith();
            cteCountQueryBuilder1.SelectRaw($"COUNT({(hasDistinct ? "DISTINCT " : null)}AggregateId) AS CountOfRows");

            return cteCountQueryBuilder1;
        }

        QueryBuilder BuildPartitionSizeCte()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@numberOfPartitions", numberOfPartitions ?? _defaultPartitionCount);
            parameters.Add("@maxPageSize", _maxPageLimit);

            string partitionSizeSql;

            if (additionalParameters.TryGetValue("allowSmallPartitions", out string value) && Convert.ToBoolean(value))
            {
                string greatest = _dialect.GetGreatestString("1", "CEILING(CountOfRows / @numberOfPartitions)");
                partitionSizeSql = $"CAST({greatest} AS BIGINT) AS PartitionSize";
            }
            else
            {
                string greatest = _dialect.GetGreatestString("CEILING(CountOfRows / @numberOfPartitions)", "(5 * @maxPageSize)");
                partitionSizeSql = $"CAST({greatest} AS BIGINT) AS PartitionSize";
            }

            var ctePartitionSizesQueryBuilder1 = new QueryBuilder(_dialect)
                .From("Counts")
                .Select("CountOfRows")
                .Select(partitionSizeSql)
                .AddParameters(parameters);

            return ctePartitionSizesQueryBuilder1;
        }
    }
}
