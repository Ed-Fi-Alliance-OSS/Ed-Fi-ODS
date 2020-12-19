// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.Utilities;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.PagedQueryBuilding
{
    public class ChangeQueriesPagedAggregateIdsQueryBuilderDecorator : IPagedAggregateIdsQueryBuilder
    {
        private readonly IPagedAggregateIdsQueryBuilder _queryBuilder;

        public ChangeQueriesPagedAggregateIdsQueryBuilderDecorator(IPagedAggregateIdsQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }
        
        public SqlBuilder BuildQuery(Entity entity, IQueryCollection queryCollection)
        {
            var sqlBuilder = _queryBuilder.BuildQuery(entity, queryCollection);

            if (queryCollection.ContainsKey("MinChangeVersion"))
            {
                sqlBuilder.Where("ChangeVersion >= @minChangeVersion");
            }
            
            if (queryCollection.ContainsKey("MaxChangeVersion"))
            {
                sqlBuilder.Where("ChangeVersion >= @maxChangeVersion");
            }

            return sqlBuilder;
        }

        public void ApplyParameters(DynamicParameters parameters, IQueryCollection queryCollection)
        {
            if (queryCollection.TryGetQueryParameter("MinChangeVersion", out int minChangeVersion))
            {
                parameters.Add("MinChangeVersion", minChangeVersion);
            }
            
            if (queryCollection.TryGetQueryParameter("MaxChangeVersion", out int maxChangeVersion))
            {
                parameters.Add("MaxChangeVersion", maxChangeVersion);
            }
        }
    }
}
