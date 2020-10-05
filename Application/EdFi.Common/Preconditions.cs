// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Common
{
    public static class Preconditions
    {
        public static T ThrowIfNull<T>(T obj, string parameterName)
            where T : class
        {
            return obj ?? throw new ArgumentNullException(parameterName);
        }

        public static string ThrowIfWhitespace(string value, string parameterName)
        {
            return value.Trim().Length == 0 ?
                throw new ArgumentException("Argument cannot be an empty string or whitespace", parameterName)
                : value;
        }
    }
}
