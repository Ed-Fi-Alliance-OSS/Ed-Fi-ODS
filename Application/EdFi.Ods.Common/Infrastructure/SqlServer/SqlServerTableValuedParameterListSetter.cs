// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Data;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.Common.Infrastructure.Activities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Type;
using NHibernate.Util;

namespace EdFi.Ods.Common.Infrastructure.SqlServer
{
    /// <summary>
    /// Implements an <see cref="IParameterListSetter" /> that is optimized for SQL Server by making
    /// use of a table-valued parameter for the IN clause.
    /// </summary>
    public class SqlServerTableValuedParameterListSetter : IParameterListSetter
    {
        /// <summary>
        /// Sets the value of a SQL Server table-valued parameter (by name) to the supplied list of Ids.
        /// </summary>
        /// <param name="query">The NHibernate query.</param>
        /// <param name="name">The name of the table-valued parameter.</param>
        /// <param name="ids">The list of Ids to be assigned to the parameter's value.</param>
        public void SetParameterList(IQuery query, string name, IEnumerable ids)
        {
            Preconditions.ThrowIfNull(query, nameof(query));
            Preconditions.ThrowIfNull(name, nameof(name));
            Preconditions.ThrowIfNull(ids, nameof(ids));

            // If list is empty, no item type can be determined - pass call through NHibernate
            if (!ids.Cast<object>()
                .Any())
            {
                query.SetParameterList(name, ids);
                return;
            }

            // Determine the item type so we can assess Table-Valued parameter support
            var itemSystemType = ids.Cast<object>()
                .First()
                .GetType();

            IType nHibernateType;

            // If item type is not supported, pass call through to NHibernate 'SetParameterList'
            if (!SqlServerStructuredMappings.StructuredTypeBySystemType.TryGetValue(itemSystemType, out nHibernateType))
            {
                query.SetParameterList(name, ids);
                return;
            }

            // Create a DataTable that matches the structure of the corresponding custom SQL Server type
            var dt = CreateIdDataTable(ids, itemSystemType);

            // Set the named parameter's value, using the DataTable and the structured IType
            query.SetParameter(name, dt, nHibernateType);
        }

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
                             CreateIdDataTable(values, itemSystemType),
                             SqlServerStructuredMappings.StructuredTypeBySystemType[itemSystemType]);
        }

        /// <summary>
        /// Creates a DataTabe with a single column "Id" populated with the given values.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="idType">The type of the "Id" column.</param>
        /// <returns></returns>
        public static DataTable CreateIdDataTable(IEnumerable ids, Type idType)
        {
            // Create a DataTable that matches the structure of the corresponding custom SQL Server type
            var dt = new DataTable();
            dt.Columns.Add("Id", idType);

            // Add the supplied ids as rows in the DataTable
            foreach (var id in ids)
            {
                dt.Rows.Add(id);
            }

            return dt;
        }
    }
}
