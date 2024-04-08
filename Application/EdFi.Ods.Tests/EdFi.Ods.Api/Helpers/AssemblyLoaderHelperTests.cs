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
        private string _unitTestNormalPluginFolder = "UnitTestPlugins";

        // Contains the default plugin assemblies and a non-plugin assembly
        private string _unitTestPluginWithNonPluginAssemblyFolder = "UnitTestPluginsWithNonPluginAssembly";

        // Contains the default plugin assemblies and an invalid plugin assembly.
        // The invalid plugin implements IPluginMarker, but does not have any additional
        // content which is needed make it a valid plugin assembly.
        private string _unitTestInvalidPluginFolder = "UnitTestPluginsWithInvalidAssembly";

        // Folder that remains empty
        private string _unitTestEmptyPluginFolder = "UnitTestPluginsEmpty";

        private Dictionary<string, string> EmbeddedReaourcePlugins = new Dictionary<string, string>()
        {
            { "Profiles.Sample", "Profiles" },
            { "Extensions.Sample", "Extension" },
        };

        private string[] _nonEmptyUnitTestPluginFolders;

        private string _temporaryDirectory;

        [OneTimeSetUp]
        public void Setup()
        {
            _temporaryDirectory = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())).FullName;

            _unitTestNormalPluginFolder = Path.Combine(_temporaryDirectory, _unitTestNormalPluginFolder);
            _unitTestEmptyPluginFolder = Path.Combine(_temporaryDirectory, _unitTestEmptyPluginFolder);
            _unitTestInvalidPluginFolder = Path.Combine(_temporaryDirectory, _unitTestInvalidPluginFolder);

            _unitTestPluginWithNonPluginAssemblyFolder = Path.Combine(
                _temporaryDirectory, _unitTestPluginWithNonPluginAssemblyFolder);

            _nonEmptyUnitTestPluginFolders = new[]
            {
                _unitTestNormalPluginFolder,
                _unitTestPluginWithNonPluginAssemblyFolder,
                _unitTestInvalidPluginFolder
            };

            foreach (var folder in _nonEmptyUnitTestPluginFolders)
            {
                Directory.CreateDirectory(folder);

                foreach (var plugin in EmbeddedReaourcePlugins)
                {
                    Directory.CreateDirectory(Path.Combine(folder, plugin.Key));

                    if (plugin.Value == "Extension")
                    {
                        Directory.CreateDirectory(Path.Combine(folder, plugin.Key, "Artifacts"));
                        Directory.CreateDirectory(Path.Combine(folder, plugin.Key, "Artifacts", "Metadata"));

                        using (var fileStream = File.Create(
                                   Path.Combine(folder, plugin.Key, "Artifacts", "Metadata", "ApiModel-EXTENSION.json")))
                        {
                            Assembly.GetExecutingAssembly()
                                .GetManifestResourceStream($"EdFi.Ods.Tests._EmbeddedResources.{plugin.Key}-ApiModel-EXTENSION-For-Tests.json")!
                                .CopyTo(fileStream);
                        }
                    }

                    using (var fileStream = File.Create(Path.Combine(folder, plugin.Key, $"EdFi.Ods.{plugin.Key}.dll")))
                    {
                        Assembly.GetExecutingAssembly()
                            .GetManifestResourceStream($"EdFi.Ods.Tests._EmbeddedResources.EdFi.Ods.{plugin.Key}.dll")!
                            .CopyTo(fileStream);
                    }
                }
            }

            // Create a folder with an invalid plugin assembly
            Directory.CreateDirectory(Path.Combine(_unitTestInvalidPluginFolder, "Profiles.InvalidPluginAssembly"));
            Directory.CreateDirectory(Path.Combine(_unitTestInvalidPluginFolder, "Profiles.InvalidPluginAssembly", "Artifacts"));
            Directory.CreateDirectory(Path.Combine(_unitTestInvalidPluginFolder, "Profiles.InvalidPluginAssembly", "Artifacts", "Metadata"));

            using (var fileStream = File.Create(Path.Combine(_unitTestInvalidPluginFolder, InvalidPluginAssemblyFileName)))
            {
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream($"EdFi.Ods.Tests._EmbeddedResources.{InvalidPluginAssemblyFileName}")!
                    .CopyTo(fileStream);
            }

            // Copy a non-plugin dll into the folder to ensure that the method does not return it
            File.Copy(
                NonPluginAssemblyFileName, Path.Combine(_unitTestPluginWithNonPluginAssemblyFolder, NonPluginAssemblyFileName),
                true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Delete the folders and files created for the tests
            if (Directory.Exists(_temporaryDirectory))
            {
                Directory.Delete(_temporaryDirectory, true);
            }
        }

        [Test]
        public void Should_return_all_plugin_assemblies_from_plugin_folder()
        {
            // Arrange

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(_unitTestNormalPluginFolder);

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
            var returnedAssemblies = AssemblyLoaderHelper.FindPluginAssemblies(
                    _unitTestNormalPluginFolder, includeExtensionAssemblies: false)
                .Select(Path.GetFileName).ToArray();

            // Assert
            FileExistsInDirectory("EdFi.Ods.Extensions.Sample.dll", Path.Combine(_unitTestNormalPluginFolder, "Extensions.Sample"), true)
                .ShouldBeTrue();
            returnedAssemblies.ShouldBeEquivalentTo(new[] { "EdFi.Ods.Profiles.Sample.dll" });
        }

        [Test]
        public void Should_not_include_non_plugin_assemblies_located_in_plugin_folder()
        {
            // Arrange

            // Act
            var returnedAssemblies = AssemblyLoaderHelper.FindPluginAssemblies(_unitTestPluginWithNonPluginAssemblyFolder)
                .Select(Path.GetFileName).ToArray();

            // Assert
            File.Exists(Path.Combine(_unitTestPluginWithNonPluginAssemblyFolder, NonPluginAssemblyFileName)).ShouldBeTrue();

            returnedAssemblies.ShouldBeEquivalentTo(
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
            var result = AssemblyLoaderHelper.FindPluginAssemblies(_unitTestEmptyPluginFolder);

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
            Should.Throw<Exception>(() => AssemblyLoaderHelper.FindPluginAssemblies(_unitTestInvalidPluginFolder).ToList())
                .Message
                .ShouldBe("No plugin artifacts were found in assembly 'InvalidPluginAssembly.dll'. Expected an IPluginMarker implementation and assembly metadata embedded resource 'assemblyMetadata.json' (for Profiles or Extensions plugins), or implementations of IPlugin and/or IPlugModule (for custom application plugins).");
        }

        // This method uses parts of the example code found at the following link
        // https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
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
