// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Ods.Sandbox.Admin.Contexts
{
    public class IdentityContext : IdentityDbContext
    {
        protected IdentityContext()
            : base() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyProviderSpecificMappings(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ApplyProviderSpecificConnection(optionsBuilder);
        }

        protected virtual void ApplyProviderSpecificConnection(DbContextOptionsBuilder optionsBuilder) { }
        /// <remarks>
        /// Sub-classes should override this to provide database system-specific column and/or
        /// table mappings: for example, if a linking table column in Postgres needs to map to a
        /// name other than the default provided by Entity Framework.
        /// </remarks>
        protected virtual void ApplyProviderSpecificMappings(ModelBuilder modelBuilder) { }
    }
}

