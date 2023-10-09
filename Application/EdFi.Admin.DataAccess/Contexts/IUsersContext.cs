// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Admin.DataAccess.Contexts
{
    public interface IUsersContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<ApiClient> ApiClients { get; set; }

        DbSet<ClientAccessToken> ClientAccessTokens { get; set; }

        DbSet<Vendor> Vendors { get; set; }

        DbSet<Application> Applications { get; set; }

        DbSet<Profile> Profiles { get; set; }

        DbSet<OdsInstance> OdsInstances { get; set; }

        DbSet<OdsInstanceContext> OdsInstanceContexts { get; set; }

        DbSet<OdsInstanceDerivative> OdsInstanceDerivatives { get; set; }

        DbSet<ApplicationEducationOrganization> ApplicationEducationOrganizations { get; set; }

        DbSet<VendorNamespacePrefix> VendorNamespacePrefixes { get; set; }

        DbSet<OwnershipToken> OwnershipTokens { get; set; }

        DbSet<ApiClientOdsInstance> ApiClientOdsInstances { get; set; }

        DbSet<ApiClientOwnershipToken> ApiClientOwnershipTokens { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
