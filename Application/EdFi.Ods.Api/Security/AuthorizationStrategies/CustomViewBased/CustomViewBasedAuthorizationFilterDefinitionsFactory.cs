// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.Extensions;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;

public class CustomViewBasedAuthorizationFilterDefinitionsFactory : IAuthorizationFilterDefinitionsFactory
{
    private readonly IDatabaseNamingConvention _databaseNamingConvention;

    private const string TrackedChangesAlias = "c";

    private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
    private readonly ICustomViewBasisEntityProvider _customViewBasisEntityProvider;
    private readonly ConcurrentDictionary<(Resource resource, string viewName), string> _nonIdentifyingPropertiesTextByResourceAndView = new();

    public CustomViewBasedAuthorizationFilterDefinitionsFactory(
        IDatabaseNamingConvention databaseNamingConvention,
        IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
        ICustomViewBasisEntityProvider customViewBasisEntityProvider)
    {
        _databaseNamingConvention = databaseNamingConvention;
        _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        _customViewBasisEntityProvider = customViewBasisEntityProvider;
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

    private InstanceAuthorizationResult AuthorizeInstance(
        DataManagementRequestContext dataManagementRequestContext,
        AuthorizationFilterContext authorizationFilterContext,
        string authorizationStrategyName)
    {
        for (int i = 0; i < (authorizationFilterContext.SubjectEndpointValues?.Count ?? 0); i++)
        {
            if (authorizationFilterContext.SubjectEndpointValues[i] == null)
            {
                if (!authorizationFilterContext.SubjectEndpointNames[i].EndsWith("USI"))
                {
                    string existingLiteral = dataManagementRequestContext.AuthorizationPhase.GetPhaseText("existing ");

                    string subjectEndpointName = authorizationFilterContext.SubjectEndpointNames[i].ReplaceSuffix("DescriptorId", "Descriptor");

                    throw new SecurityAuthorizationException(
                        SecurityAuthorizationException.DefaultDetail + $" The {existingLiteral}'{subjectEndpointName}' value is required for authorization purposes.",
                        dataManagementRequestContext.AuthorizationPhase.GetPhaseText($"The existing resource item is inaccessible to clients using the '{authorizationStrategyName}' authorization strategy."))
                    {
                        InstanceTypeParts = dataManagementRequestContext.AuthorizationPhase == AuthorizationPhase.ProposedData
                            // On proposed data
                            ? ["custom-view", "access-denied", "element-required"]
                            // On existing data
                            : ["custom-view", "invalid-data", "element-uninitialized"]
                    };
                }
                
                // We will defer to the final authorization check to produce identical messages
                // whether the endpoint values are null or not.
                return InstanceAuthorizationResult.NotPerformed();
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
        if (filterDefinition is not ViewBasedAuthorizationFilterDefinition viewBasedFilterDefinition)
        {
            throw new Exception($"Expected a view-based filter definition of type '{nameof(ViewBasedAuthorizationFilterDefinition)}'.");
        }

        string viewName = viewBasedFilterDefinition.ViewName;

        string[] trackedChangesPropertyNames = resource.Entity.IsDerived 
            ? filterContext.SubjectEndpointNames.Select(GetBasePropertyNameForSubjectEndpointName).ToArray() 
            : filterContext.SubjectEndpointNames;

        if (useOuterJoins)
        {
            throw new InvalidOperationException("Outer joins are not used with custom view-based authorizations.");
        }

        // Verify that all the tracked changes property names are identifying (a requirement for tracked change queries)
        string nonIdentifyPropertyNames = _nonIdentifyingPropertiesTextByResourceAndView.GetOrAdd(
            (resource, viewBasedFilterDefinition.ViewName),
            (x, propertyNames) =>
            {
                return string.Join(
                    "', '",
                    propertyNames.Where(
                        tcpn => !x.resource.Entity.Identifier.Properties.Any(p => p.PropertyName.EqualsIgnoreCase(tcpn))));
            },
            trackedChangesPropertyNames);

        if (nonIdentifyPropertyNames.Length > 0)
        {
            throw new SecurityConfigurationException(
                SecurityConfigurationException.DefaultDetail,
                $"Non-identifying properties ('{nonIdentifyPropertyNames}') were found to be used for the custom view-based authorization strategy, but this is not supported by Change Queries which only tracks deleted/changed values of identifying properties. Should a different authorization strategy be used?");
        }
        
        queryBuilder.Join(
            $"auth.{viewName} AS rba{filterIndex}", 
            j =>
            {
                for (int i = 0; i < trackedChangesPropertyNames.Length; i++)
                {
                    j.On(
                        $"{TrackedChangesAlias}.{_databaseNamingConvention.ColumnName($"Old{trackedChangesPropertyNames[i]}")}",
                        $"rba{filterIndex}.{_databaseNamingConvention.ColumnName(viewBasedFilterDefinition.ViewTargetEndpointNames[i])}");
                }

                return j;
            });

        string GetBasePropertyNameForSubjectEndpointName(string filterContextSubjectEndpointName)
        {
            if (!resource.Entity.PropertyByName.TryGetValue(filterContextSubjectEndpointName, out var entityProperty))
            {
                throw new Exception(
                    $"Unable to find property '{filterContextSubjectEndpointName}' on entity '{resource.Entity.FullName}'.");
            }

            return entityProperty.BaseProperty.PropertyName;
        }
    }
}
