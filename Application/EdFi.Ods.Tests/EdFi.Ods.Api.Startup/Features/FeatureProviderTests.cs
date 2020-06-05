// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Features;
using EdFi.Ods.Common.Extensibility;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Startup.Features
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class FeatureProviderTests
    {
        public class When_getting_enabled_features_when_no_features_are_available : TestFixtureBase
        {
            private IFeatureProvider _systemUnderTest;
            private IFeature[] _results;

            protected override void Arrange()
            {

                _systemUnderTest = new FeatureProvider(new IFeature[0]);
            }

            protected override void Act() => _results = _systemUnderTest.EnabledFeatures();

            [Test]
            public void Should_return_no_features() => _results.Length.ShouldBe(0);
        }

        public class When_getting_enabled_features_when_a_feature_is_enabled : TestFixtureBase
        {
            private IFeatureProvider _systemUnderTest;
            private IFeature[] _results;
            private IFeature _feature;

            protected override void Arrange()
            {
                _feature = Stub<IFeature>();

                A.CallTo(() => _feature.IsEnabled()).Returns(true);

                _systemUnderTest = new FeatureProvider(new []{_feature});
            }

            protected override void Act() => _results = _systemUnderTest.EnabledFeatures();

            [Test]
            public void Should_check_if_the_feature_is_enabled() => A.CallTo(() => _feature.IsEnabled()).MustHaveHappened();

            [Test]
            public void Should_return_one_feature() => _results.Length.ShouldBe(1);
        }

        public class When_getting_enabled_features_when_a_feature_is_enabled_and_a_feature_is_disabled : TestFixtureBase
        {
            private IFeatureProvider _systemUnderTest;
            private IFeature[] _results;
            private IFeature _enabledFeature;
            private IFeature _disabledFeature;

            protected override void Arrange()
            {
                _enabledFeature = Stub<IFeature>();
                _disabledFeature = Stub<IFeature>();

                A.CallTo(() => _enabledFeature.IsEnabled()).Returns(true);
                A.CallTo(() => _disabledFeature.IsEnabled()).Returns(false);

                _systemUnderTest = new FeatureProvider(new []{_enabledFeature, _disabledFeature});
            }

            protected override void Act() => _results = _systemUnderTest.EnabledFeatures();

            [Test]
            public void Should_check_if_the_enabled_feature_is_enabled() => A.CallTo(() => _enabledFeature.IsEnabled()).MustHaveHappened();
            
            [Test]
            public void Should_check_if_the_disabled_feature_is_enabled() => A.CallTo(() => _disabledFeature.IsEnabled()).MustHaveHappened();

            [Test]
            public void Should_return_one_feature() => _results.Length.ShouldBe(1);
        }
    }
}
