// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Defines a method for transforming raw data returned from the EdFi_Admin database into an OdsInstanceConfiguration object.
/// </summary>
public interface IEdFiAdminRawOdsInstanceConfigurationDataTransformer
{
    /// <summary>
    /// Transforms the supplied raw data into an OdsInstanceConfiguration instance.
    /// </summary>
    /// <param name="rawDataRows">The raw ODS instance configuration data from the EdFi_Admin database.</param>
    /// <returns>The initialized <see cref="OdsInstanceConfiguration" /> instance.</returns>
    Task<OdsInstanceConfiguration> TransformAsync(RawOdsInstanceConfigurationDataRow[] rawDataRows);
}
