// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Database.Querying
{
    public class SqlResult
    {
        public SqlResult(SqlBuilder.Template template)
        {
            Template = template;
        }
        
        public SqlBuilder.Template Template { get; }

        public string Sql => Template.RawSql;
    }
}
