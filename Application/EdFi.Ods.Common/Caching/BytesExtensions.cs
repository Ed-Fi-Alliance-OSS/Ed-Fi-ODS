// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;

namespace EdFi.Ods.Common.Caching;

public static class BytesExtensions
{
    public static byte[] GetBytes<T>(this T value)
    {
        if (value is int intValue)
        {
            return BitConverter.GetBytes(intValue);
        }

        if (value is string stringValue)
        {
            return Encoding.UTF8.GetBytes(stringValue);
        }

        if (value is ulong ulongValue)
        {
            return BitConverter.GetBytes(ulongValue);
        }

        if (value is byte[] bytesValue)
        {
            return bytesValue;
        }
        
        throw new NotImplementedException($"Support for extracting bytes from type '{typeof(T)}' has not been implemented.");
    }
}
