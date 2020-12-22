// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Models.Domain
{
    public static class EntitySpecification
    {
        public static bool IsLookupEntity(this Entity entity)
        {
            return entity.IsDescriptorEntity();
        }

        public static bool IsDescriptorEntity(this Entity entity)
        {
            return DescriptorEntitySpecification.IsEdFiDescriptorEntity(entity.Name);
        }

        public static bool IsPersonEntity(this Entity entity)
        {
            return PersonEntitySpecification.IsPersonEntity(entity.Name);
        }
        
        public static bool HasServerAssignedSurrogateId(this Entity entity)
        {
            //People and the base descriptors have server assigned surrogate ids.
            return entity.Identifier.Properties.Any(
                p =>
                    p.IsServerAssigned
                    && !p.Entity.IsDerived
                    && p.Entity.IsAggregateRoot);
        }
    }
}
