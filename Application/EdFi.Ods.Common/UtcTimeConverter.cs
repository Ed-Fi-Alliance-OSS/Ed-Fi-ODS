// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EdFi.Ods.Common
{
    public class UtcTimeConverter : DateTimeConverterBase
    {
        private static readonly Regex _timeParser = new Regex(
            @"^(?<Hours>[0-9]{2}):(?<Minutes>[0-9]{2})(:(?<Seconds>[0-9]{2}))?((?<UTC>Z)|((?<OffsetHours>[\-\+][0-9]{2})(:(?<OffsetMinutes>[0-9]{2}))?)?)$",
            RegexOptions.Compiled);
        
        // NOTE: https://en.wikipedia.org/wiki/List_of_UTC_offsets
        private static readonly int[] _validMinuteOffsets = {0, 30, 45};

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                if (objectType != typeof(TimeSpan?))
                {
                    throw new FormatException("Unable to convert null value to non-nullable TimeSpan.");
                }

                return null;
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new FormatException(
                    string.Format(
                        "Unexpected token parsing time. Expected string, found '{0}'.",
                        reader.TokenType));
            }

            string valueText = (string) reader.Value;

            var match = _timeParser.Match(valueText);

            if (!match.Success)
            {
                throw new FormatException("Unexpected time value format found '" + valueText + "'.");
            }

            int.TryParse(match.Groups["Hours"].Value, out int hours);

            if (hours > 23)
            {
                throw new FormatException("The hours component of the time must be between 0 and 23.");
            }
            
            int.TryParse(match.Groups["Minutes"].Value, out int minutes);

            if (minutes > 59)
            {
                throw new FormatException("The minutes component of the time must be between 0 and 59.");
            }
            
            int.TryParse(match.Groups["Seconds"].Value, out int seconds);
            
            if (seconds > 59)
            {
                throw new FormatException("The seconds component of the time must be between 0 and 59.");
            }

            int.TryParse(match.Groups["OffsetHours"].Value, out int offsetHours);

            if (offsetHours < -12 || offsetHours > 14)
            {
                // NOTE: https://en.wikipedia.org/wiki/List_of_UTC_offsets
                throw new FormatException("The hours offset of the time must be between -12 and 14.");
            }
            
            int.TryParse(match.Groups["OffsetMinutes"].Value, out int offsetMinutes);

            if (!_validMinuteOffsets.Contains(offsetMinutes))
            {
                // NOTE: https://en.wikipedia.org/wiki/List_of_UTC_offsets
                throw new FormatException("The minutes offset of the time must be 0, 30 or 45.");
            }
            
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
