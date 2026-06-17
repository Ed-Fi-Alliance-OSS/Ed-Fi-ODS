// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using log4net;
using Polly;
using Polly.CircuitBreaker;

namespace EdFi.Ods.Features.ExternalCache.Redis;

/// <summary>
/// Provides resilience policies for Redis cache operations.
/// </summary>
public class RedisCacheResilience
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(RedisCacheResilience));

    /// <summary>
    /// Gets the circuit breaker pipeline for Redis operations.
    /// </summary>
    public ResiliencePipeline Pipeline { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RedisCacheResilience"/> class.
    /// </summary>
    /// <param name="failureThreshold">The minimum throughput required before the circuit breaker evaluates failures.</param>
    /// <param name="breakDurationSeconds">The number of seconds to keep the circuit open.</param>
    /// <param name="samplingDurationSeconds">
    /// The window over which failures are evaluated. This must be larger than the Redis operation timeout;
    /// otherwise failing calls age out of the window before the threshold is reached and the circuit never
    /// opens (leaving every request to block on the full timeout).
    /// </param>
    public RedisCacheResilience(int failureThreshold = 5, int breakDurationSeconds = 30, int samplingDurationSeconds = 30)
    {
        Pipeline = new ResiliencePipelineBuilder()
            .AddCircuitBreaker(new CircuitBreakerStrategyOptions
            {
                FailureRatio = 0.5,
                SamplingDuration = TimeSpan.FromSeconds(samplingDurationSeconds),
                MinimumThroughput = failureThreshold,
                BreakDuration = TimeSpan.FromSeconds(breakDurationSeconds),
                OnOpened = args =>
                {
                    _logger.Error($"Redis circuit breaker OPENED for {breakDurationSeconds}s after repeated failures.");
                    return ValueTask.CompletedTask;
                },
                OnClosed = args =>
                {
                    _logger.Info("Redis circuit breaker CLOSED — Redis operations resuming normally.");
                    return ValueTask.CompletedTask;
                },
                OnHalfOpened = args =>
                {
                    _logger.Info("Redis circuit breaker HALF-OPEN — testing Redis connectivity.");
                    return ValueTask.CompletedTask;
                }
            })
            .Build();
    }
}
