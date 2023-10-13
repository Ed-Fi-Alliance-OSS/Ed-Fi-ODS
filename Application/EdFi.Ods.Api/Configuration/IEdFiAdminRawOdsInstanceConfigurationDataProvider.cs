// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Defines a method for obtaining raw ODS instance configuration data for an ODS instance.
/// </summary>
public interface IEdFiAdminRawOdsInstanceConfigurationDataProvider
{
    /// <summary>
    /// Gets raw ODS instance configuration data for an ODS instance.
    /// </summary>
    /// <param name="odsInstanceId">The tenant-specific ODS identifier.</param>
    /// <returns>The raw data containing the ODS instance configuration details.</returns>
    Task<RawOdsInstanceConfigurationDataRow[]> GetByIdAsync(int odsInstanceId);

    Task<string[]> GetDistinctOdsInstanceContextValuesAsync(string odsContextKey);
}
