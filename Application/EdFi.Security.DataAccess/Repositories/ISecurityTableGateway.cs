// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Security.DataAccess.Models;

namespace EdFi.Security.DataAccess.Repositories;

public interface ISecurityTableGateway
{
    Application GetApplication();

    List<Action> GetActions();

    List<ClaimSet> GetClaimSets();

    List<ResourceClaim> GetResourceClaims(int applicationId);

    List<AuthorizationStrategy> GetAuthorizationStrategies(int applicationId);

    List<ClaimSetResourceClaimAction> GetClaimSetResourceClaimActions(int applicationId);

    List<ResourceClaimAction> GetResourceClaimActionAuthorizations(int applicationId);
}
