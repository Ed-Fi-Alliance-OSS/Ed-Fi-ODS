using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased.Variations
{
    public abstract class RelationshipBasedAuthorizationFilterHandlerBase 
        : IRelationshipBasedAuthorizationFilterHandler
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IEducationOrganizationClaimsProvider _educationOrganizationClaimsProvider;
        private readonly IRelationshipBasedAuthorizationViewJoinApplicator _relationshipBasedAuthorizationViewJoinApplicator;
        private readonly IPhysicalNamesProvider _physicalNamesProvider;

        protected RelationshipBasedAuthorizationFilterHandlerBase(
            IPhysicalNamesProvider physicalNamesProvider,
            IDomainModelProvider domainModelProvider,
            IEducationOrganizationClaimsProvider educationOrganizationClaimsProvider,
            IRelationshipBasedAuthorizationViewJoinApplicator relationshipBasedAuthorizationViewJoinApplicator)
        {
            _physicalNamesProvider = physicalNamesProvider;
            _domainModelProvider = domainModelProvider;
            _educationOrganizationClaimsProvider = educationOrganizationClaimsProvider;
            _relationshipBasedAuthorizationViewJoinApplicator = relationshipBasedAuthorizationViewJoinApplicator;
        }

        public abstract bool CanHandle(string authorizationStrategyName);

        protected virtual bool IsRelevantForAuthorization(EntityProperty authorizationContextProperty)
        {
            return true;
        }

        protected virtual string GetViewModifier()
        {
            return null;
        }

        public void ApplyAuthorizationFilter(SqlBuilder sqlBuilder, Entity entity)
        {
            var educationOrganizationIdsGroupedByFullName =
                _educationOrganizationClaimsProvider.GetEducationOrganizationClaims();

            // TODO: API Simplification - Remove when support for authorizing claims with multiple EdOrg types is implemented
            // ---------------------------------------------------------------------------------------------
            if (educationOrganizationIdsGroupedByFullName.Count() > 1)
            {
                // TODO: API Simplification - Support authorization with API client associated with multiple ed org types.
                throw new NotImplementedException("Support for multiple EdOrg types has not yet been implemented.");
            }
            // ---------------------------------------------------------------------------------------------

            // Relationship-based authorization (rba)
            var authViewAliasGenerator = new AliasGenerator("rba_");

            // Each grouping represent a set of EdOrgIds of a particular type of EdOrg
            foreach (var educationOrganizationClaims in educationOrganizationIdsGroupedByFullName)
            {
                var claimEducationOrganizationEntityFullName = educationOrganizationClaims.EntityFullName;
                var claimEducationOrganizationIds = educationOrganizationClaims.EducationOrganizationIds;

                // Ensure we can find the Entity for the identified concrete EdOrgId in the model
                if (!_domainModelProvider.GetDomainModel()
                    .EntityByFullName.TryGetValue(claimEducationOrganizationEntityFullName, out var claimEducationOrganizationEntity))
                {
                    // This should never happen
                    string educationOrganizationIdsText = string.Join(", ", claimEducationOrganizationIds);

                    throw new Exception(
                        $"Entity for EducationOrganization discriminator value '{claimEducationOrganizationEntityFullName}' derived from API client's assigned education organization Ids [{educationOrganizationIdsText}] could not be found in the model.");
                }

                var claimEducationOrganizationIdProperty = claimEducationOrganizationEntity.Identifier.Properties.Single();

                // Derive the authorization context (needed for relationship-based authorization)
                var authorizationContextProperties = GetAuthorizationContextProperties(entity).Where(IsRelevantForAuthorization);

                // Derive authorization view filtering information
                var authorizationsToPerform = authorizationContextProperties.Select(
                    p =>
                    {
                        string viewBaseName = string.Join(
                            "To",
                            new[]
                            {
                                claimEducationOrganizationIdProperty.PropertyName,
                                p.DefiningProperty.PropertyName
                            }.OrderBy(x => x));

                        string viewModifier = GetViewModifier();
                        
                        return new RelationshipBasedAuthorizationFilterDetails
                        {
                            ClaimEducationOrganizationEntityName = claimEducationOrganizationEntityFullName,
                            ClaimEducationOrganizationIds = claimEducationOrganizationIds,
                            ClaimViewColumnName = _physicalNamesProvider.Column(claimEducationOrganizationIdProperty),
                            TargetEntityColumnName = _physicalNamesProvider.Column(p),
                            TargetViewColumnName = _physicalNamesProvider.Column(p.DefiningProperty),
                            TargetDefiningProperty = p.DefiningProperty,
                            ViewName = $"{viewBaseName}{viewModifier}",
                        };
                    });

                IList<EntityProperty> GetAuthorizationContextProperties(Entity targetEntity)
                {
                    if (targetEntity.IsPersonEntity() || targetEntity.IsEducationOrganizationDerivedEntity())
                    {
                        // Authorization context for EdOrgs and People entities is just the PK property
                        return new[] {targetEntity.Identifier.Properties.Single()};
                    }

                    return targetEntity.Properties.Where(p => p.IsIdentifying && !p.IsLocallyDefined)
                        .Where(
                            p => p.DefiningProperty.Entity.IsPersonEntity()
                                || p.DefiningProperty.Entity.IsEducationOrganizationDerivedEntity()
                                || p.DefiningProperty.Entity.IsEducationOrganizationBaseEntity())
                        .ToList();
                }

                foreach (var authorization in authorizationsToPerform)
                {
                    _relationshipBasedAuthorizationViewJoinApplicator.ApplyAuthorizationViewJoin(
                        sqlBuilder,
                        authViewAliasGenerator,
                        authorization);
                }
            }
        }
    }
}