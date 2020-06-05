// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Api.NetCore.Configuration;
using EdFi.Ods.Api.NetCore.Conventions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.NetCore.Container.Modules
{
    public class ApplicationModelConventionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // api model conventions should be singletons
            builder.RegisterType<MvcOptionsConfigurator>().As<IConfigureOptions<MvcOptions>>().SingleInstance();
            builder.RegisterType<DataManagementControllerRouteConvention>().As<IApplicationModelConvention>().SingleInstance();
        }
    }
}
