// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Api.ETag;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Validation;
using FluentValidation;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [Obsolete("Required for bulk load")]
    public class LegacyEdFiOdsApiInstaller : RegistrationMethodsInstallerBase
    {
        protected virtual void RegisterIEdFiOdsInstanceIdentificationProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IEdFiOdsInstanceIdentificationProvider>()
                   .ImplementedBy<EdFiOdsInstanceIdentificationProvider>());
        }

        // ReSharper disable once InconsistentNaming
        protected virtual void RegisterIETagProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IETagProvider>()
                   .ImplementedBy<ETagProvider>());
        }

        protected virtual void RegisterUniqueIdToUsiValueMapper(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IUniqueIdToUsiValueMapper>()
                   .ImplementedBy<UniqueIdToUsiValueMapper>());
        }

        protected virtual void RegisterIPersonUniqueIdToUsiCache(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IPersonUniqueIdToUsiCache>()
                   .ImplementedBy<PersonUniqueIdToUsiCache>()
                   .DependsOn(Dependency.OnValue("synchronousInitialization", false)));

            PersonUniqueIdToUsiCache.GetCache = container.Resolve<IPersonUniqueIdToUsiCache>;
        }

        protected virtual void RegisterIDescriptorCache(IWindsorContainer container)
        {
            container.Register(
                Component.For<IDescriptorsCache>()
                         .ImplementedBy<DescriptorsCache>()
                         .LifestyleSingleton());

            IDescriptorsCache cache = null;

            // Provide cache using a closure rather than repeated invocations to the container
            DescriptorsCache.GetCache = () => cache ?? (cache = container.Resolve<IDescriptorsCache>());
        }

        protected virtual void RegisterITokenRequestHandlers(IWindsorContainer container)
        {
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn<ITokenRequestHandler>()
                       .WithService.FirstInterface());
        }

        protected virtual void RegisterValidators(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IEntityValidator>()
                   .ImplementedBy<DataAnnotationsEntityValidator>());

            container.Register(
                Component
                   .For<IValidator<IEdFiDescriptor>>()
                   .ImplementedBy<DescriptorNamespaceValidator>());

            container.Register(
                Component
                   .For<IResourceValidator>()
                   .ImplementedBy<FluentValidationPutPostRequestResourceValidator>(),
                Component
                   .For<IResourceValidator>()
                   .ImplementedBy<DataAnnotationsResourceValidator>());
        }

        protected virtual void RegisterIEdFiOdsBasedPersonIdentifiersProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IPersonIdentifiersProvider>()
                   .ImplementedBy<PersonIdentifiersProvider>());
        }

        protected virtual void RegisterIExplicitObjectValidators(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IExplicitObjectValidator>()
                   .ImplementedBy<FluentValidationObjectValidator>());
        }

        // TODO: Remove with ODS-2973, deprecated by ProfilesInstaller
        protected virtual void RegisterIProfileResourceModelProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For<IProfileResourceModelProvider>()
                   .ImplementedBy<ProfileResourceModelProvider>());
        }

        protected virtual void RegisterResourceModelHelper(IWindsorContainer container)
        {
            ResourceModelHelper.ResourceModel =
                new Lazy<ResourceModel>(() => container.Resolve<IResourceModelProvider>().GetResourceModel());
        }
    }
}
