// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using EdFi.Common.Utils;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Dtos;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Utils;
using FakeItEasy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.NHibernate
{
    [TestFixture]
    public class DescriptorsCacheTests
    {
        protected const string TestDescriptorName = "AcademicSubjectDescriptor";
        protected DescriptorLookup TestDescriptorNormal = new DescriptorLookup
        {
            Id = 100,
            DescriptorValue = "uri://ed-fi.org/AcademicSubjectDescriptor#110",
            DescriptorName = TestDescriptorName
        };
        protected DescriptorLookup TestDescriptorCustom = new DescriptorLookup
        {
            Id = 200,
            DescriptorValue = "uri://www.changetest.org/AcademicSubjectDescriptor#110",
            DescriptorName = TestDescriptorName
        };
        protected DescriptorLookup TestDescriptorCustomNotIncluded = new DescriptorLookup
        {
            Id = 300,
            DescriptorValue = "uri://www.changetest.org/AcademicSubjectDescriptor#210",
            DescriptorName = TestDescriptorName
        };
        protected DescriptorLookup TestDescriptorWithCodeValue = new DescriptorLookup
        {
            Id = 400,
            DescriptorValue =
                "uri://www.changetest.org/AcademicSubjectDescriptor#Mathematics",
            DescriptorName = TestDescriptorName
        };

        protected IDescriptorLookupProvider MockDescriptorCacheDataProvider { get; set; }

        protected MemoryCacheProvider CacheProvider { get; set; }

        protected IEdFiOdsInstanceIdentificationProvider MockEdFiOdsInstanceIdentificationProvider { get; set; }

        protected DescriptorsCache descriptionCache;

        private IDescriptorsCache MockNHibernateCallsAndInitializeCache()
        {
            MockDescriptorCacheDataProvider = A.Fake<IDescriptorLookupProvider>();

            A.CallTo(() => MockDescriptorCacheDataProvider.GetAllDescriptorLookups())
                .Returns(
                    new Dictionary<string, IList<DescriptorLookup>>
                    {
                        {
                            TestDescriptorName, new List<DescriptorLookup>
                            {
                                TestDescriptorNormal,
                                TestDescriptorCustom,
                                TestDescriptorWithCodeValue
                            }
                        }
                    });

            Dictionary<string, IList<DescriptorLookup>> values = new Dictionary<string, IList<DescriptorLookup>>
            {
                {
                    TestDescriptorName, new List<DescriptorLookup>
                    {
                        TestDescriptorNormal,
                        TestDescriptorCustom,
                        TestDescriptorWithCodeValue
                    }
                }
            };

            var memorycacheoption = A.Fake<IOptions<MemoryCacheOptions>>();

            MemoryCache memoryCache = new MemoryCache(memorycacheoption);

            CacheProvider = new MemoryCacheProvider(memoryCache);
            CacheProvider.Insert(TestDescriptorName, values, DateTime.MaxValue, TimeSpan.FromMinutes(5));

            MockEdFiOdsInstanceIdentificationProvider =
                A.Fake<IEdFiOdsInstanceIdentificationProvider>();

            A.CallTo(() => MockEdFiOdsInstanceIdentificationProvider.GetInstanceIdentification())
                .Returns(1);

            descriptionCache = new DescriptorsCache(
                MockDescriptorCacheDataProvider, CacheProvider, MockEdFiOdsInstanceIdentificationProvider);
            return descriptionCache;
        }

        [Test]
        public void GetId_ForDescriptor_ByFullyQualifiedValue_CaseInsensitiveCompare_FindsCorrectId()
        {
            var cache = MockNHibernateCallsAndInitializeCache();

            var returnedId = descriptionCache.GetId(TestDescriptorName, "uri://www.changetest.org/academicSubjectDescriptor#mathematics");
            Assert.AreEqual(TestDescriptorWithCodeValue.Id, returnedId);
        }

        [Test]
        public void GetId_ForDescriptor_ByFullyQualifiedValue_FindsCorrectId()
        {
            var cache = MockNHibernateCallsAndInitializeCache();
            var returnedId = cache.GetId(TestDescriptorName, "uri://ed-fi.org/AcademicSubjectDescriptor#110");
            Assert.AreEqual(TestDescriptorNormal.Id, returnedId);
        }

        [Test]
        public void GetId_ForDescriptor_ByFullyQualifiedValue_IncorrectFormatting_DoesNotFindCorrectId()
        {
            var cache = MockNHibernateCallsAndInitializeCache();
            Should.Throw<BadRequestException>(() => cache.GetId(TestDescriptorName, "uri://ed-fi.org110"));
        }

        [Test]
        public void GetId_ForDescriptor_ByFullyQualifiedValue_IncorrectFormatting2_DoesNotFindCorrectId()
        {
            var cache = MockNHibernateCallsAndInitializeCache();
            Should.Throw<BadRequestException>(() => cache.GetId(TestDescriptorName, "ed-fi.org/110"));
        }

        [Test]
        public void GetId_ForDescriptor_ByUnQualifiedValue_DoesNotFindCorrectId()
        {
            var cache = MockNHibernateCallsAndInitializeCache();
            Should.Throw<BadRequestException>(() => cache.GetId(TestDescriptorName, "110"));
        }

        [Test]
        public void GetId_ForDescriptor_ForMissingValue_Forces_DatabaseFetch_And_Cache_Update()
        {
            var cache = MockNHibernateCallsAndInitializeCache();

            A.CallTo(() => MockDescriptorCacheDataProvider.GetDescriptorLookupsByDescriptorName(TestDescriptorName))
                .Returns(
                    new List<DescriptorLookup>
                    {
                        TestDescriptorNormal,
                        TestDescriptorCustom,
                        TestDescriptorCustomNotIncluded
                    });

            SystemClock.Now = () => DateTime.UtcNow.AddHours(1);
            var returnedId = cache.GetId(TestDescriptorName, "uri://www.changetest.org/AcademicSubjectDescriptor#210");

            A.CallTo(() => MockDescriptorCacheDataProvider.GetDescriptorLookupsByDescriptorName(TestDescriptorName))
                .MustHaveHappened();

            Assert.AreEqual(TestDescriptorCustomNotIncluded.Id, returnedId);
        }

        [Test]
        public void GetId_ForDescriptor_ForMissingValue_Throws_Exception_If_DatabaseSynchronization_Also_Did_Not_Find_It()
        {
            var cache = MockNHibernateCallsAndInitializeCache();
            SystemClock.Now = () => DateTime.UtcNow.AddHours(1);
            Should.Throw<BadRequestException>(() => cache.GetId(TestDescriptorName, "descriptorValue"));
        }

        [Test]
        public void GetValue_ForDescriptor_CustomNamespaceValue_ReturnsFullyQualifiedValue()
        {
            var cache = MockNHibernateCallsAndInitializeCache();
            SystemClock.Now = () => DateTime.UtcNow.AddHours(1);
            var returnedValue = cache.GetValue(TestDescriptorName, TestDescriptorCustom.Id);
            Assert.AreEqual(TestDescriptorCustom.DescriptorValue, returnedValue);
        }

        [Test]
        public void GetValue_ForDescriptor_DefaultDomainValue_ReturnsFullyQualifiedValue()
        {
            var cache = MockNHibernateCallsAndInitializeCache();
            var returnedValue = cache.GetValue(TestDescriptorName, TestDescriptorNormal.Id);
            Assert.AreEqual(TestDescriptorNormal.DescriptorValue, returnedValue);
        }
    }
}
#endif