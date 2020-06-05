// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using NHibernate;

namespace EdFi.Ods.Api.Common.Extensions
{
    public static class QueryExtensions
    {
        /// <summary>
        /// Sets the value of multiple parameters (by name) on the <see cref="NHibernate.IQuery"/> from the supplied dictionary.
        /// </summary>
        /// <param name="query">The NHibernate query.</param>
        /// <param name="parameters">The named parameter values.</param>
        /// <returns>The NHibernate query.</returns>
        public static IQuery SetParameters(this IQuery query, IDictionary parameters)
        {
            foreach (DictionaryEntry entry in parameters)
            {
                // Set the named parameter values from the supplied dictionary
                query.SetParameter((string)entry.Key, entry.Value);
            }

            return query;
        }
    }
}
