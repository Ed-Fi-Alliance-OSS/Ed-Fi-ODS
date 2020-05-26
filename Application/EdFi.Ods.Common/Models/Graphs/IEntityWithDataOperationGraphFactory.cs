// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Threading.Tasks;
using QuickGraph;

namespace EdFi.Ods.Common.Models.Graphs
{
    /// <summary>
    /// Defines a method for creating a graph containing entities and their dependencies at an operation level.
    /// </summary>
    public interface IEntityWithDataOperationGraphFactory
    {
        /// <summary>
        /// Creates a new graph containing the Ed-Fi model's entities and their dependencies at an
        /// operation level, optionally performing the predefined graph transformations.
        /// </summary>
        /// <param name="includeTransformations">Indicates whether to perform transformations on the graph
        /// (e.g. based on known authorization constraints -- first create students, then create student
        /// school associations, then update students).
        /// </param>
        /// <returns>A new graph instance.</returns>
        BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> CreateGraph(bool includeTransformations);
    }
}
