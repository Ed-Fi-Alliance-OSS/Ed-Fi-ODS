// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
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
        public abstract class MultipleStandardVersionsFixtureBase : TestFixtureBase
        {
            protected readonly string StandardVersion;

            public MultipleStandardVersionsFixtureBase(string standardVersion)
            {
                StandardVersion = standardVersion;
            }

            public static readonly string[] StandardVersions =
            {
                "4.0.0",
                "5.2.0",
                "6.0.0"
            };
        }

        [TestFixtureSource(nameof(base.StandardVersions))]
        public class When_getting_assembly_data_from_all_providers_with_no_extensions : MultipleStandardVersionsFixtureBase
        {
            private IEnumerable<IAssemblyDataProvider> _assemblyDataProviders;
            private List<AssemblyData> _assemblyData;

            public When_getting_assembly_data_from_all_providers_with_no_extensions(string version) : base(version) { }

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(new Options
                {
                    StandardVersion = StandardVersion,
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
                    "EdFi.Ods.Standard"
                };

                _assemblyData.Select(x => x.AssemblyName).ForEach(x => expected.ShouldContain(x));
                _assemblyData.Count.ShouldBe(expected.Count);
            }
        }

        [TestFixtureSource(nameof(base.StandardVersions))]
        public class When_getting_assembly_data_from_all_providers_with_extensions : MultipleStandardVersionsFixtureBase
        {
            private IEnumerable<IAssemblyDataProvider> _assemblyDataProviders;
            private List<AssemblyData> _assemblyData;

            public When_getting_assembly_data_from_all_providers_with_extensions(string version) : base(version) { }

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(
                    new Options
                    {
                        ExtensionPaths = new List<string>
                        {
                            new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory)[CodeRepositoryConventions.Extensions]
                        },
                        StandardVersion = StandardVersion,
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
                    "EdFi.Ods.Standard",
                    "EdFi.Ods.Extensions.SampleAlternativeEducationProgram",
                    "EdFi.Ods.Extensions.SampleStudentTranscript",
                };

                if (Version.Parse(StandardVersion).Major < 6)
                {
                    expected.Add("EdFi.Ods.Extensions.TPDM");
                }

                _assemblyData.Select(x => x.AssemblyName).ForEach(x => expected.ShouldContain(x));
                _assemblyData.Count.ShouldBe(expected.Count);
            }
        }

        [TestFixtureSource(nameof(base.StandardVersions))]
        public class When_getting_assembly_data_with_no_extensions : MultipleStandardVersionsFixtureBase
        {
            private IAssemblyDataProvider _assemblyDataProvider;
            private List<AssemblyData> _assemblyData;

            public When_getting_assembly_data_with_no_extensions(string version) : base(version) { }

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(new Options
                {
                    StandardVersion = StandardVersion,
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

        [TestFixtureSource(nameof(base.StandardVersions))]
        public class When_getting_assembly_data_with_extensions : MultipleStandardVersionsFixtureBase
        {
            private IAssemblyDataProvider _assemblyDataProvider;
            private List<AssemblyData> _assemblyData;

            public When_getting_assembly_data_with_extensions(string version) : base(version) { }

            protected override void Arrange()
            {
                var container = ContainerHelper.CreateContainer(
                    new Options
                    {
                        ExtensionPaths = [
                           new CodeRepositoryHelper(TestContext.CurrentContext.TestDirectory)[CodeRepositoryConventions.Extensions]
                        ],
                        StandardVersion = StandardVersion,
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
                    "EdFi.Ods.Standard",
                    "EdFi.Ods.Extensions.SampleAlternativeEducationProgram",
                    "EdFi.Ods.Extensions.SampleStudentTranscript",
                };

                if (Version.Parse(StandardVersion).Major < 6)
                {
                    expected.Add("EdFi.Ods.Extensions.TPDM");
                }

                _assemblyData.Select(x => x.AssemblyName).ForEach(x => expected.ShouldContain(x));
                _assemblyData.Count.ShouldBe(expected.Count);
            }
        }
    }
}
