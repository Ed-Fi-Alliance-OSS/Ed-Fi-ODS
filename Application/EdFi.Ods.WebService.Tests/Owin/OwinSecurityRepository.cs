// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;
using Newtonsoft.Json;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Ods.WebService.Tests.Owin
{
    public class OwinSecurityRepository : SecurityRepositoryBase, ISecurityRepository
    {
        private OwinSecurityData _securityData;

        private static string _jsonSecurityData;

        public OwinSecurityRepository()
        {
            if (string.IsNullOrEmpty(_jsonSecurityData))
            {
                _securityData = new OwinSecurityData();

                using (var context = new SqlServerSecurityContext())
                {
                    var application =
                        context.Applications.First(
                            app => app.ApplicationName.Equals("Ed-Fi ODS API", StringComparison.InvariantCultureIgnoreCase));

                    _securityData.Application = application;

                    _securityData.Actions = context.Actions.ToList();

                    _securityData.ClaimSets = context.ClaimSets.Include(cs => cs.Application)
                                                     .ToList();

                    _securityData.ResourceClaims = context.ResourceClaims.Include(rc => rc.Application)
                                                          .Include(rc => rc.ParentResourceClaim)
                                                          .Where(rc => rc.Application.ApplicationId.Equals(application.ApplicationId))
                                                          .ToList();

                    _securityData.AuthorizationStrategies = context.AuthorizationStrategies.Include(auth => auth.Application)
                                                                   .Where(auth => auth.Application.ApplicationId.Equals(application.ApplicationId))
                                                                   .ToList();

                    _securityData.ClaimSetResourceClaims = context.ClaimSetResourceClaims.Include(csrc => csrc.Action)
                                                                  .Include(csrc => csrc.ClaimSet)
                                                                  .Include(csrc => csrc.ResourceClaim)
                                                                  .Where(
                                                                      csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(
                                                                          application.ApplicationId))
                                                                  .ToList();

                    _securityData.ResourceClaimAuthorizationMetadata =
                        context.ResourceClaimAuthorizationMetadatas.Include(rcas => rcas.Action)
                               .Include(rcas => rcas.AuthorizationStrategy)
                               .Include(rcas => rcas.ResourceClaim)
                               .Where(rcas => rcas.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                               .ToList();
                }

                _jsonSecurityData = JsonConvert.SerializeObject(_securityData);
            }

            if (!string.IsNullOrEmpty(_jsonSecurityData))
            {
                _securityData = JsonConvert.DeserializeObject<OwinSecurityData>(_jsonSecurityData);

                Initialize(
                    _securityData.Application,
                    _securityData.Actions,
                    _securityData.ClaimSets,
                    _securityData.ResourceClaims,
                    _securityData.AuthorizationStrategies,
                    _securityData.ClaimSetResourceClaims,
                    _securityData.ResourceClaimAuthorizationMetadata);
            }
        }

        public Application GetApplication()
        {
            return Application;
        }

        public List<Action> GetActions()
        {
            return Actions;
        }

        public List<ClaimSet> GetClaimSets()
        {
            return ClaimSets;
        }

        public List<ResourceClaim> GetResourceClaims()
        {
            return ResourceClaims;
        }

        public List<AuthorizationStrategy> GetAuthorizationStrategies()
        {
            return AuthorizationStrategies;
        }

        public List<ClaimSetResourceClaim> GetClaimSetResourceClaims()
        {
            return ClaimSetResourceClaims;
        }

        public List<ResourceClaimAuthorizationMetadata> GetResourceClaimAuthorizationMetadata()
        {
            return ResourceClaimAuthorizationMetadata;
        }

        public void ReInitialize(
            Application application,
            List<Action> actions,
            List<ClaimSet> claimSets,
            List<ResourceClaim> resourceClaims,
            List<AuthorizationStrategy> authorizationStrategies,
            List<ClaimSetResourceClaim> claimSetResourceClaims,
            List<ResourceClaimAuthorizationMetadata> resourceClaimAuthorizationMetadata)
        {
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

    public class OwinSecurityData
    {
        public Application Application { get; set; }

        public List<Action> Actions { get; set; }

        public List<ClaimSet> ClaimSets { get; set; }

        public List<ResourceClaim> ResourceClaims { get; set; }

        public List<AuthorizationStrategy> AuthorizationStrategies { get; set; }

        public List<ClaimSetResourceClaim> ClaimSetResourceClaims { get; set; }

        public List<ResourceClaimAuthorizationMetadata> ResourceClaimAuthorizationMetadata { get; set; }
    }
}
