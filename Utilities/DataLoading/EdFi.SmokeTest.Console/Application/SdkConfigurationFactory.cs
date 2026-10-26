// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace EdFi.SmokeTest.Console.Application
{
    public class SdkConfigurationFactory : ISdkConfigurationFactory
    {
        private readonly Type _configType;
        private readonly IOAuthTokenHandler _tokenHandler;
        private readonly IServiceProvider _serviceProvider;
        private readonly bool _isHostConfiguration;
        public object SdkConfig;

        public SdkConfigurationFactory(IApiConfiguration apiConfiguration,
                                       ISdkLibraryConfiguration sdkLibraryConfiguration,
                                       ISdkDataPathConfiguration sdkDataPathConfiguration,
                                       IOAuthTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;

            var sdkGenerationBasePath = sdkLibraryConfiguration.Path;
            var owinServerUrl = apiConfiguration.Url;
            var dataPath = sdkDataPathConfiguration.DataPath;

            // New-generator SDKs ship Client.HostConfiguration (DI-based); old-generator SDKs ship
            // only Client.Configuration. Probe for the new type first and select the mode by which
            // type is present - do NOT rely on catching exceptions for control flow.
            var hostConfigurationName =
                $"{sdkLibraryConfiguration.SdkNamespacePrefix}.{EdFiConstants.SdkConfigurationClassName}";
            var hostConfigType = TryGetTypeFromAssembly(sdkGenerationBasePath, hostConfigurationName);

            if (hostConfigType != null)
            {
                _isHostConfiguration = true;
                _configType = hostConfigType;
                _serviceProvider = ConfigureHostConfiguration(sdkGenerationBasePath, owinServerUrl, dataPath);
            }
            else
            {
                // Pre-net10 (old-generator) fallback: construct Client.Configuration directly.
                _isHostConfiguration = false;

                var legacyConfigurationName =
                    $"{sdkLibraryConfiguration.SdkNamespacePrefix}.{EdFiConstants.SdkConfigurationClassNameLegacy}";
                _configType = GetTypeFromAssembly(sdkGenerationBasePath, legacyConfigurationName);

                var defaultHeader = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                };

                // 4-arg ctor: (defaultHeaders, apiKey, apiKeyPrefix, basePath). The old-generator SDK's
                // operation paths OMIT the /data/v3 segment - they look like "/ed-fi/schools", not
                // "/data/v3/ed-fi/schools" - so the base path must already be the data-management API
                // URL (e.g. http://localhost:8765/data/v3), not the server root. Program resolves
                // OdsApi:ApiUrl from the version endpoint's "dataManagementApi" to exactly that URL and
                // surfaces it here as apiConfiguration.Url, so it is passed through as-is. Do NOT
                // normalize it back to the server root.
                object[] args =
                {
                    defaultHeader, new Dictionary<string, string>(), new Dictionary<string, string>(), owinServerUrl
                };

                SdkConfig = Activator.CreateInstance(_configType, args);
            }
        }

        public object SdkConfiguration
        {
            get
            {
                if (_isHostConfiguration)
                {
                    // Return the service provider for API instantiation (DI path).
                    return _serviceProvider;
                }

                // Old-generator path: set the bearer token on the Configuration and return it.
                var accessTokenProperty = _configType.GetProperty(EdFiConstants.AccessToken);
                var token = _tokenHandler.GetBearerToken();

                accessTokenProperty?.SetValue(SdkConfig, token);

                return SdkConfig;
            }
        }

        private IServiceProvider ConfigureHostConfiguration(string sdkGenerationBasePath, string owinServerUrl, string dataPath)
        {
            // Configure service collection for DI
            var services = new ServiceCollection();

            // Add logging
            services.AddSingleton<ILoggerFactory>(NullLoggerFactory.Instance);
            services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));

            // Register the OAuth token handler as singleton
            services.AddSingleton(_tokenHandler);

            // Get the SDK assembly
            var sdkAssembly = Assembly.LoadFrom(sdkGenerationBasePath);

            // Register IOAuthTokenHandler so it can be used by TokenProvider
            services.AddSingleton(_tokenHandler);

            // Create and register TokenProvider that gets tokens from IOAuthTokenHandler
            var tokenProvider = TokenProviderFactory.CreateTokenProvider(sdkAssembly, _tokenHandler);
            if (tokenProvider != null)
            {
                var tokenProviderType = tokenProvider.GetType().BaseType;
                services.AddSingleton(tokenProviderType, tokenProvider);
            }

            // Create HostConfiguration instance and use its proper methods
            var hostConfiguration = Activator.CreateInstance(_configType, new object[] { services });

            // Call AddApiHttpClients with our HTTP client configuration
            var addApiHttpClientsMethod = _configType.GetMethod("AddApiHttpClients");
            if (addApiHttpClientsMethod != null)
            {
                // Create delegate for configuring HttpClient. The data-path suffix injected into the
                // BaseAddress is configurable (OdsApi:DataPath, default "/data/v3"); see ComposeSdkBaseAddress.
                Action<HttpClient> configureClient = (client) =>
                {
                    client.BaseAddress = ComposeSdkBaseAddress(owinServerUrl, dataPath);
                };

                // Call AddApiHttpClients(configureClient, null)
                var parameters = addApiHttpClientsMethod.GetParameters();
                if (parameters.Length == 2)
                {
                    hostConfiguration = addApiHttpClientsMethod.Invoke(hostConfiguration, new object[] { configureClient, null });
                }
            }

            // Build the service provider AFTER calling AddApiHttpClients
            var serviceProvider = services.BuildServiceProvider();
            SdkConfig = hostConfiguration;

            return serviceProvider;
        }

        /// <summary>
        ///     Composes the new-generator SDK's HttpClient BaseAddress from the server URL and the configured
        ///     data-path suffix. The SDK constructs request URLs by concatenating BaseAddress.AbsolutePath with
        ///     operation paths like "/ed-fi/...", so the base address must carry the data path WITHOUT a trailing
        ///     slash (otherwise "/data/v3//ed-fi/..."). Behavior:
        ///     <list type="bullet">
        ///         <item>Empty/whitespace/"/" data path: no segment is injected; the base URL path is kept, only
        ///         its trailing slash trimmed.</item>
        ///         <item>Otherwise the data path is normalized to a leading slash and no trailing slash.</item>
        ///         <item>If the base URL path already contains the (normalized) data path, it is not appended
        ///         again (escape hatch); the trailing slash is still trimmed.</item>
        ///     </list>
        /// </summary>
        public static Uri ComposeSdkBaseAddress(string owinServerUrl, string dataPath)
        {
            var baseUri = new Uri(owinServerUrl);
            var normalizedDataPath = NormalizeDataPath(dataPath);

            // No injection (empty/"/" data path) OR the base URL already carries the data path (escape hatch):
            // keep the base URL's own path, trimming only a trailing slash.
            var path = string.IsNullOrEmpty(normalizedDataPath) || baseUri.AbsolutePath.Contains(normalizedDataPath)
                ? baseUri.AbsolutePath.TrimEnd('/')
                : normalizedDataPath;

            return new UriBuilder(baseUri) { Path = path }.Uri;
        }

        // Normalizes a configured data path to a leading slash with no trailing slash (e.g. "data/v3/" ->
        // "/data/v3"). Returns empty string for null/whitespace/"/" to signal "do not inject a segment".
        private static string NormalizeDataPath(string dataPath)
        {
            var trimmed = dataPath?.Trim().Trim('/');

            return string.IsNullOrEmpty(trimmed)
                ? string.Empty
                : $"/{trimmed}";
        }

        private static Type TryGetTypeFromAssembly(string sdkAssemblyPath, string typeToRetrieve)
        {
            var assembly = Assembly.LoadFrom(sdkAssemblyPath);

            return assembly.GetExportedTypes()
                .FirstOrDefault(type => type.FullName != null && type.FullName.Contains(typeToRetrieve));
        }

        private static Type GetTypeFromAssembly(string sdkAssemblyPath, string typeToRetrieve)
        {
            var configType = TryGetTypeFromAssembly(sdkAssemblyPath, typeToRetrieve);

            if (configType == null)
            {
                // LoadFrom returns the already-loaded assembly, so this is cheap on the failure path.
                var assembly = Assembly.LoadFrom(sdkAssemblyPath);

                var availableTypes = string.Join(Environment.NewLine,
                    assembly.GetExportedTypes()
                        .Where(t => t.FullName != null && t.Namespace != null && t.Namespace.Contains("Client"))
                        .Select(t => $"  - {t.FullName}")
                        .OrderBy(s => s));

                throw new InvalidOperationException(
                    $"Could not find type '{typeToRetrieve}' in assembly '{sdkAssemblyPath}'.{Environment.NewLine}" +
                    $"Assembly: {assembly.FullName}{Environment.NewLine}" +
                    $"Available types in 'Client' namespace:{Environment.NewLine}{availableTypes}");
            }

            return configType;
        }
    }
}
