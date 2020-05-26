// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.TestObjects._Extensions;

namespace EdFi.TestObjects.Builders
{
    public class FixedLengthStringValueBuilder : ExplicitLengthStringValueBuilderBase
    {
        /// <summary>
        /// Attempts to get the explicit length of the string to generate.
        /// </summary>
        /// <param name="buildContext">The context of the current value builder.</param>
        /// <returns><b>true</b> if able to define the length; otherwise <b>false</b>.</returns>
        protected override bool TryGetLength(BuildContext buildContext, out int length)
        {
            length = -1;

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

            var attributes = Factory.CustomAttributeProvider.GetCustomAttributes(
                propertyInfo,
                typeof(StringLengthAttribute),
                false);

            if (attributes.Length == 0)
            {
                return false;
            }

            var attribute = (StringLengthAttribute) attributes[0];
            length = attribute.MaximumLength;

            return true;
        }
    }
}
