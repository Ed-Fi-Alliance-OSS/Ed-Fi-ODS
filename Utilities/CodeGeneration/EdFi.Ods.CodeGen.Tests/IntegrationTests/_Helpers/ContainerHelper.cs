// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using Autofac.Extensions.DependencyInjection;
using EdFi.Ods.CodeGen.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.CodeGen.Tests.IntegrationTests._Helpers
{
    public static class ContainerHelper
    {
        public static IContainer CreateContainer()
        {
            var serviceCollection = new ServiceCollection().AddConfiguration();

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new ProvidersModule());

            containerBuilder.Populate(serviceCollection);

            return containerBuilder.Build();
        }
    }
}
