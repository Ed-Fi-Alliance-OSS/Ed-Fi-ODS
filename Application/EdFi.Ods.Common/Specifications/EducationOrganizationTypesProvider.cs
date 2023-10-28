// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Specifications;

public class EducationOrganizationTypesProvider : IEducationOrganizationTypesProvider
{
    private readonly Lazy<Entity> _educationOrganizationEntity;
    private readonly Lazy<string[]> _validEducationOrganizationTypes;

    public EducationOrganizationTypesProvider(IDomainModelProvider domainModelProvider)
    {
        _educationOrganizationEntity = new(() => domainModelProvider.GetDomainModel()
                .EntityByFullName[EdFiConventions.EducationOrganizationFullName]);

        _validEducationOrganizationTypes = new(() => domainModelProvider.GetDomainModel()
            .Entities.Where(e => e.BaseEntity == _educationOrganizationEntity.Value)
            .Select(e => e.Name)
            .InsertAtHead(_educationOrganizationEntity.Value.Name)
            .ToArray()
        );
    }

    /// <inheritdoc cref="IEducationOrganizationTypesProvider.EducationOrganizationTypes" />
    public string[] EducationOrganizationTypes
    {
        get => _validEducationOrganizationTypes.Value;
    }
}
