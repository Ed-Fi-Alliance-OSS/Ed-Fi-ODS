// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using System;
using System.Linq;
using Autofac;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Container;
using EdFi.Ods.Api.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;

namespace EdFi.Ods.Security.Container.Modules
{
    public class AuthorizationStrategyModule : ConditionalModule
    {
        public AuthorizationStrategyModule(ApiSettings apiSettings)
            : base(apiSettings, nameof(AuthorizationStrategyModule)) { }

        public override bool IsSelected() => !ApiSettings.DisableSecurity;

        public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
        {
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
        }
    }
}
#endif
