// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;

namespace EdFi.Ods.Common.Caching;

internal static class CachingInterceptorKeyGenerator
{
    public static ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        return arguments.Length switch
        {
            0 => XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name),
            1 => XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0]),
            2 => XxHash3Code.Combine(
                method.DeclaringType!.FullName,
                method.Name,
                arguments[0],
                arguments[1]
            ),
            3 => XxHash3Code.Combine(
                method.DeclaringType!.FullName,
                method.Name,
                arguments[0],
                arguments[1],
                arguments[2]
            ),
            _ => throw new NotImplementedException(
                "Support for generating cache keys for more than 3 arguments has not been implemented."
            ),
        };
    }

    public static ulong GenerateContextualCacheKey(
        byte[] contextHashBytes,
        MethodInfo method,
        object[] arguments
    )
    {
        return arguments.Length switch
        {
            0 => XxHash3Code.Combine(contextHashBytes, method.DeclaringType!.FullName, method.Name),
            1 => XxHash3Code.Combine(
                contextHashBytes,
                method.DeclaringType!.FullName,
                method.Name,
                arguments[0]
            ),
            2 => XxHash3Code.Combine(
                contextHashBytes,
                method.DeclaringType!.FullName,
                method.Name,
                arguments[0],
                arguments[1]
            ),
            3 => XxHash3Code.Combine(
                contextHashBytes,
                method.DeclaringType!.FullName,
                method.Name,
                arguments[0],
                arguments[1],
                arguments[2]
            ),
            _ => throw new NotImplementedException(
                "Support for generating contextual cache keys with more than 3 arguments has not been implemented."
            ),
        };
    }
}
