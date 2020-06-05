#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Api.Common.Dependencies;
using EdFi.Ods.Api.Common.Infrastructure.Composites;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Providers.Criteria;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Composites;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Filtering;
using EdFi.Ods.Security.Authorization.Pipeline;
using EdFi.Ods.Security.Authorization.Repositories;
using EdFi.Ods.Security.AuthorizationStrategies;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Security.Profiles;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Security.Container.Installers
{
    public class SecurityComponentsInstaller : RegistrationMethodsInstallerBase
    {
        private readonly IDictionary<Type, Type> decoratorRegistrations = new Dictionary<Type, Type>
        {
            {typeof(IGetEntityByKey<>), typeof(GetEntityByKeyAuthorizationDecorator<>)},
            {typeof(IGetEntitiesBySpecification<>), typeof(GetEntitiesBySpecificationAuthorizationDecorator<>)},
            {typeof(IPagedAggregateIdsCriteriaProvider<>), typeof(PagedAggregateIdsCriteriaProviderDecorator<>)},
            {typeof(ITotalCountCriteriaProvider<>), typeof(TotalCountCriteriaProviderDecorator<>)},
            {typeof(IGetEntityById<>), typeof(GetEntityByIdAuthorizationDecorator<>)},
            {typeof(IGetEntitiesByIds<>), typeof(GetEntitiesByIdsAuthorizationDecorator<>)},
            {typeof(ICreateEntity<>), typeof(CreateEntityAuthorizationDecorator<>)},
            {typeof(IDeleteEntityById<>), typeof(DeleteEntityByIdAuthorizationDecorator<>)},
            {typeof(IUpdateEntity<>), typeof(UpdateEntityAuthorizationDecorator<>)},
            {typeof(IUpsertEntity<>), typeof(UpsertEntityAuthorizationDecorator<>)},

            // TODO: Remove with ODS-2973, deprecated by CompositesFeatureInstaller
            {typeof(ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>), typeof(HqlBuilderAuthorizationDecorator)}
        };

        protected virtual void RegisterIAuthorizationSegmentsToFiltersConverter(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IAuthorizationSegmentsToFiltersConverter>()
                    .ImplementedBy<AuthorizationSegmentsToFiltersConverter>());
        }

        protected virtual void RegisterIEducationOrganizationHierarchyProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IEducationOrganizationHierarchyProvider>()
                    .ImplementedBy<EducationOrganizationHierarchyProvider>());
        }

        protected virtual void RegisterComponentsUsingLegacyMechanism(IWindsorContainer container)
        {
            // Register the decorators
            foreach (var registration in decoratorRegistrations)
            {
                container.Register(
                    Component
                        .For(registration.Key)
                        .ImplementedBy(registration.Value)
                        .IsDefault());
            }

            container.Register(
                Component
                    .For<ISecurityRepository>()
                    .ImplementedBy<SecurityRepository>());

            container.Register(
                Component.For<IClientAppRepo>()
                    .ImplementedBy<ClientAppRepo>());

            container.Register(
                Component
                    .For<IUsersContextFactory>()
                    .ImplementedBy<UsersContextFactory>());

            container.Register(
                Component
                    .For<ISecurityContextFactory>()
                    .ImplementedBy<SecurityContextFactory>());

            // TODO: Remove with ODS-2973, deprecated by ProfilesInstaller
            container.Register(
                Component
                    .For<IAdminProfileNamesPublisher>()
                    .ImplementedBy<AdminProfileNamesPublisher>());

            // Register pipeline step provider decorators
            container.Register(
                Component
                    .For<IGetPipelineStepsProvider>()
                    .ImplementedBy<AuthorizationContextGetPipelineStepsProviderDecorator>()
                    .IsDefault());

            container.Register(
                Component
                    .For<IGetBySpecificationPipelineStepsProvider>()
                    .ImplementedBy<AuthorizationContextGetBySpecificationPipelineStepsProviderDecorator>()
                    .IsDefault());

            container.Register(
                Component
                    .For<IPutPipelineStepsProvider>()
                    .ImplementedBy<AuthorizationContextPutPipelineStepsProviderDecorator>()
                    .IsDefault());

            container.Register(
                Component
                    .For<IDeletePipelineStepsProvider>()
                    .ImplementedBy<AuthorizationContextDeletePipelineStepsProviderDecorator>()
                    .IsDefault());

            container.Register(
                Component
                    .For<IResourceClaimUriProvider>()
                    .ImplementedBy<ResourceClaimUriProvider>());

            // Register authorization context pipeline steps
            container.Register(
                Component.For(typeof(SetAuthorizationContextForGet<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForGet<,,,>)),
                Component.For(typeof(SetAuthorizationContextForPut<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForPut<,,,>)),
                Component.For(typeof(SetAuthorizationContextForDelete<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForDelete<,,,>)),
                Component.For(typeof(SetAuthorizationContextForPost<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForPost<,,,>))
            );

            // -----------------------------------------------
            //   Register authorization subsystem components
            // -----------------------------------------------
            container.Register(
                Component
                    .For<IEdFiAuthorizationProvider>()
                    .ImplementedBy<EdFiAuthorizationProvider>());

            container.Register(
                Component
                    .For<IAuthorizationSegmentsVerifier>()
                    .ImplementedBy<AuthorizationSegmentsVerifier>());

            container.Register(
                Component.For<IAuthorizationSegmentsSqlProvider>()
                    .ImplementedBy<SqlServerAuthorizationSegmentSqlProvider>());

            container.Register(
                Component
                    .For<IResourceAuthorizationMetadataProvider>()
                    .ImplementedBy<ResourceAuthorizationMetadataProvider>());
        }

        protected virtual void RegisterIAuthorizationContextProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IAuthorizationContextProvider>()
                    .ImplementedBy<AuthorizationContextProvider>());

            // Make this dependency available to generated artifacts
            GeneratedArtifactStaticDependencies.Resolvers.Set(() => container.Resolve<IAuthorizationContextProvider>());
        }

        protected virtual void RegisterEducationOrganizationCache(IWindsorContainer container)
        {
            // Register EdOrg Cache components
            container.Register(
                Component
                    .For<IEducationOrganizationCache>()
                    .ImplementedBy<EducationOrganizationCache>()
                    .DependsOn(Dependency.OnValue("synchronousInitialization", false)));
        }

        protected virtual void RegisterEducationOrganizationCacheDataProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IEducationOrganizationCacheDataProvider, IEducationOrganizationIdentifiersValueMapper>()
                    .ImplementedBy<EducationOrganizationCacheDataProvider>());
        }

        protected virtual void RegisterIRelationshipsAuthorizationContextDataProviderFactory(IWindsorContainer container)
        {
            // Register authorization context data provider factory
            container.Register(
                Component
                    .For(
                        typeof(IRelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                            GetRelationshipBasedAuthorizationStrategyContextDataType()))
                    .ImplementedBy(
                        typeof(RelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                            GetRelationshipBasedAuthorizationStrategyContextDataType()))
                    .DependsOn(
                        new {serviceLocator = container}));
        }

        protected virtual void RegisterIRelationshipsAuthorizationContextDataProviders(IWindsorContainer container)
        {
            // Register all context data providers
            var relationshipContextDataProviderTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Where(
                    a =>
                        a.IsExtensionAssembly() || a.IsStandardAssembly())
                .SelectMany(a => a.GetTypes())
                .Where(
                    t => !t.IsAbstract
                         && typeof(
                             IRelationshipsAuthorizationContextDataProvider
                             <,>).IsAssignableFromGeneric(t));

            // Register all context data providers including any defined in extension assemblies.
            // NOTE: If there is no entries for relationshipContextDataProviderTypes this means that the EdFi.Ods.Standard.Security assembly is not loaded.
            // and this can be resolved by calling AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Standard_Security>(); in your configuration
            if (!relationshipContextDataProviderTypes.Any())
            {
                throw new Exception("Unable to find any relationship-based authorization context providers dynamically.");
            }

            foreach (var providerType in relationshipContextDataProviderTypes)
            {
                var partiallyClosedInterfaceType =
                    providerType.GetInterfaces()
                        .SingleOrDefault(
                            i => i.Name == typeof(IRelationshipsAuthorizationContextDataProvider<,>).Name);

                var modelType = partiallyClosedInterfaceType.GetGenericArguments()[0];

                var closedInterfaceType =
                    typeof(IRelationshipsAuthorizationContextDataProvider<,>).MakeGenericType(
                        modelType,
                        GetRelationshipBasedAuthorizationStrategyContextDataType());

                var closedServiceType =
                    providerType.MakeGenericType(GetRelationshipBasedAuthorizationStrategyContextDataType());

                container.Register(
                    Component
                        .For(closedInterfaceType)
                        .ImplementedBy(closedServiceType));
            }

#region Commented Out, Non-working - Possible more elegant registration approach

            //container.Register(Classes
            //    .FromAssemblyContaining<Marker_EdFi_Ods_Security>()
            //    .BasedOn(typeof(IRelationshipsAuthorizationContextDataProvider<,>))
            //    .Configure(
            //        r =>
            //        {
            //            var genericStrategy =
            //                new PassthroughGenericStrategy();

            //            r.ExtendedProperties(
            //                Property.ForKey(Constants.GenericImplementationMatchingStrategy)
            //                        .Eq((object)genericStrategy));
            //        })
            //    .WithServiceBase());

#endregion
        }

        protected virtual void RegisterIConcreteEducationOrganizationIdAuthorizationContextDataTransformer(
            IWindsorContainer container)
        {
            var relationshipContextDataType = GetRelationshipBasedAuthorizationStrategyContextDataType();

            var transformerInterfaceType =
                typeof(IConcreteEducationOrganizationIdAuthorizationContextDataTransformer<>).MakeGenericType(
                    relationshipContextDataType);

            var transformerServiceType =
                typeof(ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<>).MakeGenericType(
                    relationshipContextDataType);

            container.Register(
                Component
                    .For(transformerInterfaceType)
                    .ImplementedBy(transformerServiceType));
        }

        /// <summary>
        /// Gets the context data type for the relationship-based authorizations strategies, providing an extensibility point for additional education organization types.
        /// </summary>
        protected virtual Type GetRelationshipBasedAuthorizationStrategyContextDataType()
        {
            return typeof(RelationshipsAuthorizationContextData);
        }

        protected virtual void RegisterINHibernateFilterTextProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<INHibernateFilterTextProvider>()
                    .ImplementedBy<NHibernateFilterTextProvider>());
        }

        protected virtual void RegisterAuthorizationStrategies(IWindsorContainer container)
        {
            container.Install(new AuthorizationStrategiesInstaller<Marker_EdFi_Ods_Security>());
        }

        protected virtual void RegisterIAuthorizationFilterContextProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IAuthorizationFilterContextProvider>()
                    .ImplementedBy<AuthorizationFilterContextProvider>());
        }
    }
}
#endif