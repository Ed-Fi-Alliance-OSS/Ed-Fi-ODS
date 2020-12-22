using EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased.Variations
{
    public class RelationshipsWithEdOrgsAndPeopleFilterHandler : RelationshipBasedAuthorizationFilterHandlerBase
    {
        private const string AuthorizationStrategyName = "RelationshipsWithEdOrgsAndPeople";
        private const string AuthorizationStrategyDescription = "Relationships with Education Organizations and People";

        public RelationshipsWithEdOrgsAndPeopleFilterHandler(
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
    }
}