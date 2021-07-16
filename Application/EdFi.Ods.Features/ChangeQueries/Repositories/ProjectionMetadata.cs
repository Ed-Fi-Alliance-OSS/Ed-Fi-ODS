// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public class ProjectionMetadata
    {
        public string JsonPropertyName { get; set; }

        public SelectColumn[] SelectColumns { get; set; }

        public string ChangeTableJoinColumnName { get; set; }

        public string SourceTableJoinColumnName { get; set; }

        public bool IsDescriptorProperty { get; set; }
    }

    public class SelectColumn
    {
        public string ColumnName { get; set; }
        
        public string ColumnAlias { get; set; }
    }
}
