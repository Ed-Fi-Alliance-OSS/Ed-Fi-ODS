// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased
{
    public class NamespaceBasedAuthorizationStrategy : IAuthorizationStrategy, IAuthorizationFilterDefinitionsFactory
    {
        private readonly AuthorizationContextDataFactory _authorizationContextDataFactory = new();

        private const string AuthorizationStrategyName = "NamespaceBased";
        private const string FilterPropertyName = "Namespace";
        
        /// <summary>
        /// Gets the authorization strategy's NHibernate filter definitions and a functional delegate for determining when to apply them.
        /// </summary>
        /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and mappings.</returns>
        public IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions()
        {
            var filters = new List<AuthorizationFilterDefinition>
            {
                new (
                    "Namespace",
                    @"(Namespace IS NOT NULL AND Namespace LIKE :Namespace)",
                    @"({currentAlias}.Namespace IS NOT NULL AND {currentAlias}.Namespace LIKE :Namespace)",
                    ApplyAuthorizationCriteria,
                    AuthorizeInstance, 
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
        
        private InstanceAuthorizationResult AuthorizeInstance(
            EdFiAuthorizationContext authorizationContext,
            AuthorizationFilterContext authorizationFilterContext)
        {
            var contextData =
                _authorizationContextDataFactory.CreateContextData<NamespaceBasedAuthorizationContextData>(
                    authorizationContext.Data);

            if (contextData == null)
            {
                return InstanceAuthorizationResult.Failed(
                    new NotSupportedException(
                        "No 'Namespace' property could be found on the resource in order to perform authorization. Should a different authorization strategy be used?"));
            }

            if (string.IsNullOrWhiteSpace(contextData.Namespace))
            {
                return InstanceAuthorizationResult.Failed(
                    new EdFiSecurityException(
                    "Access to the resource item could not be authorized because the Namespace of the resource is empty."));
            }

            var claimNamespacePrefixes = GetClaimNamespacePrefixes(authorizationContext);

            if (!claimNamespacePrefixes.Any(ns => contextData.Namespace.StartsWithIgnoreCase(ns)))
            {
                string claimNamespacePrefixesText = string.Join("', '", claimNamespacePrefixes);

                return InstanceAuthorizationResult.Failed(
                    new EdFiSecurityException(
                    $"Access to the resource item with namespace '{contextData.Namespace}' could not be authorized based on the caller's NamespacePrefix claims: '{claimNamespacePrefixesText}'."));
            }

            return InstanceAuthorizationResult.Success();
        }

        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            var claimNamespacePrefixes = GetClaimNamespacePrefixes(authorizationContext);

            return new AuthorizationStrategyFiltering
            {
                AuthorizationStrategyName = AuthorizationStrategyName,
                Filters = new []
                {
                    new AuthorizationFilterContext
                    {
                        FilterName = "Namespace",
                        SubjectEndpointName = "Namespace",
                        ClaimEndpointValues = claimNamespacePrefixes.Cast<object>().ToArray(),
                        ClaimParameterName = "Namespace",
                        ClaimParameterValueMap =  prefix => $"{prefix}%"
                        // TODO: GKM - consider renaming to ClaimParameterRawValues and providing an optional ClaimParameterValuesMapper (a function that projects the raw values, according to the SQL parameter value requirements). Only makes sense if the values can also be used for instance-based authorization, which may not make sense.
                        // SubjectEndpointValue = authorizationContext.Data
                    }
                },
                Operator = FilterOperator.And
            };
        }

        private static IReadOnlyList<string> GetClaimNamespacePrefixes(EdFiAuthorizationContext authorizationContext)
        {
            // TODO: GKM - Review all use of the ClaimsPrincipal, and consider eliminating it for CallContext
            var namespacePrefixes = authorizationContext.Principal.Claims
                .Where(c => c.Type == EdFiOdsApiClaimTypes.NamespacePrefix)
                .Select(c => c.Value)
                .ToList();

            if (!namespacePrefixes.Any() || namespacePrefixes.All(string.IsNullOrEmpty))
            {
                throw new EdFiSecurityException($"Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('{EdFiOdsApiClaimTypes.NamespacePrefix}') or the claim values were all empty.");
            }

            return namespacePrefixes;
        }
    }
}
