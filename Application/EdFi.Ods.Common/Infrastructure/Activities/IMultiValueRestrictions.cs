// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NHibernate.Criterion;

namespace EdFi.Ods.Common.Infrastructure.Activities
{
    /// <summary>
    /// Defines custom NHibernate <see cref="Restrictions" />.
    /// </summary>
    public interface IMultiValueRestrictions
    {
        /// <summary>
        /// Apply an "in" constraint to the named property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the Property in the class. 
        /// View aliases must be enclosed in curly brackets.
        /// </param>
        /// <param name="values">An array of values.</param>
        /// <returns>An <see cref="AbstractCriterion" />.</returns>
        AbstractCriterion In(string propertyName, object[] values);
    }
}
