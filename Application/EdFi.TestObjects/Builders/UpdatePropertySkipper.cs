// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.TestObjects._Extensions;

namespace EdFi.TestObjects.Builders
{
    public class UpdatePropertySkipper : IValueBuilder
    {
        private static readonly HashSet<Type> _ignoreAttributeMarkers = new HashSet<Type>();

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.BuildMode != BuildMode.Modify)
            {
                return ValueBuildResult.NotHandled;
            }

            if (buildContext.ContainingType == null)
            {
                return ValueBuildResult.NotHandled;
            }

            var propertyName = buildContext.LogicalPropertyPath.Split('.')
                                           .Last();

            var propertyInfo = buildContext.ContainingType.GetPublicProperties()
                                           .SingleOrDefault(x => x.Name == propertyName);

            if (propertyInfo == null)
            {
                throw new Exception(
                    string.Format(
                        "Unable to find property '{0}' on type '{1}' (or its implementations).",
                        propertyName,
                        buildContext.ContainingType));
            }

            var attributes = Factory.CustomAttributeProvider.GetCustomAttributes(propertyInfo, false);

            var attributeTypes = attributes.Select(a => a.GetType());

            if (attributeTypes.Intersect(_ignoreAttributeMarkers)
                              .Any())
            {
                return ValueBuildResult.Skip(buildContext.LogicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset()
        {
            //NOOP
        }

        public ITestObjectFactory Factory { get; set; }

        public static void ClearIgnores()
        {
            _ignoreAttributeMarkers.Clear();
        }

        public static void IgnorePropertiesMarkedWith<TAttribute>()
            where TAttribute : Attribute
        {
            _ignoreAttributeMarkers.Add(typeof(TAttribute));
        }
    }
}
