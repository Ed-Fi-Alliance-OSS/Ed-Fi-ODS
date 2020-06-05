// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Common.Infrastructure.Filtering;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships.Filters;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    public class RelationshipsWithStudentsOnlyAuthorizationStrategyFilterConfigurator
    {
        /// <summary>
        /// Gets the NHibernate filter definitions and a functional delegate for determining when to apply them. 
        /// </summary>
        /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and entity mappings.</returns>
        public IReadOnlyList<FilterApplicationDetails> GetFilters()
        {
            var filters = new List<FilterApplicationDetails>
                          {
                              // Local Education Agency/School to Student relationships
                              RelationshipsAuthorizationFilters.LocalEducationAgencyIdToStudentUSI,
                              RelationshipsAuthorizationFilters.SchoolIdToStudentUSI
                          };

            return filters;
        }
    }
}
