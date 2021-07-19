// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.Domain;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Rendering;
using EdFi.Ods.Generator.Templating;

namespace EdFi.Ods.Generator.Database
{
    public class DatabaseRenderingPlugin : IRenderingPlugin
    {
        public void Initialize(ContainerBuilder containerBuilder)
        {
            // Register reusable database template model provider
            containerBuilder.RegisterType<DatabaseTemplateModelProvider>()
                .As<ITemplateModelProvider>();

            // Register database-aware factories
            containerBuilder.RegisterType<DatabaseTypeTranslatorFactory>()
                .As<IDatabaseTypeTranslatorFactory>();

            containerBuilder.RegisterType<DatabaseNamingConventionFactory>()
                .As<IDatabaseNamingConventionFactory>();
            
            // Domain model components
            containerBuilder.RegisterType<OptionsDomainDefinitionsProviderProvider>()
                .As<IDomainModelDefinitionsProviderProvider>();
        }
    }
}
