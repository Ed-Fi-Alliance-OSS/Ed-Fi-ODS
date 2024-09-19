// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries.Criteria;

/// <summary>
/// Provide an interface for applying additional manipulations of a query based on an aggregate root table based on
/// the entity-level specification, or additional parameters that were supplied by the API client.
/// </summary>
public interface IAggregateRootQueryCriteriaApplicator
{
    /// <summary>
    /// Applies additional manipulations of a query based on an aggregate root table based on
    /// the entity-level specification, or additional parameters that were supplied by the API client.
    /// </summary>
    /// <param name="queryBuilder"></param>
    /// <param name="entity"></param>
    /// <param name="specification"></param>
    /// <param name="additionalParameters"></param>
    void ApplyAdditionalParameters(
        QueryBuilder queryBuilder,
        Entity entity,
        AggregateRootWithCompositeKey specification,
        IDictionary<string, string> additionalParameters);
}
