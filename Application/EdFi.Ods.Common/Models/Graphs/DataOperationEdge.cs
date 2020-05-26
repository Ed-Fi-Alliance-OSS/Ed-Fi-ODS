// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using QuickGraph;

namespace EdFi.Ods.Common.Models.Graphs
{
    public class DataOperationEdge : IEdge<EntityWithDataOperation>
    {
        /// <summary>
        /// Gets the source vertex
        /// </summary>
        public EntityWithDataOperation Source { get; set; }

        /// <summary>
        /// Gets the target vertex
        /// </summary>
        public EntityWithDataOperation Target { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => $"{Source as object} --> {Target as object}";
    }
}
