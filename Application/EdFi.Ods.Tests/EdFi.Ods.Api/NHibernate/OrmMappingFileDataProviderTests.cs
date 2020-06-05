// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.NHibernate
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class OrmMappingFileDataProviderTests
    {
        private const string EdFiOdsStandard = OrmMappingFileConventions.OrmMappingAssembly;
        private const string Unknown = "Unknown";

        public class When_getting_orm_mapping_data_for_the_standard_assembly_using_sqlServer : TestFixtureBase
        {
            private IAssembliesProvider _assembliesProvider;
            private OrmMappingFileDataProvider _ormMappingFileDataProvider;
            private OrmMappingFileData _result;

            protected override void Arrange()
            {
                _assembliesProvider = Stub<IAssembliesProvider>();

                A.CallTo(() => _assembliesProvider.Get(A<string>._))
                    .Returns(
                        AppDomain.CurrentDomain.GetAssemblies()
                            .FirstOrDefault(x => x.GetName().Name.EqualsIgnoreCase(EdFiOdsStandard)));

                _ormMappingFileDataProvider = new OrmMappingFileDataProvider(_assembliesProvider, DatabaseEngine.SqlServer, EdFiOdsStandard);
            }

            protected override void Act()
            {
                _result = _ormMappingFileDataProvider.OrmMappingFileData();
            }

            [Test]
            public void Should_find_the_assembly_in_the_current_app_domain()
                => A.CallTo(() => _assembliesProvider.Get(A<string>.That.IsEqualTo(EdFiOdsStandard))).MustHaveHappened();

            [Test]
            public void Should_create_the_dto() => _result.ShouldNotBeNull();

            [Test]
            public void Should_contain_the_assembly_requested() => _result.Assembly.ShouldNotBeNull();

            [Test]
            public void Should_contain_three_mapping_file_paths_to_be_loaded() => _result.MappingFileFullNames.Length.ShouldBe(3);

            [Test]
            public void Should_return_the_mapping_file_paths_for_sqlServer()
                => _result.MappingFileFullNames.All(x => x.ContainsIgnoreCase(DatabaseEngine.SqlServer.ScriptsFolderName));
        }

        public class When_getting_orm_mapping_data_for_the_standard_assembly_using_postgreSql : TestFixtureBase
        {
            private IAssembliesProvider _assembliesProvider;
            private OrmMappingFileDataProvider _ormMappingFileDataProvider;
            private OrmMappingFileData _result;

            protected override void Arrange()
            {
                _assembliesProvider = Stub<IAssembliesProvider>();

                A.CallTo(() => _assembliesProvider.Get(A<string>._))
                    .Returns(
                        AppDomain.CurrentDomain.GetAssemblies()
                            .FirstOrDefault(x => x.GetName().Name.EqualsIgnoreCase(EdFiOdsStandard)));

                _ormMappingFileDataProvider = new OrmMappingFileDataProvider(_assembliesProvider, DatabaseEngine.Postgres, EdFiOdsStandard);
            }

            protected override void Act()
            {
                _result = _ormMappingFileDataProvider.OrmMappingFileData();
            }

            [Test]
            public void Should_find_the_assembly_in_the_current_app_domain()
                => A.CallTo(() => _assembliesProvider.Get(A<string>.That.IsEqualTo(EdFiOdsStandard))).MustHaveHappened();

            [Test]
            public void Should_create_the_dto() => _result.ShouldNotBeNull();

            [Test]
            public void Should_contain_the_assembly_requested() => _result.Assembly.ShouldNotBeNull();

            [Test]
            public void Should_contain_three_mapping_file_paths_to_be_loaded() => _result.MappingFileFullNames.Length.ShouldBe(3);

            [Test]
            public void Should_return_the_mapping_file_paths_for_postgreSql()
                => _result.MappingFileFullNames.All(x => x.ContainsIgnoreCase(DatabaseEngine.Postgres.ScriptsFolderName));
        }

        public class When_getting_orm_mapping_data_for_an_assembly_not_found_using_sqlServer : TestFixtureBase
        {
            private IAssembliesProvider _assembliesProvider;
            private OrmMappingFileDataProvider _ormMappingFileDataProvider;
            private OrmMappingFileData _result;

            protected override void Arrange()
            {
                _assembliesProvider = Stub<IAssembliesProvider>();

                A.CallTo(() => _assembliesProvider.Get(A<string>._))
                    .Returns(
                        AppDomain.CurrentDomain.GetAssemblies()
                            .FirstOrDefault(x => x.GetName().Name.EqualsIgnoreCase(Unknown)));

                _ormMappingFileDataProvider = new OrmMappingFileDataProvider(_assembliesProvider, DatabaseEngine.Postgres, Unknown);
            }

            protected override void Act()
            {
                _result = _ormMappingFileDataProvider.OrmMappingFileData();
            }

            [Test]
            public void Should_find_the_assembly_in_the_current_app_domain()
                => A.CallTo(() => _assembliesProvider.Get(A<string>.That.IsEqualTo(Unknown))).MustHaveHappened();

            [Test]
            public void Should_create_the_dto() => _result.ShouldNotBeNull();

            [Test]
            public void Should_contain_a_null_assembly() => _result.Assembly.ShouldBeNull();

            [Test]
            public void Should_contain_three_mapping_file_paths_to_be_loaded() => _result.MappingFileFullNames.Length.ShouldBe(3);

            [Test]
            public void Should_return_the_mapping_file_paths_for_sqlServer()
                => _result.MappingFileFullNames.All(x => x.ContainsIgnoreCase(DatabaseEngine.Postgres.ScriptsFolderName));
        }
    }
}
