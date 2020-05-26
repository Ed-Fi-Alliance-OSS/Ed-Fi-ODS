// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Newtonsoft.Json;

namespace Test.Common
{
    public static class DefaultTestJsonSerializer
    {
        private static readonly Lazy<JsonSerializerSettings> _defaultJsonSerializerSettings =
            new Lazy<JsonSerializerSettings>(InitializeDefaultJsonSerializerSettings);

        public static JsonSerializerSettings DefaultSettings
        {
            get { return _defaultJsonSerializerSettings.Value; }
        }

        private static JsonSerializerSettings InitializeDefaultJsonSerializerSettings()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateParseHandling = DateParseHandling.None,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return serializerSettings;
        }

        public static object DeserializeObject(string value)
        {
            return JsonConvert.DeserializeObject(value, DefaultSettings);
        }

        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, DefaultSettings);
        }
    }
}
