// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Database
{
    public class OdsDatabaseConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceContextProvider;

        public OdsDatabaseConnectionStringProvider(IContextProvider<OdsInstanceConfiguration> odsInstanceContextProvider)
        {
            _odsInstanceContextProvider = odsInstanceContextProvider;
        }

        public string GetConnectionString() => _odsInstanceContextProvider.Get().ConnectionString;

        public string GetReadReplicaConnectionString() => _odsInstanceContextProvider.Get().ConnectionString;
    }
}
