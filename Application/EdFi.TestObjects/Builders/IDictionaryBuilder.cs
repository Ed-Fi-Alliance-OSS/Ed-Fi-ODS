// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;

namespace EdFi.TestObjects.Builders
{
    public class IDictionaryBuilder : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType.IsGenericType && buildContext.TargetType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                var typeArgs = buildContext.TargetType.GetGenericArguments();
                Type dictionaryType = typeof(Dictionary<,>).MakeGenericType(typeArgs);
                var dictionary = Activator.CreateInstance(dictionaryType);
                var addMethod = dictionaryType.GetMethod("Add", typeArgs);

                for (int i = 0; i < Factory.CollectionCount; i++)
                {
                    var entryKey = GetEntryKey(
                        buildContext.LogicalPropertyPath,
                        typeArgs[0],
                        buildContext.PropertyValueConstraints,
                        buildContext.ObjectGraphLineage);

                    var entryValue = Factory.Create(
                        buildContext.LogicalPropertyPath + "+Value",
                        typeArgs[1],
                        buildContext.PropertyValueConstraints,
                        buildContext.ObjectGraphLineage);

                    addMethod.Invoke(
                        dictionary,
                        new[]
                        {
                            entryKey, entryValue
                        });
                }

                return ValueBuildResult.WithValue(dictionary, buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }

        private object GetEntryKey(
            string logicalPropertyPath,
            Type keyType,
            IDictionary<string, object> propertyValueConstraints,
            LinkedList<object> objectGraphLineage)
        {
            object entryKey = null;
            int attempts = 0;

            // Make sure we get an actual key value (can't use null)
            while (entryKey == null
                   || keyType == typeof(string) && string.IsNullOrEmpty((string) entryKey)
                                                && attempts < 3)
            {
                entryKey = Factory.Create(logicalPropertyPath + "+Key", keyType, propertyValueConstraints, objectGraphLineage);
                attempts++;
            }

            return entryKey;
        }
    }
}
