// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.Utilities;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQuery
{
    public class ChangeQueriesResourcePageQueryBuilderDecorator : IResourcePageQueryBuilder
    {
        private readonly IResourcePageQueryBuilder _queryBuilder;

        public ChangeQueriesResourcePageQueryBuilderDecorator(IResourcePageQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }
        
        public SqlBuilder BuildQuery(Entity entity, IQueryCollection query)
        {
            var sqlBuilder = _queryBuilder.BuildQuery(entity, query);

            if (query.ContainsKey("MinChangeVersion"))
            {
                sqlBuilder.Where("ChangeVersion >= @MinChangeVersion");
            }
            
            if (query.ContainsKey("MaxChangeVersion"))
            {
                sqlBuilder.Where("ChangeVersion <= @MaxChangeVersion");
            }

            return sqlBuilder;
        }

        public void ApplyParameters(DynamicParameters parameters, IQueryCollection query)
        {
            if (query.TryGetQueryParameter("MinChangeVersion", out int minChangeVersion))
            {
                parameters.Add("MinChangeVersion", minChangeVersion);
            }
            
            if (query.TryGetQueryParameter("MaxChangeVersion", out int maxChangeVersion))
            {
                parameters.Add("MaxChangeVersion", maxChangeVersion);
            }
        }
    }
}
