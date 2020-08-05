// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;

namespace EdFi.TestObjects.Builders
{
    public class IEnumerableBuilder : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType.IsArray
                ||
                buildContext.TargetType.IsGenericType
                && (buildContext.TargetType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                    || buildContext.TargetType.GetGenericTypeDefinition() == typeof(IList<>)
                    || buildContext.TargetType.GetGenericTypeDefinition() == typeof(List<>)
                    || buildContext.TargetType.GetGenericTypeDefinition() == typeof(ICollection<>)
                ))
            {
                var itemType = buildContext.TargetType.IsArray
                    ? buildContext.TargetType.GetElementType()
                    : buildContext.TargetType.GetGenericArguments()[0];

                var listType = typeof(List<>).MakeGenericType(itemType);
                var list = Activator.CreateInstance(listType);

                var addMethod = listType.GetMethod(
                    "Add",
                    new[]
                    {
                        itemType
                    });

                var distinctValues = new HashSet<object>();

                for (int i = 0; i < Factory.CollectionCount; i++)
                {
                    var newItem = Factory.Create(
                        buildContext.LogicalPropertyPath + "[" + i + "]",
                        itemType,
                        buildContext.PropertyValueConstraints,
                        buildContext.ObjectGraphLineage);

                    // Set the parent references on all API entities to avoid the GetHashCode calls
                    // made by .NET when adding them to HashSets from causing null references exceptions.
                    // Entities use their primary key values and their parent's primary key values
                    // in the GetHashCode calculation.
                    SetEntityParentBackReferencesUpTheEntireLineage(buildContext, newItem);

                    if (newItem != null)
                    {
                        distinctValues.Add(newItem);
                    }
                }

                // Enforce distinctness in values added to the lists
                // TODO: Need unit tests for enforcing distinctness
                foreach (var item in distinctValues)
                {
                    addMethod.Invoke(
                        list,
                        new[]
                        {
                            item
                        });
                }

                if (buildContext.TargetType.IsArray)
                {
                    // Convert list to an array
                    var toArrayMethod = listType.GetMethod("ToArray");
                    return ValueBuildResult.WithValue(toArrayMethod.Invoke(list, null), buildContext.LogicalPropertyPath);
                }

                if (buildContext.TargetType.IsGenericType && buildContext.TargetType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    // Entity child collection concrete implementation is HashSet<>.
                    // Convert list created above to a HashSet<T> using same generic Type as list.
                    var concreteType = typeof(HashSet<>);
                    var genericType = concreteType.MakeGenericType(itemType);
                    var instance = Activator.CreateInstance(genericType, list);
                    return ValueBuildResult.WithValue(instance, buildContext.LogicalPropertyPath);
                }

                return ValueBuildResult.WithValue(list, buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        private static void SetEntityParentBackReferencesUpTheEntireLineage(BuildContext buildContext, object newItem)
        {
            // Set the parent references up the lineage, if possible.
            var newChildEntity = (newItem as IChildEntity);

            foreach (object o in buildContext.ObjectGraphLineage)
            {
                newChildEntity?.SetParent(o);
                newChildEntity = o as IChildEntity;
            }
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }
    }
}
