// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased;

public class NamespaceBasedAuthorizationFilterDefinitionsFactory : IAuthorizationFilterDefinitionsFactory
{
    private readonly IDatabaseNamingConvention _databaseNamingConvention;
    private readonly AuthorizationContextDataFactory _authorizationContextDataFactory = new();

    private const string FilterPropertyName = "Namespace";
    private readonly string _oldNamespaceQueryColumnExpression;

    private const string TrackedChangesAlias = "c";

    public NamespaceBasedAuthorizationFilterDefinitionsFactory(IDatabaseNamingConvention databaseNamingConvention)
    {
        _databaseNamingConvention = databaseNamingConvention;

        _oldNamespaceQueryColumnExpression = $"{TrackedChangesAlias}.{databaseNamingConvention.ColumnName($"OldNamespace")}";
    }

    /// <summary>
    /// Gets the authorization strategy's NHibernate filter definitions and a functional delegate for determining when to apply them.
    /// </summary>
    /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and mappings.</returns>
    public IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions()
    {
        var filters = new List<AuthorizationFilterDefinition>
        {
            new(
                "Namespace",
                @"({currentAlias}.{subjectEndpointName} IS NOT NULL AND {currentAlias}.{subjectEndpointName} LIKE :Namespace)",
                ApplyAuthorizationCriteria,
                ApplyTrackedChangesAuthorizationCriteria,
                AuthorizeInstance)
        }.AsReadOnly();

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
        if (!parameters.TryGetValue(FilterPropertyName, out var parameterValue))
        {
            throw new Exception(
                $"Unable to find parameter '{FilterPropertyName}' for applying namespace-based authorization. Available parameters: '{string.Join("', '", parameters.Keys)}'");
        }

        // Ensure the Namespace parameter is represented as an object array
        var namespacePrefixes = parameterValue as object[] ?? new[] { parameterValue };

        // Combine the namespace filters using OR (only one must match to grant authorization)
        var namespacesDisjunction = new Disjunction();

        foreach (var namespacePrefix in namespacePrefixes)
        {
            namespacesDisjunction.Add(Restrictions.Like(subjectEndpointName, namespacePrefix));
        }

        // Add the final namespaces criteria to the supplied WHERE clause (junction)
        @where.Add(new AndExpression(Restrictions.IsNotNull(subjectEndpointName), namespacesDisjunction));
    }

    private static PropertyMapping[] GetContextDataPropertyMappings(string resourceFullName, IEnumerable<string> availablePropertyNames)
    {
        return new PropertyMapping[]
        {
            new(
                NamespaceAuthorizationConvention.GetNamespacePropertyName(resourceFullName, availablePropertyNames),
                "Namespace")
        };
    }
    
    private InstanceAuthorizationResult AuthorizeInstance(
        EdFiAuthorizationContext authorizationContext,
        AuthorizationFilterContext authorizationFilterContext)
    {
        try
        {
            var contextData =
                _authorizationContextDataFactory.CreateContextData<NamespaceBasedAuthorizationContextData>(
                    authorizationContext.Data, getContextDataPropertyMappings: GetContextDataPropertyMappings);

            if (contextData == null)
            {
                return InstanceAuthorizationResult.Failed(
                    new NotSupportedException(
                        "No 'Namespace' (or Namespace-suffixed) property could be found on the resource in order to perform authorization. Should a different authorization strategy be used?"));
            }

            if (string.IsNullOrWhiteSpace(contextData.Namespace))
            {
                return InstanceAuthorizationResult.Failed(
                    new EdFiSecurityException(
                        "Access to the resource item could not be authorized because the Namespace of the resource is empty."));
            }

            var claimNamespacePrefixes = NamespaceBasedAuthorizationHelpers.GetClaimNamespacePrefixes(authorizationContext);

            if (!claimNamespacePrefixes.Any(ns => contextData.Namespace.StartsWithIgnoreCase(ns)))
            {
                string claimNamespacePrefixesText = string.Join("', '", claimNamespacePrefixes);

                return InstanceAuthorizationResult.Failed(
                    new EdFiSecurityException(
                        $"Access to the resource item could not be authorized based on the caller's NamespacePrefix claims: '{claimNamespacePrefixesText}'."));
            }
        }
        catch (EdFiSecurityException ex)
        {
            return InstanceAuthorizationResult.Failed(ex);
        }

        return InstanceAuthorizationResult.Success();
    }

    private void ApplyTrackedChangesAuthorizationCriteria(
        AuthorizationFilterDefinition filterDefinition,
        AuthorizationFilterContext filterContext,
        Resource resource,
        int filterIndex,
        QueryBuilder queryBuilder,
        bool useOuterJoins)
    {
        if (filterContext.ClaimParameterValues.Length == 1)
        {
            if (filterContext.SubjectEndpointName == "Namespace")
            {
                queryBuilder.WhereLike($"{_oldNamespaceQueryColumnExpression}", filterContext.ClaimParameterValues.Single());
            }
            else
            {
                queryBuilder.WhereLike(
                    $"{TrackedChangesAlias}.{_databaseNamingConvention.ColumnName($"Old{filterContext.SubjectEndpointName}")}",
                    filterContext.ClaimParameterValues.Single());
            }
        }
        else if (filterContext.ClaimParameterValues.Length > 1)
        {
            queryBuilder.Where(
                q =>
                {
                    if (filterContext.SubjectEndpointName == "Namespace")
                    {
                        filterContext.ClaimParameterValues.ForEach(ns => q.OrWhereLike(_oldNamespaceQueryColumnExpression, ns));
                    }
                    else
                    {
                        filterContext.ClaimParameterValues.ForEach(
                            ns => q.OrWhereLike(
                                $"{TrackedChangesAlias}.{_databaseNamingConvention.ColumnName($"Old{filterContext.SubjectEndpointName}")}",
                                ns));
                    }

                    return q;
                });
        }
        else
        {
            // This should never happen
            throw new EdFiSecurityException("No namespaces found in claims.");
        }
    }
}
