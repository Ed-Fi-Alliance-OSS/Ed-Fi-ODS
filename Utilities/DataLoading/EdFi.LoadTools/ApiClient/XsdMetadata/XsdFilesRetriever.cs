// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using log4net;
using Microsoft.Extensions.Configuration;

namespace EdFi.LoadTools.ApiClient.XsdMetadata
{
    public class XsdFilesRetriever : IXsdFilesRetriever, IDisposable
    {
        private const string EdFi = "ed-fi";
        private readonly IConfiguration _configuration;
        private readonly string _extension;
        private readonly HttpClient _httpClient;
        private readonly ILog _logger = LogManager.GetLogger(typeof(XsdFilesRetriever));
        private readonly OdsVersionInformation _odsVersionInformation;
        private readonly IRemoteFileDownloader _remoteFileDownloader;
        private readonly string _xsdMedataUrl;
        private readonly IXsdMetadataFilesProvider _xsdMetadataFilesProvider;
        private readonly IXsdMetadataInformationProvider _xsdMetadataInformationProvider;
        private string _xsdFolder;

        public XsdFilesRetriever(IConfiguration configuration,
            IXsdMetadataInformationProvider xsdMetadataInformationProvider,
            IXsdMetadataFilesProvider xsdMetadataFilesProvider,
            IRemoteFileDownloader remoteFileDownloader,
            OdsVersionInformation odsVersionInformation)
        {
            _configuration = configuration;
            _xsdMetadataInformationProvider = xsdMetadataInformationProvider;
            _xsdMetadataFilesProvider = xsdMetadataFilesProvider;
            _remoteFileDownloader = remoteFileDownloader;
            _odsVersionInformation = odsVersionInformation;
            _httpClient = new HttpClient {Timeout = new TimeSpan(0, 0, 5, 0)};

            _xsdMedataUrl = _configuration.GetValue<string>("OdsApi:XsdMetadataUrl");
            _extension = _configuration.GetValue<string>("OdsApi:Extension");

            SetXsdFolder();

            void SetXsdFolder()
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string workingFolder = string.IsNullOrEmpty(_configuration.GetValue<string>("Folders:Working"))
                    ? currentDirectory
                    : Path.GetFullPath(_configuration.GetValue<string>("Folders:Working"));

                _xsdFolder = string.IsNullOrEmpty(_configuration.GetValue<string>("Folders:Xsd"))
                    ? Path.Combine(workingFolder, "xsd")
                    : Path.GetFullPath(_configuration.GetValue<string>("Folders:Xsd"));

                // create the xsd folder if it does not exists so that the dependencies work.
                if (!Directory.Exists(_xsdFolder))
                {
                    Directory.CreateDirectory(_xsdFolder);
                }

                // clean the folder if the force flag is set.
                if (!configuration.GetValue<bool>("ForceMetadata"))
                {
                    return;
                }

                foreach (string file in Directory.GetFiles(_xsdFolder))
                {
                    File.Delete(file);
                }
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public async Task DownloadXsdFilesAsync()
        {
            // do nothing if there is no endpoint
            if (string.IsNullOrEmpty(_xsdMedataUrl))
            {
                return;
            }

            var xsdMetadataInformation = await GetXsdMetadataInformationAsync();

            _logger.Debug($"Processing xsd files for '{xsdMetadataInformation.Name}'");

            var xsdFileInformations = await _xsdMetadataFilesProvider.GetXsdFilesAsync(_httpClient, xsdMetadataInformation.Files)
                .ConfigureAwait(false);

            foreach (var xsdFileInformation in xsdFileInformations)
            {
                string destinationFullPath = Path.Combine(_xsdFolder, xsdFileInformation.FileName);

                _logger.Info($"Downloading file '{xsdFileInformation.FileName}' to '{_xsdFolder}");

                var fileDownloadResult = await _remoteFileDownloader.DownloadAsync(
                    _httpClient, xsdFileInformation.Url, destinationFullPath);

                if (!fileDownloadResult.IsSuccessful)
                {
                    _logger.Info($"unable to download file '{fileDownloadResult.FullName}'");

                    _logger.Warn(
                        $"Error message while processing '{fileDownloadResult.FullName}' is '{fileDownloadResult.ErrorMessage}'");
                }
            }

            async Task<XsdMetadataInformation> GetXsdMetadataInformationAsync()
            {
                _logger.Info($"Get all xsd file information from '{_xsdMedataUrl}'");

                var xsdMetadataInformations = await _xsdMetadataInformationProvider
                    .GetXsdMetadataInformationAsync(_httpClient, _xsdMedataUrl)
                    .ConfigureAwait(false);

                ValidExtensionSupport(xsdMetadataInformations);

                var installedDataModels = _odsVersionInformation.DataModels
                    .Select(y => y["name"].ToLowerInvariant())
                    .ToList();

                var matchingXsdMetadataInformations = xsdMetadataInformations
                    .Where(x => installedDataModels.Any(y => y.EqualsIgnoreCase(x.Name)))
                    .ToList();

                // if an extension is installed then we want to return that information by default
                if (xsdMetadataInformations.Count == 1)
                {
                    return matchingXsdMetadataInformations.Single();
                }

                // if an extension is available and not defined in the config, we return the extension xsd information
                // otherwise we return the extension information that was defined in the configuration

                return string.IsNullOrEmpty(_extension) && matchingXsdMetadataInformations.Count == 2
                    ? matchingXsdMetadataInformations.Single(x => !x.Name.EqualsIgnoreCase(EdFi))
                    : matchingXsdMetadataInformations.Single(
                        x => x.Name.EqualsIgnoreCase(_extension));
            }

            void ValidExtensionSupport(List<XsdMetadataInformation> xsdMetadataInformations)
            {
                if (xsdMetadataInformations.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("XsdMetadataUrl", "Unable to find xsd file information.");
                }

                if (xsdMetadataInformations.Count > 2 && string.IsNullOrEmpty(_extension))
                {
                    throw new ArgumentOutOfRangeException(
                        "Extension", "Multiple extensions exists without declaring the extension to use.");
                }
            }
        }
    }
}
