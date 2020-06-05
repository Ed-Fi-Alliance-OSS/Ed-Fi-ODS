#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.Extensions;

namespace EdFi.Ods.Features.Container.Installers
{
    public class ExtensionsInstaller : IWindsorInstaller
    {
        private readonly IConfigValueProvider _configValueProvider;
        private readonly IAssembliesProvider _assembliesProvider;

        public ExtensionsInstaller(IAssembliesProvider assembliesProvider, IConfigValueProvider configValueProvider)
        {
            _configValueProvider = configValueProvider;
            _assembliesProvider = Preconditions.ThrowIfNull(assembliesProvider, nameof(assembliesProvider));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IOpenApiContentProvider>().ImplementedBy<ExtensionsOpenApiContentProvider>());

            container.Install(
                new EdFiExtensionsInstaller(_assembliesProvider, _configValueProvider));
        }
    }
}
#endif
