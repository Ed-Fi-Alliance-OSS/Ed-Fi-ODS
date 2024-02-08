// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Admin.DataAccess.Extensions;
using EdFi.Admin.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Admin.DataAccess.Contexts
{
    public class SqlServerUsersContext : UsersContext
    {
        public SqlServerUsersContext(DbContextOptions options) : base(options) { }

        protected override void ApplyProviderSpecificMappings(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApiClient>()
             .HasMany(t => t.ApplicationEducationOrganizations) // many to many with ApiClient
             .WithMany(t => t.Clients) // Colection of entities ApplicationEducationOrganizations related to ApiClient
             .UsingEntity(join => join.ToTable("ApiClientApplicationEducationOrganizations"));

            modelBuilder.UseUnderscoredFkColumnNames();

            modelBuilder.Model.FindEntityTypes(typeof(ApiClient)).First().GetProperty("CreatorOwnershipTokenId")
                .SetColumnName("CreatorOwnershipTokenId_OwnershipTokenId");
        }

    }
}
