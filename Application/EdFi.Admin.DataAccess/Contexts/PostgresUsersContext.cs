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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Model.GetEntityTypes().ForEach(
                entityType =>
                    entityType.SetSchema("dbo"));

            modelBuilder.Model.GetEntityTypes().Single(e => e.ClrType.Name == nameof(ApiClientApplicationEducationOrganization))
                .GetProperty("ApplicationEducationOrganizationId")
                .SetColumnName("applicationedorg_applicationedorgid");

            modelBuilder.MakeDbObjectNamesLowercase();
        }
    }
}