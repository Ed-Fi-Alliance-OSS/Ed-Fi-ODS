// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Provides contextual cache interception that can use asynchronous cache providers.
/// </summary>
/// <typeparam name="TContext">The type of contextual data used to generate the cache key.</typeparam>
public class AsyncContextualCachingInterceptor<TContext> : AsyncCachingInterceptor
    where TContext : IContextHashBytesSource
{
    private readonly IContextProvider<TContext> _contextProvider;

    public AsyncContextualCachingInterceptor(
        IAsyncCacheProvider<ulong> asyncCacheProvider,
        ICacheProvider<ulong> localCacheProvider,
        IContextProvider<TContext> contextProvider)
        : base(asyncCacheProvider, localCacheProvider) => _contextProvider = contextProvider;

    protected override ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        var context = _contextProvider.Get() ?? throw new InvalidOperationException(
                $"No context has been set for value of type '{typeof(TContext).Name}'.");

        return arguments.Length switch
        {
            0 => XxHash3Code.Combine(context.HashBytes, method.DeclaringType!.FullName, method.Name),
            1 => XxHash3Code.Combine(context.HashBytes, method.DeclaringType!.FullName, method.Name, arguments[0]),
            2 => XxHash3Code.Combine(context.HashBytes, method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1]),
            3 => XxHash3Code.Combine(context.HashBytes, method.DeclaringType!.FullName, method.Name, arguments[0], arguments[1], arguments[2]),
            _ => throw new NotImplementedException(
                                "Support for generating contextual cache keys with more than 3 arguments has not been implemented."),
        };
    }
}
