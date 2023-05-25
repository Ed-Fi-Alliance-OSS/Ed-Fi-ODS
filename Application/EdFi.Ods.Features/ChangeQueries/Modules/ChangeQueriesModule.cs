// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Common.Infrastructure.Configuration;
using EdFi.Ods.Features.ChangeQueries.Providers;
using EdFi.Ods.Features.ChangeQueries.SnapshotContext;
using Microsoft.AspNetCore.Mvc.Filters;
using EdFi.Ods.Features.ChangeQueries.ExceptionHandling;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Features.ChangeQueries.Repositories;
using EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers;
using EdFi.Ods.Features.ChangeQueries.Repositories.Authorization;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges;
using EdFi.Ods.Features.ChangeQueries.Repositories.Snapshots;

namespace EdFi.Ods.Features.ChangeQueries.Modules
{
    public class ChangeQueriesModule : ConditionalModule
    {
        public ChangeQueriesModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(ChangeQueriesModule)) { }

        public override bool IsSelected() => IsFeatureEnabled(ApiFeature.ChangeQueries);

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
            // Change Queries support in NHibernate mappings 
            builder.RegisterType<ChangeQueryMappingNHibernateConfigurationActivity>()
                .As<INHibernateBeforeBindMappingActivity>()
                .SingleInstance();

            builder.RegisterType<QueryBuilder>();
            
            AddSupportForAvailableChanges();
            AddSupportForSnapshots();
            AddSupportForDeletes();
            AddSupportForKeyChanges();
            AddSupportForAuthorization();
            
            // General Tracked Changes query support
            builder.RegisterType<TrackedChangesIdentifierProjectionsProvider>()
                .As<ITrackedChangesIdentifierProjectionsProvider>()
                .SingleInstance();
            
            void AddSupportForAvailableChanges()
            {
                // Available changes support
                builder.RegisterType<AvailableChangeVersionProvider>()
                   .As<IAvailableChangeVersionProvider>()
                   .SingleInstance();
            }

            void AddSupportForSnapshots()
            {
                // Snapshots support
                builder.RegisterType<SnapshotContextProvider>()
                    .As<ISnapshotContextProvider>()
                    .SingleInstance();

                builder.RegisterType<SnapshotContextActionFilter>()
                    .As<IFilterMetadata>()
                    .SingleInstance();

                builder.RegisterType<SnapshotGoneExceptionTranslator>()
                    .As<IExceptionTranslator>()
                    .SingleInstance();
            }

            void AddSupportForDeletes()
            {
                // Deletes support
                builder.RegisterType<DeletedItemsResourceDataProvider>()
                    .As<IDeletedItemsResourceDataProvider>()
                    .SingleInstance();
            
                builder.RegisterType<DeletedItemsQueryBuilderFactory>()
                    .As<IDeletedItemsQueryBuilderFactory>()
                    .SingleInstance();
                
                builder.RegisterType<DeletedItemsQueryTemplatePreparer>()
                    .As<IDeletedItemsQueryTemplatePreparer>()
                    .SingleInstance();
            }

            void AddSupportForKeyChanges()
            {
                // KeyChanges support
                builder.RegisterType<KeyChangesResourceDataProvider>()
                    .As<IKeyChangesResourceDataProvider>()
                    .SingleInstance();
            
                builder.RegisterType<KeyChangesQueryBuilderFactory>()
                    .As<IKeyChangesQueryBuilderFactory>()
                    .SingleInstance();
                
                builder.RegisterType<KeyChangesQueryTemplatePreparer>()
                    .As<IKeyChangesQueryTemplatePreparer>()
                    .SingleInstance();
            }
            
            void AddSupportForAuthorization()
            {
                // General authorization support
                builder.RegisterType<NHibernateEntityTypeDomainModelEnhancer>()
                    .As<IDomainModelEnhancer>()
                    .SingleInstance();
            
                builder.RegisterDecorator<KeyChangesQueryBuilderFactoryAuthorizationDecorator, IKeyChangesQueryBuilderFactory>();
                builder.RegisterDecorator<DeletedItemsQueryBuilderFactoryAuthorizationDecorator, IDeletedItemsQueryBuilderFactory>();
            }
        }
    }
}
