// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using Autofac;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Pipeline;
using EdFi.Ods.Api.Security.AuthorizationStrategies;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Api.Security.Utilities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdFi.Ods.Api.Security.Container.Modules
{
    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationContextProvider>()
                .As<IAuthorizationContextProvider>()
                .SingleInstance();

            builder.RegisterType<AuthorizationFilterContextProvider>()
                .As<IAuthorizationFilterContextProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorizationFilteringProvider>()
                .As<IAuthorizationFilteringProvider>()
                .SingleInstance();

            builder.RegisterType<AuthorizationBasisMetadataSelector>()
                .As<IAuthorizationBasisMetadataSelector>()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            builder.RegisterType<ResourceAuthorizationMetadataProvider>()
                .As<IResourceAuthorizationMetadataProvider>()
                .InstancePerLifetimeScope();

            var assembly = typeof(Marker_EdFi_Ods_Api).Assembly;

            var strategyTypes = assembly.GetTypes()
                .Where(t => typeof(IAuthorizationStrategy).IsAssignableFrom(t) && !t.IsAbstract).ToList();

            foreach (Type strategyType in strategyTypes)
            {
                // Handle relationship based authorization strategies explicitly
                if (strategyType.IsGenericType)
                {
                    // Property injection is used for RelationshipsAuthorizationStrategyBase<>
                    builder.RegisterType(strategyType.MakeGenericType(typeof(RelationshipsAuthorizationContextData)))
                        .PropertiesAutowired()
                        .As<IAuthorizationStrategy>()
                        .SingleInstance();
                }
                else
                {
                    builder.RegisterType(strategyType)
                        .As<IAuthorizationStrategy>()
                        .SingleInstance();
                }
            }

            builder.RegisterAssemblyTypes(typeof(Marker_EdFi_Ods_Api).Assembly)
                .Where(t => typeof(IAuthorizationFilterDefinitionsFactory).IsAssignableFrom(t))
                .As<IAuthorizationFilterDefinitionsFactory>()
                .SingleInstance();

            builder.RegisterType<AuthorizationFilterDefinitionProvider>()
                .As<IAuthorizationFilterDefinitionProvider>()
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
                .SingleInstance();

            builder.RegisterType<ResourceClaimUriProvider>()
                .As<IResourceClaimUriProvider>()
                .SingleInstance();

            // RelationshipsAuthorizationContextDataProviderFactory
            builder.RegisterType(
                    typeof(RelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                        GetRelationshipBasedAuthorizationStrategyContextDataType())).As(
                    typeof(IRelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                        GetRelationshipBasedAuthorizationStrategyContextDataType()))
                .SingleInstance();

            Type GetRelationshipBasedAuthorizationStrategyContextDataType() => typeof(RelationshipsAuthorizationContextData);

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
        }
    }
}
