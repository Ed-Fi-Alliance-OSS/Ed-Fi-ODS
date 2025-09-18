// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;

namespace EdFi.Ods.Common.Caching.CacheKeyProviders;

/// <summary>
/// Implements a mechanism for generating cache keys based on method signatures and arguments.
/// </summary>
public class MethodSignatureCacheKeyProvider : IMethodSignatureCacheKeyProvider
{
    /// <inheritdoc cref="IMethodSignatureCacheKeyProvider.GetKey" />
    public ulong GetKey(MethodInfo method, object[] arguments)
    {
        switch (arguments.Length)
        {
            case 0:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name);

            case 1:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0]);

            case 2:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1]);

            case 3:
                return XxHash3Code.Combine(method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1], arguments[2]);

            default:
                throw new NotImplementedException(
                    "Support for generating cache keys for more than 3 arguments has not been implemented.");
        }
    }
}
