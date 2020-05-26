// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Data;
using System.Data.Common;

namespace Test.Common.Integration.Comparison.Comparison
{
    /// <summary>
    /// Defines a method for comparing two <see cref="DbDataReader"/> instances.
    /// </summary>
    public interface IDataComparer
    {
        /// <summary>
        /// Compares the contents of two DbDataReader instances, optionally creating DataTables for further inspection of the data.
        /// </summary>
        /// <param name="tableName">The name of the table for which the data comparison was performed.</param>
        /// <param name="expectedData">A <see cref="DbDataReader"/> containing the expected data.</param>
        /// <param name="actualData">A <see cref="DbDataReader"/> containing the actual data.</param>
        /// <param name="uniqueConstraintFieldNames">An array of the names of the fields to use as the basis for identifying corresponding rows between the two readers.</param>
        /// <param name="isPrimaryKey">Indicates whether the unique constraint field names refers to a primary key.</param>
        /// <param name="dataCopyMode">Indicates whether or not a <see cref="DataTable"/> should be created for each <see cref="DbDataReader"/> (expected and actual) and the data copied in while processing the readers.</param>
        /// <returns>The results of the comparison.</returns>
        DataComparerResults Compare(
            string tableName,
            IDataReader expectedData,
            IDataReader actualData,
            string[] uniqueConstraintFieldNames,
            bool isPrimaryKey,
            DataCopyMode dataCopyMode);

        /// <summary>
        /// Compares the contents of two DbDataReader instances, ignoring the specified columns, optionally creating DataTables for further inspection of the data.
        /// </summary>
        /// <param name="tableName">The name of the table for which the data comparison was performed.</param>
        /// <param name="expectedData">A <see cref="DbDataReader"/> containing the expected data.</param>
        /// <param name="actualData">A <see cref="DbDataReader"/> containing the actual data.</param>
        /// <param name="uniqueConstraintFieldNames">An array of the names of the primary key fields to use as the basis for identifying corresponding rows between the two readers.</param>
        /// <param name="isPrimaryKey">Indicates whether the unique constraint field names refers to a primary key.</param>
        /// <param name="dataCopyMode">Indicates whether or not a <see cref="DataTable"/> should be created for each <see cref="DbDataReader"/> (expected and actual) and the data copied in while processing the readers.</param>
        /// <param name="additionalFieldsToIgnore">Fields to ignore for the current comparison (mismatches in data values will not be counted as failures).</param>
        /// <returns>The results of the comparison.</returns>
        DataComparerResults Compare(
            string tableName,
            IDataReader expectedData,
            IDataReader actualData,
            string[] uniqueConstraintFieldNames,
            bool isPrimaryKey,
            DataCopyMode dataCopyMode,
            string[] additionalFieldsToIgnore);
    }
}
