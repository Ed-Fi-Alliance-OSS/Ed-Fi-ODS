#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Castle.DynamicProxy;

namespace EdFi.Ods.Common.ChainOfResponsibility
{
    /// <summary>
    /// Implements an <see cref="IInterceptor"/> that handles the boilerplate code of calling
    /// the <see cref="ChainOfResponsibilityBase{TService, TRequest, TResponse}.ProcessRequest"/> 
    /// method for transferring control flow from the external interface to the Chain of Responsibility 
    /// processing.
    /// </summary>
    public class ChainOfResponsibilityLinkInterceptor : IInterceptor
    {
        private readonly ConcurrentDictionary<Type, Func<object, object, object>> _processRequestDelegateByTargetType
            = new ConcurrentDictionary<Type, Func<object, object, object>>();

        private readonly ConcurrentDictionary<RequestTypeMetaData, Func<object[], object>> _requestFactoryDelegateByRequestType
            = new ConcurrentDictionary<RequestTypeMetaData, Func<object[], object>>(RequestTypeMetaData.RequestTypeMetadataComparer);
        private readonly ConcurrentDictionary<Type, Type> _requestTypeByTargetType = new ConcurrentDictionary<Type, Type>();

        public void Intercept(IInvocation invocation)
        {
            var targetType = invocation.TargetType;

            // Get the request type
            var requestType = _requestTypeByTargetType.GetOrAdd(
                targetType,
                t =>
                {
                    // Climb hierarchy to get to ChainOfResponsibilityBase, don't just assume it's the immediate base tye
                    var chainOfResponsibilityType = FindChainOfResponsibilityBaseInTypeHierarchy(targetType);
                    return GetRequestType(chainOfResponsibilityType);
                });

            object request;

            if (invocation.Arguments.Length == 1 && invocation.Arguments[0]
                                                              .GetType()
                                                              .Name.EndsWith("Request"))
            {
                request = invocation.Arguments[0];
            }
            else
            {
                // Get the request factory delegate
                var requestTypeMetaData = new RequestTypeMetaData(requestType, invocation.Method.GetParameters());

                var createRequest = _requestFactoryDelegateByRequestType.GetOrAdd(requestTypeMetaData, GetRequestFactoryDelegate);

                // Create the request
                request = createRequest(invocation.Arguments);
            }

            // Get the ProcessRequest delegate for the target type
            var processRequest = GetProcessRequestDelegate(requestType, targetType);

            // Process it with the Chain of Responsibility implementation
            object resultAsObject = processRequest(invocation.InvocationTarget, request);
            invocation.ReturnValue = resultAsObject;
        }

        private Func<object, object, object> GetProcessRequestDelegate(Type requestType, Type targetType)
        {
            return _processRequestDelegateByTargetType.GetOrAdd(
                targetType,
                t =>
                {
                    // -----------------------
                    // Invoking ProcessRequest
                    // -----------------------
                    var instanceParmExpr = Expression.Parameter(typeof(object), "instance");
                    var requestParmExpr = Expression.Parameter(typeof(object), "request");

                    var requestCastExpr = Expression.Convert(requestParmExpr, requestType);

                    // Call ProcessRequest on behalf of implementation
                    // TODO: Why is ProcessRequest public?  The abstraction is leaking.
                    var processRequestMethodInfo = targetType.GetMethod("ProcessRequest", BindingFlags.Public | BindingFlags.Instance);

                    var callProcessRequestMethodExpr = Expression.Call(
                        Expression.Convert(instanceParmExpr, targetType),
                        processRequestMethodInfo,
                        requestCastExpr);

                    var castReturnToObjectExpr = Expression.Convert(callProcessRequestMethodExpr, typeof(object));

                    var lambda = Expression.Lambda<Func<object, object, object>>(castReturnToObjectExpr, instanceParmExpr, requestParmExpr);

                    return lambda.Compile();
                });
        }

        private Func<object[], object> GetRequestFactoryDelegate(RequestTypeMetaData requestTypeMetaData)
        {
            return _requestFactoryDelegateByRequestType.GetOrAdd(
                requestTypeMetaData,
                rt =>
                {
                    // ------------------------
                    // Request Factory Delegate
                    // ------------------------
                    var argsParmExpr = Expression.Parameter(typeof(object[]), "args");

                    var constructorInfo = rt.RequestType.GetConstructor(Type.EmptyTypes);

                    if (constructorInfo == null)
                    {
                        throw new Exception($"Request type '{rt.RequestType.Name}' does not have a default constructor.");
                    }

                    var constructorExpr = Expression.New(constructorInfo);

                    var properties = rt.RequestType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var bindings = new List<MemberBinding>();

                    for (int i = 0; i < rt.ParameterInfoList.Count; i++)
                    {
                        string parameterName = rt.ParameterInfoList[i];

                        var matchingProperty = properties.FirstOrDefault(
                            p => p.ToString()
                                  .Equals(parameterName, StringComparison.InvariantCultureIgnoreCase));

                        if (matchingProperty != null)
                        {
                            var binding = Expression.Bind(
                                matchingProperty.GetSetMethod(),
                                Expression.Convert(Expression.ArrayIndex(argsParmExpr, Expression.Constant(i)), matchingProperty.PropertyType));

                            bindings.Add(binding);
                        }
                    }

                    var initExpr = Expression.MemberInit(constructorExpr, bindings);

                    var createRequest = Expression.Lambda<Func<object[], object>>(initExpr, argsParmExpr)
                                                  .Compile();

                    return createRequest;
                });
        }

        private static Type GetRequestType(Type chainOfResponsibilityType)
        {
            var args = chainOfResponsibilityType.GetGenericArguments();

            if (args.Length != 3)
            {
                throw new Exception(
                    "ChainOfResponsibility base class is expected to have 3 generic arguments: service type, request type, and response type.");
            }

            // Sanity check -- Make sure that the 2nd generic argument appears to be the request before continuing
            if (!args[1]
                .Name.EndsWith("Request") && !args[1]
                                             .Name.EndsWith("RequestBase"))
            {
                throw new Exception("Second generic argument on ChainOfResponsibilityBase was not the Request.  Has the class been refactored?");
            }

            // Request is the 2nd argument in the generic
            var requestType = args[1];

            return requestType;
        }

        private static Type FindChainOfResponsibilityBaseInTypeHierarchy(Type targetType)
        {
            // Get the request type
            var type = targetType.BaseType;

            while (type != null)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ChainOfResponsibilityBase<,,>))
                {
                    break;
                }

                type = type.BaseType;
            }

            // This should never happen
            if (type == null)
            {
                throw new Exception("Unable to find ChainOfResponsibilityBase in type hierarchy.");
            }

            return type;
        }

        private class RequestTypeMetaData
        {
            public RequestTypeMetaData(Type requestType, IEnumerable<ParameterInfo> parameters)
            {
                RequestType = requestType;

                ParameterInfoList = parameters.Select(x => x.ToString())
                                              .ToList();
            }

            public static IEqualityComparer<RequestTypeMetaData> RequestTypeMetadataComparer { get; } = new RequestTypeMetadataEqualityComparer();

            public Type RequestType { get; }

            public IList<string> ParameterInfoList { get; }

            private class RequestTypeMetadataEqualityComparer : IEqualityComparer<RequestTypeMetaData>
            {
                public bool Equals(RequestTypeMetaData x, RequestTypeMetaData y)
                {
                    if (ReferenceEquals(x, y))
                    {
                        return true;
                    }

                    if (ReferenceEquals(x, null))
                    {
                        return false;
                    }

                    if (ReferenceEquals(y, null))
                    {
                        return false;
                    }

                    if (x.GetType() != y.GetType())
                    {
                        return false;
                    }

                    return x.RequestType.ToString() == y.RequestType.ToString()
                           && x.ParameterInfoList.Select(q => q.ToLowerInvariant())
                               .OrderBy(q => q)
                               .SequenceEqual(
                                    y.ParameterInfoList.Select(q => q.ToLowerInvariant())
                                     .OrderBy(q => q),
                                    StringComparer.InvariantCultureIgnoreCase);
                }

                public int GetHashCode(RequestTypeMetaData obj)
                {
                    return obj.RequestType != null
                        ? obj.RequestType.GetHashCode()
                        : 0;
                }
            }
        }
    }
}
#endif