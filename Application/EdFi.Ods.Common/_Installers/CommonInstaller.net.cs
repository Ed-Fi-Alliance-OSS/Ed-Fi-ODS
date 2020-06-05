#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.IO;

namespace EdFi.Ods.Common._Installers
{
    public class CommonInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                // Assemblies Provider
                Component.For<IAssembliesProvider>().ImplementedBy<AssembliesProvider>().IsFallback(),

                // File System Wrapper
                Component.For<IFileSystem>().ImplementedBy<FileSystemWrapper>(),

                // Configuration File
                Component.For<IConfigValueProvider>().ImplementedBy<AppConfigValueProvider>().IsFallback(),
                Component.For<IConfigConnectionStringsProvider>().ImplementedBy<AppConfigConnectionStringsProvider>()
                    .IsFallback(),
                Component.For<IConfigSectionProvider>().ImplementedBy<AppConfigSectionProvider>().IsFallback());
        }
    }
}
#endif
