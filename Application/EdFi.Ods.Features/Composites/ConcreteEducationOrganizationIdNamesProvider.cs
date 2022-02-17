// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Features.Composites
{
    public class ConcreteEducationOrganizationIdNamesProvider : IConcreteEducationOrganizationIdNamesProvider
    {
        private readonly Lazy<string[]> _concreteEducationOrganizationIdNames;

        public ConcreteEducationOrganizationIdNamesProvider(IDomainModelProvider domainModelProvider)
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

        /// <inheritdoc cref="IConcreteEducationOrganizationIdNamesProvider.GetNames" />
        public string[] GetNames()
        {
            return _concreteEducationOrganizationIdNames.Value;
        }
    }
}
