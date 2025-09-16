// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Api.Security.Authorization.EntityAuthorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Pipeline;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.AuthorizationStrategies;
using EdFi.Ods.Api.Security.AuthorizationStrategies.CustomViewBased;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters.Hints;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Api.Security.Utilities;
using EdFi.Ods.Common.Caching;
using Module = Autofac.Module;

namespace EdFi.Ods.Api.Security.Container.Modules
{
    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationContextProvider>()
                .As<IAuthorizationContextProvider>()
                .SingleInstance();

            builder.RegisterType<DataManagementAuthorizationPlanFactory>()
                .As<IDataManagementAuthorizationPlanFactory>()
                .SingleInstance();

            builder.RegisterType<AuthorizationBasisMetadataSelector>()
                .As<IAuthorizationBasisMetadataSelector>()
                .EnableInterfaceInterceptors()
                //.InterceptedBy(InterceptorCacheKeys.Security)
                .SingleInstance();

            builder.RegisterType<ActionBitValueProvider>()
                .As<IActionBitValueProvider>()
                .SingleInstance();

            builder.RegisterType<AuthorizationContextValidator>()
                .As<IAuthorizationContextValidator>()
                .SingleInstance();

            builder.RegisterType<AuthorizationStrategyResolver>()
                .As<IAuthorizationStrategyResolver>()
                .EnableInterfaceInterceptors()
                //.InterceptedBy(InterceptorCacheKeys.Security)
                .SingleInstance();

            builder.RegisterType<ClaimSetRequestEvaluator>()
                .As<IClaimSetRequestEvaluator>()
                .EnableInterfaceInterceptors()
                //.InterceptedBy(InterceptorCacheKeys.Security)
                .SingleInstance();

            builder.RegisterType<RequestEvaluationStrategiesSelector>()
                .As<IRequestEvaluationStrategiesSelector>()
                .SingleInstance();

            builder.RegisterType<RequestEvaluationValidationRuleSetSelector>()
                .As<IRequestEvaluationValidationRuleSetSelector>()
                .SingleInstance();

            builder.RegisterType<ResourceClaimAuthorizationMetadataLineageProvider>()
                .As<IResourceClaimAuthorizationMetadataLineageProvider>()
                .EnableInterfaceInterceptors()
                //.InterceptedBy(InterceptorCacheKeys.Security)
                .SingleInstance();

            builder.RegisterType<EntityAuthorizer>()
                .As<IEntityAuthorizer>()
                .SingleInstance();

            builder.RegisterType<EntityAuthorizationQueryExecutor>()
                .As<IEntityAuthorizationQueryExecutor>()
                .SingleInstance();

            builder.RegisterType<EntityAuthorizationSqlBuilder>()
                .As<IEntityAuthorizationSqlBuilder>()
                .SingleInstance();

            builder.RegisterType<EntityInstanceAuthorizationValidator>()
                .As<IEntityInstanceAuthorizationValidator>()
                .SingleInstance();

            builder.RegisterType<EntityInstanceDelegateFilterAuthorizer>()
                .As<IEntityInstanceDelegateFilterAuthorizer>()
                .SingleInstance();

            builder.RegisterType<EntityInstanceViewBasedFilterAuthorizer>()
                .As<IEntityInstanceViewBasedFilterAuthorizer>()
                .SingleInstance();

            builder.RegisterType<RedundantAuthorizationContextManager>()
                .As<IRedundantAuthorizationContextManager>()
                .SingleInstance();

            builder.RegisterType<NamedAuthorizationStrategyProvider>()
                .As<IAuthorizationStrategyProvider>()
                .SingleInstance();

            // Register support for custom view-based authorization
            builder.RegisterType<CustomViewBasedAuthorizationStrategyProvider>()
                // Allow caching of information until the security metadata is refreshed
                .EnableClassInterceptors()
                .As<IAuthorizationStrategyProvider>()
                .SingleInstance();

            builder.RegisterType<CustomViewBasedAuthorizationStrategy>()
                .AsSelf();

            builder.RegisterType<CustomViewBasisEntityProvider>()
                .As<ICustomViewBasisEntityProvider>()
                .SingleInstance();
            
            var assembly = typeof(Marker_EdFi_Ods_Api).Assembly;

            RegisterNamedAuthorizationStrategies();

            builder.RegisterAssemblyTypes(typeof(Marker_EdFi_Ods_Api).Assembly)
                .Where(t => typeof(IAuthorizationFilterDefinitionsFactory).IsAssignableFrom(t))
                .As<IAuthorizationFilterDefinitionsFactory>()
                .SingleInstance();

            builder.RegisterType<AuthorizationFilterDefinitionProvider>()
                .As<IAuthorizationFilterDefinitionProvider>()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(Marker_EdFi_Ods_Api).Assembly)
                .Where(t => typeof(IAuthorizationViewHintProvider).IsAssignableFrom(t))
                .As<IAuthorizationViewHintProvider>()
                .SingleInstance();
            
            builder.RegisterType<AuthorizationTablesAndViewsProvider>()
                .As<IAuthorizationTablesAndViewsProvider>()
                .SingleInstance();

            builder.RegisterType<ClaimsIdentityProvider>()
                .As<IClaimsIdentityProvider>()
                .SingleInstance();

            builder.RegisterType<ClaimSetClaimsProvider>()
                .As<IClaimSetClaimsProvider>()
                .EnableInterfaceInterceptors()
                //.InterceptedBy(InterceptorCacheKeys.Security)
                .SingleInstance();

            builder.RegisterType<ResourceClaimUriProvider>()
                .As<IResourceClaimUriProvider>()
                .SingleInstance();

            // RelationshipsAuthorizationContextDataProviderFactory
            builder.RegisterType<RelationshipsAuthorizationContextDataProviderFactory>()
                .As<IRelationshipsAuthorizationContextDataProviderFactory>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(SetAuthorizationContextForGet<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(SetAuthorizationContextForPut<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(SetAuthorizationContextForDelete<,,,>))
                .AsSelf()
                .SingleInstance();

            builder.RegisterGeneric(typeof(SetAuthorizationContextForPost<,,,>))
                .AsSelf()
                .SingleInstance();
            
            builder.RegisterType<EducationOrganizationIdNamesProvider>()
                .As<IEducationOrganizationIdNamesProvider>()
                .SingleInstance();

            void RegisterNamedAuthorizationStrategies()
            {
                var namedStrategyTypes = assembly.GetTypes()
                    .Where(t => typeof(IAuthorizationStrategy).IsAssignableFrom(t) && !t.IsAbstract)
                    .Select(
                        t => new
                        {
                            Type = t,
                            AuthorizationStrategyName = t.GetCustomAttribute<AuthorizationStrategyNameAttribute>()?.Name
                        })
                    .Where(x => x.AuthorizationStrategyName != null)
                    .ToList();

                foreach (var namedStrategyInfo in namedStrategyTypes)
                {
                    builder.RegisterType(namedStrategyInfo.Type)
                        .PropertiesAutowired() // Convenience for DI for derived relationship-based authorization strategies
                        .Keyed<IAuthorizationStrategy>(namedStrategyInfo.AuthorizationStrategyName)
                        .SingleInstance();
                }
            }
        }
    }
}
