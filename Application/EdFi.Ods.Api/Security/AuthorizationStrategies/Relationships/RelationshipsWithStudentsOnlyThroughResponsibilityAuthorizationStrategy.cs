// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public class RelationshipsWithStudentsOnlyThroughResponsibilityAuthorizationStrategy<TContextData>
        : RelationshipsAuthorizationStrategyBase<TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        public RelationshipsWithStudentsOnlyThroughResponsibilityAuthorizationStrategy(IDomainModelProvider domainModelProvider)
            : base(domainModelProvider) { }

        protected override SubjectEndpoint[] GetAuthorizationSubjectEndpoints(
            IEnumerable<(string name, object value)> authorizationContextTuples)
        {
            return authorizationContextTuples
                .Where(nv => PersonEntitySpecification.IsPersonIdentifier(nv.name, PersonEntitySpecification.Student))
                .Select(nv => new SubjectEndpoint(nv, "ThroughResponsibility"))
                .ToArray();
        }
    }
}
