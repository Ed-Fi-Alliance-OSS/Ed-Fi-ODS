// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.CodeGen.Extensions;

public static class PropertyHelpers
{
    public static bool CSharpDefaultHasDomainMeaning(string propertyName, PropertyType propertyType)
    {
        // Any min/max range definition implies domain meaning
        if (propertyType.MinValue.HasValue || propertyType.MaxValue.HasValue)
        {
            return true;
        }

        switch (propertyType.ToCSharp())
        {
            case CSharpLanguageType.Guid:
            case CSharpLanguageType.String:
            case CSharpLanguageType.DateTime:
                return false;

            case CSharpLanguageType.TimeSpan:

                if (propertyName.StartsWith("Start")
                    || propertyName.StartsWith("Begin")
                    || propertyName.StartsWith("End"))
                {
                    return false;
                }

                break;

            case "short":
            case "int":
            case "long":

                if (propertyName.EndsWith("Year", StringComparison.OrdinalIgnoreCase)
                    || propertyName.Equals("Version", StringComparison.OrdinalIgnoreCase)
                    || propertyName.Contains("Sequence")
                    || propertyName.EndsWith("Number")
                    || propertyName.EndsWith("Id")
                    || propertyName.EndsWith("USI"))
                {
                    return false;
                }

                break;

            default:
                return true;
        }

        return true;
    }
}
