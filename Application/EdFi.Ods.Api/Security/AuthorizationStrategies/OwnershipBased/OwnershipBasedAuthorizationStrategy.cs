using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.OwnershipBased
{
    public class OwnershipBasedAuthorizationStrategy : IEdFiAuthorizationStrategy
    {
        private readonly AuthorizationContextDataFactory _authorizationContextDataFactory
            = new AuthorizationContextDataFactory();

        public Task AuthorizeSingleItemAsync(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext,
            CancellationToken cancellationToken)
        {
            
            var contextData = _authorizationContextDataFactory
               .CreateContextData<OwnershipBasedAuthorizationContextData>(
                    authorizationContext.Data);

            if (contextData == null)
            {               
                throw new NotSupportedException(
                    "No 'OwnershipTokenId' property could be found on the resource's underlying entity in order to perform authorization. Should a different authorization strategy be used?");
            }

            if (contextData.CreatedByOwnershipTokenId != null)
            {
                var hasOwnershipToken = authorizationContext.Principal.Claims
                    .Any(c => 
                        c.Type == EdFiOdsApiClaimTypes.OwnershipTokenId 
                        && c.Value == contextData.CreatedByOwnershipTokenId.ToString());

                if (!hasOwnershipToken)
                {
                    throw new EdFiSecurityException(
                        "Access to the resource item could not be authorized using any of the caller's ownership tokens.");
                }
            }
            else
            {
                throw new EdFiSecurityException(
                    "Access to the resource item could not be authorized based on the caller's ownership token because the resource item has no owner.");
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            var tokens = authorizationContext.Principal.Claims
                .Where(c => c.Type == EdFiOdsApiClaimTypes.OwnershipTokenId)
                .Select(x => (object) x.Value)
                .ToArray();

            return new[]
            {
                new AuthorizationFilterDetails
                {
                   FilterName ="CreatedByOwnershipTokenId",
                   SubjectEndpointName ="CreatedByOwnershipTokenId",
                   ClaimEndpointName ="CreatedByOwnershipTokenId",
                   ClaimValues = tokens
                }
            };
        }        
    }
}
