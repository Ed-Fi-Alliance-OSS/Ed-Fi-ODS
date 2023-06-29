﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntitiesForQueriesViews : GeneratorBase
    {
        private const object NotRendered = null;
        private readonly IAuthorizationDatabaseTableViewsProvider _authorizationDatabaseTableViewsProvider;
        private static IDatabaseTypeTranslator _databaseTypeTranslator;

        public EntitiesForQueriesViews(IAuthorizationDatabaseTableViewsProvider authorizationDatabaseTableViewsProvider,
            IDatabaseTypeTranslator databaseTypeTranslator)
        {
            Preconditions.ThrowIfNull(authorizationDatabaseTableViewsProvider, nameof(authorizationDatabaseTableViewsProvider));
            Preconditions.ThrowIfNull(databaseTypeTranslator, nameof(databaseTypeTranslator));
            _authorizationDatabaseTableViewsProvider = authorizationDatabaseTableViewsProvider;
            _databaseTypeTranslator = databaseTypeTranslator;
        }

        protected override object Build()
        {
            var aggregateRootWithCompositeKeyProperties = new[]
            {
                new
                {
                    Type = "Guid",
                    Name = "Id"
                },
                new
                {
                    Type = "DateTime",
                    Name = "LastModifiedDate"
                }
            };

            var views = _authorizationDatabaseTableViewsProvider.LoadViews();

            string GetCSharpNullSuffix(AuthorizationDatabaseColumn c)
                => c.Nullable && _databaseTypeTranslator.GetSysType(c.DbDataType) != "string"
                    ? "?"
                    : string.Empty;

            return new
            {
                Namespace = Namespaces.Entities.NHibernate.QueryModels.Views,
                Classes = views.Where(view => view.SchemaOwner.IsAuthSchema()).Select(
                    view => new
                    {
                        ClassName = view.Name.GetAuthorizationViewClassName(),
                        TableName = view.Name,
                        SchemaName = view.SchemaOwner,
                        Properties = view.Columns.OrderBy(c => c.Name).Select(
                            c => new
                            {
                                PropertyName = c.Name.ToMixedCase(),
                                CSharpDeclaredType = _databaseTypeTranslator.GetSysType(c.DbDataType) + GetCSharpNullSuffix(c),
                                NotInherited = !aggregateRootWithCompositeKeyProperties.Any(
                                    x => x.Name.EqualsIgnoreCase(c.Name) && x.Type == _databaseTypeTranslator.GetSysType(c.DbDataType))
                            })
                    })
            };
        }
    }
}
