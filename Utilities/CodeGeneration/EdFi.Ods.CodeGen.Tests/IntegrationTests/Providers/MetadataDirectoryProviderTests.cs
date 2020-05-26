// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using Castle.Windsor;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen._Installers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Providers
{
    [TestFixture, LocalTestOnly]
    public class MetadataDirectoryProviderTests : TestFixtureBase
    {
        private WindsorContainer _container;
        private IMetadataFolderProvider _metadataFolderProvider;

        protected override void Arrange()
        {
            _container = new WindsorContainer();
            _container.Install(new AppConfigInstaller(), new ProvidersInstaller());
        }

        protected override void Act() => _metadataFolderProvider = _container.Resolve<IMetadataFolderProvider>();

        [Test]
        public void Should_have_a_valid_resolved_standard_metadata_directory()
            => Directory.Exists(_metadataFolderProvider.GetStandardMetadataFolder()).ShouldBeTrue();

        [Test]
        public void Should_have_a_valid_resolved_standard_schema_directory()
            => Directory.Exists(_metadataFolderProvider.GetStandardSchemaFolder()).ShouldBeTrue();

        [Test]
        public void Should_not_be_null() => _metadataFolderProvider.ShouldNotBeNull();
    }
}
