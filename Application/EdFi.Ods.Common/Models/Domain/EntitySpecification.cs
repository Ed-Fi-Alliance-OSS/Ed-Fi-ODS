// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Models.Domain
{
    public static class EntitySpecification
    {
        public static bool IsLookupEntity(this Entity entity)
        {
            return entity.IsDescriptorEntity();
        }

        /// <summary>
        /// Indicates whether the specific type name matches the convention for an entity derived from the abstract Descriptor
        /// entity, but does not represent the abstract Descriptor entity itself.
        /// </summary>
        /// <param name="typeName">The name of the type to be evaluated.</param>
        /// <returns><b>true</b> if the type name matches the convention for a Descriptor-derived entity; otherwise <b>false</b>.</returns>
        public static bool IsDescriptorEntity(this Entity entity)
        {
            return DescriptorEntitySpecification.IsEdFiDescriptorEntity(entity.Name);
        }

        public static bool IsPersonEntity(this Entity entity)
        {
            return PersonEntitySpecification.IsPersonEntity(entity.Name);
        }
    }
}
