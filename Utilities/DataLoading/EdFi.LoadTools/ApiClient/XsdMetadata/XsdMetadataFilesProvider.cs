// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using Newtonsoft.Json;

namespace EdFi.LoadTools.ApiClient.XsdMetadata
{
    public class XsdMetadataFilesProvider : IXsdMetadataFilesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(XsdMetadataFilesProvider));

        public async Task<List<XsdMetadataFileInformation>> GetXsdFilesAsync(HttpClient httpClient, string xsdFilesUrl)
        {
            _logger.Info($"Downloading xsd file list from '{xsdFilesUrl}'");

            var response = await httpClient.GetAsync(xsdFilesUrl).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var xsdFiles = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return CreateXsdFileInformation().ToList();

            IEnumerable<XsdMetadataFileInformation> CreateXsdFileInformation()
            {
                foreach (string xsdFile in xsdFiles)
                {
                    string fileName = xsdFile.Split('/').LastOrDefault();

                    if (string.IsNullOrEmpty(fileName))
                    {
                        yield break;
                    }

                    yield return new XsdMetadataFileInformation
                    {
                        Url = xsdFile,
                        FileName = fileName
                    };
                }
            }
        }
    }
}
