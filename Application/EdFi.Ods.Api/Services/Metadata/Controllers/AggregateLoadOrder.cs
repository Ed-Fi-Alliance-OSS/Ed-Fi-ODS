// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;

namespace EdFi.Ods.Api.Services.Metadata.Controllers
{
    public class AggregateLoadOrder
    {
        public string Resource { get; set; }

        public int Order { get; set; }

        public IList<string> Operations { get; set; }

        public static AggregateLoadOrder Create(EntityWithDataOperation entityDataOperation, int order)
        {
            var operations = new List<string>();

            if (entityDataOperation.DataOperation == DataOperation.Merge)
            {
                operations.AddRange(new[] {"Create", "Update"});
            }
            else
            {
                operations.Add(
                    entityDataOperation.DataOperation == DataOperation.Create
                        ? "Create"
                        : "Update");
            }

            var entity = entityDataOperation.ContextualConcreteEntity ?? entityDataOperation.Entity;
            var resource = $"/{entity.SchemaUriSegment()}/{entity.PluralName.ToCamelCase()}";

            return new AggregateLoadOrder
                   {
                       Resource = resource, Operations = operations, Order = order
                   };
        }
    }
}
