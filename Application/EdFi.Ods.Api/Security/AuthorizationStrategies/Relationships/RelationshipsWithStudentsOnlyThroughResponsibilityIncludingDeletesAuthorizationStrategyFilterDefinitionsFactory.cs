// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

public class RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletesAuthorizationStrategyFilterDefinitionsFactory
    : RelationshipsAuthorizationStrategyFilterDefinitionsFactory
{
    public RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletesAuthorizationStrategyFilterDefinitionsFactory(
        IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider,
        IApiClientContextProvider apiClientContextProvider,
        IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
        IPersonTypesProvider personTypesProvider)
        : base(
            educationOrganizationIdNamesProvider,
            apiClientContextProvider,
            viewBasedSingleItemAuthorizationQuerySupport,
            personTypesProvider) { }

    public override IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions()
    {
        string authorizationPathModifier = RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletesAuthorizationStrategy<RelationshipsAuthorizationContextData>.AuthorizationPathModifier;

        return CreateAllEducationOrganizationToPersonFilters(
                shouldIncludePersonType: pt => pt == WellKnownPersonTypes.Student,
                authorizationPathModifier: authorizationPathModifier)
            .ToArray();
    }
}
