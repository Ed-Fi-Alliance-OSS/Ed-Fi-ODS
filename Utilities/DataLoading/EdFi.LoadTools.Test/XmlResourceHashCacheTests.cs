// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.IO;
using EdFi.LoadTools.Engine;
using NUnit.Framework;

namespace EdFi.LoadTools.Test
{
    public class XmlResourceHashCacheTests
    {
        private class Configuration : IHashCacheConfiguration, IThrottleConfiguration
        {
            public string Folder => Directory.GetCurrentDirectory();

            public int ConnectionLimit => 5;

            public int TaskCapacity => 10;

            public int MaxSimultaneousRequests => 5;
        }

        [TestFixture]
        public class WhenCreatingLotsOfHashes
        {
            private readonly List<byte[]> _bytes = new List<byte[]>();
            private readonly Configuration _configuration = new Configuration();
            private readonly HashProvider _hashProvider = new HashProvider();
            private ResourceHashCache _cache;

            [SetUp]
            public void Setup()
            {
                var rnd = new Random(100);
                _cache = new ResourceHashCache(_configuration, _configuration, _hashProvider);

                for (var i = 0; i < 1000000; i++)
                {
                    var bytes = new byte[32];
                    rnd.NextBytes(bytes);
                    _cache.Add(bytes);

                    if (i % 100 == 0)
                    {
                        _bytes.Add(bytes);
                    }
                }
            }

            [Test]
            public void Should_find_all_cached_values()
            {
                foreach (var item in _bytes)
                {
                    Assert.IsTrue(_cache.Exists(item));
                }
            }
        }

        [TestFixture]
        public class WhenSavingAndLoadingToFile
        {
            private readonly List<byte[]> _bytes = new List<byte[]>();
            private readonly Configuration _configuration = new Configuration();
            private readonly HashProvider _hashProvider = new HashProvider();
            private ResourceHashCache _cache1;
            private ResourceHashCache _cache2;
            private string _filename;

            [SetUp]
            public void Setup()
            {
                _filename = Path.Combine(_configuration.Folder, Path.GetRandomFileName());
                var rnd = new Random(100);
                _cache1 = new ResourceHashCache(_configuration, _configuration, _hashProvider);

                for (var i = 0; i < 1000000; i++)
                {
                    var bytes = new byte[_hashProvider.Bytes];
                    rnd.NextBytes(bytes);
                    _cache1.Add(bytes);
                    _bytes.Add(bytes);
                }

                _cache1.Save(_filename);

                _cache2 = new ResourceHashCache(_configuration, _configuration, _hashProvider);
                _cache2.Load(_filename);
            }

            [TearDown]
            public void Cleanup()
            {
                File.Delete(_filename);
            }

            [Test]
            public void Should_find_all_cached_values_in_loaded_cache()
            {
                foreach (var item in _bytes)
                {
                    Assert.IsTrue(_cache2.Exists(item));
                }
            }
        }
    }
}
