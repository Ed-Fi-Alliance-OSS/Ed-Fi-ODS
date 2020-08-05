// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;

namespace EdFi.Ods.Common.Specifications
{
    public class EducationStandardSpecification
    {
        public static string[] ValidTypes { get; } =
            {
                "LearningStandard", "LearningObjective", "Credential", "LearningStandardEquivalenceAssociation"
            };

        public static bool IsEducationStandardEntity(Type type)
        {
            return IsEducationStandardEntity(type.Name);
        }

        public static bool IsEducationStandardEntity(string typeName)
        {
            return ValidTypes.Contains(typeName, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
