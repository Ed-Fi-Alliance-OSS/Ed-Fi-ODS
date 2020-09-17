// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;

namespace EdFi.Ods.CodeGen.Database.DatabaseSchema
{
    /// <summary>
    /// Defines methods for converting from database physical data types to various code generation output formats
    /// for artifacts based on database views.
    /// </summary>
    public interface IDatabaseTypeTranslator
    {
        /// <summary>
        /// Gets the C# .NET type associated with the supplied database data type.
        /// </summary>
        /// <param name="sqlType">The raw data type used by the reference database.</param>
        /// <returns>The corresponding C# .NET type.</returns>
        /// <remarks>This supports the code generation process for database views read by the DatabaseSchemaReader library which
        /// only provides the data type from the data view in the reference database.
        /// </remarks>
        string GetSysType(string sqlType);

        /// <summary>
        /// Gets the NHibernate mapping type associated with the supplied database data type.
        /// </summary>
        /// <param name="sqlType">The raw data type used by the reference database.</param>
        /// <returns>The corresponding NHibernate mapping type.</returns>
        /// <remarks>This supports the code generation process for database views read by the DatabaseSchemaReader library which
        /// only provides the data type from the data view in the reference database.
        /// </remarks>
        string GetNHType(string sqlType);

        /// <summary>
        /// Gets the <see cref="DbType" /> enumeration value associated with the supplied database data type.
        /// </summary>
        /// <param name="sqlType">The raw data type used by the reference database.</param>
        /// <returns>The corresponding <see cref="DbType" /> enumeration value.</returns>
        DbType GetDbType(string sqlType);
    }
}
