// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;

namespace EdFi.Ods.Common.Configuration
{
    public class ApiSettings
    {
        private readonly Lazy<DatabaseEngine> _databaseEngine;
        private readonly Lazy<ApiMode> _apiMode;

        public ApiSettings()
        {
            _databaseEngine = new Lazy<DatabaseEngine>(() => DatabaseEngine.TryParseEngine(Engine));

            _apiMode = new Lazy<ApiMode>(
                () =>
                {
                    if (ApiMode.TryParse(x => x.Value.EqualsIgnoreCase(Mode), out ApiMode apiMode))
                    {
                        return apiMode;
                    }

                    throw new NotSupportedException(
                        $"Not supported Mode \"{Mode}\". Supported modes: {ApiConfigurationConstants.Sandbox}, {ApiConfigurationConstants.YearSpecific}, and {ApiConfigurationConstants.SharedInstance}.");
                }
            );
        }

        public string Mode { get; set; }

        public string Engine { get; set; }

        public bool PlainTextSecrets { get; set; }

        public int[] Years { get; set; }

        public List<Feature> Features { get; set; } = new List<Feature>();

        public List<string> ExcludedExtensions { get; set; } = new List<string>();

        public bool? UseReverseProxyHeaders { get; set; }

        public string PathBase { get; set; }

        public DatabaseEngine GetDatabaseEngine() => _databaseEngine.Value;

        public ApiMode GetApiMode() => _apiMode.Value;

        public bool IsFeatureEnabled(string featureName)
            => Features.SingleOrDefault(x => x.Name.EqualsIgnoreCase(featureName) && x.IsEnabled) != null;
    }
}
