// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;

namespace Test.Common._Stubs
{
    public class StubSecurityRepository : ISecurityRepository
    {
        public Action GetActionByName(string actionName)
        {
            return new Action
            {
                ActionId = 1,
                ActionName = actionName,
                ActionUri = "http://ed-fi.org/ods/actions/" + actionName.ToLowerInvariant()
            };
        }

        public AuthorizationStrategy GetAuthorizationStrategyByName(string authorizationStrategyName)
        {
            return new AuthorizationStrategy
            {
                Application = new Application {ApplicationId = 1},
                AuthorizationStrategyId = 1,
                AuthorizationStrategyName = authorizationStrategyName,
                DisplayName = authorizationStrategyName
            };
        }

        public IEnumerable<ClaimSetResourceClaimAction> GetClaimsForClaimSet(string claimSetName)
        {
            return new List<ClaimSetResourceClaimAction>();
        }

        public IEnumerable<string> GetResourceClaimLineage(string resourceUri)
        {
            return new List<string>();
        }

        public IEnumerable<ResourceClaimAction> GetResourceClaimLineageMetadata(string resourceClaimUri, string action)
        {
            return new List<ResourceClaimAction>();
        }

        public Action GetActionByHttpVerb(string httpVerb)
        {
            var actionName = string.Empty;

            switch (httpVerb)
            {
                case "GET":
                    actionName = "Read";
                    break;

                case "POST":
                    actionName = "Upsert";
                    break;

                case "PUT":
                    actionName = "Update";
                    break;

                case "DELETE":
                    actionName = "Delete";
                    break;
            }

            return GetActionByName(actionName);
        }

        public ResourceClaim GetResourceByResourceName(string resourceName)
        {
            return new ResourceClaim {ResourceName = resourceName};
        }
    }
}
