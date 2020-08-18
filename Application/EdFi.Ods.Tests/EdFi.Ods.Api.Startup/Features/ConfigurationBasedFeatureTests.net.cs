// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Startup.Features
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Feature_Configuration_based_features_are_enabled_by_configuration_value
    {
        public class When_the_featureIsEnabled_configuration_value_is_true : ScenarioFor<FakeConfigurationBasedFeature>
        {
            private bool _actualEnabled;

            protected override void Arrange()
            {
                A.CallTo(() =>
                        Given<IConfigValueProvider>()
                            .GetValue(A<string>.Ignored))
                    .Returns("true");
            }

            protected override void Act()
            {
                _actualEnabled = SystemUnderTest.IsEnabled();
            }

            [Assert]
            public void Should_read_the_configuration_value_defined_by_the_feature()
            {
                A.CallTo(() =>
                        Given<IConfigValueProvider>()
                            .GetValue(SystemUnderTest.ConfigKey))
                    .MustHaveHappened();
            }
        
            [Assert]
            public void Should_indicate_the_feature_is_enabled()
            {
                _actualEnabled.ShouldBeTrue();
            }
        }

        public class When_the_featureIsEnabled_configuration_value_is_false : ScenarioFor<FakeConfigurationBasedFeature>
        {
            private bool _actualEnabled;

            protected override void Arrange()
            {
                A.CallTo(() =>
                        Given<IConfigValueProvider>()
                            .GetValue(A<string>.Ignored))
                    .Returns("false");
            }

            protected override void Act()
            {
                _actualEnabled = SystemUnderTest.IsEnabled();
            }

            [Assert]
            public void Should_read_the_configuration_value_defined_by_the_feature()
            {
                A.CallTo(() =>
                        Given<IConfigValueProvider>()
                            .GetValue(SystemUnderTest.ConfigKey))
                    .MustHaveHappened();
            }
        
            [Assert]
            public void Should_indicate_the_feature_is_NOT_enabled()
            {
                _actualEnabled.ShouldBeFalse();
            }
        }

        public class When_the_featureIsEnabled_configuration_value_is_not_parseable_to_boolean : ScenarioFor<FakeConfigurationBasedFeature>
        {
            private bool _actualEnabled;

            protected override void Arrange()
            {
                A.CallTo(() =>
                        Given<IConfigValueProvider>()
                            .GetValue(A<string>.Ignored))
                    .Returns("not-parseable-to-boolean");
            }

            protected override void Act()
            {
                _actualEnabled = SystemUnderTest.IsEnabled();
            }

            [Assert]
            public void Should_read_the_configuration_value_defined_by_the_feature()
            {
                A.CallTo(() =>
                        Given<IConfigValueProvider>()
                            .GetValue(SystemUnderTest.ConfigKey))
                    .MustHaveHappened();
            }
        
            [Assert]
            public void Should_indicate_the_feature_is_NOT_enabled()
            {
                _actualEnabled.ShouldBeFalse();
            }
        }

        public class FakeConfigurationBasedFeature : ConfigurationBasedFeatureBase
        {
            public FakeConfigurationBasedFeature(IConfigValueProvider configValueProvider, IApiConfigurationProvider apiConfigurationProvider)
                : base(configValueProvider, apiConfigurationProvider) { }

            public override IWindsorInstaller Installer => new FakeInstaller();
        }

        public class FakeInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                
            }
        }
    }
}
