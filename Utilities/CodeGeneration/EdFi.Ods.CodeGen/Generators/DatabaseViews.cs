// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.CodeGen.Providers;
using Newtonsoft.Json;

namespace EdFi.Ods.CodeGen.Generators
{
    public class DatabaseViews : GeneratorBase
    {
        private readonly IAuthorizationDatabaseTableViewsProvider _authorizationDatabaseTableViewsProvider;

        public DatabaseViews(IAuthorizationDatabaseTableViewsProvider authorizationDatabaseTableViewsProvider)
        {
            _authorizationDatabaseTableViewsProvider = authorizationDatabaseTableViewsProvider;
        }

        protected override object Build()
        {
            var views = _authorizationDatabaseTableViewsProvider.LoadViews().Select(
                v => new
                {
                    SchemaOwner = v.SchemaOwner,
                    Name = v.Name,
                    Columns = v.Columns.Select(
                        c => new
                        {
                            Name = c.Name,
                            DbDataType = c.DbDataType,
                            IsPrimaryKey = c.IsPrimaryKey,
                            Length = c.Length,
                            Precision = c.Precision,
                            Scale = c.Scale,
                            Nullable = c.Nullable
                        }),
                });

            string json = JsonConvert.SerializeObject(
                views,
                Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore,  });

            // Stubble produces all line endings in the processing of the mustache templates as LF (even on Windows),
            // and appends a blank line at the end of the file as well (so removing the extra CRLF from our DatabaseViews
            // template won't help). We need the line endings in the JSON to be LFs rather than CRLFs (as produced by
            // JSON.NET) to prevent issues around committing files with mixed-mode line endings.
            return new {Views = json.ReplaceLineEndings("\n")};
        }
    }
}
