// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Common.Attributes;

namespace EdFi.Ods.Api.Common.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GetSignatureProperties(this Type type)
        {
            return type.GetProperties()
                       .Where(
                            p => Attribute.IsDefined(p, typeof(DomainSignatureAttribute), true));
        }

        public static bool IsScalar(this Type type)
        {
            return type.IsValueType || type == typeof(string);
        }
    }
}
