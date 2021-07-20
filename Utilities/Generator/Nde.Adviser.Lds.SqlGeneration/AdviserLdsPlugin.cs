// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using Autofac;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Generator.Database.TemplateModelProviders;
using EdFi.Ods.Generator.Database.Transformers;
using EdFi.Ods.Generator.Rendering;
using Nde.Adviser.Lds.SqlGeneration.Transformers;

namespace Nde.Adviser.Lds.SqlGeneration
{
    public class AdviserLdsPlugin : IRenderingPlugin
    {
        public void Initialize(ContainerBuilder containerBuilder)
        {
            // Register domain model transformers
            containerBuilder
                .RegisterType<IdAlternateIdentifierStripper>()
                .As<IDomainModelDefinitionsTransformer>();
            
            containerBuilder
                .RegisterType<SchoolYearContextInjectionTransformer>()
                .As<IDomainModelDefinitionsTransformer>();

            containerBuilder
                .RegisterType<CapabilityStatementTransformer>()
                .As<IDomainModelDefinitionsTransformer>();

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
