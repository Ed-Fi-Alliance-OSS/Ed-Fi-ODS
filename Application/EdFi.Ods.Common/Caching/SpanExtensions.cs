// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Standart.Hash.xxHash;
using BitConverter = System.BitConverter;
using DateTime = System.DateTime;
using NotImplementedException = System.NotImplementedException;
using TimeSpan = System.TimeSpan;

namespace EdFi.Ods.Common.Caching;

public static class SpanExtensions
{
    private static readonly byte[] _enumerableItemDelimiter = { 0 };
    private static readonly byte[] _nullBytes = { 0 };

    public static int GetByteLength(this byte[] value)
    {
        if (value == null)
        {
            return _nullBytes.Length;
        }

        return value.Length;
    }

    public static void CopyTo(this byte[] value, Span<byte> buffer)
    {
        if (value == null)
        {
            _nullBytes.CopyTo(buffer);
        }
        else
        {
            value.AsSpan().CopyTo(buffer);
        }
    }

    public static int GetByteLength(this string value)
    {
        if (value == null)
        {
            return _nullBytes.Length;
        }

        return value.Length * 2; // Raw bytes in .NET strings are UTF-16
    }

    public static void CopyTo(this string value, Span<byte> buffer)
    {
        if (value == null)
        {
            _nullBytes.CopyTo(buffer);
        }
        else
        {
            // Get the ReadOnlySpan<char> from the string
            var chars = value.AsSpan();

            // Interpret the characters as bytes (UTF-16)
            var rawBytes = MemoryMarshal.AsBytes(chars);
            
            rawBytes.CopyTo(buffer);
        }
    }

    public static int GetByteLength(this IList<string> value)
    {
        // We hash the combined string text into a ulong value
        return sizeof(ulong);
    }

    public static void CopyTo(this IList<string> value, Span<byte> buffer)
    {
        var totalByteLength = value.Sum(v => string.IsNullOrEmpty(v) ? _nullBytes.Length : v.GetByteLength());

        var stringsBuffer = ArrayPool<byte>.Shared.Rent(totalByteLength);

        try
        {
            int offset = 0;
        
            foreach (var item in value)
            {
                int sourceSpanLength = string.IsNullOrEmpty(item) ? 1 : item.GetByteLength();
                var targetSpan = stringsBuffer.AsSpan(offset, sourceSpanLength);

                if (string.IsNullOrEmpty(item))
                {
                    _nullBytes.CopyTo(targetSpan);
                }
                else
                {
                    item.CopyTo(targetSpan);
                }
                
                offset += sourceSpanLength;
            }

            // We cannot return these bytes because they are part of shared pool, so reduce the list to a single hash value, then return the ulong result as bytes
            var hashValue = xxHash3.ComputeHash(stringsBuffer, totalByteLength);

            hashValue.CopyTo(buffer);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(stringsBuffer);
        }
    }

    public static int GetByteLength(this int intValue)
    {
        return sizeof(int);
    }

    public static void CopyTo(this int intValue, Span<byte> buffer)
    {
        BitConverter.TryWriteBytes(buffer, intValue);
    }

    public static int GetByteLength(this ulong ulongValue)
    {
        return sizeof(ulong);
    }
    
    public static void CopyTo(this ulong ulongValue, Span<byte> buffer)
    {
        BitConverter.TryWriteBytes(buffer, ulongValue);
    }

    public static int GetByteLength(this DateTime dateTimeValue)
    {
        return sizeof(long);
    }

    public static void CopyTo(this DateTime dateTimeValue, Span<byte> buffer)
    {
        long dateBinary = dateTimeValue.ToBinary();
        BitConverter.TryWriteBytes(buffer, dateBinary);
    }

    public static int GetByteLength(this long longValue)
    {
        return sizeof(long);
    }

    public static void CopyTo(this long longValue, Span<byte> buffer)
    {
        BitConverter.TryWriteBytes(buffer, longValue);
    }

    public static int GetByteLength(this short shortValue)
    {
        return sizeof(short);
    }

    public static void CopyTo(this short shortValue, Span<byte> buffer)
    {
        BitConverter.TryWriteBytes(buffer, shortValue);
    }

    public static int GetByteLength(this TimeSpan timeSpanValue)
    {
        return sizeof(long);
    }

    public static void CopyTo(this TimeSpan timeSpanValue, Span<byte> buffer)
    {
        var timeSpanTicks = timeSpanValue.Ticks;
        BitConverter.TryWriteBytes(buffer, timeSpanTicks);
    }

    public static void CopyTo<T>(this T value, Span<byte> buffer)
    {
        if (value == null)
        {
            _nullBytes.CopyTo(buffer);
        }

        if (value is int intValue)
        {
            intValue.CopyTo(buffer);
            return;
        }

        if (value is ulong ulongValue)
        {
            ulongValue.CopyTo(buffer);
            return;
        }

        if (value is DateTime dateTimeValue)
        {
            dateTimeValue.CopyTo(buffer);
            return;
        }

        if (value is string stringValue)
        {
            stringValue.CopyTo(buffer);
            return;
        }

        if (value is IList<string> stringListValue)
        {
            stringListValue.CopyTo(buffer);
            return;
        }

        if (value is long longValue)
        {
            longValue.CopyTo(buffer);
            return;
        }

        if (value is byte[] bytesValue)
        {
            bytesValue.CopyTo(buffer);
            return;
        }

        if (value is short shortValue)
        {
            shortValue.CopyTo(buffer);
            return;
        }

        if (value is TimeSpan timeSpanValue)
        {
            timeSpanValue.CopyTo(buffer);
            return;
        }

        throw new NotImplementedException($"Support for copying bytes from type '{typeof(T)}' to a buffer has not been implemented.");
    }
    
    public static int GetByteLength<T>(this T value)
    {
        if (value == null)
        {
            return _nullBytes.Length;
        }

        if (value is int intValue)
        {
            return intValue.GetByteLength();
        }

        if (value is ulong ulongValue)
        {
            return ulongValue.GetByteLength();
        }

        if (value is DateTime dateTimeValue)
        {
            return dateTimeValue.GetByteLength();
        }

        if (value is string stringValue)
        {
            return stringValue.GetByteLength();
        }
        
        if (value is IList<string> stringListValue)
        {
            return stringListValue.GetByteLength();
        }

        if (value is long longValue)
        {
            return longValue.GetByteLength();
        }

        if (value is byte[] bytesValue)
        {
            return bytesValue.GetByteLength();
        }
        
        if (value is short shortValue)
        {
            return shortValue.GetByteLength();
        }

        if (value is TimeSpan timeSpanValue)
        {
            return timeSpanValue.GetByteLength();
        }

        throw new NotImplementedException($"Support for determining byte length for type '{typeof(T)}' has not been implemented.");
    }
}
