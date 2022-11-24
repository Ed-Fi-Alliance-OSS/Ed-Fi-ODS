// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EdFi.Admin.DataAccess.Providers;
using log4net;

namespace EdFi.Admin.DataAccess.Authentication
{
    public class ExpiredAccessTokenDeleter : IExpiredAccessTokenDeleter
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;

        private const string DeleteSql = "DELETE FROM dbo.ClientAccessTokens WHERE Expiration <= @p0;";

        private readonly ILog _logger = LogManager.GetLogger(typeof(ExpiredAccessTokenDeleter));
        
        public ExpiredAccessTokenDeleter(
            DbProviderFactory dbProviderFactory,
            IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider)
        {
            _dbProviderFactory = dbProviderFactory;
            _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        }

        public async Task DeleteExpiredTokensAsync()
        {
            await using var connection = _dbProviderFactory.CreateConnection();
            connection.ConnectionString = _adminDatabaseConnectionStringProvider.GetConnectionString();
            await connection.OpenAsync();

            int recordsAffected = await connection.ExecuteAsync(DeleteSql, DateTime.UtcNow);

            if (recordsAffected > 0)
            {
                _logger.Debug($"{recordsAffected} expired access tokens were deleted.");
            }
        }
    }
}
