// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Reflection;
using Autofac;

namespace EdFi.Ods.Api.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Indicates whether the type implements the decorator pattern for the specified service type (is an instantiatable
        /// class that implements or inherits from the service type, and receives another instance of the service type as a
        /// constructor argument).
        /// </summary>
        /// <param name="type">The <see cref="Type" /> being evaluated.</param>
        /// <typeparam name="TService">The type of the service whose implementations are to be decorated.</typeparam>
        /// <returns><b>true</b> if the type is a decorator; otherwise <b>false</b>.</returns>
        public static bool IsDecoratorOf<TService>(this Type type)
        {
            return type.GetTypeInfo().IsDecoratorOf<TService>();
        }

        /// <summary>
        /// Indicates whether the type implements the decorator pattern for the specified service type (is an instantiatable
        /// class that implements or inherits from the service type, and receives another instance of the service type as a
        /// constructor argument).
        /// </summary>
        /// <param name="type">The <see cref="TypeInfo" /> being evaluated.</param>
        /// <typeparam name="TService">The type of the service whose implementations are to be decorated.</typeparam>
        /// <returns><b>true</b> if the type is a decorator; otherwise <b>false</b>.</returns>
        public static bool IsDecoratorOf<TService>(this TypeInfo type)
        {
            // If it's not an implementation of the service
            if (!type.IsImplementationOf<TService>()
                || type.DeclaredConstructors.Count() != 1)
            {
                return false;
            }

            var constructorInfo = type.DeclaredConstructors.Single();

            // Constructor must have a parameter that is of the service type
            return constructorInfo.GetParameters().Any(p => p.ParameterType == typeof(TService));
        }

        /// <summary>
        /// Indicates whether the is an implementation of the specified service type -- that it is assignable to the supplied
        /// service type, is not an interface, and is not an abstract class.
        /// </summary>
        /// <param name="subjectType">The <see cref="Type" /> being evaluated.</param>
        /// <typeparam name="TService">The <see cref="Type" /> of the service to be implemented.</typeparam>
        /// <returns><b>true</b> if the type is an implementation of the service type; otherwise <b>false</b>.</returns>
        public static bool IsImplementationOf<TService>(this Type subjectType)
        {
            return subjectType.IsAssignableTo<TService>() 
                && !subjectType.IsInterface
                && !subjectType.IsAbstract;
        }
    }
}
