// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;

namespace EdFi.TestObjects.CustomBuilders
{
    public class NamedPropertySkipper<T> : IValueBuilder
    {
        private readonly string _propertyName;

        public NamedPropertySkipper(string propertyName)
        {
            _propertyName = propertyName;
        }

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            string logicalPropertyPath = buildContext.LogicalPropertyPath;

            var propertyName = logicalPropertyPath.Split('.')
                                                  .Last();

            if (propertyName.Equals(_propertyName) && buildContext.TargetType == typeof(T))
            {
                return ValueBuildResult.Skip(logicalPropertyPath);
            }

            return ValueBuildResult.NotHandled;
        }

        public void Reset() { }

        public ITestObjectFactory Factory { get; set; }
    }
}
