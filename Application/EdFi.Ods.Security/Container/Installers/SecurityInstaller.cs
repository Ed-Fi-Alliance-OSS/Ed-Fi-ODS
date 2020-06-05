#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Providers.Criteria;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Filtering;
using EdFi.Ods.Security.Authorization.Pipeline;
using EdFi.Ods.Security.Authorization.Repositories;
using EdFi.Ods.Security.AuthorizationStrategies;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Security.Claims;
using EdFi.Ods.Security.Utilities;

namespace EdFi.Ods.Security.Container.Installers
{
    public class SecurityInstaller : IWindsorInstaller
    {
        public const string CacheTimeoutKey = "SecurityMetadataCacheTimeoutMinutes";

        private readonly IConfigValueProvider _configValueProvider;
        private readonly IDictionary<Type, Type> _decoratorRegistrations = new Dictionary<Type, Type>
        {
            // NHibernate authorization decorators
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

            // pipeline steps authorization decorators
            {typeof(IGetPipelineStepsProvider), typeof(AuthorizationContextGetPipelineStepsProviderDecorator)},
            {
                typeof(IGetBySpecificationPipelineStepsProvider),
                typeof(AuthorizationContextGetBySpecificationPipelineStepsProviderDecorator)
            },
            {typeof(IPutPipelineStepsProvider), typeof(AuthorizationContextPutPipelineStepsProviderDecorator)},
            {typeof(IDeletePipelineStepsProvider), typeof(AuthorizationContextDeletePipelineStepsProviderDecorator)}
        };

        public SecurityInstaller(IConfigValueProvider configValueProvider)
        {
            _configValueProvider = Preconditions.ThrowIfNull(configValueProvider, nameof(configValueProvider));
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterClaims(container);

            RegisterAuthorizationDecorators(container);

            RegisterIAuthorizationSegmentsToFiltersConverter(container);
            RegisterEducationOrganizationHierarchyProvider(container);
            RegisterComponentsUsingLegacyMechanism(container);
            RegisterIRelationshipsAuthorizationContextDataProviders(container);
            RegisterIRelationshipsAuthorizationContextDataProviderFactory(container);
            RegisterIAuthorizationContextProvider(container);
            RegisterEducationOrganizationCache(container);
            RegisterEducationOrganizationCacheDataProvider(container);
            RegisterIConcreteEducationOrganizationIdAuthorizationContextDataTransformer(container);
            RegisterNHibernateFilterTextProvider(container);
            RegisterAuthorizationFilterContextProvider(container);
            RegisterAuthorizationSegmentsVerifier(container);
            RegisterAuthorizationViewsProvider(container);

            container.Install(new AuthorizationStrategiesInstaller<Marker_EdFi_Ods_Security>());
        }

        private void RegisterClaims(IWindsorContainer container)
        {
            container.Register(Component.For<IClaimsIdentityProvider>().ImplementedBy<ClaimsIdentityProvider>());
        }

        private void RegisterAuthorizationSegmentsVerifier(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthorizationSegmentsVerifier>()
                    .ImplementedBy<AuthorizationSegmentsVerifier>());
        }

        private void RegisterIAuthorizationSegmentsToFiltersConverter(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IAuthorizationSegmentsToFiltersConverter>()
                    .ImplementedBy<AuthorizationSegmentsToFiltersConverter>());
        }

        private void RegisterEducationOrganizationHierarchyProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IEducationOrganizationHierarchyProvider>()
                    .ImplementedBy<EducationOrganizationHierarchyProvider>());
        }

        private void RegisterAuthorizationViewsProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IAuthorizationViewsProvider>()
                    .ImplementedBy<AuthorizationViewsProvider>());
        }


        private void RegisterComponentsUsingLegacyMechanism(IWindsorContainer container)
        {
            if (!int.TryParse(_configValueProvider.GetValue(CacheTimeoutKey), out int cacheTimeoutInMinutes))
            {
                cacheTimeoutInMinutes = 0;
            }

            if (cacheTimeoutInMinutes <= 0)
            {
                // Default to no caching
                container.Register(
                    Component.For<ISecurityRepository>()
                        .ImplementedBy<SecurityRepository>());
            }
            else
            {
                container.Register(
                    Component.For<ISecurityRepository>()
                        .ImplementedBy<CachedSecurityRepository>()
                        .DependsOn(Dependency.OnValue("cacheTimeoutInMinutes", cacheTimeoutInMinutes)));
            }

            container.Register(
                Component.For<IClientAppRepo>()
                    .ImplementedBy<ClientAppRepo>(),
                Component.For<IAccessTokenClientRepo>()
                    .ImplementedBy<AccessTokenClientRepo>(),
                Component.For<IUsersContextFactory>()
                    .ImplementedBy<UsersContextFactory>(),
                Component.For<ISecurityContextFactory>()
                    .ImplementedBy<SecurityContextFactory>(),
                Component
                    .For<IResourceClaimUriProvider>()
                    .ImplementedBy<ResourceClaimUriProvider>(),

                // Register authorization context pipeline steps
                Component.For(typeof(SetAuthorizationContextForGet<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForGet<,,,>)),
                Component.For(typeof(SetAuthorizationContextForPut<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForPut<,,,>)),
                Component.For(typeof(SetAuthorizationContextForDelete<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForDelete<,,,>)),
                Component.For(typeof(SetAuthorizationContextForPost<,,,>))
                    .ImplementedBy(typeof(SetAuthorizationContextForPost<,,,>)),

                // -----------------------------------------------
                //   Register authorization subsystem components
                // -----------------------------------------------
                Component
                    .For<IEdFiAuthorizationProvider>()
                    .ImplementedBy<EdFiAuthorizationProvider>(),
                Component
                    .For<IResourceAuthorizationMetadataProvider>()
                    .ImplementedBy<ResourceAuthorizationMetadataProvider>());
        }

        private void RegisterIAuthorizationContextProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthorizationContextProvider>()
                    .ImplementedBy<AuthorizationContextProvider>());
        }

        private void RegisterEducationOrganizationCache(IWindsorContainer container)
        {
            container.Register(
                Component.For<IEducationOrganizationCache>()
                    .ImplementedBy<EducationOrganizationCache>()
                    .DependsOn(Dependency.OnValue("synchronousInitialization", false)));
        }

        private void RegisterEducationOrganizationCacheDataProvider(IWindsorContainer container)
        {
            container.Register(
                Component
                    .For<IEducationOrganizationCacheDataProvider, IEducationOrganizationIdentifiersValueMapper>()
                    .ImplementedBy<EducationOrganizationCacheDataProvider>());
        }

        private void RegisterIRelationshipsAuthorizationContextDataProviderFactory(IWindsorContainer container)
        {
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

        private void RegisterIConcreteEducationOrganizationIdAuthorizationContextDataTransformer(IWindsorContainer container)
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

        private void RegisterNHibernateFilterTextProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<INHibernateFilterTextProvider>()
                    .ImplementedBy<NHibernateFilterTextProvider>());
        }

        private void RegisterAuthorizationFilterContextProvider(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthorizationFilterContextProvider>()
                    .ImplementedBy<AuthorizationFilterContextProvider>());
        }

        private void RegisterAuthorizationDecorators(IWindsorContainer container)
        {
            foreach (var registration in _decoratorRegistrations)
            {
                container.Register(
                    Component.For(registration.Key)
                        .ImplementedBy(registration.Value)
                        .IsDecorator());
            }
        }

        private void RegisterIRelationshipsAuthorizationContextDataProviders(IWindsorContainer container)
        {
            // Register all context data providers
            var relationshipContextDataProviderTypes = container.Resolve<IAssembliesProvider>().GetAssemblies()
                .Where(a => a.IsExtensionAssembly() || a.IsStandardAssembly())
                .SelectMany(a => a.GetTypes())
                .Where(
                    t => !t.IsAbstract && typeof(IRelationshipsAuthorizationContextDataProvider<,>).IsAssignableFromGeneric(t))
                .ToList();

            // Register all context data providers including any defined in extension assemblies.
            // NOTE: If there is no entries for relationshipContextDataProviderTypes this means that the EdFi.Ods.Standard.Security assembly is not loaded.
            // and this can be resolved by calling AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Standard_Security>(); in your configuration
            if (!relationshipContextDataProviderTypes.Any())
            {
                throw new ConfigurationErrorsException(
                    "Unable to find any relationship-based authorization context providers dynamically.");
            }

            foreach (var providerType in relationshipContextDataProviderTypes)
            {
                var partiallyClosedInterfaceType =
                    providerType.GetInterfaces()
                        .SingleOrDefault(i => i.Name == typeof(IRelationshipsAuthorizationContextDataProvider<,>).Name);

                var modelType = partiallyClosedInterfaceType?.GetGenericArguments()[0];

                var closedInterfaceType =
                    typeof(IRelationshipsAuthorizationContextDataProvider<,>)
                        .MakeGenericType(modelType, GetRelationshipBasedAuthorizationStrategyContextDataType());

                var closedServiceType =
                    providerType
                        .MakeGenericType(GetRelationshipBasedAuthorizationStrategyContextDataType());

                container.Register(
                    Component.For(closedInterfaceType)
                        .ImplementedBy(closedServiceType));
            }
        }

        private Type GetRelationshipBasedAuthorizationStrategyContextDataType()
        {
            return typeof(RelationshipsAuthorizationContextData);
        }
    }
}
#endif