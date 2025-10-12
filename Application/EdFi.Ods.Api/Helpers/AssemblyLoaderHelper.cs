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
        private static readonly Dictionary<(string path, bool includeFramework), bool> _assembliesAlreadyLoadedByIncludeFrameworkOption = new();

        private const string AssemblyMetadataSearchString = "assemblyMetadata.json";

        /// <summary>
        /// Load assemblies from the folder specified by <paramref name="directory"/>.
        /// If <paramref name="directory"/> is null or empty, the folder containing the currently executing assembly will be used.
        /// </summary>
        /// <param name="directory">Optional: Directory from which assemblies should be loaded (Default: null). </param>
        /// <param name="includeFramework">Optional: Should .NET framework assemblies be included in the loading (Default: false).</param>
        public static void LoadAssembliesFromFolder(string directory = null, bool includeFramework = false)
        {
            directory = GetDefaultDirectoryIfNotProvided(directory);

            if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            {
                return;
            }

            var directoryInfo = new DirectoryInfo(directory);

            if (_assembliesAlreadyLoadedByIncludeFrameworkOption.ContainsKey((directoryInfo.FullName, includeFramework)))
            {
                return;
            }

            // Mark as having already executed with this option
            _assembliesAlreadyLoadedByIncludeFrameworkOption[(directoryInfo.FullName, includeFramework)] = true;

            // Storage to ensure not loading the same assembly twice and optimize calls to GetAssemblies()
            IDictionary<string, bool> loadedByAssemblyName = new ConcurrentDictionary<string, bool>();

            _logger.Debug($"Loaded assemblies from executing folder: '{directoryInfo.FullName}'");

            foreach (FileInfo assemblyFilesToLoad in directoryInfo.GetFiles("*.dll")
                         .Where(fi => ShouldLoad(fi.Name, loadedByAssemblyName, includeFramework)))
            {
                LoadAssemblyFile(assemblyFilesToLoad);
            }

            int alreadyLoaded = loadedByAssemblyName.Keys.Count;

            var sw = new Stopwatch();
            sw.Start();
            
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
        }

        public static string GetPluginFolder(string pluginSettingsFolder)
        {
            if (string.IsNullOrWhiteSpace(pluginSettingsFolder))
            {
                return string.Empty;
            }

            if (Path.IsPathRooted(pluginSettingsFolder))
            {
                return pluginSettingsFolder;
            }

            // in a developer environment the plugin folder is relative to the WebApi project
            // "Get-RepositoryRoot "Ed-Fi-ODS"/Application/EdFi.Ods.WebApi/bin/Debug/net8.0/../../../" => "Get-RepositoryRoot "Ed-Fi-ODS"/Application/EdFi.Ods.WebApi"
            var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory!, "../../../"));
            var relativeToProject = Path.GetFullPath(Path.Combine(projectDirectory, pluginSettingsFolder));

            if (Directory.Exists(relativeToProject))
            {
                return relativeToProject;
            }

            // in a deployment environment the plugin folder is relative to the executable
            // "C:/inetpub/Ed-Fi/WebApi"
            var relativeToExecutable =
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory!, pluginSettingsFolder));

            if (Directory.Exists(relativeToExecutable))
            {
                return relativeToExecutable;
            }

            // last attempt to get directory relative to the working directory
            var relativeToWorkingDirectory = Path.GetFullPath(pluginSettingsFolder);

            if (Directory.Exists(relativeToWorkingDirectory))
            {
                return relativeToWorkingDirectory;
            }

            return pluginSettingsFolder;
        }

        private static void LoadAssemblyFile(FileInfo assemblyFilesToLoad)
        {
            _logger.Debug($"{assemblyFilesToLoad.Name}");

            try
            {
                Assembly.LoadFrom(assemblyFilesToLoad.FullName);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to load assembly {assemblyFilesToLoad.FullName}", ex);
                throw;
            }
        }

        private static string GetDefaultDirectoryIfNotProvided(string directory)
        {
            return string.IsNullOrEmpty(directory)
                ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty
                : directory;
        }

        private static void LoadReferencedAssembly(Assembly assembly, IDictionary<string, bool> loaded,
            bool includeFramework = false)
        {
            // Check all referenced assemblies of the specified assembly
            foreach (var referencedAssembliesToLoad in assembly.GetReferencedAssemblies()
                         .Where(a => ShouldLoad(a.FullName, loaded, includeFramework)))
            {
                // Load the assembly and load its dependencies
                LoadReferencedAssembly(
                    Assembly.Load(referencedAssembliesToLoad), loaded, includeFramework); // AppDomain.CurrentDomain.Load(name)

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
                   // Needed by System.Data.SqlClient, which is used by Entity Framework
                   && assemblyName != "sni.dll";
        }

        public static IEnumerable<string> FindPluginAssemblies(string pluginFolder, bool includeFramework = false,
            bool includeExtensionAssemblies = true)
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

            // Only process extension ApiModel metadata files if the includeExtensions flag is set
            var apiModelFiles = includeExtensionAssemblies
                ? Directory.GetFiles(pluginFolder, "ApiModel-EXTENSION.json", SearchOption.AllDirectories)
                : new string[] { };

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
            var duplicateExtensionPlugins = physicalNames.ToLookup(x => x.Key).Where(x => x.Count() > 1);

            foreach (var duplicateExtensionPlugin in duplicateExtensionPlugins)
            {
                isDuplicate = true;
                var pluginFolders = duplicateExtensionPlugin.Select(s => s.Value);

                _logger.Error(
                    $"found duplicate extension schema name '{duplicateExtensionPlugin.Key}' in plugin folder." +
                    $" You will be able to deploy only one of the following plugins '{string.Join("' and '", pluginFolders)}' folder name." +
                    $" Please remove the conflicting plugins and retry");
            }

            if (isDuplicate)
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

                    if (!HasPluginMarker(assembly))
                    {
                        continue;
                    }

                    string assemblyDirectory = Path.GetDirectoryName(assemblyPath);

                    if (TryReadAssemblyMetadata(assembly, out var assemblyMetadata))
                    {
                        if (IsExtensionAssembly(assemblyMetadata))
                        {
                            if (!includeExtensionAssemblies)
                            {
                                _logger.Info($"Excluding extension assembly '{assembly.GetName().Name}'.");
                                continue;
                            }

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
                    else
                    {
                        yield return assembly.Location;
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

            static bool HasPluginMarker(Assembly assembly)
            {
                return assembly.GetTypes().Any(
                    t => t.GetInterfaces()
                        .Any(
                            i =>
                                i.AssemblyQualifiedName == typeof(IPluginMarker).AssemblyQualifiedName));
            }
        }

        private static bool IsExtensionAssembly(AssemblyMetadata assemblyMetadata)
        {
            return assemblyMetadata.AssemblyModelType.EqualsIgnoreCase(PluginConventions.Extension);
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

            assemblyMetadata = JsonConvert.DeserializeObject<AssemblyMetadata>(
                jsonFile,
                new JsonSerializerSettings
                {
                    Error = (sender, args) => throw new Exception(
                        $"Unable to deserialize '{typeof(AssemblyMetadata)}' from embedded resource '{resourceName}'.")
                });

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
