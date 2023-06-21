// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Selects the appropriate ODS for the currently authenticated API client.
/// </summary>
public class OdsInstanceSelector : IOdsInstanceSelector
{
    private readonly IApiKeyContextProvider _apiKeyContextProvider;
    private readonly IOdsInstanceConfigurationProvider _odsInstanceConfigurationProvider;

    public OdsInstanceSelector(
        IApiKeyContextProvider apiKeyContextProvider,
        IOdsInstanceConfigurationProvider odsInstanceConfigurationProvider)
    {
        _apiKeyContextProvider = apiKeyContextProvider;
        _odsInstanceConfigurationProvider = odsInstanceConfigurationProvider;
    }

    /// <inheritdoc cref="IOdsInstanceSelector.GetOdsInstanceAsync" />
    public async Task<OdsInstanceConfiguration> GetOdsInstanceAsync(IReadOnlyDictionary<string, object> routeValues)
    {
        var apiKeyContext = _apiKeyContextProvider.GetApiKeyContext();

        if (apiKeyContext == null || apiKeyContext == ApiKeyContext.Empty)
        {
            return null;
        }

        if (apiKeyContext.OdsInstanceIds.Count == 0)
        {
            throw new ApiSecurityConfigurationException("The API client has not been associated with an ODS instance.");
        }

        if (apiKeyContext.OdsInstanceIds.Count == 1)
        {
            return await _odsInstanceConfigurationProvider.GetByIdAsync(apiKeyContext.OdsInstanceIds[0]);
        }

        var firstMatchingOdsInstanceConfiguration = apiKeyContext.OdsInstanceIds
            .Select(id =>  _odsInstanceConfigurationProvider.GetByIdAsync(id).ConfigureAwait(false).GetAwaiter().GetResult())
            .Where(config => config != null)
            .FirstOrDefault(config => 
                config.ContextValueByKey.All(contextValue => 
                    routeValues.TryGetValue(contextValue.Key, out var routeValue)
                        && contextValue.Value.EqualsIgnoreCase(routeValue.ToString())));

        if (firstMatchingOdsInstanceConfiguration == null)
        {
            throw new NotFoundException("No ODS instance matching the available route values was found.");
        }

        return firstMatchingOdsInstanceConfiguration;
    }
}
