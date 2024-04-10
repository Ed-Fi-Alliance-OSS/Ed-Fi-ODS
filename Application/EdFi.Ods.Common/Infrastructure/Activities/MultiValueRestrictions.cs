// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate.Criterion;
using System.Collections.Concurrent;

namespace EdFi.Ods.Common.Infrastructure.Activities
{
    /// <summary>
    /// Implements a default <see cref="IMultiValueRestrictions" /> as a pass-through to NHibernate.
    /// </summary>
    public class MultiValueRestrictions : IMultiValueRestrictions
    {
        private readonly ConcurrentDictionary<string, string> _propertyNameByViewAlias = new();

        /// <summary>
        /// Apply an "in" constraint to the named property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the Property in the class.
        /// </param>
        /// <param name="values">An array of values.</param>
        /// <returns>An <see cref="AbstractCriterion" />.</returns>
        public AbstractCriterion In(string propertyName, object[] values)
        {
            // NHibernate's Restrictions.In() does not expect view aliases to be enclosed in
            // curly brackets (contrary to Expression.Sql())
            propertyName = _propertyNameByViewAlias.GetOrAdd(propertyName, (p) => p
                .Replace("{", string.Empty)
                .Replace("}", string.Empty));

            return Restrictions.In(propertyName, values);
        }
    }
}
