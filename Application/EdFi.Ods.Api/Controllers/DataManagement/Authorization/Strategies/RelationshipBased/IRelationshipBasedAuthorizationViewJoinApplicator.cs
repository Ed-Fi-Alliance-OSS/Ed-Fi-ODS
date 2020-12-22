// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Common.Infrastructure.Filtering;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Strategies.RelationshipBased
{
    // TODO: Simple API - Need better name to distinguish from IRelationshipBasedAuthorizationFilterApplicator
    public interface IRelationshipBasedAuthorizationViewJoinApplicator
    {
        void ApplyAuthorizationViewJoin(
            SqlBuilder sqlBuilder,
            AliasGenerator authViewAliasGenerator,
            RelationshipBasedAuthorizationFilterDetails authorizationFilterDetails);
    }
}
