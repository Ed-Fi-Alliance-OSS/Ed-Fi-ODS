// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using QuickGraph;
using EntitySpecification = EdFi.Ods.Common.Specifications.EntitySpecification;

namespace EdFi.Ods.Api.Common.Models.GraphML
{
    // ReSharper disable once InconsistentNaming
    public class GraphML
    {
        public string Id { get; set; }

        public IList<GraphMLNode> Nodes { get; set; }

        public IList<GraphMLEdge> Edges { get; set; }
    }
}
