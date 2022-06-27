// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using Autofac;
using EdFi.Ods.Generator.Common.Database.DataTypes;
using EdFi.Ods.Generator.Common.Database.Domain;
using EdFi.Ods.Generator.Common.Database.NamingConventions;
using EdFi.Ods.Generator.Common.Database.TemplateModelProviders;
// NOTE: Removed for copy/integration into legacy Ed-Fi code generator
// using EdFi.Ods.Generator.Common.Rendering;
using EdFi.Ods.Generator.Common.Templating;
using Module = Autofac.Module;

namespace EdFi.Ods.Generator.Common.Database
{
    public class DatabaseTemplateModelModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            // Register reusable database template model provider
            containerBuilder.RegisterType<DatabaseTemplateModelProvider>()
                .AsSelf()
                .As<ITemplateModelProvider>();

            // Register database-aware factories
            containerBuilder.RegisterType<DatabaseTypeTranslatorFactory>()
                .As<IDatabaseTypeTranslatorFactory>();

            containerBuilder.RegisterType<DatabaseNamingConventionFactory>()
                .As<IDatabaseNamingConventionFactory>();
            
            // Render Property enhancement
            // NOTE: Removed for copy/integration into legacy Ed-Fi code generator
            // containerBuilder.RegisterType<DatabaseRenderingPropertiesEnhancer>()
            //     .As<IRenderingPropertiesEnhancer>();
            
            // Domain model components
            containerBuilder.RegisterType<ModelPathsDomainDefinitionsProviderSource>()
                .As<IDomainModelDefinitionsProviderSource>();
            
            // Register enhancers for Database artifacts generation
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<ITableEnhancer>()
                .AsImplementedInterfaces();
            
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<IColumnEnhancer>()
                .AsImplementedInterfaces();
        }
    }
}
