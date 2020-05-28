// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using DatabaseSchemaReader.DataSchema;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntitiesForQueriesViews : GeneratorBase
    {
        private const object NotRendered = null;
        private readonly IViewsProvider _viewsProvider;
        private static IDatabaseTypeTranslator _databaseTypeTranslator;

        public EntitiesForQueriesViews(IViewsProvider viewsProvider,
            IDatabaseTypeTranslator databaseTypeTranslator)
        {
            Preconditions.ThrowIfNull(viewsProvider, nameof(viewsProvider));
            Preconditions.ThrowIfNull(databaseTypeTranslator, nameof(databaseTypeTranslator));
            _viewsProvider = viewsProvider;
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

            var views = _viewsProvider.LoadViews();

            string GetCSharpNullSuffix(DatabaseColumn c)
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
