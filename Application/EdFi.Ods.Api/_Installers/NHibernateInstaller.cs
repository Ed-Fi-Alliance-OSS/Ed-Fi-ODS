// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Infrastructure.Repositories;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Common.Providers.Criteria;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api._Installers
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof(IRepository<>))
                    .ImplementedBy(typeof(NHibernateRepository<>)),
                Component
                    .For(typeof(ICreateEntity<>))
                    .ImplementedBy(typeof(CreateEntity<>)),
                Component
                    .For(typeof(IDeleteEntityById<>))
                    .ImplementedBy(typeof(DeleteEntityById<>)),
                Component
                    .For(typeof(IDeleteEntityByKey<>))
                    .ImplementedBy(typeof(DeleteEntityByKey<>)),
                Component
                    .For(typeof(IGetEntitiesByIds<>))
                    .ImplementedBy(typeof(GetEntitiesByIds<>)),
                Component
                    .For(typeof(IGetEntitiesBySpecification<>))
                    .ImplementedBy(typeof(GetEntitiesBySpecification<>)),
                Component
                    .For(typeof(IGetEntityById<>))
                    .ImplementedBy(typeof(GetEntityById<>)),
                Component
                    .For(typeof(IGetEntityByKey<>))
                    .ImplementedBy(typeof(GetEntityByKey<>)),
                Component
                    .For(typeof(IUpdateEntity<>))
                    .ImplementedBy(typeof(UpdateEntity<>)),
                Component
                    .For(typeof(IUpsertEntity<>))
                    .ImplementedBy(typeof(UpsertEntity<>)),
                Component
                    .For<IDescriptorLookupProvider>()
                    .ImplementedBy<DescriptorLookupProvider>()
                    .LifestyleSingleton(),
                Component
                    .For(typeof(IPagedAggregateIdsCriteriaProvider<>))
                    .ImplementedBy(typeof(PagedAggregateIdsCriteriaProvider<>)),
                Component
                    .For(typeof(ITotalCountCriteriaProvider<>))
                    .ImplementedBy(typeof(TotalCountCriteriaProvider<>)),
                Component
                    .For<IFilterCriteriaApplicatorProvider>()
                    .ImplementedBy<FilterCriteriaApplicatorProvider>()
            );
        }
    }
}
