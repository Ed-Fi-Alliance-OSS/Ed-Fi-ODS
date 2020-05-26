// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Common.Models.Graphs;
using QuickGraph;

namespace EdFi.Ods.Common.Security
{
    public interface IEntityWithDataOperationTransformer
    {
        void Transform(BidirectionalGraph<EntityWithDataOperation, DataOperationEdge> graph);
    }
}
