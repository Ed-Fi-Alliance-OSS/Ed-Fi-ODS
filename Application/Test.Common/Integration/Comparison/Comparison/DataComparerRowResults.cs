// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Linq;
using System.Text;

namespace Test.Common.Integration.Comparison.Comparison
{
    public enum DataComparerRowDifference
    {
        RowMissing = 1,
        UnexpectedRow,
        ValuesDiffer
    }

    public class DataComparerRowResults
    {
        // Default constructor for XML Serialization
        public DataComparerRowResults() { }

        public DataComparerRowResults(DataComparerRowDifference difference)
        {
            Difference = difference;
        }

        public DataComparerRowDifference Difference { get; set; }

        public Hashtable KeyValues { get; set; } = new Hashtable();

        public Hashtable ExpectedValues { get; set; } = new Hashtable();

        public Hashtable ActualValues { get; set; } = new Hashtable();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Difference + ":");

            foreach (string key in KeyValues.Keys.OfType<string>()
                .ToList())
            {
                sb.AppendLine(string.Format("  {0} = \"{1}\"", key, KeyValues[key]));
            }

            if (Difference == DataComparerRowDifference.ValuesDiffer)
            {
                foreach (string key in ExpectedValues.Keys.OfType<string>()
                    .ToList())
                {
                    sb.AppendLine(
                        string.Format(
                            @"  {0} = 
    Expected: ""{1}""
    Actual:   ""{2}""
",
                            key,
                            ExpectedValues[key] ?? "[null]",
                            ActualValues[key] ?? "[null]"));
                }
            }
            else if (Difference == DataComparerRowDifference.RowMissing)
            {
                foreach (string key in ExpectedValues.Keys.OfType<string>()
                    .ToList())
                {
                    sb.AppendLine(string.Format("  {0} = \"{1}\"", key, ExpectedValues[key] ?? "[null]"));
                }
            }
            else if (Difference == DataComparerRowDifference.UnexpectedRow)
            {
                foreach (string key in ActualValues.Keys.OfType<string>()
                    .ToList())
                {
                    sb.AppendLine(string.Format("  {0} = \"{1}\"", key, ActualValues[key] ?? "[null]"));
                }
            }

            return sb.ToString();
        }
    }
}
