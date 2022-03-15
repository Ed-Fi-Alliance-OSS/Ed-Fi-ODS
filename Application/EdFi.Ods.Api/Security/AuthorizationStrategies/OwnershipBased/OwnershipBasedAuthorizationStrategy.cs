using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.OwnershipBased
{
    public class OwnershipBasedAuthorizationStrategy : IAuthorizationStrategy, IAuthorizationFilterDefinitionsProvider
    {
        private readonly AuthorizationContextDataFactory _authorizationContextDataFactory = new();

        private const string AuthorizationStrategyName = "OwnershipBased";
        private const string FilterPropertyName = "CreatedByOwnershipTokenId";

        /// <summary>
        /// Gets the authorization strategy's NHibernate filter definitions and a functional delegate for determining when to apply them. 
        /// </summary>
        /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and mappings.</returns>
        IReadOnlyList<AuthorizationFilterDefinition> IAuthorizationFilterDefinitionsProvider.GetAuthorizationFilterDefinitions()
        {
            var filters = new AuthorizationFilterDefinition[]
            {
                new AuthorizationFilterDefinition(
                    "CreatedByOwnershipTokenId",
                    @"(CreatedByOwnershipTokenId IS NOT NULL AND CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))",
                    @"({currentAlias}.CreatedByOwnershipTokenId IS NOT NULL AND {currentAlias}.CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))",
                    ApplyAuthorizationCriteria,
                    AuthorizeInstance,
                    (t, p) => !DescriptorEntitySpecification.IsEdFiDescriptorEntity(t) && p.HasPropertyNamed("CreatedByOwnershipTokenId")),
            };

            return filters;
        }

        private static void ApplyAuthorizationCriteria(
            ICriteria criteria,
            Junction @where,
            IDictionary<string, object> parameters,
            JoinType joinType)
        {
            // Defensive check to ensure required parameter is present
            if (!parameters.ContainsKey(FilterPropertyName))
            {
                throw new Exception($"Unable to find parameter '{FilterPropertyName}' for applying ownership-based authorization. Available parameters: '{string.Join("', '", parameters.Keys)}'");
            }

            @where.ApplyPropertyFilters(parameters, FilterPropertyName);
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
                // TODO: GKM - Review all use of the ClaimsPrincipal, and consider eliminating it for CallContext
                var hasOwnershipToken = authorizationContext.Principal.Claims.Any(
                    c => c.Type == EdFiOdsApiClaimTypes.OwnershipTokenId
                        && c.Value == contextData.CreatedByOwnershipTokenId.ToString());

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

        /// <summary>
        /// Get authorization filtering context to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        AuthorizationStrategyFiltering IAuthorizationStrategy.GetAuthorizationStrategyFiltering(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            // TODO: GKM - Review all use of the ClaimsPrincipal, and consider eliminating it for CallContext
            var ownershipTokens = authorizationContext.Principal.Claims
                .Where(c => c.Type == EdFiOdsApiClaimTypes.OwnershipTokenId)
                .Select(x => (object) x.Value)
                .ToArray();

            return new AuthorizationStrategyFiltering()
            {
                AuthorizationStrategyName = AuthorizationStrategyName,
                Filters = new[]
                {
                    new AuthorizationFilterContext
                    {
                        FilterName = "CreatedByOwnershipTokenId",
                        SubjectEndpointName = "CreatedByOwnershipTokenId",
                        ClaimParameterName = "CreatedByOwnershipTokenId",
                        ClaimParameterValues = ownershipTokens
                    }
                },
                Operator = FilterOperator.And
            };
        }
    }
}
