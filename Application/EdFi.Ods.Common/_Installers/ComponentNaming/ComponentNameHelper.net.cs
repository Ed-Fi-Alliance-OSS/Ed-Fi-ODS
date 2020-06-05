#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using Castle.MicroKernel.Registration;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Common._Installers.ComponentNaming
{
    public static class ComponentNameHelper
    {
        /// <summary>
        /// Returns a two-part name using the <see cref="Type.Name"/> property and the supplied suffix, separated by a period.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the service to use for the first part of the name.</param>
        /// <param name="suffix">The text suffix for the second part of the name.</param>
        /// <returns></returns>
        public static string GetServiceNameWithSuffix(this Type serviceType, string suffix)
        {
            return serviceType.Name + "." + suffix;
        }

        /// <summary>
        /// Names a component registration for an <see cref="IDatabaseConnectionStringProvider"/> using 
        /// the supplied enumeration value's name as the suffix on the key.
        /// </summary>
        /// <typeparam name="T">The service type being registered.</typeparam>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/> whose values represent the databases used by the application.</typeparam>
        /// <param name="registration">The <see cref="ComponentRegistration"/> instance.</param>
        /// <param name="database">The enumeration value representing the database to use for naming the registration.</param>
        /// <returns>The <see cref="ComponentRegistration"/> instance, for method chaining.</returns>
        public static ComponentRegistration<T> NamedForDatabase<T, TEnum>(this ComponentRegistration<T> registration, TEnum database)
            where T : class, IDatabaseConnectionStringProvider
        {
            // Only enumerations are supported
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Generic type 'TEnum' must be an enumeration.");
            }

            string enumName = Enum.GetName(typeof(TEnum), database);

            string componentName = typeof(T).GetServiceNameWithSuffix(enumName);

            registration.Named(componentName);

            return registration;
        }
    }
}
#endif