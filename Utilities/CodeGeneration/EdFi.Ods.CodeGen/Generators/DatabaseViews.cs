﻿// SPDX-License-Identifier: Apache-2.0
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

            return new {Views = JsonConvert.SerializeObject(views, Formatting.Indented ,
                new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore})};
        }
    }
}
