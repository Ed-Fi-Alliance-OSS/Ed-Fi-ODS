// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

public class RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletesAuthorizationStrategy<TContextData>
    : RelationshipsAuthorizationStrategyBase<TContextData>
    where TContextData : RelationshipsAuthorizationContextData, new()
{
    private readonly IPersonEntitySpecification _personEntitySpecification;

    // NOTE:
    // The authorization path modifier has been shortened here from "ThroughResponsibilityIncludingDeletes" for the sake
    // of Postgres' 63 character limit on identifier names (This is used, by convention, to build the auth view name.)
    //
    // The class name must match the convention for the name of the strategy as it appears in the security metadata,
    // but the path modifier can be different, as was necessary here.
    public const string AuthorizationPathModifier = "ThroughDeletedResponsibility";

    public RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletesAuthorizationStrategy(
        IDomainModelProvider domainModelProvider,
        IPersonEntitySpecification personEntitySpecification)
        : base(domainModelProvider)
    {
        _personEntitySpecification = personEntitySpecification;
    }

    protected override SubjectEndpoint[] GetAuthorizationSubjectEndpoints(
        IEnumerable<(string name, object value)> authorizationContextTuples)
    {
        return authorizationContextTuples
            .Where(nv => _personEntitySpecification.IsPersonIdentifier(nv.name, WellKnownPersonTypes.Student))
            .Select(nv => new SubjectEndpoint(nv, AuthorizationPathModifier))
            .ToArray();
    }
}
