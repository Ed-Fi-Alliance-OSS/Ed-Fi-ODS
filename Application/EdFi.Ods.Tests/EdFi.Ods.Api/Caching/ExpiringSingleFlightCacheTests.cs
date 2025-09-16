// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

[TestFixture]
public class ExpiringSingleFlightCacheTests
{
    private static readonly TimeSpan _expirationPeriod = TimeSpan.FromMilliseconds(250);

    [Test]
    public async Task Cache_ShouldPreventThunderingHerd_WhenExpiringEntireCache()
    {
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>("TestCache", _expirationPeriod);

        string cacheKey = "ThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;

        object ValueFactory(string key, TimeSpan workDuration)
        {
            // Simulate expensive computation
            Thread.Sleep(workDuration);
            Interlocked.Increment(ref computationCount);
            return computedValue;
        }

        object GetOrComputeValue()
        {
            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                TimeSpan.FromMilliseconds(100),
                TimeSpan.FromMilliseconds(50));

            return value;
        }

        var tasks = Enumerable.Range(0, 10).Select(_ => Task.Run(GetOrComputeValue)).ToArray();

        // Act
        object[] results1 = await Task.WhenAll(tasks);
        int computationCount1 = computationCount;

        // Wait for the cache to expire
        await Task.Delay(_expirationPeriod + TimeSpan.FromMilliseconds(50));

        Console.WriteLine("Cache should have expired by now...");

        // Repeat after cache expiration
        computationCount = 0; // Reset computation count
        var tasksAfterExpiry = Enumerable.Range(0, 10).Select(_ => Task.Run(GetOrComputeValue)).ToArray();
        object[] results2 = await Task.WhenAll(tasksAfterExpiry);
        int computationCount2 = computationCount;

        // Assert
        // First retrieval: all values should be the same, and computation happens once
        results1.All(value => (string) value == computedValue).ShouldBeTrue();
        computationCount1.ShouldBe(1);

        // Second retrieval after expiration: all values should be fetched, and computation happens once
        results2.All(value => (string) value == computedValue).ShouldBeTrue();
        computationCount2.ShouldBe(1);
    }

    [Test]
    public async Task Cache_ShouldPreventThunderingHerd_WhenCacheExpirationDisabled()
    {
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>("TestNonExpiringCache", TimeSpan.Zero);

        string cacheKey = "ThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;

        object ValueFactory(string key, TimeSpan workDuration)
        {
            // Simulate expensive computation
            Thread.Sleep(workDuration);
            Interlocked.Increment(ref computationCount);
            return computedValue;
        }

        object GetOrComputeValue()
        {
            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                TimeSpan.FromMilliseconds(100),
                TimeSpan.FromMilliseconds(50));

            return value;
        }

        var tasks = Enumerable.Range(0, 10).Select(_ => Task.Run(GetOrComputeValue)).ToArray();

        // Act
        object[] results1 = await Task.WhenAll(tasks);

        // Wait for the cache to expire
        await Task.Delay(_expirationPeriod + TimeSpan.FromMilliseconds(50));

        Console.WriteLine("Cache would have expired by now but expiration is disabled...");

        // Repeat after cache expiration
        var tasksAfterExpiry = Enumerable.Range(0, 10).Select(_ => Task.Run(GetOrComputeValue)).ToArray();
        object[] results2 = await Task.WhenAll(tasksAfterExpiry);

        // Assert
        // First retrieval: all values should be the same, and computation happens once
        results1.All(value => (string) value == computedValue).ShouldBeTrue();

        // Second retrieval after expiration: all values should be fetched, and computation happens once
        results2.All(value => (string) value == computedValue).ShouldBeTrue();
        computationCount.ShouldBe(1);
    }

    [Test]
    public void Cache_ShouldHandleThunderingHerd_WhenCachingDisabled()
    {
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>("TestCache", TimeSpan.MinValue);

        string cacheKey = "DisabledThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;

        object ValueFactory(string key, TimeSpan workDuration)
        {
            // Simulate expensive computation
            Thread.Sleep(workDuration);
            Interlocked.Increment(ref computationCount);
            return computedValue;
        }

        object GetOrComputeValue()
        {
            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                TimeSpan.FromMilliseconds(100),
                TimeSpan.FromMilliseconds(50));

            return value;
        }

        var tasks = Enumerable.Range(0, 10).Select(_ => Task.Run(GetOrComputeValue)).ToArray();

        var results = Task.WhenAll(tasks).Result;

        // Assert
        results.All(value => (string) value == "ComputedValue").ShouldBeTrue();
        computationCount.ShouldBe(10);
    }

    [Test]
    public void Cache_TwoThunderingHerds_ShouldResolveValuesOnce_OnDifferentKeys()
    {
        // Arrange
        int cacheExpirationCount = 0;
        
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestCache",
            TimeSpan.FromMinutes(1), // Effectively no timeout for the cache for this test
            () => cacheExpirationCount++);

        string cacheKey1 = "ThunderingHerdKey1";
        string computedValue1 = "ComputedValue1";
        int computationCount1 = 0;

        string cacheKey2 = "ThunderingHerdKey2";
        string computedValue2 = "ComputedValue2";
        int computationCount2 = 0;

        object ValueFactory(string key, (string computedValue, TimeSpan workDuration) args)
        {
            // Simulate expensive computation
            Thread.Sleep(args.workDuration);

            if (key == cacheKey1)
            {
                Interlocked.Increment(ref computationCount1);
            }
            else
            {
                Interlocked.Increment(ref computationCount2);
            }

            return args.computedValue;
        }

        object GetOrComputeValue(string cacheKey, string computedValue, TimeSpan workDuration, int i)
        {
            CallContext.SetData("TestTask", i);

            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                (computedValue, workDuration), // Guard against permanent hangs
                TimeSpan.FromMinutes(1));

            return value;
        }

        var startEvent = new ManualResetEventSlim(false);
        
        var tasks1 = Enumerable.Range(10, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey1, computedValue1, TimeSpan.FromMilliseconds(50), _);
            }))
            .ToArray();

        var tasks2 = Enumerable.Range(20, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey2, computedValue2, TimeSpan.FromMilliseconds(50), _);
            }))
            .ToArray();

        // Launch the thundering herds
        startEvent.Set();

        var results1 = Task.WhenAll(tasks1).Result;
        var results2 = Task.WhenAll(tasks2).Result;

        // Assert
        string actualValuesReturned1 = GetActualValuesReturnedMessage(results1);
        string actualValuesReturned2 = GetActualValuesReturnedMessage(results2);
        
        results1.ShouldSatisfyAllConditions(
            _ => _.All(value => (string) value == "ComputedValue1").ShouldBeTrue(actualValuesReturned1),
            _ => _.Length.ShouldBe(10),
            _ => computationCount1.ShouldBe(1));

        results2.ShouldSatisfyAllConditions(
            _ => _.All(value => (string) value == "ComputedValue2").ShouldBeTrue(actualValuesReturned2),
            _ => _.Length.ShouldBe(10),
            _ => computationCount2.ShouldBe(1));
        
        // Cache should not have expired during this test
        cacheExpirationCount.ShouldBe(0);
    }

    [Test]
    public void Cache_TwoThunderingHerdsWithMultipleCacheExpirations_ShouldResolveAllValuesWithoutErrors()
    {
        // Arrange
        // var provider = new ExpiringSingleFlightFactoryCacheProvider<string, object>("TestCache", TimeSpan.FromMinutes(1));
        int cacheExpirationCount = 0;
        
        // TODO: Causes problems with cache expiration during initialization
        var provider = new ExpiringSingleFlightCache<string, object>("TestCache", _expirationPeriod, () => cacheExpirationCount++);

        string cacheKey1 = "ThunderingHerdKey1";
        string computedValue1 = "ComputedValue1";
        int computationCount1 = 0;

        string cacheKey2 = "ThunderingHerdKey2";
        string computedValue2 = "ComputedValue2";
        int computationCount2 = 0;

        object ValueFactory(string key, (string computedValue, TimeSpan workDuration) args)
        {
            // Simulate expensive computation
            Thread.Sleep(args.workDuration);

            if (key == cacheKey1)
            {
                Interlocked.Increment(ref computationCount1);
            }
            else
            {
                Interlocked.Increment(ref computationCount2);
            }

            return args.computedValue;
        }

        object GetOrComputeValue(string cacheKey, string computedValue, TimeSpan workDuration, int i)
        {
            CallContext.SetData("TestTask", i);

            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                (computedValue, workDuration), // Guard against permanent hangs
                TimeSpan.FromMinutes(1));

            return value;
        }

        var startEvent = new ManualResetEventSlim(false);
        
        var tasks1 = Enumerable.Range(10, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey1, computedValue1, TimeSpan.FromMilliseconds(50), _);
            }))
            .ToArray();

        var tasks2 = Enumerable.Range(20, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey2, computedValue2, TimeSpan.FromMilliseconds(50), _);
            }))
            .ToArray();

        // Launch the thundering herds
        startEvent.Set();

        var results1 = Task.WhenAll(tasks1).Result;
        var results2 = Task.WhenAll(tasks2).Result;

        int finalCacheExpirationCount = cacheExpirationCount;
        
        // Assert
        string actualValuesReturned1 = GetActualValuesReturnedMessage(results1);
        string actualValuesReturned2 = GetActualValuesReturnedMessage(results2);
        
        results1.ShouldSatisfyAllConditions(
            _ => _.All(value => (string) value == "ComputedValue1").ShouldBeTrue(actualValuesReturned1),
            _ => _.Length.ShouldBe(10),
            _ => computationCount1.ShouldBeLessThanOrEqualTo(2 * finalCacheExpirationCount));

        results2.ShouldSatisfyAllConditions(
            _ => _.All(value => (string) value == "ComputedValue2").ShouldBeTrue(actualValuesReturned2),
            _ => _.Length.ShouldBe(10),
            _ => computationCount2.ShouldBeLessThanOrEqualTo(2 * finalCacheExpirationCount));
    }

    [Test]
    public async Task Cache_ShouldHandleFactoryTimeouts_DuringThunderingHerd()
    {
        var cacheExpirationPeriodForThisTest = TimeSpan.FromSeconds(1);

        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestCache",
            cacheExpirationPeriodForThisTest, // Make the expiration irrelevant to this test (else use _expirationPeriod),
            TimeSpan.FromMilliseconds(50)); // Set factory delegate timeout

        string cacheKey = "ThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;
        int computationAttempt = 0;

        object ValueFactory(string key, (TimeSpan initialWorkDuration, TimeSpan subsequentWorkDuration) args)
        {
            // Simulate expensive computation
            if (Interlocked.Increment(ref computationAttempt) == 1)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({CallContext.GetData("TestTask")}): Initial work taking {args.initialWorkDuration.TotalMilliseconds} ms being performed...");
                Thread.Sleep(args.initialWorkDuration);
                Interlocked.Increment(ref computationCount);
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({CallContext.GetData("TestTask")}): Subsequent work taking {args.subsequentWorkDuration.TotalMilliseconds} ms being performed...");
                Thread.Sleep(args.subsequentWorkDuration);
                Interlocked.Increment(ref computationCount);
            }

            return computedValue;
        }

        object GetOrComputeValue(int i)
        {
            CallContext.SetData("TestTask", i);

            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                (
                    initialWorkDuration: TimeSpan.FromMilliseconds(150), // Initial work is longer than factory timeout setting on cache
                    subsequentWorkDuration: TimeSpan.FromMilliseconds(25) // Subsequent work completes faster
                ), // Callers will wait longer than initial work before timing out
                TimeSpan.FromMilliseconds(175));

            return value;
        }

        // Act
        // Create the first thundering herd of tasks
        var tasks = Enumerable.Range(0, 10).Select(_ => Task.Run(() => GetOrComputeValue(_))).ToArray();
        object[] results1 = await Task.WhenAll(tasks);
        int computationCount1 = computationCount;

        // Wait for the cache to expire
        await Task.Delay(cacheExpirationPeriodForThisTest + TimeSpan.FromMilliseconds(50));
        Console.WriteLine("Cache should have expired by now... starting a new \"herd\"...");

        // Reset computation count
        computationCount = 0; 

        // Repeat the thundering herd scenario after cache expiration
        var tasksAfterExpiry = Enumerable.Range(0, 10).Select(_ => Task.Run(() => GetOrComputeValue(_))).ToArray();
        object[] results2 = await Task.WhenAll(tasksAfterExpiry);
        int computationCount2 = computationCount;

        // Assert
        // First retrieval: all values should be the same, and computation happens once
        string customMessage1 = GetActualValuesReturnedMessage(results1);
        results1.All(value => (string) value == computedValue).ShouldBeTrue(customMessage1);
        computationCount1.ShouldBe(1);

        // Second retrieval after expiration: all values should be fetched, and computation happens once
        string customMessage2 = $"Actual returned values: {string.Join(", ", results2.Select((o, i) => $"{i+1} - {o ?? "(null)"}"))}";
        results2.All(value => (string) value == computedValue).ShouldBeTrue(customMessage2);
        computationCount2.ShouldBe(1);
    }

    private static string GetActualValuesReturnedMessage(object[] results)
    {
        return $"Actual returned values: {string.Join(", ", results.Select((o, i) => $"{i+1} - {o ?? "(null)"}"))}";
    }
}
