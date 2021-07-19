// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public class TrackedKeyChangesQueryMetadata
    {
        public TrackedKeyChangesQueryMetadata(
            string changeTableSchema,
            string changeTableName,
            string selectClause,
            string keyChangesOnlyWhereClause,
            string discriminatorCriteria,
            string sourceBaseTableJoin,
            ProjectionMetadata[] identifierProjections)
        {
            ChangeTableSchema = changeTableSchema;
            ChangeTableName = changeTableName;
            SelectColumnsListSql = selectClause;
            KeyChangesOnlyWhereClause = keyChangesOnlyWhereClause;
            DiscriminatorCriteria = discriminatorCriteria;
            SourceBaseTableJoin = sourceBaseTableJoin;
            IdentifierProjections = identifierProjections;
        }

        public string ChangeTableSchema { get; }

        public string ChangeTableName { get; }

        public string SelectColumnsListSql { get; }

        public string KeyChangesOnlyWhereClause { get; }

        public string DiscriminatorCriteria { get; }

        public string SourceBaseTableJoin { get; }

        public ProjectionMetadata[] IdentifierProjections { get; }
    }
}
