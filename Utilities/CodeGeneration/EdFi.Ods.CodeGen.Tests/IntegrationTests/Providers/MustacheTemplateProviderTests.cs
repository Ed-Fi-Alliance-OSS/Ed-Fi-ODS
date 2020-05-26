// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen._Installers;
using EdFi.Ods.Common.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Providers
{
    [TestFixture]
    public class MustacheTemplateProviderTests
    {
        public class When_getting_known_mustache_templates_from_the_embedded_resources : TestFixtureBase
        {
            private WindsorContainer _container;
            private readonly string templateName = "Entities";
            private IDictionary<string, string> _result;

            protected override void Arrange()
            {
                _container = new WindsorContainer();
                _container.Install(new AppConfigInstaller(), new ProvidersInstaller());
            }

            protected override void Act() => _result = _container.Resolve<IMustacheTemplateProvider>().GetMustacheTemplates();

            [Test]
            public void Should_contain_a_known_mustache_file() => _result[templateName].ShouldNotBeNullOrEmpty();

            [Test]
            public void Should_have_the_templates() => _result.Count.ShouldBeGreaterThan(1);

            [Test]
            public void Should_not_have_empty_result() => _result.ShouldNotBeNull();

            [Test]
            public void Should_only_contain_names_of_the_mustache_files()
            {
                AssertAll(
                    () => _result.Keys.Any(x => x.EndsWithIgnoreCase("mustache")).ShouldBeFalse(),
                    () => _result.Keys.Any(x => x.EndsWithIgnoreCase("json")).ShouldBeFalse());
            }
        }
    }
}
