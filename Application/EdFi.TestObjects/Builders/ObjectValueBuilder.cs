// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.TestObjects.Builders
{
    public class ObjectValueBuilder : IValueBuilder
    {
        private int nextValue = 1;

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType == typeof(object))
            {
                var value = "Object" + nextValue++;
                return ValueBuildResult.WithValue(value, buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset()
        {
            nextValue = 1;
        }

        public ITestObjectFactory Factory { get; set; }
    }
}
