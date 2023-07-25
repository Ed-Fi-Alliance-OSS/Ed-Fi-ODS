// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Security.Authentication;

/// <summary>
/// Defines an interface for writing the connection string for an ODS instance to persistent storage.
/// </summary>
public interface IEdFiOdsConnectionStringWriter
{
    /// <summary>
    /// Writes the connection string for an ODS instance to persistent storage.
    /// </summary>
    /// <param name="odsInstanceId">
    /// The identifier of the ODS instance for which the connection string is to be written.
    /// </param>
    /// <param name="connectionString">
    /// The connection string to be written.
    /// </param>
    /// <param name="derivativeType">
    /// Optional. The type of ODS instance derivative to which the connection string should be written.
    /// </param>
    public Task WriteConnectionStringAsync(int odsInstanceId, string connectionString, DerivativeType derivativeType = null);
}
