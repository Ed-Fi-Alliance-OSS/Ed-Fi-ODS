// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using System;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Common.Helpers
{
    public static class StringHelpers
    {
        public static string NamedDatabase<T, TEnum>(TEnum value) => $"{nameof(T)}.{Enum.GetName(typeof(TEnum), value)}";

        public static string NamedDatabase<T, TEnum>(TEnum value, ApiMode apiMode)
            => $"{nameof(T)}.{Enum.GetName(typeof(TEnum), value)}.{apiMode.Value}";
    }
}
#endif
