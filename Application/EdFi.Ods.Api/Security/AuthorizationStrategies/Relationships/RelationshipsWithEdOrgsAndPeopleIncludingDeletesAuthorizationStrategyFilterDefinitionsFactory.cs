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

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

public class RelationshipsWithEdOrgsAndPeopleIncludingDeletesAuthorizationStrategyFilterDefinitionsFactory
    : RelationshipsAuthorizationStrategyFilterDefinitionsFactory
{
    public RelationshipsWithEdOrgsAndPeopleIncludingDeletesAuthorizationStrategyFilterDefinitionsFactory(
        IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider,
        IApiKeyContextProvider apiKeyContextProvider,
        IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport)
        : base(educationOrganizationIdNamesProvider, apiKeyContextProvider, viewBasedSingleItemAuthorizationQuerySupport) { }

    public override IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions()
    {
        return CreateAllEducationOrganizationToPersonFilters(authorizationPathModifier: "IncludingDeletes").ToArray();
    }
}
