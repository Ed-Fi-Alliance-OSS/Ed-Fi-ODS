// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using System;
using Autofac;
using EdFi.Ods.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;

namespace EdFi.Ods.Security.Container.Modules
{
    public class RelationshipsAuthorizationContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
        }
    }
}
#endif
