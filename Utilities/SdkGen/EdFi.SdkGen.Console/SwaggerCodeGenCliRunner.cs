// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace EdFi.SdkGen.Console
{
    public class SwaggerCodeGenCliRunner
    {
        private const string Profiles = "Profiles";
        private const string Composites = "Composites";
        private const string Identity = "Identity";
        private const string Java = "java";
        private const string All = "All";
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Options _options;
       
        public SwaggerCodeGenCliRunner(Options options)
        {
            _options = options;
        }

        public void Run()
        {
            // run the task synchronously to avoid collisions to get the end points.
            _options.MetaDataEndpoint = "https://api.ed-fi.org/v5.3/api/metadata?sdk=true";
            var endpointTask = Task.Run(() => GetSwaggerEndpoints(_options.MetaDataEndpoint));
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

        private void RunCliCodegen(IEnumerable<SwaggerDetail> apiEndpoints)
        {
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "csharp"));

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
                    //$"-jar {_options.CliExecutableFullName()}", "generate", "-l csharp", $"-i {apiEndpoint.EndpointUri}",
                    //$"--api-package {apiPackage}", $"--model-package {modelPackage}", $"-o {_options.OutputFolder}",
                    //$"--additional-properties packageName={_options.Namespace},targetFramework=v5.0,netCoreProjectFile=true", "-DmodelTests=false -DapiTests=false",
                    //"-Dhttps.protocols=TLSv1.2"

                    $"-jar {_options.CliExecutableFullName()}", "generate", "-g csharp", $"-i {apiEndpoint.EndpointUri}",
                    $"--api-package {apiPackage}", $"--model-package {modelPackage}", $"-o {_options.OutputFolder}",
                    $"--additional-properties packageName={_options.Namespace},targetFramework=v5.0,netCoreProjectFile=true"
                };

                _log.Info($"Generating C# SDK for {apiEndpoint.EndpointUri}");

                ShellProcess(Java, @params);
            }
        }

        private async Task<IEnumerable<SwaggerDetail>> GetSwaggerEndpoints(string swaggerEndpoint)
        {
            _log.Info($"Downloading swagger endpoint data from {swaggerEndpoint}");

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(swaggerEndpoint))
                {
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<SwaggerDetail>>(json);
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
        private class SwaggerDetail
        {
            public string Name { get; set; }

            public string EndpointUri { get; set; }

            public string Prefix { get; set; }
        }
    }
}
