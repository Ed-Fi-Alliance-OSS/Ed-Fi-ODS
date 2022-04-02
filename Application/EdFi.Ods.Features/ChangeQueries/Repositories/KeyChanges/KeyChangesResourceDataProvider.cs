// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesResourceDataProvider
        : TrackedChangesResourceDataProviderBase<KeyChange>, IKeyChangesResourceDataProvider
    {
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly IKeyChangesQueryFactory _keyChangesQueryFactory;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public KeyChangesResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IKeyChangesQueriesPreparer keyChangesQueriesPreparer,
            IDatabaseNamingConvention namingConvention,
            IKeyChangesQueryFactory keyChangesQueryFactory,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
            : base(dbProviderFactory, odsDatabaseConnectionStringProvider, keyChangesQueriesPreparer, namingConvention)
        {
            _namingConvention = namingConvention;
            _keyChangesQueryFactory = keyChangesQueryFactory;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        public async Task<ResourceData<KeyChange>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            var changeWindowCteQuery = _keyChangesQueryFactory.CreateMainQuery(resource);
            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            string changeVersionColumnName = _namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName);
            string idColumnName = _namingConvention.ColumnName("Id");
            
            return await base.GetResourceDataAsync(
                resource,
                queryParameters,
                changeWindowCteQuery,
                itemData => 
                    new KeyChange
                    {
                        Id = (Guid)itemData[idColumnName],
                        ChangeVersion = (long) itemData[changeVersionColumnName],
                        OldKeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroups.OldValue),
                        NewKeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroups.NewValue),
                    });
        }
    }
}
