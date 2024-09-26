// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.Partitions.Controllers;

/// <summary>
/// Defines the interface for obtaining the <see cref="QueryBuilder" /> for the main Partitions query.
/// </summary>
public interface IPartitionsQueryBuilderProvider
{
    /// <summary>
    /// Get the <see cref="QueryBuilder" /> for the main Partitions query.
    /// </summary>
    /// <param name="numberOfPartitions"></param>
    /// <param name="aggregateRootEntity"></param>
    /// <param name="specification"></param>
    /// <param name="additionalParameters"></param>
    /// <returns></returns>
    QueryBuilder GetQueryBuilder(
        int numberOfPartitions,
        Entity aggregateRootEntity,
        AggregateRootWithCompositeKey specification,
        IDictionary<string, string> additionalParameters);
}
