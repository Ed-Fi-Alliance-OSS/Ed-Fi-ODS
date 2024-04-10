// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Infrastructure.Activities;
using NHibernate.Criterion;
using NHibernate.Util;

namespace EdFi.Ods.Common.Infrastructure.SqlServer
{
    /// <summary>
    /// Implements an <see cref="IMultiValueRestrictions" /> that is optimized for SQL Server.
    /// </summary>
    public class SqlServerMultiValueRestrictions : IMultiValueRestrictions
    {
        /// <summary>
        /// Apply an "in" constraint to the named property.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the Property in the class. 
        /// View aliases must be enclosed in curly brackets.
        /// <param name="values">An array of values.</param>
        /// <returns>An <see cref="AbstractCriterion" />.</returns>
        public AbstractCriterion In(string propertyName, object[] values)
        {
            var itemSystemType = values.First().GetType();

            return Expression.Sql($"{propertyName} IN (?)",
                             SqlServerTableValuedParameterHelper.CreateIdDataTable(values, itemSystemType),
                             SqlServerStructuredMappings.StructuredTypeBySystemType[itemSystemType]);
        }
    }
}
