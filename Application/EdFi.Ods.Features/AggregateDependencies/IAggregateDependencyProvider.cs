// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Models.GraphML;
using QuickGraph;

namespace EdFi.Ods.Features.AggregateDependencies
{
    /// <summary>
    /// Provides the responses of the aggregate dependencies endpoint.
    /// </summary>
    /// <remarks>
    /// The responses come from the resource model, which does not change while the API runs, so they are built once
    /// and the same instances are returned to every request. Callers must not modify them.
    /// </remarks>
    public interface IAggregateDependencyProvider
    {
        /// <summary>
        /// Gets the resources grouped in the order they can be loaded.
        /// </summary>
        /// <exception cref="NonAcyclicGraphException">The resource model has a circular dependency.</exception>
        IReadOnlyList<ResourceLoadOrder> GetLoadOrder();

        /// <summary>
        /// Gets the resource dependency graph.
        /// </summary>
        /// <exception cref="NonAcyclicGraphException">The resource model has a circular dependency.</exception>
        // ReSharper disable once InconsistentNaming
        GraphML GetGraphML();
    }
}
