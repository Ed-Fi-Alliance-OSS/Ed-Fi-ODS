// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EdFi.Common;
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
            LoadSecurityConfigurationFromDatabase();
        }

        public void LoadRecordOwnershipData()
        {
            using (var context = _securityContextFactory.CreateContext())
            {
                var claimNameList = new string[] { 
                    "http://ed-fi.org/ods/identity/claims/domains/educationOrganizations",
                    "http://ed-fi.org/ods/identity/claims/studentSectionAssociation",
                    "http://ed-fi.org/ods/identity/claims/gradingPeriod",
                    "http://ed-fi.org/ods/identity/claims/session",
                    "http://ed-fi.org/ods/identity/claims/course",
                    "http://ed-fi.org/ods/identity/claims/courseOffering",
                    "http://ed-fi.org/ods/identity/claims/section",
                    "http://ed-fi.org/ods/identity/claims/studentSchoolAssociation"
                };

                var ownershipBasedClaimSetId = context.ClaimSets.FirstOrDefault(a => a.ClaimSetName == "Ownership Based Test").ClaimSetId;
                var ownershipBasedAuthorizationStrategyId = context.AuthorizationStrategies.FirstOrDefault(a => a.AuthorizationStrategyName == "OwnershipBased").AuthorizationStrategyId;

                var resourceClaims = context.ResourceClaims.Where(x => claimNameList.Contains(x.ClaimName)).ToList();          
                var actions = context.Actions.ToList();

                var claimSetResourceClaimActions = new List<ClaimSetResourceClaimAction>();

                resourceClaims.ForEach(resourceClaim =>
                {
                            actions.ForEach(action =>
                            {
                                if (!context.ClaimSetResourceClaimActions.Any(a => a.ActionId == action.ActionId && a.ResourceClaimId == resourceClaim.ResourceClaimId 
                                && a.ClaimSetId == ownershipBasedClaimSetId))
                                {
                                    claimSetResourceClaimActions.Add(
                                       new ClaimSetResourceClaimAction
                                       {
                                           ResourceClaimId = resourceClaim.ResourceClaimId,
                                           ActionId = action.ActionId,
                                           ClaimSetId = ownershipBasedClaimSetId
                                       }); 
                                }
                            });

                });

                if (claimSetResourceClaimActions.Any())
                {
                    context.ClaimSetResourceClaimActions.AddRange(claimSetResourceClaimActions);
                    context.SaveChanges();
                }

                var resourceClaimList = resourceClaims.Select(x => x.ResourceClaimId);
                var claimSetResourceClaimActionList = context.ClaimSetResourceClaimActions.Where(x => resourceClaimList.Contains(x.ResourceClaimId))
                    .Where(x=>x.ClaimSetId == ownershipBasedClaimSetId).ToList();

                var claimSetResourceClaimActionAuthorizationStrategyOverrides = new List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides>();

                claimSetResourceClaimActionList.ForEach(claimSetResourceClaimAction =>
                {
                    if (!context.ClaimSetResourceClaimActionAuthorizationStrategyOverrides.Any(a => a.ClaimSetResourceClaimActionId == claimSetResourceClaimAction.ClaimSetResourceClaimActionId 
                        && a.AuthorizationStrategyId == ownershipBasedAuthorizationStrategyId))
                    {
                        claimSetResourceClaimActionAuthorizationStrategyOverrides.Add(
                          new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                          {
                              ClaimSetResourceClaimActionId = claimSetResourceClaimAction.ClaimSetResourceClaimActionId,
                              AuthorizationStrategyId = ownershipBasedAuthorizationStrategyId
                          });
                    }
                });

                if (claimSetResourceClaimActionAuthorizationStrategyOverrides.Any())
                {
                    context.ClaimSetResourceClaimActionAuthorizationStrategyOverrides.AddRange(claimSetResourceClaimActionAuthorizationStrategyOverrides);
                    context.SaveChanges();
                }
            }

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

                var claimSetResourceClaimActions = context.ClaimSetResourceClaimActions.Include(csrc => csrc.Action)
                                                    .Include(csrc => csrc.ClaimSet)
                                                    .Include(csrc => csrc.ResourceClaim)
                                                    .Where(csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                                                    .ToList();

                var claimSetResourceClaimActionAuthorizationStrategyOverrides = context.ClaimSetResourceClaimActionAuthorizationStrategyOverrides.Include(csrcas => csrcas.AuthorizationStrategy)
                                                   .Include(csrcas => csrcas.ClaimSetResourceClaimAction)
                                                   .ToList();

                var resourceClaimActionAuthorizationStrategies = context.ResourceClaimActionAuthorizationStrategies.Include(rcaas => rcaas.AuthorizationStrategy)
                                    .Include(rcaas => rcaas.ResourceClaimAction)
                                    .ToList();

                var resourceClaimActionAuthorizations =
                    context.ResourceClaimActions.Include(rcas => rcas.Action)                           
                           .Include(rcas => rcas.ResourceClaim)
                           .Where(rcas => rcas.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                           .ToList();

                foreach (var a in resourceClaimActionAuthorizations)
                {
                    a.AuthorizationStrategies = resourceClaimActionAuthorizationStrategies.Where(r => r.ResourceClaimAction.ResourceClaimActionId == a.ResourceClaimActionId).ToList();
                }

                Initialize(
                    application,
                    actions,
                    claimSets,
                    resourceClaims,
                    authorizationStrategies,
                    claimSetResourceClaimActions,
                    resourceClaimActionAuthorizations);
            }
        }
    }
}
