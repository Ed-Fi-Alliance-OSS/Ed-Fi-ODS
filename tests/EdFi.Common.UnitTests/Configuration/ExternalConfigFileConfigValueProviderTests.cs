// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Diagnostics.CodeAnalysis;
using System.IO;
using EdFi.Ods.Common.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Configuration
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ExternalConfigFileConfigValueProviderTests
    {
        private static readonly string ExternalConfigFileName = Path.Combine(TestContext.CurrentContext.TestDirectory, "SampleExternal.config");
        private const string NoAppSettingsConfig = "NoAppSettings.config";
        private const string KeyForStringValue = "a";
        private const string ValueForStringValue = "a1";
        private const string KeyForBoolValue = "b";
        private const string KeyThatDoesNotExist = "KeyThatDoesNotExist";

        // Official LegacyTestFixtureBase is not useful here. Creating custom fixture for shared code.
        public abstract class Fixture
        {
            private ExternalConfigFileSectionProvider _externalConfigFileSectionProvider;
            protected ExternalConfigFileConfigValueProvider SystemUnderTest;
            protected abstract string ConfigFileName { get; }

            [SetUp]
            public void SetUp()
            {
                _externalConfigFileSectionProvider = new ExternalConfigFileSectionProvider(ConfigFileName);
                SystemUnderTest = new ExternalConfigFileConfigValueProvider(_externalConfigFileSectionProvider);
            }
        }

        [TestFixture]
        public class When_file_does_not_have_an_appSettings_section : Fixture
        {
            protected override string ConfigFileName
            {
                get => NoAppSettingsConfig;
            }

            [Test]
            public void Should_return_null()
            {
                SystemUnderTest.GetValue(KeyForStringValue)
                               .ShouldBeNull();
            }
        }

        [TestFixture]
        public class When_getting_string_value : Fixture
        {
            protected override string ConfigFileName
            {
                get => ExternalConfigFileName;
            }

            [Test]

            public void Should_return_the_string_when_key_exists()
            {
                SystemUnderTest.GetValue(KeyForStringValue)
                               .ShouldBe(ValueForStringValue);
            }

            [Test]
            public void Should_return_the_null_when_key_does_not_exist()
            {
                SystemUnderTest.GetValue(KeyThatDoesNotExist)
                                .ShouldBeNull();
            }
        }
    }
}
