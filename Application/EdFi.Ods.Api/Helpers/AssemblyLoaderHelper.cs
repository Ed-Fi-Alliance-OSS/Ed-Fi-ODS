// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using EdFi.Ods.Common.Extensibility;
using log4net;

namespace EdFi.Ods.Api.Helpers
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

            var pluginFinder = new PluginFinder<IPluginMarker>();

            foreach (var assemblyFile in pluginFinder.FindAssemliesWithPlugins(pluginFolder))
            {
                Assembly.LoadFile(assemblyFile);
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

    public class PluginFinder<TPlugin> 
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(PluginFinder<>));

        private class PluginAssemblyLoadingContext : AssemblyLoadContext
        {
            public PluginAssemblyLoadingContext()
                : base(true)
            {

            }
        }

        public IEnumerable<string> FindAssemliesWithPlugins(string pluginFolder)
        {
            // return no plugins to load if the folder does not exist
            if (!Directory.Exists(pluginFolder))
            {
                _logger.Debug($"Plugin folder '{pluginFolder}' does not exist. No plugins will be loaded.");
                yield break;
            }

            var assemblies = Directory.GetFiles(pluginFolder,"*.dll", SearchOption.AllDirectories);

            var pluginFinderAssemblyContext = new PluginAssemblyLoadingContext();

            foreach (var assemblyPath in assemblies)
            {
                var assembly = pluginFinderAssemblyContext.LoadFromAssemblyPath(assemblyPath);
                if (HasPlugins(assembly))
                {
                    yield return assembly.Location;
                }
            }

            pluginFinderAssemblyContext.Unload();
        }

        public static bool HasPlugins(Assembly assembly)
        {
           return assembly.GetTypes()
                .Any(
                    t =>
                        t.GetInterfaces()
                            .Any(
                                i =>
                                    i.AssemblyQualifiedName == typeof(TPlugin).AssemblyQualifiedName));
        }
    }
}
#endif