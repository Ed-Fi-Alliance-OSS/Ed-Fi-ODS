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
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public DeletedItemsResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IDeletedItemsQueryTemplatePreparer deletedItemsQueryTemplatePreparer,
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
            : base(dbProviderFactory, odsDatabaseConnectionStringProvider, deletedItemsQueryTemplatePreparer, namingConvention)
        {
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        public async Task<ResourceData<DeletedResourceItem>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            return await base.GetResourceDataAsync(
                resource, 
                queryParameters, 
                itemData => 
                    new DeletedResourceItem
                    { 
                        Id = (Guid) itemData[IdColumnName],
                        ChangeVersion = (long) itemData[ChangeVersionColumnName],
                        KeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroups.OldValue),
                    });
        }
    }
}
