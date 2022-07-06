// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications
{
    public class DescriptorEntitySpecification
    {
        /// <summary>
        /// Indicates whether the specific <see cref="Type" /> matches the convention for an entity derived from the abstract Descriptor
        /// entity, but does not represent the abstract Descriptor entity itself.
        /// </summary>
        /// <param name="type">The <see cref="Type" /> to be evaluated.</param>
        /// <returns><b>true</b> if the type name matches the convention for a Descriptor-derived entity; otherwise <b>false</b>.</returns>
        public static bool IsEdFiDescriptorEntity(Type type)
        {
            return IsEdFiDescriptorEntity(type.Name);
        }

        /// <summary>
        /// Indicates whether the specific type name matches the convention for an entity derived from the abstract Descriptor
        /// entity, but does not represent the abstract Descriptor entity itself.
        /// </summary>
        /// <param name="typeName">The name of the type to be evaluated.</param>
        /// <returns><b>true</b> if the type name matches the convention for a Descriptor-derived entity; otherwise <b>false</b>.</returns>
        public static bool IsEdFiDescriptorEntity(string typeName)
        {
            return typeName.EndsWithIgnoreCase("Descriptor")
                   && !typeName.EqualsIgnoreCase("Descriptor");
        }
    }
}
