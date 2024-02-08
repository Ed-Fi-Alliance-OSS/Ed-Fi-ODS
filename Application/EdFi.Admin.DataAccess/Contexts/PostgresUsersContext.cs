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
            modelBuilder.Model.GetEntityTypes().ForEach(
               entityType =>
                   entityType.SetSchema("dbo"));

            modelBuilder.Entity<ApiClient>()
                .HasMany(t => t.ApplicationEducationOrganizations)
                .WithMany(t => t.Clients)
                .UsingEntity(join => join.ToTable("ApiClientApplicationEducationOrganizations"));

            modelBuilder.UseUnderscoredFkColumnNames();
            modelBuilder.MakeDbObjectNamesLowercase();
        }
    }
}