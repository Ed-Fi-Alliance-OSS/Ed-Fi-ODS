// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Common.Serialization;

public static class AggregateDataByteArrayExtensions
{
    public static DateTime ReadLastModifiedDate(this byte[] aggregateData)
    {
        // Convert the first 8 bytes to a long
        long binary = BitConverter.ToInt64(aggregateData, 0);

        // Deserialize the DateTime
        return DateTime.FromBinary(binary);
    }
}
