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

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsResourceDataProvider : TrackedChangesResourceDataProviderBase<DeletedResourceItem>, IDeletedItemsResourceDataProvider
    {
        private readonly IDeletedItemsTemplateQueryProvider _deletedItemsTemplateQueryProvider;
        private readonly IDatabaseNamingConvention _namingConvention;

        public DeletedItemsResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            ITrackedChangesQueriesProvider trackedChangesQueriesProvider,
            IDeletedItemsTemplateQueryProvider deletedItemsTemplateQueryProvider,
            IDatabaseNamingConvention namingConvention)
            : base(dbProviderFactory, odsDatabaseConnectionStringProvider, trackedChangesQueriesProvider, namingConvention)
        {
            _deletedItemsTemplateQueryProvider = deletedItemsTemplateQueryProvider;
            _namingConvention = namingConvention;
        }

        public async Task<ResourceData<DeletedResourceItem>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            var identifierProjections = _deletedItemsTemplateQueryProvider.GetIdentifierProjections(resource);
            var templateQuery = _deletedItemsTemplateQueryProvider.GetTemplateQuery(resource);

            return await base.GetResourceDataAsync(
                resource, 
                queryParameters, 
                templateQuery, 
                itemData => 
                    new DeletedResourceItem
                    { 
                        Id = (Guid) itemData[_namingConvention.ColumnName("Id")],
                        ChangeVersion = (long) itemData[_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)],
                        KeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroup.OldValue),
                    });
        }
    }
}
