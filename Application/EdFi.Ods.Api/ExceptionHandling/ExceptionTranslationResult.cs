// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.ExceptionHandling
{
    public class ReferentialConstraintViolationExceptionTranslationResult : ExceptionTranslationResult
    {
        public ReferentialConstraintViolationExceptionTranslationResult(
            string constraintName,
            string databaseName,
            string referencedTableName,
            string columnName,
            RESTError error,
            Exception originalException)
            : base(error, originalException)
        {
            ConstraintName = constraintName;
            DatabaseName = databaseName;
            ReferencedTableName = referencedTableName;
            ColumnName = columnName;
        }
    
        public string ConstraintName { get; }
    
        public string DatabaseName { get; }
    
        public string ReferencedTableName { get; }
    
        public string ColumnName { get; }
    }
    
    // public class DescriptorViolationExceptionTranslationResult : ExceptionTranslationResult
    // {
    //     public DescriptorViolationExceptionTranslationResult(
    //         string constraintName,
    //         string databaseName,
    //         string tableName,
    //         string columnName,
    //         RESTError error,
    //         Exception originalException)
    //         : base(error, originalException)
    //     {
    //         ConstraintName = constraintName;
    //         DatabaseName = databaseName;
    //         TableName = tableName;
    //         ColumnName = columnName;
    //     }
    //
    //     public string ConstraintName { get; }
    //
    //     public string DatabaseName { get; }
    //
    //     public string TableName { get; }
    //
    //     public string ColumnName { get; }
    // }
}
