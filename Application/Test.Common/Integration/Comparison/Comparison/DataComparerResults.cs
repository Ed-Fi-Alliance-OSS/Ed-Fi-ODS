// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Test.Common.Integration.Comparison.Comparison
{
    /// <summary>
    /// Compares two result sets and reports differences.
    /// </summary>
    public class DataComparerResults
    {
        /// <summary>
        /// Holds the value for the <see cref="TableName"/> property.
        /// </summary>
        private string _tableName;

        // Default constructor for XML Serialization
        public DataComparerResults() { }

        public DataComparerResults(string tableName, int expectedRowCount, int actualRowCount)
        {
            _tableName = tableName;
            ExpectedRowCount = expectedRowCount;
            ActualRowCount = actualRowCount;
        }

        /// <summary>
        /// Gets the number of rows that were found in the "actuals" result set.
        /// </summary>
        public int ActualRowCount { get; set; }

        public DataTable ActualData { get; set; }

        /// <summary>
        /// Gets the number of rows that were found in the "expected data" result set.
        /// </summary>
        public int ExpectedRowCount { get; set; }

        public DataTable ExpectedData { get; set; }

        /// <summary>
        /// Gets a list that contains the names of the columns of the resultset.
        /// </summary>
        public List<string> ColumnNames { get; set; } = new List<string>();

        /// <summary>
        /// Gets a list that contains details about all the differences found between the expected and actual result sets.
        /// </summary>
        public List<DataComparerRowResults> RowDifferences { get; set; } = new List<DataComparerRowResults>();

        /// <summary>
        /// Gets or sets the name of the table for which the data comparison was performed.
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        /// <summary>
        /// Displays a textual view of the differences between actual and expected data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                @"Table Name:         {0}
Expected Row Count: {1}
Actual Row Count:   {2}

Differences:        {3}

{4}
",
                TableName,
                ExpectedRowCount,
                ActualRowCount,
                RowDifferences.Count,
                GetRowDifferencesText());
        }

        private string GetRowDifferencesText()
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataComparerRowResults results in RowDifferences)
            {
                sb.AppendLine(results.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
