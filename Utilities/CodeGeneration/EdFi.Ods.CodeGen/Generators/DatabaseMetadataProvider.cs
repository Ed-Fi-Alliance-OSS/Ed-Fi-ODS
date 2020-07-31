// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.CodeGen.Models.Templates;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.CodeGen.Generators
{
    public class DatabaseMetadataProvider : GeneratorBase
    {
        protected override object Build()
        {
            string ColumnNamesFor(IEnumerable<string> columnNames) => string.Join(", ", columnNames.Select(c => $@"""{c}"""));

            bool EntityInSchema(Entity e) => TemplateContext.SchemaPhysicalName.Equals(e.FullName.Schema);

            bool AssociationInSchema(Association a) => TemplateContext.SchemaPhysicalName.Equals(a.FullName.Schema);

            bool AssociationIsNotOneToOne(Association a)
                => a.Cardinality != Cardinality.OneToOne
                   && a.Cardinality != Cardinality.OneToOneInheritance
                   && a.Cardinality != Cardinality.OneToOneExtension;

            DatabaseMetadata DatabaseMetadataForEntity(Entity e)
                => new DatabaseMetadata
                {
                    Name = e.Identifier.Name,
                    TableName = e.Name,
                    ColumnNames = ColumnNamesFor(e.Identifier.Properties.Select(p => p.PropertyName)),
                };

            IEnumerable<DatabaseMetadata> DatabaseMetadataForAlternativeIdentities(Entity e)
                => e.AlternateIdentifiers.Select(
                    ai => new DatabaseMetadata
                    {
                        Name = ai.Name,
                        TableName = e.Name,
                        ColumnNames = ColumnNamesFor(ai.Properties.Select(p => p.PropertyName)),
                    });

            DatabaseMetadata DatabaseMetadataForAssociation(Association a)
                => new DatabaseMetadata
                {
                    Name = a.FullName.Name,
                    TableName = a.SecondaryEntity.Name,
                    ColumnNames = ColumnNamesFor(a.SecondaryEntityAssociationProperties.Select(p => p.PropertyName)),
                };

            var databaseMetadata = new List<DatabaseMetadata>();

            var domainModel = TemplateContext.DomainModelProvider.GetDomainModel();

            databaseMetadata.AddRange(
                domainModel.Entities
                    .Where(EntityInSchema)
                    .Select(DatabaseMetadataForEntity));

            databaseMetadata.AddRange(
                domainModel.Entities
                    .Where(EntityInSchema)
                    .SelectMany(DatabaseMetadataForAlternativeIdentities));

            databaseMetadata.AddRange(
                domainModel.Associations
                    .Where(AssociationInSchema)
                    .Where(AssociationIsNotOneToOne)
                    .Select(DatabaseMetadataForAssociation));

            return new
            {
                NamespaceName = EdFiConventions.BuildNamespace(
                    Namespaces.CodeGen.ExceptionHandling, TemplateContext.SchemaProperCaseName),
                IndexMetaData = databaseMetadata.OrderBy(x => x.TableName).ThenBy(x => x.Name)
            };
        }
    }
}
