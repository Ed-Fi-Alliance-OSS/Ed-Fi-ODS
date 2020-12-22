// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased.Variations
{
    public class RelationshipsWithStudentsOnlyThroughEdOrgResponsibilityAssociationFilterHandler
        : RelationshipBasedAuthorizationFilterHandlerBase
    {
        private const string AuthorizationStrategyName = "RelationshipsWithStudentsOnlyThroughEdOrgAssociation";
        private const string AuthorizationStrategyDescription =
            "Relationships with Students only (through StudentEducationOrganizationAssociation)";

        public RelationshipsWithStudentsOnlyThroughEdOrgResponsibilityAssociationFilterHandler(
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
            => authorizationStrategyName == AuthorizationStrategyName
                || authorizationStrategyName == AuthorizationStrategyDescription;

        protected override bool IsRelevantForAuthorization(EntityProperty authorizationContextProperty)
            => authorizationContextProperty.PropertyName == "StudentUSI";

        protected override string GetViewModifier() => "ThroughEdOrgAssociation";
    }
}
