using EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased.Variations
{
    public class RelationshipsWithPeopleOnlyFilterHandler : RelationshipBasedAuthorizationFilterHandlerBase
    {
        private const string AuthorizationStrategyName = "RelationshipsWithPeopleOnly";
        private const string AuthorizationStrategyDescription = "Relationships with People only";

        public RelationshipsWithPeopleOnlyFilterHandler(
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
            => authorizationContextProperty.Entity.IsPersonEntity() && authorizationContextProperty.PropertyName.EndsWith("USI");
    }
}