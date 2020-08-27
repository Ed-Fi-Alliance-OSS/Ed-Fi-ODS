// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.ChangeQueries.SqlServer
{
    public class ChangeQueriesDatabaseConstants
    {
        /// <summary>
        /// Gets the database schema name for the Change Events table.
        /// </summary>
        public const string SchemaName = "changes";

        /// <summary>
        /// Gets the logical schema name for Change Events.
        /// </summary>
        public const string LogicalSchemaName = "ChangeQueries";

        /// <summary>
        /// Gets the column name used for tracking changed records
        /// </summary>
        public const string ChangeVersionColumnName = "ChangeVersion";

        /// <summary>
        /// Prefix applied to the schema name holding the tracked delete tables for a data standard schema.
        /// </summary>
        public const string TrackedDeletesSchemaPrefix = "Tracked_Deletes_";
    }
}
