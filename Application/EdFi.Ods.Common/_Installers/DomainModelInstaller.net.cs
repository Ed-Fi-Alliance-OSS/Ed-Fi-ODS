#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common._Installers
{
    public class DomainModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<DomainModel>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<IDomainModelProvider>().GetDomainModel()),
                Component.For<Schema[]>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<DomainModel>().Schemas.ToArray()),
                Component.For<ISchemaNameMapProvider>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<DomainModel>().SchemaNameMapProvider));
        }
    }
}
#endif
