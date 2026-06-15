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
                                       ISdkLibraryConfiguration sdkLibraryConfiguration, IOAuthTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;

            var sdkGenerationBasePath = sdkLibraryConfiguration.Path;
            var owinServerUrl = apiConfiguration.Url;

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
                _serviceProvider = ConfigureHostConfiguration(sdkGenerationBasePath, owinServerUrl);
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

                // 4-arg ctor: (defaultHeaders, apiKey, apiKeyPrefix, basePath). The old-generator SDK
                // bakes the full request path (including /data/v3) into each operation, so the base
                // path is the configured server URL as-is.
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

        private IServiceProvider ConfigureHostConfiguration(string sdkGenerationBasePath, string owinServerUrl)
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
                // Create delegate for configuring HttpClient
                Action<HttpClient> configureClient = (client) =>
                {
                    // CRITICAL: The SDK constructs URLs by concatenating BaseAddress.AbsolutePath + "/ed-fi/..."
                    // So we need to include /data/v3 in the base address WITHOUT a trailing slash
                    // to avoid double slashes: /data/v3//ed-fi/...
                    var baseUri = new Uri(owinServerUrl);

                    // If the base URL doesn't have /data/v3, add it
                    if (!baseUri.AbsolutePath.Contains("/data/v3"))
                    {
                        var uriBuilder = new UriBuilder(baseUri)
                        {
                            Path = "/data/v3"  // No trailing slash
                        };
                        client.BaseAddress = uriBuilder.Uri;
                    }
                    else
                    {
                        // Remove trailing slash if present
                        var path = baseUri.AbsolutePath.TrimEnd('/');
                        var uriBuilder = new UriBuilder(baseUri)
                        {
                            Path = path
                        };
                        client.BaseAddress = uriBuilder.Uri;
                    }
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

        private static Type TryGetTypeFromAssembly(string sdkAssemblyPath, string typeToRetrieve)
        {
            var assembly = Assembly.LoadFrom(sdkAssemblyPath);

            return assembly.GetExportedTypes()
                .FirstOrDefault(type => type.FullName != null && type.FullName.Contains(typeToRetrieve));
        }

        private static Type GetTypeFromAssembly(string sdkAssemblyPath, string typeToRetrieve)
        {
            var assembly = Assembly.LoadFrom(sdkAssemblyPath);
            var reflectedAssemblyTypes = assembly.GetExportedTypes();

            var configType = reflectedAssemblyTypes.FirstOrDefault(
                type => type.FullName != null && type.FullName.Contains(typeToRetrieve));

            if (configType == null)
            {
                var availableTypes = string.Join(Environment.NewLine,
                    reflectedAssemblyTypes
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
