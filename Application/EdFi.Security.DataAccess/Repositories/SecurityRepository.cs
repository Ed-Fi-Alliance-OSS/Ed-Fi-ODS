// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Utils.Extensions;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;

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
                GetClaimSetResourceClaimActions,
                GetResourceClaimActionAuthorizations);
        }

        private Application GetApplication()
        {
            using var context = _securityContextFactory.CreateContext();

            return context.Applications.First(
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

        private List<ClaimSetResourceClaimAction> GetClaimSetResourceClaimActions()
        {
            using var context = _securityContextFactory.CreateContext();

            var claimSetResourceClaimActions = context.ClaimSetResourceClaimActions
                .Include(csrc => csrc.Action)
                .Include(csrc => csrc.ClaimSet)
                .Include(csrc => csrc.ClaimSet.Application)
                .Include(csrc => csrc.ResourceClaim)
                .Include(csrc => csrc.AuthorizationStrategyOverrides.Select(aso => aso.AuthorizationStrategy))
                .Where(csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(Application.Value.ApplicationId))
                .ToList();

            // Replace empty lists with null since some consumers expect it that way
            claimSetResourceClaimActions
                .Where(csrc => csrc.AuthorizationStrategyOverrides.Count == 0)
                .ForEach(csrc => csrc.AuthorizationStrategyOverrides = null);

            return claimSetResourceClaimActions;
        }

        private List<ResourceClaimAction> GetResourceClaimActionAuthorizations()
        {
            using var context = _securityContextFactory.CreateContext();

            var resourceClaimActionAuthorizationStrategies = context.ResourceClaimActionAuthorizationStrategies
                .Include(rcaas => rcaas.AuthorizationStrategy)
                .Include(rcaas => rcaas.ResourceClaimAction)
                .ToList();

            var resourceClaimActionAuthorizations = context.ResourceClaimActions
                .Include(rcas => rcas.Action)
                .Include(rcas => rcas.ResourceClaim)
                .Include(rcas => rcas.AuthorizationStrategies.Select(ast => ast.AuthorizationStrategy.Application))
                .Where(rcas => rcas.ResourceClaim.Application.ApplicationId.Equals(Application.Value.ApplicationId))
                .ToList();

            foreach (var a in resourceClaimActionAuthorizations)
            {
                a.AuthorizationStrategies = resourceClaimActionAuthorizationStrategies.Where(r => r.ResourceClaimAction.ResourceClaimActionId == a.ResourceClaimActionId).ToList();
            }

            return resourceClaimActionAuthorizations;
        }
    }
}
