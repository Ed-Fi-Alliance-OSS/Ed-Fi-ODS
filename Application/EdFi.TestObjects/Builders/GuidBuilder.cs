// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;

namespace EdFi.TestObjects.Builders
{
    public class GuidBuilder : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType.IsGenericType
                && buildContext.TargetType.GetGenericTypeDefinition() == typeof(Nullable<>)
                && Nullable.GetUnderlyingType(buildContext.TargetType) == typeof(Guid))
            {
                // TODO: For REST API usage, we don't want any nullable Guids to have values, but this is not desired generic behavior.
                return ValueBuildResult.Skip(buildContext.LogicalPropertyPath);
            }

            if (buildContext.TargetType == typeof(Guid))
            {
                return ValueBuildResult.WithValue(Guid.NewGuid(), buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }
    }
}
