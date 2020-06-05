#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EdFi.Ods.Api.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Security.AuthorizationStrategies.Relationships;

namespace EdFi.Ods.Security.Container.Installers
{
    public class AuthorizationStrategiesInstaller<TMarker> : RegistrationMethodsInstallerBase
    {
        protected virtual void RegisterAuthorizationStrategies(IWindsorContainer container)
        {
            var assembly = Assembly.GetAssembly(typeof(TMarker));

            // Register array of IEdFiAuthorizationStrategy
            var strategyTypes = from t in assembly.GetTypes()
                                where typeof(IEdFiAuthorizationStrategy).IsAssignableFrom(t) &&
                                      !t.IsAbstract
                                select t;

            var matchingStrategy = new RelationshipBasedAuthorizationGenericStrategy(
                GetRelationshipBasedAuthorizationStrategyContextDataType());

            foreach (var strategyType in strategyTypes)
            {
                // Handle relationship-based authorization strategies explicitly
                if (typeof(RelationshipsAuthorizationStrategyBase<>).IsAssignableFromGeneric(strategyType))
                {
                    container.Register(
                        Component
                           .For<IEdFiAuthorizationStrategy>()
                           .ImplementedBy(strategyType, matchingStrategy));
                }
                else
                {
                    container.Register(
                        Component
                           .For<IEdFiAuthorizationStrategy>()
                           .ImplementedBy(strategyType));
                }
            }
        }

        protected virtual void RegisterINHibernateFilterConfigurators(IWindsorContainer container)
        {
            container.Register(
                Classes
                   .FromAssemblyContaining<TMarker>()
                   .BasedOn<INHibernateFilterConfigurator>()
                   .WithServiceFromInterface());
        }

        /// <summary>
        /// Gets the context data type for the relationship-based authorizations strategies, providing an extensibility point for additional education organization types.
        /// </summary>
        protected virtual Type GetRelationshipBasedAuthorizationStrategyContextDataType()
        {
            return typeof(RelationshipsAuthorizationContextData);
        }
    }
}
#endif