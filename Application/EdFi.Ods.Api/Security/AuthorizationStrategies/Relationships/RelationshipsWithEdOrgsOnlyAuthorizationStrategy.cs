// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public class RelationshipsWithEdOrgsOnlyAuthorizationStrategy<TContextData>
        : RelationshipsAuthorizationStrategyBase<TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        private readonly IEducationOrganizationIdNamesProvider _educationOrganizationIdNamesProvider;

        public RelationshipsWithEdOrgsOnlyAuthorizationStrategy(
            IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider,
            IDomainModelProvider domainModelProvider)
            : base(domainModelProvider)
        {
            _educationOrganizationIdNamesProvider = educationOrganizationIdNamesProvider;
        }

        protected override SubjectEndpoint[] GetAuthorizationSubjectEndpoints(
            IEnumerable<(string name, object value)> authorizationContextTuples)
        {
            return authorizationContextTuples
                .Where(nv => _educationOrganizationIdNamesProvider.IsEducationOrganizationIdName(nv.name))
                .Select(nv => new SubjectEndpoint(nv))
                .ToArray();
        }
    }
}
