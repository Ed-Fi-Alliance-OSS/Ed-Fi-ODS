// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Common.Models.Resource;
using QuickGraph;

namespace EdFi.Ods.Common.Security
{
    public interface IResourceLoadGraphTransformer
    {
        void Transform(BidirectionalGraph<Resource, AssociationViewEdge> resourceGraph);
    }
}
