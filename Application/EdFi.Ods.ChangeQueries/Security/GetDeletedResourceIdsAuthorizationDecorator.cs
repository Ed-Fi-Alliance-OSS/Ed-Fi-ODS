// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization.Repositories;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.ChangeQueries.Security
{
    public class GetDeletedResourceIdsAuthorizationDecorator<T>
        : RepositoryOperationAuthorizationDecoratorBase<T>, IGetDeletedResourceIds
        where T : class, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetDeletedResourceIds _next;
        private readonly ISecurityRepository _securityRepository;

        public GetDeletedResourceIdsAuthorizationDecorator(
            IGetDeletedResourceIds next,
            ISecurityRepository securityRepository,
            IAuthorizationContextProvider authorizationContextProvider,
            IEdFiAuthorizationProvider authorizationProvider)
            : base(authorizationContextProvider, authorizationProvider)
        {
            _next = next;
            _securityRepository = securityRepository;
        }

        public IReadOnlyList<DeletedResource> Execute(string schema, string resource, IQueryParameters queryParameters)
        {
            return null;
        }
    }
}
