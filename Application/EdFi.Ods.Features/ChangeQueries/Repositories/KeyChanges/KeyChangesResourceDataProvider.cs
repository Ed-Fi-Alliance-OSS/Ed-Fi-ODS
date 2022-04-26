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
        // private readonly IKeyChangesQueryBuilderFactory _keyChangesQueryBuilderFactory;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public KeyChangesResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IKeyChangesQueryTemplatePreparer keyChangesQueryTemplatePreparer,
            IDatabaseNamingConvention namingConvention,
            // IKeyChangesQueryBuilderFactory keyChangesQueryBuilderFactory,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
            : base(dbProviderFactory, odsDatabaseConnectionStringProvider, keyChangesQueryTemplatePreparer, namingConvention)
        {
            // _keyChangesQueryBuilderFactory = keyChangesQueryBuilderFactory;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        public async Task<ResourceData<KeyChange>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            // var keyChangesQueryBuilder = _keyChangesQueryBuilderFactory.CreateQueryBuilder(resource);
            
            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            return await base.GetResourceDataAsync(
                resource,
                queryParameters,
                // keyChangesQueryBuilder,
                itemData => 
                    new KeyChange
                    {
                        Id = (Guid)itemData[IdColumnName],
                        ChangeVersion = (long) itemData[ChangeVersionColumnName],
                        OldKeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroups.OldValue),
                        NewKeyValues = GetIdentifierKeyValues(identifierProjections, itemData, ColumnGroups.NewValue),
                    });
        }
    }
}
