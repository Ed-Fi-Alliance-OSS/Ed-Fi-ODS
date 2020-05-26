// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.CodeGen._Installers
{
    public class AppConfigInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            container.Register(Component.For<IConfigurationRoot>().UsingFactoryMethod(() => builder.Build()));
        }
    }
}
