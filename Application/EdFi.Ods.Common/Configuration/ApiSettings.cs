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

        public ApiSettings()
        {
            _databaseEngine = new Lazy<DatabaseEngine>(() => DatabaseEngine.TryParseEngine(Engine));
        }

        public int BearerTokenTimeoutMinutes { get; set; } = 60;

        public int DefaultPageSizeLimit { get; set; } = 500;

        public int LogRequestResponseContentForMinutes { get; set; } = 0;

        public string Engine { get; set; }

        public bool PlainTextSecrets { get; set; }

        public int[] Years { get; set; }

        public List<Feature> Features { get; set; } = new();

        public List<ScheduledJobSetting> ScheduledJobs { get; set; } = new();

        public List<string> ExcludedExtensions { get; set; } = new();

        public bool? UseReverseProxyHeaders { get; set; }

        public string OverrideForForwardingHostServer { get; set; }

        public int? OverrideForForwardingHostPort { get; set; }

        public string PathBase { get; set; }

        public CacheSettings Caching { get; set; } = new();

        public ReverseProxySettings GetReverseProxySettings()
        {
            return new ReverseProxySettings(
                UseReverseProxyHeaders,
                OverrideForForwardingHostServer,
                OverrideForForwardingHostPort);
        }

        public DatabaseEngine GetDatabaseEngine() => _databaseEngine.Value;

        public bool IsFeatureEnabled(string featureName)
            => Features.SingleOrDefault(x => x.Name.EqualsIgnoreCase(featureName) && x.IsEnabled) != null;
    }
}
