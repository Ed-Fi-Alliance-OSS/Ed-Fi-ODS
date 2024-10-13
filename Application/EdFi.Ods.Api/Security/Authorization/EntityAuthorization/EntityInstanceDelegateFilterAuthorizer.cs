// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

public interface IEntityInstanceDelegateFilterAuthorizer
{
    AuthorizationStrategyFilterResults[] PerformInstanceBasedAuthorization(
        FilterOperator filterOperator,
        IReadOnlyList<AuthorizationStrategyFiltering> authorizationStrategyFilterings,
        DataManagementRequestContext dataManagementRequestContext);
}

public class EntityInstanceDelegateFilterAuthorizer : IEntityInstanceDelegateFilterAuthorizer
{
    private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;

    public EntityInstanceDelegateFilterAuthorizer(IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider)
    {
        _authorizationFilterDefinitionProvider = authorizationFilterDefinitionProvider;
    }

    public AuthorizationStrategyFilterResults[] PerformInstanceBasedAuthorization(
        FilterOperator filterOperator,
        IReadOnlyList<AuthorizationStrategyFiltering> authorizationStrategyFilterings,
        DataManagementRequestContext dataManagementRequestContext)
    {
        var results = authorizationStrategyFilterings.Where(asf => asf.Operator == filterOperator)
            .Select(
                s => new AuthorizationStrategyFilterResults
                {
                    AuthorizationStrategyName = s.AuthorizationStrategyName,
                    Operator = s.Operator,
                    FilterResults = s.Filters
                        .Select(
                            f => new
                            {
                                FilterDefinition =
                                    _authorizationFilterDefinitionProvider.GetAuthorizationFilterDefinition(f.FilterName),
                                FilterContext = f
                            })
                        .Select(
                            x => new FilterAuthorizationResult
                            {
                                FilterDefinition = x.FilterDefinition,
                                FilterContext = x.FilterContext,
                                Result = x.FilterDefinition.AuthorizeInstance(
                                    dataManagementRequestContext,
                                    x.FilterContext,
                                    s.AuthorizationStrategyName)
                            })
                        .ToArray()
                })
            .ToArray();

        return results;
    }
}
