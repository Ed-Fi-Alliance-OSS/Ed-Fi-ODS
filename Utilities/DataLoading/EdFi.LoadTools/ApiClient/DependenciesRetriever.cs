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
using EdFi.Common.Inflection;
using EdFi.LoadTools.Engine;
using log4net;
using Newtonsoft.Json;

namespace EdFi.LoadTools.ApiClient
{
    public class DependenciesRetriever
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DependenciesRetriever).Name);
        private readonly IApiMetadataConfiguration _configuration;
        private const string EdfiNamespace = "ed-fi";
        private const string CreateOperation = "Create";

        public DependenciesRetriever(IApiMetadataConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string Filename => Path.Combine(_configuration.Folder, "dependencies.json");
        private bool DependenciesExists => File.Exists(Filename);
        public async Task<IEnumerable<Dependency>> GetDependencyOrderAsync()
        {
            if (!DependenciesExists || _configuration.Force)
            {
                await LoadDependenciesAsync().ConfigureAwait(false);
            }

            return await ReadDependenciesAsync().ConfigureAwait(false);
        }

        private async Task<IEnumerable<Dependency>> ReadDependenciesAsync()
        {
            Dependency[] dependencies;

            if (!DependenciesExists)
            {
                return Enumerable.Empty<Dependency>();
            }

            using (var reader = new StreamReader(Filename))
            {
                var dependenciesJson = await reader.ReadToEndAsync().ConfigureAwait(false);
                dependencies = JsonConvert.DeserializeObject<Dependency[]>(dependenciesJson);
                reader.Close();
            }

            foreach (var dependency in dependencies)
            {
                var dependencySegments = dependency.Resource.Split('/');
                var resource = dependencySegments[2];

                dependency.Namespace = dependencySegments[1].ToLower();
                dependency.Resource = CompositeTermInflector.MakeSingular(resource).ToLower();
            }

            return dependencies.OrderBy(o => o.Order).GroupBy(x => x.Resource)
                .Select(GetFirstDependencySetPriorityToDependencyWithEdFiNamespace).AsEnumerable();
        }

        private Dependency GetFirstDependencySetPriorityToDependencyWithEdFiNamespace(IGrouping<string, Dependency> dependencyGroup)
        {
            return dependencyGroup.FirstOrDefault(d => d.Namespace.Equals(EdfiNamespace) && d.Operations.Any(s => s.Equals(CreateOperation))) ??
                   dependencyGroup.FirstOrDefault(d => d.Operations.Any(s => s.Equals(CreateOperation))) ?? dependencyGroup.First();
        }

        public async Task<IEnumerable<IGrouping<int, Dependency>>> GetDependencyLevelGroupsAsync()
        {
            var resources = await GetDependencyOrderAsync().ConfigureAwait(false);

           return resources
                .Where(s => s.Operations.Any(d => d.Equals(CreateOperation)))
                .OrderBy(s => s.Order)
                .GroupBy(d => d.Order);
        }

        private async Task LoadDependenciesAsync()
        {
            using (LogicalThreadContext.Stacks["NDC"].Push(_configuration.DependenciesUrl))
            {
                File.Delete(Filename);

                Log.Info("Loading API Dependencies");

                using (var writer = new StreamWriter(Filename))
                {
                    var jsonDependencies = await LoadJsonStringAsync(_configuration.DependenciesUrl).ConfigureAwait(false);

                    await writer.WriteLineAsync(jsonDependencies).ConfigureAwait(false);

                    writer.Close();
                }
            }
        }

        private async Task<string> LoadJsonStringAsync(string dependenciesUrl)
        {
            using (var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 5, 0)
            })
            {
                var response = await client.GetAsync(dependenciesUrl).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
}
