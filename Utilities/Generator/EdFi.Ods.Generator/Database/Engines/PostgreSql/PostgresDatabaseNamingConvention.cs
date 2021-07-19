// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.NamingConventions;

namespace EdFi.Ods.Generator.Database.Engines.PostgreSql
{
    public class PostgresDatabaseNamingConvention : IDatabaseNamingConvention
    {
        public string Schema(Entity entity) => throw new System.NotImplementedException();

        public string TableName(Entity entity) => throw new System.NotImplementedException();

        public string ColumnName(EntityProperty property, string suffix = null) => throw new System.NotImplementedException();

        public string ColumnName(string name, string suffix = null) => throw new System.NotImplementedException();

        public string PrimaryKeyConstraintName(Entity entity) => throw new System.NotImplementedException();

        public string ForeignKeyConstraintName(AssociationView association, string suffix = null) => throw new System.NotImplementedException();

        public string ForeignKeyIndexName(AssociationView association, string suffix) => throw new System.NotImplementedException();

        public string DefaultConstraintName(EntityProperty property) => throw new System.NotImplementedException();

        public string DefaultDateConstraintValue() => throw new System.NotImplementedException();

        public string DefaultGuidConstraintValue() => throw new System.NotImplementedException();

        public string GetUniqueIndexName(Entity entity, string suffix = null) => throw new System.NotImplementedException();

        public string GetAlternateKeyConstraintName(Entity entity) => throw new System.NotImplementedException();
    }
}
