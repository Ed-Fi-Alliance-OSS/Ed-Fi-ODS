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
using EdFi.LoadTools.BulkLoadClient.Application;
using log4net;

namespace EdFi.LoadTools.ApiClient.XsdMetadata
{
    public class XsdFilesRetriever : IXsdFilesRetriever, IDisposable
    {
        private const string EdFi = "ed-fi";
        private readonly BulkLoadClientConfiguration _configuration;
        private readonly string _extension;
        private readonly HttpClient _httpClient;
        private readonly ILog _logger = LogManager.GetLogger(typeof(XsdFilesRetriever));
        private readonly OdsVersionInformation _odsVersionInformation;
        private readonly IRemoteFileDownloader _remoteFileDownloader;
        private readonly string _xsdMedataUrl;
        private readonly IXsdMetadataFilesProvider _xsdMetadataFilesProvider;
        private readonly IXsdMetadataInformationProvider _xsdMetadataInformationProvider;
        private readonly string _xsdFolder;
        private readonly string _workingFolder;

        public XsdFilesRetriever(BulkLoadClientConfiguration configuration,
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

            _xsdMedataUrl = _configuration.XsdMetadataUrl;
            _extension = _configuration.Extension;
            _xsdFolder = Path.GetFullPath(_configuration.XsdFolder);
            _workingFolder = Path.GetFullPath(_configuration.WorkingFolder);

            ValidateXsdFolder();

            void ValidateXsdFolder()
            {
                // create the xsd folder if it does not exists so that the dependencies work.
                if (!Directory.Exists(_xsdFolder))
                {
                    Directory.CreateDirectory(_xsdFolder);
                }
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public async Task DownloadXsdFilesAsync()
        {
            if (string.IsNullOrEmpty(_xsdMedataUrl))
            {
                return;
            }

            var xsdFiles = Directory.GetFiles(_xsdFolder, "*.xsd");

            if (xsdFiles.Any() && !_configuration.ForceMetadata)
            {
                _logger.Info($"Xsd files found at '{_xsdFolder}', skipping download. Provide the '--force' parameter to download files.");
                return;
            }

            if (_configuration.ForceMetadata)
            {
                _logger.Info($"Removing existing xsd files from '{_xsdFolder}'");
                foreach (string file in xsdFiles)
                {
                    File.Delete(file);
                }
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
                    throw new FileNotFoundException(
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

                // if no extension is installed then we want to return core by default
                if (xsdMetadataInformations.Count == 1)
                {
                    return matchingXsdMetadataInformations.Single();
                }

                // if only one extension is available and not defined in the config, we return the extension xsd information
                // otherwise we return the extension information that was defined in the configuration
                return string.IsNullOrEmpty(_extension) && matchingXsdMetadataInformations.Count == 2
                    ? matchingXsdMetadataInformations.Single(x => !x.Name.EqualsIgnoreCase(EdFi))
                    : matchingXsdMetadataInformations.Single(x => x.Name.EqualsIgnoreCase(_extension));
            }

            void ValidExtensionSupport(List<XsdMetadataInformation> xsdMetadataInformations)
            {
                if (xsdMetadataInformations.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("XsdMetadataUrl", "Unable to find xsd file information.");
                }

                if ((xsdMetadataInformations.Count > 2 && string.IsNullOrEmpty(_extension)) ||
                    (xsdMetadataInformations.Count > 2 && !xsdMetadataInformations.Any(y => y.Name.EqualsIgnoreCase(_extension))))
                {
                    var availableExtensions = xsdMetadataInformations
                        .Select(x => x.Name)
                        .Where(x => !x.EqualsIgnoreCase(EdFi));

                    throw new ArgumentOutOfRangeException(
                        "Extension",
                        $"Must declare a specific extension. Available extensions: '{string.Join("', '", availableExtensions)}'");
                }
            }
        }
    }
}
