// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.CodeGen.Processing;
using EdFi.Ods.CodeGen.Processing.Impl;

namespace EdFi.Ods.CodeGen.Modules
{
    public class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TemplateWriter>()
                .As<ITemplateWriter>();

            builder.RegisterType<TemplateProcessor>()
                .As<ITemplateProcessor>();
        }
    }
}
