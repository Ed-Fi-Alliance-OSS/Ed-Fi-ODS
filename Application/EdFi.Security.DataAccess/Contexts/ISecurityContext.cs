// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Entity;
using System.Threading.Tasks;
using EdFi.Security.DataAccess.Models;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.Contexts
{
    public interface ISecurityContext : IDisposable
    {
        DbSet<Application> Applications { get; set; }

        DbSet<Action> Actions { get; set; }

        DbSet<AuthorizationStrategy> AuthorizationStrategies { get; set; }

        DbSet<ClaimSet> ClaimSets { get; set; }

        DbSet<ClaimSetResourceClaim> ClaimSetResourceClaims { get; set; }

        DbSet<ResourceClaim> ResourceClaims { get; set; }

        DbSet<ResourceClaimAuthorizationMetadata> ResourceClaimAuthorizationMetadatas { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
