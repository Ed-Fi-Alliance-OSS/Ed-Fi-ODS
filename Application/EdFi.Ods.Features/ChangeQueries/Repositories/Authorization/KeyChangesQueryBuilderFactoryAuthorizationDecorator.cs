// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain.DomainModelEnhancers;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Authorization
{
    public class KeyChangesQueryBuilderFactoryAuthorizationDecorator
        : TrackedChangesQueryFactoryAuthorizationDecoratorBase, IKeyChangesQueryBuilderFactory
    {
        private readonly IKeyChangesQueryBuilderFactory _next;

        public KeyChangesQueryBuilderFactoryAuthorizationDecorator(
            IKeyChangesQueryBuilderFactory next,
            IDomainModelProvider domainModelProvider,
            IDomainModelEnhancer domainModelEnhancer,
            IDataManagementAuthorizationPlanFactory dataManagementAuthorizationPlanFactory,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            ISecurityRepository securityRepository)
            : base(
                domainModelProvider,
                domainModelEnhancer,
                dataManagementAuthorizationPlanFactory,
                authorizationFilterDefinitionProvider,
                securityRepository)
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
