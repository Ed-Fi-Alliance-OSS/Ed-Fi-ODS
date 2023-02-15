// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;

namespace EdFi.Ods.Common.Caching;

using Castle.DynamicProxy;
using System;
using System.Collections.Generic;

public class CachingInterceptor : IInterceptor
{
    private readonly ICacheProvider<ulong> _cacheProvider;

    public CachingInterceptor(ICacheProvider<ulong> cacheProvider)
    {
        _cacheProvider = cacheProvider;
    }

    public void Intercept(IInvocation invocation)
    {
        var cacheKey = GenerateCacheKey(invocation.Method, invocation.Arguments);

        if (_cacheProvider.TryGetCachedObject(cacheKey, out var data))
        {
            invocation.ReturnValue = data;
            return;
        }

        invocation.Proceed();

        if (!invocation.Method.ReturnType.IsValueType && invocation.ReturnValue != null)
        {
            _cacheProvider.SetCachedObject(cacheKey, invocation.ReturnValue);
        }
    }

    private ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        switch (arguments.Length)
        {
            case 0:
                return XxHash3Code.Combine(method.DeclaringType.FullName, method.Name);

            case 1:
                return XxHash3Code.Combine(method.DeclaringType.FullName, method.Name, arguments[0]);

            case 2:
                return XxHash3Code.Combine(method.DeclaringType.FullName, method.Name, arguments[0], arguments[1]);
        }

        throw new NotImplementedException(
            "Support for generating cache keys for more than 2 arguments has not been implemented.");
    }
}
