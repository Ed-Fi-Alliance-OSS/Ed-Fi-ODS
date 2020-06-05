// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text.RegularExpressions;
using Npgsql;

namespace EdFi.Ods.Api.Common.ExceptionHandling.Translators.Postgres
{
    public enum PostgresExceptionConstraintType
    {
        Unknown,
        DuplicatedUniqueKey,
        InsertOrUpdateForeignKey,
        UpdateOrDeleteForeignKey
    }

    public class PostgresExceptionInfo
    {
        private const string UnknownValue = "unknown";

        public string TableName { get; }
        public string ColumnNames { get; }
        public string Values { get; }
        public PostgresExceptionConstraintType ConstraintType { get; }

        public bool IsComposedKeyConstraint => ColumnNames.Contains(",");

        private PostgresExceptionInfo()
        {
            TableName = UnknownValue;
            ColumnNames = UnknownValue;
            Values = UnknownValue;
            ConstraintType = PostgresExceptionConstraintType.Unknown;
        }

        public PostgresExceptionInfo(PostgresException exception, Regex detailExpression) : this()
        {
            if (!string.IsNullOrEmpty(exception.TableName))
            {
                TableName = exception.TableName;
            }

            if (!string.IsNullOrEmpty(exception.Detail))
            {
                var match = detailExpression.Match(exception.Detail);

                if (match.Success)
                {
                    string columns = match.Groups["KeyColumns"].Value;
                    string values = match.Groups["KeyValues"].Value;
                    string constraintType = match.Groups["ConstraintType"].Value;

                    if (!string.IsNullOrEmpty(columns))
                    {
                        ColumnNames = columns.Replace("\"", "");
                    }

                    if (!string.IsNullOrEmpty(values))
                    {
                        Values = values;
                    }

                    if (!string.IsNullOrEmpty(constraintType))
                    {
                        ConstraintType = GetConstrainType(constraintType);
                    }
                }
            }
        }

        private static PostgresExceptionConstraintType GetConstrainType(string constraintText)
        {
            switch (constraintText)
            {
                case "already exists":
                    return PostgresExceptionConstraintType.DuplicatedUniqueKey;
                case "not present in":
                    return PostgresExceptionConstraintType.InsertOrUpdateForeignKey;
                case "still referenced from":
                    return PostgresExceptionConstraintType.UpdateOrDeleteForeignKey;
                default:
                    return PostgresExceptionConstraintType.Unknown;
            }
        }
    }
}
