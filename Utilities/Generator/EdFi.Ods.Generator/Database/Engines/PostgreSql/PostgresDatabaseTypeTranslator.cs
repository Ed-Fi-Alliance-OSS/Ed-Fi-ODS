// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.DataTypes;

namespace EdFi.Ods.Generator.Database.Engines.PostgreSql
{
    public class PostgresDatabaseTypeTranslator : IDatabaseTypeTranslator
    {
        public string GetSysType(string sqlType)
        {
            switch (sqlType)
            {
                case "smallint":
                case "int2":
                case "smallserial":
                case "serial2":
                    return "short";

                case "int":
                case "integer":
                case "int4":
                case "serial":
                case "serial4":
                    return "int";

                case "bigint":
                case "int8":
                case "bigserial":
                case "serial8":
                case "bit varying":
                case "varbit":
                    return "long";

                case "uuid":
                    return "Guid";

                case "date":
                case "timestamp":
                case "timestamptz":
                    return "DateTime";

                case "time":
                case "timetz":
                case "interval":
                    return "TimeSpan";

                case "double precision":
                case "float8":
                    return "double";

                case "real":
                case "float4":
                case "numeric":
                case "decimal":
                case "money":
                    return "decimal";

                case "bool":
                case "boolean":
                    return "bool";

                case "bytea":
                    return "byte[]";

                case "text":
                case "varchar":
                case "character varying":
                case "char":
                case "character":
                case "bpchar":
                case "line":
                    return "string";

                default:
                    throw new NotSupportedException($".NET system type mapping from database type '{sqlType}' is not supported.");
            }
        }

        public string GetNHType(string sqlType)
        {
            switch (sqlType)
            {
                case "smallint":
                case "int2":
                case "serial2":
                case "smallserial":
                    return "short";

                case "int":
                case "integer":
                case "int4":
                case "serial":
                case "serial4":
                    return "int";

                case "bigint":
                case "int8":
                case "bigserial":
                case "serial8":
                case "bit varying":
                case "varbit":
                    return "long";

                case "uuid":
                    return "Guid";

                case "date":
                    return "date";

                case "timestamp":
                    return "timestamp";
                    // Should we consider changing this to "DateTime"?
                    // See: https://nhibernate.jira.com/browse/NH-2520?focusedCommentId=55412

                case "timestamptz":
                    return "UtcDateTime";

                case "time":
                case "timetz":
                case "interval":
                    return "TimeAsTimeSpan";

                case "double precision":
                case "float8":
                    return "double";

                case "real":
                case "float4":
                case "numeric":
                case "decimal":
                    return "decimal";

                case "money":
                    return "Currency";

                case "bool":
                case "boolean":
                    return "bool";

                case "bytea":
                    return "byte[]"; // Should this really be "BinaryBlob"?

                case "char":
                case "character":
                case "varchar":
                case "character varying":
                case "bpchar":
                case "line":
                    return "string";

                default:
                    throw new NotSupportedException($"NHibernate type mapping from database type '{sqlType}' is not supported.");
            }
        }

        public DbType GetDbType(string sqlType)
        {
            switch (sqlType)
            {
                case "smallint":
                case "int2":
                case "smallserial":
                case "serial2":
                    return DbType.Int16;

                case "int":
                case "integer":
                case "int4":
                case "serial":
                case "serial4":
                    return DbType.Int32;

                case "bigint":
                case "int8":
                case "bigserial":
                case "serial8":
                case "bit varying":
                case "varbit":
                    return DbType.Int64;

                case "uuid":
                    return DbType.Guid;

                case "date":
                    return DbType.Date;

                case "timestamp":
                case "timestamptz":
                    return DbType.Binary; // This seems wrong -- DbType.DateTime?

                case "time":
                case "timetz":
                case "interval":
                    return DbType.Time;

                case "double precision":
                case "float8":
                    return DbType.Double;

                case "real":
                case "float4":
                    return DbType.Single;

                case "decimal":
                case "numeric":
                    return DbType.Decimal;

                case "money":
                    return DbType.Currency;

                case "bool":
                case "boolean":
                    return DbType.Boolean;

                case "bytea":
                    return DbType.Binary;

                case "text":
                case "varchar":
                case "character varying":
                case "line":
                case "bpchar":
                    return DbType.String;

                case "char":
                case "character":
                    return DbType.AnsiStringFixedLength;

                case "xml":
                    return DbType.Xml;

                default:
                    throw new NotSupportedException($"DbType mapping from PostgreSQL type '{sqlType}' is not supported.");
            }
        }

        public string GetSqlType(PropertyType propertyType) => throw new NotImplementedException();
    }
}
