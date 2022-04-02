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

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsResourceDataProvider 
        : TrackedChangesResourceDataProviderBase<DeletedResourceItem>, IDeletedItemsResourceDataProvider
    {
        private readonly IDeletedItemsQueryFactory _deletedItemsQueryFactory;
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public DeletedItemsResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IDeletedItemsQueriesPreparer deletedItemsQueriesPreparer,
            IDeletedItemsQueryFactory deletedItemsQueryFactory,
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
            : base(dbProviderFactory, odsDatabaseConnectionStringProvider, deletedItemsQueriesPreparer, namingConvention)
        {
            _deletedItemsQueryFactory = deletedItemsQueryFactory;
            _namingConvention = namingConvention;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        public async Task<ResourceData<DeletedResourceItem>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            var templateQuery = _deletedItemsQueryFactory.CreateMainQuery(resource);
            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            string changeVersionColumnName = _namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName);
            string idColumnName = _namingConvention.ColumnName("Id");

            return await base.GetResourceDataAsync(
                resource, 
                queryParameters, 
                templateQuery, 
                itemData => 
                    new DeletedResourceItem
                    { 
                        Id = (Guid) itemData[idColumnName],
                        ChangeVersion = (long) itemData[changeVersionColumnName],
                        KeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroups.OldValue),
                    });
        }
    }
}
