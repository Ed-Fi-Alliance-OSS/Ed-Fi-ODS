// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Providers.Criteria
{
    /// <summary>
    /// Defines a method for building a query that retrieves the total count of resource items available to the current caller.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to which criteria is being applied.</typeparam>
    public interface ITotalCountCriteriaProvider<in TEntity> : IAggregateRootCriteriaProvider<TEntity>
        where TEntity : class { }
}