// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications
{
    public class DescriptorEntitySpecification
    {
        public static bool IsEdFiDescriptorEntity(Type type)
        {
            return IsEdFiDescriptorEntity(type.Name);
        }

        public static bool IsEdFiDescriptorEntity(string typeName)
        {
            return typeName.EndsWithIgnoreCase("Descriptor")
                   && !typeName.EqualsIgnoreCase("Descriptor");
        }
    }
}
