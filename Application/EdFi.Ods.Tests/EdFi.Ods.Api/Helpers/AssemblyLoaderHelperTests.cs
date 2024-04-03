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
        private const string OriginalPluginFolder = "../../../../../../Ed-Fi-Ods-Implementation/Plugin";
        private const string InvalidPluginAssemblyFileName = "InvalidPluginAssembly.dll";

        // Contains the default plugin assemblies that are copied from the original plugin folder
        private const string UnitTestPluginFolder = "UnitTestPlugins";

        // Contains the default plugin assemblies that are copied from the original plugin folder
        // and a non-plugin assembly that is a copy of the currently executing assembly dll
        private const string UnitTestPluginWithNonPluginAssemblyFolder = "UnitTestPluginsWithNonPluginAssembly";

        // Contains the default plugin assemblies that are copied from the original plugin folder
        // and an invalid plugin assembly that is copied from the embedded resources
        private const string UnitTestInvalidPluginFolder = "UnitTestPluginsWithInvalidAssembly";

        // Folder that remains empty
        private const string UnitTestEmptyPluginFolder = "UnitTestPluginsEmpty";

        private readonly string _nonPluginAssemblyFileName;
        private readonly string _nonPluginAssemblyLocation;

        public When_finding_plugin_assemblies()
        {
            _nonPluginAssemblyLocation = Assembly.GetCallingAssembly().Location;
            _nonPluginAssemblyFileName = Path.GetFileName(_nonPluginAssemblyLocation);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            Directory.CreateDirectory(UnitTestPluginFolder);
            Directory.CreateDirectory(UnitTestEmptyPluginFolder);
            Directory.CreateDirectory(UnitTestPluginWithNonPluginAssemblyFolder);
            Directory.CreateDirectory(UnitTestInvalidPluginFolder);

            // Save the InvalidPluginAssembly.dll EmbeddedResource as a file in the UnitTestInvalidPlugins Folder
            using (var fileStream = File.Create(Path.Combine(UnitTestInvalidPluginFolder, InvalidPluginAssemblyFileName)))
            {
                Assembly.GetExecutingAssembly().GetManifestResourceStream("EdFi.Ods.Tests._EmbeddedResources.InvalidPluginAssembly.dll")!.CopyTo(fileStream);
            }


            // Copy a non-plugin dll into the folder to ensure that the method does not return it
            File.Copy(_nonPluginAssemblyLocation ?? "", Path.Combine(UnitTestPluginWithNonPluginAssemblyFolder, _nonPluginAssemblyFileName), true);


            CopyDirectory(OriginalPluginFolder, UnitTestPluginFolder, true, true);
            CopyDirectory(OriginalPluginFolder, UnitTestPluginWithNonPluginAssemblyFolder, true, true);
            CopyDirectory(OriginalPluginFolder, UnitTestInvalidPluginFolder, true, true);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var foldersToDelete = new List<string>
            {
                UnitTestPluginFolder,
                UnitTestEmptyPluginFolder,
                UnitTestPluginWithNonPluginAssemblyFolder,
                UnitTestInvalidPluginFolder
            };

            // Delete the folders created for the tests
            foreach (var folder in foldersToDelete)
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
            result.Select(s => s.Split("\\").Last()).ToList()
                .ShouldBeEquivalentTo(new List<string>
                {
                "EdFi.Ods.Profiles.Sample.dll",
                "EdFi.Ods.Extensions.Homograph.dll",
                "EdFi.Ods.Extensions.Sample.dll",
                "EdFi.Ods.Extensions.TPDM.dll",
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

            result.Select(s => s.Split("\\").Last()).ToList()
                .ShouldBeEquivalentTo(new List<string>
                {
                    "EdFi.Ods.Profiles.Sample.dll"
                });
        }

        [Test]
        public void Should_not_include_non_plugin_assemblies_located_in_plugin_folder()
        {
            // Arrange

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(UnitTestPluginFolder);

            // Assert
            File.Exists(Path.Combine(UnitTestPluginWithNonPluginAssemblyFolder, _nonPluginAssemblyFileName)).ShouldBeTrue();

            result.Select(s => s.Split("\\").Last()).ToList()
                .ShouldBeEquivalentTo(new List<string>
                {
                    "EdFi.Ods.Profiles.Sample.dll",
                    "EdFi.Ods.Extensions.Homograph.dll",
                    "EdFi.Ods.Extensions.Sample.dll",
                    "EdFi.Ods.Extensions.TPDM.dll",
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
            Should.Throw<Exception>(() => AssemblyLoaderHelper.FindPluginAssemblies(UnitTestInvalidPluginFolder).ToList()).Message.ShouldBe("No plugin artifacts were found in assembly 'InvalidPluginAssembly.dll'. Expected an IPluginMarker implementation and assembly metadata embedded resource 'assemblyMetadata.json' (for Profiles or Extensions plugins), or implementations of IPlugin and/or IPlugModule (for custom application plugins).");
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
            // Get information about the source directory
            var dir = new DirectoryInfo(directory);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            // If recursive and copying subdirectories, recursively call this method
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
