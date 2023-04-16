// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Caching;

[TestFixture]
public class CachingInterceptorTests
{
    [Test]
    public void Methods_on_cached_target_are_invoked_and_cached_correctly()
    {
        List<string> invocations0 = new();
        List<(string, string)> invocations1 = new();
        List<(string, int, string)> invocations2 = new();
        List<(string, int, int, string)> invocations3 = new();
        List<(string, int, int, string, string)> invocations4 = new();

        var generator = new ProxyGenerator();
        var target = new TestIntercepted(invocations0, invocations1, invocations2, invocations3, invocations4);

        var cacheProvider = new ConcurrentDictionaryCacheProvider<ulong>();

        var cachedTarget =
            generator.CreateInterfaceProxyWithTarget<ITestIntercepted>(target, new CachingInterceptor(cacheProvider));

        // Test caching of no arguments method
        var noArgsResult1 = cachedTarget.GetAString();
        var noArgsResult2 = cachedTarget.GetAString();

        // Test caching of one argument method
        var stringArgResult1 = cachedTarget.GetAString("Hello");
        var stringArgResult2 = cachedTarget.GetAString("Hello");

        // Test caching of two argument method
        var stringIntArgsResult1 = cachedTarget.GetAString("Hello", 123);
        var stringIntArgsResult2 = cachedTarget.GetAString("Hello", 123);

        // Test caching of three argument method
        var stringIntIntArgsResult1 = cachedTarget.GetAString("Hello", 123, 345);
        var stringIntIntArgsResult2 = cachedTarget.GetAString("Hello", 123, 345);

        cachedTarget.ShouldSatisfyAllConditions(
            // No arguments
            x => noArgsResult1.ShouldBe(noArgsResult2),
            x => invocations0.Count.ShouldBe(1),
            // 1 argument
            x => stringArgResult1.ShouldBe(stringArgResult2),
            x => invocations1.Count.ShouldBe(1),
            // 2 arguments
            x => stringIntArgsResult1.ShouldBe(stringIntArgsResult2),
            x => invocations2.Count.ShouldBe(1),
            // 3 arguments
            x => stringIntIntArgsResult1.ShouldBe(stringIntIntArgsResult2),
            x => invocations3.Count.ShouldBe(1),
            // More arguments (not implemented until needed)
            x => Should.Throw<NotImplementedException>(() => cachedTarget.GetAString("Hello", 123, 345, "World")),
            x => invocations4.Count.ShouldBe(0)
                );
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
