// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Caching;

public interface ISingleFlightFactoryCacheProvider<TKey, TValue>
{
    TValue GetOrCreate<TArg>(
        TKey key,
        Func<TKey, TArg, TValue> factory,
        TimeSpan singleFlightTimeout,
        TArg factoryArgument);
    
    // TValue GetOrAdd<TArg>(TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument)
    //
    // Task<object> GetOrCreateAsync<TArg>(
    //     TKey key,
    //     Func<TKey, TArg, CancellationToken, Task<object>> factory,
    //     TimeSpan singleFlightTimeout,
    //     TArg factoryArgument,
    //     CancellationToken ct = default);
}
