// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Identity;
using EdFi.Ods.Api.Services.Controllers.IdentityManagement;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Api.Services.Metadata.Providers;
using EdFi.Ods.Api.Startup.HttpRouteConfigurations;
using EdFi.Ods.Common._Installers;
using EdFi.Ods.Common._Installers.ComponentNaming;

namespace EdFi.Ods.Api.Startup.Features.Installers
{
    public class IdentityManagementInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IRouteConfiguration, IOpenApiMetadataRouteConfiguration>().ImplementedBy<IdentityRouteConfiguration>(),
                Component.For<IOpenApiContentProvider>().ImplementedBy<IdentityOpenApiContentProvider>(),
                Component.For<IIdentityService, IIdentityServiceAsync>().ImplementedBy<UnimplementedIdentityService>());

            RegisterControllers(container);
        }

        private void RegisterControllers(IWindsorContainer container)
        {
            // TODO - JSM move in the identity controller registration with ODS-3225
        }
    }
}
