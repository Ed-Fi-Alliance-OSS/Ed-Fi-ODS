#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace EdFi.Ods.Common.InversionOfControl
{
    public interface ICloseHandlersFilterFluentConstraint<TService, TThis>
        where TThis : TService
    {
        void Before<TBefore>()
            where TBefore : TService;

        void After<TAfter>()
            where TAfter : TService;
    }

    public interface IDefineHandlersFilterFluentPredicate<TService>
    {
        ICloseHandlersFilterFluentConstraint<TService, TThis> Execute<TThis>()
            where TThis : TService;
    }

    public interface IHandlersFilter<TService> : IHandlersFilter, IDefineHandlersFilterFluentPredicate<TService> { }

    public static class GenericFiltersManager
    {
        private static bool IsAssignableFromOpenGeneric(this Type typeToCheck, Type openGenericType)
        {
            if (!openGenericType.IsGenericType || typeToCheck == null)
            {
                return false;
            }

            if (typeToCheck.IsGenericType)
            {
                var typeArgs = typeToCheck.GetGenericArguments();

                if (typeArgs.Length == openGenericType.GetGenericArguments()
                                                      .Length)
                {
                    try
                    {
                        var closed = openGenericType.MakeGenericType(typeArgs);
                        return closed.IsAssignableFrom(typeToCheck);
                    }
                    catch
                    {
                        //violated type constraints
                        return false;
                    }
                }
            }
            else
            {
                return IsAssignableFromOpenGeneric(typeToCheck.BaseType, openGenericType)
                       || typeToCheck.GetInterfaces()
                                     .Any(i => IsAssignableFromOpenGeneric(i, openGenericType));
            }

            return false;
        }

        /// <summary>
        /// Adds a filter that implements <see cref="IHandlersFilter{TService}"/> to the
        /// container for both the generic and non generic <see cref="IHandlersFilter"/>
        /// versions of the interface.
        /// </summary>
        /// <typeparam name="TFilter">The filter with a parameterless constructor to add to the container</typeparam>
        /// <typeparam name="TService">The service type the filter is for</typeparam>
        /// <param name="container"></param>
        public static IHandlersFilter<TService> GetOrAddFilter<TFilter, TService>(this IWindsorContainer container)
            where TFilter : IHandlersFilter<TService>, new()
        {
            if (!container.Kernel.HasComponent(typeof(IHandlersFilter<TService>)))
            {
                var filter = Activator.CreateInstance<TFilter>();

                container.Register(
                    Component.For<IHandlersFilter<TService>, IHandlersFilter>()
                             .Instance(filter));
            }

            return container.Resolve<IHandlersFilter<TService>>();
        }

        /// <summary>
        /// Adds any generic <see cref="IHandlersFilter{TService}"/> that are in the container as
        /// <see cref="IHandlersFilter"/>'s on the container.
        /// </summary>
        /// <param name="container">The source and destination container.</param>
        public static void FinalizeFilters(this IWindsorContainer container)
        {
            var filters = container.ResolveAll<IHandlersFilter>();

            if (filters == null)
            {
                return;
            }

            var registeredServiceHandlers = new HashSet<Type>();

            foreach (var handlersFilter in filters)
            {
                if (!handlersFilter.GetType()
                                   .IsAssignableFromOpenGeneric(typeof(IHandlersFilter<>)))
                {
                    continue;
                }

                var serviceHandledType =
                    handlersFilter.GetType()
                                  .GenericTypeArguments.SingleOrDefault(ga => ga.IsInterface);

                if (serviceHandledType == null)
                {
                    continue;
                }

                //Prevents filters defined for a service generically from registering for the same service
                //more than once as only the first filter registered for a service is used.
                registeredServiceHandlers.Add(serviceHandledType);

                container.Kernel.AddHandlersFilter(handlersFilter);
            }
        }
    }
}
#endif