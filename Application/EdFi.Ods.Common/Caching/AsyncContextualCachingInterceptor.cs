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
public class AsyncContextualCachingInterceptor<TContext>(
    IAsyncCacheProvider<ulong> asyncCacheProvider,
    ICacheProvider<ulong> localCacheProvider,
    IContextProvider<TContext> contextProvider
) : AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider)
    where TContext : IContextHashBytesSource
{
    private readonly IContextProvider<TContext> _contextProvider = contextProvider;

    protected override ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        // Without context, we cannot generate a key here
        var context =
            _contextProvider.Get()
            ?? throw new InvalidOperationException(
                $"No context has been set for value of type '{typeof(TContext).Name}'."
            );

        return CachingInterceptorKeyGenerator.GenerateContextualCacheKey(
            context.HashBytes,
            method,
            arguments
        );
    }
}
