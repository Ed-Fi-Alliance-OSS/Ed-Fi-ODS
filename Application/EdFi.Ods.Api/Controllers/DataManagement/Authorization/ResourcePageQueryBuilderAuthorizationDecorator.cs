// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.Authorization.Details;
using EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQuery;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization
{
    public class ResourcePageQueryBuilderAuthorizationDecorator : IResourcePageQueryBuilder
    {
        private readonly IRequestAuthorizationDetailsProvider _requestAuthorizationDetailsProvider;
        private readonly IAuthorizationFilterHandler[] _authorizationFilterHandlers;
        private readonly IResourcePageQueryBuilder _resourcePageQueryBuilder;

        public ResourcePageQueryBuilderAuthorizationDecorator(
            IResourcePageQueryBuilder resourcePageQueryBuilder,
            IRequestAuthorizationDetailsProvider requestAuthorizationDetailsProvider,
            IAuthorizationFilterHandler[] authorizationFilterHandlers)
        {
            _resourcePageQueryBuilder = resourcePageQueryBuilder;
            _requestAuthorizationDetailsProvider = requestAuthorizationDetailsProvider;
            _authorizationFilterHandlers = authorizationFilterHandlers;
        }

        public SqlBuilder BuildQuery(Entity entity, IQueryCollection query)
        {
            // Build the main paged query for the resource
            var sqlBuilder = _resourcePageQueryBuilder.BuildQuery(entity, query);

            var requestAuthorizationDetails = _requestAuthorizationDetailsProvider.GetRequestAuthorizationDetails();

            foreach (var filterHandler in _authorizationFilterHandlers)
            {
                if (!filterHandler.CanHandle(requestAuthorizationDetails.AuthorizationStrategyName))
                {
                    continue;
                }

                filterHandler.ApplyFilter(requestAuthorizationDetails.AuthorizationStrategyName, sqlBuilder, entity);
                return sqlBuilder;
            }

            throw new ApiSecurityConfigurationException(
                $"Authorization of request using authorization strategy '{requestAuthorizationDetails.AuthorizationStrategyName}' was not handled.");
        }

        public void ApplyParameters(DynamicParameters parameters, IQueryCollection query)
        {
            // Pass call through
            _resourcePageQueryBuilder.ApplyParameters(parameters, query);
            
            var requestAuthorizationDetails = _requestAuthorizationDetailsProvider.GetRequestAuthorizationDetails();

            foreach (var filterHandler in _authorizationFilterHandlers)
            {
                if (!filterHandler.CanHandle(requestAuthorizationDetails.AuthorizationStrategyName))
                {
                    continue;
                }

                filterHandler.ApplyParameters(requestAuthorizationDetails.AuthorizationStrategyName, parameters, query);

                return;
            }
            
            throw new ApiSecurityConfigurationException(
                $"Authorization of request using authorization strategy '{requestAuthorizationDetails.AuthorizationStrategyName}' was not handled.");
        }
    }
}
