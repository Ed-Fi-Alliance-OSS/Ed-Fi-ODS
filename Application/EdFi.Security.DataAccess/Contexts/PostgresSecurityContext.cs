﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Utils.Extensions;
using EdFi.Security.DataAccess.Models;
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

            modelBuilder.Model.GetEntityTypes().ForEach(entityType =>
                entityType.SetSchema("dbo"));

            //Fixes mapping error when using EFC
            modelBuilder.Model.GetEntityTypes().Single(e => e.ClrType.Name == nameof(ClaimSet))
                .GetProperty("ApplicationId")
                .SetColumnName("application_applicationid");

            modelBuilder.Model.GetEntityTypes().Single(e => e.ClrType.Name == nameof(ResourceClaim))
                .GetProperty("ApplicationId")
                .SetColumnName("application_applicationid");

            modelBuilder.Model.GetEntityTypes().Single(e => e.ClrType.Name == nameof(AuthorizationStrategy))
                .GetProperty("ApplicationId")
                .SetColumnName("application_applicationid");
        }
    }
}
