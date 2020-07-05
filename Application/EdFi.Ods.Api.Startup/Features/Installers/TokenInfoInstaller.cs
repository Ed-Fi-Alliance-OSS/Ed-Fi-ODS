// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Api.Services.Providers;
using EdFi.Ods.Api.Startup.HttpRouteConfigurations;

namespace EdFi.Ods.Api.Startup.Features.Installers
{
    public class TokenInfoInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ITokenInfoProvider>().ImplementedBy<TokenInfoProvider>(),
                Component.For<IRouteConfiguration, IOpenApiMetadataRouteConfiguration>().ImplementedBy<TokenInfoRouteConfiguration>());

            RegisterControllers(container);
        }

        private void RegisterControllers(IWindsorContainer container)
        {
            // TODO -JSM resolve once we move open api to another assembly with ODS-3225
            // container.Register(Component.For<AuthenticatedUserContextController>().LifestyleScoped());
        }
    }
}
