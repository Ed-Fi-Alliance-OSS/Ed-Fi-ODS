// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using EdFi.Ods.Api.Models.GraphML;

namespace EdFi.Ods.Features.Controllers
{
    /// <summary>
    /// Holds the responses of the aggregate dependencies endpoint for the life of the process. They come from the
    /// resource model, which does not change while the API runs, so they are built once instead of on every request.
    /// </summary>
    /// <remarks>
    /// Each response is built by the first request that needs it. If building it throws, the exception is kept and
    /// thrown again to later requests, so a model with a circular dependency is not analyzed again on every call.
    /// </remarks>
    public class AggregateDependencyCache
    {
        private readonly object _lock = new();
        private Lazy<IReadOnlyList<ResourceLoadOrder>> _loadOrder;
        private Lazy<GraphML> _graphML;

        public IReadOnlyList<ResourceLoadOrder> GetLoadOrder(Func<IReadOnlyList<ResourceLoadOrder>> createLoadOrder)
            => GetOrCreate(ref _loadOrder, createLoadOrder).Value;

        // ReSharper disable once InconsistentNaming
        public GraphML GetGraphML(Func<GraphML> createGraphML)
            => GetOrCreate(ref _graphML, createGraphML).Value;

        private Lazy<T> GetOrCreate<T>(ref Lazy<T> lazy, Func<T> create)
        {
            if (Volatile.Read(ref lazy) == null)
            {
                lock (_lock)
                {
                    lazy ??= new Lazy<T>(create, LazyThreadSafetyMode.ExecutionAndPublication);
                }
            }

            return lazy;
        }
    }
}
