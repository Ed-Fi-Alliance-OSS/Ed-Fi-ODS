// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public class QueryProjection
    {
        public string JsonPropertyName { get; set; }

        public SelectColumn[] SelectColumns { get; set; }

        public string ChangeTableJoinColumnName { get; set; }

        public string SourceTableJoinColumnName { get; set; }

        public bool IsDescriptorUsage { get; set; }
    }

    public class SelectColumn
    {
        public string ColumnName { get; set; }
        
        public string JsonPropertyName { get; set; }

        /// <summary>
        /// Indicates whether the column represents an old or new value.
        /// </summary>
        public ColumnGroups ColumnGroup { get; set; }
    }

    [Flags]
    public enum ColumnGroups
    {
        OldValue = 1,
        NewValue = 2,
    }
}
