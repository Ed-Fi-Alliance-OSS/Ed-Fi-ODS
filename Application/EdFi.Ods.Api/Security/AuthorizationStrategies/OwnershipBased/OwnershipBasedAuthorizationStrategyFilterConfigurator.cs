using System;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Specifications;
using System.Collections.Generic;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.OwnershipBased
{
    public class OwnershipBasedAuthorizationStrategyFilterConfigurator : INHibernateFilterConfigurator
    {
        private const string FilterPropertyName = "CreatedByOwnershipTokenId";
        
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
                        // Defensive check to ensure required parameter is present
                        if (!p.ContainsKey(FilterPropertyName))
                        {
                            throw new Exception($"Unable to find parameter '{FilterPropertyName}' for applying ownership-based authorization. Available parameters: '{string.Join("', '", p.Keys)}'");
                        }

                        w.ApplyPropertyFilters(p, FilterPropertyName);
                    },
                    (t, p) => !DescriptorEntitySpecification.IsEdFiDescriptorEntity(t) && p.HasPropertyNamed("CreatedByOwnershipTokenId")),
            }.AsReadOnly();

            return filters;
        }
    }
}
