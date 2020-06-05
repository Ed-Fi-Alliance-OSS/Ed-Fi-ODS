// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Api.Common.Infrastructure.Architecture.Activities;
using EdFi.Ods.Common;
using NHibernate;
using NHibernate.Type;

namespace EdFi.Ods.Api.Common.Infrastructure.Architecture.SqlServer
{
    /// <summary>
    /// Implements an <see cref="IParameterListSetter" /> that is optimized for SQL Server by making
    /// use of a table-valued parameter for the IN clause.
    /// </summary>
    public class SqlServerTableValuedParameterListSetter : IParameterListSetter
    {
        // Additional types here must be supported with a SQL Server user-defined table type, and explicit
        // support in the SqlServerStructured class.
        private static readonly Dictionary<Type, IType> _structuredTypeBySystemType
            = new Dictionary<Type, IType>
            {
                {typeof(int), new SqlServerStructured<int>()},
                {typeof(Guid), new SqlServerStructured<Guid>()}
            };

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
            if (!_structuredTypeBySystemType.TryGetValue(itemSystemType, out nHibernateType))
            {
                query.SetParameterList(name, ids);
                return;
            }

            // Create a DataTable that matches the structure of the corresponding custom SQL Server type 
            var dt = CreateDataTable(ids, itemSystemType);

            // Set the named parameter's value, using the DataTable and the structured IType
            query.SetParameter(name, dt, nHibernateType);
        }

        private static DataTable CreateDataTable(IEnumerable ids, Type itemSystemType)
        {
            // Create a DataTable that matches the structure of the corresponding custom SQL Server type 
            var dt = new DataTable();
            dt.Columns.Add("Id", itemSystemType);

            // Add the supplied ids as rows in the DataTable
            foreach (var id in ids)
            {
                dt.Rows.Add(id);
            }

            return dt;
        }
    }
}
