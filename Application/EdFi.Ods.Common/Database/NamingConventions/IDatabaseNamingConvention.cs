// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Database.NamingConventions
{
    public interface IDatabaseNamingConvention
    {
        string Schema(Entity entity);

        string TableName(Entity entity);

        string ColumnName(EntityProperty property, string contextualSuffix = null);

        string ColumnName(string name, string contextualSuffix = null);

        string PrimaryKeyConstraintName(Entity entity);
        
        string ForeignKeyConstraintName(AssociationView association, string context = null);
        
        string ForeignKeyIndexName(AssociationView association, string context);

        string DefaultConstraintName(EntityProperty property);

        string DefaultDateConstraintValue();
        
        string DefaultGuidConstraintValue();

        string GetUniqueIndexName(Entity entity, string contextualSuffix = null);

        string GetAlternateKeyConstraintName(Entity entity);

        string IdentifierName(string coreName, string prefix = null, string suffix = null);
        
        /// <summary>
        /// Gets a short code representing the database engine.
        /// </summary>
        string DatabaseEngineCode { get; }
    }
}
