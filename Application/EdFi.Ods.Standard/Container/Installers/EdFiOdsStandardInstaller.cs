#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Dependencies;
using EdFi.Ods.Api.Common.ExceptionHandling.EdFi;
using EdFi.Ods.Api.Common.Providers;

namespace EdFi.Ods.Standard.Container.Installers
{
    public class EdFiOdsStandardInstaller : RegistrationMethodsInstallerBase
    {
        protected virtual void RegisterIDomainModelProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IDomainModelProvider>()
                   .ImplementedBy<DomainModelProvider>());
        }

        protected virtual void RegisterIEdFiDescriptorReflectionProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IEdFiDescriptorReflectionProvider>()
                   .ImplementedBy<EdFiDescriptorReflectionProvider>());
        }

        protected virtual void RegisterIDatabaseMetadataProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IDatabaseMetadataProvider>()
                   .ImplementedBy<DatabaseMetadataProvider>());
        }

        protected virtual void RegisterIResourceModelProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IResourceModelProvider>()
                   .ImplementedBy<ResourceModelProvider>());

            // Make this dependency available to generated artifacts
            GeneratedArtifactStaticDependencies
                .Resolvers.Set(() => container.Resolve<IResourceModelProvider>());
        }

        protected virtual void RegisterIDomainModelDefinitionsProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IDomainModelDefinitionsProvider>()
                   .ImplementedBy<DomainModelDefinitionsJsonEmbeddedResourceProvider>()
                   .DependsOn(Dependency.OnValue("sourceAssembly", typeof(Marker_EdFi_Ods_Standard).Assembly)));
        }
    }
}
#endif
