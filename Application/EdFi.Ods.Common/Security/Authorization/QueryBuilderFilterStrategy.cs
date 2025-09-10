// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security.Authorization;

public enum QueryBuilderFilterStrategy
{
    /// <summary>
    /// Indicates that the authorization filtering should be applied using CTEs.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    CTEs = 0,
    /// <summary>
    /// Indicates that the authorization filtering should be applied using SQL joins.
    /// </summary>
    Joins,
    /// <summary>
    /// Indicates that the authorization filtering should be applied using an EXISTS subquery.
    /// </summary>
    ExistsSubquery
}
