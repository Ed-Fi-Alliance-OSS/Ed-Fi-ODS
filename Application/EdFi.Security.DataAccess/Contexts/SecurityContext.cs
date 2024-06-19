// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.EntityFrameworkCore;
using EdFi.Security.DataAccess.Models;

namespace EdFi.Security.DataAccess.Contexts
{
    public abstract class SecurityContext : DbContext, ISecurityContext
    {
        protected SecurityContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Action> Actions { get; set; }

        public DbSet<AuthorizationStrategy> AuthorizationStrategies { get; set; }

        public DbSet<ClaimSet> ClaimSets { get; set; }

        public DbSet<ClaimSetResourceClaim> ClaimSetResourceClaims { get; set; }

        public DbSet<ResourceClaim> ResourceClaims { get; set; }

        public DbSet<ResourceClaimAuthorizationMetadata> ResourceClaimAuthorizationMetadatas { get; set; }
    }
}
