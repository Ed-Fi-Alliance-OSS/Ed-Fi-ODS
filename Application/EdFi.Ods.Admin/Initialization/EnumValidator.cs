// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Configuration;

namespace EdFi.Ods.Admin.Initialization
{
    /// <summary>
    /// The validate method here is redundant because the CanValidate verifies the type to a specific Enum type.
    /// </summary>
    /// <typeparam name="T">a specific enum type</typeparam>
    public class EnumValidator<T> : ConfigurationValidatorBase
        where T : struct, IConvertible
    {
        public override void Validate(object value)
        {
            // No further validation required. Type is all we need.
        }

        public override bool CanValidate(Type type)
        {
            return typeof(T) == type;
        }
    }
}
