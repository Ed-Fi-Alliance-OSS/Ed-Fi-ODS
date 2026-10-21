// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using log4net;
using Microsoft.Data.SqlClient;
using Npgsql;
using Polly;
using Polly.Retry;

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public static class DeadlockPolicyHelper
{
    /// <summary>
    /// Key for the <see cref="ILog" /> used to report retries, set by the caller on the <see cref="ResilienceContext" />.
    /// </summary>
    public static readonly ResiliencePropertyKey<ILog> LoggerKey = new("Logger");

    /// <summary>
    /// Key for the name of the entity being persisted, set by the caller on the <see cref="ResilienceContext" />.
    /// </summary>
    public static readonly ResiliencePropertyKey<string> EntityTypeNameKey = new("EntityTypeName");

    /// <summary>
    /// Key for the number of retries performed so far, set by the retry policy on the <see cref="ResilienceContext" />
    /// before each retry attempt.
    /// </summary>
    public static readonly ResiliencePropertyKey<int> RetriesKey = new("Retries");

    private const int RetryCount = 5;
    private static readonly TimeSpan RetryStartingDelay = TimeSpan.FromMilliseconds(100);

    private static int _cumulativeRetries = 0;

    public static ResiliencePipeline RetryPolicy { get; }

    static DeadlockPolicyHelper()
    {
        RetryPolicy = CreatePipeline(RetryStartingDelay);
    }

    /// <summary>
    /// Creates the deadlock retry pipeline (exponential backoff without jitter, e.g. 100, 200, 400, 800 and 1600ms
    /// for a starting delay of 100ms).
    /// </summary>
    /// <param name="startingDelay">The delay before the first retry, doubled for each subsequent retry.</param>
    /// <param name="timeProvider">The time provider used for the delays (defaults to the system time provider).</param>
    internal static ResiliencePipeline CreatePipeline(TimeSpan startingDelay, TimeProvider timeProvider = null)
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
                    ShouldHandle = new PredicateBuilder().Handle<Exception>(IsDeadlockError),
                    MaxRetryAttempts = RetryCount,
                    Delay = startingDelay,
                    BackoffType = DelayBackoffType.Exponential,
                    UseJitter = false,
                    OnRetry = args =>
                    {
                        Interlocked.Increment(ref _cumulativeRetries);

                        // AttemptNumber is zero-based (the Polly v7 retry attempt was one-based)
                        int retryAttempt = args.AttemptNumber + 1;

                        args.Context.Properties.Set(RetriesKey, retryAttempt);

                        args.Context.Properties.TryGetValue(LoggerKey, out var logger);

                        if (logger?.IsWarnEnabled == true)
                        {
                            args.Context.Properties.TryGetValue(EntityTypeNameKey, out var entityTypeName);

                            logger.Warn(
                                $"Deadlock exception encountered during '{entityTypeName}' entity persistence. Retrying transaction (with attempt #{retryAttempt + 1} overall of {RetryCount + 1} total in {args.RetryDelay.TotalMilliseconds:N0}ms). (Cumulative total retries: {_cumulativeRetries})...");
                        }

                        return default;
                    }
                })
            .Build();
    }

    /// <summary>
    /// Indicates whether the exception of the NHibernate persistence should be handled by the retry policy in the controller.
    /// </summary>
    /// <param name="exception">The exception of the pipeline execution call.</param>
    /// <returns><b>true</b> if the result should be handled by the retry policy; otherwise <b>false</b>.</returns>
    private static bool IsDeadlockError(Exception exception)
    {
        // Exit quickly if no exception is present (no retries necessary)
        if (exception == null)
        {
            return false;
        }

        // SQL Server deadlock detection
        if (exception.InnerException is SqlException { Number: 1205 })
        {
            return true;
        }

        // PostgreSQL deadlock detection
        if (exception.InnerException is PostgresException { SqlState: PostgresErrorCodes.DeadlockDetected })
        {
            return true;
        }

        return false;
    }
}
