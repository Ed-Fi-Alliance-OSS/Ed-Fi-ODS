// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using EdFi.Ods.CodeGen.Database.DatabaseSchema;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.CodeGen.Generators
{
    public class DatabaseMetadataProvider : GeneratorBase
    {
        private readonly IDatabaseSchemaProvider _databaseSchemaProvider;

        public DatabaseMetadataProvider(IDatabaseSchemaProvider databaseSchemaProvider)
        {
            _databaseSchemaProvider = databaseSchemaProvider;
        }

        protected override object Build()
        {
            var indicesForSchema = _databaseSchemaProvider
                .LoadIndices()
                .Where(i => TemplateContext.SchemaPhysicalName.Equals(i.SchemaOwner));

            return new
            {
                NamespaceName =
                    EdFiConventions.BuildNamespace(Namespaces.CodeGen.ExceptionHandling, TemplateContext.SchemaProperCaseName),
                IndexMetaData = indicesForSchema.Select(
                    index => new
                    {
                        Name = index.Name,
                        TableName = index.TableName,
                        ColumnNames = string.Join(", ", index.Columns.Select(c => $"\"{c.Name}\""))
                    })
            };
        }
    }
}
