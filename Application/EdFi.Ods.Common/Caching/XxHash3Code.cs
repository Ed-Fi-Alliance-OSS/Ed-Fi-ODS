// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Buffers;
using System.Linq.Expressions;
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
        int value1Length = value1.GetByteLength();

        var buffer = ArrayPool<byte>.Shared.Rent(value1Length);
        value1.CopyTo(buffer);

        return xxHash3.ComputeHash(buffer, value1Length);
    }

    public static ulong Combine<T1, T2>(T1 value1, T2 value2)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();

        int bufferLength = value1Length + value2Length;

        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
        int offset = 0;

        try
        {
            value1.CopyTo(buffer.AsSpan(offset, value1Length));
            offset += value1Length;

            value2.CopyTo(buffer.AsSpan(offset, value2Length));

            return xxHash3.ComputeHash(buffer, value1Length + value2Length);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();

        int bufferLength = value1Length + value2Length + value3Length;
        
        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
        int offset = 0;

        try
        {
            value1.CopyTo(buffer.AsSpan(offset, value1Length));
            offset += value1Length;

            value2.CopyTo(buffer.AsSpan(offset, value2Length));
            offset += value2Length;

            value3.CopyTo(buffer.AsSpan(offset, value3Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();

        int bufferLength = value1Length + value2Length + value3Length + value4Length;
        
        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
        int offset = 0;

        try
        {
            value1.CopyTo(buffer.AsSpan(offset, value1Length));
            offset += value1Length;

            value2.CopyTo(buffer.AsSpan(offset, value2Length));
            offset += value2Length;

            value3.CopyTo(buffer.AsSpan(offset, value3Length));
            offset += value3Length;

            value4.CopyTo(buffer.AsSpan(offset, value4Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
    
    public static ulong Combine<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();

        int bufferLength = value1Length + value2Length + value3Length + value4Length + value5Length;
        
        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
        int offset = 0;

        try
        {
            value1.CopyTo(buffer.AsSpan(offset, value1Length));
            offset += value1Length;

            value2.CopyTo(buffer.AsSpan(offset, value2Length));
            offset += value2Length;

            value3.CopyTo(buffer.AsSpan(offset, value3Length));
            offset += value3Length;

            value4.CopyTo(buffer.AsSpan(offset, value4Length));
            offset += value4Length;

            value5.CopyTo(buffer.AsSpan(offset, value5Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length;

        var buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
        int offset = 0;

        try
        {
            value1.CopyTo(buffer.AsSpan(offset, value1Length));
            offset += value1Length;

            value2.CopyTo(buffer.AsSpan(offset, value2Length));
            offset += value2Length;

            value3.CopyTo(buffer.AsSpan(offset, value3Length));
            offset += value3Length;

            value4.CopyTo(buffer.AsSpan(offset, value4Length));
            offset += value4Length;

            value5.CopyTo(buffer.AsSpan(offset, value5Length));
            offset += value5Length;

            value6.CopyTo(buffer.AsSpan(offset, value6Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
