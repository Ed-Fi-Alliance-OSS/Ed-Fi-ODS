// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.UnitTests.Helpers
{
    [TestFixture]
    public class AssemblyDataHelperTests
    {
        public class When_creating_assembly_data_for_the_data_standard : TestFixtureBase
        {
            private AssemblyDataHelper _assemblyDataHelper;
            private AssemblyData _assemblyData;

            protected override void Arrange()
            {
                var jsonFileProvider = A.Fake<IJsonFileProvider>();
                var assemblyMetadata = new AssemblyMetadata {AssemblyModelType = TemplateSetConventions.Standard};
                A.CallTo(() => jsonFileProvider.Load<AssemblyMetadata>(A<string>.Ignored)).Returns(assemblyMetadata);

                var domainModelDefinitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();
                A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions()).MustNotHaveHappened();

                var domainModelDefinitionsProviderProvider = A.Fake<IDomainModelDefinitionsProviderProvider>();

                A.CallTo(
                        ()
                            => domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName())
                    .Returns(new Dictionary<string, IDomainModelDefinitionsProvider>());

                _assemblyDataHelper = new AssemblyDataHelper(jsonFileProvider, domainModelDefinitionsProviderProvider);
            }

            protected override void Act()
            {
                _assemblyData =
                    _assemblyDataHelper.CreateAssemblyData(
                        "Drive:/Ed-Fi-ODS/Application/EdFi.Ods.Standard/assemblymetadata.json");
            }

            [Test]
            public void Should_create_expected_assembly_data()
            {
                _assemblyData.ShouldSatisfyAllConditions(
                    () => _assemblyData.AssemblyName.ShouldBe("EdFi.Ods.Standard"),
                    () => _assemblyData.IsExtension.ShouldBe(false),
                    () => _assemblyData.IsProfile.ShouldBe(false),
                    () => _assemblyData.Path.ShouldBe("Drive:\\Ed-Fi-ODS\\Application\\EdFi.Ods.Standard"),
                    () => _assemblyData.SchemaName.ShouldBe("EdFi"),
                    () => _assemblyData.TemplateSet.ShouldBe(TemplateSetConventions.Standard)
                );
            }
        }

        public class When_creating_assembly_data_for_an_extension : TestFixtureBase
        {
            private AssemblyDataHelper _assemblyDataHelper;
            private AssemblyData _assemblyData;

            protected override void Arrange()
            {
                var jsonFileProvider = A.Fake<IJsonFileProvider>();
                var assemblyMetadata = new AssemblyMetadata {AssemblyModelType = TemplateSetConventions.Extension};
                A.CallTo(() => jsonFileProvider.Load<AssemblyMetadata>(A<string>.Ignored)).Returns(assemblyMetadata);

                var domainModelDefinitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();
                var domainModelDefinition = new DomainModelDefinitions {SchemaDefinition = new SchemaDefinition("TPDM", "tpdm")};
                A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions()).Returns(domainModelDefinition);

                var domainModelDefinitionsProviderProvider = A.Fake<IDomainModelDefinitionsProviderProvider>();

                var domainModelDefinitionsByProjectName = new Dictionary<string, IDomainModelDefinitionsProvider>
                {
                    {"EdFi.Ods.Extensions.TPDM", domainModelDefinitionsProvider}
                };

                A.CallTo(
                        ()
                            => domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName())
                    .Returns(domainModelDefinitionsByProjectName);

                _assemblyDataHelper = new AssemblyDataHelper(jsonFileProvider, domainModelDefinitionsProviderProvider);
            }

            protected override void Act()
            {
                _assemblyData =
                    _assemblyDataHelper.CreateAssemblyData(
                        "Drive:Ed-Fi-Extensions/Extensions/EdFi.Ods.Extensions.TPDM/assemblymetadata.json");
            }

            [Test]
            public void Should_create_expected_assembly_data()
            {
                _assemblyData.ShouldNotBeNull();

                _assemblyData.ShouldSatisfyAllConditions(
                    () => _assemblyData.AssemblyName.ShouldBe("EdFi.Ods.Extensions.TPDM"),
                    () => _assemblyData.IsExtension.ShouldBe(true),
                    () => _assemblyData.IsProfile.ShouldBe(false),
                    () => _assemblyData.Path.ShouldBe("Drive:Ed-Fi-Extensions\\Extensions\\EdFi.Ods.Extensions.TPDM"),
                    () => _assemblyData.SchemaName.ShouldBe("TPDM"),
                    () => _assemblyData.TemplateSet.ShouldBe(TemplateSetConventions.Extension)
                );
            }
        }

        public class When_creating_assembly_data_for_a_profile : TestFixtureBase
        {
            private AssemblyDataHelper _assemblyDataHelper;
            private AssemblyData _assemblyData;

            protected override void Arrange()
            {
                var jsonFileProvider = A.Fake<IJsonFileProvider>();
                var assemblyMetadata = new AssemblyMetadata { AssemblyModelType = TemplateSetConventions.Profile };
                A.CallTo(() => jsonFileProvider.Load<AssemblyMetadata>(A<string>.Ignored)).Returns(assemblyMetadata);

                var domainModelDefinitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();
                A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions()).MustNotHaveHappened();


                var domainModelDefinitionsProviderProvider = A.Fake<IDomainModelDefinitionsProviderProvider>();

                A.CallTo(
                        ()
                            => domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName())
                    .Returns(new Dictionary<string, IDomainModelDefinitionsProvider>());

                _assemblyDataHelper = new AssemblyDataHelper(jsonFileProvider, domainModelDefinitionsProviderProvider);
            }

            protected override void Act()
            {
                _assemblyData =
                    _assemblyDataHelper.CreateAssemblyData(
                        "Drive:Ed-Fi-Extensions/Extensions/EdFi.Ods.Profiles.Sample/assemblymetadata.json");
            }

            [Test]
            public void Should_create_expected_assembly_data()
            {
                _assemblyData.ShouldNotBeNull();

                _assemblyData.ShouldSatisfyAllConditions(
                    () => _assemblyData.AssemblyName.ShouldBe("EdFi.Ods.Profiles.Sample"),
                    () => _assemblyData.IsExtension.ShouldBe(false),
                    () => _assemblyData.IsProfile.ShouldBe(true),
                    () => _assemblyData.Path.ShouldBe("Drive:Ed-Fi-Extensions\\Extensions\\EdFi.Ods.Profiles.Sample"),
                    () => _assemblyData.SchemaName.ShouldBe("EdFi"),
                    () => _assemblyData.TemplateSet.ShouldBe(TemplateSetConventions.Profile)
                );
            }
        }
    }
}
