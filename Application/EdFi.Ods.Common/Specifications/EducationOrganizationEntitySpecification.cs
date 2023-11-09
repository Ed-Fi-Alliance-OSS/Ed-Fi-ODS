// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications;

public class EducationOrganizationEntitySpecification : IEducationOrganizationEntitySpecification
{
    private readonly IEducationOrganizationTypesProvider _educationOrganizationTypesProvider;

    public EducationOrganizationEntitySpecification(IEducationOrganizationTypesProvider educationOrganizationTypesProvider)
    {
        _educationOrganizationTypesProvider = educationOrganizationTypesProvider;
    }

    public bool IsEducationOrganizationEntity(Type type) => IsEducationOrganizationEntity(type.Name);

    public bool IsEducationOrganizationEntity(string typeName)
        => _educationOrganizationTypesProvider.EducationOrganizationTypes.Contains(typeName, StringComparer.InvariantCultureIgnoreCase);

    public bool IsEducationOrganizationBaseEntity(string typeName)
        => typeName == EdFiConventions.EducationOrganizationFullName.Name;

    public bool IsEducationOrganizationIdentifier(string propertyName)
    {
        string entityName;

        // TODO: Embedded convention (EdOrg identifiers ends with "Id")
        if (propertyName.TryTrimSuffix("Id", out entityName))
        {
            return IsEducationOrganizationEntity(entityName);
        }

        return false;
    }
}
