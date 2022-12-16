// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common;
using EdFi.Ods.CodeGen.Metadata;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common.Metadata.Profiles;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Models.Validation;

namespace EdFi.Ods.CodeGen.Generators
{
    public abstract class GeneratorBase : IGenerator
    {
        protected ProfileResourceModelProvider ProfileResourceModelProvider;
        protected IProfileResourceNamesProvider ProfileResourceNamesProvider;
        protected bool ProjectHasProfileDefinition;
        protected IResourceModelProvider ResourceModelProvider;
        protected TemplateContext TemplateContext;
        protected ProfileMetadataProvider ProfileMetadataProvider;

        public object Generate(TemplateContext templateContext)
        {
            TemplateContext = Preconditions.ThrowIfNull(templateContext, nameof(templateContext));
            ResourceModelProvider = new ResourceModelProvider(TemplateContext.DomainModelProvider);

            // Profile-related properties
            ProfileMetadataProvider = MetadataHelper.GetProfileMetadataProvider(ResourceModelProvider, templateContext.ProjectPath);
            ProfileResourceNamesProvider = ProfileMetadataProvider;
            ProfileResourceModelProvider = new ProfileResourceModelProvider(
                ResourceModelProvider,
                ProfileMetadataProvider,
                new ProfileValidationReporter());

            ProjectHasProfileDefinition = ProfileMetadataProvider.HasProfileData;

            Configure();

            return Build();
        }

        protected virtual void Configure() { }

        protected abstract object Build();
    }
}
