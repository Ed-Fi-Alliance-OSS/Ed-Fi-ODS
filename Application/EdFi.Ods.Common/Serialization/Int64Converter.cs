using System;
using System.Globalization;
using Newtonsoft.Json;


namespace EdFi.Ods.Common.Serialization
{
    /// <summary>
    /// Implements a converter for long integers that more closely matches the behavior of Newtonsoft's handling of 32-bit integers.
    /// </summary>
    /// <remarks>This code is based on the code for handling 32-bit integers in the Newtonsoft.Json core library. See the
    /// ParseReadNumber method of JsonTextReader.cs in https://github.com/JamesNK/Newtonsoft.Json/.
    /// </remarks>
    public class Int64Converter : JsonConverter
    {
        private static readonly object[] _boxedDigits = { 0L, 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L };

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return BoxedLong(0);
            }

            if (reader.ValueType == typeof(int) || reader.ValueType == typeof(long))
            {
                return BoxedLong(Convert.ToInt64(reader.Value));
            }

            string rawValue = reader.Value.ToString();

            if (string.IsNullOrEmpty(rawValue))
            {
                return BoxedLong(0);
            }

            char firstChar = rawValue[0];
            bool singleDigit = (char.IsDigit(firstChar) && rawValue.Length == 1);

            if (singleDigit)
            {
                return _boxedDigits[firstChar - '0'];
            }

            // Explicit hexadecimal prefix
            if (rawValue.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    return BoxedLong(Convert.ToInt64(rawValue, 16));
                }
                catch (Exception ex)
                {
                    ThrowReaderException(reader, objectType, ex);
                }
            }

            // Treat any string of digits (even with leading 0s) as decimal
            if (long.TryParse(rawValue, NumberStyles.None, CultureInfo.InvariantCulture, out long result))
            {
                return BoxedLong(result);
            }

            ThrowReaderException(reader, objectType, null);
            return null; // never reached
        }

        private static void ThrowReaderException(JsonReader reader, Type objectType, Exception innerException)
        {
            var lineInfo = reader as IJsonLineInfo;
            throw new JsonReaderException(
                string.Format(
                    "Input string '{0}' is not a valid {1}. Path '{2}', line {3}, position {4}.",
                    reader.Value,
                    objectType,
                    reader.Path,
                    lineInfo?.LineNumber ?? 0,
                    lineInfo?.LinePosition ?? 0),
                innerException);
        }

        private static object BoxedLong(long value)
        {
            return value is >= 0 and <= 9 ? _boxedDigits[value] : value;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, System.Numerics.BigInteger.Parse(value.ToString(), CultureInfo.InvariantCulture));
        }
    }
}
