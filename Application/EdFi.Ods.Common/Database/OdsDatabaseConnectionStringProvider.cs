﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using log4net;

namespace EdFi.Ods.Common.Database
{
    public class OdsDatabaseConnectionStringProvider : IOdsDatabaseConnectionStringProvider
    {
        private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceContextProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(OdsDatabaseConnectionStringProvider));
        private readonly IOdsDatabaseAccessIntentProvider _odsDatabaseAccessIntentProvider;

        public OdsDatabaseConnectionStringProvider(IContextProvider<OdsInstanceConfiguration> odsInstanceContextProvider, IOdsDatabaseAccessIntentProvider odsDatabaseAccessIntentProvider)
        {
            _odsInstanceContextProvider = odsInstanceContextProvider;
            _odsDatabaseAccessIntentProvider = odsDatabaseAccessIntentProvider;
        }

        public string GetConnectionString()
        {
            var odsInstanceConfiguration = _odsInstanceContextProvider.Get();

            if (odsInstanceConfiguration == null)
            {
                throw new InvalidOperationException("No ODS instance has been identified for the current request.");
            }

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"Getting connection string for ODS instance '{odsInstanceConfiguration.OdsInstanceId}' (with hash id '{odsInstanceConfiguration.OdsInstanceHashId}') from context...");
            }

            if (odsInstanceConfiguration.ReadReplicaConnectionString == null)
            {
                return odsInstanceConfiguration.ConnectionString;
            }

            return _odsDatabaseAccessIntentProvider.GetDatabaseAccessIntent() == DatabaseAccessIntent.ReadOnly
                ? odsInstanceConfiguration.ReadReplicaConnectionString
                : odsInstanceConfiguration.ConnectionString;
        }

        public string GetReadReplicaConnectionString()
        {
            var odsInstanceConfiguration = _odsInstanceContextProvider.Get();

            if (odsInstanceConfiguration == null)
            {
                throw new InvalidOperationException("No ODS instance has been identified for the current request.");
            }

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"Getting read-replica connection string for ODS instance '{odsInstanceConfiguration.OdsInstanceId}' (with hash id '{odsInstanceConfiguration.OdsInstanceHashId}') from context...");
            }

            return odsInstanceConfiguration.ReadReplicaConnectionString;
        }
    }
}