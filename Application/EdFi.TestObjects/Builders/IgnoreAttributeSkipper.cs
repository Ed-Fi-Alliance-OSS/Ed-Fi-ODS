// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Linq;
using EdFi.TestObjects._Extensions;

namespace EdFi.TestObjects.Builders
{
    public class IgnoreAttributeSkipper : IValueBuilder
    {
        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.ContainingType == null)
            {
                return ValueBuildResult.NotHandled;
            }

            var propertyName = buildContext.LogicalPropertyPath.Split('.')
                                           .Last();

            var propertyInfo = buildContext.ContainingType.GetPublicProperties()
                                           .SingleOrDefault(p => p.Name == propertyName);

            if (propertyInfo == null)
            {
                throw new Exception(
                    string.Format(
                        "Property '{0}' not found on Type '{1}'.",
                        propertyName,
                        buildContext.ContainingType.FullName));
            }

            var ignoredByAttribute = Factory.CustomAttributeProvider
                                            .GetCustomAttributes(propertyInfo, true)
                                            .Any(
                                                 a => a.GetType()
                                                       .Name.Contains("Ignore"));

            return ignoredByAttribute
                ? ValueBuildResult.Skip(buildContext.LogicalPropertyPath)
                : ValueBuildResult.NotHandled;
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }
    }
}
