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

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Utilities;

[TestFixture]
public class AssemblyLoaderHelperTests
{
    // Write tests for the FindPluginAssemblies method
    [TestFixture]
    public class When_finding_plugin_assemblies
    {
        private const string UnitTestPluginFolder = "UnitTestPluginFolder";
        private const string EmptyUnitTestPluginFolder = "UnitTestEmptyPlugins";

        [OneTimeSetUp]
        public void Setup()
        {
            Directory.CreateDirectory(UnitTestPluginFolder);
            Directory.CreateDirectory(EmptyUnitTestPluginFolder);

            var originalPluginFolder = "../../../../../../Ed-Fi-Ods-Implementation/Plugin";
            CopyDirectory(originalPluginFolder, UnitTestPluginFolder, true, true);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(UnitTestPluginFolder))
            {
                Directory.Delete(UnitTestPluginFolder, true);
            }

            if (Directory.Exists(EmptyUnitTestPluginFolder))
            {
                Directory.Delete(EmptyUnitTestPluginFolder, true);
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
            var nonPluginAssemblyLocation = Assembly.GetCallingAssembly().Location;
            var nonPluginAssemblyFileName = Path.GetFileName(nonPluginAssemblyLocation);

            // Copy a non-plugin dll into the folder to ensure that the method does not return it
            File.Copy(nonPluginAssemblyLocation, Path.Combine(UnitTestPluginFolder, nonPluginAssemblyFileName), true);

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(UnitTestPluginFolder);

            // Assert
            Assert.That(File.Exists(Path.Combine(UnitTestPluginFolder, nonPluginAssemblyFileName)));

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
            var result = AssemblyLoaderHelper.FindPluginAssemblies(EmptyUnitTestPluginFolder);

            // Assert
            result.ShouldBeEmpty();
        }

        [Test]
        public void Should_return_empty_list_when_plugin_folder_does_not_exist()
        {
            // Arrange
            var nonExistantPluginFolder = "ThisPluginFolderDoesNotExist";

            // Act
            var result = AssemblyLoaderHelper.FindPluginAssemblies(nonExistantPluginFolder);

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
    }
}
