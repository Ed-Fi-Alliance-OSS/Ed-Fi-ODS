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

namespace EdFi.Ods.Common.InversionOfControl
{
    public class ChainOfResponsibilityRegistrar
    {
        private readonly IWindsorContainer _container;

        public ChainOfResponsibilityRegistrar(IWindsorContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Registers a chain of responsibility with the container with the specified ordered chain members.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TNullObject">The null object pattern implementation to terminate the chain.</typeparam>
        /// <param name="chainTypes">The ordered types (implementing the service type) to be registered.</param>
        /// <returns>The key used to register the chain with the container.</returns>
        /// <remarks>This component registers a series of components implementing the Chain of Responsibility pattern whereby each component either handles a given
        /// request, or the request is passed to the next item in the chain for possible handling using a constructor parameter named "next".  Also, due to a limitation
        /// with the Castle Windsor container, you cannot wire up a null object reference to a constructor argument, and so you must supply the null object type to use
        /// at the end of the chain.  This object should either return no behavior, or throw an exception depending on the behavior desired for unhandled requests.</remarks>
        public string RegisterChainOf<TService, TNullObject>(Type[] chainTypes)
            where TNullObject : TService
            where TService : class
        {
            return RegisterChainOf<TService, TNullObject>(chainTypes, null);
        }

        /// <summary>
        /// Registers a chain of responsibility with the container with the specified ordered chain members.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TNullObject">The null object pattern implementation to terminate the chain.</typeparam>
        /// <param name="chainTypes">The ordered types (implementing the service type) to be registered.</param>
        /// <param name="context">For multiple chains of the same service type, this parameter can be used to supply contextual information to be included in the container 
        /// registration key to distinguish this chain from the others.</param>
        /// <returns>The key used to register the chain with the container.</returns>
        /// <remarks>This component registers a series of components implementing the Chain of Responsibility pattern whereby each component either handles a given
        /// request, or the request is passed to the next item in the chain for possible handling using a constructor parameter named "next".  Also, due to a limitation
        /// with the Castle Windsor container, you cannot wire up a null object reference to a constructor argument, and so you must supply the null object type to use
        /// at the end of the chain.  This object should either return no behavior, or throw an exception depending on the behavior desired for unhandled requests.</remarks>
        public string RegisterChainOf<TService, TNullObject>(Type[] chainTypes, string context)
            where TNullObject : TService
            where TService : class
        {
            string headChainKey = null;

            string nullObjectRegistrationKey = GetNullObjectRegistrationKey<TService, TNullObject>();

            // Create an array of chain types without the null object in it (just in case it's inadvertently been included in the chain types)
            var chainTypesToRegister = chainTypes.Where(t => t != typeof(TNullObject))
                                                 .ToArray();

            for (int i = 0; i < chainTypesToRegister.Length; i++)
            {
                var type = chainTypesToRegister[i];

                var registration =
                    Component
                       .For<TService>()
                       .ImplementedBy(type);

                string registrationName = GetRegistrationKey<TService>(chainTypesToRegister, type, context);
                registration.Named(registrationName);

                if (i == 0)
                {
                    headChainKey = registrationName;
                }

                // If this is the last implementation in the chain...
                if (i == chainTypesToRegister.Length - 1)
                {
                    // ... configure the "next" parameter with null to end the chain of chains
                    //registration.DynamicParameters((k, d) => d["next"] = (IRoleParameterValidator) null);
                    registration.DependsOn(
                        Dependency.OnComponent("next", nullObjectRegistrationKey));
                }
                else
                {
                    // ... configure the service with an override for the next implementer in the chain
                    var nextKey = GetRegistrationKey<TService>(chainTypesToRegister, chainTypesToRegister[i + 1], context);

                    registration.DependsOn(
                        Dependency.OnComponent("next", nextKey));
                }

                // Add an extended property to this registration to prevent the ChainOfResponsibilityFacility from performing any processing
                registration = registration.ExtendedProperties(
                    Property.ForKey("ChainOfResponsibilityRegistrar")
                            .Eq(true));

                _container.Register(registration);

                // Make sure the Null object type is registered (but after the first chain component to prevent context-less components from getting resolved after the Null object)
                if (!_container.Kernel.HasComponent(nullObjectRegistrationKey))
                {
                    _container.Register(
                        Component.For<TService>()
                                 .ImplementedBy<TNullObject>()
                                 .Named(nullObjectRegistrationKey)

                                  // Add an extended property to this registration to prevent the ChainOfResponsibilityFacility from performing any processing
                                 .ExtendedProperties(
                                      Property.ForKey("ChainOfResponsibilityRegistrar")
                                              .Eq(true)));
                }
            }

            return headChainKey;
        }

        private static string GetNullObjectRegistrationKey<TService, TNullObject>()
        {
            return string.Format(
                "{0}.{1}",
                typeof(TService).Name,
                typeof(TNullObject).Name);
        }

        private static string GetRegistrationKey<TService>(IEnumerable<Type> chainTypes, Type type, string context)
        {
            if (type == chainTypes.First())
            {
                return string.Format(
                    "{0}.{1}",
                    typeof(TService).Name,
                    context);
            }

            return string.Format(
                "{0}.{1}.{2}",
                typeof(TService).Name,
                context,
                type.Name);
        }
    }
}
#endif