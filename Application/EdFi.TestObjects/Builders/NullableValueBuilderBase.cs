// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.TestObjects.Builders
{
    public abstract class NullableValueBuilderBase<T> : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType.IsGenericType
                && buildContext.TargetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // Reassign the nullable type to the underlying target type
                buildContext.TargetType = Nullable.GetUnderlyingType(buildContext.TargetType);
            }

            if (buildContext.TargetType == typeof(T))
            {
                var value = GetNextValue();
                return ValueBuildResult.WithValue(value, buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public abstract void Reset();

        public ITestObjectFactory Factory { get; set; }

        protected abstract T GetNextValue();
    }
}
