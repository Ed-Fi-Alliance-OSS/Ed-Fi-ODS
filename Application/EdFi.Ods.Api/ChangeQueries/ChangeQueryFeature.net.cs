// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Configuration;

namespace EdFi.Ods.Api.ChangeQueries
{
    public static class ChangeQueryFeature
    {
        public static string ChangeQueriesConfigKey = "changeQueries:featureIsEnabled";

        public static bool IsEnabled => _enabled.Value;

        public static string SchoolYearTypesResourceName = "SchoolYearType";

        private static readonly Lazy<bool> _enabled = new Lazy<bool>(GetChangeQueriesConfigValue);

        private static bool GetChangeQueriesConfigValue()
        {
            bool configValue;
            bool.TryParse(ConfigurationManager.AppSettings[ChangeQueriesConfigKey], out configValue);
            return configValue;
        }
    }
}

#endif