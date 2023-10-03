// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Security.Authorization
{
    /// <summary>
    /// Provides methods for obtaining and testing matches with the names of the all types of education organization ids in the current model.
    /// </summary>
    public class EducationOrganizationIdNamesProvider : IEducationOrganizationIdNamesProvider
    {
        private readonly Lazy<string[]> _concreteEducationOrganizationIdNames;
        private readonly Lazy<List<string>> _sortedEducationOrganizationIdNames; 

        public EducationOrganizationIdNamesProvider(IDomainModelProvider domainModelProvider)
        {
            _concreteEducationOrganizationIdNames = new Lazy<string[]>(() =>
            {
                // Get the EducationOrganization base entity
                var edOrgEntity = domainModelProvider.GetDomainModel().EducationOrganizationBaseEntity();
                
                var derivedEntities = edOrgEntity.DerivedEntities;

                return derivedEntities.Select(e => e.Identifier.Properties.Single().PropertyName).ToArray();
            });
            
            _sortedEducationOrganizationIdNames =
                new Lazy<List<string>>(
                    () =>
                    {
                        var sortedEdOrgNames = new List<string>(GetAllNames());
                        sortedEdOrgNames.Sort();

                        return sortedEdOrgNames;
                    });
        }

        /// <inheritdoc cref="IEducationOrganizationIdNamesProvider.GetAllNames" />
        public string[] GetAllNames()
        {
            return new[] { "EducationOrganizationId" }.Concat(_concreteEducationOrganizationIdNames.Value).ToArray();
        }

        /// <inheritdoc cref="IEducationOrganizationIdNamesProvider.GetConcreteNames" />
        public string[] GetConcreteNames()
        {
            return _concreteEducationOrganizationIdNames.Value;
        }

        /// <inheritdoc cref="IEducationOrganizationIdNamesProvider.IsEducationOrganizationIdName" />
        public bool IsEducationOrganizationIdName(string candidateName)
        {
            return _sortedEducationOrganizationIdNames.Value.BinarySearch(candidateName) >= 0;
        }
    }
}
