// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Linq;
using System.Xml.Linq;
using Autofac;
using EdFi.Ods.CodeGen.Metadata;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers;
using EdFi.Ods.Common.Metadata.Schemas;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using NUnit.Framework;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests.Profiles
{
    public class ProfileTestDataHelper
    {
        private const string ProjectDirectory = @"IntegrationTests\Profiles\Xml\";
        private readonly DomainModel _domainModel;

        public ProfileTestDataHelper(string fileName)
        {
            var container = ContainerHelper.CreateContainer(new Options());

            _domainModel = new DomainModelProvider(
                container.Resolve<IDomainModelDefinitionsProviderProvider>()
                    .DomainModelDefinitionProviders(),
                new IDomainModelDefinitionsTransformer[0])
                .GetDomainModel();

            Validator = GetValidator(fileName);
        }

        private string TestFilePath
        {
            get => Path.Combine(TestContext.CurrentContext.TestDirectory, ProjectDirectory);
        }

        public MetadataValidatorBase<Profile> Validator { get; }

        private Common.Metadata.Schemas.Profiles GetProfiles(string fileName)
        {
            var profileDoc = XDocument.Load(Path.Combine(TestFilePath, fileName));

            return MetadataHelper.GetProfiles(profileDoc);
        }

        private MetadataValidatorBase<Profile> GetValidator(string fileName)
        {
            XDocument doc = XDocument.Load(Path.Combine(TestFilePath, fileName));
            var profiles = GetProfiles(fileName);

            return new ProfileMetadataValidator(_domainModel.ResourceModel, profiles.Profile, doc);
        }
    }
}
