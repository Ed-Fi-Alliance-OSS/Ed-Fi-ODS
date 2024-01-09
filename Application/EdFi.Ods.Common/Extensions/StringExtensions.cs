// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Buffers;
using EdFi.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Executes the supplied action against a read-only span of bytes converted from the string as lower-case characters (without performing string allocations).
    /// </summary>
    /// <param name="value">The source string value for the operation.</param>
    /// <param name="action">The action to be performed against the lower-case byte buffer representation.</param>
    /// <param name="arg">The argument to prevent need for closure.</param>
    /// <typeparam name="TArg">The type of the argument provided to prevent the need for a closure.</typeparam>
    /// <remarks>This extension method can be used to calculate case-insensitive hash values.</remarks>
    public static void ApplyReadOnlySpanInvariant<TArg>(this string value, ReadOnlySpanAction<byte, TArg> action, TArg arg)
    {
        var buffer = ArrayPool<byte>.Shared.Rent(value.Length);

        try
        {
            value.ForEach((c, i, b) => b[i] = Convert.ToByte(char.ToLower(c)), buffer);

            var span = new ReadOnlySpan<byte>(buffer, 0, value.Length);

            action(span, arg);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
