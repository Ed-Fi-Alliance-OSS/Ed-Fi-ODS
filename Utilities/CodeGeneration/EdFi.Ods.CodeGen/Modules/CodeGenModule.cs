// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Generator.Common.Database;

namespace EdFi.Ods.CodeGen.Modules
{
    public class CodeGenModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ProvidersModule());
            builder.RegisterModule(new ProcessingModule());

            builder.RegisterModule(new DatabaseTemplateModelModule());
            
            builder.RegisterType<ApplicationRunner>()
                .As<IApplicationRunner>();
        }
    }
}
