// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Implements an <see cref="IOdsInstanceConfigurationProvider"/> that obtains ODS instance configurations from the EdFi_Admin database.
/// </summary>
public class OdsInstanceConfigurationProvider : IOdsInstanceConfigurationProvider
{
    private readonly IEdFiAdminRawOdsInstanceConfigurationDataProvider _edFiAdminRawOdsInstanceConfigurationDataProvider;
    private readonly IEdFiAdminRawOdsInstanceConfigurationDataTransformer _edFiAdminRawOdsInstanceConfigurationDataTransformer;
    private readonly IConnectionStringOverridesApplicator _connectionStringOverridesApplicator;

    public OdsInstanceConfigurationProvider(
        IEdFiAdminRawOdsInstanceConfigurationDataProvider edFiAdminRawOdsInstanceConfigurationDataProvider,
        IEdFiAdminRawOdsInstanceConfigurationDataTransformer edFiAdminRawOdsInstanceConfigurationDataTransformer,
        IConnectionStringOverridesApplicator connectionStringOverridesApplicator)
    {
        _edFiAdminRawOdsInstanceConfigurationDataProvider = edFiAdminRawOdsInstanceConfigurationDataProvider;
        _edFiAdminRawOdsInstanceConfigurationDataTransformer = edFiAdminRawOdsInstanceConfigurationDataTransformer;
        _connectionStringOverridesApplicator = connectionStringOverridesApplicator;
    }

    /// <inheritdoc cref="IOdsInstanceConfigurationProvider.GetByIdAsync" />
    public async Task<OdsInstanceConfiguration> GetByIdAsync(int odsInstanceId)
    {
        // Get the raw configuration data for the ODS instance
        var rawDataRows = await _edFiAdminRawOdsInstanceConfigurationDataProvider.GetByIdAsync(odsInstanceId);

        // Build the base configuration from the raw data
        var odsInstanceConfiguration = await _edFiAdminRawOdsInstanceConfigurationDataTransformer.TransformAsync(rawDataRows);

        // Apply overrides (from configuration sources)
        _connectionStringOverridesApplicator.ApplyOverrides(odsInstanceConfiguration);

        // Ensure that all connection strings have values
        EnsureConnectionStringsInitialized();

        // Return the final configuration
        return odsInstanceConfiguration;

        void EnsureConnectionStringsInitialized()
        {
            if (string.IsNullOrEmpty(odsInstanceConfiguration.ConnectionString))
            {
                throw new Exception("ODS connection string has not been initialized.");
            }

            var uninitializedDerivatives = odsInstanceConfiguration.ConnectionStringByDerivativeType
                .Where(kvp => string.IsNullOrEmpty(kvp.Value))
                .ToList();

            if (uninitializedDerivatives.Any())
            {
                var uninitializedDerivativeType = uninitializedDerivatives.Select(kvp => kvp.Key).First();

                throw new Exception(
                    $"Derivative ODS connection string '{uninitializedDerivativeType}' has not been initialized.");
            }
        }
    }
}