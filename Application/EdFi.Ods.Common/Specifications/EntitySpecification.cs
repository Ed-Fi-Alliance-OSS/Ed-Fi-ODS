// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications
{
    public static class EntitySpecification
    {
        public static bool HasResourceRepresentation(Entity entity)
        {
            return entity.IsAggregateRoot 
                && !entity.IsAbstract 
                && !entity.FullName.IsEdFiSchoolYearType();
        }
    }
}
