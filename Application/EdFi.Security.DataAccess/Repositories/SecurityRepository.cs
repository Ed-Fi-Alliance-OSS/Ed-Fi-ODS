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

        public void LoadMultipleAuthorizationStrategyData()
        {
            using (var context = _securityContextFactory.CreateContext())
            {

                var authorizationStrategyNameList = new string[] {
                    "OwnershipBased",
                    "RelationshipsWithEdOrgsAndPeople",
                    "RelationshipsWithStudentsOnlyThroughResponsibility"
                };

                var claimNameList = new string[] {
                    "http://ed-fi.org/ods/identity/claims/studentSectionAssociation",
                    "http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation"
                };

                var resourceClaims = context.ResourceClaims.Where(x => claimNameList.Contains(x.ClaimName)).ToList();

                var studentSectionAssociationResourceClaimId = resourceClaims.FirstOrDefault(x => x.ClaimName.Equals("http://ed-fi.org/ods/identity/claims/studentSectionAssociation")).ResourceClaimId;
                var seoraResourceClaimId = resourceClaims.FirstOrDefault(x => x.ClaimName.Equals("http://ed-fi.org/ods/identity/claims/studentEducationOrganizationResponsibilityAssociation")).ResourceClaimId;

                var readActionId = context.Actions.FirstOrDefault(a=>a.ActionName.ToLower()=="read").ActionId;
                var createActionId = context.Actions.FirstOrDefault(a => a.ActionName.ToLower() == "create").ActionId;

                var edFiSandboxClaimSetId = context.ClaimSets.FirstOrDefault(a => a.ClaimSetName == "Ed-Fi Sandbox").ClaimSetId;
                var authorizationStrategyList = context.AuthorizationStrategies.ToList();
                var authorizationStrategyReadList = authorizationStrategyList.Where(a => authorizationStrategyNameList.Contains(a.AuthorizationStrategyName)).ToList();
                var relationshipsWithEdOrgsOnlyAuthorizationStrategy = authorizationStrategyList.Where(a => a.AuthorizationStrategyName.Equals("RelationshipsWithEdOrgsOnly")).Single();
                var authorizationStrategyCreateList = authorizationStrategyList.Where(a => a.AuthorizationStrategyName.Equals("RelationshipsWithEdOrgsAndPeople") || a.AuthorizationStrategyName.Equals("RelationshipsWithStudentsOnlyThroughResponsibility")).ToList();

                var claimSetResourceClaimActions = new List<ClaimSetResourceClaimAction>();

                if (!context.ClaimSetResourceClaimActions.Any(a => a.ActionId == readActionId && a.ResourceClaimId == studentSectionAssociationResourceClaimId
                        && a.ClaimSetId == edFiSandboxClaimSetId))
                    {
                        claimSetResourceClaimActions.Add(
                           new ClaimSetResourceClaimAction
                           {
                               ResourceClaimId = studentSectionAssociationResourceClaimId,
                               ActionId = readActionId,
                               ClaimSetId = edFiSandboxClaimSetId
                           });
                }

                if (!context.ClaimSetResourceClaimActions.Any(a => a.ActionId == createActionId && a.ResourceClaimId == studentSectionAssociationResourceClaimId
                    && a.ClaimSetId == edFiSandboxClaimSetId))
                {
                    claimSetResourceClaimActions.Add(
                       new ClaimSetResourceClaimAction
                       {
                           ResourceClaimId = studentSectionAssociationResourceClaimId,
                           ActionId = createActionId,
                           ClaimSetId = edFiSandboxClaimSetId
                       });
                }


                if (!context.ClaimSetResourceClaimActions.Any(a => a.ActionId == createActionId && a.ResourceClaimId == seoraResourceClaimId
                    && a.ClaimSetId == edFiSandboxClaimSetId))
                {
                    claimSetResourceClaimActions.Add(
                       new ClaimSetResourceClaimAction
                       {
                           ResourceClaimId = seoraResourceClaimId,
                           ActionId = createActionId,
                           ClaimSetId = edFiSandboxClaimSetId
                       });
                }


                if (claimSetResourceClaimActions.Any())
                {
                    context.ClaimSetResourceClaimActions.AddRange(claimSetResourceClaimActions);
                    context.SaveChanges();
                }

                var claimSetStudentSectionAssociationResourceClaimAction = context.ClaimSetResourceClaimActions.Where(x => x.ResourceClaimId== studentSectionAssociationResourceClaimId && x.ClaimSetId == edFiSandboxClaimSetId
                    && x.ActionId== readActionId).Single();

                var claimSetResourceClaimActionAuthorizationStrategyOverrides = new List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides>();

                authorizationStrategyReadList.ForEach(authorizationStrategy =>
                {

                        if (!context.ClaimSetResourceClaimActionAuthorizationStrategyOverrides.Any(a => a.ClaimSetResourceClaimActionId == claimSetStudentSectionAssociationResourceClaimAction.ClaimSetResourceClaimActionId
                        && a.AuthorizationStrategyId == authorizationStrategy.AuthorizationStrategyId))
                        {
                            claimSetResourceClaimActionAuthorizationStrategyOverrides.Add(
                              new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                              {
                                  ClaimSetResourceClaimAction = claimSetStudentSectionAssociationResourceClaimAction,
                                  ClaimSetResourceClaimActionId = claimSetStudentSectionAssociationResourceClaimAction.ClaimSetResourceClaimActionId,
                                  AuthorizationStrategy = authorizationStrategy,
                                  AuthorizationStrategyId = authorizationStrategy.AuthorizationStrategyId
                              });
                        }
                });

                var claimSetResourceClaimActionCreate = context.ClaimSetResourceClaimActions.Where(x => x.ResourceClaimId == studentSectionAssociationResourceClaimId && x.ClaimSetId == edFiSandboxClaimSetId
                && x.ActionId == createActionId).Single();


                authorizationStrategyCreateList.ForEach(authorizationStrategy =>
                {

                    if (!context.ClaimSetResourceClaimActionAuthorizationStrategyOverrides.Any(a => a.ClaimSetResourceClaimActionId == claimSetResourceClaimActionCreate.ClaimSetResourceClaimActionId
                    && a.AuthorizationStrategyId == authorizationStrategy.AuthorizationStrategyId))
                    {
                        claimSetResourceClaimActionAuthorizationStrategyOverrides.Add(
                          new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                          {
                              ClaimSetResourceClaimAction = claimSetResourceClaimActionCreate,
                              ClaimSetResourceClaimActionId = claimSetResourceClaimActionCreate.ClaimSetResourceClaimActionId,
                              AuthorizationStrategy = authorizationStrategy,
                              AuthorizationStrategyId = authorizationStrategy.AuthorizationStrategyId
                          });
                    }
                });

                var claimSetSeoraResourceClaimAction = context.ClaimSetResourceClaimActions.Where(x => x.ResourceClaimId == seoraResourceClaimId && x.ClaimSetId == edFiSandboxClaimSetId
                    && x.ActionId == createActionId).Single();


                if (!context.ClaimSetResourceClaimActionAuthorizationStrategyOverrides.Any(a => a.ClaimSetResourceClaimActionId == claimSetSeoraResourceClaimAction.ClaimSetResourceClaimActionId
                    && a.AuthorizationStrategyId == relationshipsWithEdOrgsOnlyAuthorizationStrategy.AuthorizationStrategyId))
                    {
                        claimSetResourceClaimActionAuthorizationStrategyOverrides.Add(
                          new ClaimSetResourceClaimActionAuthorizationStrategyOverrides
                          {
                              ClaimSetResourceClaimAction =claimSetSeoraResourceClaimAction,
                              ClaimSetResourceClaimActionId = claimSetSeoraResourceClaimAction.ClaimSetResourceClaimActionId,
                              AuthorizationStrategy = relationshipsWithEdOrgsOnlyAuthorizationStrategy,
                              AuthorizationStrategyId = relationshipsWithEdOrgsOnlyAuthorizationStrategy.AuthorizationStrategyId,

                          });
                }

                if (claimSetResourceClaimActionAuthorizationStrategyOverrides.Any())
                {
                    context.ClaimSetResourceClaimActionAuthorizationStrategyOverrides.AddRange(claimSetResourceClaimActionAuthorizationStrategyOverrides);
                    context.SaveChanges();
                }
            }

            Reset();
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

            Reset();
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
