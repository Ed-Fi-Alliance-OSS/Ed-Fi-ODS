// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Caching;

[TestFixture]
public class ContextualCachingInterceptorTests
{
    private ContextProvider<TestContext> _contextProvider;
    private ITestIntercepted _cachedTarget;
    
    private List<string> _invocations0;
    private List<(string, string)> _invocations1;
    private List<(string, int, string)> _invocations2;
    private List<(string, int, int, string)> _invocations3;
    private List<(string, int, int, string, string)> _invocations4;

    [SetUp]
    public void Setup()
    {
        _invocations0 = new();
        _invocations1 = new();
        _invocations2 = new();
        _invocations3 = new();
        _invocations4 = new();

        var generator = new ProxyGenerator();
        var target = new TestIntercepted(_invocations0, _invocations1, _invocations2, _invocations3, _invocations4);

        var cacheProvider = new ConcurrentDictionaryCacheProvider<ulong>();

        _contextProvider = new ContextProvider<TestContext>(new HashtableContextStorage());
        
        _cachedTarget = generator.CreateInterfaceProxyWithTarget<ITestIntercepted>(
            target,
            new ContextualCachingInterceptor<TestContext>(cacheProvider, _contextProvider));
    }
    
    [Test]
    public void Interception_of_cached_target_method_fails_with_correct_exception_when_no_context_is_set()
    {
        // No context is set
        var actualException = Should.Throw<CachingInterceptorCacheKeyGenerationException>(() => _cachedTarget.GetAString());
        
        actualException.ShouldSatisfyAllConditions(
            ex=> ex.Message.ShouldBe($"Cache key generation failed for invocation of method 'GetAString' of declaring type '{GetType().FullName}+ITestIntercepted'."),
            ex => ex.InnerException.ShouldBeOfType<InvalidOperationException>(),
            ex => ex.InnerException!.Message.ShouldBe($"No context has been set for value of type '{nameof(TestContext)}'.")
            );
    }

    [Test]
    public void Methods_on_cached_target_are_invoked_and_cached_correctly()
    {
        // Method invocations should run the first time and then be served from cache
        _contextProvider.Set(new TestContext("ContextOne"));
        InvokeAndVerifyCachingBehavior(expectedTargetInvocationCount: 1);

        // With new contextual value, additional identical method invocations should again run the first time before being served from cache
        _contextProvider.Set(new TestContext("ContextTwo"));
        InvokeAndVerifyCachingBehavior(expectedTargetInvocationCount: 2);

        void InvokeAndVerifyCachingBehavior(int expectedTargetInvocationCount)
        {
            var random = new Random();
            
            // Test caching of no arguments method
            var noArgsResult1 = _cachedTarget.GetAString();
            var noArgsResult2 = _cachedTarget.GetAString();

            // Test caching of one argument method
            string stringArg1 = "Hello" + random.Next(10000); 
            var stringArgResult1 = _cachedTarget.GetAString(stringArg1);
            var stringArgResult2 = _cachedTarget.GetAString(stringArg1);

            // Test caching of two argument method
            int intArg1 = random.Next(); 
            var stringIntArgsResult1 = _cachedTarget.GetAString(stringArg1, intArg1);
            var stringIntArgsResult2 = _cachedTarget.GetAString(stringArg1, intArg1);

            // Test caching of three argument method
            int intArg2 = random.Next(); 
            var stringIntIntArgsResult1 = _cachedTarget.GetAString(stringArg1, intArg1, intArg2);
            var stringIntIntArgsResult2 = _cachedTarget.GetAString(stringArg1, intArg1, intArg2);

            _cachedTarget.ShouldSatisfyAllConditions(

                // No arguments
                x => noArgsResult1.ShouldBe(noArgsResult2),
                x => _invocations0.Count.ShouldBe(expectedTargetInvocationCount),

                // 1 argument
                x => stringArgResult1.ShouldBe(stringArgResult2),
                x => _invocations1.Count.ShouldBe(expectedTargetInvocationCount),

                // 2 arguments
                x => stringIntArgsResult1.ShouldBe(stringIntArgsResult2),
                x => _invocations2.Count.ShouldBe(expectedTargetInvocationCount),

                // 3 arguments
                x => stringIntIntArgsResult1.ShouldBe(stringIntIntArgsResult2),
                x => _invocations3.Count.ShouldBe(expectedTargetInvocationCount),

                // More arguments (not implemented until needed)
                x =>
                {
                    var actualException = Should.Throw<CachingInterceptorCacheKeyGenerationException>(() => _cachedTarget.GetAString(stringArg1, intArg1, intArg2, "World"));

                    actualException.Message.ShouldBe(
                        $"Cache key generation failed for invocation of method 'GetAString' of declaring type '{GetType().FullName}+ITestIntercepted'.");

                    actualException.InnerException.ShouldBeOfType<NotImplementedException>();
                    actualException.InnerException.Message.ShouldBe("Support for generating contextual cache keys with more than 3 arguments has not been implemented.");

                },
                x => _invocations4.Count.ShouldBe(0));
        }
    }

    public class TestContext : IContextHashBytesSource
    {
        public TestContext(string contextValue)
        {
            ContextValue = contextValue;
        }

        public string ContextValue { get; set; }

        public byte[] HashBytes
        {
            get => Encoding.UTF8.GetBytes(ContextValue);
        }
    }

    public interface ITestIntercepted
    {
        string GetAString();
        string GetAString(string input);
        string GetAString(string input, int input2);
        string GetAString(string input, int input2, int input3);
        string GetAString(string input, int input2, int input3, string input4);
    }

    public class TestIntercepted : ITestIntercepted
    {
        private readonly List<string> _invocations0;
        private readonly List<(string, string)> _invocations1;
        private readonly List<(string, int, string)> _invocations2;
        private readonly List<(string, int, int, string)> _invocations3;
        private readonly List<(string, int, int, string, string)> _invocations4;

        public TestIntercepted(
            List<string> invocations0,
            List<(string, string)> invocations1,
            List<(string, int, string)> invocations2,
            List<(string, int, int, string)> invocations3,
            List<(string, int, int, string, string)> invocations4)
        {
            _invocations0 = invocations0;
            _invocations1 = invocations1;
            _invocations2 = invocations2;
            _invocations3 = invocations3;
            _invocations4 = invocations4;
        }

        public string GetAString()
        {
            string result = new Random().Next().ToString();

            _invocations0.Add(result);

            return result;
        }

        public string GetAString(string input)
        {
            string result = input.GetHashCode().ToString();

            _invocations1.Add((input, result));

            return result;
        }

        public string GetAString(string input, int input2)
        {
            string result = (input.GetHashCode() + input2 * 7).ToString();

            _invocations2.Add((input, input2, result));

            return result;
        }

        public string GetAString(string input, int input2, int input3)
        {
            string result = (input.GetHashCode() + input2 * 7 + input3 * 11).ToString();

            _invocations3.Add((input, input2, input3, result));

            return result;
        }
        public string GetAString(string input, int input2, int input3, string input4)
        {
            string result = (input.GetHashCode() + input2 * 7 + input3 * 11 + input4.GetHashCode()).ToString();

            _invocations4.Add((input, input2, input3, input4, result));

            return result;
        }
    }
}
