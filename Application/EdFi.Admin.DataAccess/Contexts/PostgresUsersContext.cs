// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess.Extensions;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EdFi.Admin.DataAccess.Contexts
{
    public class PostgresUsersContext : UsersContext
    {
        public PostgresUsersContext(DbContextOptions options) : base(options) { }
        

        protected override void ApplyProviderSpecificMappings(ModelBuilder modelBuilder)
        {
            /*
            // The column name in this linking table had to be shortened for Postgres
            modelBuilder.Entity<ApiClient>()
                .HasMany(t => t.ApplicationEducationOrganizations)
                .WithMany(t => t.Clients)
                .Map(
                    m =>
                    {
                        m.ToTable("ApiClientApplicationEducationOrganizations", "dbo");
                        m.MapLeftKey("ApiClient_ApiClientId");
                        m.MapRightKey("ApplicationEdOrg_ApplicationEdOrgId");
                    });
            */
            modelBuilder.Model.GetEntityTypes().ForEach(
               entityType =>
                   entityType.SetSchema("dbo"));

            modelBuilder.Entity<ApiClient>()
                .HasMany(t => t.ApplicationEducationOrganizations)
                .WithMany(t => t.Clients)
                .UsingEntity(join => join.ToTable("ApiClientApplicationEducationOrganizations"));

            modelBuilder.UseUnderscoredFkColumnNames();
            modelBuilder.MakeDbObjectNamesLowercase();  

            //modelBuilder.Conventions.Add<ForeignKeyLowerCaseNamingConvention>();
            //modelBuilder.Conventions.Add<TableLowerCaseNamingConvention>();

            //modelBuilder.Properties().Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name.ToLowerInvariant()));
        }
        /*
        private class TableLowerCaseNamingConvention : IStoreModelConvention<EntitySet>
        {
            public void Apply(EntitySet entitySet, DbModel model)
            {
                Preconditions.ThrowIfNull(entitySet, nameof(entitySet));
                Preconditions.ThrowIfNull(model, nameof(model));

                entitySet.Table = entitySet.Table.ToLowerInvariant();
            }
        }

        private class ForeignKeyLowerCaseNamingConvention : IStoreModelConvention<AssociationType>
        {
            public void Apply(AssociationType association, DbModel model)
            {
                Preconditions.ThrowIfNull(association, nameof(association));
                Preconditions.ThrowIfNull(model, nameof(model));

                if (!association.IsForeignKey)
                {
                    return;
                }

                association.Constraint.FromProperties.ForEach(PropertyNamesToLowerInvariant);
                association.Constraint.ToProperties.ForEach(PropertyNamesToLowerInvariant);

                void PropertyNamesToLowerInvariant(EdmProperty property) => property.Name = property.Name.ToLowerInvariant();
            }
        }
        */

    }
}