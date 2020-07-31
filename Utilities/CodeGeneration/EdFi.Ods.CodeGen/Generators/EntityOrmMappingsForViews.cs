// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Models.Templates;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityOrmMappingsForViews : GeneratorBase
    {
        private const string NotRendered = null;
        private readonly IViewsProvider _viewsProvider;
        private readonly IDatabaseTypeTranslator _databaseTypeTranslator;

        public EntityOrmMappingsForViews(IViewsProvider viewsProvider, IDatabaseTypeTranslator databaseTypeTranslator)
        {
            Preconditions.ThrowIfNull(viewsProvider, nameof(viewsProvider));
            Preconditions.ThrowIfNull(databaseTypeTranslator, nameof(databaseTypeTranslator));

            _viewsProvider = viewsProvider;
            _databaseTypeTranslator = databaseTypeTranslator;
        }

        protected override object Build()
        {
            var views = _viewsProvider.LoadViews();

            return
                new OrmMapping
                {
                    Namespace = Namespaces.Entities.NHibernate.QueryModels.Views,
                    Assembly = TemplateContext.IsExtension
                        ? TemplateContext.SchemaProperCaseName
                        : Namespaces.Standard.BaseNamespace,
                    Aggregates = new List<OrmAggregate>
                    {
                        new OrmAggregate{
                        Classes = views
                            .Where(view => view.SchemaOwner.IsAuthSchema())
                            .Select(
                                view =>
                                    new OrmClass
                                    {
                                        ClassName = GetAuthorizationViewFullName(view.Name),
                                        TableName = view.Name,
                                        SchemaName = view.SchemaOwner,
                                        CompositeId = new OrmCompositeIdentity
                                        {
                                            KeyProperties = view.Columns
                                                .OrderBy(c => c.Name)
                                                .Select(
                                                    c => new OrmProperty
                                                    {
                                                        PropertyName = c.Name,
                                                        ColumnName = c.Name,
                                                        NHibernateTypeName = _databaseTypeTranslator.GetNHType(c.DbDataType),
                                                        MaxLength = c.Length > 0
                                                            ? c.Length.ToString()
                                                            : NotRendered
                                                    })
                                                .ToList()
                                        },
                                        Properties = view.Columns
                                            .OrderBy(c => c.Name)
                                            .Select(
                                                c => new NHibernatePropertyDefinition()
                                                {
                                                    PropertyName = c.Name,
                                                    ColumnName = c.Name,
                                                    NHibernateTypeName = _databaseTypeTranslator.GetNHType(c.DbDataType),
                                                    MaxLength = c.Length > 0
                                                        ? c.Length.ToString()
                                                        : NotRendered,
                                                    IsNullable = c.Nullable,
                                                    IsReadOnly = true
                                                })
                                            .ToList()
                                    }
                            )
                            .ToList()
                    }}
                };
        }

        private static string GetAuthorizationViewFullName(string viewName)
        {
            return $"{Namespaces.Entities.NHibernate.QueryModels.Views}.{viewName.GetAuthorizationViewClassName()}";
        }
    }
}
