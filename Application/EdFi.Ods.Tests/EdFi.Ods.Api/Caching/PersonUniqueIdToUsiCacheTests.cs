// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Entities.NHibernate.StaffAggregate.EdFi;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Caching
{
    [TestFixture]
    public class PersonUniqueIdToUsiCacheTests
    {
        protected const string Staff = "Staff";
        protected const string IsolatedForUnitTest = "IsolatedForUnitTest";

        public class When_getting_and_subsequently_evicting_USI_and_UniqueId_for_initially_non_cached_UniqueId_and_both_values_are_returned_by_usi_value_mapper 
            : TestFixtureBase
        {
            // Supplied values
            private PersonIdentifiersValueMap _suppliedUsiValueMap;
            private List<PersonIdentifiersValueMap> _suppliedPersonIdentifiers;

            // Actual values
            private int _actualUsiFromValueMapper;
            private int _actualUsiFromIdentifiersProvider;

            // External dependencies
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IEdFiOdsInstanceIdentificationProvider _edfiOdsInstanceIdentificationProvider;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToUsiCache _uniqueIdToUsiCache;
            private bool _actualEvictionResult;
            private int _actualUsiAfterEviction;
            private string _actualUniqueIdAfterEviction;
            private string _actualUniqueIdFromValueMapper;

            protected override void Arrange()
            {
                _edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();
                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                _suppliedUsiValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = Guid.NewGuid()
                        .ToString(),
                    Usi = 10,
                    Id = Guid.NewGuid() // Id is also provided by the USI value mapper
                };

                _suppliedPersonIdentifiers = new List<PersonIdentifiersValueMap>
                {
                    new PersonIdentifiersValueMap
                    {
                        UniqueId = Guid.NewGuid()
                            .ToString(),
                        Usi = 100,
                        Id = Guid.NewGuid()
                    },
                    new PersonIdentifiersValueMap
                    {
                        UniqueId = Guid.NewGuid()
                            .ToString(),
                        Usi = 101,
                        Id = Guid.NewGuid()
                    }
                };

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>._, A<string>._))
                    .ReturnsNextFromSequence(
                        // First call retrieves value map from the database successfully
                        _suppliedUsiValueMap, 
                        // For testing eviction (due to removal of data from database), don't supply the map again 
                        new PersonIdentifiersValueMap());

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) _suppliedPersonIdentifiers));

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _uniqueIdToUsiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider,
                        _edfiOdsInstanceIdentificationProvider,
                        _usiValueMapper,
                        _personIdentifiersProvider,
                        synchronousInitialization: true);

                    PersonUniqueIdToUsiCache.GetCache = () => _uniqueIdToUsiCache;
                }
            }

            protected override void Act()
            {
                _actualUsiFromValueMapper = _uniqueIdToUsiCache.GetUsi(Staff, _suppliedUsiValueMap.UniqueId);
                _actualUniqueIdFromValueMapper = _uniqueIdToUsiCache.GetUniqueId(Staff, _suppliedUsiValueMap.Usi);

                _actualUsiFromIdentifiersProvider = _uniqueIdToUsiCache.GetUsi(
                    Staff,
                    _suppliedPersonIdentifiers.First().UniqueId);

                // Test evictions
                _actualEvictionResult = _uniqueIdToUsiCache.TryEvictIdentifier(new Staff(), _suppliedUsiValueMap.Usi);
                _actualUsiAfterEviction = _uniqueIdToUsiCache.GetUsi(Staff, _suppliedUsiValueMap.UniqueId);
                _actualUniqueIdAfterEviction = _uniqueIdToUsiCache.GetUniqueId(Staff, _suppliedUsiValueMap.Usi);
            }

            [Test]
            public void Should_call_person_identifiers_provider_once_to_warm_the_cache()
            {
                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>.That.IsEqualTo(Staff)))
                    .MustHaveHappenedOnceExactly();
            }

            [Test]
            public void Should_call_usi_value_mapper_for_the_usi_not_initially_loaded_into_the_cache()
            {
                A.CallTo(
                        () => _usiValueMapper.GetUsi(
                            A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo(_suppliedUsiValueMap.UniqueId)))
                    .MustHaveHappened();
            }

            [Test]
            public void Should_return_correct_values_from_cache()
            {
                _actualUsiFromValueMapper.ShouldBe(_suppliedUsiValueMap.Usi);
                _actualUniqueIdFromValueMapper.ShouldBe(_suppliedUsiValueMap.UniqueId);
                _actualUsiFromIdentifiersProvider.ShouldBe(_suppliedPersonIdentifiers.First().Usi);
            }

            [Test]
            public void Should_indicate_eviction_of_identifier_was_successful()
            {
                _actualEvictionResult.ShouldBeTrue();
            }

            [Test]
            public void Should_return_default_Usi_after_eviction()
            {
                _actualUsiAfterEviction.ShouldBe(default(int));
            }
            
            [Test]
            public void Should_return_default_UniqueId_after_eviction()
            {
                _actualUniqueIdAfterEviction.ShouldBe(default(string));
            }
        }
    }
}
