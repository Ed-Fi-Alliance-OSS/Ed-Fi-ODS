// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Security.AuthorizationStrategies.NHibernateConfiguration;
using NHibernate.Criterion;

namespace EdFi.Ods.Security.AuthorizationStrategies.NamespaceBased
{
    public class NamespaceBasedAuthorizationStrategyFilterConfigurator : INHibernateFilterConfigurator
    {
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
                    (c, w, p, jt) =>
                    {
                        // Ensure the Namespace parameter is represented as an object array
                        var namespacePrefixes = p["Namespace"] as object[] ?? new [] { p["Namespace"] };
                        
                        // Combine the namespace filters using OR (only one must match to grant authorization)
                        var namespacesDisjunction = new Disjunction();
                        
                        foreach (var namespacePrefix in namespacePrefixes)
                        {
                            namespacesDisjunction.Add(Restrictions.Like("Namespace", namespacePrefix));
                        }
                        
                        // Add the final namespaces criteria to the supplied WHERE clause (junction)
                        w.Add(
                            new AndExpression(
                                Restrictions.IsNotNull("Namespace"),
                                namespacesDisjunction));
                    },
                    (t, p) => !DescriptorEntitySpecification.IsEdFiDescriptorEntity(t) && p.HasPropertyNamed("Namespace")),
            }.AsReadOnly();

            return filters;
        }
    }
}
