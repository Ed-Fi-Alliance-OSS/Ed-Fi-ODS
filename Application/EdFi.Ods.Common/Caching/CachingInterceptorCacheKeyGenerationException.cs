// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Indicates that a problem was encountered while attempting to build the cache key during the interception of a method invocation.
/// </summary>
public class CachingInterceptorCacheKeyGenerationException : Exception
{
    public CachingInterceptorCacheKeyGenerationException() { }

    public CachingInterceptorCacheKeyGenerationException(string message)
        : base(message) { }

    public CachingInterceptorCacheKeyGenerationException(string message, Exception inner)
        : base(message, inner) { }
}
