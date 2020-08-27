// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Extensibility;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.Ods.Common
{
    public class AssembliesProvider : IAssembliesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(AssembliesProvider));

        public Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();

        public Assembly Get(string assemblyName) => GetAssemblies().FirstOrDefault(x=> x.GetName().Name.EqualsIgnoreCase(assemblyName));

        public Assembly[] GetAssembliesContaining<T>()
            => GetAssemblies()
                .Where(x => x.GetTypes().Any(y => y.GetInterfaces().Contains(typeof(T))))
                .ToArray();

        /// <summary>
        /// Defines a method that searches the provided folder for, and loads assemblies that include
        /// a type (generally a marker interface) that implements the <see cref="IPluginMarker" /> interface.
        /// </summary>
        /// <param name="pluginFolder">The full path of the folder to scan for plug-ins.</param>
        public void LoadPluginAssemblies(string pluginFolder)
        {
            if (!IsSuppliedPluginFolderName())
            {
                return;
            }

            foreach (var assembly in GetPlugins())
            {
                Assembly.Load(assembly.GetName());
            }

            IEnumerable<Assembly> GetPlugins()
            {
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += (s, e) =>
                {
                    var assembly = Assembly.ReflectionOnlyLoad(e.Name);

                    if (assembly == null)
                    {
                        throw new Exception($"Could not load assembly {e.Name}.");
                    }

                    return assembly;
                };

                var directoryInfo = new DirectoryInfo(pluginFolder);

                // return no plugins to load if the folder does not exist
                if (!directoryInfo.Exists)
                {
                    _logger.Debug($"Plugin folder '{pluginFolder}' does not exist.");
                    yield break;
                }

                // return the assemblies that are only plugins and exclude non plugin assembles (e.g. log4net.dll)
                foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.dll"))
                {
                    var assembly = Assembly.ReflectionOnlyLoadFrom(fileInfo.FullName);

                    // load in the referenced assemblies into the reflection domain
                    foreach (AssemblyName referencedAssembly in assembly.GetReferencedAssemblies())
                    {
                        Assembly.ReflectionOnlyLoad(referencedAssembly.FullName);
                    }

                    if (assembly.GetTypes().Any(t =>
                        t.GetInterfaces().Any(i =>
                            i.AssemblyQualifiedName == typeof(IPluginMarker).AssemblyQualifiedName)))
                    {
                        yield return assembly;
                    }
                }
            }

            bool IsSuppliedPluginFolderName()
            {
                if (string.IsNullOrEmpty(pluginFolder))
                {
                    _logger.Debug($"Plugin folder is null or empty so no plugins will be loaded.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(pluginFolder))
                {
                    _logger.Debug($"Plugin folder is null or whitespace so no plugins will be loaded.");
                    return false;
                }

                return true;
            }
        }

    }
}
