// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Standart.Hash.xxHash;

namespace EdFi.Ods.Common.Caching;

public static class BytesExtensions
{
    private static readonly byte[] _enumerableItemDelimiter = { 0 };

    private static readonly byte[] _nullBytes = { 0 };

    private static readonly ILog _logger = LogManager.GetLogger(typeof(BytesExtensions));

    public static byte[] GetBytes(this byte[] bytesValue)
    {
        return bytesValue;
    }
    
    public static byte[] GetBytes<T>(this T value)
    {
        if (value is int intValue)
        {
            return BitConverter.GetBytes(intValue);
        }

        if (value is ulong ulongValue)
        {
            return BitConverter.GetBytes(ulongValue);
        }

        if (value is string stringValue)
        {
            return Encoding.UTF8.GetBytes(stringValue);
        }

        if (value is byte[] bytesValue)
        {
            return bytesValue;
        }

        if (value is IList<string> stringListValue)
        {
            return GetBytes(stringListValue);
        }

        if (value == null)
        {
            return _nullBytes;
        }

        string toStringValue = value.ToString();
        
        // If debug logging enabled. Argument's ToString() must be overidden to provide instance-specific output.
        if (_logger.IsDebugEnabled)
        {
            Type valueType = value.GetType();

            if (valueType.IsGenericType)
            {
                var toStringSpan = toStringValue.AsSpan();
                var fullNameSpan = valueType.FullName.AsSpan();

                var toStringSlice = toStringSpan.Slice(0, toStringSpan.IndexOf('['));
                var fullNameSlice = fullNameSpan.Slice(0, fullNameSpan.IndexOf('['));

                if (toStringSlice.SequenceEqual(fullNameSlice))
                {
                    throw new NotSupportedException(
                        $"The ToString method on the supplied object of type '{value.GetType().FullName}' must be overridden to be suitable for use with {nameof(GetBytes)}.");
                }
            }
            else if (toStringValue == value.GetType().FullName)
            {
                throw new NotSupportedException(
                    $"The ToString method on the supplied object of type '{value.GetType().FullName}' must be overridden to be suitable for use with {nameof(GetBytes)}.");
            }
        }

        return Encoding.UTF8.GetBytes(value.ToString());
    }

    private static byte[] GetBytes(this IList<string> value)
    {
        var byteArrays = value.Select(i => i.GetBytes()).ToList();
        
        return GetArrayBytes(byteArrays);
    }
    
    private static byte[] GetArrayBytes(List<byte[]> byteArrays)
    {
        // Handle the simple, single array case first
        if (byteArrays.Count == 1)
        {
            return xxHash3.ComputeHash(byteArrays[0], byteArrays[0].Length).GetBytes();
        }

        var totalBytes = byteArrays.Sum(x => x.Length + 1);

        var buffer = ArrayPool<byte>.Shared.Rent(totalBytes);

        try
        {
            int startIndex = 0;

            foreach (byte[] valueAsBytes in byteArrays)
            {
                valueAsBytes.AsSpan().CopyTo(buffer.AsSpan(startIndex));
                _enumerableItemDelimiter.AsSpan().CopyTo(buffer.AsSpan(startIndex + valueAsBytes.Length));
                startIndex += valueAsBytes.Length + 1;
            }

            // Reduce list to a single hash value, then return the ulong result as bytes
            return xxHash3.ComputeHash(buffer, totalBytes).GetBytes();
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
