// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using EdFi.Admin.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;

namespace EdFi.Admin.DataAccess.Contexts
{
    public class PostgresUsersContext : UsersContext
    {
        public PostgresUsersContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Model.GetEntityTypes().ForEach(entityType =>
                entityType.SetSchema("dbo"));
            
            modelBuilder.MakeDbObjectNamesLowercase();
            
            modelBuilder.Model.GetEntityTypes().Single(e => e.ClrType.Name == nameof(ApiClientApplicationEducationOrganization))
                .GetProperty("ApplicationEducationOrganizationId")
                .SetColumnName("applicationedorg_applicationedorgid");
            
            // modelBuilder.Model.GetEntityTypes().Single(e => e.ClrType.Name == nameof(ApiClientApplicationEducationOrganization))
            //     .GetProperty("Profiledefinition").SetValueConverter();

            modelBuilder
                .Entity<Profile>()
                .Property(e => e.ProfileDefinition)
                .HasColumnType("xml");
        }
    }
}
