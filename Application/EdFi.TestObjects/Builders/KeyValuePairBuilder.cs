// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.TestObjects.Builders
{
    public class KeyValuePairBuilder : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType.IsGenericType && buildContext.TargetType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                var typeArgs = buildContext.TargetType.GetGenericArguments();
                var kvpType = typeof(KeyValuePair<,>).MakeGenericType(typeArgs);

                var constructor = kvpType.GetConstructor(typeArgs);

                var entryKey = Factory.Create("xyz", typeArgs[0], buildContext.PropertyValueConstraints, buildContext.ObjectGraphLineage);
                var entryValue = Factory.Create("xyz", typeArgs[1], buildContext.PropertyValueConstraints, buildContext.ObjectGraphLineage);

                var kvp = constructor.Invoke(
                    new[]
                    {
                        entryKey, entryValue
                    });

                return ValueBuildResult.WithValue(kvp, buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }
    }
}
