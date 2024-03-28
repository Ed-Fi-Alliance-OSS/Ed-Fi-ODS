// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using log4net;

namespace EdFi.SdkGen.Console
{
    public class OpenApiCodgenCliUpdater
    {
        private const int BufferSize = 4096;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Options _options;

        public OpenApiCodgenCliUpdater(Options options)
        {
            _options = options;
        }

        public void Run()
        {
            if (!ShouldUpdate())
            {
                return;
            }

            // run the task synchronously to avoid collitions to get the jar file.
            DownloadOpenApiCodegenCli().Wait();
        }

        private bool ShouldUpdate()
        {
            _log.Info("Checking if the openapi-codegen-cli is valid");

            if (_options.Force)
            {
                _log.Info($"Force updating {_options.CliExecutableFullName()} to the specific version {_options.CliVersion}.");
                return true;
            }

            if (!File.Exists(_options.CliExecutableFullName()))
            {
                _log.Debug($"{_options.CliExecutableFullName()} does not exist.");
                return true;
            }

            return false;
        }

        private async Task DownloadOpenApiCodegenCli()
        {
            _log.Info($"Downloading a new copy of the {_options.CliExecutableFullName()}");

            using (var httpClient = new HttpClient())
            {
                var downloadUrl = _options.CliDownloadUrl();

                _log.Debug($"Downloading openApi-codegen-cli.jar from {downloadUrl}");

                using (HttpResponseMessage response = await httpClient.GetAsync(downloadUrl))
                {
                    response.EnsureSuccessStatusCode();

                    // save to a temporary file before moving to the final file.
                    var fileName = $"{_options.CliExecutableFullName()}.download";

                    _log.Debug($"Writing file {fileName}");

                    using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }

                    // if download is successful we can then move the temp file to the proper name.
                    _log.Debug($"Renaming {fileName} to {_options.CliExecutableFullName()}");
                    File.Move(fileName, _options.CliExecutableFullName());
                }
            }
        }
    }
}
