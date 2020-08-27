// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.TestObjects.Builders
{
    public class StringValueBuilder : IValueBuilder
    {
        public static bool GenerateNulls = true;
        public static bool GenerateEmptyStrings = true;

        private int counter;
        private int index;

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType != typeof(string))
            {
                return ValueBuildResult.NotHandled;
            }

            if (index == 1)
            {
                if (!GenerateEmptyStrings)
                {
                    IncrementIndex();
                }
            }

            if (index == 2)
            {
                if (!GenerateNulls)
                {
                    IncrementIndex();
                }
            }

            ValueBuildResult buildResult;

            switch (index)
            {
                case 0:
                    buildResult = ValueBuildResult.WithValue("String" + ++counter, buildContext.LogicalPropertyPath);
                    break;
                case 1:
                    buildResult = ValueBuildResult.WithValue(string.Empty, buildContext.LogicalPropertyPath);
                    break;
                case 2:
                    buildResult = ValueBuildResult.WithValue(null, buildContext.LogicalPropertyPath);
                    break;
                default:
                    throw new Exception(string.Format("Unhandled index: {0}", index));
            }

            IncrementIndex();

            return buildResult;
        }

        public void Reset()
        {
            counter = 0;
            index = 0;
        }

        public ITestObjectFactory Factory { get; set; }

        private void IncrementIndex()
        {
            index = (index + 1) % 3;
        }
    }
}
