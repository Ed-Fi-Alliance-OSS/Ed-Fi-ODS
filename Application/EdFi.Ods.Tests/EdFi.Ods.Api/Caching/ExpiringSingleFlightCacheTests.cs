// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Context;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching;

[TestFixture]
public class ExpiringSingleFlightCacheTests
{
    private static readonly double _timespanFactor = 16 / (double) Environment.ProcessorCount;

    private static readonly TimeSpan _expirationPeriod = TimeSpan.FromMilliseconds(250 * _timespanFactor);
    private static readonly TimeSpan _defaultCreateTimeoutPeriod = TimeSpan.FromMilliseconds(100 * _timespanFactor);

    [Test]
    public async Task Cache_01_ShouldGracefullyHandleThunderingHerd_WhenCacheExpiresDuringProducer()
    {
        var cacheExpirationCount = 0;
        
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestCache",
            _expirationPeriod,
            () => Interlocked.Increment(ref cacheExpirationCount),
            TimeSpan.FromMinutes(1)); // Creation timeout is not the focus

        string cacheKey = "ThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;

        Task<object> ValueFactory(string key, TimeSpan workDuration, CancellationToken cancellationToken)
        {
            // After the cache expires once, decrease execution time
            if (cacheExpirationCount > 0)
            {
                workDuration = TimeSpan.FromMilliseconds(50 * _timespanFactor);
            }
            
            // Simulate expensive computation
            Thread.Sleep(workDuration);
            cancellationToken.ThrowIfCancellationRequested();
            Interlocked.Increment(ref computationCount);

            return Task.FromResult((object) computedValue);
        }

        Task<object> GetOrComputeValue()
        {
            var value = provider.GetOrCreateAsync(
                cacheKey,
                ValueFactory,
                // Make initial work take longer than the cache expiration period
                TimeSpan.FromMilliseconds(_expirationPeriod.TotalMilliseconds * 1.5 * _timespanFactor),
                CancellationToken.None);

            return value;
        }

        // Initialize the thundering herd
        var startEvent = new ManualResetEventSlim(false);

        var tasks = Enumerable.Range(0, 10)
            .Select(i => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue();
            }))
            .ToArray();

        // Act
        
        // Launch the thundering herd
        startEvent.Set();

        object[] results = await Task.WhenAll(tasks);
        int actualCacheExpirationCount = cacheExpirationCount;

        // Assert
        // All values should be the same, and computation happens once
        results.All(value => (string) value == computedValue).ShouldBeTrue();
        computationCount.ShouldBe(1);
        actualCacheExpirationCount.ShouldBe(1);
    }

    [Test]
    public async Task Cache_02_ShouldGracefullyHandleThunderingHerd_WhenCacheExpirationDisabled()
    {
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestNonExpiringCache", 
            TimeSpan.Zero, // Caching expiration disabled
            TimeSpan.FromMinutes(1)); // Creation timeout is not the focus of this test

        string cacheKey = "ThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;

        Task<object> ValueFactory(string key, TimeSpan workDuration, CancellationToken cancellationToken)
        {
            // Simulate expensive computation
            Thread.Sleep(workDuration);
            cancellationToken.ThrowIfCancellationRequested();
            Interlocked.Increment(ref computationCount);
            return Task.FromResult((object) computedValue);
        }

        Task<object> GetOrComputeValue()
        {
            var value = provider.GetOrCreateAsync(
                cacheKey,
                ValueFactory,
                TimeSpan.FromMilliseconds(100 * _timespanFactor),
                CancellationToken.None);

            return value;
        }

        // Initialize the thundering herd
        var startEvent = new ManualResetEventSlim(false);

        var tasks = Enumerable.Range(10, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue();
            }))
            .ToArray();

        // Act

        // Launch the thundering herds
        startEvent.Set();

        var results = await Task.WhenAll(tasks);

        // Assert

        // All values should be the same, and computation happens once
        results.All(value => (string) value == computedValue).ShouldBeTrue();
        computationCount.ShouldBe(1);
    }

    [Test]
    public void Cache_03_ShouldNotPreventThunderingHerd_WhenCachingDisabled()
    {
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestCache", 
            TimeSpan.MinValue,  // Caching disabled
            _defaultCreateTimeoutPeriod);

        string cacheKey = "DisabledThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;

        Task<object> ValueFactory(string key, TimeSpan workDuration, CancellationToken cancellationToken)
        {
            // Simulate expensive computation
            Thread.Sleep(workDuration);
            cancellationToken.ThrowIfCancellationRequested();
            Interlocked.Increment(ref computationCount);
            return Task.FromResult((object) computedValue);
        }

        Task<object> GetOrComputeValue()
        {
            var value = provider.GetOrCreateAsync(
                cacheKey,
                ValueFactory,
                TimeSpan.FromMilliseconds(50 * _timespanFactor),
                CancellationToken.None);;

            return value;
        }

        // Initialize the thundering herd
        var startEvent = new ManualResetEventSlim(false);

        var tasks = Enumerable.Range(0, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue();
            }))
            .ToArray();
        
        // Act
        
        // Launch the thundering herds
        startEvent.Set();

        var results = Task.WhenAll(tasks).Result;

        // Assert
        results.All(value => (string) value == "ComputedValue").ShouldBeTrue();
        computationCount.ShouldBe(10);
    }

    [Test]
    public async Task Cache_04_TwoSimultaneousThunderingHerds_ShouldResolveValuesOnceEach_OnDifferentKeys()
    {
        // Arrange
        int cacheExpirationCount = 0;
        
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestCache",
            TimeSpan.FromHours(1), // Cache expiration is not the focus of this test
            () => Interlocked.Increment(ref cacheExpirationCount),
            _defaultCreateTimeoutPeriod);

        string cacheKey1 = "ThunderingHerdKey1";
        string computedValue1 = "ComputedValue1";
        int computationCount1 = 0;

        string cacheKey2 = "ThunderingHerdKey2";
        string computedValue2 = "ComputedValue2";
        int computationCount2 = 0;

        Task<object> ValueFactory(string key, (string computedValue, TimeSpan workDuration) args, CancellationToken cancellationToken)
        {
            // Simulate expensive computation
            Thread.Sleep(args.workDuration);
            cancellationToken.ThrowIfCancellationRequested();

            if (key == cacheKey1)
            {
                Interlocked.Increment(ref computationCount1);
            }
            else
            {
                Interlocked.Increment(ref computationCount2);
            }

            return Task.FromResult((object) args.computedValue);
        }

        Task<object> GetOrComputeValue(string cacheKey, string computedValue, TimeSpan workDuration, int i)
        {
            CallContext.SetData("TestTask", i);

            var value = provider.GetOrCreateAsync(
                cacheKey,
                ValueFactory,
                (computedValue, workDuration),
                CancellationToken.None);

            return value;
        }

        // Initialize the thundering herds
        var startEvent = new ManualResetEventSlim(false);

        var tasks1 = Enumerable.Range(10, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey1, computedValue1, TimeSpan.FromMilliseconds(50 * _timespanFactor), _);
            }))
            .ToArray();

        var tasks2 = Enumerable.Range(20, 10)
            .Select(_ => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey2, computedValue2, TimeSpan.FromMilliseconds(50 * _timespanFactor), _);
            }))
            .ToArray();

        // Act

        // Launch both thundering herds
        startEvent.Set();

        var allResults = await Task.WhenAll(tasks1.Concat(tasks2));
        
        var results1 = allResults.Take(10).ToArray();
        var results2 = allResults.Skip(10).ToArray();

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
    public async Task Cache_05_TwoThunderingHerdsWithCacheExpiration_ShouldHandleGracefullyAndResolveAllValueOnce()
    {
        var cacheExpirationCount = 0;
        
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestCache",
            _expirationPeriod,
            () => Interlocked.Increment(ref cacheExpirationCount),
            TimeSpan.FromMinutes(1)); // Creation timeout is not the focus

        string cacheKey1 = "ThunderingHerdKey1";
        string computedValue1 = "ComputedValue1";
        int computationCount1 = 0;

        string cacheKey2 = "ThunderingHerdKey2";
        string computedValue2 = "ComputedValue2";
        int computationCount2 = 0;

        Task<object> ValueFactory(string key, (string computedValue, TimeSpan workDuration) args, CancellationToken cancellationToken)
        {
            // After the cache expires once, decrease execution time
            if (cacheExpirationCount > 0)
            {
                args.workDuration = TimeSpan.FromMilliseconds(50 * _timespanFactor);
            }

            // Simulate expensive computation
            Thread.Sleep(args.workDuration);
            cancellationToken.ThrowIfCancellationRequested();

            if (key == cacheKey1)
            {
                Interlocked.Increment(ref computationCount1);
            }
            else
            {
                Interlocked.Increment(ref computationCount2);
            }

            return Task.FromResult((object) args.computedValue);
        }

        Task<object> GetOrComputeValue(string cacheKey, string computedValue, int i)
        {
            CallContext.SetData("TestTask", i);

            var initialWorkDuration = TimeSpan.FromMilliseconds(_expirationPeriod.TotalMilliseconds * 1.5 * _timespanFactor);
            
            var value = provider.GetOrCreateAsync(
                cacheKey,
                ValueFactory,
                (computedValue, initialWorkDuration),
                CancellationToken.None);

            return value;
        }
        
        // Initialize the thundering herd
        var startEvent = new ManualResetEventSlim(false);

        var tasks1 = Enumerable.Range(0, 10)
            .Select(i => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey1, computedValue1, i);
            }))
            .ToArray();

        var tasks2 = Enumerable.Range(10, 10)
            .Select(i => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(cacheKey2, computedValue2, i);
            }))
            .ToArray();

        // Act
        
        // Launch the thundering herd
        startEvent.Set();

        object[] allResults = await Task.WhenAll(tasks1.Concat(tasks2));
        int actualCacheExpirationCount = cacheExpirationCount;

        var results1 = allResults.Take(10).ToArray();
        var results2 = allResults.Skip(10).ToArray();
        
        // Assert
        // First retrieval: all values should be the same, and computation happens once
        results1.ShouldSatisfyAllConditions(
            _ => _.All(value => (string) value == computedValue1).ShouldBeTrue(), 
            _ => _.Length.ShouldBe(10),
            _ => computationCount1.ShouldBe(1));

        results2.ShouldSatisfyAllConditions(
            _ => _.All(value => (string) value == computedValue2).ShouldBeTrue(), 
            _ => _.Length.ShouldBe(10),
            _ => computationCount2.ShouldBe(1));

        actualCacheExpirationCount.ShouldBe(1);
    }

    [Test]
    public async Task Cache_06_ShouldGracefullyRetryCreationAfterTimeout_DuringThunderingHerd()
    {
        // The create timeout needs to be long enough so that initial work can timeout and then retry 1-2 times (after ~200ms, ~400ms) before wait period expires (1.5X create timeout period)
        TimeSpan createTimeoutPeriod = TimeSpan.FromMilliseconds(1000); 
        
        // Arrange
        var provider = new ExpiringSingleFlightCache<string, object>(
            "TestCache",
            TimeSpan.FromHours(1), // Make the expiration irrelevant to this test (else use default _expirationPeriod),
            createTimeoutPeriod); 

        string cacheKey = "ThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;
        int computationAttempt = 0;

        Task<object> ValueFactory(string key, (TimeSpan initialWorkDuration, TimeSpan subsequentWorkDuration) args, CancellationToken cancellationToken)
        {
            // Simulate expensive computation
            if (Interlocked.Increment(ref computationAttempt) == 1)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({CallContext.GetData("TestTask")}): Initial work taking {args.initialWorkDuration.TotalMilliseconds} ms being performed...");
                Thread.Sleep(args.initialWorkDuration);
                cancellationToken.ThrowIfCancellationRequested();
                Interlocked.Increment(ref computationCount);
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({CallContext.GetData("TestTask")}): Subsequent work taking {args.subsequentWorkDuration.TotalMilliseconds} ms being performed...");
                Thread.Sleep(args.subsequentWorkDuration);
                cancellationToken.ThrowIfCancellationRequested();
                Interlocked.Increment(ref computationCount);
            }

            return Task.FromResult((object) computedValue);
        }

        async Task<object> GetOrComputeValue(int i)
        {
            CallContext.SetData("TestTask", i);

            var value = await provider.GetOrCreateAsync(
                cacheKey,
                ValueFactory,
                (
                    // Initial work is longer than creation timeout setting on cache, but shorter than the wait timeout (1.5X create timeout)
                    initialWorkDuration: TimeSpan.FromMilliseconds(createTimeoutPeriod.TotalMilliseconds + 50),
                    subsequentWorkDuration: TimeSpan.FromMilliseconds(10) // Subsequent work completes much faster
                ), // Callers will wait longer than initial work before timing out
                CancellationToken.None);

            return value;
        }

        // Initialize the thundering herd
        var startEvent = new ManualResetEventSlim(false);
        
        var tasks = Enumerable.Range(0, 10)
            .Select(i => Task.Run(() =>
            {
                // Wait for the thundering herd launch signal
                startEvent.Wait();
                return GetOrComputeValue(i);
            }))
            .ToArray();

        // Act

        // Launch the thundering herd
        startEvent.Set();

        var results = await Task.WhenAll(tasks);

        string customMessage1 = GetActualValuesReturnedMessage(results);

        // Assert
        // First retrieval: all values should be the same, and computation happens once
        results.ShouldSatisfyAllConditions(
            _ => _.All(value => (string) value == computedValue).ShouldBeTrue(customMessage1),
            _ => computationAttempt.ShouldBe(2),
            _ => computationCount.ShouldBe(1));
    }

    [Test]
    public async Task Cache_ClearsAfterExpirationPeriod()
    {
        // Arrange
        int cacheClearedCount = 0;

        var provider = new ExpiringSingleFlightCache<string, object>(
            "CacheWithExpiration",
            _expirationPeriod,
            () => Interlocked.Increment(ref cacheClearedCount),
            _defaultCreateTimeoutPeriod);

        string cacheKey = "TestKey";
        string initialValue = "InitialValue";
        string newValue = "NewValue";
        int computationCount = 0;

        // Define the ValueFactory
        Task<object> ValueFactory(string key, string result, CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref computationCount);

            return Task.FromResult((object)result);
        }

        // Act
        // Populate the cache with an initial value
        var initialResult = await provider.GetOrCreateAsync(cacheKey, ValueFactory, initialValue, CancellationToken.None);

        // Simulate a delay longer than the expiration period to allow cache clearing
        await Task.Delay(_expirationPeriod + TimeSpan.FromMilliseconds(50));

        // Attempt to retrieve the value again (it should recompute and replace the old value)
        var newResult = await provider.GetOrCreateAsync(cacheKey, ValueFactory, newValue, CancellationToken.None);

        // Assert
        initialResult.ShouldBe(initialValue);
        newResult.ShouldBe(newValue);
        computationCount.ShouldBe(2); // One for each ValueFactory invocation
        cacheClearedCount.ShouldBe(1); // Cache should have cleared after expiration period
    }
    
    [Test]
    public async Task Cache_IsNotCleared_WhenExpirationIsDisabled()
    {
        // Arrange
        int cacheClearedCount = 0;

        // Initialize the cache with expiration disabled (`TimeSpan.Zero`)
        var provider = new ExpiringSingleFlightCache<string, object>(
            "NonExpiringCache",
            TimeSpan.Zero, // Disable expiration
            () => Interlocked.Increment(ref cacheClearedCount),
            _defaultCreateTimeoutPeriod);

        string cacheKey = "TestKey";
        string initialValue = "InitialValue";
        string reusedValue = "InitialValue";
        int computationCount = 0;

        // Define the ValueFactory
        Task<object> ValueFactory(string key, string result, CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref computationCount);

            return Task.FromResult((object) result);
        }

        // Act
        // Populate the cache with an initial value
        var initialResult = await provider.GetOrCreateAsync(
            cacheKey,
            ValueFactory,
            initialValue,
            CancellationToken.None);

        // Simulate a long delay (much longer than what would otherwise be the expiration period)
        await Task.Delay(_expirationPeriod + TimeSpan.FromMilliseconds(50));

        // Retrieve the value again (it should still be in the cache since expiration is disabled)
        var newResult = await provider.GetOrCreateAsync(
            cacheKey,
            ValueFactory,
            reusedValue,
            CancellationToken.None);

        // Assert
        initialResult.ShouldBe(initialValue);
        newResult.ShouldBe(initialValue); // Value should remain unchanged
        computationCount.ShouldBe(1); // ValueFactory should have been invoked only once
        cacheClearedCount.ShouldBe(0); // Cache clearing should not have been triggered
    }

    private static string GetActualValuesReturnedMessage(object[] results)
    {
        return $"Actual returned values: {string.Join(", ", results.Select((o, i) => $"{i + 1} - {o ?? "(null)"}"))}";
    }
}
