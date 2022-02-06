// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public class RelationshipsWithEdOrgsAndPeopleIncludingDeletesAuthorizationStrategy<TContextData>
        : RelationshipsAuthorizationStrategyBase<TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        public RelationshipsWithEdOrgsAndPeopleIncludingDeletesAuthorizationStrategy(IConcreteEducationOrganizationIdAuthorizationContextDataTransformer<TContextData> concreteEducationOrganizationIdAuthorizationContextDataTransformer)
            : base(concreteEducationOrganizationIdAuthorizationContextDataTransformer) { }

        protected override void BuildAuthorizationSegments(
            AuthorizationBuilder<TContextData> authorizationBuilder,
            string[] authorizationContextPropertyNames)
        {
            // For person USIs, use the view that incorporates the deleted associations
            authorizationContextPropertyNames
                .Where(PersonEntitySpecification.IsPersonIdentifier)
                .ForEach(pn => authorizationBuilder.ClaimsMustBeAssociatedWith(pn, "IncludingDeletes"));
            
            // For EdOrgs, use the standard views
            authorizationContextPropertyNames
                .Where(pn => !PersonEntitySpecification.IsPersonIdentifier(pn))
                .ForEach(pn => authorizationBuilder.ClaimsMustBeAssociatedWith(pn));
        }
    }
}
