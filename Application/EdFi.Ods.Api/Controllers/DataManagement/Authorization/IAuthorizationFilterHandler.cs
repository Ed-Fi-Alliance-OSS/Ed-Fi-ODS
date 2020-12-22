// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization
{
    public interface IAuthorizationFilterHandler
    {
        /// <summary>
        /// Indicates whether the current implementation can handle the specified authorization strategy.
        /// </summary>
        /// <param name="authorizationStrategyName">The name of the authorization strategy being used for authorization.</param>
        /// <returns><b>true</b> if authorization can be handled by this implementation; otherwise <b>false</b>.</returns>
        bool CanHandle(string authorizationStrategyName);
        
        /// <summary>
        /// Applies authorization strategy-specific filtering to the query.
        /// </summary>
        /// <param name="authorizationStrategyName">The name of the authorization strategy being used for authorization.</param>
        /// <param name="sqlBuilder">The <see cref="SqlBuilder" /> representing the resource page query for the API request.</param>
        /// <param name="entity">The aggregate root <see cref="Entity" />.</param>
        void ApplyFilter(string authorizationStrategyName, SqlBuilder sqlBuilder, Entity entity);

        /// <summary>
        /// Applies authorization strategy-specific parameters to the query. 
        /// </summary>
        /// <param name="authorizationStrategyName">The name of the authorization strategy being used for authorization.</param>
        /// <param name="parameters">The parameters collection to apply additional authorization strategy-specific parameters.</param>
        /// <param name="query">The collection of parsed query string parameters from the API request.</param>
        void ApplyParameters(string authorizationStrategyName, DynamicParameters parameters, IQueryCollection query);
    }
}
