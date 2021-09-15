// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using DatabaseSchemaReader.DataSchema;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.CodeGen.Generators
{
    public class EntitiesForQueriesTupleTable : GeneratorBase
    {
        private const object NotRendered = null;
        private static IDatabaseTypeTranslator _databaseTypeTranslator;
        private readonly ITupleTableProvider _tupleTableProvider;

        public EntitiesForQueriesTupleTable(ITupleTableProvider tupleTableProvider,
            IDatabaseTypeTranslator databaseTypeTranslator)
        {
            Preconditions.ThrowIfNull(tupleTableProvider, nameof(tupleTableProvider));
            Preconditions.ThrowIfNull(databaseTypeTranslator, nameof(databaseTypeTranslator));
            _tupleTableProvider = tupleTableProvider;
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

            var tupleTable = _tupleTableProvider.LoadTupleTable();

            string GetCSharpNullSuffix(DatabaseColumn c)
                => c.Nullable && _databaseTypeTranslator.GetSysType(c.DbDataType) != "string"
                    ? "?"
                    : string.Empty;

            return new
            {
                Namespace = Namespaces.Entities.NHibernate.QueryModels.Tables,
                Classes = new
                {
                    ClassName = tupleTable.Name.GetAuthorizationViewClassName(),
                    TableName = tupleTable.Name,
                    SchemaName = tupleTable.SchemaOwner,
                    Properties = tupleTable.Columns.OrderBy(c => c.Name).Select(
                        c => new
                        {
                            PropertyName = c.Name.ToMixedCase(),
                            CSharpDeclaredType = _databaseTypeTranslator.GetSysType(c.DbDataType) + GetCSharpNullSuffix(c),
                            NotInherited = !aggregateRootWithCompositeKeyProperties.Any(
                                x => x.Name.EqualsIgnoreCase(c.Name) &&
                                     x.Type == _databaseTypeTranslator.GetSysType(c.DbDataType))
                        })
                }
            };
        }
    }
}
