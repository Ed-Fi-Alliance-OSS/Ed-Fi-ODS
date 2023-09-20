// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.EntityFrameworkCore;
using EdFi.Security.DataAccess.Models;

namespace EdFi.Security.DataAccess.Contexts
{
    public abstract class SecurityContextCore : DbContext, ISecurityContextCore
    {
        protected SecurityContextCore(DbContextOptions options)
            : base(options) { }

        public DbSet<Action> Actions { get; set; }

        public DbSet<AuthorizationStrategy> AuthorizationStrategies { get; set; }

        public DbSet<ClaimSet> ClaimSets { get; set; }

        public DbSet<ClaimSetResourceClaimAction> ClaimSetResourceClaimActions { get; set; }

        public DbSet<ResourceClaim> ResourceClaims { get; set; }

        public DbSet<ResourceClaimAction> ResourceClaimActions { get; set; }

        public DbSet<ClaimSetResourceClaimActionAuthorizationStrategyOverrides> ClaimSetResourceClaimActionAuthorizationStrategyOverrides { get; set; }

        public DbSet<ResourceClaimActionAuthorizationStrategies> ResourceClaimActionAuthorizationStrategies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceClaim>()
                .HasOne(rc => rc.ParentResourceClaim)
                .WithMany()
                .HasForeignKey(fk => fk.ParentResourceClaimId);

            modelBuilder.Entity<ResourceClaim>()
                .Navigation(t => t.ParentResourceClaim);
        }
    }
}
