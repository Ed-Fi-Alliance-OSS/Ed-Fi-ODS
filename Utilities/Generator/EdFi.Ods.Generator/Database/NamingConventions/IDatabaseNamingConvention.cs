// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Generator.Database.NamingConventions
{
    public interface IDatabaseNamingConvention
    {
        string Schema(Entity entity);

        string TableName(Entity entity);

        string ColumnName(EntityProperty property, string suffix = null);

        string ColumnName(string name, string suffix = null);

        string PrimaryKeyConstraintName(Entity entity);
        
        string ForeignKeyConstraintName(AssociationView association, string suffix = null);
        
        string ForeignKeyIndexName(AssociationView association, string suffix);

        string DefaultConstraintName(EntityProperty property);

        string DefaultDateConstraintValue();
        
        string DefaultGuidConstraintValue();

        string GetUniqueIndexName(Entity entity, string suffix = null);

        string GetAlternateKeyConstraintName(Entity entity);
    }
}
