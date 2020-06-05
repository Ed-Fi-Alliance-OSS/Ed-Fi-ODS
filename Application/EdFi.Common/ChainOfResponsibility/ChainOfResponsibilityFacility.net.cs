#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace EdFi.Ods.Common.ChainOfResponsibility
{
    /// <summary>
    /// Implements a Castle Windsor Facility that simplifies the process of implementing the
    /// Chain of Responsibility pattern by dynamically building Linq expressions to create the
    /// request objects from the interface method arguments (required by the pattern abstraction), 
    /// and eliminating boilerplate code by automatically invoking the ProcessRequest method of 
    /// the <see cref="ChainOfResponsibilityBase{TService, TRequest, TResponse}"/> class.
    /// </summary>
    public class ChainOfResponsibilityFacility : AbstractFacility
    {
        private readonly Dictionary<Type, object> _chainTerminatingProxyByInterface = new Dictionary<Type, object>();
        private readonly HashSet<Type> _interfacesNotImplementedUsingChainOfResponsibility = new HashSet<Type>();
        private readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();

        private bool _isFinalized;

        protected override void Init()
        {
            Kernel.ComponentModelCreated += OnComponentModelCreated;
        }

        private void OnComponentModelCreated(ComponentModel model)
        {
            // Check the component registration for a property marking it as being initiated 
            // from the ChainOfResponsibilityRegstrar, and then exit.
            if (model.ExtendedProperties.Contains("ChainOfResponsibilityRegistrar"))
            {
                return;
            }

            // Determine if implementation class inherits from ChainOfResponsibilityBase
            bool implementsChainOfResponsibility =
                IsAssignableToGenericType(model.Implementation, typeof(ChainOfResponsibilityBase<,,>));

            // Verify that we aren't mixing a ChainOfResponsibility link with previous registered implementations that aren't
            if (IsInterfaceEstablishedAsNotUsingChainOfResponsibility(model) && implementsChainOfResponsibility)
            {
                throw new Exception(
                    string.Format(
                        "Type '{0}' inherits from ChainOfResponsibilityBase, while other registered classes for the '{1}' service do not.  To prevent broken chains, all members of the chain must inherit from ChainOfResponsibility.",
                        model.Implementation.Name,
                        model.Services.First()
                             .Name));
            }

            // Has this interface already been established as being implemented using a Chain of Responsibility?
            if (IsInterfaceEstablishedAsUsingChainOfResponsibility(model))
            {
                // If the current registration doesn't implement the Chain of Responsibility (and it's not the chain-terminating proxy) 
                if (!implementsChainOfResponsibility && !IsDynamicProxy(model.Implementation))
                {
                    throw new Exception(
                        string.Format(
                            "Type '{0}' does not inherit from ChainOfResponsibilityBase, while other registered classes for the '{1}' service do.  To prevent broken chains, all members of the chain must inherit from ChainOfResponsibility.",
                            model.Implementation.Name,
                            model.Services.First()
                                 .Name));
                }

                // We've already built a proxy for this interface, so we're done
                return;
            }

            if (implementsChainOfResponsibility)
            {
                // This is the first implementation of the interface, and it implements the Chain of Responsibility
                // Generate a proxy terminator for the interface
                var p = _proxyGenerator.CreateInterfaceProxyWithoutTarget(
                    model.Services.First(),
                    new ChainOfResponsibilityTerminatorProxyInterceptor());

                _chainTerminatingProxyByInterface.Add(model.Services.First(), p);
            }
            else
            {
                // Make note of the fact that this interface has an implementation that doesn't implement the Chain of Responsibility
                _interfacesNotImplementedUsingChainOfResponsibility.Add(model.Services.First());
            }
        }

        private bool IsInterfaceEstablishedAsUsingChainOfResponsibility(ComponentModel model)
        {
            return _chainTerminatingProxyByInterface.ContainsKey(model.Services.First());
        }

        private bool IsInterfaceEstablishedAsNotUsingChainOfResponsibility(ComponentModel model)
        {
            return _interfacesNotImplementedUsingChainOfResponsibility.Contains(model.Services.First());
        }

        /// <summary>
        /// Registers a dynamic proxy on the end of each chain of responsibility to automatically 
        /// handle the "unhandled request" scenario.
        /// </summary>
        /// <remarks>This method may be made obsolete by Castle Windsor 3.x's "IsDefault" feature on component registrations.</remarks>
        public void FinalizeChains()
        {
            if (_isFinalized)
            {
                throw new InvalidOperationException("Chains have already been finalized.");
            }

            // Prepare the interceptor for boilerplate to provide boilerplate "ProcessRequest" method invocation from arguments
            Kernel.Register(Component.For<ChainOfResponsibilityLinkInterceptor>());
            var linkInterceptorReference = new InterceptorReference(typeof(ChainOfResponsibilityLinkInterceptor));

            // Add interceptor to all implementation classes to handle boilerplate invocation
            foreach (var kvp in _chainTerminatingProxyByInterface)
            {
                var handlers = Kernel.GetHandlers(kvp.Key);

                foreach (var handler in handlers)
                {
                    handler.ComponentModel.Interceptors.AddFirst(linkInterceptorReference);
                }

                // Register the chain terminating proxy
                Kernel.Register(
                    Component.For(kvp.Key)
                             .Instance(kvp.Value));
            }

            _isFinalized = true;
        }

        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            Type baseType = givenType.BaseType;

            if (baseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(baseType, genericType);
        }

        private static bool IsDynamicProxy(Type implementation)
        {
            // TODO: This implementation may be too simple, and may need to be tightened down
            return implementation.Name.EndsWith("Proxy");
        }
    }
}
#endif