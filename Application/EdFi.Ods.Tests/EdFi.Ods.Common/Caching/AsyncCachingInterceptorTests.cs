// SPDX-License-Identifier: Apache-2.0
// Copyright (c) Ed-Fi Alliance, LLC and Contributors.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Caching;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Caching;

[TestFixture]
public class AsyncCachingInterceptorTests
{
    [Test]
    public void Intercept_SyncMethod_ShouldReturnFromL1Cache_WhenPresent()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.GetData));

        object cachedValue = "cached-l1";
        A.CallTo(() => localCacheProvider.TryGetCachedObject(A<ulong>._, out cachedValue)).Returns(true);

        interceptor.Intercept(invocation);

        invocation.ReturnValue.ShouldBe(cachedValue);
        A.CallTo(() => invocation.Proceed()).MustNotHaveHappened();
        A.CallTo(() => asyncCacheProvider.TryGetCachedObjectAsync(A<ulong>._)).MustNotHaveHappened();
    }

    [Test]
    public void Intercept_SyncMethod_ShouldFallbackToAsyncProvider_WhenL1Misses()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.GetData));

        object ignored = null!;
        A.CallTo(() => localCacheProvider.TryGetCachedObject(A<ulong>._, out ignored)).Returns(false);

        var cachedValue = "cached-l2";
        A.CallTo(() => asyncCacheProvider.TryGetCachedObjectAsync(A<ulong>._)).Returns((true, (object) cachedValue));

        interceptor.Intercept(invocation);

        invocation.ReturnValue.ShouldBe(cachedValue);
        A.CallTo(() => invocation.Proceed()).MustNotHaveHappened();
        A.CallTo(() => asyncCacheProvider.SetCachedObjectAsync(A<ulong>._, A<object>._)).MustNotHaveHappened();
    }

    [Test]
    public void Intercept_SyncMethod_ShouldProceedAndCache_WhenBothMiss()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.GetData));

        object ignored = null!;
        A.CallTo(() => localCacheProvider.TryGetCachedObject(A<ulong>._, out ignored)).Returns(false);
        A.CallTo(() => asyncCacheProvider.TryGetCachedObjectAsync(A<ulong>._)).Returns((false, null!));
        A.CallTo(() => invocation.Proceed()).Invokes(() => invocation.ReturnValue = "from-target");

        interceptor.Intercept(invocation);

        invocation.ReturnValue.ShouldBe("from-target");
        A.CallTo(() => invocation.Proceed()).MustHaveHappenedOnceExactly();
        A.CallTo(() => asyncCacheProvider.SetCachedObjectAsync(A<ulong>._, "from-target")).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task Intercept_AsyncTaskOfT_ShouldReturnCachedValue()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.GetDataAsync));

        A.CallTo(() => asyncCacheProvider.TryGetCachedObjectAsync(A<ulong>._)).Returns((true, (object) "cached-result"));

        interceptor.Intercept(invocation);
        var result = await (Task<string>) invocation.ReturnValue;

        result.ShouldBe("cached-result");
        A.CallTo(() => invocation.Proceed()).MustNotHaveHappened();
        object outValue = null!;
        A.CallTo(() => localCacheProvider.TryGetCachedObject(A<ulong>._, out outValue)).MustNotHaveHappened();
    }

    [Test]
    public async Task Intercept_AsyncTaskOfT_ShouldProceedAndCache_WhenMiss()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.GetDataAsync));

        A.CallTo(() => asyncCacheProvider.TryGetCachedObjectAsync(A<ulong>._)).Returns((false, null!));
        A.CallTo(() => invocation.Proceed()).Invokes(() => invocation.ReturnValue = Task.FromResult("from-target"));

        interceptor.Intercept(invocation);
        var result = await (Task<string>) invocation.ReturnValue;

        result.ShouldBe("from-target");
        A.CallTo(() => invocation.Proceed()).MustHaveHappenedOnceExactly();
        A.CallTo(() => asyncCacheProvider.SetCachedObjectAsync(A<ulong>._, "from-target")).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task Intercept_AsyncTask_ShouldSkipExecution_WhenCached()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.ExecuteOperationAsync));

        A.CallTo(() => asyncCacheProvider.TryGetCachedObjectAsync(A<ulong>._)).Returns((true, (object) "marker"));

        interceptor.Intercept(invocation);
        await (Task) invocation.ReturnValue;

        A.CallTo(() => invocation.Proceed()).MustNotHaveHappened();
        A.CallTo(() => asyncCacheProvider.SetCachedObjectAsync(A<ulong>._, A<object>._)).MustNotHaveHappened();
    }

    [Test]
    public async Task Intercept_AsyncTask_ShouldProceedAndCache_WhenMiss()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.ExecuteOperationAsync));

        A.CallTo(() => asyncCacheProvider.TryGetCachedObjectAsync(A<ulong>._)).Returns((false, null!));
        A.CallTo(() => invocation.Proceed()).Invokes(() => invocation.ReturnValue = Task.CompletedTask);

        interceptor.Intercept(invocation);
        await (Task) invocation.ReturnValue;

        A.CallTo(() => invocation.Proceed()).MustHaveHappenedOnceExactly();
        A.CallTo(() => asyncCacheProvider.SetCachedObjectAsync(A<ulong>._, A<object>.That.Matches(v => Equals(v, 1))))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public void Intercept_ShouldThrowCacheKeyGenerationException_WhenNoDeclaringType()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = A.Fake<IInvocation>();
        var method = A.Fake<MethodInfo>();

        A.CallTo(() => invocation.Method).Returns(method);
        A.CallTo(() => invocation.Arguments).Returns(Array.Empty<object>());
        A.CallTo(() => method.ReturnType).Returns(typeof(string));
        A.CallTo(() => method.DeclaringType).Returns(null);
        A.CallTo(() => method.Name).Returns("TestMethod");

        var exception = Should.Throw<CachingInterceptorCacheKeyGenerationException>(() => interceptor.Intercept(invocation));
        exception.Message.ShouldContain("Cache key generation failed for invocation of method 'TestMethod'");
        exception.InnerException.ShouldBeOfType<NotSupportedException>();
        exception.InnerException.Message.ShouldBe("Unable to generate a cache key for method 'TestMethod' because it has no DeclaringType.");
    }

    [Test]
    public void Intercept_ShouldThrowCacheKeyGenerationException_WhenMethodHasMoreThanThreeArguments()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);
        var invocation = CreateInvocation(nameof(ISampleService.GetDataWithFourArgs), "a", 1, 2, "b");

        var exception = Should.Throw<CachingInterceptorCacheKeyGenerationException>(() => interceptor.Intercept(invocation));
        exception.InnerException.ShouldBeOfType<NotImplementedException>();
        exception.InnerException.Message.ShouldBe("Support for generating cache keys for more than 3 arguments has not been implemented.");
    }

    [Test]
    public void Clear_ShouldClearLocalAndAsyncProviders_WhenBothAreClearable()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>(options => options.Implements(typeof(IClearable)));
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>(options => options.Implements(typeof(IClearable)));
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);

        interceptor.Clear();

        A.CallTo(() => ((IClearable) localCacheProvider).Clear()).MustHaveHappenedOnceExactly();
        A.CallTo(() => ((IClearable) asyncCacheProvider).Clear()).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void Clear_ShouldNotDoubleClear_WhenProvidersAreSameInstance()
    {
        var sharedCacheProvider = A.Fake<ITieredCacheProvider>();
        var interceptor = new AsyncCachingInterceptor(sharedCacheProvider, sharedCacheProvider);

        interceptor.Clear();

        A.CallTo(() => ((IClearable) sharedCacheProvider).Clear()).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void Clear_ShouldThrow_WhenNeitherProviderIsClearable()
    {
        var localCacheProvider = A.Fake<ICacheProvider<ulong>>();
        var asyncCacheProvider = A.Fake<IAsyncCacheProvider<ulong>>();
        var interceptor = new AsyncCachingInterceptor(asyncCacheProvider, localCacheProvider);

        var exception = Should.Throw<NotSupportedException>(() => interceptor.Clear());
        exception.Message.ShouldBe("Unable to clear the underlying data associated with the AsyncCachingInterceptor.");
    }

    private static IInvocation CreateInvocation(string methodName, params object[] arguments)
    {
        var invocation = A.Fake<IInvocation>();
        A.CallTo(() => invocation.Method).Returns(typeof(ISampleService).GetMethod(methodName)!);
        A.CallTo(() => invocation.Arguments).Returns(arguments);
        return invocation;
    }

    private interface ISampleService
    {
        string GetData();
        Task<string> GetDataAsync();
        Task ExecuteOperationAsync();
        string GetDataWithFourArgs(string value1, int value2, int value3, string value4);
    }

    private interface ITieredCacheProvider : ICacheProvider<ulong>, IAsyncCacheProvider<ulong>, IClearable;
}
