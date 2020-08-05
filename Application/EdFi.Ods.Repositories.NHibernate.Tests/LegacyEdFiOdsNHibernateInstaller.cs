﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Api.NHibernate.Architecture.Criteria;
using EdFi.Ods.Api.NHibernate.Composites;
using EdFi.Ods.Common.Composites;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [Obsolete("Required for bulk load")]
    public class LegacyEdFiOdsNHibernateInstaller: RegistrationMethodsInstallerBase
    {
        protected virtual void RegisterOriginalComponents(IWindsorContainer container)
        {
            container
               .Register(
                    Component
                       .For(typeof(IRepository<>))
                       .ImplementedBy(typeof(NHibernateRepository<>)));

            container.Register(
                Component
                   .For(typeof(ICreateEntity<>))
                   .ImplementedBy(typeof(CreateEntity<>)));

            container.Register(
                Component
                   .For(typeof(IDeleteEntityById<>))
                   .ImplementedBy(typeof(DeleteEntityById<>)));

            container.Register(
                Component
                   .For(typeof(IDeleteEntityByKey<>))
                   .ImplementedBy(typeof(DeleteEntityByKey<>)));

            container.Register(
                Component
                   .For(typeof(IGetEntitiesByIds<>))
                   .ImplementedBy(typeof(GetEntitiesByIds<>)));

            container.Register(
                Component
                   .For(typeof(IGetEntitiesBySpecification<>))
                   .ImplementedBy(typeof(GetEntitiesBySpecification<>)));

            container.Register(
                Component
                   .For(typeof(IGetEntityById<>))
                   .ImplementedBy(typeof(GetEntityById<>)));

            container.Register(
                Component
                   .For(typeof(IGetEntityByKey<>))
                   .ImplementedBy(typeof(GetEntityByKey<>)));

            container.Register(
                Component
                   .For(typeof(IUpdateEntity<>))
                   .ImplementedBy(typeof(UpdateEntity<>)));

            container.Register(
                Component
                   .For(typeof(IUpsertEntity<>))
                   .ImplementedBy(typeof(UpsertEntity<>)));

            container.Register(
                Component
                   .For<IDescriptorLookupProvider>()
                   .ImplementedBy<DescriptorLookupProvider>()
                   .LifestyleSingleton());

            // TODO: Remove with ODS-2973, deprecated by CompositesFeatureInstaller
            container.Register(
                Component
                   .For<ICompositeResourceResponseProvider>()
                   .ImplementedBy<CompositeResourceResponseProvider>());

            // TODO: Remove with ODS-2973, deprecated by CompositesFeatureInstaller
            container.Register(
                Component
                   .For<ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>()
                   .ImplementedBy<HqlBuilder>());
        }

        protected virtual void RegisterIFieldsExpressionParser(IWindsorContainer container)
        {
            // TODO: Remove with ODS-2973, deprecated by CompositesFeatureInstaller
            container.Register(
                Component
                   .For<IFieldsExpressionParser>()
                   .ImplementedBy<FieldsExpressionParser>());
        }

        protected virtual void RegisterIPagedAggregateIdsCriteriaProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For(typeof(IPagedAggregateIdsCriteriaProvider<>))
                   .ImplementedBy(typeof(PagedAggregateIdsCriteriaProvider<>)));
        }

        protected virtual void RegisterITotalCountCriteriaProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                   .For(typeof(ITotalCountCriteriaProvider<>))
                   .ImplementedBy(typeof(TotalCountCriteriaProvider<>)));
        }

        protected virtual void RegisterIFilterCriteriaApplicatorProvider(IWindsorContainer container)
        {
            container.Register(Component
                .For<IFilterCriteriaApplicatorProvider>()
                .ImplementedBy<FilterCriteriaApplicatorProvider>());
        }
    }
}
