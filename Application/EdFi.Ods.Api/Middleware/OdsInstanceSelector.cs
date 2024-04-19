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
    private readonly IApiClientContextProvider _apiClientContextProvider;
    private readonly IOdsInstanceConfigurationProvider _odsInstanceConfigurationProvider;
    private readonly bool _hasOdsContextRouteTemplate;

    public OdsInstanceSelector(
        IApiClientContextProvider apiClientContextProvider,
        IOdsInstanceConfigurationProvider odsInstanceConfigurationProvider, 
        ApiSettings apiSettings)
    {
        _apiClientContextProvider = apiClientContextProvider;
        _odsInstanceConfigurationProvider = odsInstanceConfigurationProvider;
        _hasOdsContextRouteTemplate = !string.IsNullOrEmpty(apiSettings.OdsContextRouteTemplate);
    }

    /// <inheritdoc cref="IOdsInstanceSelector.GetOdsInstanceAsync" />
    public async Task<OdsInstanceConfiguration> GetOdsInstanceAsync(IReadOnlyDictionary<string, object> routeValues)
    {
        var apiClientContext = _apiClientContextProvider.GetApiClientContext();

        if (apiClientContext == null || apiClientContext == ApiClientContext.Empty)
        {
            return null;
        }

        if (apiClientContext.OdsInstanceIds.Count == 0)
        {
            throw new SecurityConfigurationException(
                "scenario87.",
                "The API client has not been associated with an ODS instance.");
        }

        if (apiClientContext.OdsInstanceIds.Count == 1 && !_hasOdsContextRouteTemplate)
        {
            return await _odsInstanceConfigurationProvider.GetByIdAsync(apiClientContext.OdsInstanceIds[0]);
        }

        var firstMatchingOdsInstanceConfiguration = apiClientContext.OdsInstanceIds
            .Select(id =>  _odsInstanceConfigurationProvider.GetByIdAsync(id).ConfigureAwait(false).GetAwaiter().GetResult())
            .Where(config => config != null && config.ContextValueByKey.Count != 0)
            .FirstOrDefault(config => 
                config.ContextValueByKey.All(contextValue => 
                    routeValues.TryGetValue(contextValue.Key, out var routeValue)
                        && contextValue.Value.EqualsIgnoreCase(routeValue.ToString())));

        if (firstMatchingOdsInstanceConfiguration == null)
        {
            throw new NotFoundException(
                "scenario63.",
                $"No ODS instance matching the available route values was found. Route values were: [{string.Join(", ", routeValues.Select(kvp => $"{kvp.Key}={kvp.Value}"))}]");
        }

        return firstMatchingOdsInstanceConfiguration;
    }
}
