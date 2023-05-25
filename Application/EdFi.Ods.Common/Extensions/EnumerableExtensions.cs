// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }

            return source;
        }

        public static bool Contains(this IEnumerable<string> source, StringSegment value)
            => Contains(source, value, StringComparison.Ordinal);

        public static bool Contains(this IEnumerable<string> source, StringSegment value, StringComparison stringComparison)
        {
            ArgumentNullException.ThrowIfNull(source);

            foreach (var element in source)
            {
                if (value.Equals(element, stringComparison))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
