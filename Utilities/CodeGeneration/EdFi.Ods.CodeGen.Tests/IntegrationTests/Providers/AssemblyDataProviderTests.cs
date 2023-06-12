// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;
using Autofac;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Providers
{
    [TestFixture]
    public class AssemblyDataProviderTests
    {
        public class When_getting_assembly_data_from_all_providers_with_no_extensions : TestFixtureBase
        {
            private IEnumerable<IAssemblyDataProvider> _assemblyDataProviders;
            private List<AssemblyData> _assemblyData;

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(new Options {
                        StandardVersion = "5.0.0",
                        ExtensionVersion = "1.1.0"
                });

                _assemblyDataProviders = container.Resolve<IEnumerable<IAssemblyDataProvider>>();
            }

            protected override void Act() => _assemblyData = _assemblyDataProviders.SelectMany(x => x.Get()).ToList();

            [Test]
            public void Should_have_correct_assemblies_for_processing()
            {
                var expected = new List<string>
                {
                    "EdFi.Ods.Standard",
                    "ODS Database Specific",
                };

                _assemblyData.Select(x => x.AssemblyName).ForEach(x => expected.ShouldContain(x));
                _assemblyData.Count.ShouldBe(expected.Count);
            }
        }

        public class When_getting_assembly_data_from_all_providers_with_extensions : TestFixtureBase
        {
            private IEnumerable<IAssemblyDataProvider> _assemblyDataProviders;
            private List<AssemblyData> _assemblyData;

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(
                    new Options
                    {
                        ExtensionPaths = new[]
                        {
                            new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory)[
                                CodeRepositoryConventions.ExtensionsRepositoryName]
                        },
                        StandardVersion = "5.0.0",
                        ExtensionVersion = "1.1.0"
                    });

                _assemblyDataProviders = container.Resolve<IEnumerable<IAssemblyDataProvider>>();
            }

            protected override void Act() => _assemblyData = _assemblyDataProviders.SelectMany(x => x.Get()).ToList();

            [Test]
            public void Should_have_correct_assemblies_for_processing()
            {
                var expected = new List<string>
                {
                    "EdFi.Ods.Extensions.Homograph",
                    "EdFi.Ods.Extensions.Sample",
                    "EdFi.Ods.Extensions.TPDM",
                    "EdFi.Ods.Standard",
                    "ODS Database Specific",
                    "EdFi.Ods.Extensions.SampleStudentTranscript",
                    "EdFi.Ods.Extensions.SampleStudentTransportation"
                };

                _assemblyData.Select(x => x.AssemblyName).ForEach(x => expected.ShouldContain(x));
                _assemblyData.Count.ShouldBe(expected.Count);
            }
        }
        public class When_getting_assembly_data_with_no_extensions : TestFixtureBase
        {
            private IAssemblyDataProvider _assemblyDataProvider;
            private List<AssemblyData> _assemblyData;

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(new Options
                {
                    StandardVersion = "5.0.0",
                    ExtensionVersion = "1.1.0"
                });

                _assemblyDataProvider = container.Resolve<IEnumerable<IAssemblyDataProvider>>()
                    .Single(x => x is AssemblyDataProvider);
            }

            protected override void Act() => _assemblyData = _assemblyDataProvider.Get().ToList();

            [Test]
            public void Should_have_correct_assemblies_for_processing()
            {
                var expected = new List<string>
                {
                    "EdFi.Ods.Standard",
                };

                _assemblyData.Select(x => x.AssemblyName).ForEach(x => expected.ShouldContain(x));
                _assemblyData.Count.ShouldBe(expected.Count);
            }
        }

        public class When_getting_assembly_data_with_extensions : TestFixtureBase
        {
            private IAssemblyDataProvider _assemblyDataProvider;
            private List<AssemblyData> _assemblyData;

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(
                    new Options
                    {
                        ExtensionPaths = new[]
                        {
                            new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory)[
                                CodeRepositoryConventions.ExtensionsRepositoryName]
                        },
                        StandardVersion = "5.0.0",
                        ExtensionVersion = "1.1.0"
                    });

                _assemblyDataProvider = container.Resolve<IEnumerable<IAssemblyDataProvider>>()
                    .Single(x => x is AssemblyDataProvider);
            }

            protected override void Act() => _assemblyData = _assemblyDataProvider.Get().ToList();

            [Test]
            public void Should_have_correct_assemblies_for_processing()
            {
                var expected = new List<string>
                {
                    "EdFi.Ods.Extensions.Homograph",
                    "EdFi.Ods.Extensions.Sample",
                    "EdFi.Ods.Extensions.TPDM",
                    "EdFi.Ods.Standard",
                    "EdFi.Ods.Extensions.SampleStudentTranscript",
                    "EdFi.Ods.Extensions.SampleStudentTransportation"
                };

                _assemblyData.Select(x => x.AssemblyName).ForEach(x => expected.ShouldContain(x));
                _assemblyData.Count.ShouldBe(expected.Count);
            }
        }
    }
}
