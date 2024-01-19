using System;
using System.Globalization;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Serialization;

/// <summary>
/// Implements a converter for long integers that more closely matches the behavior of Newtonsoft's handling of 32-bit integers.
/// </summary>
/// <remarks>This code is based on the code for handling 32-bit integers in the Newtonsoft.Json core library. See the
/// ParseReadNumber method of JsonTextReader.cs in https://github.com/JamesNK/Newtonsoft.Json/.
/// </remarks>
public class Int64Converter : JsonConverter
{
    private static readonly object[] _boxedDigits = { 0L, 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L};
        
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
        {
            return BoxedLong(default);
        }

        if (reader.ValueType == typeof(int) || reader.ValueType == typeof(long))
        {
            return BoxedLong((long) reader.Value);
        }

        string rawValue = reader.Value.ToString();

        // Null or empty string, and we leave the target value with its default value (to match core Int32 parsing behavior by JSON.NET)
        if (string.IsNullOrEmpty(rawValue))
        {
            return BoxedLong(default);
        }

        // Code based on Int32 handling in ParseReadNumber method of JsonTextReader.cs in https://github.com/JamesNK/Newtonsoft.Json/
        char firstChar = rawValue[0]; 
        bool singleDigit = (char.IsDigit(firstChar) && rawValue.Length == 1);
        bool nonBase10 = (firstChar == '0' && rawValue.Length > 1 && rawValue[1] != '.' && rawValue[1] != 'e' && rawValue[1] != 'E');

        if (singleDigit)
        {
            // digit char values start at 48
            return _boxedDigits[firstChar - 48];
        }
        
        if (nonBase10)
        {
            try
            {
                long base10Value = rawValue.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                    ? Convert.ToInt64(rawValue, 16)
                    : Convert.ToInt64(rawValue, 8);
                
                return BoxedLong(base10Value);
            }
            catch (Exception ex)
            {
                var lineInfo = reader as IJsonLineInfo;
                
                throw new JsonReaderException(
                    string.Format(
                        "Input string '{0}' is not a valid {1}. Path '{2}', line {3}, position {4}.",
                        reader.Value,
                        objectType,
                        reader.Path,
                        lineInfo.LineNumber,
                        lineInfo.LinePosition), ex);
            }
        }
        
        if (long.TryParse(rawValue, out long value))
        {
            return BoxedLong(value);
        }

        var jsonLineInfo = reader as IJsonLineInfo;

        throw new JsonReaderException(
            string.Format(
                "Input string '{0}' is not a valid {1}. Path '{2}', line {3}, position {4}.",
                reader.Value,
                objectType,
                reader.Path,
                jsonLineInfo.LineNumber,
                jsonLineInfo.LinePosition));
    }

    private static object BoxedLong(long value)
    {
        return value is >= 0 and <= 9
            ? _boxedDigits[value]
            : value;
    }
    
    public override bool CanConvert(Type objectType)
    {
        return typeof(Int64) == objectType;
    }

    // Code based on Int64 handling in the ParseReadNumber method of JsonTextReader.cs in https://github.com/JamesNK/Newtonsoft.Json/
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, System.Numerics.BigInteger.Parse(value.ToString(), CultureInfo.InvariantCulture));
    }

}