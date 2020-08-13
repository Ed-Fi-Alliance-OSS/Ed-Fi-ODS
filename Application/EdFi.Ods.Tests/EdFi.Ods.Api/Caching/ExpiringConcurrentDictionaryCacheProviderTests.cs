// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EdFi.Ods.Api.Caching;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching
{
    [TestFixture]
    public class ExpiringConcurrentDictionaryCacheProviderTests
    {
        public class When_adding_values_to_a_cache_with_recurring_expiration : TestFixtureBase
        {
            private readonly object[] _suppliedEntries = {
                new object(),
                new object(),
            };
            
            private readonly List<bool> _actualGetResultsForCacheHit = new List<bool>();
            private readonly List<object> _actualEntriesForCacheHit = new List<object>();

            private readonly List<bool> _actualGetResultsForCacheMiss = new List<bool>();
            private readonly List<object> _actualEntriesForCacheMiss = new List<object>();

            protected override void Act()
            {
                const int TestExpirationPeriod = 250;

                var cache = new ExpiringConcurrentDictionaryCacheProvider(TimeSpan.FromMilliseconds(TestExpirationPeriod));
                
                // Wait for midpoint of the first expiration period
                Thread.Sleep(TestExpirationPeriod / 2);

                // Iterate through initial settings and 2 cache expirations
                for (int i = 0; i < 3; i++)
                {
                    object value;

                    // Try to get items (should NOT be there)
                    _actualGetResultsForCacheMiss.Add(cache.TryGetCachedObject("Initial-SetCachedObject1", out value));
                    _actualEntriesForCacheMiss.Add(value);

                    _actualGetResultsForCacheMiss.Add(cache.TryGetCachedObject("Initial-SetCachedObject2", out value));
                    _actualEntriesForCacheMiss.Add(value);

                    // Add new items
                    cache.SetCachedObject("Initial-SetCachedObject1", _suppliedEntries[0]);
                    cache.Insert("Initial-SetCachedObject2", _suppliedEntries[1], DateTime.MaxValue, TimeSpan.Zero);

                    // Try to get items (should STILL be there)
                    _actualGetResultsForCacheHit.Add(cache.TryGetCachedObject("Initial-SetCachedObject1", out value));
                    _actualEntriesForCacheHit.Add(value);

                    _actualGetResultsForCacheHit.Add(cache.TryGetCachedObject("Initial-SetCachedObject2", out value));
                    _actualEntriesForCacheHit.Add(value);

                    // Let the cache expire (and continue midway through next expiration period)
                    Thread.Sleep(TestExpirationPeriod);
                }
            }

            [Test]
            public void Should_return_added_items_before_next_cache_expiration()
            {
                _actualGetResultsForCacheHit.ShouldAllBe(x => x == true);
                _actualEntriesForCacheHit.ShouldAllBe(x => _suppliedEntries.Contains(x));
            }

            [Test]
            public void Should_not_return_added_items_after_next_cache_expiration()
            {
                _actualGetResultsForCacheMiss.ShouldAllBe(x => x == false);
                _actualEntriesForCacheMiss.ShouldAllBe(x => x == null);
            }
        }
    }
}
