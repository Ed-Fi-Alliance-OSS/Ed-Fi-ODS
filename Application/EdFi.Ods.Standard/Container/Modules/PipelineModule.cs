// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Linq;
using Autofac;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.CreateOrUpdate;

namespace EdFi.Ods.Standard.Container.Modules
{
    public class PipelineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Marker_EdFi_Ods_Standard).Assembly)
                .Where(t => t.Name.EndsWith("CreateOrUpdatePipeline"))
                .AsSelf();
        }
    }
}
#endif