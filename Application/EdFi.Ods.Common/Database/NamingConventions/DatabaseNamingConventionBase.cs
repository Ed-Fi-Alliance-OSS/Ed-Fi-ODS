// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Database.NamingConventions
{
    public abstract class DatabaseNamingConventionBase : IDatabaseNamingConvention
    {
        // Convention constants
        private const string PrimaryKeyNameSuffix = "_PK";
        private const string AlternateKeyNameSuffix = "_AK";
        private const string ForeignKeyNamePrefix = "FK_";
        
        private const string UniqueIndexNamePrefix = "UX_";
        private const string IndexNamePrefix = "IX_";
        
        private const string DefaultConstraintMidfix = "_DF_";

        protected abstract int MaximumNameLength { get; }
        
        protected abstract bool LowerCaseNames { get; }
        
        public virtual string Schema(Entity entity) => 
            new PhysicalNameParts(SchemaCore(entity))
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);
        
        private static string SchemaCore(Entity entity) => entity?.Schema;

        public virtual string TableName(Entity entity) => 
            new PhysicalNameParts(TableNameCore(entity))
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);

        private static string TableNameCore(Entity entity) => entity?.Name;

        public virtual string ColumnName(EntityProperty property, string contextualSuffix = null) =>
            new PhysicalNameParts(ColumnNameCore(property?.PropertyName), suffix: contextualSuffix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);

        public virtual string ColumnName(string name, string contextualSuffix) => 
            new PhysicalNameParts(ColumnNameCore(name), suffix: contextualSuffix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);

        private static string ColumnNameCore(string name) => name;
        
        public virtual string PrimaryKeyConstraintName(Entity entity) => 
            new PhysicalNameParts(PrimaryKeyConstraintNameCore(entity), suffix: PrimaryKeyNameSuffix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);

        private static string PrimaryKeyConstraintNameCore(Entity entity) => $"{TableNameCore(entity)}";

        public virtual string ForeignKeyConstraintName(AssociationView association, string context = null) => 
            new PhysicalNameParts(ForeignKeyConstraintNameCore(association, context), prefix: ForeignKeyNamePrefix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);

        private static string ForeignKeyConstraintNameCore(AssociationView association, string context = null)
        {
            if (association == null)
            {
                return null;
            }
            
            switch (association.AssociationType)
            {
                case AssociationViewType.ToDerived:
                case AssociationViewType.ToExtension:
                case AssociationViewType.OneToMany:
                case AssociationViewType.OneToOneOutgoing:
                    throw new ArgumentException("AssociationView must represent the incoming side of the association to be used for naming a foreign key.");
            }

            return $"{TableNameCore(association.ThisEntity)}_{TableNameCore(association.OtherEntity)}{context}";
        }

        public virtual string ForeignKeyIndexName(AssociationView association, string context = null) => 
            new PhysicalNameParts(ForeignKeyIndexNameCore(association, context), prefix: IndexNamePrefix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);
        
        private static string ForeignKeyIndexNameCore(AssociationView association, string context = null) =>
            $"{TableNameCore(association.ThisEntity)}_{association.RoleName}{TableNameCore(association.OtherEntity)}{context}";

        public virtual string DefaultConstraintName(EntityProperty property) => 
            new PhysicalNameParts(DefaultConstraintNameCore(property))
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);
        
        private static string DefaultConstraintNameCore(EntityProperty property) =>
            $"{TableNameCore(property.Entity)}{DefaultConstraintMidfix}{ColumnNameCore(property.PropertyName)}";

        public virtual string GetUniqueIndexName(Entity entity, string contextualSuffix = null) =>
            new PhysicalNameParts(GetUniqueIndexNameCore(entity), prefix: UniqueIndexNamePrefix, suffix: contextualSuffix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);
        
        private static string GetUniqueIndexNameCore(Entity entity) => TableNameCore(entity);

        public virtual string GetAlternateKeyConstraintName(Entity entity) =>
            new PhysicalNameParts(GetAlternateKeyConstraintNameCore(entity), prefix: UniqueIndexNamePrefix, suffix: AlternateKeyNameSuffix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);

        public virtual string IdentifierName(string coreName, string prefix = null, string suffix = null)
        {
            return new PhysicalNameParts(coreName, prefix, suffix)
                .ApplyLongNameConvention(LowerCaseNames, MaximumNameLength);
        }

        private static string GetAlternateKeyConstraintNameCore(Entity entity) => TableNameCore(entity);
        
        public abstract string DefaultDateConstraintValue();

        public abstract string DefaultGuidConstraintValue();
        
        /// <summary>
        /// Gets a short code representing the database engine.
        /// </summary>
        public abstract string DatabaseEngineCode { get; }
    }
}