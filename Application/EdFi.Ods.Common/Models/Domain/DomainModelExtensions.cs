// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Common.Models.Domain
{
    public static class DomainModelExtensions
    {
        /// <summary>
        /// Gets the <see cref="Entity" /> representing the well-known <i>edfi.EducationOrganization</i> base entity.
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns></returns>
        public static Entity GetEducationOrganizationEntity(this DomainModel domainModel)
        {
            return domainModel.EntityByFullName[new FullName(EdFiConventions.PhysicalSchemaName, "EducationOrganization")];
        }
    }
}
