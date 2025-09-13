using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using NUnit.Framework;
using Shouldly;

[TestFixture]
public class ExpiringConcurrentDictionaryCacheProviderThunderingHerdTests
{
    private static readonly TimeSpan _expirationPeriod = TimeSpan.FromMilliseconds(250);

    [Test]
    public async Task Cache_ShouldPreventThunderingHerd_WhenExpiringEntireCache()
    {
        // Arrange
        IConcurrentCacheProvider<string> provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", _expirationPeriod);

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
        IConcurrentCacheProvider<string> provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestNonExpiringCache", TimeSpan.Zero);

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
        IConcurrentCacheProvider<string> provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", TimeSpan.MinValue);

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
    public void Cache_TwoThunderingHerds_ShouldOperateIndependently_OnDifferentKeys()
    {
        // Arrange
        IConcurrentCacheProvider<string> provider = new ExpiringConcurrentDictionaryCacheProvider<string>("TestCache", _expirationPeriod);

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

        object GetOrComputeValue(string cacheKey, string computedValue, TimeSpan workDuration)
        {
            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                TimeSpan.FromMilliseconds(100),
                (computedValue, workDuration));

            return value;
        }

        var tasks1 = Enumerable.Range(0, 10)
            .Select(_ => Task.Run(() => GetOrComputeValue(cacheKey1, computedValue1, TimeSpan.FromMilliseconds(50))))
            .ToArray();

        var tasks2 = Enumerable.Range(0, 10)
            .Select(_ => Task.Run(() => GetOrComputeValue(cacheKey2, computedValue2, TimeSpan.FromMilliseconds(50))))
            .ToArray();

        // var tasks = tasks1.Concat(tasks2).ToArray();

        var results1 = Task.WhenAll(tasks1).Result;
        var results2 = Task.WhenAll(tasks2).Result;

        // Assert
        results1.All(value => (string) value == "ComputedValue1").ShouldBeTrue();
        computationCount1.ShouldBe(1);

        results2.All(value => (string) value == "ComputedValue2").ShouldBeTrue();
        computationCount2.ShouldBe(1);
    }
    
    [Test]
    public async Task Cache_ShouldHandleFactoryTimeouts_DuringThunderingHerd()
    {
        var cacheExpirationPeriodForThisTest = TimeSpan.FromSeconds(1);

        // Arrange
        IConcurrentCacheProvider<string> provider = new ExpiringConcurrentDictionaryCacheProvider<string>(
            "TestCache",
            cacheExpirationPeriodForThisTest, // Make the expiration irrelevant to this test (else use _expirationPeriod),
            TimeSpan.FromMilliseconds(50)); // Set factory delegate timeout

        string cacheKey = "ThunderingHerdKey";
        string computedValue = "ComputedValue";
        int computationCount = 0;

        object ValueFactory(string key, (TimeSpan initialWorkDuration, TimeSpan subsequentWorkDuration) args)
        {
            // Simulate expensive computation
            if (Interlocked.Increment(ref computationCount) == 1)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({CallContext.GetData("TestTask")}): Initial work taking {args.initialWorkDuration.TotalMilliseconds} ms being performed...");
                Thread.Sleep(args.initialWorkDuration);
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({CallContext.GetData("TestTask")}): Subsequent work taking {args.subsequentWorkDuration.TotalMilliseconds} ms being performed...");
                Thread.Sleep(args.subsequentWorkDuration);
            }

            return computedValue;
        }

        object GetOrComputeValue(int i)
        {
            CallContext.SetData("TestTask", i);

            var value = provider.GetOrCreate(
                cacheKey,
                ValueFactory,
                TimeSpan.FromMilliseconds(175), // Callers will wait longer than initial work before timing out
                (
                    initialWorkDuration: TimeSpan.FromMilliseconds(150), // Initial work is longer than factory timeout setting on cache
                    subsequentWorkDuration: TimeSpan.FromMilliseconds(25) // Subsequent work completes faster
                ));

            return value;
        }

        var tasks = Enumerable.Range(0, 10).Select(_ => Task.Run(() => GetOrComputeValue(_))).ToArray();

        // Act
        object[] results1 = await Task.WhenAll(tasks);
        int computationCount1 = computationCount;

        // Wait for the cache to expire
        await Task.Delay(cacheExpirationPeriodForThisTest + TimeSpan.FromMilliseconds(50));

        Console.WriteLine("Cache should have expired by now... starting a new \"herd\"...");

        // Repeat after cache expiration
        computationCount = 0; // Reset computation count
        var tasksAfterExpiry = Enumerable.Range(0, 10).Select(_ => Task.Run(() => GetOrComputeValue(_))).ToArray();
        object[] results2 = await Task.WhenAll(tasksAfterExpiry);
        int computationCount2 = computationCount;

        // Assert
        // First retrieval: all values should be the same, and computation happens once
        results1.All(value => (string) value == computedValue).ShouldBeTrue();
        computationCount1.ShouldBe(2);

        // Second retrieval after expiration: all values should be fetched, and computation happens once
        results2.All(value => (string) value == computedValue).ShouldBeTrue();
        computationCount2.ShouldBe(2);
    }
}
