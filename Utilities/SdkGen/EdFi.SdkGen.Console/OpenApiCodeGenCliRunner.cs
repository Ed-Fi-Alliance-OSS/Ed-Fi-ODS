// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace EdFi.SdkGen.Console
{
    public class OpenApiCodeGenCliRunner
    {
        private const string Profiles = "Profiles";
        private const string Composites = "Composites";
        private const string Identity = "Identity";
        private const string Java = "java";
        private const string All = "All";
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Options _options;
       
        public OpenApiCodeGenCliRunner(Options options)
        {
            _options = options;
        }

        public void Run()
        {
            // run the task synchronously to avoid collisions to get the end points.
            var endpointTask = Task.Run(() => GetOpenApiEndpoints(_options.MetaDataEndpoint));
            endpointTask.Wait();
            var coreEdfiNamespaceList = new[] { @".*/metadata/composites/v1/ed-fi/([A-Za-z\-]+)/swagger.json", @".*/metadata/data/v3/ed-fi/swagger.json" };           
            var apiEndPoints = endpointTask.Result
                                                .Where(
                                                     x => x.Name.Equals(All) && !_options.CoreOnly
                                                          || _options.IncludeProfiles && x.Prefix.Equals(Profiles)
                                                          || _options.IncludeComposites && x.Prefix.Equals(Composites)
                                                          || _options.IncludeIdentity && x.Name.Equals(Identity)                                                        
                                                          || _options.CoreOnly && coreEdfiNamespaceList.Any(y => Regex.IsMatch(x.EndpointUri, y)))
                                                .ToList();
            RunCliCodegen(apiEndPoints);
        }

        private void RunCliCodegen(IEnumerable<OpenApiDetail> apiEndpoints)
        {
            foreach (var apiEndpoint in apiEndpoints)
            {
                // Profile/Composite section namespaces end with section name.
                string section = apiEndpoint.Prefix.Equals(Profiles) || apiEndpoint.Prefix.Equals(Composites)
                    ? $"{apiEndpoint.Prefix}."
                    : string.Empty;

                // 'Composite' is appended to composite category name to avoid namespace collisions.
                string metadataSectionReplaced =
                    apiEndpoint.Prefix.Equals(Composites)
                        ? $"{apiEndpoint.Name.Replace('-', '_')}Composite"
                        : apiEndpoint.Name.Replace('-', '_');

                string apiPackage = $"Apis.{section}{metadataSectionReplaced}";
                string modelPackage = $"Models.{section}{metadataSectionReplaced}";

                // code-gen paramaters
                string[] @params =
                {
                    $"-jar {_options.CliExecutableFullName()}", "generate", "-g csharp-netcore", $"-i {apiEndpoint.EndpointUri}",
                    $"--api-package {apiPackage}", $"--model-package {modelPackage}", $"-o {_options.OutputFolder}",
                    $"--additional-properties packageName={_options.Namespace},targetFramework=net6.0,netCoreProjectFile=true",
                    "--global-property modelTests=false --global-property apiTests=false --skip-validate-spec"
                };

                _log.Info($"Generating C# SDK for {apiEndpoint.EndpointUri}");

                ShellProcess(Java, @params);
            }
        }

        private async Task<IEnumerable<OpenApiDetail>> GetOpenApiEndpoints(string openapiEndpoint)
        {
            _log.Info($"Downloading openapi endpoint data from {openapiEndpoint}");

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(openapiEndpoint))
                {
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<OpenApiDetail>>(json);
                }
            }
        }

        private void ShellProcess(string command, params string[] args)
        {
            var startInfo = new ProcessStartInfo
                            {
                                FileName = command, Arguments = string.Join(" ", args), UseShellExecute = false
                            };

            _log.Debug($"{startInfo.FileName} {startInfo.Arguments}");

            using (var exeProcess = Process.Start(startInfo))
            {
                exeProcess?.WaitForExit();
            }
        }

        // instead of adding a reference to the api project it is easier to use an internal dto
        private class OpenApiDetail
        {
            public string Name { get; set; }

            public string EndpointUri { get; set; }

            public string Prefix { get; set; }
        }
    }
}
