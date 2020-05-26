// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;

namespace EdFi.TestObjects.Builders
{
    public class IncrementingNumericValueBuilder : IValueBuilder
    {
        public static double Precision = .001;

        private readonly Dictionary<Type, dynamic> nextValueByType = new Dictionary<Type, dynamic>();
        private readonly Dictionary<Type, bool> nextNullableResultByType = new Dictionary<Type, bool>();

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (!buildContext.TargetType.IsValueType)
            {
                return ValueBuildResult.NotHandled;
            }

            if (buildContext.TargetType.IsGenericType
                && buildContext.TargetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                bool nextResultIsNull;

                // Get or initialize the flag for this nullable type
                if (!nextNullableResultByType.TryGetValue(buildContext.TargetType, out nextResultIsNull))
                {
                    nextNullableResultByType[buildContext.TargetType] = false;
                }

                // Flip the result for the next time we request an instance of this nullable type
                nextNullableResultByType[buildContext.TargetType] = !nextResultIsNull;

                // If this result should be null, do so now
                if (nextResultIsNull)
                {
                    return ValueBuildResult.WithValue(null, buildContext.LogicalPropertyPath);
                }

                // Reassign the nullable type to the underlying target type
                buildContext.TargetType = Nullable.GetUnderlyingType(buildContext.TargetType);
            }

            if (buildContext.TargetType == typeof(ushort)
                || buildContext.TargetType == typeof(uint)
                || buildContext.TargetType == typeof(ulong)
                || buildContext.TargetType == typeof(byte)
                || buildContext.TargetType == typeof(sbyte)
                || buildContext.TargetType == typeof(short)
                || buildContext.TargetType == typeof(int)
                || buildContext.TargetType == typeof(long)
                || buildContext.TargetType == typeof(decimal)
                || buildContext.TargetType == typeof(double)
                || buildContext.TargetType == typeof(float)
            )
            {
                var value = GetNextValue(buildContext.TargetType);
                return ValueBuildResult.WithValue(value, buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset()
        {
            nextValueByType.Clear();
        }

        public ITestObjectFactory Factory { get; set; }

        private dynamic GetNextValue(Type type)
        {
            if (!nextValueByType.ContainsKey(type))
            {
                nextValueByType[type] = (dynamic) type.GetDefault() + (dynamic) Convert.ChangeType(Precision, type);
            }

            dynamic nextValue = Convert.ChangeType(nextValueByType[type] + 1, type);
            nextValueByType[type] = nextValue;
            return nextValue;
        }
    }

    public static class ReflectionUtility
    {
        public static object GetDefault(this Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}
