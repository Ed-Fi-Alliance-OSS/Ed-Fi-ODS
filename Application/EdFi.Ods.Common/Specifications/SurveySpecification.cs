// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;

namespace EdFi.Ods.Common.Specifications
{
    public class SurveySpecification
    {
        public static string[] ValidTypes { get; } =
        {
            "Survey", "SurveyQuestion", "SurveyQuestionResponse", "SurveySection", "SurveySectionResponse", "SurveyResponse"
        };

        public static bool IsSurveyEntity(Type type)
        {
            return IsSurveyEntity(type.Name);
        }

        public static bool IsSurveyEntity(string typeName)
        {
            return ValidTypes.Contains(typeName, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
