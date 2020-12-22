using EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased.Variations
{
    public class RelationshipsWithEdOrgsOnlyFilterHandler : RelationshipBasedAuthorizationFilterHandlerBase
    {
        private const string AuthorizationStrategyName = "RelationshipsWithEdOrgsOnly";
        private const string AuthorizationStrategyDescription = "Relationships with Education Organizations only";

        public RelationshipsWithEdOrgsOnlyFilterHandler(
            IPhysicalNamesProvider physicalNamesProvider,
            IDomainModelProvider domainModelProvider,
            IEducationOrganizationClaimsProvider educationOrganizationClaimsProvider,
            IRelationshipBasedAuthorizationViewJoinApplicator relationshipBasedAuthorizationViewJoinApplicator)
            : base(
                physicalNamesProvider,
                domainModelProvider,
                educationOrganizationClaimsProvider,
                relationshipBasedAuthorizationViewJoinApplicator) { }

        public override bool CanHandle(string authorizationStrategyName) 
            => authorizationStrategyName == AuthorizationStrategyName || authorizationStrategyName == AuthorizationStrategyDescription;

        protected override bool IsRelevantForAuthorization(EntityProperty authorizationContextProperty)
            => authorizationContextProperty.IsIdentifying
                && (authorizationContextProperty.Entity.IsEducationOrganizationBaseEntity()
                    || authorizationContextProperty.Entity.IsEducationOrganizationDerivedEntity());
    }
}