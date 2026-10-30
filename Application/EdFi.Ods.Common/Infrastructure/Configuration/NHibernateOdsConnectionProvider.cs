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
using Polly.Retry;

namespace EdFi.Ods.Common.Infrastructure.Configuration
{
    public class NHibernateOdsConnectionProvider : DriverConnectionProvider
    {
        public const string UseReadWriteConnectionCacheKey = "UseReadWriteConnection";

        private const int RetryCount = 5;
        private static readonly TimeSpan RetryStartingDelay = TimeSpan.FromSeconds(1);

        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;

        private readonly ILog _logger = LogManager.GetLogger(typeof(NHibernateOdsConnectionProvider));

        private readonly ResiliencePipeline _connectionRetryPolicy;

        public NHibernateOdsConnectionProvider(IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
            _connectionRetryPolicy = CreateConnectionRetryPipeline(_logger);
        }

        /// <summary>
        /// Creates the connection retry pipeline (exponential backoff without jitter of 1, 2, 4, 8 and 16 seconds),
        /// retrying on any exception except <see cref="EdFiProblemDetailsExceptionBase" />.
        /// </summary>
        /// <param name="logger">The logger used to report retries.</param>
        /// <param name="timeProvider">The time provider used for the delays (defaults to the system time provider).</param>
        internal static ResiliencePipeline CreateConnectionRetryPipeline(ILog logger, TimeProvider timeProvider = null)
        {
            var builder = new ResiliencePipelineBuilder();

            if (timeProvider != null)
            {
                builder.TimeProvider = timeProvider;
            }

            return builder
                .AddRetry(
                    new RetryStrategyOptions
                    {
                        // Retry on any exception except EdFiProblemDetailsExceptionBase
                        ShouldHandle = new PredicateBuilder().Handle<Exception>(ex => ex is not EdFiProblemDetailsExceptionBase),
                        MaxRetryAttempts = RetryCount,
                        Delay = RetryStartingDelay,
                        BackoffType = DelayBackoffType.Exponential,
                        UseJitter = false,
                        OnRetry = args =>
                        {
                            // AttemptNumber is zero-based (the Polly v7 retry attempt was one-based)
                            logger.Warn($"Retry attempt {args.AttemptNumber + 1} of {RetryCount}: Retrying connection in {args.RetryDelay.TotalSeconds} seconds due to exception: {args.Outcome.Exception?.Message}");

                            return default;
                        }
                    })
                .Build();
        }

        public override DbConnection GetConnection()
        {
            var connection = Driver.CreateConnection();

            try
            {
                connection.ConnectionString = _connectionStringProvider.GetConnectionString();

                // Execute the Open method with the retry policy
                _connectionRetryPolicy.Execute(() => connection.Open());
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