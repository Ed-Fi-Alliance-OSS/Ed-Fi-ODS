// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Providers.Criteria
{
    /// <summary>
    /// Defines a method for building a query that retrieves the Ids for the next page of data.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to which criteria is being applied.</typeparam>
    public interface IPagedAggregateIdsCriteriaProvider<in TEntity> : IAggregateRootCriteriaProvider<TEntity>
        where TEntity : class { }
}