// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Serialization
{
    public class DictionaryStringByDatabaseEngine : JsonConverter<IDictionary<DatabaseEngine, string>>
    {
        public override void WriteJson(JsonWriter writer, IDictionary<DatabaseEngine, string> value, JsonSerializer serializer)
        {
            var target = new Dictionary<string, string>();

            foreach (DatabaseEngine engine in value.Keys)
            {
                target[engine.Value] = value[engine];
            }

            serializer.Serialize(writer, target);
        }

        public override IDictionary<DatabaseEngine, string> ReadJson(JsonReader reader, Type objectType,
            IDictionary<DatabaseEngine, string> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var target = new Dictionary<DatabaseEngine, string>();

            // Advance to the first property
            reader.Read();

            while (reader.TokenType == JsonToken.PropertyName)
            {
                var engine = DatabaseEngine.TryParseEngine((string) reader.Value);
                reader.Read();

                string value = (string) reader.Value;

                target[engine] = value;

                // Advance to next entry
                reader.Read();
            }

            return target;
        }
    }
}
