// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Configuration;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Serialization
{
    public class DatabaseEngineConverter : JsonConverter<DatabaseEngine>
    {
        public override void WriteJson(JsonWriter writer, DatabaseEngine value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Value);
        }

        public override DatabaseEngine ReadJson(JsonReader reader, Type objectType, DatabaseEngine existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            string source = (string) reader.Value;

            return DatabaseEngine.FromValue(source);
        }
    }
}
