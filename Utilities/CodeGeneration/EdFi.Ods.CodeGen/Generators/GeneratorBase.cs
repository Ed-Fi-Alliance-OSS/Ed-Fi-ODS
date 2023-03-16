// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Generators
{
    public abstract class GeneratorBase : IGenerator
    {
        protected IResourceModelProvider ResourceModelProvider;
        protected TemplateContext TemplateContext;

        public object Generate(TemplateContext templateContext)
        {
            TemplateContext = Preconditions.ThrowIfNull(templateContext, nameof(templateContext));
            ResourceModelProvider = new ResourceModelProvider(TemplateContext.DomainModelProvider);

            Configure();

            return Build();
        }

        protected virtual void Configure() { }

        protected abstract object Build();
    }
}
