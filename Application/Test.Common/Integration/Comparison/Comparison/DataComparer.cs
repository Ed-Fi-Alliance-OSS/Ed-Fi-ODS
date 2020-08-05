// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using log4net;

namespace Test.Common.Integration.Comparison.Comparison
{
    /// <summary>
    /// Contains values that represent how the <see cref="DataComparer"/> handles the copying of actual and expected data into the <see cref="DataComparerResults"/>.
    /// </summary>
    public enum DataCopyMode
    {
        /// <summary>
        /// Indicates that no data will be copied to the results.
        /// </summary>
        /// <remarks>This is the best option for regression acceptance tests where the cost of running an acceptance test again is low and the data does not need to be persisted.</remarks>
        None, /// <summary>
        /// Indicates that only data that is different will be copied to the results.
        /// </summary>
        /// <remarks>This is the best option for parallel tests where the cost of comparing the actual and expected data again could be very high, and we only want a relevant subset of the data to be persisted for subsequent review.</remarks>
        DifferencesOnly, /// <summary>
        /// Indicates that all data will be copied to the results.
        /// </summary>
        /// <remarks>This is the best option for interactive acceptance tests where a full visual inspection of the expected and actual data sets is necessary to support development of the jobs.</remarks>
        All
    }

    /// <summary>
    /// Implements a method for comparing two <see cref="IDataReader"/> instances.
    /// </summary>
    public class DataComparer : IDataComparer
    {
        private readonly bool _allowActualsColumnsToBeSubset;

        /// <summary>
        /// Holds the value for the <see cref="FieldNamesToIgnore"/> property.
        /// </summary>
        private readonly List<string> _fieldNamesToIgnore = new List<string>();
        private readonly ILog _logger = LogManager.GetLogger(typeof(DataComparer));

        private readonly Dictionary<IDataReader, int> rowCountsByReader = new Dictionary<IDataReader, int>();

        private readonly Dictionary<IDataReader, DataTable> tablesByReader = new Dictionary<IDataReader, DataTable>();

        /// <summary>
        /// Holds the value for the <see cref="MaximumDifferences"/> property.
        /// </summary>
        private int _maximumDifferences = 100;
        private int[] actualPKOrdinals;

        private DataCopyMode dataCopyMode;
        private List<string> primaryKeyFields;

        public DataComparer() { }

        public DataComparer(bool allowActualsColumnsToBeSubset)
        {
            _allowActualsColumnsToBeSubset = allowActualsColumnsToBeSubset;
        }

        /// <summary>
        /// Gets or sets a value indicating the maximum number of differences that will be captured by the comparer before it stops processing data.  This is used to avoid processing and capturing information on differences of exceedingly large datasets.
        /// </summary>
        public int MaximumDifferences
        {
            get { return _maximumDifferences; }
            set { _maximumDifferences = value; }
        }

        /// <summary>
        /// Gets a reference to the list of field names that should be ignored when comparing individual records.
        /// </summary>
        public List<string> FieldNamesToIgnore
        {
            get { return _fieldNamesToIgnore; }
        }

        /// <summary>
        /// Gets or sets a value indicating .
        /// </summary>
        public string FieldNamesToIgnoreAsDelimitedString
        {
            get { return string.Join(";", _fieldNamesToIgnore.ToArray()); }
            set { _fieldNamesToIgnore.AddRange(value.Split(';')); }
        }

        /// <summary>
        /// Compares the contents of two IDataReader instances, ignoring the specified columns, optionally creating DataTables for further inspection of the data.
        /// </summary>
        /// <param name="tableName">The name of the table for which the data comparison was performed.</param>
        /// <param name="expectedData">A <see cref="IDataReader"/> containing the expected data.</param>
        /// <param name="actualData">A <see cref="IDataReader"/> containing the actual data.</param>
        /// <param name="uniqueConstraintFieldNames">An array of the names of the primary key fields to use as the basis for identifying corresponding rows between the two readers.</param>
        /// <param name="isPrimaryKey"></param>
        /// <param name="dataCopyMode">Indicates whether or not a <see cref="DataTable"/> should be created for each <see cref="IDataReader"/> (expected and actual) and the data copied in while processing the readers.</param>
        /// <param name="additionalFieldsToIgnore">Fields to ignore for the current comparison (mismatches in data values will not be counted as failures).</param>
        /// <returns>The results of the comparison.</returns>
        public DataComparerResults Compare(
            string tableName,
            IDataReader expectedData,
            IDataReader actualData,
            string[] uniqueConstraintFieldNames,
            bool isPrimaryKey,
            DataCopyMode dataCopyMode,
            string[] additionalFieldsToIgnore)
        {
            //Initialize an empty array if the parameter is null.
            additionalFieldsToIgnore = additionalFieldsToIgnore ?? new string[0];

            var dataComparerResults = new DataComparerResults {TableName = tableName};

            this.dataCopyMode = dataCopyMode;

            // Prepare data tables, if necessary
            if (dataCopyMode == DataCopyMode.All || dataCopyMode == DataCopyMode.DifferencesOnly)
            {
                DataTable expectedTable = InitializeDataTable(expectedData, uniqueConstraintFieldNames, isPrimaryKey);
                expectedTable.TableName = "ExpectedDataTable";
                tablesByReader[expectedData] = expectedTable;
                dataComparerResults.ExpectedData = expectedTable;

                DataTable actualTable = InitializeDataTable(actualData, uniqueConstraintFieldNames, isPrimaryKey);
                actualTable.TableName = "ActualDataTable";
                tablesByReader[actualData] = actualTable;
                dataComparerResults.ActualData = actualTable;
            }

            primaryKeyFields = new List<string>(uniqueConstraintFieldNames);

            InitializeColumnNamesFromReader(dataComparerResults.ColumnNames, actualData);

            VerifyThatAllNonTestColumnsFromExpectedDataArePresent(
                dataComparerResults.TableName,
                dataComparerResults.ColumnNames,
                expectedData,
                additionalFieldsToIgnore);

            // Initialize counts
            rowCountsByReader[expectedData] = 0;
            rowCountsByReader[actualData] = 0;

            int[] expectedPKOrdinals =
                (from field in uniqueConstraintFieldNames
                    select expectedData.GetOrdinal(field)).ToArray();

            actualPKOrdinals =
                (from field in uniqueConstraintFieldNames
                    select actualData.GetOrdinal(field)).ToArray();

            DbDataReaderComparer comparer = new DbDataReaderComparer(expectedPKOrdinals, actualPKOrdinals);

            CompareAndDisposeDataReaders(comparer, dataComparerResults, actualData, expectedData, additionalFieldsToIgnore);

            // Set counts
            dataComparerResults.ExpectedRowCount = rowCountsByReader[expectedData];
            dataComparerResults.ActualRowCount = rowCountsByReader[actualData];

            return dataComparerResults;
        }

        /// <summary>
        /// Compares the contents of two IDataReader instances, optionally creating DataTables for further inspection of the data.
        /// </summary>
        /// <param name="tableName">The name of the table for which the data comparison was performed.</param>
        /// <param name="expectedData">A <see cref="IDataReader"/> containing the expected data.</param>
        /// <param name="actualData">A <see cref="IDataReader"/> containing the actual data.</param>
        /// <param name="uniqueConstraintFieldNames">An array of the names of the primary key fields to use as the basis for identifying corresponding rows between the two readers.</param>
        /// <param name="isPrimaryKey"></param>
        /// <param name="dataCopyMode">Indicates whether or not a <see cref="DataTable"/> should be created for each <see cref="IDataReader"/> (expected and actual) and the data copied in while processing the readers.</param>
        /// <returns>The results of the comparison.</returns>
        public DataComparerResults Compare(
            string tableName,
            IDataReader expectedData,
            IDataReader actualData,
            string[] uniqueConstraintFieldNames,
            bool isPrimaryKey,
            DataCopyMode dataCopyMode)
        {
            return Compare(tableName, expectedData, actualData, uniqueConstraintFieldNames, isPrimaryKey, dataCopyMode, null);
        }

        private DataTable InitializeDataTable(IDataReader reader, string[] uniqueFieldNames, bool hasPrimaryKey)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                Type fieldType = reader.GetFieldType(i);

                if (fieldType == typeof(TimeSpan))
                {
                    dt.Columns.Add(
                        reader.GetName(i),
                        typeof(string));
                }
                else
                {
                    dt.Columns.Add(
                        reader.GetName(i),
                        fieldType);
                }
            }

            // Set the primary key
            List<DataColumn> pkColumns = new List<DataColumn>();

            foreach (string keyFieldName in uniqueFieldNames)
            {
                pkColumns.Add(dt.Columns[keyFieldName]);
            }

            dt.Constraints.Add("PrimaryKey", pkColumns.ToArray(), hasPrimaryKey);

            return dt;
        }

        private void CompareAndDisposeDataReaders(
            DbDataReaderComparer comparer,
            DataComparerResults dataComparerResults,
            IDataReader actualData,
            IDataReader expectedData,
            IEnumerable<string> additionalColumnNamesToIgnore)
        {
            try
            {
                bool expectedReaderHasMoreData = ReadDataReader(expectedData);
                bool actualReaderHasMoreData = ReadDataReader(actualData);

                // No data?  Quit now
                if (!actualReaderHasMoreData && !expectedReaderHasMoreData)
                {
                    return;
                }

                Dictionary<string, bool> additionalFieldsToIgnore =
                    GetAdditionalFieldsToIgnoreAsDictionary(additionalColumnNamesToIgnore);

                do
                {
                    // Using primary key values, determine whether readers are on same record, or one is "ahead" of the other
                    int pkCompareResult = CompareCurrentReadersPKValues(
                        comparer,
                        expectedData,
                        actualData,
                        expectedReaderHasMoreData,
                        actualReaderHasMoreData);

                    ProcessComparisonResults(
                        dataComparerResults,
                        pkCompareResult,
                        expectedData,
                        actualData,
                        ref expectedReaderHasMoreData,
                        ref actualReaderHasMoreData,
                        additionalFieldsToIgnore);
                }
                while ((expectedReaderHasMoreData || actualReaderHasMoreData)
                       && dataComparerResults.RowDifferences.Count < MaximumDifferences);
            }
            finally
            {
                // Make sure the the data readers are properly disposed
                actualData.Dispose();
                expectedData.Dispose();
            }
        }

        private static Dictionary<string, bool> GetAdditionalFieldsToIgnoreAsDictionary(
            IEnumerable<string> additionalColumnNamesToIgnore)
        {
            Dictionary<string, bool> additionalFieldsToIgnore = new Dictionary<string, bool>();

            if (additionalColumnNamesToIgnore != null)
            {
                foreach (string fieldName in additionalColumnNamesToIgnore)
                {
                    additionalFieldsToIgnore.Add(fieldName, true);
                }
            }

            return additionalFieldsToIgnore;
        }

        private void VerifyThatAllNonTestColumnsFromExpectedDataArePresent(
            string actualTableName,
            List<string> columnNames,
            IDataReader expectedData,
            IList<string> additionalFieldsToIgnore)
        {
            for (int i = 0; i < expectedData.FieldCount; i++)
            {
                string expectedFieldName = expectedData.GetName(i);

                if (additionalFieldsToIgnore.Contains(expectedFieldName))
                {
                    continue;
                }

                if (!columnNames.Contains(expectedFieldName))
                {
                    if (_allowActualsColumnsToBeSubset)
                    {
                        _logger.WarnFormat(
                            "'Actual Values' data reader (for table '{0}') does not have column '{1}'.",
                            actualTableName,
                            expectedFieldName);
                    }
                    else

                        //TODO: GKM - Evaluate for reinclusion after Types/Descriptor handling resolved
                    {
                        throw new InvalidDataException(
                            string.Format(
                                "'Actual Values' data reader (for table '{0}') does not have column '{1}'.",
                                actualTableName,
                                expectedFieldName));
                    }
                }
            }
        }

        private bool ReadDataReader(IDataReader reader)
        {
            bool result = reader.Read();

            if (result)
            {
                rowCountsByReader[reader] = rowCountsByReader[reader] + 1;

                if (dataCopyMode == DataCopyMode.All)
                {
                    AddDataRowToTable(reader, tablesByReader[reader]);
                }
            }

            return result;
        }

        private void AddDataRowToTable(IDataReader reader, DataTable table)
        {
            DataRow newRow = table.NewRow();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                object fieldValue = reader.GetValue(i);

                if (fieldValue.GetType() == typeof(TimeSpan))
                {
                    // Convert TimeSpans to strings because TimeSpan is not serializable to XML
                    newRow[i] = fieldValue.ToString();
                }
                else
                {
                    newRow[i] = fieldValue;
                }
            }

            table.Rows.Add(newRow);
        }

        private void InitializeColumnNamesFromReader(List<string> columnNames, IDataReader dataReader)
        {
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                columnNames.Add(dataReader.GetName(i));
            }
        }

        private void ProcessComparisonResults(
            DataComparerResults results,
            int pkCompareResult,
            IDataReader expectedData,
            IDataReader actualData,
            ref bool expectedReaderHasMoreData,
            ref bool actualReaderHasMoreData,
            IDictionary<string, bool> additionalFieldsToIgnore)
        {
            switch (Math.Sign(pkCompareResult))
            {
                case -1:

                    // Missing row in actuals
                    HandleMissingActualRow(expectedData, results);
                    expectedReaderHasMoreData = ReadDataReader(expectedData);
                    break;

                case 0:

                    // Row matches as expected, advance both readers
                    HandleSameRow(expectedData, actualData, results, additionalFieldsToIgnore);
                    expectedReaderHasMoreData = ReadDataReader(expectedData);
                    actualReaderHasMoreData = ReadDataReader(actualData);
                    break;

                case 1:

                    // Unexpected row in actuals
                    HandleUnexpectedActualsRow(actualData, results);
                    actualReaderHasMoreData = ReadDataReader(actualData);
                    break;
            }
        }

        private void HandleSameRow(
            IDataReader expectedReader,
            IDataReader actualsReader,
            DataComparerResults results,
            IDictionary<string, bool> additionalFieldsToIgnore)
        {
            DataComparerRowResults rowResults = null;

            // Iterate through all the fields, comparing values
            for (int i = 0; i < actualsReader.FieldCount; i++)
            {
                string fieldName = actualsReader.GetName(i);

                if (ShouldSkipFieldValueComparison(fieldName, additionalFieldsToIgnore))
                {
                    continue;
                }

                // Get the expected value
                int expectedOrdinal = GetExpectedOrdinal(expectedReader, fieldName);

                if (expectedOrdinal < 0)
                {
                    _logger.WarnFormat("Expected row does not have column '{0}'", fieldName);
                    continue;
                }

                object expectedValue = expectedReader.GetValue(expectedOrdinal);

                object actualValue = actualsReader.GetValue(i);

                if (!expectedValue.Equals(actualValue))
                {
                    // Make sure row results object is created
                    if (rowResults == null)
                    {
                        rowResults = new DataComparerRowResults(DataComparerRowDifference.ValuesDiffer);
                    }

                    rowResults.ExpectedValues[fieldName] = MakeSerializable(expectedValue);
                    rowResults.ActualValues[fieldName] = MakeSerializable(actualValue);
                }
            }

            if (rowResults != null)
            {
                CollectPrimaryKeyValues(actualsReader, rowResults.KeyValues);
                results.RowDifferences.Add(rowResults);

                // Add difference to the DataTables as well...
                if (dataCopyMode == DataCopyMode.DifferencesOnly)
                {
                    AddDataRowToTable(expectedReader, tablesByReader[expectedReader]);
                    AddDataRowToTable(actualsReader, tablesByReader[actualsReader]);
                }
            }
        }

        private object MakeSerializable(object value)
        {
            if (value.GetType() == typeof(TimeSpan))
            {
                return value.ToString();
            }

            if (value == DBNull.Value)
            {
                return null;
            }

            return value;
        }

        private void CollectPrimaryKeyValues(IDataReader sourceReader, Hashtable values)
        {
            foreach (string fieldName in primaryKeyFields)
            {
                int ordinal = sourceReader.GetOrdinal(fieldName);
                values[sourceReader.GetName(ordinal)] = MakeSerializable(sourceReader.GetValue(ordinal));
            }
        }

        private static int GetExpectedOrdinal(IDataReader expectedData, string fieldName)
        {
            int expectedOrdinal;

            try
            {
                expectedOrdinal = expectedData.GetOrdinal(fieldName);
            }
            catch (Exception)
            {
                throw new InvalidDataException("'Expected Values' data reader does not have column '" + fieldName + "'.");

                //return -1;
            }

            return expectedOrdinal;
        }

        private bool ShouldSkipFieldValueComparison(string fieldName, IDictionary<string, bool> additionalFieldsToIgnore)
        {
            return FieldNamesToIgnore.Contains(fieldName) || additionalFieldsToIgnore.ContainsKey(fieldName);
        }

        private void HandleUnexpectedActualsRow(IDataReader actualsReader, DataComparerResults results)
        {
            // Unexpected actual row
            DataComparerRowResults diff = new DataComparerRowResults(DataComparerRowDifference.UnexpectedRow);
            CollectPrimaryKeyValues(actualsReader, diff.KeyValues);
            CollectRowValues(actualsReader, diff.ActualValues);
            results.RowDifferences.Add(diff);

            // Add difference to the DataTable as well...
            if (dataCopyMode == DataCopyMode.DifferencesOnly)
            {
                AddDataRowToTable(actualsReader, tablesByReader[actualsReader]);
            }
        }

        private void HandleMissingActualRow(IDataReader expectedReader, DataComparerResults results)
        {
            // Missing actual row
            DataComparerRowResults diff = new DataComparerRowResults(DataComparerRowDifference.RowMissing);
            CollectPrimaryKeyValues(expectedReader, diff.KeyValues);
            CollectRowValues(expectedReader, diff.ExpectedValues);
            results.RowDifferences.Add(diff);

            // Add difference to the DataTable as well...
            if (dataCopyMode == DataCopyMode.DifferencesOnly)
            {
                AddDataRowToTable(expectedReader, tablesByReader[expectedReader]);
            }
        }

        private static int CompareCurrentReadersPKValues(
            DbDataReaderComparer comparer,
            IDataReader expectedData,
            IDataReader actualData,
            bool expectedReaderHasMoreData,
            bool actualReaderHasMoreData)
        {
            int pkCompareResult;

            if (expectedReaderHasMoreData && actualReaderHasMoreData)
            {
                // With both readers having data, compare PK values
                pkCompareResult = comparer.Compare(expectedData, actualData);
            }
            else if (!expectedReaderHasMoreData && !actualReaderHasMoreData)
            {
                // Neither reader has data
                throw new InvalidOperationException("Neither IDataReader instance has data.");
            }
            else if (!expectedReaderHasMoreData)
            {
                // Expected values reader ran out of data
                // (Unexpected actual row in actual values reader)
                pkCompareResult = 1;
            }
            else // !actualReaderHasMoreData
            {
                // Actual values reader ran out of data
                // (Missing a row in actual values reader)
                pkCompareResult = -1;
            }

            return pkCompareResult;
        }

        private void CollectRowValues(IDataReader sourceReader, Hashtable values)
        {
            for (int i = 0; i < sourceReader.FieldCount; i++)
            {
                string columnName = sourceReader.GetName(i);

                if (!IsPrimaryKeyColumn(columnName))
                {
                    values[columnName] = MakeSerializable(sourceReader.GetValue(i));
                }
            }
        }

        private bool IsPrimaryKeyColumn(string columnName)
        {
            return primaryKeyFields.Contains(columnName);
        }
    }
}
