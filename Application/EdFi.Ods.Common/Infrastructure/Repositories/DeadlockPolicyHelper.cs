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
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public static class DeadlockPolicyHelper
{
    public static AsyncRetryPolicy RetryPolicy { get; }

    public static int RetryCount = 5;
    public static int RetryStartingDelayMilliseconds = 100;

    private static int _totalRetries = 0;

    static DeadlockPolicyHelper()
    {
        RetryPolicy = Policy.Handle<Exception>(ShouldRetry)
            .WaitAndRetryAsync(
                Backoff.ExponentialBackoff(TimeSpan.FromMilliseconds(RetryStartingDelayMilliseconds), RetryCount),
                onRetry: (result, ts, retryAttempt, context) =>
                {
                    Interlocked.Increment(ref _totalRetries);

                    var logger = context["Logger"] as ILog;

                    if (logger?.IsWarnEnabled == true)
                    {
                        logger.Warn(
                            $"Deadlock exception encountered during '{context["EntityTypeName"]}' entity persistence. Retrying transaction (attempt #{retryAttempt + 1} of {RetryCount + 1} after {ts.TotalMilliseconds:N0}ms). {_totalRetries} total retries...");
                    }
                });
    }

    /// <summary>
    /// Indicates whether the exception of the NHibernate persistence should be handled by the retry policy in the controller.
    /// </summary>
    /// <param name="exception">The exception of the pipeline execution call.</param>
    /// <returns><b>true</b> if the result should be handled by the retry policy; otherwise <b>false</b>.</returns>
    private static bool ShouldRetry(Exception exception)
    {
        // Exit quickly if no exception is present (no retries necessary)
        if (exception == null)
        {
            return false;
        }
        
        // SQL Server deadlock detection
        if ((exception.InnerException as SqlException)?.Message?.Contains("deadlocked") == true)
        {
            return true;
        }

        // PostgreSQL deadlock detection
        if ((exception.InnerException as PostgresException)?.Message?.Contains("deadlock") == true)
        {
            return true;
        }

        return false;
    }
}
