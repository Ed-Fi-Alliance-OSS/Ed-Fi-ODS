// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Caching.CacheKeyProviders;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Caching
{
    [TestFixture]
    public class CachingInterceptorTests
    {
        private IInvocation _invocation;
        private IMethodSignatureCacheKeyProvider _cacheKeyProvider;
        private ISingleFlightCache<ulong, object> _cacheProvider;
        private CachingInterceptor _interceptor;

        [SetUp]
        public void SetUp()
        {
            _cacheKeyProvider = A.Fake<IMethodSignatureCacheKeyProvider>();
            _cacheProvider = A.Fake<ISingleFlightCache<ulong, object>>();
            _interceptor = new CachingInterceptor(_cacheProvider, _cacheKeyProvider);

            _invocation = A.Fake<IInvocation>();
        }

        [Test]
        public void InterceptSynchronous_ShouldReturnCachedValue_OnCacheHit()
        {
            // Arrange
            ulong cacheKey = 12345;
            string cachedValue = "cached";
            string computedValue = "computed";

            // Mock the Invocation's Proceed() behavior 
            A.CallTo(() => _invocation.Method.ReturnType).Returns(typeof(string));
            A.CallTo(() => _invocation.Proceed()).Invokes(() =>
            {
                // Simulate the 'proceed' logic returning from the intercepted method
                _invocation.ReturnValue = computedValue;
            });

            A.CallTo(() => _cacheKeyProvider.GetKey(A<MethodInfo>._, A<object[]>._)).Returns(cacheKey);
            A.CallTo(() => _cacheProvider.GetOrCreateAsync(
                cacheKey,
                A<Func<ulong, IInvocation, CancellationToken, Task<object>>>._,
                A<IInvocation>._,
                A<CancellationToken>._))
                // Cache hit, so the factory should not be invoked
                .Returns(Task.FromResult((object)cachedValue));

            A.CallTo(() => _invocation.Method.ReturnType).Returns(typeof(string));

            // Act
            _interceptor.InterceptSynchronous(_invocation);

            // Assert
            A.CallTo(() => _invocation.Proceed()).MustNotHaveHappened();
            _invocation.ReturnValue.ShouldBe(cachedValue);
        }

        [Test]
        public void InterceptSynchronous_ShouldInvokeMethod_OnCacheMiss()
        {
            // Arrange
            ulong cacheKey = 12345;
            string computedValue = "computed";

            // Mock the Invocation's Proceed() behavior
            A.CallTo(() => _invocation.Method.ReturnType).Returns(typeof(string));
            A.CallTo(() => _invocation.Proceed()).Invokes(() =>
            {
                // Simulate the 'proceed' logic returning from the intercepted method
                _invocation.ReturnValue = computedValue;
            });

            A.CallTo(() => _cacheKeyProvider.GetKey(A<MethodInfo>._, A<object[]>._)).Returns(cacheKey);

            A.CallTo(() => _cacheProvider.GetOrCreateAsync(
                cacheKey,
                A<Func<ulong, IInvocation, CancellationToken, Task<object>>>._,
                A<IInvocation>._,
                A<CancellationToken>._))
                // Cache miss, so the factory should be invoked
                .Invokes((ulong key, Func<ulong, IInvocation, CancellationToken, Task<object>> func, IInvocation invocation, CancellationToken _) =>
                {
                    // Simulates invocation of the factory supplied to GetOrCreateAsync in InterceptSynchronous()
                    invocation.Proceed();
                })
                // Cache miss, so the factory result should be used
                .ReturnsLazily(() => Task.FromResult(_invocation.ReturnValue));

            // Act
            _interceptor.InterceptSynchronous(_invocation);

            // Assert
            A.CallTo(() => _invocation.Proceed()).MustHaveHappenedOnceExactly();
            _invocation.ReturnValue.ShouldBe(computedValue);
        }

        [Test]
        public void InterceptSynchronous_ShouldThrowException_OnCacheKeyGenerationFailure()
        {
            // Arrange
            A.CallTo(() => _cacheKeyProvider.GetKey(A<MethodInfo>._, A<object[]>._))
                .Throws(new InvalidOperationException("Cache key generation failed"));

            // Act & Assert
            var ex = Should.Throw<CachingInterceptorCacheKeyGenerationException>(() =>
                _interceptor.InterceptSynchronous(_invocation));
            ex.InnerException.ShouldBeOfType<InvalidOperationException>();
            ex.InnerException.Message.ShouldBe("Cache key generation failed");
        }

        [Test]
        public async Task InterceptAsynchronousOfT_ShouldReturnCachedValue_OnCacheHit()
        {
            // Arrange
            ulong cacheKey = 12345;
            string cachedValue = "cached";

            A.CallTo(() => _cacheKeyProvider.GetKey(A<MethodInfo>._, A<object[]>._)).Returns(cacheKey);
            A.CallTo(() => _cacheProvider.GetOrCreateAsync(
                cacheKey,
                A<Func<ulong, IInvocation, CancellationToken, Task<object>>>._,
                A<IInvocation>._,
                A<CancellationToken>._))
                .Returns(Task.FromResult((object)cachedValue));

            // Act
            _interceptor.InterceptAsynchronous<string>(_invocation);

            // Get the asynchronous result
            var resultTask = _invocation.ReturnValue as Task<string>;
            
            if (resultTask == null)
            {
                Assert.Fail("Result task is not a Task<string> as expected.");
            }
            
            var invocationReturnValue = await resultTask;

            // Assert
            A.CallTo(() => _invocation.Proceed()).MustNotHaveHappened();
            invocationReturnValue.ShouldBe(cachedValue);
        }

        [Test]
        public async Task InterceptAsynchronousOfT_ShouldInvokeMethod_OnCacheMiss()
        {
            // Arrange
            ulong cacheKey = 12345;
            string computedValue = "computed";
            
            // Mock the Invocation's Proceed() behavior
            A.CallTo(() => _invocation.Method.ReturnType).Returns(typeof(Task<string>));
            A.CallTo(() => _invocation.Proceed()).Invokes(() =>
            {
                // Simulate the 'proceed' logic returning from the intercepted method
                _invocation.ReturnValue = Task.FromResult(computedValue);
            });

            A.CallTo(() => _cacheKeyProvider.GetKey(A<MethodInfo>._, A<object[]>._)).Returns(cacheKey);
            A.CallTo(() => _cacheProvider.GetOrCreateAsync(
                cacheKey,
                A<Func<ulong, IInvocation, CancellationToken, Task<object>>>._,
                A<IInvocation>._,
                A<CancellationToken>._))
                // Cache miss, so the factory should be invoked
                .Invokes((ulong key, Func<ulong, IInvocation, CancellationToken, Task<object>> func, IInvocation invocation, CancellationToken _) =>
                {
                    // Simulates invocation of the factory supplied to GetOrCreateAsync in InterceptSynchronous()
                    invocation.Proceed();
                })
                // Cache miss, so the factory result should be used
                .ReturnsLazily(() =>
                {
                    var t = _invocation.ReturnValue as Task<string>;
                    return t.ConfigureAwait(false).GetAwaiter().GetResult();
                });

            // Act
            _interceptor.InterceptAsynchronous<string>(_invocation);

            // Get the asynchronous result
            var resultTask = _invocation.ReturnValue as Task<string>;
            
            if (resultTask == null)
            {
                Assert.Fail("Result task is not a Task<string> as expected.");
            }

            var invocationReturnValue = await resultTask;

            // Assert
            A.CallTo(() => _invocation.Proceed()).MustHaveHappenedOnceExactly();
            invocationReturnValue.ShouldBe(computedValue);
        }

        [Test]
        public void Clear_ShouldInvokeCacheClear()
        {
            // Arrange
            A.CallTo(() => _cacheProvider.Clear()).DoesNothing();

            // Act
            _interceptor.Clear();

            // Assert
            A.CallTo(() => _cacheProvider.Clear()).MustHaveHappenedOnceExactly();
        }
    }
}