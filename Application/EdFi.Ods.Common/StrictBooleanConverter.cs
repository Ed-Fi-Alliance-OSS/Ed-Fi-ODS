// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Extensions;
using Newtonsoft.Json;

namespace EdFi.Ods.Common;

/// <summary>
/// Implements a boolean converter that is much less forgiving than the default .NET conversion to boolean in that it only allows
/// for values of true, false, "true", "false", 0 or 1.
/// </summary>
public class StrictBooleanConverter : JsonConverter
{
    public override bool CanWrite
    {
        get => false;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool)
            || objectType == typeof(bool?)
            || objectType == typeof(string)
            || objectType == typeof(int);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Handle nulls for nullable bools
        if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonToken.Boolean)
        {
            return (bool) reader.Value;
        }

        if (reader.TokenType == JsonToken.String)
        {
            var textValue = (string)reader.Value;

            if (textValue.EqualsIgnoreCase("true")) return true;
            if (textValue.EqualsIgnoreCase("false")) return false;
        }

        if (reader.TokenType == JsonToken.Integer)
        {
            var intVal = Convert.ToInt32(reader.Value);

            if (intVal == 0) return false;
            if (intVal == 1) return true;
        }

        throw new JsonSerializationException($"Unexpected value for boolean: {reader.Value} (type: {reader.TokenType})");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
