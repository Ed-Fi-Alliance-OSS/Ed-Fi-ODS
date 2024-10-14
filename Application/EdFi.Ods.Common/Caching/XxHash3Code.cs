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

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }    

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();
        int value9Length = value9.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length
            + value9Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));
            offset += value8Length;

            value9.CopyTo(buffer.AsSpan(offset, value9Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
        T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();
        int value9Length = value9.GetByteLength();
        int value10Length = value10.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length
            + value9Length
            + value10Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));
            offset += value8Length;

            value9.CopyTo(buffer.AsSpan(offset, value9Length));
            offset += value9Length;

            value10.CopyTo(buffer.AsSpan(offset, value10Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
        T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();
        int value9Length = value9.GetByteLength();
        int value10Length = value10.GetByteLength();
        int value11Length = value11.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length
            + value9Length
            + value10Length
            + value11Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));
            offset += value8Length;

            value9.CopyTo(buffer.AsSpan(offset, value9Length));
            offset += value9Length;

            value10.CopyTo(buffer.AsSpan(offset, value10Length));
            offset += value10Length;

            value11.CopyTo(buffer.AsSpan(offset, value11Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
        T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();
        int value9Length = value9.GetByteLength();
        int value10Length = value10.GetByteLength();
        int value11Length = value11.GetByteLength();
        int value12Length = value12.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length
            + value9Length
            + value10Length
            + value11Length
            + value12Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));
            offset += value8Length;

            value9.CopyTo(buffer.AsSpan(offset, value9Length));
            offset += value9Length;

            value10.CopyTo(buffer.AsSpan(offset, value10Length));
            offset += value10Length;

            value11.CopyTo(buffer.AsSpan(offset, value11Length));
            offset += value11Length;

            value12.CopyTo(buffer.AsSpan(offset, value12Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
        T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();
        int value9Length = value9.GetByteLength();
        int value10Length = value10.GetByteLength();
        int value11Length = value11.GetByteLength();
        int value12Length = value12.GetByteLength();
        int value13Length = value13.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length
            + value9Length
            + value10Length
            + value11Length
            + value12Length
            + value13Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));
            offset += value8Length;

            value9.CopyTo(buffer.AsSpan(offset, value9Length));
            offset += value9Length;

            value10.CopyTo(buffer.AsSpan(offset, value10Length));
            offset += value10Length;

            value11.CopyTo(buffer.AsSpan(offset, value11Length));
            offset += value11Length;

            value12.CopyTo(buffer.AsSpan(offset, value12Length));
            offset += value12Length;

            value13.CopyTo(buffer.AsSpan(offset, value13Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();
        int value9Length = value9.GetByteLength();
        int value10Length = value10.GetByteLength();
        int value11Length = value11.GetByteLength();
        int value12Length = value12.GetByteLength();
        int value13Length = value13.GetByteLength();
        int value14Length = value14.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length
            + value9Length
            + value10Length
            + value11Length
            + value12Length
            + value13Length
            + value14Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));
            offset += value8Length;

            value9.CopyTo(buffer.AsSpan(offset, value9Length));
            offset += value9Length;

            value10.CopyTo(buffer.AsSpan(offset, value10Length));
            offset += value10Length;

            value11.CopyTo(buffer.AsSpan(offset, value11Length));
            offset += value11Length;

            value12.CopyTo(buffer.AsSpan(offset, value12Length));
            offset += value12Length;

            value13.CopyTo(buffer.AsSpan(offset, value13Length));
            offset += value13Length;

            value14.CopyTo(buffer.AsSpan(offset, value14Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public static ulong Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10, T11 value11, T12 value12, T13 value13, T14 value14, T15 value15)
    {
        int value1Length = value1.GetByteLength();
        int value2Length = value2.GetByteLength();
        int value3Length = value3.GetByteLength();
        int value4Length = value4.GetByteLength();
        int value5Length = value5.GetByteLength();
        int value6Length = value6.GetByteLength();
        int value7Length = value7.GetByteLength();
        int value8Length = value8.GetByteLength();
        int value9Length = value9.GetByteLength();
        int value10Length = value10.GetByteLength();
        int value11Length = value11.GetByteLength();
        int value12Length = value12.GetByteLength();
        int value13Length = value13.GetByteLength();
        int value14Length = value14.GetByteLength();
        int value15Length = value15.GetByteLength();

        int bufferLength = value1Length
            + value2Length
            + value3Length
            + value4Length
            + value5Length
            + value6Length
            + value7Length
            + value8Length
            + value9Length
            + value10Length
            + value11Length
            + value12Length
            + value13Length
            + value14Length
            + value15Length;

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
            offset += value6Length;

            value7.CopyTo(buffer.AsSpan(offset, value7Length));
            offset += value7Length;

            value8.CopyTo(buffer.AsSpan(offset, value8Length));
            offset += value8Length;

            value9.CopyTo(buffer.AsSpan(offset, value9Length));
            offset += value9Length;

            value10.CopyTo(buffer.AsSpan(offset, value10Length));
            offset += value10Length;

            value11.CopyTo(buffer.AsSpan(offset, value11Length));
            offset += value11Length;

            value12.CopyTo(buffer.AsSpan(offset, value12Length));
            offset += value12Length;

            value13.CopyTo(buffer.AsSpan(offset, value13Length));
            offset += value13Length;

            value14.CopyTo(buffer.AsSpan(offset, value14Length));
            offset += value14Length;

            value15.CopyTo(buffer.AsSpan(offset, value15Length));

            return xxHash3.ComputeHash(buffer, bufferLength);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
