// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensibility;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Startup.Features
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Feature_Conditional_features_are_enabled_by_activation_predicate
    {
        public class When_the_activation_predicate_returns_true : ScenarioFor<FakeConditionalFeature>
        {
            private bool _actualEnabled;

            protected override void Act()
            {
                SystemUnderTest.SuppliedActivationResult = true;
                
                _actualEnabled = SystemUnderTest.IsEnabled();
            }

            [Assert]
            public void Should_indicate_the_feature_is_enabled()
            {
                _actualEnabled.ShouldBeTrue();
            }
        }

        public class When_the_activation_predicate_returns_false : ScenarioFor<FakeConditionalFeature>
        {
            private bool _actualEnabled;

            protected override void Act()
            {
                SystemUnderTest.SuppliedActivationResult = false;

                _actualEnabled = SystemUnderTest.IsEnabled();
            }

            [Assert]
            public void Should_indicate_the_feature_is_NOT_enabled()
            {
                _actualEnabled.ShouldBeFalse();
            }
        }
        
        public class FakeConditionalFeature : ConfigurationBasedFeatureBase
        {
            public FakeConditionalFeature(
                IConfigValueProvider configValueProvider,
                IApiConfigurationProvider apiConfigurationProvider)
                : base(configValueProvider, apiConfigurationProvider) { }

            public bool SuppliedActivationResult { get; set; }
            
            public override IWindsorInstaller Installer => new FakeInstaller();

            protected override Func<IApiConfigurationProvider, IConfigValueProvider, bool> ActivationPredicate 
                => (x, y) => SuppliedActivationResult;
        }

        public class FakeInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store) { }
        }
    }
}
