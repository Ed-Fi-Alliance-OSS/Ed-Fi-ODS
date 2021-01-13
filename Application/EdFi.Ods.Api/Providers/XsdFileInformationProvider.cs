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

        public XsdFileInformationProvider(IAssembliesProvider assembliesProvider,
            ISchemaNameMapProvider schemaNameMapProvider)
        {
            _assembliesProvider = assembliesProvider;
            _schemaNameMapProvider = schemaNameMapProvider;

            _xsdFileInformationByUriSegment = new Lazy<IDictionary<string, XsdFileInformation>>(ParseAssemblies);
        }

        public IDictionary<string, XsdFileInformation> XsdFileInformationByUriSegment() => _xsdFileInformationByUriSegment.Value;

        public Task<XsdFileInformation> XsdFileInformationAsync(string schema, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.Debug("Cancellation has been requested.");
                cancellationToken.ThrowIfCancellationRequested();
            }

            return Task.FromResult(
                !_xsdFileInformationByUriSegment.Value.ContainsKey(schema)
                    ? default
                    : _xsdFileInformationByUriSegment.Value[schema]);
        }

        private IDictionary<string, XsdFileInformation> ParseAssemblies()
        {
            var assemblies = _assembliesProvider.GetAssemblies()
                .Where(x => IsIncluded(x.GetName().Name) && !x.IsDynamic)
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

                var assemblySchemaInformation = new XsdFileInformation
                {
                    AssemblyName = assemblyName,
                    SchemaNameMap = _schemaNameMapProvider.GetSchemaMapByLogicalName(schemaInfo["logicalName"].ToString()),
                    Version = schemaInfo["version"].ToString(),
                    SchemaFiles = manifestResourceNames
                        .Where(x => x.StartsWithIgnoreCase($"{assemblyName}.Artifacts.Schemas"))
                        .Select(x => x.Replace($"{assemblyName}.Artifacts.Schemas.", string.Empty))
                        .ToArray()
                };

                _logger.Debug(assemblySchemaInformation);

                assemblySchemaInformationByUriSegment.Add(
                    assemblySchemaInformation.SchemaNameMap.UriSegment, assemblySchemaInformation);
            }

            return assemblySchemaInformationByUriSegment;

            static bool IsIncluded(string name)
                => !(name.StartsWithIgnoreCase("System")
                     || name.StartsWithIgnoreCase("Microsoft")
                     || name.StartsWithIgnoreCase("EntityFramework")
                     || name.StartsWithIgnoreCase("Autofac")
                     || name.StartsWithIgnoreCase("Antlr3")
                     || name.StartsWithIgnoreCase("Dapper")
                     || name.StartsWithIgnoreCase("netstandard")
                     || name.StartsWithIgnoreCase("Remotion")
                     || name.StartsWithIgnoreCase("log4net")
                     || name.StartsWithIgnoreCase("NHibernate")
                     || name.StartsWithIgnoreCase("Npgsql")
                     || name.StartsWithIgnoreCase("Newtonsoft")
                     || name.StartsWithIgnoreCase("Sandwych")
                     || name.StartsWithIgnoreCase("Iesi")
                     || name.StartsWithIgnoreCase("FluentValidation"));
        }
    }
}
