// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges;
using EdFi.Ods.Generator.Database.NamingConventions;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Authorization
{
    public class DeletedItemsQueryFactoryAuthorizationDecorator : TrackedChangesQueryFactoryAuthorizationDecoratorBase, IDeletedItemsQueryFactory
    {
        private readonly IDeletedItemsQueryFactory _next;

        public DeletedItemsQueryFactoryAuthorizationDecorator(
            IDeletedItemsQueryFactory next,
            IAuthorizationContextProvider authorizationContextProvider,
            IEdFiAuthorizationProvider edFiAuthorizationProvider,
            IDatabaseNamingConvention namingConvention,
            IDomainModelProvider domainModelProvider,
            IDomainModelEnhancer domainModelEnhancer)
            : base(authorizationContextProvider, edFiAuthorizationProvider, namingConvention, domainModelProvider, domainModelEnhancer)
        {
            _next = next;
        }
        
        public Query CreateMainQuery(Resource resource)
        {
            var mainQuery = _next.CreateMainQuery(resource);
            
            ApplyAuthorizationFilters(resource, mainQuery);

            return mainQuery;
        }
    }
}
