// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Extensions;

namespace EdFi.Ods.Generator.Database.Engines.SqlServer
{
    public class SqlServerDatabaseNamingConvention : IDatabaseNamingConvention
    {
        public string Schema(Entity entity) => SchemaCore(entity).ApplyLongNameConvention();
        
        private static string SchemaCore(Entity entity) => entity.Schema;

        public string TableName(Entity entity) => TableNameCore(entity).ApplyLongNameConvention();

        private static string TableNameCore(Entity entity) => entity.Name;  
        
        public string ColumnName(EntityProperty property, string suffix = null) => ColumnNameCore(property.PropertyName, suffix);

        public string ColumnName(string name, string suffix) => ColumnNameCore(name, suffix).ApplyLongNameConvention(suffix);

        private static string ColumnNameCore(string name, string suffix = null) => $"{name}{suffix}";
        
        public string PrimaryKeyConstraintName(Entity entity) 
            => PrimaryKeyConstraintNameCore(entity).ApplyLongNameConvention("_PK");

        private static string PrimaryKeyConstraintNameCore(Entity entity) => $"{TableNameCore(entity)}_PK";

        public string ForeignKeyConstraintName(AssociationView association, string suffix = null) 
            => ForeignKeyConstraintNameCore(association, suffix).ApplyLongNameConvention(suffix.PrefixWith("_"));

        private static string ForeignKeyConstraintNameCore(AssociationView association, string suffix = null)
        {
            switch (association.AssociationType)
            {
                case AssociationViewType.ToDerived:
                case AssociationViewType.ToExtension:
                case AssociationViewType.OneToMany:
                case AssociationViewType.OneToOneOutgoing:
                    throw new ArgumentException("AssociationView must represent the incoming side of the association to be used for naming a foreign key.");
            }

            // return $"FK_{association.RoleName}{TableNameCore(association.ThisEntity)}_{TableNameCore(association.OtherEntity)}{suffix.PrefixWith("_")}";
            return $"FK_{TableNameCore(association.ThisEntity)}_{TableNameCore(association.OtherEntity)}{suffix.PrefixWith("_")}";
        }

        public string ForeignKeyIndexName(AssociationView association, string suffix = null) 
            => ForeignKeyIndexNameCore(association, suffix).ApplyLongNameConvention(suffix);
        
        private static string ForeignKeyIndexNameCore(AssociationView association, string suffix = null)
        {
            return $"IX_{TableNameCore(association.ThisEntity)}_{association.RoleName}{TableNameCore(association.OtherEntity)}{suffix.PrefixWith("_")}";
        }

        public string DefaultConstraintName(EntityProperty property) 
            => DefaultConstraintNameCore(property).ApplyLongNameConvention();
        
        private static string DefaultConstraintNameCore(EntityProperty property)
        {
            return $"{TableNameCore(property.Entity)}_DF_{ColumnNameCore(property.PropertyName)}";
        }

        public string DefaultDateConstraintValue() => "getutcdate()";

        public string DefaultGuidConstraintValue() => "newid()";

        public string GetUniqueIndexName(Entity entity, string suffix = null) =>
            GetUniqueIndexNameCore(entity, suffix).ApplyLongNameConvention(suffix.PrefixWith("_"));
        
        private static string GetUniqueIndexNameCore(Entity entity, string suffix = null)
        {
            return $"UX_{TableNameCore(entity)}{suffix.PrefixWith("_")}";
        }

        public string GetAlternateKeyConstraintName(Entity entity) =>
            GetAlternateKeyConstraintNameCore(entity).ApplyLongNameConvention("_AK");
        
        private static string GetAlternateKeyConstraintNameCore(Entity entity)
        {
            return $"UX_{TableNameCore(entity)}_AK";
        }

        // private string GetConstraintName(string thisTableName, string otherTableName, string roleName = null)
        // {
        //     string constraintName = $"FK_{roleName}{thisTableName}_{otherTableName}";
        //
        //     if (constraintName.Length > 128)
        //         return constraintName.Substring(0, 128);
        //
        //     return constraintName;
        // }
    }
}
