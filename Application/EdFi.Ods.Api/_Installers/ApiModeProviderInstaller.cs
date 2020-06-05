// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api._Installers
{
    public class ApiModeProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDatabaseEngineProvider>().ImplementedBy<DatabaseEngineProvider>(),
                Component.For<IApiConfigurationProvider>().ImplementedBy<ApiConfigurationProvider>(),
                Component.For<DatabaseEngine>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<IApiConfigurationProvider>().DatabaseEngine));
        }
    }
}
