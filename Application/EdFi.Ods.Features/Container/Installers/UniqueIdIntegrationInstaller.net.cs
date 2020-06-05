#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Features.UniqueIdIntegration.Caching;
using EdFi.Ods.Features.UniqueIdIntegration.Pipeline;
using EdFi.Ods.Features.UniqueIdIntegration.Validation;

namespace EdFi.Ods.Features.UniqueIdIntegration.Installers
{
    public class UniqueIdIntegrationInstaller : RegistrationMethodsInstallerBase
    {
        private void RegisterPersonUniqueIdToIdCache(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IPersonUniqueIdToIdCache>()
                   .ImplementedBy<PersonUniqueIdToIdCache>().IsFallback());
        }

        private void RegisterPipelineStepsProviders(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IPutPipelineStepsProvider>()
                    .ImplementedBy<UniqueIdIntegrationPutPipelineStepsProviderDecorator>().IsDecorator());
        }

        private  void RegisterPipelineSteps(IWindsorContainer container)
        {
            container.Register(
                Classes
                    .FromAssemblyContaining<Marker_EdFi_Ods_Features>()
                    .BasedOn(typeof(IStep<,>))
                    .WithService.Self());
        }

        private void RegisterObjectValidators(IWindsorContainer container)
        {
            // Register a validator that prevents UniqueIds from being changed
            container.Register(
                Component
                    .For<IEntityValidator>()
                    .ImplementedBy<UniqueIdNotChangedEntityValidator>(),

                // Register a validator that ensures that 
                Component
                    .For<IEntityValidator>()
                    .ImplementedBy<EnsureUniqueIdAlreadyExistsEntityValidator>());
        }
    }
}
#endif