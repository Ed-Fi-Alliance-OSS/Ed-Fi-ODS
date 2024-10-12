// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

/// <summary>
/// Defines the interface for obtaining the <see cref="QueryBuilder" /> for the main Partitions query.
/// </summary>
public interface IPartitionsQueryBuilderProvider
{
    /// <summary>
    /// Get the <see cref="QueryBuilder" /> for the main Partitions query.
    /// </summary>
    /// <param name="numberOfPartitions">The number of partitions requested (or <b>null</b> to use the value configured in <see cref="ApiSettings.DefaultPartitionCount"/>).</param>
    /// <param name="aggregateRootEntity">The root <see cref="Entity" /> for the resource on which partitions are being computed.</param>
    /// <param name="specification">Entity-specific criteria to apply to the computation.</param>
    /// <param name="queryParameters">Common "special" query parameters to apply to the query.</param>
    /// <param name="additionalParameters">Additional parameters to apply to the computation.</param>
    /// <returns>The <see cref="QueryBuilder" /> instance containing the query to be executed to determine the starting record for each partition.</returns>
    QueryBuilder GetQueryBuilder(
        int? numberOfPartitions,
        Entity aggregateRootEntity,
        AggregateRootWithCompositeKey specification,
        QueryParameters queryParameters,
        IDictionary<string, string> additionalParameters);
}
