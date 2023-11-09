// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Specifications
{
    public interface IEducationOrganizationEntitySpecification
    {
        bool IsEducationOrganizationBaseEntity(string typeName);
        bool IsEducationOrganizationEntity(string typeName);
        bool IsEducationOrganizationEntity(Type type);
        bool IsEducationOrganizationIdentifier(string propertyName);
    }
}