// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Linq;

namespace EdFi.Ods.Common.Models.Domain
{
    public static class PropertyTypeExtensions
    {
        private static readonly string[] _notNullableTypes =
        {
            "string", "byte[]"
        };

        // For referenced type mapping documentation: 
        // https://msdn.microsoft.com/en-us/library/cc716729(v=vs.110).aspx

        public static string ToCSharp(this PropertyType propertyType, bool includeNullability = false)
        {
            // Note: Comments with corresponding .NET types are left in-line for possible future implementation.
            string csharpType = null;

            switch (propertyType.DbType)
            {
                case DbType.Int64: // bigint
                    csharpType = "long";

                    //dotNetType = "Int64";
                    break;

                case DbType.Byte: // tinyint
                    csharpType = "byte";

                    //dotNetType = "Byte";
                    break;

                case DbType.Int16: // smallint
                    csharpType = "short";

                    //dotNetType = "Int16";
                    break;

                case DbType.Int32: // int
                    csharpType = "int";

                    //dotNetType = "Int32";
                    break;

                case DbType.Guid: // uniqueidentifier
                    csharpType = "Guid";

                    //dotNetType = "Guid";
                    break;

                case DbType.Date: // date
                case DbType.DateTime: // smalldatetime, datetime
                case DbType.DateTime2:
                    csharpType = "DateTime";

                    //dotNetType = "DateTime";
                    break;

                case DbType.Double: //float
                    csharpType = "double";

                    //dotNetType = "Double";
                    break;

                case DbType.Single: // real

                    //dotNetType = "single";
                    //dotNetType = "Single";
                    break;

                case DbType.Currency:
                case DbType.Decimal: // numeric, smallmoney, decimal, money
                    csharpType = "decimal";

                    //dotNetType = "Decimal";
                    break;

                case DbType.Boolean:
                    csharpType = "bool";

                    //dotNetType = "Boolean";
                    break;

                case DbType.Binary: // image, binary, varbinary, rowversion, timestamp
                    csharpType = "byte[]";

                    //dotNetType = "Byte[]";
                    break;

                case DbType.Time: // time
                    csharpType = "TimeSpan";

                    //dotNetType = "Timespan";
                    break;

                case DbType.AnsiString: // varchar
                case DbType.String: // char, nvarchar, ntext, text
                case DbType.AnsiStringFixedLength: // char
                case DbType.StringFixedLength: // nchar
                    csharpType = "string";

                    //dotNetType = "String";

                    break;

                case DbType.DateTimeOffset:
                    csharpType = "DateTimeOffset";

                    //dotNetType = "DateTimeOffset";

                    break;

                default:

                    throw new NotSupportedException(
                        string.Format(
                            "CSharp type mapping from 'DbType.{0}' is not supported.",
                            propertyType.DbType));
            }

            return csharpType + (includeNullability && propertyType.IsNullableCSharpType()
                       ? "?"
                       : string.Empty);
        }

        /// <summary>
        /// Indicates whether the supplies property type is represented by a string.
        /// </summary>
        /// <param name="propertyType">The property type to be evaluated.</param>
        /// <returns><b>true</b> if the property represents a string; otherwise <b>false</b>.</returns>
        public static bool IsString(this PropertyType propertyType)
        {
            switch (propertyType.DbType)
            {
                case DbType.AnsiString: // varchar
                case DbType.String: // char, nvarchar, ntext, text
                case DbType.AnsiStringFixedLength: // char
                case DbType.StringFixedLength: // nchar
                    return true;
                
                default:
                    return false;
            }
        }
        
        /// <summary>
        /// Determines if the CSharp type is a nullable type.
        /// </summary>
        /// <param name="propertyType"></param>
        /// <returns></returns>
        public static bool IsNullableCSharpType(this PropertyType propertyType)
        {
            if (!propertyType.IsNullable)
            {
                return false;
            }

            return !_notNullableTypes.Contains(propertyType.ToCSharp());
        }

        /// <summary>
        /// Converts the provided <see cref="PropertyType"/> to the non-nullable (underlying, if necessary) <see cref="System.Type"/>, even if the property is nullable.
        /// </summary>
        /// <param name="propertyType">The <see cref="PropertyType"/> whose non-nullable (underlying, if necessary) <see cref="System.Type"/> is to be obtained.</param>
        /// <returns>The non-nullable (underlying, if necessary) <see cref="System.Type"/>.</returns>
        public static Type ToUnderlyingSystemType(this PropertyType propertyType)
        {
            return ToSystemType(propertyType, allowNullable: false);
        }

        /// <summary>
        /// Converts the provided <see cref="PropertyType"/> to the corresponding <see cref="System.Type"/>, incorporating the property's nullability.
        /// </summary>
        /// <param name="propertyType">The <see cref="PropertyType"/> whose corresponding <see cref="System.Type"/> is to be obtained.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        public static Type ToSystemType(this PropertyType propertyType)
        {
            return ToSystemType(propertyType, allowNullable: true);
        }

        private static Type ToSystemType(PropertyType propertyType, bool allowNullable)
        {
            // Note: Comments with corresponding .NET types are left inline for possible future implementation.
            Type systemType = null;

            switch (propertyType.DbType)
            {
                case DbType.Int64: // bigint
                    systemType = allowNullable && propertyType.IsNullable ? typeof(long?) : typeof(long);
                    break;

                case DbType.Byte: // tinyint
                    systemType = allowNullable && propertyType.IsNullable ? typeof(byte?) : typeof(byte);
                    break;

                case DbType.Int16: // smallint
                    systemType = allowNullable && propertyType.IsNullable ? typeof(short?) : typeof(short);
                    break;

                case DbType.Int32: // int
                    systemType = allowNullable && propertyType.IsNullable ? typeof(int?) : typeof(int);
                    break;

                case DbType.Guid: // uniqueidentifier
                    systemType = allowNullable && propertyType.IsNullable ? typeof(Guid?) : typeof(Guid);
                    break;

                case DbType.Date: // date
                case DbType.DateTime: // smalldatetime, datetime
                case DbType.DateTime2:
                    systemType = allowNullable && propertyType.IsNullable ? typeof(DateTime?) : typeof(DateTime);
                    break;

                case DbType.Double: //float
                    systemType = allowNullable && propertyType.IsNullable ? typeof(double?) : typeof(double);
                    break;

                case DbType.Single: // real
                    systemType = allowNullable && propertyType.IsNullable ? typeof(float?) : typeof(float);
                    break;

                case DbType.Currency: // smallmoney, money
                case DbType.Decimal: // numeric, decimal
                    systemType = allowNullable && propertyType.IsNullable ? typeof(decimal?) : typeof(decimal);
                    break;

                case DbType.Boolean:
                    systemType = allowNullable && propertyType.IsNullable ? typeof(bool?) : typeof(bool);
                    break;

                case DbType.Binary: // image, binary, varbinary, rowversion, timestamp
                    systemType = typeof(byte[]);
                    break;

                case DbType.Time: // time
                    systemType = allowNullable && propertyType.IsNullable ? typeof(TimeSpan?) : typeof(TimeSpan);
                    break;

                case DbType.AnsiString: // varchar
                case DbType.String: // char, nvarchar, ntext, text
                case DbType.AnsiStringFixedLength: // char
                case DbType.StringFixedLength: // nchar
                    systemType = typeof(string);
                    break;

                case DbType.DateTimeOffset:
                    systemType = allowNullable && propertyType.IsNullable ? typeof(DateTimeOffset?) : typeof(DateTimeOffset);
                    break;

                default:

                    throw new NotSupportedException(
                        string.Format(
                            "System type mapping from 'DbType.{0}' is not supported.",
                            propertyType.DbType));
            }

            return systemType;
        }

        public static string ToOpenApiType(this PropertyType type)
        {
            string cSharpType = type.ToCSharp();

            switch (cSharpType)
            {
                case "string":
                case "DateTime":
                case "TimeSpan":
                case "Guid":
                    return "string";
                case "bool":
                    return "boolean";
                case "short":
                case "int":
                case "long":
                    return "integer";
                case "float":
                case "double":
                case "decimal":
                    return "number";
                default:
                    throw new Exception(string.Format("Unhandled .NET data type to Swagger conversion: '{0}'.", cSharpType));
            }
        }

        public static string ToOpenApiFormat(this PropertyType type)
        {
            string cSharpType = type.ToCSharp();

            switch (cSharpType)
            {
                case "string":
                case "bool":
                case "TimeSpan":
                case "Guid":
                    return null;
                case "short":
                case "int":
                    return "int32";
                case "long":
                    return "int64";
                case "float":
                    return "float";
                case "double":
                case "decimal":
                    return "double";
                case "DateTime":
                    return type.DbType == DbType.Date ? "date" : "date-time";
                default:
                    throw new Exception(string.Format("Unhandled .NET data type to Swagger conversion: '{0}'.", cSharpType));
            }
        }

        public static string ToNHibernateType(this PropertyType propertyType)
        {
            switch (propertyType.DbType)
            {
                case DbType.AnsiString:
                    return "AnsiString";

                case DbType.AnsiStringFixedLength:
                    return "char";

                case DbType.Binary:
                    return "byte[]"; // Is this right? Should it be "binary"?

                case DbType.Boolean:
                    return "bool";
                
                case DbType.Byte:
                    return "byte";

                case DbType.Currency:
                    return "Currency";
                
                case DbType.Date:
                    return "date";

                case DbType.DateTime:
                    return "timestamp"; // Should we use DateTime?

                case DbType.DateTime2:
                    return "UtcDateTime";

                case DbType.DateTimeOffset:
                    return "datetimeoffset";
                
                case DbType.Decimal:
                    return "decimal";
                
                case DbType.Double:
                    return "double";

                case DbType.Guid:
                    return "Guid";

                case DbType.Int16:
                    return "short";

                case DbType.Int32:
                    return "int";

                case DbType.Int64:
                    return "long";

                case DbType.Single:
                    return "single";

                case DbType.String:
                    return "string";

                case DbType.StringFixedLength:
                    return "char";

                case DbType.Time:
                    return "TimeAsTimeSpan";

                default:
                    throw new NotSupportedException($"NHibernate type mapping from DbType '{propertyType.DbType}' is not supported.");
            }
        }
    }
}
