// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Features.OpenApiMetadata.Providers;

namespace EdFi.Ods.WebService.Tests._Installers
{
    public class OpenApiMetadataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IOpenApiMetadataRouteProvider>()
                         .ImplementedBy<OpenApiMetadataRouteProvider>());

            container.Register(
                Component.For<IOpenApiMetadataCacheProvider>()
#pragma warning disable 618
                    .ImplementedBy<LegacyOpenApiMetadataCacheProvider>()
#pragma warning restore 618
                    .LifestyleSingleton());

            container.Register(
                Classes.FromAssemblyContaining<Marker_EdFi_Ods_Api>()
                       .BasedOn<IOpenApiContentProvider>()
                       .WithService.FromInterface()
                       .LifestyleSingleton());

            // Populate the swagger metadata cache at runtime instead of per request.
            container.Resolve<IOpenApiMetadataCacheProvider>()
                     .InitializeCache();
        }
    }
}
