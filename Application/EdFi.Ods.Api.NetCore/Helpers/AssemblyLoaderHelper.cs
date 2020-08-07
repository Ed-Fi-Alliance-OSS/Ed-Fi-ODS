// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using EdFi.Ods.Common.Extensibility;
using log4net;
namespace EdFi.Ods.Api.NetCore.Helpers
{
    public static class AssemblyLoaderHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssemblyLoaderHelper));

        public static void LoadAssembliesFromExecutingFolder(bool includeFramework = false)
        {
            // Storage to ensure not loading the same assembly twice and optimize calls to GetAssemblies()
            IDictionary<string, bool> loaded = new ConcurrentDictionary<string, bool>();

            LoadAssembliesFromExecutingFolder();

            int alreadyLoaded = loaded.Keys.Count;

            var sw = new Stopwatch();
            _logger.Debug($"Already loaded assemblies:");

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => ShouldLoad(a.FullName)))
            {
                loaded.TryAdd(a.FullName, true);
                _logger.Debug($"{a.FullName}");
            }

            // Loop on loaded assemblies to load dependencies (it includes Startup assembly so should load all the dependency tree)
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => IsNotNetFramework(a.FullName)))
            {
                LoadReferencedAssembly(assembly);
            }

            _logger.Debug(
                $"Assemblies loaded after scan ({loaded.Keys.Count - alreadyLoaded} assemblies in {sw.ElapsedMilliseconds} ms):");

            // Filter to avoid loading all the .net framework
            bool ShouldLoad(string assemblyName)
            {
                return (includeFramework || IsNotNetFramework(assemblyName))
                       && !loaded.ContainsKey(assemblyName);
            }

            bool IsNotNetFramework(string assemblyName)
            {
                return !assemblyName.StartsWith("Microsoft.", StringComparison.CurrentCultureIgnoreCase)
                       && !assemblyName.StartsWith("System.", StringComparison.CurrentCultureIgnoreCase)
                       && !assemblyName.StartsWith("Newtonsoft.", StringComparison.CurrentCultureIgnoreCase)
                       && assemblyName != "netstandard"
                       && !assemblyName.StartsWith("Autofac", StringComparison.CurrentCultureIgnoreCase);
            }

            void LoadReferencedAssembly(Assembly assembly)
            {
                // Check all referenced assemblies of the specified assembly
                foreach (AssemblyName an in assembly.GetReferencedAssemblies()
                    .Where(a => ShouldLoad(a.FullName)))
                {
                    // Load the assembly and load its dependencies
                    LoadReferencedAssembly(Assembly.Load(an)); // AppDomain.CurrentDomain.Load(name)
                    loaded.TryAdd(an.FullName, true);
                    _logger.Debug($"Referenced assembly => {an.FullName}");
                }
            }

            void LoadAssembliesFromExecutingFolder()
            {
                // Load referenced assemblies into the domain. This is effectively the same as EnsureLoaded in common
                // however the assemblies are linked in the project.
                var directoryInfo = new DirectoryInfo(
                    Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly()
                            .Location));

                _logger.Debug($"Loaded assemblies from executing folder: {directoryInfo.FullName}");

                foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.dll")
                    .Where(fi => ShouldLoad(fi.Name)))
                {
                    _logger.Debug($"{fileInfo.Name}");
                    Assembly.LoadFrom(fileInfo.FullName);
                }
            }
        }

        public static void LoadPluginAssemblies(string pluginFolder)
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
                    _logger.Debug($"Plugin folder '{pluginFolder}' does not exist. No plugins will be loaded.");
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

                    if (assembly.GetTypes()
                        .Any(
                            t =>
                                t.GetInterfaces()
                                    .Any(
                                        i =>
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
