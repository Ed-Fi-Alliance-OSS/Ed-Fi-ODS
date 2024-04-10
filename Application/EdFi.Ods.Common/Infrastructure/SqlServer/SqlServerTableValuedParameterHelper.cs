// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Data;

namespace EdFi.Ods.Common.Infrastructure.SqlServer
{
    public static class SqlServerTableValuedParameterHelper
    {
        /// <summary>
        /// Creates a DataTabe with a single column "Id" populated with the given ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="idType">The "Id" type of the DataTable column.</param>
        /// <returns></returns>
        public static DataTable CreateIdDataTable(IEnumerable ids, Type idType)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", idType);

            foreach (var id in ids)
            {
                dt.Rows.Add(id);
            }

            return dt;
        }
    }
}
