// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications
{
    // TODO: GKM - This is not an extensible structure.  For extensibility around EdOrg types, we'll eventually want to introduce an interface for this (CoR?), for defining what the valid EdOrgs are, their relationships, and their identifiers.
    public class EducationOrganizationEntitySpecification
    {
        private const string EducationOrganizationBaseTypeName = "EducationOrganization";

        public static string[] ValidEducationOrganizationTypes { get; } =
            {
                "EducationOrganization", // Abstract base type
                "StateEducationAgency",
                "EducationServiceCenter",
                "EducationOrganizationNetwork",
                "LocalEducationAgency",
                "School",
                "CommunityOrganization",
                "CommunityProvider",
                "PostSecondaryInstitution",
                "EducationOrganizationNetworkAssociation",
                // For TPDM Extension Support
                "University",
                "TeacherPreparationProvider"
            };

        public static bool IsEducationOrganizationEntity(Type type) => IsEducationOrganizationEntity(type.Name);

        public static bool IsEducationOrganizationEntity(string typeName)
            => ValidEducationOrganizationTypes.Contains(typeName, StringComparer.InvariantCultureIgnoreCase);

        public static bool IsEducationOrganizationBaseEntity(string typeName) => typeName == EducationOrganizationBaseTypeName;

        public static bool IsEducationOrganizationIdentifier(string propertyName)
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
}
