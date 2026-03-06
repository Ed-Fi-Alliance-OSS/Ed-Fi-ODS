// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public object SdkConfig;

        public SdkConfigurationFactory(IApiConfiguration apiConfiguration,
                                       ISdkLibraryConfiguration sdkLibraryConfiguration, IOAuthTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;

            var sdkGenerationBasePath = sdkLibraryConfiguration.Path;
            var owinServerUrl = apiConfiguration.Url;

            // Get HostConfiguration type from the SDK
            var sdkConfigurationNamespace = $"{sdkLibraryConfiguration.SdkNamespacePrefix}.{EdFiConstants.SdkConfigurationClassName}";
            _configType = GetTypeFromAssembly(sdkGenerationBasePath, sdkConfigurationNamespace);

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
            _serviceProvider = services.BuildServiceProvider();
            SdkConfig = hostConfiguration;
        }

        public object SdkConfiguration
        {
            get
            {
                // Return the service provider for API instantiation
                return _serviceProvider;
            }
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
