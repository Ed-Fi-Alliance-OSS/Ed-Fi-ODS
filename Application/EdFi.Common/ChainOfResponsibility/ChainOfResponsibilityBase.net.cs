// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdFi.Common.ChainOfResponsibility
{
    public abstract class ChainOfResponsibilityBase<TService, TRequest, TResponse>
        where TService : class
    {
        //Using the fact this is a static field in a generic type to ensure the stored method info matches the generics.
        private static MethodInfo _method;

        //Using the fact this is a static field in a generic type to ensure the stored method and parameter info matches the generics.
        private static Tuple<MethodInfo, List<ParameterInfo>> _methodAndParameters;

        protected ChainOfResponsibilityBase(TService next)
        {
            Next = next;
        }

        protected TService Next { get; set; }

        protected abstract bool CanHandleRequest(TRequest request);

        protected abstract TResponse HandleRequest(TRequest request);

        public virtual TResponse ProcessRequest(TRequest request)
        {
            if (CanHandleRequest(request))
            {
                return HandleRequest(request);
            }

            if (Next != null)
            {
                var nextResponsible = Next as ChainOfResponsibilityBase<TService, TRequest, TResponse>;

                if (nextResponsible != null)
                {
                    return nextResponsible.ProcessRequest(request);
                }

                // Execute legacy Chain of Responsibility logic, for backwards compatibility
                MethodInfo interfaceMethodInfo = GetRequestResponseMethodInfoFromInterface();

                try
                {
                    if (interfaceMethodInfo != null)
                    {
                        return (TResponse) interfaceMethodInfo.Invoke(
                            Next,
                            new object[]
                            {
                                request
                            });
                    }
                }
                catch (TargetInvocationException exception)
                {
                    var inner = exception.InnerException;
                    throw inner;
                }

                // Handle invocation using the interface to a dynamic proxy created by the ChainOfResponsibilityFacility
                if (Next.GetType()
                        .Name.Contains("Proxy"))
                {
                    // Invoke the interface's first method dynamically
                    return (TResponse) InvokeFirstMethodUsingRequestForArguments(request, Next);
                }
            }

            // GKM 10/22/2014 - It seems an exception should be thrown here instead of providing a default/empty response.  Leaving unchanged due to backwards compatibility support.
            return default(TResponse);
        }

        private static MethodInfo GetRequestResponseMethodInfoFromInterface()
        {
            if (_method == null)
            {
                var methodInfo = (from m in typeof(TService).GetMethods()
                                  let p = m.GetParameters()
                                  where m.ReturnType == typeof(TResponse)
                                        && p.Count() == 1
                                        && (p.Single()
                                             .ParameterType == typeof(TRequest) || p.Single()
                                                                                    .ParameterType.IsAssignableFrom(typeof(TRequest)))
                                  select m)
                   .SingleOrDefault();

                _method = methodInfo;
            }

            return _method;
        }

        private object InvokeFirstMethodUsingRequestForArguments(TRequest request, TService next)
        {
            try
            {
                var method = GetInterfaceMethodAndParametersInfo();

                var args =
                    (from parm in method.Item2
                     from prop in request.GetType()
                                         .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                     where parm.Name.Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase)
                     select prop.GetValue(request, null))
                   .ToList();

                return method.Item1.Invoke(next, args.ToArray());
            }
            catch (TargetInvocationException exception)
            {
                var inner = exception.InnerException;
                throw inner;
            }
        }

        private static Tuple<MethodInfo, List<ParameterInfo>> GetInterfaceMethodAndParametersInfo()
        {
            if (_methodAndParameters == null)
            {
                var propertyInfos = typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var candidateMethodInfo =
                    (from m in typeof(TService).GetMethods()
                     let p = m.GetParameters()
                              .ToList()
                     where m.ReturnType == typeof(TResponse)
                           && p.Count() == propertyInfos.Length
                           && p.All(x => propertyInfos.Any(y => y.Name.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase)))
                     select new
                            {
                                Method = m, Parameters = p
                            })
                   .SingleOrDefault();

                if (candidateMethodInfo == null)
                {
                    throw new Exception(
                        string.Format(
                            "No method signature found on interface '{0}' matching the properties of the ChainOfResponsibility request '{1}' .",
                            typeof(TService).Name,
                            typeof(TRequest).Name));
                }

                var method = Tuple.Create(candidateMethodInfo.Method, candidateMethodInfo.Parameters);
                _methodAndParameters = method;
            }

            return _methodAndParameters;
        }
    }
}
#endif