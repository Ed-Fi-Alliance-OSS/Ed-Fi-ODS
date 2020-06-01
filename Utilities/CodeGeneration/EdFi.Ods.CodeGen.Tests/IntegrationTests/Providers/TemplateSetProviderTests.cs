// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac;
using EdFi.Ods.CodeGen.Models.Configuration;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Providers
{
    [TestFixture]
    public class TemplateSetProviderTests
    {
        public class When_reading_the_template_set_data_from_assembly_embedded_resource : TestFixtureBase
        {
            private IContainer _container;
            private readonly string templateSetName = "standard";
            private IReadOnlyList<TemplateSet> _result;

            protected override void Arrange() => _container = ContainerHelper.CreateContainer();

            protected override void Act()
                => _result =
                    _container.Resolve<ITemplateSetProvider>()
                        .GetTemplatesByName(templateSetName);

            [Test]
            public void Should_has_content() => (_result.Count > 0).ShouldBeTrue();

            [Test]
            public void Should_not_have_empty_result() => _result.ShouldNotBeNull();
        }

        public class When_passing_valid_template_set_name : TestFixtureBase
        {
            private IContainer _container;
            private readonly string templateSetName = "standard";
            private IReadOnlyList<TemplateSet> _result;

            protected override void Arrange() => _container = ContainerHelper.CreateContainer();

            protected override void Act()
                => _result =
                    _container.Resolve<ITemplateSetProvider>()
                        .GetTemplatesByName(templateSetName);

            [Test]
            public void Should_has_content() => _result.Count.ShouldBeGreaterThan(0);

            [Test]
            public void Should_not_have_empty_result() => _result.ShouldNotBeNull();
        }

        public class When_passing_non_existing_template_set_name
        {
            private readonly string templateSetName = "nonExistingTemplate";
            private IContainer _container;

            [Test]
            public void Should_throw_error()
            {
                // Arrange
                _container = ContainerHelper.CreateContainer();

                // Act
                var exception =
                    Assert.Throws<ArgumentOutOfRangeException>(
                        () => _container.Resolve<ITemplateSetProvider>()
                            .GetTemplatesByName(templateSetName));

                // Assert
                exception.Message.ShouldMatch(nameof(templateSetName));
            }
        }
    }
}
