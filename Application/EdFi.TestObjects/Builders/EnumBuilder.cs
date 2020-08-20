// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.TestObjects.Builders
{
    public class EnumBuilder : IValueBuilder
    {
        private Dictionary<Type, int> valueIndicesByEnumType = new Dictionary<Type, int>();
        private Dictionary<Type, List<int>> valuesByEnumType = new Dictionary<Type, List<int>>();

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType.IsEnum)
            {
                // Initialize enum values
                if (!valuesByEnumType.ContainsKey(buildContext.TargetType))
                {
                    valuesByEnumType[buildContext.TargetType] = Enum.GetValues(buildContext.TargetType)
                                                                    .Cast<int>()
                                                                    .ToList();

                    valueIndicesByEnumType[buildContext.TargetType] = 0;
                }

                // Get the current index and list of enum values
                int index = valueIndicesByEnumType[buildContext.TargetType];
                var enumValues = valuesByEnumType[buildContext.TargetType];

                // Get the next enum value
                var value = enumValues[index];

                // Increment/cycle the index for this enum type
                valueIndicesByEnumType[buildContext.TargetType] = (index + 1) % enumValues.Count;

                return ValueBuildResult.WithValue(value, buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset()
        {
            valueIndicesByEnumType = new Dictionary<Type, int>();
            valuesByEnumType = new Dictionary<Type, List<int>>();
        }

        public ITestObjectFactory Factory { get; set; }
    }
}
