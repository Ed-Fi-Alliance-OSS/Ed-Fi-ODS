#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Configuration
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NameValueCollectionConfigValueProviderTests
    {
        private const string KeyForStringValue = "a";
        private const string ValueForStringValue = "a1";
        private const string KeyForBoolValue = "b";
        private const string KeyThatDoesNotExist = "KeyThatDoesNotExist";
        private const string NextKeyValue = "NextKey";
        private const string NextStringValue = "asdfasdfasdf";
        private const bool NextBoolValue = true;

        // Official LegacyTestFixtureBase is not useful here. Creating custom fixture for shared code.
        public abstract class FixtureWithoutNext
        {
            protected NameValueCollectionConfigValueProvider SystemUnderTest;

            [SetUp]
            public void SetUp()
            {
                SystemUnderTest = new NameValueCollectionConfigValueProvider
                {
                    Values = new NameValueCollection()
                                               {
                                                   {
                                                       KeyForStringValue, ValueForStringValue
                                                   },
                                                   {
                                                       KeyForBoolValue, "true"
                                                   }
                                               }
                };
            }
        }

        public abstract class FixtureWithNext
        {
            protected NameValueCollectionConfigValueProvider SystemUnderTest;
            protected IConfigValueProvider MockNext = A.Fake<IConfigValueProvider>();

            [SetUp]
            public void SetUp()
            {
                SystemUnderTest = new NameValueCollectionConfigValueProvider(MockNext)
                {
                    Values = new NameValueCollection()
                                               {
                                                   {
                                                       KeyForStringValue, ValueForStringValue
                                                   },
                                                   {
                                                       KeyForBoolValue, "true"
                                                   }
                                               }
                };
            }
        }

        [TestFixture]
        public class When_getting_string_value : FixtureWithoutNext
        {
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

        [TestFixture]
        public class When_getting_string_value_from_next_provider : FixtureWithNext
        {
            [Test]
            public void Should_call_next_provider_when_key_does_not_exist()
            {
                A.CallTo(() => MockNext.GetValue(NextKeyValue))
                        .Returns(NextStringValue);

                SystemUnderTest.GetValue(NextKeyValue)
                               .ShouldBe(NextStringValue);
            }
        }
    }
}
#endif