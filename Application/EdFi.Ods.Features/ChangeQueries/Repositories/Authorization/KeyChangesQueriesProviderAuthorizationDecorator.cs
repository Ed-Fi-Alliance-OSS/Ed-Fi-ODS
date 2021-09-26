// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges;
using EdFi.Ods.Generator.Database.NamingConventions;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Authorization
{
    public class KeyChangesQueriesProviderAuthorizationDecorator
        : TrackedChangesQueriesProviderAuthorizationDecorator, IKeyChangesQueriesProvider
    {
        public KeyChangesQueriesProviderAuthorizationDecorator(
            IAuthorizationContextProvider authorizationContextProvider,
            IEdFiAuthorizationProvider edFiAuthorizationProvider,
            IDomainModelProvider domainModelProvider,
            IDomainModelEnhancer domainModelEnhancer,
            IDatabaseNamingConvention namingConvention,
            IKeyChangesQueriesProvider next)
            : base(
                authorizationContextProvider,
                edFiAuthorizationProvider,
                domainModelProvider,
                domainModelEnhancer,
                namingConvention,
                next) { }
    }
}
