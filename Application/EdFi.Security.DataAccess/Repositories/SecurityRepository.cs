// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Entity;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Security.DataAccess.Contexts;

namespace EdFi.Security.DataAccess.Repositories
{
    public class SecurityRepository : SecurityRepositoryBase, ISecurityRepository
    {
        private readonly ISecurityContextFactory _securityContextFactory;

        public SecurityRepository(ISecurityContextFactory securityContextFactory)
        {
            _securityContextFactory = Preconditions.ThrowIfNull(securityContextFactory, nameof(securityContextFactory));
            LoadSecurityConfigurationFromDatabase();
        }

        protected void LoadSecurityConfigurationFromDatabase()
        {
            using (var context = _securityContextFactory.CreateContext())
            {
                var application =
                    context.Applications.First(
                        app => app.ApplicationName.Equals("Ed-Fi ODS API", StringComparison.InvariantCultureIgnoreCase));

                var actions = context.Actions.ToList();

                var claimSets = context.ClaimSets.Include(cs => cs.Application)
                                       .ToList();

                var resourceClaims = context.ResourceClaims.Include(rc => rc.Application)
                                            .Include(rc => rc.ParentResourceClaim)
                                            .Where(rc => rc.Application.ApplicationId.Equals(application.ApplicationId))
                                            .ToList();

                var authorizationStrategies = context.AuthorizationStrategies.Include(auth => auth.Application)
                                                     .Where(auth => auth.Application.ApplicationId.Equals(application.ApplicationId))
                                                     .ToList();

                var claimSetResourceClaims = context.ClaimSetResourceClaims.Include(csrc => csrc.Action)
                                                    .Include(csrc => csrc.ClaimSet)
                                                    .Include(csrc => csrc.ResourceClaim)
                                                    .Where(csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                                                    .ToList();

                var resourceClaimAuthorizationMetadata =
                    context.ResourceClaimAuthorizationMetadatas.Include(rcas => rcas.Action)
                           .Include(rcas => rcas.AuthorizationStrategy)
                           .Include(rcas => rcas.ResourceClaim)
                           .Where(rcas => rcas.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                           .ToList();

                Initialize(
                    application,
                    actions,
                    claimSets,
                    resourceClaims,
                    authorizationStrategies,
                    claimSetResourceClaims,
                    resourceClaimAuthorizationMetadata);
            }
        }
    }
}
