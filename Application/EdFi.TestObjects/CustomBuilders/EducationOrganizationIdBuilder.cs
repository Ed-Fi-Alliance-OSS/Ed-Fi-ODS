// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;

namespace EdFi.TestObjects.CustomBuilders
{
    public class EducationOrganizationIdBuilder : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            Type targetType = buildContext.TargetType;
            string logicalPropertyPath = buildContext.LogicalPropertyPath;

            if (targetType == typeof(int) && logicalPropertyPath.EndsWith("EducationOrganizationId"))
            {
                var value = Ids.HighSchool;
                return ValueBuildResult.WithValue(value, logicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset()
        {
            // Nothing to do
        }

        public ITestObjectFactory Factory { get; set; }
    }
}
