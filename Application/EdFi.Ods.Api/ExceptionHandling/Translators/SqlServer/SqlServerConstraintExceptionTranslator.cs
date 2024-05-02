// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Exceptions;
using NHibernate.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class SqlServerConstraintExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        /* Sample errors:

         * Delete fails, single column child reference
         * -------------------------------------------
         * The DELETE statement conflicted with the REFERENCE constraint "FK_CourseTranscript_CourseAttemptResultType_CourseAttemptResultTypeId". The conflict occurred in database "EdFi_Ods", table "edfi.CourseTranscript", column 'CourseAttemptResultTypeId'.
        *  The statement has been terminated.

         * Delete fails, multiple column child reference
         * ---------------------------------------------
         * The DELETE statement conflicted with the REFERENCE constraint "FK_DisciplineAction_DisciplineIncident_SchoolId". The conflict occurred in database "EdFi_Ods", table "edfi.DisciplineAction".
         * The statement has been terminated.
         *
         * Insert fails, single column parent reference
         * --------------------------------------------
         * The INSERT statement conflicted with the FOREIGN KEY constraint "FK_StudentAddress_AddressType_AddressTypeId". The conflict occurred in database "EdFi_Ods", table "edfi.AddressType", column 'AddressTypeId'.
         * The statement has been terminated.

         * Update fails, single column parent reference
         * --------------------------------------------
         * The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Student_LimitedEnglishProficiencyType_LimitedEnglishProficiencyTypeId". The conflict occurred in database "EdFi_Ods", table "edfi.LimitedEnglishProficiencyType", column 'LimitedEnglishProficiencyTypeId'.
         * The statement has been terminated.
         *
         */

        private static readonly Regex _expression = new(
            @"^The (?<StatementType>INSERT|UPDATE|DELETE) statement conflicted with the (?<ConstraintType>FOREIGN KEY|REFERENCE) constraint ""(?<ConstraintName>\w+)"".*?table ""[a-z]+\.(?<TableName>\w+)""(?:, column '(?<ColumnName>\w+)')?");

        // ^The (?<Statement>INSERT|UPDATE|DELETE) statement conflicted with the (?<ConstraintType>FOREIGN KEY|REFERENCE) constraint "(?<ConstraintName>\w+)".*?table "[a-z]+\.(?<TableName>\w+)".*?(?: column '(?<ColumnName>\w+)')?
        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is SqlException)
            {
                // Is this a constraint violation message from SQL Server?
                var match = _expression.Match(exception.Message);

                if (match.Success)
                {
                    string statementType = match.Groups["StatementType"].Value;
                    string constraintType = match.Groups["ConstraintType"].Value;
                    string tableName = match.Groups["TableName"].Value;

                    switch (statementType)
                    {
                        case "INSERT":
                        case "UPDATE":

                            if (constraintType == "FOREIGN KEY")
                            {
                                problemDetails = new UnresolvedReferenceException(tableName);
                                return true;
                            }

                            break;
                        
                        case "DELETE":

                            if (constraintType == "REFERENCE")
                            {
                                problemDetails = new DependentResourceItemExistsException(tableName);
                                return true;
                            }

                            break;
                    }
                }
            }

            problemDetails = null;
            return false;
        }
    }
}
