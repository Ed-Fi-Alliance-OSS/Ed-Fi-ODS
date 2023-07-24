// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using log4net;

namespace EdFi.Ods.Api.Configuration;

public class EdFiAdminRawOdsInstanceConfigurationDataTransformer : IEdFiAdminRawOdsInstanceConfigurationDataTransformer
{
    private readonly IOdsInstanceHashIdGenerator _odsInstanceHashIdGenerator;

    private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiAdminRawOdsInstanceConfigurationDataTransformer));
    
    public EdFiAdminRawOdsInstanceConfigurationDataTransformer(IOdsInstanceHashIdGenerator odsInstanceHashIdGenerator)
    {
        _odsInstanceHashIdGenerator = odsInstanceHashIdGenerator;
    }

    /// <inheritdoc cref="IEdFiAdminRawOdsInstanceConfigurationDataTransformer.TransformAsync" />
    public Task<OdsInstanceConfiguration> TransformAsync(RawOdsInstanceConfigurationDataRow[] rawDataRows)
    {
        var firstRow = rawDataRows?.FirstOrDefault();

        if (firstRow == null)
        {
            return Task.FromResult<OdsInstanceConfiguration>(null);
        }

        var configuration = new OdsInstanceConfiguration(
            odsInstanceId: firstRow.OdsInstanceId,
            odsInstanceHashId: _odsInstanceHashIdGenerator.GenerateHashId(firstRow.OdsInstanceId),
            connectionString: firstRow.ConnectionString,
            contextValueByKey: GetContextValues(),
            connectionStringByDerivativeType: GetConnectionStringsByDerivativeType()
        );

        return Task.FromResult(configuration);

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
            var misconfiguredOrEmptyDerivativeTypeRows = rawDataRows
                .Where(x =>
                    string.IsNullOrEmpty(x.DerivativeType) 
                    || !DerivativeType.TryParse(x.DerivativeType, out _))
                .ToList();

            var misconfiguredDerivativeTypes = misconfiguredOrEmptyDerivativeTypeRows
                .Select(x => x.DerivativeType)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();

            // Add a log entry capturing the presence of misconfigured derivative types
            if (misconfiguredDerivativeTypes.Any())
            {
                _logger.Error(
                    $"Invalid DerivativeType values found for OdsInstance '{firstRow.OdsInstanceId}': '{string.Join("', '", misconfiguredDerivativeTypes)}'");
            }

            // Construct the dictionary of connection strings, keyed by valid derivative type
            return rawDataRows.Except(misconfiguredOrEmptyDerivativeTypeRows)
                .Select(x => new KeyValuePair<DerivativeType, string>(DerivativeType.Parse(x.DerivativeType), x.ConnectionStringByDerivativeType))
                .DistinctBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
