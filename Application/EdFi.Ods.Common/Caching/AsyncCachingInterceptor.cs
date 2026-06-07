// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Provides caching interception that can use asynchronous cache providers while preserving support for synchronous methods.
/// </summary>
public class AsyncCachingInterceptor(IAsyncCacheProvider<ulong> asyncCacheProvider, ICacheProvider<ulong> localCacheProvider) : IInterceptor, IClearable
{
    private static readonly MethodInfo InterceptAsyncWithResultMethod = typeof(AsyncCachingInterceptor)
        .GetMethod(nameof(InterceptAsyncWithResultAsync), BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly object CompletedTaskValue = 1;

    private readonly IAsyncCacheProvider<ulong> _asyncCacheProvider = asyncCacheProvider;
    private readonly ICacheProvider<ulong> _localCacheProvider = localCacheProvider;

    public void Intercept(IInvocation invocation)
    {
        ulong cacheKey;

        try
        {
            if (invocation.Method.DeclaringType is null)
            {
                throw new NotSupportedException($"Unable to generate a cache key for method '{invocation.Method.Name}' because it has no DeclaringType.");
            }

            cacheKey = GenerateCacheKey(invocation.Method, invocation.Arguments);
        }
        catch (Exception ex)
        {
            throw new CachingInterceptorCacheKeyGenerationException(
                $"Cache key generation failed for invocation of method '{invocation.Method.Name}' of declaring type '{invocation.Method.DeclaringType?.FullName}'.",
                ex);
        }

        var returnType = invocation.Method.ReturnType;

        if (returnType == typeof(Task))
        {
            invocation.ReturnValue = InterceptAsyncWithoutResultAsync(invocation, cacheKey);
            return;
        }

        if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
        {
            var resultType = returnType.GetGenericArguments()[0];

            invocation.ReturnValue = InterceptAsyncWithResultMethod.MakeGenericMethod(resultType)
                .Invoke(this, [invocation, cacheKey])!;

            return;
        }

        // Reference equality check avoids making synchronous Redis call if Redis is setup as both L1 and L2 cache
        if (!ReferenceEquals(_localCacheProvider, _asyncCacheProvider)
             && _localCacheProvider.TryGetCachedObject(cacheKey, out var cachedValue))
        {
            invocation.ReturnValue = cachedValue;
            return;
        }

        var (found, value) = _asyncCacheProvider.TryGetCachedObjectAsync(cacheKey).GetAwaiter().GetResult();

        if (found)
        {
            invocation.ReturnValue = value;
            return;
        }

        invocation.Proceed();
        _asyncCacheProvider.SetCachedObjectAsync(cacheKey, invocation.ReturnValue).GetAwaiter().GetResult();
    }

    protected virtual ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        return CachingInterceptorKeyGenerator.GenerateCacheKey(method, arguments);
    }

    public void Clear()
    {
        var cleared = false;

        if (_localCacheProvider is IClearable localClearable)
        {
            localClearable.Clear();
            cleared = true;
        }

        if (!ReferenceEquals(_localCacheProvider, _asyncCacheProvider)
            && _asyncCacheProvider is IClearable asyncClearable)
        {
            asyncClearable.Clear();
            cleared = true;
        }

        if (!cleared)
        {
            throw new NotSupportedException($"Unable to clear the underlying data associated with the {nameof(AsyncCachingInterceptor)}.");
        }
    }

    private async Task InterceptAsyncWithoutResultAsync(IInvocation invocation, ulong cacheKey)
    {
        var (found, _) = await _asyncCacheProvider.TryGetCachedObjectAsync(cacheKey).ConfigureAwait(false);

        if (found)
        {
            return;
        }

        invocation.Proceed();

        var task = (Task) invocation.ReturnValue;
        await task.ConfigureAwait(false);
        await _asyncCacheProvider.SetCachedObjectAsync(cacheKey, CompletedTaskValue).ConfigureAwait(false);
    }

    private async Task<T> InterceptAsyncWithResultAsync<T>(IInvocation invocation, ulong cacheKey)
    {
        var (found, value) = await _asyncCacheProvider.TryGetCachedObjectAsync(cacheKey).ConfigureAwait(false);

        if (found)
        {
            return ConvertCachedValue<T>(value);
        }

        invocation.Proceed();

        var task = (Task<T>) invocation.ReturnValue;
        var result = await task.ConfigureAwait(false);

        await _asyncCacheProvider.SetCachedObjectAsync(cacheKey, result).ConfigureAwait(false);

        return result;
    }

    private static T ConvertCachedValue<T>(object value)
    {
        if (value is null)
        {
            return default!;
        }

        return value is T typedValue
            ? typedValue
            : (T) value;
    }
}
