// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EdFi.Common.Inflection;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using log4net;
using Microsoft.OpenApi.Models;

namespace EdFi.LoadTools.SmokeTest.ApiTests
{
    public class GetSwaggerMetadataGenerator : ITestGenerator, ITest
    {
        private readonly Dictionary<string, Entity> _entities;
        private readonly Dictionary<string, Resource> _resources;

        private readonly ISwaggerRetriever _retriever;
        private readonly List<string> _schemaNames;
        private readonly Dictionary<string, OpenApiDocument> _swaggerDocuments;

        public GetSwaggerMetadataGenerator(
            ISwaggerRetriever retriever,
            Dictionary<string, Resource> resources,
            List<string> schemaNames,
            Dictionary<string, OpenApiDocument> swaggerDocuments,
            Dictionary<string, Entity> entities)
        {
            _retriever = retriever;
            _resources = resources;
            _schemaNames = schemaNames;
            _swaggerDocuments = swaggerDocuments;
            _entities = entities;
        }

        private static ILog Log
            => LogManager.GetLogger(
                MethodBase.GetCurrentMethod()
                    .DeclaringType);

        public async Task<bool> PerformTest()
        {
            try
            {
                var metadata = await _retriever.LoadMetadata();

                var t = new[]
                {
                    "Resources",
                    "Descriptors"
                };

                foreach (var key in metadata.Keys.Where(k => t.Contains(k)))
                {
                    var doc = metadata[key];
                    _swaggerDocuments[key] = doc;

                    var uniqueSchemaNames = doc.Paths.Keys
                        .Select(GetSchemaNameFromPath)
                        .Distinct()
                        .ToList();

                    foreach (var path in doc.Paths)
                    {
                        if (_resources.ContainsKey(path.Key))
                            continue;

                        _resources[path.Key] = new Resource
                        {
                            Name = GetResoucePath(path.Key, path.Value),
                            BasePath = ReplaceVariablesInServer(doc.Servers.First()),
                            Path = path.Value,
                            Schema = GetSchemaNameFromPath(path.Key),
                            Definition = doc.Components
                                .Schemas
                                .FirstOrDefault(
                                    d => TypeNameHelper.CompareTypeNames(path.Key, d.Key, "_", uniqueSchemaNames))
                                .Value
                        };
                    }

                    foreach (var definition in doc.Components.Schemas)
                    {
                        if (_entities.ContainsKey(definition.Key))
                        {
                            continue;
                        }

                        string[] nameParts = definition.Key.Split('_');

                        _entities[definition.Key] = new Entity
                        {
                            Name = definition.Key.Replace("_", string.Empty),
                            Schema = nameParts[0],
                            Definition = definition.Value
                        };
                    }

                    foreach (var schemaName in uniqueSchemaNames)
                    {
                        if (!_schemaNames.Contains(schemaName))
                        {
                            _schemaNames.Add(schemaName);
                        }
                    }

                    Log.Info("Success");
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public IEnumerable<ITest> GenerateTests()
        {
            yield return this;
        }

        private static string GetResoucePath(string path, OpenApiPathItem pathItem)
        {
            var resoucePath = path;

            foreach (var parameter in pathItem.Operations[OperationType.Get].Parameters)
            {
                resoucePath = resoucePath.Replace($"{{{parameter.Name}}}", string.Empty);
            }

            return resoucePath.TrimEnd('/');
        }

        private static string GetSchemaNameParts(IEnumerable<string> schemaNameParts)
        {
            var schemaName = new StringBuilder();
            var nameParts = schemaNameParts as string[] ?? schemaNameParts.ToArray();

            for (var i = 1; i < nameParts.Length; i++)
            {
                schemaName.Append(Inflector.MakeInitialUpperCase(nameParts[i]));
            }

            return schemaName.ToString();
        }

        private static string GetSchemaNameFromPath(string path)
        {
            string[] v = path.Split('/');

            if (v.Length <= 1)
            {
                return null;
            }

            string[] schemaNameParts = v[1].Split('-');

            return schemaNameParts[0] + (schemaNameParts.Length > 1
                       ? GetSchemaNameParts(schemaNameParts)
                       : string.Empty);
        }

        private static string ReplaceVariablesInServer(OpenApiServer server)
        {
            var variablesToReplace = server.Variables.Select(x => new
            {
                Name = x.Key,
                DefaultValue = x.Value.Default.Replace("/", string.Empty)
            });
            var serverUrl = server.Url;

            foreach (var variable in variablesToReplace)
            {
                serverUrl = serverUrl.Replace($"{{{variable.Name}}}", variable.DefaultValue);
            }

            return serverUrl;
        }
    }
}
