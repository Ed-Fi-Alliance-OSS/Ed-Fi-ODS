// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;

namespace EdFi.SmokeTest.Console.Application
{
    public class SdkConfigurationFactory : ISdkConfigurationFactory
    {
        private readonly Type _configType;
        private readonly IOAuthTokenHandler _tokenHandler;
        public object SdkConfig;

        public SdkConfigurationFactory(IApiConfiguration apiConfiguration,
                                       ISdkLibraryConfiguration sdkLibraryConfiguration, IOAuthTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;

            var defaultHeader = new Dictionary<string, string>
                                {
                                    {
                                        "Content-Type","application/json"
                                    }
                                };

            var sdkGenerationBasePath = sdkLibraryConfiguration.Path;
            var owinServerUrl = apiConfiguration.Url;

            object[] args =
            {
                defaultHeader, new Dictionary<string, string>(), new Dictionary<string, string>(), owinServerUrl
            };

            _configType = GetTypeFromAssembly(sdkGenerationBasePath, EdFiConstants.SdkConfigurationNamespace);

            var configInstance = Activator.CreateInstance(_configType, args);

            SdkConfig = configInstance;
        }

        public object SdkConfiguration
        {
            get
            {
                var accessTokenProperty = _configType.GetProperty(EdFiConstants.AccessToken);
                var token = _tokenHandler.GetBearerToken();

                if (accessTokenProperty != null)
                {
                    accessTokenProperty.SetValue(SdkConfig, token);
                }

                return SdkConfig;
            }
        }

        private static Type GetTypeFromAssembly(string sdkAssemblyPath, string typeToRetrieve)
        {
            var reflectedAssemblyTypes = Assembly.LoadFrom(sdkAssemblyPath).GetExportedTypes();

            var resourceApiType =
                reflectedAssemblyTypes.First(type => type.FullName != null && type.FullName.Contains(typeToRetrieve));

            return resourceApiType;
        }
    }
}
