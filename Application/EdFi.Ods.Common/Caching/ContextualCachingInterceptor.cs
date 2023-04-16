// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Caching;

public class ContextualCachingInterceptor<TContext> : CachingInterceptor
    where TContext : IContextHashBytesSource
{
    private readonly IContextProvider<TContext> _contextProvider;

    public ContextualCachingInterceptor(ICacheProvider<ulong> cacheProvider, IContextProvider<TContext> contextProvider)
        : base(cacheProvider)
    {
        _contextProvider = contextProvider;
    }

    protected override ulong GenerateCacheKey(MethodInfo method, object[] arguments)
    {
        switch (arguments.Length)
        {
            case 0:
                return XxHash3Code.Combine(_contextProvider.Get().HashBytes, method.DeclaringType.FullName, method.Name);

            case 1:
                return XxHash3Code.Combine(_contextProvider.Get().HashBytes, method.DeclaringType.FullName, method.Name, arguments[0]);

            case 2:
                return XxHash3Code.Combine(_contextProvider.Get().HashBytes, method.DeclaringType.FullName, method.Name, arguments[0], arguments[1]);

            case 3:
                return XxHash3Code.Combine(_contextProvider.Get().HashBytes, method.DeclaringType.FullName, method.Name, arguments[0], arguments[1], arguments[2]);
        }

        throw new NotImplementedException(
            "Support for generating contextual cache keys with more than 3 arguments has not been implemented.");
    }
}
