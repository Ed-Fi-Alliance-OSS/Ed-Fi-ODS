// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Models.Resource
{
    public static class ResourceSpecification
    {
        /// <summary>
        /// Indicates whether the supplied property name is one that should be included
        /// in the resource model.
        /// </summary>
        /// <param name="entityPropertyName">The name of the property to be evaluated.</param>
        /// <returns><b>true</b> if the property is allowed to appear in the resource; otherwise <b>false</b>.</returns>
        public static bool IsAllowableResourceProperty(string entityPropertyName)
        {
            // Exclude boilerplate dates from resources
            return !(entityPropertyName.EqualsIgnoreCase("LastModifiedDate")
                     || entityPropertyName.EqualsIgnoreCase("CreateDate")
                     || UniqueIdSpecification.IsUSI(entityPropertyName));
        }
    }
}
