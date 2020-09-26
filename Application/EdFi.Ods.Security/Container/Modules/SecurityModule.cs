// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using System;
using System.Linq;
using Autofac;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.Authorization.Filtering;
using EdFi.Ods.Security.Authorization.Pipeline;
using EdFi.Ods.Security.AuthorizationStrategies;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Security.Claims;
using EdFi.Ods.Security.Utilities;

namespace EdFi.Ods.Security.Container.Modules
{
    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationContextProvider>()
                .As<IAuthorizationContextProvider>()
                .SingleInstance();

            builder.RegisterType<AuthorizationFilterContextProvider>().As<IAuthorizationFilterContextProvider>();

            builder.RegisterType<EdFiAuthorizationProvider>().As<IEdFiAuthorizationProvider>();
            builder.RegisterType<AuthorizationSegmentsVerifier>().As<IAuthorizationSegmentsVerifier>();
            builder.RegisterType<ResourceAuthorizationMetadataProvider>().As<IResourceAuthorizationMetadataProvider>();

            builder.RegisterType<AuthorizationSegmentsToFiltersConverter>().As<IAuthorizationSegmentsToFiltersConverter>();

            var assembly = GetType().Assembly;

            var strategyTypes = assembly.GetTypes()
                .Where(t => typeof(IEdFiAuthorizationStrategy).IsAssignableFrom(t) && !t.IsAbstract).ToList();

            foreach (Type strategyType in strategyTypes)
            {
                // Handle relationship based authorization strategies explicitly
                if (strategyType.IsGenericType)
                {
                    // Property injection is used for RelationshipsAuthorizationStrategyBase<>
                    builder.RegisterType(strategyType.MakeGenericType(typeof(RelationshipsAuthorizationContextData)))
                        .PropertiesAutowired()
                        .As<IEdFiAuthorizationStrategy>();
                }
                else
                {
                    builder.RegisterType(strategyType)
                        .As<IEdFiAuthorizationStrategy>();
                }
            }

            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => typeof(INHibernateFilterConfigurator).IsAssignableFrom(t))
                .As<INHibernateFilterConfigurator>();

            builder.RegisterType<AuthorizationViewsProvider>().As<IAuthorizationViewsProvider>();

            builder.RegisterType<ClaimsIdentityProvider>().As<IClaimsIdentityProvider>();
            builder.RegisterType<ResourceClaimUriProvider>().As<IResourceClaimUriProvider>();

            builder.RegisterType<EducationOrganizationHierarchyProvider>().As<IEducationOrganizationHierarchyProvider>();

            // RelationshipsAuthorizationContextDataProviderFactory
            builder.RegisterType(
                typeof(RelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                    GetRelationshipBasedAuthorizationStrategyContextDataType())).As(
                typeof(IRelationshipsAuthorizationContextDataProviderFactory<>).MakeGenericType(
                    GetRelationshipBasedAuthorizationStrategyContextDataType()));

            // ConcreteEducationOrganizationIdAuthorizationContextDataTransformer
            builder.RegisterType(
                typeof(ConcreteEducationOrganizationIdAuthorizationContextDataTransformer<>).MakeGenericType(
                    GetRelationshipBasedAuthorizationStrategyContextDataType())).As(
                typeof(IConcreteEducationOrganizationIdAuthorizationContextDataTransformer<>).MakeGenericType(
                    GetRelationshipBasedAuthorizationStrategyContextDataType()));

            Type GetRelationshipBasedAuthorizationStrategyContextDataType() => typeof(RelationshipsAuthorizationContextData);

            builder.RegisterGeneric(typeof(SetAuthorizationContextForGet<,,,>)).AsSelf();
            builder.RegisterGeneric(typeof(SetAuthorizationContextForPut<,,,>)).AsSelf();
            builder.RegisterGeneric(typeof(SetAuthorizationContextForDelete<,,,>)).AsSelf();
            builder.RegisterGeneric(typeof(SetAuthorizationContextForPost<,,,>)).AsSelf();
        }
    }
}
#endif
