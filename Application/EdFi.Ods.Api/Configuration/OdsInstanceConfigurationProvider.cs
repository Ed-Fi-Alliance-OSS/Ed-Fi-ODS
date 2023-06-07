// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
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
    private readonly IOdsInstanceHashIdGenerator _odsInstanceHashIdGenerator;
    private readonly IConnectionStringOverridesApplicator _connectionStringOverridesApplicator;

    public OdsInstanceConfigurationProvider(
        IEdFiAdminRawOdsInstanceConfigurationDataProvider edFiAdminRawOdsInstanceConfigurationDataProvider,
        IOdsInstanceHashIdGenerator odsInstanceHashIdGenerator,
        IConnectionStringOverridesApplicator connectionStringOverridesApplicator)
    {
        _edFiAdminRawOdsInstanceConfigurationDataProvider = edFiAdminRawOdsInstanceConfigurationDataProvider;
        _odsInstanceHashIdGenerator = odsInstanceHashIdGenerator;
        _connectionStringOverridesApplicator = connectionStringOverridesApplicator;
    }

    /// <inheritdoc cref="IOdsInstanceConfigurationProvider.GetByIdAsync" />
    public async Task<OdsInstanceConfiguration> GetByIdAsync(int odsInstanceId)
    {
        var rawDataRows = await _edFiAdminRawOdsInstanceConfigurationDataProvider.GetByIdAsync(odsInstanceId);

        // Build the base configuration
        var baseOdsInstanceConfiguration = CreateOdsInstanceConfiguration();

        // Apply overrides (from configuration)
        _connectionStringOverridesApplicator.ApplyOverrides(baseOdsInstanceConfiguration);

        // Return the final configuration
        return baseOdsInstanceConfiguration;

        OdsInstanceConfiguration CreateOdsInstanceConfiguration()
        {
            var firstRow = rawDataRows?.FirstOrDefault();

            if (firstRow == null)
            {
                return null;
            }

            var configuration = new OdsInstanceConfiguration(
                odsInstanceId: firstRow.OdsInstanceId,
                odsInstanceHashId: _odsInstanceHashIdGenerator.GenerateHashId(firstRow.OdsInstanceId),
                connectionString: firstRow.ConnectionString,
                contextValueByKey: GetContextValues(),
                connectionStringByDerivativeType: GetConnectionStringsByDerivativeType()
            );

            return configuration;

            IDictionary<string, string> GetContextValues()
            {
                return rawDataRows
                    .Where(x => !string.IsNullOrEmpty(x.ContextKey))
                    .Select(x => new KeyValuePair<string, string>(x.ContextKey, x.ContextValue))
                    .DistinctBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            }

            IDictionary<DerivativeType, string> GetConnectionStringsByDerivativeType()
            {
                return rawDataRows
                    .Where(x => !string.IsNullOrEmpty(x.DerivativeType))
                    .Select(x => new KeyValuePair<DerivativeType, string>(DerivativeType.Parse(x.DerivativeType), x.ConnectionStringByDerivativeType))
                    .DistinctBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}
