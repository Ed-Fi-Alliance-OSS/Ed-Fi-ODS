// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Features.ChangeQueries.SnapshotContext;

namespace EdFi.Ods.Features.ChangeQueries.Providers
{
    public class SnapshotOdsDatabaseConnectionStringProviderDecorator : IOdsDatabaseConnectionStringProvider
    {
        private readonly IOdsDatabaseConnectionStringProvider _next;
        private readonly IContextProvider<SnapshotUsage> _snapshotContextProvider;
        private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceContextProvider;

        public SnapshotOdsDatabaseConnectionStringProviderDecorator(IOdsDatabaseConnectionStringProvider next,
            IContextProvider<SnapshotUsage> snapshotContextProvider,
            IContextProvider<OdsInstanceConfiguration> odsInstanceContextProvider)
        {
            _next = next;
            _snapshotContextProvider = snapshotContextProvider;
            _odsInstanceContextProvider = odsInstanceContextProvider;
        }

        public string GetConnectionString()
        {
            var snapshotContext = _snapshotContextProvider.Get();

            if (snapshotContext == SnapshotUsage.Off)
            {
                return _next.GetConnectionString();
            }

            return GetSnapshotConnectionString();
        }

        public string GetReadReplicaConnectionString()
        {
            var snapshotContext = _snapshotContextProvider.Get();

            if (snapshotContext == SnapshotUsage.Off)
            {
                return _next.GetReadReplicaConnectionString();
            }

            return GetSnapshotConnectionString();
        }

        private string GetSnapshotConnectionString()
        {
            return _odsInstanceContextProvider.Get().ConnectionStringByDerivativeType[DerivativeType.Snapshot];
        }
    }
}
