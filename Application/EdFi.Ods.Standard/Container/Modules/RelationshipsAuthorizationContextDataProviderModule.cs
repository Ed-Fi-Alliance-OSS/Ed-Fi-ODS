// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Configuration;
using System.Linq;
using Autofac;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;

namespace EdFi.Ods.Standard.Container.Modules
{
    public class RelationshipsAuthorizationContextDataProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Marker_EdFi_Ods_Standard).Assembly)
                .AsClosedTypesOf(typeof(IRelationshipsAuthorizationContextDataProvider<,>))
                .AsImplementedInterfaces();

            var relationshipContextDataProviderTypes = typeof(Marker_EdFi_Ods_Standard).Assembly.GetTypes()
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

                builder.RegisterType(closedServiceType).As(closedInterfaceType);
            }

            Type GetRelationshipBasedAuthorizationStrategyContextDataType() => typeof(RelationshipsAuthorizationContextData);
        }
    }
}
#endif