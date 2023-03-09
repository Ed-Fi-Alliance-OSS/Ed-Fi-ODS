// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Buffers;
using System.Security.Policy;
using System.Text;
using Standart.Hash.xxHash;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Provides methods for building an XxHash3 value based on multiple input arguments of different types in the same
/// vein as the <see cref="System.HashCode.Combine{T}" /> method and its related overloads.
/// </summary>
public static class XxHash3Code
{
    public static ulong Combine<T1>(T1 value1)
    {
        var value1Bytes = value1.GetBytes();

        return xxHash3.ComputeHash(value1Bytes, value1Bytes.Length);
    }

    public static ulong Combine<T1, T2>(T1 value1, T2 value2)
    {
        var value1Bytes = value1.GetBytes();
        var value2Bytes = value2.GetBytes();

        int bufferLength = value1Bytes.Length + value2Bytes.Length;

        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);

        try
        {
            value1Bytes.AsSpan().CopyTo(buffer);
            value2Bytes.AsSpan().CopyTo(buffer.AsSpan(value1Bytes.Length));

            return xxHash3.ComputeHash(buffer, value1Bytes.Length + value2Bytes.Length);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
    {
        var value1Bytes = value1.GetBytes();
        var value2Bytes = value2.GetBytes();
        var value3Bytes = value3.GetBytes();

        int bufferLength = value1Bytes.Length + value2Bytes.Length + value3Bytes.Length;
        
        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);

        try
        {
            value1Bytes.AsSpan().CopyTo(buffer);
            value2Bytes.AsSpan().CopyTo(buffer.AsSpan(value1Bytes.Length));
            value3Bytes.AsSpan().CopyTo(buffer.AsSpan(value1Bytes.Length + value2Bytes.Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
    
    public static ulong Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
    {
        var value1Bytes = value1.GetBytes();
        var value2Bytes = value2.GetBytes();
        var value3Bytes = value3.GetBytes();
        var value4Bytes = value4.GetBytes();

        int bufferLength = value1Bytes.Length + value2Bytes.Length + value3Bytes.Length + value4Bytes.Length;
        
        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);

        try
        {
            value1Bytes.AsSpan().CopyTo(buffer);
            value2Bytes.AsSpan().CopyTo(buffer.AsSpan(value1Bytes.Length));
            value3Bytes.AsSpan().CopyTo(buffer.AsSpan(value1Bytes.Length + value2Bytes.Length));
            value4Bytes.AsSpan().CopyTo(buffer.AsSpan(value1Bytes.Length + value2Bytes.Length + value3Bytes.Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}

internal static class BytesExtensions
{
    public static byte[] GetBytes<T>(this T value)
    {
        if (value is int intValue)
        {
            return BitConverter.GetBytes(intValue);
        }
            
        if (value is string stringValue)
        {
            return Encoding.UTF8.GetBytes(stringValue);
        }

        throw new NotImplementedException($"Support for extracting bytes from type '{nameof(T)}' has not been implemented.");
    }
}