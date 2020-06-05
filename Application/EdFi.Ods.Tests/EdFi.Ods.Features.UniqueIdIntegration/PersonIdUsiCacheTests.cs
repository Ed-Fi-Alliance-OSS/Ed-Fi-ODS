// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Features.UniqueIdIntegration.Caching;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.UniqueIdIntegration
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PersonIdUsiCacheTests
    {
        protected const string Staff = "Staff";
        protected const string IsolatedForUnitTest = "IsolatedForUnitTest";

        public class
            When_getting_usi_and_id_for_non_cached_unique_id_and_both_values_are_returned_by_usi_value_mapper : TestFixtureBase
        {
            // Supplied values
            private PersonIdentifiersValueMap _suppliedUsiValueMap;
            private List<PersonIdentifiersValueMap> _suppliedPersonIdentifiers;

            // Actual values
            private int _actualUsiFromValueMapper;
            private int _actualUsiFromIdentifiersProvider;

            // External dependencies
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IUniqueIdToIdValueMapper _idValueMapper;
            private IEdFiOdsInstanceIdentificationProvider _edfiOdsInstanceIdentificationProvider;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private Guid _actualId;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToIdCache _idCache;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _idValueMapper = Stub<IUniqueIdToIdValueMapper>();
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

                A.CallTo(() => _idValueMapper.GetId(A<string>._, A<string>._))
                    .Returns(new PersonIdentifiersValueMap());

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>._, A<string>._))
                    .Returns(_suppliedUsiValueMap);

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) _suppliedPersonIdentifiers));

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _idCache = new PersonUniqueIdToIdCache(
                        _memoryCacheProvider,
                        _edfiOdsInstanceIdentificationProvider,
                        _idValueMapper);

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider,
                        _edfiOdsInstanceIdentificationProvider,
                        _usiValueMapper,
                        _personIdentifiersProvider,
                        synchronousInitialization: true);

                    PersonUniqueIdToUsiCache.GetCache = () => _usiCache;
                }
            }

            protected override void Act()
            {
                _actualUsiFromValueMapper = _usiCache.GetUsi(Staff, _suppliedUsiValueMap.UniqueId);

                _actualUsiFromIdentifiersProvider = _usiCache.GetUsi(
                    Staff,
                    _suppliedPersonIdentifiers.First()
                        .UniqueId);

                _actualId = _idCache.GetId(Staff, _suppliedUsiValueMap.UniqueId);
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
                _actualUsiFromIdentifiersProvider.ShouldBe(_suppliedPersonIdentifiers.First().Usi);
            }
        }

        public class
            When_getting_usi_and_id_for_non_cached_unique_id_in_a_synchronously_loaded_cache_and_each_value_mapper_only_returns_the_requested_value
            : TestFixtureBase
        {
            // Supplied values
            private PersonIdentifiersValueMap _suppliedUsiValueMap;
            private PersonIdentifiersValueMap _suppliedIdValueMap;

            // Actual values
            private readonly List<int> _actualUSIs = new List<int>();
            private Guid _actualId;

            // External dependencies
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IUniqueIdToIdValueMapper _idValueMapper;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private IEdFiOdsInstanceIdentificationProvider _edfiOdsInstanceIdentificationProvider;
            private PersonIdentifiersValueMap _suppliedPersonIdentifiersValueMap;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToIdCache _idCache;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _idValueMapper = Stub<IUniqueIdToIdValueMapper>();
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();
                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                // usi value mapper
                _suppliedUsiValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = Guid.NewGuid()
                        .ToString(),
                    Usi = 10
                };

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>._, A<string>._)).Returns(_suppliedIdValueMap);

                // id value mapper
                _suppliedIdValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = _suppliedUsiValueMap.UniqueId, // Same uniqueId
                    Id = Guid.NewGuid()
                };

                A.CallTo(() => _idValueMapper.GetId(A<string>._, A<string>._)).Returns(_suppliedIdValueMap);

                // person identifiers provider
                _suppliedPersonIdentifiersValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = _suppliedUsiValueMap.UniqueId, // Same uniqueId
                    Usi = 100
                };

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._)).Returns(
                    Task.Run(
                        () =>
                        {
                            //Force slight delay during initialization to mimic real behavior.
                            Thread.Sleep(10);

                            return
                                (IEnumerable<PersonIdentifiersValueMap>) new[] {_suppliedPersonIdentifiersValueMap};
                        }
                    ));

                _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                _idCache = new PersonUniqueIdToIdCache(
                    _memoryCacheProvider,
                    _edfiOdsInstanceIdentificationProvider,
                    _idValueMapper);

                _usiCache = new PersonUniqueIdToUsiCache(
                    _memoryCacheProvider,
                    _edfiOdsInstanceIdentificationProvider,
                    _usiValueMapper,
                    _personIdentifiersProvider,
                    synchronousInitialization: true);
            }

            protected override void Act()
            {
                _actualId = _idCache.GetId(Staff, _suppliedUsiValueMap.UniqueId);

                // Launch 50 threads to try and obtain the USI
                object listLock = new object();
                var tasks = new List<Task>();

                for (int i = 0; i < 50; i++)
                {
                    tasks.Add(
                        Task.Run(
                            () =>
                            {
                                int usi = _usiCache.GetUsi(Staff, _suppliedUsiValueMap.UniqueId);

                                lock (listLock)
                                {
                                    _actualUSIs.Add(usi);
                                }
                            }));
                }

                Task.WaitAll(tasks.ToArray());
            }

            [Test]
            public void Should_call_person_identifiers_provider_once_to_warm_the_cache()
            {
                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>.That.IsEqualTo(Staff)))
                    .MustHaveHappenedOnceExactly();
            }

            [Test]
            public void Should_call_the_id_value_mapper_for_the_id()
            {
                A.CallTo(
                        () => _idValueMapper.GetId(
                            A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo(_suppliedIdValueMap.UniqueId)))
                    .MustHaveHappened();
            }

            [Test]
            public void Should_NOT_call_usi_value_mapper_for_the_usi()
            {
                A.CallTo(
                        () => _usiValueMapper.GetUsi(
                            A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo(_suppliedIdValueMap.UniqueId)))
                    .MustNotHaveHappened();
            }

            [Test]
            public void Should_return_id_value_supplied_by_the_id_value_mapper()
            {
                _actualId.ShouldBe(_suppliedIdValueMap.Id);
            }

            [Test]
            public void Should_return_usi_value_supplied_by_person_identifiers_provider()
            {
                Assert.That(
                    _actualUSIs.Distinct(),
                    Is.EqualTo(
                        new[] {_suppliedPersonIdentifiersValueMap.Usi}));
            }
        }

        public class
            When_getting_usi_and_id_for_non_cached_unique_id_in_an_asynchronously_loaded_cache_and_each_value_mapper_only_returns_the_requested_value
            : TestFixtureBase
        {
            // Supplied values
            private PersonIdentifiersValueMap _suppliedUsiValueMap;
            private PersonIdentifiersValueMap _suppliedIdValueMap;

            // Actual values
            private readonly List<int> _actualUSIs = new List<int>();
            private Guid _actualId;

            // External dependencies
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IUniqueIdToIdValueMapper _idValueMapper;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private IEdFiOdsInstanceIdentificationProvider _edfiOdsInstanceIdentificationProvider;
            private PersonIdentifiersValueMap _suppliedPersonIdentifiersValueMap;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToIdCache _idCache;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _idValueMapper = Stub<IUniqueIdToIdValueMapper>();
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();
                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                // usi value mapper
                _suppliedUsiValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = Guid.NewGuid()
                        .ToString(),
                    Usi = 10
                };

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>._, A<string>._))
                    .Returns(_suppliedUsiValueMap);

                // id value mapper
                _suppliedIdValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = _suppliedUsiValueMap.UniqueId, // Same uniqueId
                    Id = Guid.NewGuid()
                };

                A.CallTo(() => _idValueMapper.GetId(A<string>._, A<string>._))
                    .Returns(_suppliedIdValueMap);

                _suppliedPersonIdentifiersValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = Guid.NewGuid()
                        .ToString(),
                    Usi = 100
                };

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(
                        Task.Run(
                            () =>
                            {
                                //Force slight delay during initialization to mimic real behavior.
                                Thread.Sleep(10);

                                return
                                    (IEnumerable<PersonIdentifiersValueMap>) new[] {_suppliedPersonIdentifiersValueMap};
                            }
                        ));

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _idCache = new PersonUniqueIdToIdCache(
                        _memoryCacheProvider, _edfiOdsInstanceIdentificationProvider, _idValueMapper);

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider, _edfiOdsInstanceIdentificationProvider, _usiValueMapper, _personIdentifiersProvider,
                        synchronousInitialization: false);
                }
            }

            protected override void Act()
            {
                _actualId = _idCache.GetId(Staff, _suppliedUsiValueMap.UniqueId);

                // Launch 50 threads to try and obtain the USI
                object listLock = new object();
                var tasks = new List<Task>();

                for (int i = 0; i < 50; i++)
                {
                    tasks.Add(
                        Task.Run(
                            () =>
                            {
                                int usi = _usiCache.GetUsi(Staff, _suppliedUsiValueMap.UniqueId);

                                lock (listLock)
                                {
                                    _actualUSIs.Add(usi);
                                }
                            }));
                }

                Task.WaitAll(tasks.ToArray());
            }

            [Test]
            public void Should_call_person_identifiers_provider_once_to_warm_the_cache()
            {
                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>.That.IsEqualTo(Staff)))
                    .MustHaveHappenedOnceExactly();
            }

            [Test]
            public void Should_call_the_id_value_mapper_for_the_id()
            {
                A.CallTo(
                        () => _idValueMapper.GetId(
                            A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo(_suppliedIdValueMap.UniqueId)))
                    .MustHaveHappened();
            }

            [Test]
            public void Should_call_usi_value_mapper_for_the_usi()
            {
                A.CallTo(
                        () => _usiValueMapper.GetUsi(
                            A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo(_suppliedIdValueMap.UniqueId)))
                    .MustHaveHappened();
            }

            [Test]
            public void Should_return_id_value_supplied_by_the_id_value_mapper()
            {
                _actualId.ShouldBe(_suppliedIdValueMap.Id);
            }

            [Test]
            public void Should_return_usi_value_supplied_by_the_usi_value_mapper()
            {
                Assert.That(
                    _actualUSIs.Distinct(),
                    Is.EqualTo(
                        new[] {_suppliedUsiValueMap.Usi}));
            }
        }

        public class When_getting_usi_for_nullable_property_with_empty_or_null_or_non_existing_uniqueids : TestFixtureBase
        {
            // Actual results
            private int? _actualUsiFromEmpty;
            private int? _actualUsiFromNull;
            private int? _actualUsiFromNonExisting;

            // External dependencies
            private IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IUniqueIdToIdValueMapper _idValueMapper;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edFiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) new PersonIdentifiersValueMap[0]));

                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>._, A<string>._)).Returns(new PersonIdentifiersValueMap());

                _idValueMapper = Stub<IUniqueIdToIdValueMapper>();

                A.CallTo(() => _idValueMapper.GetId(A<string>._, A<string>._))
                    .Returns(new PersonIdentifiersValueMap());

                _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                _usiCache = new PersonUniqueIdToUsiCache(
                    _memoryCacheProvider, _edFiOdsInstanceIdentificationProvider, _usiValueMapper, _personIdentifiersProvider,
                    synchronousInitialization: true);
            }

            protected override void Act()
            {
                _actualUsiFromEmpty = _usiCache.GetUsiNullable(Staff, string.Empty);
                _actualUsiFromNull = _usiCache.GetUsiNullable(Staff, null);
                _actualUsiFromNonExisting = _usiCache.GetUsiNullable(Staff, "NotThere");
            }

            [Test]
            public void Should_return_nulls_instead_of_zeros()
            {
                _actualUsiFromEmpty.ShouldBeNull();
                _actualUsiFromNull.ShouldBeNull();
                _actualUsiFromNonExisting.ShouldBeNull();
            }
        }

        public class
            When_getting_usi_for_non_nullable_property_with_empty_or_null_or_non_existing_uniqueids : TestFixtureBase
        {
            // Actual results
            private int? _actualUsiFromEmpty;
            private int? _actualUsiFromNull;
            private int? _actualUsiFromNonExisting;

            // External dependencies
            private IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IUniqueIdToIdValueMapper _idValueMapper;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edFiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) new PersonIdentifiersValueMap[0]));

                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>._, A<string>._))
                    .Returns(new PersonIdentifiersValueMap());

                _idValueMapper = Stub<IUniqueIdToIdValueMapper>();

                A.CallTo(() => _idValueMapper.GetId(A<string>._, A<string>._))
                    .Returns(new PersonIdentifiersValueMap());

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider, _edFiOdsInstanceIdentificationProvider, _usiValueMapper, _personIdentifiersProvider,
                        synchronousInitialization: true);
                }
            }

            protected override void Act()
            {
                _actualUsiFromEmpty = _usiCache.GetUsi(Staff, string.Empty);
                _actualUsiFromNull = _usiCache.GetUsi(Staff, null);
                _actualUsiFromNonExisting = _usiCache.GetUsi(Staff, "NotThere");
            }

            [Test]
            public void Should_return_zeros_instead_of_nulls()
            {
                _actualUsiFromEmpty.ShouldBe(0);
                _actualUsiFromNull.ShouldBe(0);
                _actualUsiFromNonExisting.ShouldBe(0);
            }
        }

        public class
            When_getting_usi_for_non_cached_unique_id_unique_id_is_added_to_the_cache_for_subsequent_calls : TestFixtureBase
        {
            // Supplied values
            private PersonIdentifiersValueMap _suppliedUsiValueMap;

            // Actual values
            private int _actualUsi;
            private string _actualUniqueId;

            // External dependencies
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IEdFiOdsInstanceIdentificationProvider _edfiOdsInstanceIdentificationProvider;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();

                _suppliedUsiValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = Guid.NewGuid()
                        .ToString(),
                    Usi = 10,
                    Id = Guid.NewGuid() // Id is also provided by the USI value mapper
                };

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>._, A<string>._))
                    .Returns(_suppliedUsiValueMap);

                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) new PersonIdentifiersValueMap[0]));

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider,
                        _edfiOdsInstanceIdentificationProvider,
                        _usiValueMapper,
                        _personIdentifiersProvider,
                        synchronousInitialization: true);

                    PersonUniqueIdToUsiCache.GetCache = () => _usiCache;
                }
            }

            protected override void Act()
            {
                _actualUsi = _usiCache.GetUsi(Staff, _suppliedUsiValueMap.UniqueId);
                _actualUniqueId = _usiCache.GetUniqueId(Staff, _suppliedUsiValueMap.Usi);
            }

            [Test]
            public void Should_call_usi_value_mapper_for_the_usi()
            {
                A.CallTo(
                        () => _usiValueMapper.GetUsi(
                            A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo(_suppliedUsiValueMap.UniqueId)))
                    .MustHaveHappened();
            }

            [Test]
            public void Should_have_opportunistically_cached_the_unique_id_from_the_usi_value_mapper()
            {
                // Value was cached opportunistically by initial call, so no call necessary
                A.CallTo(
                    () => _usiValueMapper.GetUniqueId(
                        A<string>.That.IsEqualTo(Staff), A<int>.That.IsEqualTo(_suppliedUsiValueMap.Usi))).MustNotHaveHappened();
            }

            [Test]
            public void Should_return_correct_values_from_cache()
            {
                _actualUsi.ShouldBe(_suppliedUsiValueMap.Usi);
                _actualUniqueId.ShouldBe(_suppliedUsiValueMap.UniqueId);
            }
        }

        public class
            When_getting_unique_id_for_non_cached_unique_id_usi_is_added_to_the_cache_for_subsequent_calls : TestFixtureBase
        {
            // Supplied values
            private PersonIdentifiersValueMap _suppliedUsiValueMap;

            // Actual values
            private int _actualUsi;
            private string _actualUniqueId;

            // External dependencies
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IEdFiOdsInstanceIdentificationProvider _edfiOdsInstanceIdentificationProvider;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();

                _suppliedUsiValueMap = new PersonIdentifiersValueMap
                {
                    UniqueId = Guid.NewGuid()
                        .ToString(),
                    Usi = 10,
                    Id = Guid.NewGuid() // Id is also provided by the USI value mapper
                };

                A.CallTo(() => _usiValueMapper.GetUniqueId(A<string>._, A<int>._))
                    .Returns(_suppliedUsiValueMap);

                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) new PersonIdentifiersValueMap[0]));

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider,
                        _edfiOdsInstanceIdentificationProvider,
                        _usiValueMapper,
                        _personIdentifiersProvider,
                        synchronousInitialization: true);

                    PersonUniqueIdToUsiCache.GetCache = () => _usiCache;
                }
            }

            protected override void Act()
            {
                _actualUniqueId = _usiCache.GetUniqueId(Staff, _suppliedUsiValueMap.Usi);
                _actualUsi = _usiCache.GetUsi(Staff, _suppliedUsiValueMap.UniqueId);
            }

            [Test]
            public void Should_call_value_mapper_for_the_unique_id()
            {
                A.CallTo(
                    () => _usiValueMapper.GetUniqueId(
                        A<string>.That.IsEqualTo(Staff), A<int>.That.IsEqualTo(_suppliedUsiValueMap.Usi))).MustHaveHappened();
            }

            [Test]
            public void Should_have_opportunistically_cached_the_usi_from_the_value_mapper()
            {
                // Value was cached opportunistically by initial call, so no call necessary
                A.CallTo(
                        () => _usiValueMapper.GetUsi(
                            A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo(_suppliedUsiValueMap.UniqueId)))
                    .MustNotHaveHappened();
            }

            [Test]
            public void Should_return_correct_values_from_cache()
            {
                _actualUsi.ShouldBe(_suppliedUsiValueMap.Usi);
                _actualUniqueId.ShouldBe(_suppliedUsiValueMap.UniqueId);
            }
        }

        internal class FakeEdFiOdsInstanceIdentificationProvider : IEdFiOdsInstanceIdentificationProvider
        {
            private int value;

            public int GetInstanceIdentification()
            {
                return value;
            }

            public void SetInstanceIdentification(int value)
            {
                this.value = value;
            }
        }

        public class When_getting_uniqueId_by_usis_that_are_not_in_the_cache_from_different_ODS_instances : TestFixtureBase
        {
            // Actual values
            private string _actualUniqueIdFromOds1;
            private string _actualUniqueIdFromOds2;

            // External dependencies
            private FakeEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edFiOdsInstanceIdentificationProvider = new FakeEdFiOdsInstanceIdentificationProvider();
                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) new PersonIdentifiersValueMap[0]));

                // USI value mapper gets call twice during Act step, with first value on ODS instance 1, and second on ODS instance 2
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();

                A.CallTo(() => _usiValueMapper.GetUniqueId(A<string>.That.IsEqualTo(Staff), A<int>.That.IsEqualTo(11)))
                    .Returns(
                        new PersonIdentifiersValueMap
                        {
                            UniqueId = "ABC123",
                            Usi = 11
                        }).Once();

                A.CallTo(() => _usiValueMapper.GetUniqueId(A<string>.That.IsEqualTo(Staff), A<int>.That.IsEqualTo(11)))
                    .Returns(
                        new PersonIdentifiersValueMap
                        {
                            UniqueId = "CDE234",
                            Usi = 11
                        }).Once();

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider,
                        _edFiOdsInstanceIdentificationProvider,
                        _usiValueMapper,
                        _personIdentifiersProvider,
                        synchronousInitialization: true);
                }
            }

            protected override void Act()
            {
                // Populate cache value from ODS instance 1
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(1);
                _usiCache.GetUniqueId(Staff, 11);

                // Populate cache value from ODS instance 2
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(2);
                _usiCache.GetUniqueId(Staff, 11);

                // Get cached value for ODS instance 1
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(1);
                _actualUniqueIdFromOds1 = _usiCache.GetUniqueId(Staff, 11);

                // Get cached value for ODS instance 2
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(2);
                _actualUniqueIdFromOds2 = _usiCache.GetUniqueId(Staff, 11);
            }

            [Test]
            public void Should_retrieve_uniqueIds_from_cache_based_on_the_ODS_context()
            {
                _actualUniqueIdFromOds2.ShouldBe("ABC123");
                _actualUniqueIdFromOds1.ShouldBe("CDE234");
            }
        }

        public class
            When_getting_uniqueId_by_usis_that_are_initialized_in_the_cache_from_different_ODS_instances : TestFixtureBase
        {
            // Actual values
            private string _actualUniqueIdFromOds1;
            private string _actualUniqueIdFromOds2;

            // External dependencies
            private FakeEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edFiOdsInstanceIdentificationProvider = new FakeEdFiOdsInstanceIdentificationProvider();

                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>.That.IsEqualTo(Staff)))
                    .Returns(
                        Task.Run(
                            () =>
                                (IEnumerable<PersonIdentifiersValueMap>)
                                new[]
                                {
                                    new PersonIdentifiersValueMap
                                    {
                                        UniqueId = "ABC123",
                                        Usi = 11
                                    }
                                })).Once();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>.That.IsEqualTo(Staff)))
                    .Returns(
                        Task.Run(
                            () =>
                                (IEnumerable<PersonIdentifiersValueMap>)
                                new[]
                                {
                                    new PersonIdentifiersValueMap
                                    {
                                        UniqueId = "CDE234",
                                        Usi = 11
                                    }
                                })).Once();

                // USI value mapper gets call twice during Act step, with first value on ODS instance 1, and second on ODS instance 2
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider,
                        _edFiOdsInstanceIdentificationProvider,
                        _usiValueMapper,
                        _personIdentifiersProvider,
                        synchronousInitialization: true);
                }
            }

            protected override void Act()
            {
                // Get cached value for ODS instance 1
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(1);
                _actualUniqueIdFromOds1 = _usiCache.GetUniqueId(Staff, 11);

                // Get cached value for ODS instance 2
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(2);
                _actualUniqueIdFromOds2 = _usiCache.GetUniqueId(Staff, 11);
            }

            [Test]
            public void Should_retrieve_uniqueIds_from_cache_based_on_the_ODS_context()
            {
                _actualUniqueIdFromOds2.ShouldBe("ABC123");
                _actualUniqueIdFromOds1.ShouldBe("CDE234");
            }
        }

        public class
            When_getting_usis_from_different_ODS_instances_and_id_value_mapper_does_not_provide_the_id : TestFixtureBase
        {
            // Supplied values
            private Guid _suppliedIdForUniqueIdABC123;

            // Actual values
            private int _actualUsiFromOds1;
            private int _actualUsiFromOds2;

            // External dependencies
            private FakeEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
            private IUniqueIdToUsiValueMapper _usiValueMapper;
            private IUniqueIdToIdValueMapper _idValueMapper;
            private IPersonIdentifiersProvider _personIdentifiersProvider;
            private Guid _actualIdFromOds1;
            private Guid _actualIdFromOds2;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToIdCache _idCache;
            private PersonUniqueIdToUsiCache _usiCache;

            protected override void Arrange()
            {
                _edFiOdsInstanceIdentificationProvider = new FakeEdFiOdsInstanceIdentificationProvider();
                _personIdentifiersProvider = Stub<IPersonIdentifiersProvider>();

                A.CallTo(() => _personIdentifiersProvider.GetAllPersonIdentifiers(A<string>._))
                    .Returns(Task.Run(() => (IEnumerable<PersonIdentifiersValueMap>) new PersonIdentifiersValueMap[0]));

                _suppliedIdForUniqueIdABC123 = Guid.NewGuid();

                // USI value mapper gets call twice during Act step, with first value on ODS instance 1, and second on ODS instance 2
                _usiValueMapper = Stub<IUniqueIdToUsiValueMapper>();

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo("ABC123")))
                    .Returns(
                        new PersonIdentifiersValueMap
                        {
                            UniqueId = "ABC123",
                            Usi = 11
                        }).Once();

                A.CallTo(() => _usiValueMapper.GetUsi(A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo("ABC123")))
                    .Returns(
                        new PersonIdentifiersValueMap
                        {
                            UniqueId = "ABC123",
                            Usi = 22
                        }).Once();

                _idValueMapper = Stub<IUniqueIdToIdValueMapper>();

                A.CallTo(() => _idValueMapper.GetId(A<string>.That.IsEqualTo(Staff), A<string>.That.IsEqualTo("ABC123")))
                    .Returns(
                        new PersonIdentifiersValueMap
                        {
                            UniqueId = "ABC123",
                            Id = _suppliedIdForUniqueIdABC123
                        }).Once();

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _idCache = new PersonUniqueIdToIdCache(
                        _memoryCacheProvider,
                        _edFiOdsInstanceIdentificationProvider,
                        _idValueMapper);

                    _usiCache = new PersonUniqueIdToUsiCache(
                        _memoryCacheProvider,
                        _edFiOdsInstanceIdentificationProvider,
                        _usiValueMapper,
                        _personIdentifiersProvider,
                        synchronousInitialization: true);
                }
            }

            protected override void Act()
            {
                // Populate cached value from ODS instance 1
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(1);
                _usiCache.GetUsi(Staff, "ABC123");

                // Populate cached value from ODS instance 2
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(2);
                _usiCache.GetUsi(Staff, "ABC123");

                // Get cached values from ODS instance 1
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(1);
                _actualUsiFromOds1 = _usiCache.GetUsi(Staff, "ABC123");
                _actualIdFromOds1 = _idCache.GetId(Staff, "ABC123");

                // Get cached values from ODS instance 2
                _edFiOdsInstanceIdentificationProvider.SetInstanceIdentification(2);
                _actualUsiFromOds2 = _usiCache.GetUsi(Staff, "ABC123");
                _actualIdFromOds2 = _idCache.GetId(Staff, "ABC123");
            }

            [Test]
            public void Should_retrieve_USI_value_from_cache_based_on_ODS_instances_in_context()
            {
                _actualUsiFromOds2.ShouldBe(11);
                _actualUsiFromOds1.ShouldBe(22);
            }

            [Test]
            public void Should_return_the_same_Id_independent_of_ODS_instance()
            {
                _actualIdFromOds1.ShouldBe(_suppliedIdForUniqueIdABC123);
                _actualIdFromOds2.ShouldBe(_suppliedIdForUniqueIdABC123);
            }
        }

        public class When_getting_UniqueId_by_id : TestFixtureBase
        {
            // Supplied values
            private Guid _suppliedId;

            // Actual values
            private string _actualFirstValue;
            private string _actualSecondValue;
            private Exception _actualExceptionOnSecondRequestForValue;

            // External dependencies
            private IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
            private IUniqueIdToIdValueMapper _idValueMapper;
            private MemoryCacheProvider _memoryCacheProvider;
            private PersonUniqueIdToIdCache _idCache;

            protected override void Arrange()
            {
                _edFiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();

                _suppliedId = Guid.NewGuid();

                _idValueMapper = Stub<IUniqueIdToIdValueMapper>();

                A.CallTo(() => _idValueMapper.GetUniqueId(A<string>.That.IsEqualTo(Staff), A<Guid>.That.IsEqualTo(_suppliedId)))
                    .Returns(
                        new PersonIdentifiersValueMap
                        {
                            Id = _suppliedId,
                            UniqueId = "ABC123"
                        });

                SetupCaching();

                void SetupCaching()
                {
                    _memoryCacheProvider = new MemoryCacheProvider {MemoryCache = new MemoryCache(IsolatedForUnitTest)};

                    _idCache = new PersonUniqueIdToIdCache(
                        _memoryCacheProvider,
                        _edFiOdsInstanceIdentificationProvider,
                        _idValueMapper);
                }
            }

            protected override void Act()
            {
                _actualFirstValue = _idCache.GetUniqueId(Staff, _suppliedId);

                // Based on Rhino expectation, this will fail if value mapper is called twice by the cache
                try
                {
                    _actualSecondValue = _idCache.GetUniqueId(Staff, _suppliedId);
                }
                catch (Exception ex)
                {
                    _actualExceptionOnSecondRequestForValue = ex;
                }
            }

            [Test]
            public void Should_not_call_value_mapper_a_second_time_for_same_value()
            {
                _actualExceptionOnSecondRequestForValue.ShouldBeNull();
            }

            [Test]
            public void Should_return_uniqueId_value()
            {
                _actualFirstValue.ShouldBe("ABC123");
                _actualSecondValue.ShouldBe("ABC123");
            }
        }
    }
}
