// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Models.Templates;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntityOrmMappingsForTupleTable : GeneratorBase
    {
        private const string NotRendered = null;
        private readonly IDatabaseTypeTranslator _databaseTypeTranslator;
        private readonly ITupleTableProvider _tupleTableProvider;

        public EntityOrmMappingsForTupleTable(ITupleTableProvider tupleTableProvider,
            IDatabaseTypeTranslator databaseTypeTranslator)
        {
            Preconditions.ThrowIfNull(tupleTableProvider, nameof(tupleTableProvider));
            Preconditions.ThrowIfNull(databaseTypeTranslator, nameof(databaseTypeTranslator));

            _tupleTableProvider = tupleTableProvider;
            _databaseTypeTranslator = databaseTypeTranslator;
        }

        protected override object Build()
        {
            var tupleTable = _tupleTableProvider.LoadTupleTable();

            return
                new OrmMapping
                {
                    Namespace = Namespaces.Entities.NHibernate.QueryModels.Tables,
                    Assembly = TemplateContext.IsExtension
                        ? TemplateContext.SchemaProperCaseName
                        : Namespaces.Standard.BaseNamespace,
                    Aggregates = new List<OrmAggregate>
                    {
                        new OrmAggregate
                        {
                            Classes = new List<OrmClass>()
                                {
                                    new OrmClass()
                                    {
                                        ClassName = GetAuthorizationTableFullName(tupleTable.Name),
                                        TableName = tupleTable.Name,
                                        SchemaName = tupleTable.SchemaOwner,
                                        CompositeId = new OrmCompositeIdentity
                                        {
                                            KeyProperties = tupleTable.Columns
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
                                        Properties = tupleTable.Columns
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
                                }
                                .ToList()
                        }
                    }
                };
        }

        private static string GetAuthorizationTableFullName(string tableName)
        {
            return $"{Namespaces.Entities.NHibernate.QueryModels.Tables}.{tableName.GetAuthorizationTableClassName()}";
        }
    }
}
