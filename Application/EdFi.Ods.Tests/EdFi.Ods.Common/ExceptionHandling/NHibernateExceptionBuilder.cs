// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Reflection;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.ExceptionHandling
{
    public static class NHibernateExceptionBuilder
    {
        private static ConstructorInfo _sqlExceptionConstructor;

        public static GenericADOException CreateException(string nHibernateMessage, string sqlMessage)
            => new GenericADOException(nHibernateMessage, CreateSqlServerException(sqlMessage, null));

        public static GenericADOException CreatePostgresException(string nHibernateMessage, string sqlMessage)
            => new GenericADOException(nHibernateMessage, CreatePostgresException(sqlMessage));

        private static SqlException CreateSqlServerException(string message, Exception innerException)
        {
            var exception = GetSqlServerExceptionConstructor()
                .Invoke(
                    new object[]
                    {
                        message,
                        null,
                        innerException,
                        default(Guid)
                    });

            return (SqlException) exception;
        }

        private static ConstructorInfo GetSqlServerExceptionConstructor()
        {
            if (_sqlExceptionConstructor == null)
            {
                var constructorTypes = new[]
                {
                    typeof(string),
                    typeof(SqlErrorCollection),
                    typeof(Exception),
                    typeof(Guid)
                };

                _sqlExceptionConstructor = typeof(SqlException).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    constructorTypes,
                    null);
            }

            return _sqlExceptionConstructor;
        }

        private static PostgresException CreatePostgresException(string message)
            => new PostgresException(message, null, null, "23505");
    }
}
