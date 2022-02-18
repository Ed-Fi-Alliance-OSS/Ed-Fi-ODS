// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Security.Authorization
{
    public class EducationOrganizationIdNamesProvider : IEducationOrganizationIdNamesProvider
    {
        private readonly Lazy<string[]> _concreteEducationOrganizationIdNames;

        public EducationOrganizationIdNamesProvider(IDomainModelProvider domainModelProvider)
        {
            _concreteEducationOrganizationIdNames = new Lazy<string[]>(
                () =>
                {
                    // Get the EducationOrganization base entity
                    var edOrgEntity = domainModelProvider.GetDomainModel()
                        .EntityByFullName[new FullName(EdFiConventions.PhysicalSchemaName, "EducationOrganization")];

                    // Process all derived entities for their concrete primary key names
                    return edOrgEntity.DerivedEntities.Select(e => e.Identifier.Properties.Single().PropertyName).ToArray();
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
    }
}
