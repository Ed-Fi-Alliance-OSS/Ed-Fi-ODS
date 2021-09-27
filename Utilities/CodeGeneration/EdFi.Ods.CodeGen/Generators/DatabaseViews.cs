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
        private readonly IAuthorizationDatabaseTableViewsProvider _viewsProvider;

        public DatabaseViews(IAuthorizationDatabaseTableViewsProvider viewsProvider)
        {
            _viewsProvider = viewsProvider;
        }

        protected override object Build()
        {
            var views = _viewsProvider.LoadViews();

            return new {
                Views = JsonConvert.SerializeObject(views, Formatting.Indented , new JsonSerializerSettings
                        {  ReferenceLoopHandling = ReferenceLoopHandling.Ignore       })
                };
        }
    }
}
