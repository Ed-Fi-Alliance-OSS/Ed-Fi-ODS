// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Composites
{
    internal static class IReadOnlyListExtensions
    {
        public static void Add<T>(this IReadOnlyList<T> readOnlyList, T item)
        {
            var underlyingList = readOnlyList as List<T>;

            if (underlyingList == null)
            {
                throw new InvalidOperationException("Underlying list instance is not of type List<T>.");
            }

            underlyingList.Add(item);
        }
    }
}
