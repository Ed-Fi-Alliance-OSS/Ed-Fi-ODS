// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Helpers;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Helpers;

[TestFixture]
public class AssemblyLoaderHelperTests
{
    // Write tests for the FindPluginAssemblies method
    [TestFixture]
    public class When_finding_plugin_assemblies
    {
        private const string InvalidPluginAssemblyFileName = "InvalidPluginAssembly.dll";
        private const string NonPluginAssemblyFileName = "EdFi.Ods.Tests.dll";

        // Contains the default plugin assemblies
        private const string UnitTestPluginFolder = "UnitTestPlugins";

        // Contains the default plugin assemblies and a non-plugin assembly
        private const string UnitTestPluginWithNonPluginAssemblyFolder = "UnitTestPluginsWithNonPluginAssembly";

        // Contains the default plugin assemblies and an invalid plugin assembly.
        // The invalid plugin implements IPluginMarker, but does not have any additional
        // content which is needed make it a valid plugin assembly.
        private const string UnitTestInvalidPluginFolder = "UnitTestPluginsWithInvalidAssembly";

        // Folder that remains empty
        private const string UnitTestEmptyPluginFolder = "UnitTestPluginsEmpty";

        private Dictionary<string, string> EmbeddedReaourcePlugins = new Dictionary<string, string>()
        {
            { "Profiles.Sample", "Profiles" },
            { "Extensions.Sample", "Extension" },
        };

        private string[] UnitTestPluginFolders = new[]
        {
            UnitTestPluginFolder,
            UnitTestPluginWithNonPluginAssemblyFolder,
            UnitTestInvalidPluginFolder
        };

        [OneTimeSetUp]
        public void Setup()
        {
            foreach (var folder in UnitTestPluginFolders)
            {
                Directory.CreateDirectory(folder);
                Directory.CreateDirectory(Path.Combine(folder, "Extension"));

                foreach (var plugin in EmbeddedReaourcePlugins)
                {
                    Directory.CreateDirectory(Path.Combine(folder, plugin.Key));

                    if (plugin.Value == "Extension")
                    {
                        Directory.CreateDirectory(Path.Combine(folder, plugin.Key, "Artifacts\\Metadata"));

                        using (var fileStream = File.Create(
                                   Path.Combine(folder, plugin.Key, "Artifacts\\Metadata\\ApiModel-EXTENSION.json")))
                        {
                            Assembly.GetExecutingAssembly()
                                .GetManifestResourceStream(
                                    $"EdFi.Ods.Tests._EmbeddedResources.{plugin.Key}-ApiModel-EXTENSION-For-Tests.json")!
                                .CopyTo(fileStream);
                        }
                    }

                    using (var fileStream = File.Create(Path.Combine(folder, $"{plugin.Key}\\EdFi.Ods.{plugin.Key}.dll")))
                    {
                        Assembly.GetExecutingAssembly()
                            .GetManifestResourceStream($"EdFi.Ods.Tests._EmbeddedResources.EdFi.Ods.{plugin.Key}.dll")!
                            .CopyTo(fileStream);
                    }
                }
            }

            using (var fileStream = File.Create(Path.Combine(UnitTestInvalidPluginFolder, InvalidPluginAssemblyFileName)))
            {
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream($"EdFi.Ods.Tests._EmbeddedResources.{InvalidPluginAssemblyFileName}")!
                    .CopyTo(fileStream);
            }

            // Copy a non-plugin dll into the folder to ensure that the method does not return it
            File.Copy(
                NonPluginAssemblyFileName, Path.Combine(UnitTestPluginWithNonPluginAssemblyFolder, NonPluginAssemblyFileName),
                true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Delete the folders created for the tests
            foreach (var folder in UnitTestPluginFolders)
            {
                if (Directory.Exists(folder))
                {
                    Directory.Delete(folder, true);
                }
            }
        }

        [Test]
        public void Should_return_all_plugin_assemblies_from_plugin_folder()
        {
            // Arrange

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(UnitTestPluginFolder);

            // Assert
            result.Select(s => s.Split("\\").Last()).ToArray()
                .ShouldBeEquivalentTo(
                    new[]
                    {
                        "EdFi.Ods.Extensions.Sample.dll",
                        "EdFi.Ods.Profiles.Sample.dll"
                    });
        }

        [Test]
        public void Should_return_only_non_extension_assemblies_when_extension_assemblies_are_excluded()
        {
            // Arrange

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(UnitTestPluginFolder, includeExtensionAssemblies: false);

            // Assert
            FileExistsInDirectory("EdFi.Ods.Extensions.Sample.dll", UnitTestPluginFolder, true).ShouldBeTrue();

            result.Select(s => s.Split("\\").Last()).ToArray()
                .ShouldBeEquivalentTo(new[] { "EdFi.Ods.Profiles.Sample.dll" });
        }

        [Test]
        public void Should_not_include_non_plugin_assemblies_located_in_plugin_folder()
        {
            // Arrange

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(UnitTestPluginFolder);

            // Assert
            File.Exists(Path.Combine(UnitTestPluginWithNonPluginAssemblyFolder, NonPluginAssemblyFileName)).ShouldBeTrue();

            result.Select(s => s.Split("\\").Last()).ToArray()
                .ShouldBeEquivalentTo(
                    new[]
                    {
                        "EdFi.Ods.Extensions.Sample.dll",
                        "EdFi.Ods.Profiles.Sample.dll"
                    });
        }

        [Test]
        public void Should_return_empty_list_when_no_plugin_assemblies_found()
        {
            // Arrange

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(UnitTestEmptyPluginFolder);

            // Assert
            result.ShouldBeEmpty();
        }

        [Test]
        public void Should_return_empty_list_when_plugin_folder_does_not_exist()
        {
            // Arrange
            var nonExistentPluginFolder = "ThisPluginFolderDoesNotExist";

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(nonExistentPluginFolder);

            // Assert
            result.ShouldBeEmpty();
        }

        [Test]
        public void Should_return_empty_list_when_plugin_folder_name_is_null()
        {
            // Arrange
            string pluginFolder = null;

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(pluginFolder);

            // Assert
            result.ShouldBeEmpty();
        }

        [Test]
        public void Should_return_empty_list_when_plugin_folder_name_is_whitespace()
        {
            // Arrange
            string pluginFolder = "   ";

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(pluginFolder);

            // Assert
            result.ShouldBeEmpty();
        }

        [Test]
        public void Should_return_empty_list_when_plugin_folder_name_is_empty()
        {
            // Arrange
            string pluginFolder = "";

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(pluginFolder);

            // Assert
            result.ShouldBeEmpty();
        }

        [Test]
        public void Should_throw_exception_when_an_invalid_plugin_assembly_is_in_plugin_folder()
        {
            // Arrange

            // Act & Assert
            Should.Throw<Exception>(() => AssemblyLoaderHelper.FindPluginAssemblies(UnitTestInvalidPluginFolder).ToList()).Message
                .ShouldBe(
                    "No plugin artifacts were found in assembly 'InvalidPluginAssembly.dll'. Expected an IPluginMarker implementation and assembly metadata embedded resource 'assemblyMetadata.json' (for Profiles or Extensions plugins), or implementations of IPlugin and/or IPlugModule (for custom application plugins).");
        }

        // This method is from https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        // With some modifications
        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive, bool overwrite)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, overwrite);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true, overwrite);
                }
            }
        }

        private static bool FileExistsInDirectory(string fileName, string directory, bool recursive)
        {
            // Get information about the directory
            var dir = new DirectoryInfo(directory);

            // Check if the directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Directory not found: {dir.FullName}");

            // Cache directories
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Get the files in the directory
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    if (FileExistsInDirectory(fileName, subDir.FullName, true))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
