// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
        IDictionary<string, string> additionalParameters)
    {
        // Get the CTE "row numbers" query
        var cteQueryBuilder = BuildRowNumbersCte();

        // Build the count query
        var cteCountQueryBuilder = BuildCountCte();

        // Build the PartitionSettings query
        var ctePartitionSettingsQueryBuilder = BuildPartitionSettingsCte();

        // Build the PartitionCounts query
        var ctePartitionCountsQueryBuilder = BuildPartitionCountsCte();

        // Build the final query
        var queryBuilder = new QueryBuilder(_dialect).With("Numbered", cteQueryBuilder)
            .With("Counts", cteCountQueryBuilder)
            .With("PartitionSettings", ctePartitionSettingsQueryBuilder)
            .With("PartitionCounts", ctePartitionCountsQueryBuilder)
            .From("Numbered, PartitionCounts")
            .Select("AggregateId")
            .WhereRaw($"(RowNumber - 1) % (CASE WHEN CountOfRows < PartitionCount THEN 1 ELSE CountOfRows / PartitionCount END) = 0")
            .OrderBy("AggregateId");

        return queryBuilder;

        QueryBuilder BuildRowNumbersCte()
        {
            var cteQueryBuilder1 = _partitionRowNumbersCteQueryBuilderProvider.GetQueryBuilder(
                aggregateRootEntity,
                specification,
                QueryParameters.Empty,
                additionalParameters);

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

        QueryBuilder BuildPartitionSettingsCte()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@defaultPartitionCount", numberOfPartitions ?? _defaultPartitionCount);
            parameters.Add("@maxPageSize", _maxPageLimit);
        
            var ctePartitionSettingsQueryBuilder1 = new QueryBuilder(_dialect)
                .From("Counts")
                .Select("CountOfRows")
                .Select("GREATEST(CEILING(CountOfRows / @defaultPartitionCount), 5 * @maxPageSize) AS PartitionSize")
                .AddParameters(parameters);

            return ctePartitionSettingsQueryBuilder1;
        }

        QueryBuilder BuildPartitionCountsCte()
        {
            var ctePartitionCountsQueryBuilder1 = new QueryBuilder(_dialect)
                .From("PartitionSettings")
                .Select("CountOfRows", "PartitionSize")
                .SelectRaw("CAST(FLOOR(CAST(CountOfRows AS FLOAT) / PartitionSize) AS BIGINT) AS PartitionCount");

            return ctePartitionCountsQueryBuilder1;
        }
    }
}
