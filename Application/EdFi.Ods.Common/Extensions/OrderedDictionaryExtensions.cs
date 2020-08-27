// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace EdFi.Ods.Common.Extensions
{
    public static class OrderedDictionaryExtensions
    {
        public static OrderedDictionary Clone(this OrderedDictionary source)
        {
            var newCopy = new OrderedDictionary();

            foreach (DictionaryEntry entry in source)
            {
                newCopy.Add(entry.Key, entry.Value);
            }

            return newCopy;
        }

        public static IEnumerable<DictionaryEntry> AsEnumerable(this OrderedDictionary source)
        {
            foreach (DictionaryEntry dictionaryEntry in source)
            {
                yield return dictionaryEntry;
            }
        }
    }
}
