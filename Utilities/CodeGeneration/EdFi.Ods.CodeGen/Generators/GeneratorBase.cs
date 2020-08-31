// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers.Impl;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators
{
    public abstract class GeneratorBase : IGenerator
    {
        protected ProfileResourceModelProvider ProfileResourceModelProvider;
        protected IProfileResourceNamesProvider ProfileResourceNamesProvider;
        protected bool ProjectHasProfileDefinition;
        protected IResourceModelProvider ResourceModelProvider;
        protected TemplateContext TemplateContext;
        protected ValidatingProfileMetadataProvider ValidatingProfileMetadataProvider;

        public object Generate(TemplateContext templateContext)
        {
            TemplateContext = Preconditions.ThrowIfNull(templateContext, nameof(templateContext));
            ResourceModelProvider = new ResourceModelProvider(TemplateContext.DomainModelProvider);

            ValidatingProfileMetadataProvider = new ValidatingProfileMetadataProvider(
                TemplateContext.ProjectPath,
                ResourceModelProvider);

            ProfileResourceNamesProvider = ValidatingProfileMetadataProvider;

            ProfileResourceModelProvider = new ProfileResourceModelProvider(
                ResourceModelProvider,
                ValidatingProfileMetadataProvider);

            ProjectHasProfileDefinition = ValidatingProfileMetadataProvider.HasProfileData;

            Configure();

            return Build();
        }

        protected virtual void Configure() { }

        protected abstract object Build();
    }
}
