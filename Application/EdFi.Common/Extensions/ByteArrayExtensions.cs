// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;

namespace EdFi.Ods.Common.Extensions
{
    public static class ByteArrayExtensions
    {
        public static int ToInt32(this byte[] input) => BitConverter.ToInt32(input, 0);

        public static long ToInt64(this byte[] input) => BitConverter.ToInt64(input, 0);

        public static string ToHexString(this byte[] input) => BitConverter.ToString(input).Replace("-", "");
    }
}
