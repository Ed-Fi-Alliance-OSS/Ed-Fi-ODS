// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Dapper;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

public class PostgreSqlPartitionsQueryBuilderPartitionsApplicator(
    Dialect _dialect,
    IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider,
    int _defaultPartitionCount) : IPartitionsQueryBuilderPartitionsApplicator
{
    private readonly int _maxPageLimit = _defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();

    public QueryBuilder ApplyPartitions(
        QueryBuilder queryBuilder,
        int? numberOfPartitions,
        IDictionary<string, string> additionalParameters)
    {
        // Define the parameters for the cross join for partitioning
        var partitionParams = new DynamicParameters();
        partitionParams.Add("@numberOfPartitions", numberOfPartitions ?? _defaultPartitionCount);
        partitionParams.Add("@maxPageSize", _maxPageLimit);

        string partitionSizeSql;

        if (additionalParameters.TryGetValue("allowSmallPartitions", out string value) && Convert.ToBoolean(value))
        {
            string greatest = _dialect.GetGreatestString("1", "CEILING(CountOfRows / @numberOfPartitions)");
            partitionSizeSql = $"SELECT CAST({greatest} AS BIGINT) AS PartitionSize";
        }
        else
        {
            string greatest = _dialect.GetGreatestString("CEILING(CountOfRows / @numberOfPartitions)", "(5 * @maxPageSize)");
            partitionSizeSql = $"SELECT CAST({greatest} AS BIGINT) AS PartitionSize";
        }

        return queryBuilder.CrossJoin(partitionSizeSql, "v", null, partitionParams);
    }
}
