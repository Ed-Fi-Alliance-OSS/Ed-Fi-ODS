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
using System.Runtime.Loader;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Common.Extensibility;
using EdFi.Ods.Common.Models.Validation;
using EdFi.Ods.Common.Validation;
using FluentValidation;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EdFi.Ods.Api.Helpers
{
    public static class AssemblyLoaderHelper
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssemblyLoaderHelper));
        private const string AssemblyMetadataSearchString = "assemblyMetadata.json";

        public static void LoadAssembliesFromExecutingFolder(bool includeFramework = false)
        {
            // Storage to ensure not loading the same assembly twice and optimize calls to GetAssemblies()
            IDictionary<string, bool> loadedByAssemblyName = new ConcurrentDictionary<string, bool>();

            LoadAssembliesFromExecutingFolder();

            int alreadyLoaded = loadedByAssemblyName.Keys.Count;

            var sw = new Stopwatch();
            _logger.Debug($"Already loaded assemblies:");

            CacheAlreadyLoadedAssemblies(loadedByAssemblyName, includeFramework);

            // Loop on loaded assemblies to load dependencies (it includes Startup assembly so should load all the dependency tree)
            foreach (Assembly nonFrameworkAssemblies in AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => IsNotNetFramework(a.FullName)))
            {
                LoadReferencedAssembly(nonFrameworkAssemblies, loadedByAssemblyName, includeFramework);
            }

            _logger.Debug(
                $"Assemblies loaded after scan ({loadedByAssemblyName.Keys.Count - alreadyLoaded} assemblies in {sw.ElapsedMilliseconds} ms):");

            void LoadAssembliesFromExecutingFolder()
            {
                // Load referenced assemblies into the domain. This is effectively the same as EnsureLoaded in common
                // however the assemblies are linked in the project.
                var directoryInfo = new DirectoryInfo(
                    Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly()
                            .Location));

                _logger.Debug($"Loaded assemblies from executing folder: '{directoryInfo.FullName}'");

                foreach (FileInfo assemblyFilesToLoad in directoryInfo.GetFiles("*.dll")
                    .Where(fi => ShouldLoad(fi.Name, loadedByAssemblyName, includeFramework)))
                {
                    _logger.Debug($"{assemblyFilesToLoad.Name}");

                    try
                    {
                        var assemblyName = AssemblyName.GetAssemblyName(assemblyFilesToLoad.FullName);
                        
                        Assembly.LoadFrom(assemblyFilesToLoad.FullName);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Unable to load assembly {assemblyFilesToLoad.FullName}", ex);
                        throw;
                    }
                }
            }
        }

        private static void LoadReferencedAssembly(Assembly assembly, IDictionary<string, bool> loaded,
            bool includeFramework = false)
        {
            // Check all referenced assemblies of the specified assembly
            foreach (var referencedAssembliesToLoad in assembly.GetReferencedAssemblies()
                .Where(a => ShouldLoad(a.FullName, loaded, includeFramework)))
            {
                // Load the assembly and load its dependencies
                LoadReferencedAssembly(Assembly.Load(referencedAssembliesToLoad), loaded, includeFramework); // AppDomain.CurrentDomain.Load(name)
                loaded.TryAdd(referencedAssembliesToLoad.FullName, true);
                _logger.Debug($"Referenced assembly => '{referencedAssembliesToLoad.FullName}'");
            }
        }

        private static void CacheAlreadyLoadedAssemblies(IDictionary<string, bool> loaded, bool includeFramework = false)
        {
            foreach (var alreadyLoadedAssemblies in AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => ShouldLoad(a.FullName, loaded, includeFramework)))
            {
                loaded.TryAdd(alreadyLoadedAssemblies.FullName, true);
                _logger.Debug($"Assembly '{alreadyLoadedAssemblies.FullName}' was already loaded.");
            }
        }

        private static bool ShouldLoad(string assemblyName, IDictionary<string, bool> loaded, bool includeFramework = false)
        {
            return (includeFramework || IsNotNetFramework(assemblyName))
                   && !loaded.ContainsKey(assemblyName);
        }

        private static bool IsNotNetFramework(string assemblyName)
        {
            return !assemblyName.StartsWithIgnoreCase("Microsoft.")
                   && !assemblyName.StartsWithIgnoreCase("System.")
                   && !assemblyName.StartsWithIgnoreCase("Newtonsoft.")
                   && assemblyName != "netstandard"
                   && !assemblyName.StartsWithIgnoreCase("Autofac")
                   && !assemblyName.StartsWithIgnoreCase("nunit")
                   // Additional assembly included based on target runtime during publish
                   // Needed by Microsoft.Data.SqlClient, which is used by Entity Framework
                   && assemblyName != "sni.dll";
        }

        public static IEnumerable<string> FindPluginAssemblies(string pluginFolder, bool includeFramework = false)
        {
            // Storage to ensure not loading the same assembly twice and optimize calls to GetAssemblies()
            IDictionary<string, bool> loaded = new ConcurrentDictionary<string, bool>();

            CacheAlreadyLoadedAssemblies(loaded, includeFramework);

            if (!IsPluginFolderNameSupplied())
            {
                yield break;
            }

            pluginFolder = Path.GetFullPath(pluginFolder);

            if (!Directory.Exists(pluginFolder))
            {
                _logger.Debug($"Plugin folder '{pluginFolder}' does not exist. No plugins will be loaded.");
                yield break;
            }

            var apiModelFiles = Directory.GetFiles(pluginFolder, "ApiModel-EXTENSION.json", SearchOption.AllDirectories);

            var physicalNames = new List<KeyValuePair<string, string>>();

            Array.Sort(apiModelFiles, StringComparer.InvariantCulture);

            foreach (var apiModelFilePath in apiModelFiles)
            {
                var myJsonString = File.ReadAllText(apiModelFilePath);

                var myJsonObject = JObject.Parse(myJsonString);

                JToken physicalNameJToken = myJsonObject.SelectToken("$.schemaDefinition.physicalName");

                if (physicalNameJToken != null)
                {
                    string[] folderNames = apiModelFilePath.Split(Path.DirectorySeparatorChar);
                    foreach (string folder in folderNames)
                    {
                        if (folder.Contains("Extensions"))
                        {
                            string key = physicalNameJToken.Value<string>();
                            var element = new KeyValuePair<string, string>(key, folder);
                            physicalNames.Add(element);
                        }
                    }
                } 
            }

            bool isDuplicate = false;
            var duplicateExtensionPlugins = physicalNames.ToLookup( x => x.Key).Where(x => x.Count() > 1);

            foreach (var duplicateExtensionPlugin in duplicateExtensionPlugins)
            {
                isDuplicate = true;
                var pluginFolders = duplicateExtensionPlugin.Select(s => s.Value); 
                _logger.Error($"found duplicate extension schema name '{duplicateExtensionPlugin.Key}' in plugin folder." +
                    $" You will be able to deploy only one of the following plugins '{string.Join("' and '", pluginFolders)}' folder name." +
                    $" Please remove the conflicting plugins and retry");
            }

            if(isDuplicate)
            {
                throw new Exception("Found duplicate plugin extension schema name. Please see logs for more details.");

            }

            var assemblies = Directory.GetFiles(pluginFolder, "*.dll", SearchOption.AllDirectories);

            var pluginAssemblyLoadContext = new PluginAssemblyLoadContext();

            try
            {
                foreach (var assemblyPath in assemblies)
                {
                    var assembly = pluginAssemblyLoadContext.LoadFromAssemblyPath(assemblyPath);

                    if (!HasPlugin(assembly))
                    {
                        continue;
                    }

                    string assemblyDirectory = Path.GetDirectoryName(assemblyPath);

                    if (TryReadAssemblyMetadata(assembly, out var assemblyMetadata))
                    {
                        if (IsExtensionAssembly(assemblyMetadata))
                        {
                            var validator = GetExtensionValidator();
                            var validationResult = validator.ValidateObject(assemblyDirectory);

                            if (!validationResult.Any())
                            {
                                yield return assembly.Location;
                            }
                            else
                            {
                                _logger.Warn($"Assembly: {assembly.GetName()} - {string.Join(",", validationResult)}");
                            }
                        }
                    }
                    else if (IsProfileAssembly(assembly))
                    {
                        yield return assembly.Location;
                    }
                    else
                    {
                        throw new Exception(
                            $"Assembly metadata embedded resource '{AssemblyMetadataSearchString}' not found in non-profiles assembly '{Path.GetFileName(assembly.Location)}'.");
                    }
                }
            }
            finally
            {
                pluginAssemblyLoadContext.Unload();
            }

            static FluentValidationObjectValidator GetExtensionValidator()
            {
                return new FluentValidationObjectValidator(
                    new IValidator[]
                    {
                        new ApiModelExistsValidator(),
                        new IsExtensionPluginValidator(),
                        new IsApiVersionValidValidator(ApiVersionConstants.InformationalVersion)
                    });
            }

            bool IsPluginFolderNameSupplied()
            {
                if (!string.IsNullOrWhiteSpace(pluginFolder))
                {
                    return true;
                }

                _logger.Debug($"Plugin folder was not specified so no plugins will be loaded.");
                return false;
            }

            static bool HasPlugin(Assembly assembly)
            {
                return assembly.GetTypes().Any(
                    t => t.GetInterfaces()
                        .Any(i => i.AssemblyQualifiedName == typeof(IPluginMarker).AssemblyQualifiedName));
            }
        }

        private static bool IsExtensionAssembly(AssemblyMetadata assemblyMetadata)
        {
            return assemblyMetadata.AssemblyModelType.EqualsIgnoreCase(PluginConventions.Extension);
        }

        private static bool IsProfileAssembly(Assembly assembly)
        {
            // Determine Profiles assembly from presence of Profiles.xml embedded resource
            return assembly.GetManifestResourceNames()
                .Any(n => n.EndsWithIgnoreCase("Profiles.xml"));
        }

        private static bool TryReadAssemblyMetadata(Assembly assembly, out AssemblyMetadata assemblyMetadata)
        {
            assemblyMetadata = null;
            
            var resourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(p => p.EndsWith(AssemblyMetadataSearchString));

            if (resourceName == null)
            {
                return false;
            }

            var stream = assembly.GetManifestResourceStream(resourceName);

            using var reader = new StreamReader(stream);

            string jsonFile = reader.ReadToEnd();

            _logger.Debug($"Deserializing object type '{typeof(AssemblyMetadata)}' from embedded resource '{resourceName}'.");

            assemblyMetadata =  JsonConvert.DeserializeObject<AssemblyMetadata>(jsonFile);

            return true;
        }

        private class PluginAssemblyLoadContext : AssemblyLoadContext
        {
            public PluginAssemblyLoadContext()
                : base(isCollectible: true) { }
        }

        private class AssemblyMetadata
        {
            public string AssemblyModelType { get; set; }

            public string AssemblyMetadataFormatVersion { get; set; }
        }
    }
}
