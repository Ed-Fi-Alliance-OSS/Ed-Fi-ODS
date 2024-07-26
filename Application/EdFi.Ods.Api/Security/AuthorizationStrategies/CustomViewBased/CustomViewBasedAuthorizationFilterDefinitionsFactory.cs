// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.Extensions;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;

// ------------------------------------------------------------------------------------------
// TODO: ODS-6426, ODS-6427 - This file is a work-in-progress across multiple stories.
// ------------------------------------------------------------------------------------------

public class CustomViewBasedAuthorizationFilterDefinitionsFactory : IAuthorizationFilterDefinitionsFactory
{
    // private readonly IDatabaseNamingConvention _databaseNamingConvention;
    // private readonly AuthorizationContextDataFactory _authorizationContextDataFactory = new();

    private readonly IEducationOrganizationIdNamesProvider _educationOrganizationIdNamesProvider;
    private readonly IApiClientContextProvider _apiClientContextProvider;
    private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
    private readonly ICustomViewBasisEntityProvider _customViewBasisEntityProvider;

    public CustomViewBasedAuthorizationFilterDefinitionsFactory(
        // IDatabaseNamingConvention databaseNamingConvention,
        IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider,
        IApiClientContextProvider apiClientContextProvider,
        IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
        ICustomViewBasisEntityProvider customViewBasisEntityProvider)
    {
        // _databaseNamingConvention = databaseNamingConvention;
        _educationOrganizationIdNamesProvider = educationOrganizationIdNamesProvider;
        _apiClientContextProvider = apiClientContextProvider;
        _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        _customViewBasisEntityProvider = customViewBasisEntityProvider;

        // _oldNamespaceQueryColumnExpression = $"{TrackedChangesAlias}.{databaseNamingConvention.ColumnName($"OldNamespace")}";
    }

    public AuthorizationFilterDefinition CreateAuthorizationFilterDefinition(string filterName)
    {
        var result = _customViewBasisEntityProvider.GetBasisEntity(filterName);

        if (result.entity == null)
        {
            return null;
        }

        var filter = 
            new ViewBasedAuthorizationFilterDefinition(
                filterName,
                filterName,
                result.entity.Identifier.Properties.Select(p => p.PropertyName).ToArray(),
                ApplyTrackedChangesAuthorizationCriteria,
                // @"({currentAlias}.{subjectEndpointName} IS NOT NULL AND {currentAlias}.{subjectEndpointName} LIKE :Namespace)",
                // ApplyAuthorizationCriteria,
                // ApplyTrackedChangesAuthorizationCriteria,
                AuthorizeInstance, 
                _viewBasedSingleItemAuthorizationQuerySupport);

        return filter;
    }

    /// <summary>
    /// Gets the authorization strategy's NHibernate filter definitions and a functional delegate for determining when to apply them.
    /// </summary>
    /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and mappings.</returns>
    public IReadOnlyList<AuthorizationFilterDefinition> CreatePredefinedAuthorizationFilterDefinitions()
    {
        return Array.Empty<AuthorizationFilterDefinition>();
    }

    private static void ApplyAuthorizationCriteria(
        ICriteria criteria,
        Junction @where,
        string[] subjectEndpointNames,
        IDictionary<string, object> parameters,
        JoinType joinType)
    {
        throw new NotSupportedException();

        // // Defensive check to ensure required parameter is present
        // if (!parameters.TryGetValue(FilterPropertyName, out var parameterValue))
        // {
        //     throw new Exception(
        //         $"Unable to find parameter '{FilterPropertyName}' for applying namespace-based authorization. Available parameters: '{string.Join("', '", parameters.Keys)}'");
        // }
        //
        // // Ensure the Namespace parameter is represented as an object array
        // var namespacePrefixes = parameterValue as object[] ?? new[] { parameterValue };
        //
        // // Combine the namespace filters using OR (only one must match to grant authorization)
        // var namespacesDisjunction = new Disjunction();
        //
        // foreach (var namespacePrefix in namespacePrefixes)
        // {
        //     namespacesDisjunction.Add(Restrictions.Like(subjectEndpointNames[0], namespacePrefix));
        // }
        //
        // // Add the final namespaces criteria to the supplied WHERE clause (junction)
        // @where.Add(new AndExpression(Restrictions.IsNotNull(subjectEndpointNames[0]), namespacesDisjunction));
    }

    // private static PropertyMapping[] GetContextDataPropertyMappings(string resourceFullName, IEnumerable<string> availablePropertyNames)
    // {
    //     return new PropertyMapping[]
    //     {
    //         new(
    //             NamespaceAuthorizationConvention.GetNamespacePropertyName(resourceFullName, availablePropertyNames),
    //             "Namespace")
    //     };
    // }
    
    private InstanceAuthorizationResult AuthorizeInstance(
        EdFiAuthorizationContext authorizationContext,
        AuthorizationFilterContext authorizationFilterContext,
        string authorizationStrategyName)
    {
        for (int i = 0; i < (authorizationFilterContext.SubjectEndpointValues?.Count ?? 0); i++)
        {
            if (authorizationFilterContext.SubjectEndpointValues[i] == null)
            {
                if (!authorizationFilterContext.SubjectEndpointNames[i].EndsWith("USI"))
                {
                    string existingLiteral = authorizationContext.GetPhaseText("existing ");
                
                    throw new SecurityAuthorizationException(
                        SecurityAuthorizationException.DefaultDetail + $" The {existingLiteral}'{authorizationFilterContext.SubjectEndpointNames[i]}' value is required for authorization purposes.",
                        authorizationContext.GetPhaseText($"The existing resource item is inaccessible to clients using the '{authorizationStrategyName}' authorization strategy."))
                    {
                        InstanceTypeParts = authorizationContext.AuthorizationPhase == AuthorizationPhase.ProposedData
                            // On proposed data
                            ? ["custom-view", "access-denied", "element-required"]
                            // On existing data
                            : ["custom-view", "invalid-data", "element-uninitialized"]
                    };
                }
            }
            // If the subject's endpoint name is an Education Organization Id, we can try to authenticate it here using claim values
            else if (_educationOrganizationIdNamesProvider.IsEducationOrganizationIdName(authorizationFilterContext.SubjectEndpointNames[i]))
            {
                // NOTE: Could consider caching the EdOrgToEdOrgId tuple table.
                // If the EdOrgId values match, then we can report the filter as successfully authorized
                if (_apiClientContextProvider.GetApiClientContext()
                    .EducationOrganizationIds.Contains((long) authorizationFilterContext.SubjectEndpointValues[i]))
                {
                    return InstanceAuthorizationResult.Success();
                }
            }
        }

        return InstanceAuthorizationResult.NotPerformed();
    }

    private void ApplyTrackedChangesAuthorizationCriteria(
        AuthorizationFilterDefinition filterDefinition,
        AuthorizationFilterContext filterContext,
        Resource resource,
        int filterIndex,
        QueryBuilder queryBuilder,
        bool useOuterJoins)
    {
        throw new NotSupportedException();
        
        // if (filterContext.ClaimParameterValues.Length == 1)
        // {
        //     if (filterContext.SubjectEndpointName == "Namespace")
        //     {
        //         queryBuilder.WhereLike($"{_oldNamespaceQueryColumnExpression}", filterContext.ClaimParameterValues.Single());
        //     }
        //     else
        //     {
        //         queryBuilder.WhereLike(
        //             $"{TrackedChangesAlias}.{_databaseNamingConvention.ColumnName($"Old{filterContext.SubjectEndpointName}")}",
        //             filterContext.ClaimParameterValues.Single());
        //     }
        // }
        // else if (filterContext.ClaimParameterValues.Length > 1)
        // {
        //     queryBuilder.Where(
        //         q =>
        //         {
        //             if (filterContext.SubjectEndpointName == "Namespace")
        //             {
        //                 filterContext.ClaimParameterValues.ForEach(ns => q.OrWhereLike(_oldNamespaceQueryColumnExpression, ns));
        //             }
        //             else
        //             {
        //                 filterContext.ClaimParameterValues.ForEach(
        //                     ns => q.OrWhereLike(
        //                         $"{TrackedChangesAlias}.{_databaseNamingConvention.ColumnName($"Old{filterContext.SubjectEndpointName}")}",
        //                         ns));
        //             }
        //
        //             return q;
        //         });
        // }
        // else
        // {
        //     // This should never happen
        //     throw new SecurityAuthorizationException(SecurityAuthorizationException.DefaultTechnicalProblemDetail, "No namespaces found in claims.");
        // }
    }
}
