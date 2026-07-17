// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Features.ExternalCache.Redis;
using NUnit.Framework;
using Polly.CircuitBreaker;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.ExternalCache.Redis;

[TestFixture]
public class RedisCacheResilienceTests
{
    [Test]
    public void Pipeline_ShouldExecuteSuccessfully_WhenNoFailures()
    {
        var resilience = new RedisCacheResilience();

        Should.NotThrow(() => resilience.Pipeline.Execute(() => { }));
    }

    [Test]
    public void Pipeline_ShouldNotOpenCircuit_BelowMinimumThroughput()
    {
        var resilience = new RedisCacheResilience();

        for (var i = 0; i < 3; i++)
        {
            Should.Throw<InvalidOperationException>(() => resilience.Pipeline.Execute(() => throw new InvalidOperationException("boom")));
        }

        Should.NotThrow(() => resilience.Pipeline.Execute(() => { }));
    }

    [Test]
    public void Pipeline_ShouldOpenCircuit_AfterReachingFailureThreshold()
    {
        var resilience = new RedisCacheResilience();

        for (var i = 0; i < 5; i++)
        {
            Should.Throw<InvalidOperationException>(() => resilience.Pipeline.Execute(() => throw new InvalidOperationException("boom")));
        }

        Should.Throw<BrokenCircuitException>(() => resilience.Pipeline.Execute(() => { }));
    }

    [Test]
    public async Task Pipeline_ShouldRespectCustomThresholdAndDuration()
    {
        var resilience = new RedisCacheResilience(failureThreshold: 2, breakDurationSeconds: 1);

        for (var i = 0; i < 2; i++)
        {
            Should.Throw<InvalidOperationException>(() => resilience.Pipeline.Execute(() => throw new InvalidOperationException("boom")));
        }

        Should.Throw<BrokenCircuitException>(() => resilience.Pipeline.Execute(() => { }));

        await Task.Delay(TimeSpan.FromMilliseconds(1200));

        Should.NotThrow(() => resilience.Pipeline.Execute(() => { }));
    }

    [Test]
    public async Task Pipeline_ShouldAllowProbeAfterBreakDuration()
    {
        var resilience = new RedisCacheResilience(failureThreshold: 2, breakDurationSeconds: 1);

        for (var i = 0; i < 2; i++)
        {
            Should.Throw<InvalidOperationException>(() => resilience.Pipeline.Execute(() => throw new InvalidOperationException("boom")));
        }

        Should.Throw<BrokenCircuitException>(() => resilience.Pipeline.Execute(() => { }));

        await Task.Delay(TimeSpan.FromMilliseconds(1200));

        var probeExecutionCount = 0;

        Should.NotThrow(() => resilience.Pipeline.Execute(() => probeExecutionCount++));
        probeExecutionCount.ShouldBe(1);
    }
}
