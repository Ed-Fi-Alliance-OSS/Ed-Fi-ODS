// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Generator.Database.NamingConventions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using SqlKata;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased
{
    public class NamespaceBasedAuthorizationStrategyFilterConfigurator : INHibernateFilterConfigurator
    {
        private const string FilterPropertyName = "Namespace";

        private readonly string _oldNamespaceColumnName;

        public NamespaceBasedAuthorizationStrategyFilterConfigurator(IDatabaseNamingConvention databaseNamingConvention)
        {
            _oldNamespaceColumnName = databaseNamingConvention.ColumnName($"OldNamespace");
        }
        
        /// <summary>
        /// Gets the authorization strategy's NHibernate filter definitions and a functional delegate for determining when to apply them.
        /// </summary>
        /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and mappings.</returns>
        public IReadOnlyList<FilterApplicationDetails> GetFilters()
        {
            var filters = new List<FilterApplicationDetails>
            {
                new FilterApplicationDetails(
                    "Namespace",
                    @"(Namespace IS NOT NULL AND Namespace LIKE :Namespace)",
                    @"({currentAlias}.Namespace IS NOT NULL AND {currentAlias}.Namespace LIKE :Namespace)",
                    ApplyAuthorizationCriteria,
                    ApplyTrackedChangesAuthorizationCriteria,
                    (t, p) => !DescriptorEntitySpecification.IsEdFiDescriptorEntity(t) && p.HasPropertyNamed("Namespace")),
            }.AsReadOnly();

            return filters;
        }
        
        private static void ApplyAuthorizationCriteria(
            ICriteria criteria,
            Junction @where,
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
                namespacesDisjunction.Add(Restrictions.Like("Namespace", namespacePrefix));
            }

            // Add the final namespaces criteria to the supplied WHERE clause (junction)
            @where.Add(new AndExpression(Restrictions.IsNotNull("Namespace"), namespacesDisjunction));
        }

        private void ApplyTrackedChangesAuthorizationCriteria(
            FilterApplicationDetails filterDefinition,
            AuthorizationFilterDetails filterContext,
            Resource resource,
            int filterIndex,
            Query query)
        {
            if (filterContext.ClaimValues.Length == 1)
            {
                query.WhereLike(_oldNamespaceColumnName, filterContext.ClaimValues.Single());
            }
            else if (filterContext.ClaimValues.Length > 1)
            {
                query.Where(
                    q => q.Where(
                        q2 =>
                        {
                            filterContext.ClaimValues.ForEach(ns => q2.OrWhereLike(_oldNamespaceColumnName, ns));

                            return q2;
                        }));
            }
            else
            {
                // This should never happen
                throw new ApiSecurityConfigurationException("No namespaces found in claims.");
            }
        }
    }
}
