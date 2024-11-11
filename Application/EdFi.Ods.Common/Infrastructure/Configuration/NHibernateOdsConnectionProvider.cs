// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using log4net;
using NHibernate.Connection;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class NHibernateOdsConnectionProvider : DriverConnectionProvider
    {
        public const string UseReadWriteConnectionCacheKey = "UseReadWriteConnection";
        
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(NHibernateOdsConnectionProvider));
        
        public NHibernateOdsConnectionProvider(IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public override DbConnection GetConnection()
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString = _connectionStringProvider.GetConnectionString();

                // Define a retry policy with exponential backoff
                var retryPolicy = Policy
                    .Handle<Exception>(ex => !(ex is EdFiProblemDetailsExceptionBase)) // Retry on any exception except EdFiProblemDetailsExceptionBase
                    .WaitAndRetry(Backoff.ExponentialBackoff(
                        initialDelay: TimeSpan.FromSeconds(1), // Initial retry delay
                        retryCount: 5),
                        onRetry: (exception, timeSpan, retryAttempt, context) =>
                        {
                            _logger.Warn($"Retry attempt {retryAttempt} of 5: Retrying connection in {timeSpan.TotalSeconds} seconds due to exception: {exception.Message}");
                        });

                // Execute the Open method with the retry policy
                retryPolicy.Execute(() => connection.Open());
            }
            catch (EdFiProblemDetailsExceptionBase)
            {
                connection.Dispose();

                // Throw the problem details exception, as-is
                throw;
            }
            catch (Exception ex)
            {
                connection.Dispose();

                // Wrap the underlying exception with a user-facing exception. 
                throw new DatabaseConnectionException("Unable to open connection to the ODS database.", ex);
            }

            return connection;
        }

        public override async Task<DbConnection> GetConnectionAsync(CancellationToken cancellationToken)
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString =  _connectionStringProvider.GetConnectionString();

                await connection.OpenAsync(cancellationToken);
            }
            catch (EdFiProblemDetailsExceptionBase)
            {
                connection.Dispose();

                // Throw the problem details exception, as-is
                throw;
            }
            catch (Exception ex)
            {
                connection.Dispose();

                // Wrap the underlying exception with a user-facing exception. 
                throw new DatabaseConnectionException("Unable to open connection to the ODS database.", ex);
            }

            return connection;
        }
    }
}