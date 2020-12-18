// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.QueryBuilding
{
    public class PagedAggregateIdsQueryBuilderAuthorization : IPagedAggregateIdsQueryBuilder
    {
        private readonly IPagedAggregateIdsQueryBuilder _queryBuilder;

        public PagedAggregateIdsQueryBuilderAuthorization(IPagedAggregateIdsQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public SqlBuilder BuildQuery(Entity entity, IQueryCollection queryCollection)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyParameters(DynamicParameters parameters, IQueryCollection queryCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}
