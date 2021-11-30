using System.Collections.Generic;
using EdFi.Security.DataAccess.Models;

namespace EdFi.Security.DataAccess.Caching
{
    public class InstanceSecurityRepositoryCacheObject
    {
        public Application Application { get; }

        public List<Action> Actions { get; }

        public List<ClaimSet> ClaimSets { get; }

        public List<ResourceClaim> ResourceClaims { get; }

        public List<AuthorizationStrategy> AuthorizationStrategies { get; }

        public List<ClaimSetResourceClaimActionAuthorizations> ClaimSetResourceClaims { get; }

        public List<ResourceClaimActionAuthorization> ResourceClaimAuthorizationMetadata { get; }


        public InstanceSecurityRepositoryCacheObject(
            Application application,
            List<Action> actions,
            List<ClaimSet> claimSets,
            List<ResourceClaim> resourceClaims,
            List<AuthorizationStrategy> authorizationStrategies,
            List<ClaimSetResourceClaimActionAuthorizations> claimSetResourceClaims,
            List<ResourceClaimActionAuthorization> resourceClaimAuthorizationMetadata)
        {
            Application = application;
            Actions = actions;
            ClaimSets = claimSets;
            ResourceClaims = resourceClaims;
            AuthorizationStrategies = authorizationStrategies;
            ClaimSetResourceClaims = claimSetResourceClaims;
            ResourceClaimAuthorizationMetadata = resourceClaimAuthorizationMetadata;
        }
    }
}