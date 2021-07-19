// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Models;
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
                .RegisterType<MetaEdModelBoilerplateStripper>()
                .As<IDomainModelDefinitionsTransformer>();
            
            containerBuilder
                .RegisterType<SchoolYearContextTransformer>()
                .As<IDomainModelDefinitionsTransformer>();

            containerBuilder
                .RegisterType<CapabilityStatementTransformer>()
                .As<IDomainModelDefinitionsTransformer>();
        }
    }
}
