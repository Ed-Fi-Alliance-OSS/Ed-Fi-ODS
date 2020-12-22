// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.NoFurtherAuthorizationRequired
{
    public class NoFurtherAuthorizationRequiredFilterHandler : IAuthorizationFilterHandler
    {
        private const string NoFurtherAuthorizationRequiredAuthorizationStrategyName = "NoFurtherAuthorizationRequired";

        public bool CanHandle(string authorizationStrategyName) 
            => authorizationStrategyName == NoFurtherAuthorizationRequiredAuthorizationStrategyName;

        public void ApplyFilter(string authorizationStrategyName, SqlBuilder sqlBuilder, Entity entity)
        {
            // Nothing to do
        }

        public void ApplyParameters(string authorizationStrategyName, DynamicParameters parameters, IQueryCollection query)
        {
            // Nothing to do
        }
    }
}
