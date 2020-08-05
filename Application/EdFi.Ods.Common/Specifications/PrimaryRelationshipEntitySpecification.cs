// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;

namespace EdFi.Ods.Common.Specifications
{
    public class PrimaryRelationshipEntitySpecification
    {
        public static string[] ValidTypes { get; } =
            {
                "StaffEducationOrganizationAssignmentAssociation",
                "StaffEducationOrganizationEmploymentAssociation",
                "StudentSchoolAssociation"
            };

        public static bool IsPrimaryRelationshipEntity(Type type)
        {
            return IsPrimaryRelationshipEntity(type.Name);
        }

        public static bool IsPrimaryRelationshipEntity(string typeName)
        {
            return ValidTypes.Contains(typeName, StringComparer.CurrentCultureIgnoreCase);
        }
    }
}
