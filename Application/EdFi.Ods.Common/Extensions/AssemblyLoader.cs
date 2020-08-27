// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using log4net;

namespace EdFi.Ods.Common.Extensions
{
    /// <summary>
    /// Provides methods for ensuring that an assembly has been loaded into the current
    /// AppDomain based on one or more provided Types.
    /// </summary>
    public static class AssemblyLoader
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssemblyLoader));

        /// <summary>
        /// Ensures that the assembly containing the specified Type has been loaded into the current AppDomain.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> whose containing assembly should be loaded.</typeparam>
        public static void EnsureLoaded<T>()
        {
            EnsureLoaded(typeof(T));
        }

        /// <summary>
        /// Ensures that the assembly containing the specified Types has been loaded into the current AppDomain.
        /// </summary>
        /// <typeparam name="T1">A <see cref="Type"/> whose containing assembly should be loaded.</typeparam>
        /// <typeparam name="T2">A <see cref="Type"/> whose containing assembly should be loaded.</typeparam>
        public static void EnsureLoaded<T1, T2>()
        {
            EnsureLoaded(typeof(T1), typeof(T2));
        }

        /// <summary>
        /// Ensures that the assembly containing the specified Types has been loaded into the current AppDomain.
        /// </summary>
        /// <typeparam name="T1">A <see cref="Type"/> whose containing assembly should be loaded.</typeparam>
        /// <typeparam name="T2">A <see cref="Type"/> whose containing assembly should be loaded.</typeparam>
        /// <typeparam name="T3">A <see cref="Type"/> whose containing assembly should be loaded.</typeparam>
        public static void EnsureLoaded<T1, T2, T3>()
        {
            EnsureLoaded(typeof(T1), typeof(T2), typeof(T3));
        }

        /// <summary>
        /// Ensures that the assembly containing the specified Types has been loaded into the current AppDomain.
        /// </summary>
        /// <param name="markerTypes">One ore more <see cref="Type"/> instances whose containing assembly should be loaded.</param>
        public static void EnsureLoaded(params Type[] markerTypes)
        {
            foreach (Type markerType in markerTypes)
            {
                _logger.DebugFormat("Ensuring that assembly '{0}' has been loaded.", markerType.Assembly.FullName);
            }
        }

        public static bool TryLoad(string assemblyName, out Assembly outAssembly)
        {
            try
            {
                outAssembly = Assembly.Load(assemblyName);
            }
            catch
            {
                outAssembly = null;
            }

            return outAssembly != null;
        }
    }
}
