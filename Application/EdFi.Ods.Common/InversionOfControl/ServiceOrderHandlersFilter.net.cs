#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel;

namespace EdFi.Ods.Common.InversionOfControl
{
    /// <summary>
    /// This is a HandlersFilter for CastleWindsor that causes Castle to return the services of type TService in the order
    /// that is derived from the order declaration methods (ExecuteThisBeforeThis, ExecuteThisAfterThis)
    /// </summary>
    /// <typeparam name="TService">The type of the class (service) that this instance should operate on</typeparam>
    public class ServiceOrderHandlersFilter<TService> : IHandlersFilter<TService>
    {
        private readonly List<Tuple<Type, Type>> _executeAfters;
        private readonly List<Tuple<Type, Type>> _executeBefores;
        private readonly Lazy<IEnumerable<Type>> _typeOrder;

        public ServiceOrderHandlersFilter()
        {
            _typeOrder = new Lazy<IEnumerable<Type>>(ResolveTypeOrder);
            _executeAfters = new List<Tuple<Type, Type>>();
            _executeBefores = new List<Tuple<Type, Type>>();
        }

        private IEnumerable<Type> TypeOrder
        {
            get { return _typeOrder.Value; }
        }

        public ICloseHandlersFilterFluentConstraint<TService, TThis> Execute<TThis>()
            where TThis : TService
        {
            return new ServiceOrderHandlersFilterFluentManager<TService, TThis>(this);
        }

        public bool HasOpinionAbout(Type service)
        {
            return service == typeof(TService);
        }

        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            //Get the service implementers that aren't covered by the ordered type enumerable.
            var unorderedTypeHandlers = handlers.Where(h => !TypeOrder.Contains(h.ComponentModel.Implementation));

            //Order the Handlers by type (this also filters types that are not ordered out)
            var orderedTypeHandlers =
                TypeOrder.Join(handlers, t => t, h => h.ComponentModel.Implementation, (t, h) => h)
                         .ToList();

            //Add the unordered handlers to the end of the handler list.
            orderedTypeHandlers.AddRange(unorderedTypeHandlers);

            return orderedTypeHandlers.ToArray();
        }

        private IEnumerable<Type> ResolveTypeOrder()
        {
            var typeDependency = new Dictionary<Type, List<Type>>();

            var alltypes = _executeBefores.SelectMany(
                                               t => new[]
                                                    {
                                                        t.Item1, t.Item2
                                                    })
                                          .Union(
                                               _executeAfters.SelectMany(
                                                   t => new[]
                                                        {
                                                            t.Item1, t.Item2
                                                        }))
                                          .Distinct()
                                          .ToList();

            foreach (var tuple in _executeBefores)
            {
                var thisType = tuple.Item1;
                var beforeType = tuple.Item2;

                if (!typeDependency.ContainsKey(beforeType) || typeDependency[beforeType] == null)
                {
                    typeDependency[beforeType] = new List<Type>();
                }

                if (!typeDependency.ContainsKey(thisType) || typeDependency[thisType] == null)
                {
                    typeDependency[thisType] = new List<Type>();
                }

                typeDependency[beforeType]
                   .Add(thisType);
            }

            foreach (var tuple in _executeAfters)
            {
                var thisType = tuple.Item1;
                var afterType = tuple.Item2;

                if (!typeDependency.ContainsKey(thisType) || typeDependency[thisType] == null)
                {
                    typeDependency[thisType] = new List<Type>();
                }

                if (!typeDependency.ContainsKey(afterType) || typeDependency[afterType] == null)
                {
                    typeDependency[afterType] = new List<Type>();
                }

                typeDependency[thisType]
                   .Add(afterType);
            }

            var typeDependencyKeys = typeDependency.Keys.ToArray();

            //Create a distinct dependency list
            foreach (var key in typeDependencyKeys)
            {
                typeDependency[key] = typeDependency[key]
                                     .Distinct()
                                     .ToList();
            }

            //Get the types with no dependencies into a list.
            var typeOrders = typeDependency.Where(x => !x.Value.Any())
                                           .Select(x => x.Key)
                                           .ToList();

            var typeOrderCount = -1;

            //Run through until either all the types are in the order list OR the order list count stops changing.
            while (alltypes.Except(typeOrders)
                           .Any() || typeOrderCount == typeOrders.Count)
            {
                typeOrderCount = typeOrders.Count;

                var typesToAdd =
                    typeDependency.Where(
                                       x => !x.Value.Except(typeOrders)
                                              .Any() && !typeOrders.Contains(x.Key))
                                  .Select(x => x.Key)
                                  .ToArray();

                if (typesToAdd.Any())
                {
                    typeOrders.AddRange(typesToAdd);
                }
            }

            return typeOrders.ToList();
        }

        public void ExecuteThisBeforeThis<TThis, TBeforeThis>()
            where TThis : TService
            where TBeforeThis : TService
        {
            _executeBefores.Add(new Tuple<Type, Type>(typeof(TThis), typeof(TBeforeThis)));
        }

        public void ExecuteThisAfterThis<TThis, TAfterThis>()
            where TThis : TService
            where TAfterThis : TService
        {
            _executeAfters.Add(new Tuple<Type, Type>(typeof(TThis), typeof(TAfterThis)));
        }
    }

    public class ServiceOrderHandlersFilterFluentManager<TService, TThis> : ICloseHandlersFilterFluentConstraint<TService, TThis>
        where TThis : TService
    {
        private readonly ServiceOrderHandlersFilter<TService> _filter;

        public ServiceOrderHandlersFilterFluentManager(ServiceOrderHandlersFilter<TService> filter)
        {
            _filter = filter;
        }

        public void Before<TBefore>()
            where TBefore : TService
        {
            _filter.ExecuteThisBeforeThis<TThis, TBefore>();
        }

        public void After<TAfter>()
            where TAfter : TService
        {
            _filter.ExecuteThisAfterThis<TThis, TAfter>();
        }
    }
}
#endif