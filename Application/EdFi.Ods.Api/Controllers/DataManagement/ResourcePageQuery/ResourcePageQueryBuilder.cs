// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Api.Controllers.DataManagement.Utilities;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQuery
{
    public class ResourcePageQueryBuilder : IResourcePageQueryBuilder
    {
        private readonly IPhysicalNamesProvider _physicalNamesProvider;

        public ResourcePageQueryBuilder(IPhysicalNamesProvider physicalNamesProvider)
        {
            _physicalNamesProvider = physicalNamesProvider;
        }
        
        public SqlBuilder BuildQuery(Entity entity, IQueryCollection query)
        {
            var pagedIdsQueryBuilder = new SqlBuilder();
            
            // Sort results by primary key
            pagedIdsQueryBuilder.OrderByPrimaryKey(entity, _physicalNamesProvider);

            // Handle inheritance (single-level only is supported)
            if (entity.IsDerived)
            {
                pagedIdsQueryBuilder.Select("b.Id");
                pagedIdsQueryBuilder.ApplyJoinToBaseEntity(entity, _physicalNamesProvider);
            }
            else
            {
                pagedIdsQueryBuilder.Select("e.Id");
            }

            return pagedIdsQueryBuilder;
        }

        public void ApplyParameters(DynamicParameters parameters, IQueryCollection query)
        {
            // Apply criteria for reserved offset/limit parameters
            if (query.TryGetQueryParameter("limit", out int limit))
            {
                parameters.Add("limit", limit);
            }
            else
            {
                parameters.Add("limit", 25);
            }
            
            if (query.TryGetQueryParameter("skip", out int offset))
            {
                parameters.Add("offset", offset);
            }
            else
            {
                parameters.Add("offset", 0);
            }
        }
    }
}
