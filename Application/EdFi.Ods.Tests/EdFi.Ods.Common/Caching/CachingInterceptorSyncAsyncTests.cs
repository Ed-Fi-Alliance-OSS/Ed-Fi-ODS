// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Caching;

/*
[TestFixture]
public class CachingInterceptorSyncAsyncTests
{
    private CachingInterceptor _interceptor;
    private ICacheProvider<ulong> _cacheProvider;

    [SetUp]
    public void Setup()
    {
        _cacheProvider = A.Fake<ICacheProvider<ulong>>();
        _interceptor = new CachingInterceptor(_cacheProvider);
    }

    public interface IService
    {
        string GetValue(string input);
        Task<string> GetValueAsync(string input);
        Task DoAsync(string input);
        string GetValueWithTooManyArguments(string input1, int intput2, bool input3, decimal input4, float input5);

    }

    private IInvocation CreateInvocation(MethodInfo method, object[] args, Func<object> proceedValueFactory)
    {
        var invocation = A.Fake<IInvocation>();
        A.CallTo(() => invocation.Method).Returns(method);
        A.CallTo(() => invocation.Arguments).Returns(args);
        A.CallTo(() => invocation.TargetType).Returns(typeof(IService));
        A.CallTo(() => invocation.Proceed()).Invokes(() =>
        {
            var result = proceedValueFactory();
            invocation.ReturnValue = result;
        });

        return invocation;
    }

    [Test]
    public void Should_return_cached_synchronous_result_on_cache_hit()
    {
        // Arrange
        var method = typeof(IService).GetMethod(nameof(IService.GetValue));
        var args = new object[] { "abc" };
        object result = "from method";

        var invocation = CreateInvocation(method, args, () => result);

        A.CallTo(() => _cacheProvider.TryGetCachedObject(A<ulong>._, out result)).Returns(true);
        
        // Act
        _interceptor.Intercept(invocation);

        // Assert
        invocation.ReturnValue.ShouldBe(result);
        A.CallTo(() => invocation.Proceed()).MustNotHaveHappened();
    }

    [Test]
    public void Should_invoke_and_cache_synchronous_result_on_cache_miss()
    {
        // Arrange
        var method = typeof(IService).GetMethod(nameof(IService.GetValue));
        var args = new object[] { "abc" };
        var result = "calculated";

        var invocation = CreateInvocation(method, args, () => result);

        object ignored;
        A.CallTo(() => _cacheProvider.TryGetCachedObject(A<ulong>._, out ignored)).Returns(false);

        // Act
        _interceptor.Intercept(invocation);

        // Assert
        invocation.ReturnValue.ShouldBe(result);
        A.CallTo(() => invocation.Proceed()).MustHaveHappenedOnceExactly();
        A.CallTo(() => _cacheProvider.SetCachedObject(A<ulong>._, result)).MustHaveHappened();
    }

    [Test]
    public async Task Should_return_cached_asynchronous_result_on_cache_hit()
    {
        // Arrange
        var method = typeof(IService).GetMethod(nameof(IService.GetValueAsync));
        var args = new object[] { "xyz" };
        var cachedResult = "cached-result";

        var invocation = CreateInvocation(method, args, () => throw new InvalidOperationException("Should not be called"));
        object resultHolder = cachedResult;
        A.CallTo(() => _cacheProvider.TryGetCachedObject(A<ulong>._, out resultHolder)).Returns(true);
        
        // Act
        _interceptor.Intercept(invocation);

        // Assert
        var task = invocation.ReturnValue.ShouldBeAssignableTo<Task<string>>();
        (await (Task<string>)task).ShouldBe(cachedResult);
    }

    [Test]
    public async Task Should_invoke_and_cache_asynchrnonous_result_on_cache_miss()
    {
        // Arrange
        var method = typeof(IService).GetMethod(nameof(IService.GetValueAsync));
        var args = new object[] { "miss" };
        var result = "async-result";

        var invocation = CreateInvocation(method, args, () => Task.FromResult(result));

        // SetupCacheMiss();

        object ignored;
        A.CallTo(() => _cacheProvider.TryGetCachedObject(A<ulong>._, out ignored)).Returns(false);

        // Act
        _interceptor.Intercept(invocation);

        // Assert
        var actualResult = await (Task<string>)invocation.ReturnValue;
        actualResult.ShouldBe(result);

        A.CallTo(() => _cacheProvider.SetCachedObject(A<ulong>._, result)).MustHaveHappened();
    }

    [Test]
    public async Task Should_not_cache_non_generic_Task()
    {
        // Arrange
        var method = typeof(IService).GetMethod(nameof(IService.DoAsync));
        var args = new object[] { "input" };

        var invocation = CreateInvocation(method, args, () => Task.CompletedTask);

        object ignored;
        A.CallTo(() => _cacheProvider.TryGetCachedObject(A<ulong>._, out ignored)).Returns(false);

        // Act
        _interceptor.Intercept(invocation);

        // Assert
        await (Task)invocation.ReturnValue;

        A.CallTo(() => _cacheProvider.SetCachedObject(A<ulong>._, A<object>._)).MustNotHaveHappened();
    }

    [Test]
    public void Should_throw_if_cache_key_generation_fails()
    {
        // Arrange
        var method = typeof(IService).GetMethod(nameof(IService.GetValueWithTooManyArguments));
        var invocation = A.Fake<IInvocation>();
        A.CallTo(() => invocation.Method).Returns(method);
        A.CallTo(() => invocation.Arguments).Returns(["one", 1, true, 1.0D, 1.0f]);

        // Act & Assert
        Should.Throw<CachingInterceptorCacheKeyGenerationException>(() =>
            _interceptor.Intercept(invocation));
    }

    [Test]
    public void Should_clear_if_provider_is_clearable()
    {
        var clearableProvider = A.Fake<ICacheProvider<ulong>>(x => x.Implements(typeof(IClearable)));
        var clearable = (IClearable)clearableProvider;

        var interceptor = new CachingInterceptor(clearableProvider);

        // Act
        interceptor.Clear();

        // Assert
        A.CallTo(() => clearable.Clear()).MustHaveHappened();
    }

    [Test]
    public void Should_throw_on_clear_if_not_clearable()
    {
        // Act & Assert
        Should.Throw<NotSupportedException>(() => _interceptor.Clear());
    }
}
*/
