// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;
using EdFi.Ods.Generator.Database.NamingConventions;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesResourceDataProvider : TrackedChangesResourceDataProviderBase<KeyChange>, IKeyChangesResourceDataProvider
    {
        private readonly IKeyChangesTemplateQueryProvider _keyChangesTemplateQueryProvider;
        private readonly IDatabaseNamingConvention _namingConvention;

        public KeyChangesResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IKeyChangesTemplateQueryProvider keyChangesTemplateQueryProvider,
            ITrackedChangesQueriesProvider trackedChangesQueriesProvider,
            IDatabaseNamingConvention namingConvention)
            : base(dbProviderFactory, odsDatabaseConnectionStringProvider, trackedChangesQueriesProvider, namingConvention)
        {
            _keyChangesTemplateQueryProvider = keyChangesTemplateQueryProvider;
            _namingConvention = namingConvention;
        }

        public async Task<ResourceData<KeyChange>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            var identifierProjections = _keyChangesTemplateQueryProvider.GetIdentifierProjections(resource);
            var templateQuery = _keyChangesTemplateQueryProvider.GetTemplateQuery(resource);

            return await base.GetResourceDataAsync(
                resource,
                queryParameters,
                templateQuery,
                itemData => 
                    new KeyChange
                    {
                        Id = (Guid) itemData[_namingConvention.ColumnName("Id")],
                        ChangeVersion = (long) itemData[_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)],
                        OldKeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroup.OldValue),
                        NewKeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroup.NewValue),
                    });
        }
    }
}
