// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.OwnershipBased;

public class OwnershipBasedAuthorizationFilterDefinitionsFactory : IAuthorizationFilterDefinitionsFactory
{
    private readonly AuthorizationContextDataFactory _authorizationContextDataFactory = new();

    private const string FilterPropertyName = "CreatedByOwnershipTokenId";

    /// <summary>
    /// Gets the authorization strategy's NHibernate filter definitions and a functional delegate for determining when to apply them. 
    /// </summary>
    /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and mappings.</returns>
    public IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions()
    {
        var filters = new[]
        {
            new AuthorizationFilterDefinition(
                "CreatedByOwnershipTokenId",
                null, // NOTE: For future use --> @"({currentAlias}.CreatedByOwnershipTokenId IS NOT NULL AND {currentAlias}.CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))",
                ApplyAuthorizationCriteria,
                ApplyTrackedChangesAuthorizationCriteria,
                AuthorizeInstance)
        };

        return filters;
    }

    private static void ApplyAuthorizationCriteria(
        ICriteria criteria,
        Junction @where,
        string subjectEndpointName,
        IDictionary<string, object> parameters,
        JoinType joinType)
    {
        // Defensive check to ensure required parameter is present
        if (!parameters.ContainsKey(FilterPropertyName))
        {
            throw new Exception($"Unable to find parameter '{FilterPropertyName}' for applying ownership-based authorization. Available parameters: '{string.Join("', '", parameters.Keys)}'");
        }

        // NOTE: subjectEndpointName is ignored here -- we don't expect or want any variation due to role names applied here.
        @where.ApplyPropertyFilters(parameters, FilterPropertyName);
    }

    private void ApplyTrackedChangesAuthorizationCriteria(
        AuthorizationFilterDefinition filterDefinition,
        AuthorizationFilterContext filterContext,
        Resource resource,
        int filterIndex,
        QueryBuilder queryBuilder,
        bool useOuterJoins)
    {
        throw new NotSupportedException("The ownership-based authorization strategy is not supported for authorizing requests for tracked deletes or key changes.");
    }

    private InstanceAuthorizationResult AuthorizeInstance(
        EdFiAuthorizationContext authorizationContext,
        AuthorizationFilterContext filterContext)
    {
        var contextData =
            _authorizationContextDataFactory.CreateContextData<OwnershipBasedAuthorizationContextData>(
                authorizationContext.Data);

        if (contextData == null)
        {
            return InstanceAuthorizationResult.Failed(
                new NotSupportedException(
                    "No 'OwnershipTokenId' property could be found on the resource's underlying entity in order to perform authorization. Should a different authorization strategy be used?"));
        }

        if (contextData.CreatedByOwnershipTokenId != null)
        {
            var hasOwnershipToken = authorizationContext.ApiKeyContext.OwnershipTokenIds.Any(t => t == contextData.CreatedByOwnershipTokenId);

            if (!hasOwnershipToken)
            {
                return InstanceAuthorizationResult.Failed(
                    new EdFiSecurityException(
                        "Access to the resource item could not be authorized using any of the caller's ownership tokens."));
            }
        }
        else
        {
            return InstanceAuthorizationResult.Failed(
                new EdFiSecurityException(
                    "Access to the resource item could not be authorized based on the caller's ownership token because the resource item has no owner."));
        }

        return InstanceAuthorizationResult.Success();
    }
}
