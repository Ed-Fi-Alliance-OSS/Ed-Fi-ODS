// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Generator.Rendering;
using EdFi.Ods.Generator.Templating;

namespace EdFi.Ods.Generator.Modules
{
    public class GeneratorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TemplatesProvider>().As<ITemplatesProvider>();

            builder.RegisterType<RenderingsManifestProvider>().As<IRenderingsManifestProvider>();
            
            builder.RegisterType<RenderingManager>().As<IRenderingManager>();
        }
    }
}
