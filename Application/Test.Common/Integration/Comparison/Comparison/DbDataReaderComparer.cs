// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Data;

namespace Test.Common.Integration.Comparison.Comparison
{
    public class DbDataReaderComparer : IComparer<IDataReader>
    {
        private readonly int[] actualPKOrdinals;
        private readonly int[] expectedPKOrdinals;

        public DbDataReaderComparer(int[] expectedPKOrdinals, int[] actualPKOrdinals)
        {
            if (expectedPKOrdinals.Length != actualPKOrdinals.Length)
            {
                throw new ApplicationException("Primary Key lengths must be the same for comparison to take place.");
            }

            this.expectedPKOrdinals = expectedPKOrdinals;
            this.actualPKOrdinals = actualPKOrdinals;
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// Value Condition Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        public int Compare(IDataReader x, IDataReader y)
        {
            //Initialize result value.
            var result = 0;

            for (int i = 0; i < expectedPKOrdinals.Length; i++)
            {
                int xIndex = expectedPKOrdinals[i];
                int yIndex = actualPKOrdinals[i];

                object xValue = x.GetValue(xIndex);
                object yValue = y.GetValue(yIndex);

                Type t = x.GetFieldType(xIndex);

                // Check for nulls
                if (xValue == DBNull.Value)
                {
                    if (yValue == DBNull.Value)
                    {
                        // They're both null, so treat them as equal
                        result = 0;
                    }
                    else
                    {
                        // x (null) < y (not null)
                        result = -1;
                    }
                }
                else if (yValue == DBNull.Value)
                {
                    // Will only get here if xValue is not null...
                    // x (not null) > y (null)
                    result = 1;
                }
                else
                {
                    if (t == typeof(int))
                    {
                        int intX = (int) xValue;
                        int intY = (int) yValue;
                        result = intX.CompareTo(intY);
                    }
                    else if (t == typeof(long))
                    {
                        long guidX = (long) xValue;
                        long guidY = (long) yValue;
                        result = guidX.CompareTo(guidY);
                    }
                    else if (t == typeof(short))
                    {
                        short shortX = (short) xValue;
                        short shortY = (short) yValue;
                        result = shortX.CompareTo(shortY);
                    }
                    else if (t == typeof(string))
                    {
                        string stringX = (string) xValue;
                        string stringY = (string) yValue;
                        result = stringX.CompareTo(stringY);
                    }
                    else if (t == typeof(TimeSpan))
                    {
                        TimeSpan timeSpanX = (TimeSpan) xValue;
                        TimeSpan timeSpanY = (TimeSpan) yValue;
                        result = timeSpanX.CompareTo(timeSpanY);
                    }
                    else if (t == typeof(DateTime))
                    {
                        DateTime dateTimeX = (DateTime) xValue;
                        DateTime dateTimeY = (DateTime) yValue;
                        result = dateTimeX.CompareTo(dateTimeY);
                    }
                    else if (t == typeof(Guid))
                    {
                        Guid guidX = (Guid) xValue;
                        Guid guidY = (Guid) yValue;
                        result = guidX.CompareTo(guidY);
                    }
                    else
                    {
                        throw new NotSupportedException(
                            "Comparison of primary key values of type '" + t.Name + "' are not yet supported.");
                    }
                }

                // Exit the loop if we have a non-zero result
                if (result != 0)
                {
                    break;
                }
            }

            return result;
        }
    }
}
