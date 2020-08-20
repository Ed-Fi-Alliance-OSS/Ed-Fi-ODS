// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.TestObjects.Builders
{
    public class HashtableBuilder : IValueBuilder
    {
        private int index;
        private readonly Type[] types =
        {
            typeof(int), typeof(int?), typeof(string), typeof(double), typeof(double?), typeof(float), typeof(float?)
        };

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType == typeof(Hashtable))
            {
                var hashtable = new Hashtable();

                for (int i = 0; i < Factory.CollectionCount; i++)
                {
                    var entryKey = GetEntryKey(
                        buildContext.LogicalPropertyPath,
                        typeof(string),
                        buildContext.PropertyValueConstraints,
                        buildContext.ObjectGraphLineage);

                    //var entryKey = Factory.Create(logicalPropertyPath + "+Key", typeof(string));

                    IncrementIndex();

                    var entryValue = Factory.Create(
                        buildContext.LogicalPropertyPath + "+Value",
                        types[index],
                        buildContext.PropertyValueConstraints,
                        buildContext.ObjectGraphLineage);

                    IncrementIndex();

                    hashtable.Add(entryKey, entryValue);
                }

                return ValueBuildResult.WithValue(hashtable, buildContext.LogicalPropertyPath);
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

        private void IncrementIndex()
        {
            index = (index + 1) % types.Length;
        }
    }
}
