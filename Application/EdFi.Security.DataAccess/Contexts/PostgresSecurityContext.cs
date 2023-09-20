// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Security.DataAccess.Contexts
{
    public class PostgresSecurityContext : SecurityContext
    {
        public PostgresSecurityContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.IsForeignKey())
                    {
                        var foreignKey = property.GetContainingForeignKeys().FirstOrDefault(f => f.Properties.Count == 1);

                        foreignKey?.SetConstraintName(foreignKey.GetConstraintName()?.ToLowerInvariant());
                    }
                    property.SetColumnName(property.ClrType.Name.ToLowerInvariant());
                }
                entityType.SetTableName(entityType.GetTableName()?.ToLowerInvariant());
            }
            //
            // modelBuilder.Conventions.Add<ForeignKeyLowerCaseNamingConvention>();
            // modelBuilder.Conventions.Add<TableLowerCaseNamingConvention>();
            //
            // modelBuilder.Properties().Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name.ToLowerInvariant()));
        }

        // private class TableLowerCaseNamingConvention : IStoreModelConvention<EntitySet>
        // {
        //     public void Apply(EntitySet entitySet, DbModel model)
        //     {
        //         Preconditions.ThrowIfNull(entitySet, nameof(entitySet));
        //         Preconditions.ThrowIfNull(model, nameof(model));
        //
        //         entitySet.Table = entitySet.Table.ToLowerInvariant();
        //     }
        // }
        //
        // private class ForeignKeyLowerCaseNamingConvention : IStoreModelConvention<AssociationType>
        // {
        //     public void Apply(AssociationType association, DbModel model)
        //     {
        //         Preconditions.ThrowIfNull(association, nameof(association));
        //         Preconditions.ThrowIfNull(model, nameof(model));
        //
        //         if (!association.IsForeignKey)
        //         {
        //             return;
        //         }
        //
        //         association.Constraint.FromProperties.ForEach(PropertyNamesToLowerInvariant);
        //         association.Constraint.ToProperties.ForEach(PropertyNamesToLowerInvariant);
        //
        //         void PropertyNamesToLowerInvariant(EdmProperty property) => property.Name = property.Name.ToLowerInvariant();
        //     }
        // }
    }
}
