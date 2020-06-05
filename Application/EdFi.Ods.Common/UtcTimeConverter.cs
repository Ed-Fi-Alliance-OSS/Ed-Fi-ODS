// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EdFi.Ods.Common
{
    public class UtcTimeConverter : DateTimeConverterBase
    {
        private readonly Regex timeParser = new Regex(
            @"^(?<Hours>[0-9]{2}):(?<Minutes>[0-9]{2})(:(?<Seconds>[0-9]{2}))?((?<UTC>Z)|((?<OffsetHours>[\-\+][0-9]{2})(:(?<OffsetMinutes>[0-9]{2}))?)?)$",
            RegexOptions.Compiled);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                if (objectType != typeof(TimeSpan?))
                {
                    throw new Exception("Unable to convert Null value to non-nullable TimeSpan.");
                }

                return null;
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new Exception(
                    string.Format(
                        "Unexpected token parsing time. Expected string, found '{0}'.",
                        reader.TokenType));
            }

            string valueText = (string) reader.Value;

            var match = timeParser.Match(valueText);

            if (!match.Success)
            {
                throw new Exception("Unexpected time value format found '" + valueText + "'.");
            }

            int hours, minutes, seconds, offsetHours, offsetMinutes;

            int.TryParse(
                match.Groups["Hours"]
                     .Value,
                out hours);

            int.TryParse(
                match.Groups["Minutes"]
                     .Value,
                out minutes);

            int.TryParse(
                match.Groups["Seconds"]
                     .Value,
                out seconds);

            int.TryParse(
                match.Groups["OffsetHours"]
                     .Value,
                out offsetHours);

            int.TryParse(
                match.Groups["OffsetMinutes"]
                     .Value,
                out offsetMinutes);

            var baseTime = new TimeSpan(hours, minutes, seconds);
            var offset = new TimeSpan(offsetHours, offsetMinutes, 0);

            var returnValue = baseTime.Subtract(offset);

            if (returnValue.TotalDays > 1)
            {
                return returnValue.Subtract(TimeSpan.FromDays(1));
            }

            if (returnValue < TimeSpan.Zero)
            {
                return returnValue.Add(TimeSpan.FromDays(1));
            }

            return returnValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
