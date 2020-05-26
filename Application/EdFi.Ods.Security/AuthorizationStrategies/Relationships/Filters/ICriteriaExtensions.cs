// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

public static class ICriteriaExtensions
{
    /// <summary>
    /// Applies a join-based filter to the criteria for the specified authorization view.
    /// </summary>
    /// <param name="criteria">The criteria to which filters should be applied.</param>
    /// <param name="parameters">The named parameters to be used to satisfy additional filtering requirements.</param>
    /// <param name="viewName">The name of the view to be filtered.</param>
    /// <param name="joinPropertyName">The name of the property to be joined between the entity being queried and the authorization view.</param>
    public static void ApplyJoinFilter(this ICriteria criteria, IDictionary<string, object> parameters, string viewName, string joinPropertyName, string filterPropertyName)
    {
        string authViewAlias = $"authView{viewName}";

        // Apply authorization join using ICriteria
        criteria.CreateEntityAlias(
            authViewAlias,
            Restrictions.EqProperty($"aggregateRoot.{joinPropertyName}", $"{authViewAlias}.{joinPropertyName}"),
            JoinType.InnerJoin,
            $"{viewName.GetAuthorizationViewClassName()}".GetFullNameForView());

        object value;

        // Defensive check to ensure required parameter is present
        if (!parameters.TryGetValue(filterPropertyName, out value))
            throw new Exception($"Unable to find parameter for filtering '{filterPropertyName}' on view '{viewName}'.");

        var arrayOfValues = value as object[];

        if (arrayOfValues != null)
            criteria.Add(Restrictions.In($"{authViewAlias}.{filterPropertyName}", arrayOfValues));
        else
            criteria.Add(Restrictions.Eq($"{authViewAlias}.{filterPropertyName}", value));
    }

    /// <summary>
    /// Applies property-level filter expressions to the criteria as either Equal or In expressions based on the supplied parameters.
    /// </summary>
    /// <param name="criteria">The criteria to which filters should be applied.</param>
    /// <param name="parameters">The named parameters to be processed into the criteria query.</param>
    public static void ApplyPropertyFilters(this ICriteria criteria, IDictionary<string, object> parameters, params string[] properties)
    {
        foreach (var nameAndValue in parameters.Where(x => properties.Contains(x.Key, StringComparer.OrdinalIgnoreCase)))
        {
            var arrayOfValues = nameAndValue.Value as object[];

            if (arrayOfValues != null)
                criteria.Add(Restrictions.In($"{nameAndValue.Key}", arrayOfValues));
            else
                criteria.Add(Restrictions.Eq($"{nameAndValue.Key}", nameAndValue.Value));
        }
    }

    private static string GetFullNameForView(this string viewName)
    {
        return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
    }
}