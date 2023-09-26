// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Utils.Extensions;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.Repositories;

public class SecurityTableGateway : ISecurityTableGateway
{
    private readonly ISecurityContextFactory _securityContextFactory;

    public SecurityTableGateway(ISecurityContextFactory securityContextFactory)
    {
        _securityContextFactory = securityContextFactory ?? throw new ArgumentNullException(nameof(securityContextFactory));
    }

    public List<Action> GetActions()
    {
        using var context = _securityContextFactory.CreateContext();

        return context.Actions.ToList();
    }

    public List<ClaimSet> GetClaimSets()
    {
        using var context = _securityContextFactory.CreateContext();

        return context.ClaimSets.ToList();
    }

    public List<ResourceClaim> GetResourceClaims()
    {
        using var context = _securityContextFactory.CreateContext();

        return context.ResourceClaims
            .Include(rc => rc.ParentResourceClaim)
            .ToList();
    }

    public List<AuthorizationStrategy> GetAuthorizationStrategies()
    {
        using var context = _securityContextFactory.CreateContext();

        return context.AuthorizationStrategies.ToList();
    }

    public List<ClaimSetResourceClaimAction> GetClaimSetResourceClaimActions()
    {
        using var context = _securityContextFactory.CreateContext();

        var claimSetResourceClaimActions = context.ClaimSetResourceClaimActions.Include(csrc => csrc.Action)
            .Include(csrc => csrc.ClaimSet)
            .Include(csrc => csrc.ResourceClaim)
            .Include(csrc => csrc.AuthorizationStrategyOverrides)
            .ThenInclude(aso => aso.AuthorizationStrategy)
            .ToList();

        // Replace empty lists with null since some consumers expect it that way
        claimSetResourceClaimActions.Where(csrc => csrc.AuthorizationStrategyOverrides.Count == 0)
            .ForEach(csrc => csrc.AuthorizationStrategyOverrides = null);

        return claimSetResourceClaimActions;
    }

    public List<ResourceClaimAction> GetResourceClaimActionAuthorizations()
    {
        using var context = _securityContextFactory.CreateContext();

        var resourceClaimActionAuthorizationStrategies = context.ResourceClaimActionAuthorizationStrategies
            .Include(rcaas => rcaas.AuthorizationStrategy)
            .Include(rcaas => rcaas.ResourceClaimAction)
            .ToList();

        var resourceClaimActionAuthorizations = context.ResourceClaimActions.Include(rcas => rcas.Action)
            .Include(rcas => rcas.ResourceClaim)
            .Include(rcas => rcas.AuthorizationStrategies)
            .ToList();

        foreach (var a in resourceClaimActionAuthorizations)
        {
            a.AuthorizationStrategies = resourceClaimActionAuthorizationStrategies
                .Where(r => r.ResourceClaimAction.ResourceClaimActionId == a.ResourceClaimActionId)
                .ToList();
        }

        return resourceClaimActionAuthorizations;
    }
}
