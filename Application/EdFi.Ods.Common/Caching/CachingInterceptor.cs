// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Caching.CacheKeyProviders;
using EdFi.Ods.Common.Caching.SingleFlight;

namespace EdFi.Ods.Common.Caching;

public class CachingInterceptor(
    ISingleFlightCache<ulong, object> _singleFlightCache,
    IMethodSignatureCacheKeyProvider _cacheKeyProvider) : IAsyncInterceptor, IClearable
{
    // private readonly ConcurrentDictionary<ulong, SemaphoreSlim> _locks = new();

    public void InterceptSynchronous(IInvocation invocation)
    {
        var returnType = invocation.Method.ReturnType;

        // No caching possible on 'void' methods.
        if (returnType == typeof(void))
        {
            invocation.Proceed();

            return;
        }

        // Cache sync return values via a sync-over-async bridge if your cache only supports async.
        // Prefer to have a sync cache path; otherwise, you can do a fast path:

        ulong cacheKey = GetInvocationCacheKey(invocation);

        invocation.ReturnValue = _singleFlightCache.GetOrCreateAsync(
            cacheKey,
            static (_, inv, ct) =>
            {
                inv.Proceed();
                return Task.FromResult(inv.ReturnValue!);
            }, 
            invocation, 
            CancellationToken.None)
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();
    }

    public void InterceptAsynchronous(IInvocation invocation)
    {
        invocation.ReturnValue = InterceptTaskAsync(invocation);
        async Task InterceptTaskAsync(IInvocation invocation)
        {
            // Just proceed and await so exceptions flow correctly; no caching of Task (no value)
            invocation.Proceed();
            var task = (Task)invocation.ReturnValue!;
            await task.ConfigureAwait(false);
        }
    }

    public void InterceptAsynchronous<TResult>(IInvocation invocation)
    {
        invocation.ReturnValue = InterceptTaskOfTAsync();

        async Task<TResult> InterceptTaskOfTAsync()
        {
            var cacheKey = _cacheKeyProvider.GetKey(invocation.Method, invocation.Arguments);

            // Single-flight locking (optional)
            // var gate = _locks.GetOrAdd(cacheKey, _ => new SemaphoreSlim(1, 1));
            //
            // await gate.WaitAsync().ConfigureAwait(false);

            // try
            {
                return (TResult) await _singleFlightCache.GetOrCreateAsync(
                        cacheKey,
                        static async (_, inv, ct) =>
                        {
                            object ret;
                            
                            // If not cached, call the underlying method and await its result
                            try
                            {
                                inv.Proceed();


                            ret = inv.ReturnValue;

                            // Support Task<TResult>
                            if (ret is Task<TResult> t)
                            {
                                var result = await t; //.ConfigureAwait(false);
                                return result;
                            }

                            // Support ValueTask<TResult>
                            if (ret is ValueTask<TResult> vt)
                            {
                                var result = await vt; //.ConfigureAwait(false);

                                return result; // vt;
                            }

                            // If the method is sync (rare here) and already returned TResult
                            if (ret is TResult value)
                            {
                                return value;
                            }

                            // If the method returned Task (non-generic), we cannot cache a value
                            if (ret is Task nonGenericTask)
                            {
                                await nonGenericTask.ConfigureAwait(false);

                                throw new InvalidOperationException(
                                    $"Method {inv.Method.Name} returned Task (no result) but interceptor expected a value to cache.");
                            }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}: {ex}");

                                throw;
                            }

                            throw new InvalidOperationException(
                                $"Unsupported return type {ret?.GetType().Name} for method {inv.Method.Name}.");
                        },
                        invocation, 
                        CancellationToken.None) 
                    .ConfigureAwait(false);
            }
            // finally
            // {
            //     gate.Release();
            //
            //     // Clean up gate to prevent unbounded growth
            //     if (gate.CurrentCount == 1)
            //     {
            //         _locks.TryRemove(cacheKey, out _);
            //     }
            // }
        }
    }

    public void Clear()
    {
        if (_singleFlightCache is IClearable clearable)
        {
            clearable.Clear();

            return;
        }

        throw new NotSupportedException($"Unable to clear the underlying data associated with the {nameof(CachingInterceptor)}.");
    }

    private ulong GetInvocationCacheKey(IInvocation invocation)
    {
        ulong cacheKey;

        try
        {
            if (invocation.Method.DeclaringType == null)
            {
                throw new NotSupportedException($"Unable to generate a cache key for method '{invocation.Method.Name}' because it has no DeclaringType.");
            }

            cacheKey = _cacheKeyProvider.GetKey(invocation.Method, invocation.Arguments);
        }
        catch (Exception ex)
        {
            throw new CachingInterceptorCacheKeyGenerationException(
                $"Cache key generation failed for invocation of method '{invocation.Method.Name}' of declaring type '{invocation.Method.DeclaringType?.FullName}'.", ex);
        }

        return cacheKey;
    }
}
