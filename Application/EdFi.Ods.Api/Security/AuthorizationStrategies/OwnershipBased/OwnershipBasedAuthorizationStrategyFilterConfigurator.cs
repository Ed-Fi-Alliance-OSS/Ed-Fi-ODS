using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Specifications;
using System.Collections.Generic;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.OwnershipBased
{
    public class OwnershipBasedAuthorizationStrategyFilterConfigurator : INHibernateFilterConfigurator
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
                    "CreatedByOwnershipTokenId",
                    @"(CreatedByOwnershipTokenId IS NOT NULL AND CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))",
                    @"({currentAlias}.CreatedByOwnershipTokenId IS NOT NULL AND {currentAlias}.CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))",
                    (c, w, p, jt) =>
                    {
                        w.ApplyPropertyFilters(p,"CreatedByOwnershipTokenId");
                    },
                    (t, p) => !DescriptorEntitySpecification.IsEdFiDescriptorEntity(t) && p.HasPropertyNamed("CreatedByOwnershipTokenId")),
            }.AsReadOnly();

            return filters;
        }
    }
}
