// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.CodeGen._Installers;

namespace EdFi.Ods.CodeGen.Console._Installers
{
    public class CodeGenInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(
                new AppConfigInstaller(),
                new ProvidersInstaller(),
                new ProcessingInstaller());

            container.Register(Component.For<IApplicationRunner>().ImplementedBy<ApplicationRunner>());
        }
    }
}
