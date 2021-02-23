// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;

namespace EdFi.LoadTools.ApiClient
{
    public class RemoteFileDownloader : IRemoteFileDownloader
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(RemoteFileDownloader));

        public async Task<RemoteFileDownloadResult> DownloadAsync(HttpClient httpClient, string fileUrl, string destinationFullPath)
        {
            try
            {
                _logger.Debug($"Downloading file '{fileUrl}'");
                var response = await httpClient.GetAsync(fileUrl).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStreamAsync();

                _logger.Debug($"Writing file to '{destinationFullPath}'");
                await using var streamWriter = new StreamWriter(destinationFullPath, false);

                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                await streamWriter.WriteAsync(content).ConfigureAwait(false);

                return new RemoteFileDownloadResult
                {
                    FullName = fileUrl,
                    IsSuccessful = true
                };
            }
            catch (Exception e)
            {
                _logger.Warn(e);

                return new RemoteFileDownloadResult
                {
                    FullName = destinationFullPath,
                    IsSuccessful = false,
                    ErrorMessage = e.ToString()
                };
            }
        }
    }
}
