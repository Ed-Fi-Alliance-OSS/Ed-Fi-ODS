// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace EdFi.Ods.Common.Caching;

public class CachingInterceptor : IInterceptor
{
    private readonly ICacheProvider<ulong> _cacheProvider;

    public CachingInterceptor(ICacheProvider<ulong> cacheProvider)
    {
        _cacheProvider = cacheProvider;
    }

    public void Intercept(IInvocation invocation)
    {
        // Compute the cache for the method invocation
        var cacheKey = GenerateCacheKey(invocation.Method, invocation.Arguments);

        // Check the cache provider for a known response
        if (_cacheProvider.TryGetCachedObject(cacheKey, out var data))
        {
            invocation.ReturnValue = data;

            return;
        }

        // Invoke the underlying method
        invocation.Proceed();

        // Cache the response
        _cacheProvider.SetCachedObject(cacheKey, invocation.ReturnValue);
    }

    protected virtual ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        switch (arguments.Length)
        {
            case 0:
                return XxHash3Code.Combine(method.DeclaringType.FullName, method.Name);

            case 1:
                return XxHash3Code.Combine(method.DeclaringType.FullName, method.Name, arguments[0]);

            case 2:
                return XxHash3Code.Combine(method.DeclaringType.FullName, method.Name, arguments[0], arguments[1]);

            case 3:
                return XxHash3Code.Combine(method.DeclaringType.FullName, method.Name, arguments[0], arguments[1], arguments[2]);
        }

        throw new NotImplementedException(
            "Support for generating cache keys for more than 3 arguments has not been implemented.");
    }
}