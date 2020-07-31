// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    public class DatabaseTypeTranslator : IDatabaseTypeTranslator
    {
        public string GetSysType(string sqlType)
        {
            switch (sqlType)
            {
                case "int2":
                case "smallint":
                case "tinyint":
                    return "short";
                case "int":
                case "int4":
                case "integer":
                case "serial":
                case "serial4":
                    return "int";
                case "bigint":
                case "bigserial":
                case "bit varying":
                case "int8":
                case "serial8":
                case "varbit":
                    return "long";
                case "uniqueidentifier":
                case "uuid":
                    return "Guid";
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                case "timestamp":
                case "timestamptz":
                    return "DateTime";
                case "float":
                case "double precision":
                case "double":
                case "float8":
                    return "double";
                case "real":
                case "numeric":
                case "smallmoney":
                case "decimal":
                case "money":
                    return "decimal";
                case "bit":
                case "bool":
                case "boolean":
                    return "bool";
                case "image":
                case "binary":
                case "varbinary":
                case "bytea":
                    return "byte[]";
                case "time":
                case "interval":
                case "timetz":
                    return "TimeSpan";
                case "text":
                case "ntext":
                case "varchar":
                case "nvarchar":
                case "bpchar":
                case "char":
                case "character varying":
                case "character":
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
                case "int2":
                case "smallint":
                case "tinyint":
                    return "short";
                case "int":
                case "int4":
                case "integer":
                case "serial":
                case "serial4":
                    return "int";
                case "bigint":
                case "bigserial":
                case "bit varying":
                case "int8":
                case "serial8":
                case "varbit":
                    return "long";
                case "uniqueidentifier":
                case "uuid":
                    return "Guid";
                case "datetimeoffset":
                    return "datetimeoffset";
                case "smalldatetime":
                case "datetime":
                case "timestamp":
                case "timestamptz":
                    return "timestamp"; //"datetime";
                case "datetime2":
                    return "UtcDateTime";
                case "date":
                    return "date";
                case "float":
                case "double precision":
                case "double":
                case "float8":
                    return "double";
                case "real":
                case "numeric":
                case "smallmoney":
                case "decimal":
                case "money":
                    return "decimal";
                case "bit":
                case "bool":
                case "boolean":
                    return "bool";
                case "image":
                case "binary":
                case "varbinary":
                case "bytea":
                    return "byte[]";
                case "time":
                case "interval":
                case "timetz":
                    return "TimeAsTimeSpan";
                case "text":
                case "varchar":
                    return "AnsiString";
                case "ntext":
                case "bpchar":
                case "char":
                case "nvarchar":
                case "character varying":
                case "character":
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
                case "int2":
                case "smallint":
                    return DbType.Int16;
                case "int":
                case "int4":
                case "integer":
                case "serial":
                case "serial4":
                    return DbType.Int32;
                case "bigint":
                case "bigserial":
                case "bit varying":
                case "int8":
                case "serial8":
                case "varbit":
                    return DbType.Int64;
                case "uniqueidentifier":
                case "uuid":
                    return DbType.Guid;
                case "datetime":
                    return DbType.DateTime;
                case "datetime2":
                    return DbType.DateTime2;
                case "time":
                    return DbType.Time;
                case "date":
                    return DbType.Date;
                case "binary":
                    return DbType.Binary;
                case "bit":
                case "bool":
                case "boolean":
                    return DbType.Boolean;
                case "decimal":
                    return DbType.Decimal;
                case "float":
                case "double precision":
                case "double":
                case "float8":
                    return DbType.Double;
                case "image":
                    return DbType.Binary;
                case "money":
                    return DbType.Currency;
                case "char":
                    return DbType.AnsiStringFixedLength;
                case "sql_variant":
                case "sysname":
                case "nvarchar":
                case "ntext":
                case "bpchar":
                case "character varying":
                case "character":
                case "line":
                case "nchar":
                    return DbType.String;
                case "text":
                case "varchar":
                    return DbType.AnsiString;
                case "numeric":
                    return DbType.Decimal;
                case "real":
                    return DbType.Single;
                case "smalldatetime":
                    return DbType.DateTime;
                case "smallmoney":
                    return DbType.Currency;
                case "timestamp":
                case "timestamptz":
                    return DbType.Binary;
                case "tinyint":
                    return DbType.Byte;
                case "varbinary":
                    return DbType.Binary;
                case "xml":
                    return DbType.Xml;
                default:
                    throw new NotSupportedException($"DbType mapping from database type '{sqlType}' is not supported.");
            }
        }
    }
}
