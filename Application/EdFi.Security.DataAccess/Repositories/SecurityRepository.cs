// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Security.DataAccess.Repositories
{
    public class SecurityRepository : SecurityRepositoryBase, ISecurityRepository
    {
        private readonly ISecurityContextFactory _securityContextFactory;

        public SecurityRepository(ISecurityContextFactory securityContextFactory)
        {
            _securityContextFactory = Preconditions.ThrowIfNull(securityContextFactory, nameof(securityContextFactory));

            Initialize(
                GetApplication,
                GetActions,
                GetClaimSets,
                GetResourceClaims,
                GetAuthorizationStrategies,
                GetClaimSetResourceClaims,
                GetResourceClaimAuthorizationMetadata);
        }

        private Application GetApplication()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.Applications.AsEnumerable().FirstOrDefault(
                app => app.ApplicationName.Equals("Ed-Fi ODS API", StringComparison.InvariantCultureIgnoreCase));
        }

        private List<Models.Action> GetActions()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.Actions.ToList();
        }

        private List<ClaimSet> GetClaimSets()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.ClaimSets.Include(cs => cs.Application).ToList();
        }

        private List<ResourceClaim> GetResourceClaims()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.ResourceClaims
                .Include(rc => rc.Application)
                .Include(rc => rc.ParentResourceClaim)
                .Where(rc => rc.Application.ApplicationId.Equals(Application.Value.ApplicationId))
                .ToList();
        }

        private List<AuthorizationStrategy> GetAuthorizationStrategies()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.AuthorizationStrategies
                .Include(auth => auth.Application)
                .Where(auth => auth.Application.ApplicationId.Equals(Application.Value.ApplicationId))
                .ToList();
        }

        private List<ClaimSetResourceClaim> GetClaimSetResourceClaims()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.ClaimSetResourceClaims
                .Include(csrc => csrc.Action)
                .Include(csrc => csrc.ClaimSet)
                .Include(csrc => csrc.ResourceClaim)
                .Include(csrc => csrc.AuthorizationStrategyOverride)
                .Where(csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(Application.Value.ApplicationId))
                .ToList();
        }

        private List<ResourceClaimAuthorizationMetadata> GetResourceClaimAuthorizationMetadata()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.ResourceClaimAuthorizationMetadatas
                .Include(rcas => rcas.Action)
                .Include(rcas => rcas.AuthorizationStrategy)
                .Include(rcas => rcas.ResourceClaim)
                .Where(rcas => rcas.ResourceClaim.Application.ApplicationId.Equals(Application.Value.ApplicationId))
                .ToList();
        }
    }
}
