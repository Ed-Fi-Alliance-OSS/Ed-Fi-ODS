// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Standart.Hash.xxHash;

namespace EdFi.Ods.Common.Caching;

public static class BytesExtensions
{
    private static readonly byte[] _enumerableItemDelimiter = { 0 };

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
        
        throw new NotImplementedException($"Support for extracting bytes from type '{typeof(T)}' has not been implemented.");
    }

    private static byte[] GetBytes(this IList<string> value)
    {
        var byteArrays = value.Select(i => i.GetBytes()).ToList();
        
        return GetArrayBytes(byteArrays);
    }
    
    private static byte[] GetArrayBytes(List<byte[]> byteArrays)
    {
        var totalBytes = byteArrays.Sum(x => x.Length + 1);

        var buffer = ArrayPool<byte>.Shared.Rent(totalBytes);

        try
        {
            int startIndex = 0;

            foreach (byte[] valueAsBytes in byteArrays)
            {
                valueAsBytes.AsSpan().CopyTo(buffer.AsSpan(startIndex));
                _enumerableItemDelimiter.AsSpan().CopyTo(buffer.AsSpan(valueAsBytes.Length + 1));
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
