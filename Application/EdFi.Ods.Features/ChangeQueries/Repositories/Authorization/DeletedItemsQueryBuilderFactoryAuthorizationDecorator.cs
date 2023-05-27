// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Authorization
{
    public class DeletedItemsQueryBuilderFactoryAuthorizationDecorator
        : TrackedChangesQueryFactoryAuthorizationDecoratorBase, IDeletedItemsQueryBuilderFactory
    {
        private readonly IDeletedItemsQueryBuilderFactory _next;

        public DeletedItemsQueryBuilderFactoryAuthorizationDecorator(
            IDeletedItemsQueryBuilderFactory next,
            IAuthorizationContextProvider authorizationContextProvider,
            IApiKeyContextProvider apiKeyContextProvider,
            IDomainModelProvider domainModelProvider,
            IDomainModelEnhancer domainModelEnhancer,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IClaimSetClaimsProvider claimSetClaimsProvider)
            : base(
                authorizationContextProvider,
                apiKeyContextProvider,
                domainModelProvider,
                domainModelEnhancer,
                authorizationFilteringProvider,
                authorizationBasisMetadataSelector,
                authorizationFilterDefinitionProvider,
                dataManagementResourceContextProvider,
                claimSetClaimsProvider)
        {
            _next = next;
        }

        public QueryBuilder CreateQueryBuilder(Resource resource)
        {
            var queryBuilder = _next.CreateQueryBuilder(resource);

            ApplyAuthorizationFilters(resource, queryBuilder);

            return queryBuilder;
        }
    }
}
