// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using log4net;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Providers
{
    public class XsdFileInformationProvider : IXsdFileInformationProvider
    {
        private readonly IAssembliesProvider _assembliesProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(XsdFileInformationProvider));
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;
        private readonly Lazy<IDictionary<string, XsdFileInformation>> _xsdFileInformationByUriSegment;
        private const string CoreUriSegment = "ed-fi";

        public XsdFileInformationProvider(IAssembliesProvider assembliesProvider,
            ISchemaNameMapProvider schemaNameMapProvider)
        {
            _assembliesProvider = assembliesProvider;
            _schemaNameMapProvider = schemaNameMapProvider;

            _xsdFileInformationByUriSegment = new Lazy<IDictionary<string, XsdFileInformation>>(ParseAssemblies);
        }

        public string[] Schemas() => _xsdFileInformationByUriSegment.Value.Keys.ToArray();

        public XsdFileInformation XsdFileInformationByUriSegment(string uriSegment)
            => !_xsdFileInformationByUriSegment.Value.ContainsKey(uriSegment)
                ? default
                : _xsdFileInformationByUriSegment.Value[uriSegment];

        public XsdFileInformation CoreXsdFileInformation() => XsdFileInformationByUriSegment(CoreUriSegment);

        private IDictionary<string, XsdFileInformation> ParseAssemblies()
        {
            var assemblies = _assembliesProvider.GetAssemblies()
                .Where(x => !x.IsDynamic)
                .ToList();

            var assemblySchemaInformationByUriSegment =
                new Dictionary<string, XsdFileInformation>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var assembly in assemblies)
            {
                string[] manifestResourceNames = assembly.GetManifestResourceNames();
                string assemblyName = assembly.GetName().Name;

                _logger.Debug($"Checking assembly '{assemblyName}'");

                string apiModelFileName = $"{assemblyName}.Artifacts.Metadata.ApiModel.json";
                string extensionApiModelFileName = $"{assemblyName}.Artifacts.Metadata.ApiModel-EXTENSION.json";

                if (!manifestResourceNames.Any(
                    x => x.ContainsIgnoreCase(apiModelFileName) || x.ContainsIgnoreCase(extensionApiModelFileName)))
                {
                    continue;
                }

                _logger.Debug($"Assembly '{assemblyName} has an 'ApiModel.json'");

                var stream = manifestResourceNames.Any(x => x.ContainsIgnoreCase(apiModelFileName))
                    ? new StreamReader(assembly.GetManifestResourceStream(apiModelFileName))
                    : new StreamReader(assembly.GetManifestResourceStream(extensionApiModelFileName));

                var apiModel = JsonConvert.DeserializeObject<Dictionary<string, object>>(stream.ReadToEnd());

                var schemaInfo = apiModel["schemaDefinition"].ToDictionary();

                var assemblySchemaInformation = new XsdFileInformation(
                    assemblyName,
                    schemaInfo["version"].ToString(),
                    _schemaNameMapProvider.GetSchemaMapByLogicalName(schemaInfo["logicalName"].ToString()),
                    manifestResourceNames
                        .Where(x => x.StartsWithIgnoreCase($"{assemblyName}.Artifacts.Schemas"))
                        .Select(x => x.Replace($"{assemblyName}.Artifacts.Schemas.", string.Empty))
                        .ToArray()
                );

                _logger.Debug(assemblySchemaInformation);

                assemblySchemaInformationByUriSegment.Add(
                    assemblySchemaInformation.SchemaNameMap.UriSegment, assemblySchemaInformation);
            }

            return assemblySchemaInformationByUriSegment;
        }
    }
}
