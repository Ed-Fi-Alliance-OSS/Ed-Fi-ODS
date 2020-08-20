// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Security.Authorization;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization
{
    public class EducationOrganizationCacheTests
    {
        /// <summary>
        /// Provides a simple implementation of a connection string provider that exposes a property
        /// for the value to be returned.
        /// </summary>
        private class FakeConnectionStringProvider : IDatabaseConnectionStringProvider
        {
            public string CurrentValue { get; set; }

            public string GetConnectionString()
            {
                return CurrentValue;
            }
        }

        /// <summary>
        /// Provides an cache data provider implementation that enables the definition of return values
        /// based on specific connection string values.
        /// </summary>
        private class FakeEducationOrganizationCacheDataProvider
            : IEducationOrganizationCacheDataProvider,
                IEducationOrganizationIdentifiersValueMapper
        {
            private readonly IDatabaseConnectionStringProvider _connectionStringProvider;

            private readonly Dictionary<string, IEnumerable<EducationOrganizationIdentifiers>>
                _resultsByConnectionString
                    = new Dictionary<string, IEnumerable<EducationOrganizationIdentifiers>>();

            public FakeEducationOrganizationCacheDataProvider(IDatabaseConnectionStringProvider connectionStringProvider)
            {
                _connectionStringProvider = connectionStringProvider;
            }

            public Task<IEnumerable<EducationOrganizationIdentifiers>> GetAllEducationOrganizationIdentifiers()
            {
                return
                    Task.Run(() => _resultsByConnectionString[_connectionStringProvider.GetConnectionString()]);
            }

            public EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(string stateOrganizationId)
            {
                throw new NotImplementedException();
            }

            public EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(int educationOrganizationId)
            {
                return new EducationOrganizationIdentifiers(default(int), default(string));
            }

            public void AddResult(string connectionStringValue, IEnumerable<EducationOrganizationIdentifiers> result)
            {
                _resultsByConnectionString[connectionStringValue] = result;
            }
        }

        public class When_retrieving_education_organization_cache_data_using_different_ODS_connection_strings : TestFixtureBase
        {
            private EducationOrganizationIdentifiers actual88ResultForString1;
            private EducationOrganizationIdentifiers actual99ResultForString1;
            private EducationOrganizationIdentifiers actual88ResultForString2;
            private EducationOrganizationIdentifiers actual99ResultForString2;
            private ICacheProvider cacheProvider;
            private IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider;
            private IEducationOrganizationIdentifiersValueMapper educationOrganizationIdentifiersValueMapper;
            private FakeEducationOrganizationCacheDataProvider educationOrganizationCacheDataProvider;
            private FakeConnectionStringProvider connectionStringProvider;

            protected override void Arrange()
            {
                // Create the cache
                var memoryCacheProvider = Stub<MemoryCacheProvider>();
                var edOrgCache = new EducationOrganizationCache(
                    memoryCacheProvider,
                    edFiOdsInstanceIdentificationProvider,
                    educationOrganizationIdentifiersValueMapper,
                    educationOrganizationCacheDataProvider,
                    true);

                connectionStringProvider.CurrentValue = "String1";
                A.CallTo(() => educationOrganizationIdentifiersValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(new EducationOrganizationIdentifiers(
                        99,
                        "School",
                        stateEducationAgencyId: 1,
                        localEducationAgencyId: 9,
                        schoolId: 99));


                actual99ResultForString1 = edOrgCache.GetEducationOrganizationIdentifiers(99);

                A.CallTo(() => educationOrganizationIdentifiersValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(new EducationOrganizationIdentifiers());

                actual88ResultForString1 = edOrgCache.GetEducationOrganizationIdentifiers(88);

                // Then retrieve values for the second connection string
                connectionStringProvider.CurrentValue = "String2";
                A.CallTo(() => educationOrganizationIdentifiersValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(new EducationOrganizationIdentifiers(
                        88,
                        "School",
                        stateEducationAgencyId: 1,
                        localEducationAgencyId: 8,
                        schoolId: 88));

                actual88ResultForString2 = edOrgCache.GetEducationOrganizationIdentifiers(88);

                A.CallTo(() => educationOrganizationIdentifiersValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(new EducationOrganizationIdentifiers());
                actual99ResultForString2 = edOrgCache.GetEducationOrganizationIdentifiers(99);
            }

            [Test]
            public void
                Should_return_cached_data_retrieved_when_the_current_connection_matches_the_connection_where_the_requested_data_is_defined
                ()
            {
                actual99ResultForString1.LocalEducationAgencyId.ShouldBe(9);
                actual88ResultForString2.LocalEducationAgencyId.ShouldBe(8);
            }

            [Test]
            public void
                Should_return_no_data_when_the_current_connection_does_not_match_the_connection_where_the_requested_data_is_defined
                ()
            {
                actual88ResultForString1.EducationOrganizationId.ShouldBe(default(int));
                actual88ResultForString1.EducationServiceCenterId.ShouldBeNull();
                actual88ResultForString1.EducationOrganizationType.ShouldBeNull();
                actual88ResultForString1.LocalEducationAgencyId.ShouldBeNull();
                actual88ResultForString1.SchoolId.ShouldBeNull();
                actual88ResultForString1.StateEducationAgencyId.ShouldBeNull();

                actual99ResultForString2.EducationOrganizationId.ShouldBe(default(int));
                actual99ResultForString2.EducationServiceCenterId.ShouldBeNull();
                actual99ResultForString2.EducationOrganizationType.ShouldBeNull();
                actual99ResultForString2.LocalEducationAgencyId.ShouldBeNull();
                actual99ResultForString2.SchoolId.ShouldBeNull();
                actual99ResultForString2.StateEducationAgencyId.ShouldBeNull();
            }
        }

        public class
            When_getting_education_organization_values_for_non_cached_edorg_id_in_a_synchronously_loaded_cache_and_each_value_mapper_only_returns_the_requested_value
            : TestFixtureBase
        {
            // Supplied values
            private EducationOrganizationIdentifiers suppliedEdOrgValueMap;
            private EducationOrganizationIdentifiers suppliedEducationOrganizationIdentifiers;

            // Actual values
            private readonly List<EducationOrganizationIdentifiers> actualEducationOrganizationIdentifiers =
                new List<EducationOrganizationIdentifiers>();

            // External dependencies
            private IEducationOrganizationIdentifiersValueMapper edOrgValueMapper;
            private IEducationOrganizationCacheDataProvider educationOrganizationIdentifiersProvider;
            private IEdFiOdsInstanceIdentificationProvider edfiOdsInstanceIdentificationProvider;
            private readonly List<Task> _tasks = new List<Task>();
            private const int TaskCount = 50;
            protected override void Arrange()
            {
                edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                edOrgValueMapper = Stub<IEducationOrganizationIdentifiersValueMapper>();
                educationOrganizationIdentifiersProvider = Stub<IEducationOrganizationCacheDataProvider>();

                // edorg value mapper
                suppliedEdOrgValueMap = new EducationOrganizationIdentifiers(
                    educationOrganizationId: 123456,
                    educationOrganizationType: "District",
                    stateEducationAgencyId: 1,
                    educationServiceCenterId: 330950,
                    localEducationAgencyId: 123456);

                A.CallTo(() => edOrgValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(suppliedEdOrgValueMap);

                // edorg identifiers provider
                suppliedEducationOrganizationIdentifiers = new EducationOrganizationIdentifiers(
                    educationOrganizationId: 123456,
                    educationOrganizationType: "District",
                    stateEducationAgencyId: 1,
                    educationServiceCenterId: 330950,
                    localEducationAgencyId: 8675309);

                var memoryCacheProvider = Stub<MemoryCacheProvider>();

                var educationOrganizationCache = new EducationOrganizationCache(
                    memoryCacheProvider,
                    edfiOdsInstanceIdentificationProvider,
                    edOrgValueMapper,
                    educationOrganizationIdentifiersProvider,
                    synchronousInitialization: true);

                var listLock = new object();

                for (var i = 0; i < TaskCount; i++)
                {
                    _tasks.Add(
                        new Task(
                            () =>
                            {
                                var educationOrganizationIdentifiers =
                                    educationOrganizationCache.GetEducationOrganizationIdentifiers(
                                        suppliedEducationOrganizationIdentifiers.EducationOrganizationId);

                                lock (listLock)
                                {
                                    actualEducationOrganizationIdentifiers.Add(educationOrganizationIdentifiers);
                                }
                            }));
                }

                A.CallTo(() => educationOrganizationIdentifiersProvider.GetAllEducationOrganizationIdentifiers())
                    .WithAnyArguments()
                    .Returns(
                        Task.Run(
                            () =>
                            {
                                Task.WaitAll(_tasks.ToArray());

                                return (IEnumerable<EducationOrganizationIdentifiers>)
                                    new[]
                                    {
                                        suppliedEducationOrganizationIdentifiers
                                    };
                            }));
            }

            protected override void Act()
            {
                // Launch threads to try and obtain the edorg Identifiers
                _tasks.ForEach(t => t.Start());
                Task.WaitAll(_tasks.ToArray());
            }

            [Assert]
            public void Should_call_edorg_data_provider_once_to_warm_the_cache()
            {
                A.CallTo(
                        () => educationOrganizationIdentifiersProvider.GetAllEducationOrganizationIdentifiers())
                    .MustHaveHappened();
            }

            [Assert]
            public void Should_NOT_call_edorg_value_mapper_for_the_values()
            {
                A.CallTo(
                    () => edOrgValueMapper.GetEducationOrganizationIdentifiers(suppliedEdOrgValueMap.EducationOrganizationId)).MustNotHaveHappened();
            }

            [Assert]
            public void Should_return_education_organization_values_supplied_by_edorg_data_provider()
            {
                Assert.That(
                    actualEducationOrganizationIdentifiers.Select(x => x.LocalEducationAgencyId)
                        .Distinct(),
                    Is.EqualTo(
                        new[]
                        {
                            suppliedEdOrgValueMap.LocalEducationAgencyId
                        }));
            }
        }

        public class
            When_getting_ed_org_identifiers_for_non_cached_ed_org_id_in_an_asynchronously_loaded_cache_and_each_value_mapper_only_returns_the_requested_value
            : TestFixtureBase
        {
            // Supplied values
            private EducationOrganizationIdentifiers suppliedEdOrgValueMap;
            private EducationOrganizationIdentifiers suppliedEducationOrganizationIdentifiers;

            // Actual values
            private readonly List<EducationOrganizationIdentifiers> actualEducationOrganizationIdentifiers =
                new List<EducationOrganizationIdentifiers>();
            private EducationOrganizationIdentifiers actualEdOrgIds;

            // External dependencies
            private IEducationOrganizationIdentifiersValueMapper edOrgValueMapper;
            private IEducationOrganizationCacheDataProvider educationOrganizationIdentifiersProvider;
            private IEdFiOdsInstanceIdentificationProvider edfiOdsInstanceIdentificationProvider;

            private readonly List<Task> _tasks = new List<Task>();
            private const int TaskCount = 50;

            protected override void Arrange()
            {
                edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                edOrgValueMapper = Stub<IEducationOrganizationIdentifiersValueMapper>();
                educationOrganizationIdentifiersProvider = Stub<IEducationOrganizationCacheDataProvider>();

                // edorg value mapper
                suppliedEdOrgValueMap = new EducationOrganizationIdentifiers(
                    educationOrganizationId: 123456,
                    educationOrganizationType: "District",
                    stateEducationAgencyId: 1,
                    educationServiceCenterId: 330950,
                    localEducationAgencyId: 123456);

                A.CallTo(() => edOrgValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(suppliedEdOrgValueMap);

                // edorg identifiers provider
                suppliedEducationOrganizationIdentifiers = new EducationOrganizationIdentifiers(
                    educationOrganizationId: 123456,
                    educationOrganizationType: "District",
                    stateEducationAgencyId: 1,
                    educationServiceCenterId: 330950,
                    localEducationAgencyId: 8675309);

                var memoryCacheProvider = Stub<MemoryCacheProvider>();

                var educationOrganizationCache = new EducationOrganizationCache(
                    memoryCacheProvider,
                    edfiOdsInstanceIdentificationProvider,
                    edOrgValueMapper,
                    educationOrganizationIdentifiersProvider,
                    synchronousInitialization: false);

                var listLock = new object();

                for (var i = 0; i < TaskCount; i++)
                {
                    _tasks.Add(
                        new Task(
                            () =>
                            {
                                var educationOrganizationIdentifiers =
                                    educationOrganizationCache.GetEducationOrganizationIdentifiers(
                                        suppliedEducationOrganizationIdentifiers.EducationOrganizationId);

                                lock (listLock)
                                {
                                    actualEducationOrganizationIdentifiers.Add(educationOrganizationIdentifiers);
                                }
                            }));
                }

                A.CallTo(() => educationOrganizationIdentifiersProvider.GetAllEducationOrganizationIdentifiers())
                    .WithAnyArguments()
                    .Returns(
                        Task.Run(
                            () =>
                            {
                                Task.WaitAll(_tasks.ToArray());

                                return (IEnumerable<EducationOrganizationIdentifiers>)
                                    new[]
                                    {
                                        suppliedEducationOrganizationIdentifiers
                                    };
                            }));


            }

            protected override void Act()
            {
                // Launch threads to try and obtain the edorg Identifiers
                _tasks.ForEach(t => t.Start());
                Task.WaitAll(_tasks.ToArray());

            }

            [Assert]
            public void Should_call_edorg_data_provider_once_to_warm_the_cache()
            {
                A.CallTo(
                    () => educationOrganizationIdentifiersProvider.GetAllEducationOrganizationIdentifiers()).MustHaveHappened();
            }

            [Assert]
            public void Should_call_ed_org_value_mapper_for_the_ed_org()
            {
                A.CallTo(
                    () => edOrgValueMapper.GetEducationOrganizationIdentifiers(suppliedEdOrgValueMap.EducationOrganizationId)).MustHaveHappened();
            }

            [Assert]
            public void Should_return_education_organization_values_supplied_by_edorg_data_provider()
            {
                Assert.That(
                    actualEducationOrganizationIdentifiers.Select(x => x.LocalEducationAgencyId)
                        .Distinct(),
                    Is.EqualTo(
                        new[]
                        {
                            suppliedEdOrgValueMap.LocalEducationAgencyId
                        }));
            }
        }

        public class When_getting_values_for_nullable_property_with_default_or_non_existant_ed_org_id : TestFixtureBase
        {
            // Actual results
            private EducationOrganizationIdentifiers actualEdOrgIdsFromDefault;
            private EducationOrganizationIdentifiers actualEdOrgIdsFromNonExisting;

            // External dependencies
            private IEducationOrganizationIdentifiersValueMapper edOrgValueMapper;
            private IEducationOrganizationCacheDataProvider educationOrganizationIdentifiersProvider;
            private IEdFiOdsInstanceIdentificationProvider edfiOdsInstanceIdentificationProvider;

            protected override void Arrange()
            {
                edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                edOrgValueMapper = Stub<IEducationOrganizationIdentifiersValueMapper>();
                educationOrganizationIdentifiersProvider = Stub<IEducationOrganizationCacheDataProvider>();

                A.CallTo(() => educationOrganizationIdentifiersProvider.GetAllEducationOrganizationIdentifiers())
                    .WithAnyArguments()
                    .Returns(
                        Task.Run(
                            () =>
                                (IEnumerable<EducationOrganizationIdentifiers>)
                                new EducationOrganizationIdentifiers[0]));

                edOrgValueMapper = Stub<IEducationOrganizationIdentifiersValueMapper>();
                A.CallTo(() => edOrgValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(EducationOrganizationIdentifiers.CreateLookupInstance(default(int)));
            }

            protected override void Act()
            {
                var memoryCacheProvider = Stub<MemoryCacheProvider>();
                var educationOrganizationCache = new EducationOrganizationCache(
                    memoryCacheProvider,
                    edfiOdsInstanceIdentificationProvider,
                    edOrgValueMapper,
                    educationOrganizationIdentifiersProvider,
                    synchronousInitialization: true);

                actualEdOrgIdsFromDefault = educationOrganizationCache.GetEducationOrganizationIdentifiers(default(int));
                actualEdOrgIdsFromNonExisting = educationOrganizationCache.GetEducationOrganizationIdentifiers(-1);
            }

            [Assert]
            public void Should_return_nulls_instead_of_zeros()
            {
                actualEdOrgIdsFromDefault.ShouldBeNull();
                actualEdOrgIdsFromNonExisting.IsDefault.ShouldBeTrue();
            }
        }

        public class When_getting_ed_org_values_for_non_cached_ed_org_ed_org_is_added_to_the_cache_for_subsequent_calls : TestFixtureBase
        {
            //Supplied Values
            private EducationOrganizationIdentifiers suppliedEdOrgValueMap;

            // Actual results
            private EducationOrganizationIdentifiers actualEdOrgIds;

            // External dependencies
            private IEducationOrganizationIdentifiersValueMapper edOrgValueMapper;
            private IEducationOrganizationCacheDataProvider educationOrganizationIdentifiersProvider;
            private IEdFiOdsInstanceIdentificationProvider edfiOdsInstanceIdentificationProvider;

            protected override void Arrange()
            {
                edfiOdsInstanceIdentificationProvider = Stub<IEdFiOdsInstanceIdentificationProvider>();
                edOrgValueMapper = Stub<IEducationOrganizationIdentifiersValueMapper>();
                educationOrganizationIdentifiersProvider = Stub<IEducationOrganizationCacheDataProvider>();

                A.CallTo(() => educationOrganizationIdentifiersProvider.GetAllEducationOrganizationIdentifiers())
                    .WithAnyArguments()
                    .Returns(
                        Task.Run(
                            () =>
                                (IEnumerable<EducationOrganizationIdentifiers>)
                                new EducationOrganizationIdentifiers[0]));

                // edorg value mapper
                suppliedEdOrgValueMap = new EducationOrganizationIdentifiers(
                    educationOrganizationId: 123456,
                    educationOrganizationType: "District",
                    stateEducationAgencyId: 1,
                    educationServiceCenterId: 330950,
                    localEducationAgencyId: 123456);

                A.CallTo(() => edOrgValueMapper.GetEducationOrganizationIdentifiers(default(int)))
                    .WithAnyArguments()
                    .Returns(suppliedEdOrgValueMap);
            }

            protected override void Act()
            {
                var memoryCacheProvider = Stub<MemoryCacheProvider>();

                var educationOrganizationCache = new EducationOrganizationCache(
                    memoryCacheProvider,
                    edfiOdsInstanceIdentificationProvider,
                    edOrgValueMapper,
                    educationOrganizationIdentifiersProvider,
                    synchronousInitialization: true);

                //Two Calls

                educationOrganizationCache.GetEducationOrganizationIdentifiers(suppliedEdOrgValueMap.EducationOrganizationId);
                actualEdOrgIds = educationOrganizationCache.GetEducationOrganizationIdentifiers(suppliedEdOrgValueMap.EducationOrganizationId);
            }

            [Assert]
            public void Should_call_ed_org_value_mapper_for_the_ed_org_ids_once()
            {
                A.CallTo(
                    () => edOrgValueMapper.GetEducationOrganizationIdentifiers(suppliedEdOrgValueMap.EducationOrganizationId)).MustHaveHappened();
            }

            [Assert]
            public void Should_return_correct_values_from_cache()
            {
                actualEdOrgIds.ShouldBe(suppliedEdOrgValueMap);
            }
        }
    }
}
#endif