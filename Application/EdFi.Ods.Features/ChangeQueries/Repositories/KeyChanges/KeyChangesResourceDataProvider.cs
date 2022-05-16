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
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesResourceDataProvider
        : TrackedChangesResourceDataProviderBase<KeyChange>, IKeyChangesResourceDataProvider
    {
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public KeyChangesResourceDataProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider,
            IKeyChangesQueryTemplatePreparer keyChangesQueryTemplatePreparer,
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
            : base(dbProviderFactory, odsDatabaseConnectionStringProvider, keyChangesQueryTemplatePreparer, namingConvention)
        {
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        public async Task<ResourceData<KeyChange>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        {
            // We won't support keyChanges for descriptors (which would require special query handling anyway), so we just return an empty result with count of 0.
            if (resource.Entity.IsDescriptorEntity)
            {
                return new ResourceData<KeyChange>()
                {
                    Items = Array.Empty<KeyChange>(),
                    Count = 0
                };
            }
            
            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            return await base.GetResourceDataAsync(
                resource,
                queryParameters,
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
