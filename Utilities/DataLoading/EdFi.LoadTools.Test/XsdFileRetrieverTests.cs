// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.ApiClient.XsdMetadata;
using EdFi.LoadTools.BulkLoadClient.Application;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;

namespace EdFi.LoadTools.Test
{
    [TestFixture]
    public class XsdFileRetrieverTests
    {
        private BulkLoadClientConfiguration _configuration;
        private string _workingFolder;
        private string _xsdFolder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _workingFolder = TestContext.CurrentContext.WorkDirectory;
            _xsdFolder = Path.Combine(_workingFolder, "xsd");

            configRoot["Folders:Working"] = _workingFolder;
            configRoot["Folders:Xsd"] = _xsdFolder;

            _configuration = BulkLoadClientConfiguration.Create(configRoot);

            if (Directory.Exists(_xsdFolder))
            {
                Directory.Delete(_xsdFolder, true);
            }
        }

        [Test]
        [Category("RunManually")]
        public async Task Should_get_xsd_metadata_information_and_download_files()
        {
            var odsVersionInformation = new OdsVersionInformation
            {
                DataModels = new List<Dictionary<string, string>>
                {
                    new Dictionary<string, string>
                    {
                        {"name", "Ed-Fi"},
                        {"version", "3.3.1-b"}
                    },
                    new Dictionary<string, string>
                    {
                        {"name", "TPDM"},
                        {"version", "1.1.0"}
                    }
                }
            };

            using var sut = new XsdFilesRetriever(
                _configuration,
                new XsdMetadataInformationProvider(),
                new XsdMetadataFilesProvider(),
                new RemoteFileDownloader(),
                odsVersionInformation);

            sut.ShouldNotBeNull();

            await sut.DownloadXsdFilesAsync();

            Directory.Exists(_xsdFolder).ShouldBeTrue();

            string[] files = Directory.GetFiles(_xsdFolder);
            files.Length.ShouldNotBe(0);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                fileInfo.Exists.ShouldBe(true);

                // validate we actually wrote the contents of the file
                fileInfo.Length.ShouldBeGreaterThan(0);
            }
        }
    }
}
