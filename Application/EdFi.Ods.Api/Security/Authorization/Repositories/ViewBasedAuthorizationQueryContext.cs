// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;

namespace EdFi.Ods.Api.Security.Authorization.Repositories;

/// <summary>
/// Stores the SQL and the parameters that were previously used for executing the first single-item authorization query
/// on a request.
/// </summary>
public class ViewBasedAuthorizationQueryContext
{
    /// <summary>
    /// Gets or sets the SQL that was used for the authorization query.
    /// </summary>
    public string Sql { get; set; }

    /// <summary>
    /// Gets or sets the parameter objects on the command related to the authorization subject (and excluding the claim-based
    /// EdOrgId endpoint parameters).
    /// </summary>
    public DbParameter[] Parameters { get; set; }
}
