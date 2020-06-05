#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Configuration;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Configuration
{
    public class ApiConfigurationProvider : IApiConfigurationProvider
    {
        private readonly IConfigValueProvider _configValueProvider;
        private readonly IDatabaseEngineProvider _databaseEngineProvider;

        public ApiConfigurationProvider(
            IConfigValueProvider configValueProvider,
            IDatabaseEngineProvider databaseEngineProvider)
        {
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
            _databaseEngineProvider = Preconditions.ThrowIfNull(databaseEngineProvider, nameof(databaseEngineProvider));

            ParseApiMode();
        }

        public ApiMode Mode { get; private set; }

        public DatabaseEngine DatabaseEngine
        {
            get => _databaseEngineProvider.DatabaseEngine;
        }

        public bool IsYearSpecific() => Mode?.Equals(ApiMode.YearSpecific) ?? false;

        private void ParseApiMode()
        {
            string mode = _configValueProvider.GetValue(ApiConfigurationConstants.ApiStartupType);

            if (string.IsNullOrWhiteSpace(mode))
            {
                throw new ConfigurationErrorsException($"No value found for app key {ApiConfigurationConstants.ApiStartupType}.");
            }

            if (ApiMode.TryParse(x => x.Value.EqualsIgnoreCase(mode), out ApiMode apiMode))
            {
                Mode = apiMode;
            }
            else
            {
                throw new NotSupportedException(
                    $"Not supported apiStartup:type \"{mode}\". Supported modes: {ApiConfigurationConstants.Sandbox}, {ApiConfigurationConstants.YearSpecific}, and {ApiConfigurationConstants.SharedInstance}.");
            }
        }
    }
}
#endif