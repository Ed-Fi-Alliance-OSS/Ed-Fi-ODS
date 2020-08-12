#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Configuration;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Configuration
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ApiConfigurationProviderTests
    {
        public class When_getting_a_sandbox_api_mode : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private IConfigValueProvider _configValueProvider;
            private IDatabaseEngineProvider _databaseEngineProvider;
            private ApiMode _result;
            private ApiConfigurationProvider _systemUnderTest;

            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();
                _databaseEngineProvider = A.Fake<IDatabaseEngineProvider>();

                A.CallTo(() => _configValueProvider.GetValue(ApiConfigurationConstants.ApiStartupType))
                    .Returns(ApiConfigurationConstants.Sandbox);

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(new Dictionary<string, string> { { "db", ApiConfigurationConstants.SqlServerProviderName } });

                _systemUnderTest = new ApiConfigurationProvider(_configValueProvider, _databaseEngineProvider);
            }

            protected override void Act()
            {
                _result = _systemUnderTest.Mode;
            }

            [Test]
            public void Should_not_be_year_specific()
            {
                _systemUnderTest.IsYearSpecific()
                    .ShouldBe(false);
            }

            [Test]
            public void Should_parse_the_api_mode_with_success()
            {
                _result.ShouldBe(ApiMode.Sandbox);
            }
        }

        public class When_getting_a_year_specific_api_mode : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private IConfigValueProvider _configValueProvider;
            private IDatabaseEngineProvider _databaseEngineProvider;
            private ApiMode _result;
            private ApiConfigurationProvider _systemUnderTest;

            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();
                _databaseEngineProvider = A.Fake<IDatabaseEngineProvider>();

                A.CallTo(() => _configValueProvider.GetValue(ApiConfigurationConstants.ApiStartupType))
                    .Returns(ApiConfigurationConstants.YearSpecific);

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(new Dictionary<string, string> { { "db", ApiConfigurationConstants.SqlServerProviderName } });

                _systemUnderTest = new ApiConfigurationProvider(_configValueProvider, _databaseEngineProvider);
            }

            protected override void Act()
            {
                _result = _systemUnderTest.Mode;
            }

            [Test]
            public void Should_be_year_specific()
            {
                _systemUnderTest.IsYearSpecific()
                    .ShouldBe(true);
            }

            [Test]
            public void Should_parse_the_api_mode_with_success()
            {
                _result.ShouldBe(ApiMode.YearSpecific);
            }
        }

        public class When_getting_a_shared_instance_api_mode : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private IConfigValueProvider _configValueProvider;
            private IDatabaseEngineProvider _databaseEngineProvider;
            private ApiMode _result;
            private ApiConfigurationProvider _systemUnderTest;

            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();
                _databaseEngineProvider = A.Fake<IDatabaseEngineProvider>();

                A.CallTo(() => _configValueProvider.GetValue(ApiConfigurationConstants.ApiStartupType))
                    .Returns(ApiConfigurationConstants.SharedInstance);

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(new Dictionary<string, string> { { "db", ApiConfigurationConstants.SqlServerProviderName } });

                _systemUnderTest = new ApiConfigurationProvider(_configValueProvider, _databaseEngineProvider);
            }

            protected override void Act()
            {
                _result = _systemUnderTest.Mode;
            }

            [Test]
            public void Should_not_be_year_specific()
            {
                _systemUnderTest.IsYearSpecific()
                    .ShouldBe(false);
            }

            [Test]
            public void Should_parse_the_api_mode_with_success()
            {
                _result.ShouldBe(ApiMode.SharedInstance);
            }
        }

        public class When_getting_a_district_specific_api_mode : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private IConfigValueProvider _configValueProvider;
            private IDatabaseEngineProvider _databaseEngineProvider;
            private ApiMode _result;
            private ApiConfigurationProvider _systemUnderTest;

            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();
                _databaseEngineProvider = A.Fake<IDatabaseEngineProvider>();

                A.CallTo(() => _configValueProvider.GetValue(ApiConfigurationConstants.ApiStartupType))
                    .Returns(ApiConfigurationConstants.DistrictSpecific);

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(new Dictionary<string, string> { { "db", ApiConfigurationConstants.SqlServerProviderName } });

                _systemUnderTest = new ApiConfigurationProvider(_configValueProvider, _databaseEngineProvider);
            }

            protected override void Act()
            {
                _result = _systemUnderTest.Mode;
            }

            [Test]
            public void Should_not_be_year_specific()
            {
                _systemUnderTest.IsYearSpecific()
                    .ShouldBe(false);
            }

            [Test]
            public void Should_parse_the_api_mode_with_success()
            {
                _result.ShouldBe(ApiMode.DistrictSpecific);
            }
        }

        public class When_getting_a_empty_api_mode : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private IConfigValueProvider _configValueProvider;
            private IDatabaseEngineProvider _databaseEngineProvider;

            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();
                _databaseEngineProvider = A.Fake<IDatabaseEngineProvider>();

                A.CallTo(() => _configValueProvider.GetValue(ApiConfigurationConstants.ApiStartupType))
                    .Returns(string.Empty);
            }

            protected override void Act()
            {
                _ = new ApiConfigurationProvider(_configValueProvider, _databaseEngineProvider);
            }

            [Test]
            public void Should_throw_a_ConfigurationErrorsException()
            {
                ActualException.ShouldBeOfType<ConfigurationErrorsException>();
            }
        }

        public class When_getting_a_unknown_api_mode : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private IConfigValueProvider _configValueProvider;
            private IDatabaseEngineProvider _databaseEngineProvider;


            protected override void Arrange()
            {
                _configValueProvider = A.Fake<IConfigValueProvider>();
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();
                _databaseEngineProvider = A.Fake<IDatabaseEngineProvider>();

                A.CallTo(() => _configValueProvider.GetValue(ApiConfigurationConstants.ApiStartupType))
                    .Returns("unknown");
            }

            protected override void Act()
            {
                _ = new ApiConfigurationProvider(_configValueProvider, _databaseEngineProvider);
            }

            [Test]
            public void Should_throw_NotSupportedException()
            {
                ActualException.ShouldBeOfType<NotSupportedException>();
            }
        }
    }
}
#endif