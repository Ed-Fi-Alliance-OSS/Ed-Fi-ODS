// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using NHibernate;
using NHibernate.Criterion;

namespace EdFi.Ods.Common.Infrastructure.Activities
{
    /// <summary>
    /// Defines a method for setting a list of parameters on an <see cref="NHibernate.IQuery" /> instance.
    /// </summary>
    public interface IParameterListSetter
    {
        /// <summary>
        /// Sets the value of a parameter (by name) to the supplied list of Ids.
        /// </summary>
        /// <param name="query">The NHibernate query.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="ids">The list of Ids to be assigned to the parameter's value.</param>
        void SetParameterList(IQuery query, string name, IEnumerable ids);

        /// <summary>
        /// Apply an "in" constraint to the named property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the Property in the class. 
        /// View aliases must be enclosed in curly brackets.
        /// </param>
        /// <param name="values">An array of values.</param>
        /// <returns>An <see cref="AbstractCriterion" />.</returns>
        public AbstractCriterion In(string propertyName, object[] values);
    }
}
