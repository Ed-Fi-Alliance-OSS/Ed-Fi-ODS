// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using EdFi.LoadTools.BulkLoadClient.Application;
using EdFi.LoadTools.Engine.Factories;
using log4net;

namespace EdFi.LoadTools.BulkLoadClient
{
    public class LoadProcess : ILoadProcess
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(LoadProcess));
        private readonly IApiLoaderApplication _application;
        private readonly Configuration _configuration;

        public LoadProcess(Configuration configuration, IApiLoaderApplication application)
        {
            _configuration = configuration;
            _application = application;
        }

        public async Task<int> Run()
        {
            ConfigureTls();

            int exitCode;

            if (!_configuration.IsValid)
            {
                exitCode = 1;
                _log.Error(_configuration.ErrorText);
            }
            else
            {
                try
                {
                    LogConfiguration(_configuration);

                    // run application
                    exitCode = await _application.Run();
                }
                catch (AggregateException ex)
                {
                    exitCode = 1;

                    foreach (var e in ex.InnerExceptions)
                    {
                        _log.Error(e);
                    }
                }
            }

            return exitCode;
        }

        private static IEnumerable<string> GetFilesToImport(Configuration configuration)
        {
            return Directory.EnumerateFiles(configuration.DataFolder);
        }

        public static BulkLoadValidationResult ValidateXmlFile(Configuration configuration, string[] unsupportedInterchanges)
        {
            var validationErrors = new BulkLoadValidationResult();
            var streamsRetriever = new XsdStreamsRetriever(configuration);
            var factory = new SchemaSetFactory(streamsRetriever);
            var schemaSet = factory.GetSchemaSet();

            foreach (var fileToImport in GetFilesToImport(configuration))
            {
                var xmlReaderSettings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema,
                    Schemas = schemaSet,
                    ValidationFlags = XmlSchemaValidationFlags.AllowXmlAttributes |
                                      XmlSchemaValidationFlags.ReportValidationWarnings |
                                      XmlSchemaValidationFlags.ProcessIdentityConstraints
                };

                xmlReaderSettings.ValidationEventHandler += (s, e) => { validationErrors.Add(e.Message); };

                using (var fileStream = new FileStream(fileToImport, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = XmlReader.Create(fileStream, xmlReaderSettings))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && unsupportedInterchanges.Any(
                                i => i.Equals(reader.Name, StringComparison.InvariantCultureIgnoreCase)))
                            {
                                validationErrors.Add($"Import of data for {reader.Name} is not supported");
                            }
                        }

                        reader.Close();
                    }

                    fileStream.Close();
                }
            }

            return validationErrors;
        }

        private static void LogConfiguration(Configuration configuration)
        {
            _log.Info($"Api Url:                  {configuration.ApiUrl}");
            _log.Info($"School Year:              {configuration.SchoolYear}");
            _log.Info($"Retries:                  {configuration.Retries}");
            _log.Info($"Oauth Key:                {configuration.OauthKey}");
            _log.Info($"Metadata Url:             {configuration.MetadataUrl}");
            _log.Info($"Data Folder:              {configuration.DataFolder}");
            _log.Info($"Working Folder:           {configuration.WorkingFolder}");
            _log.Info($"Xsd Folder:               {configuration.XsdFolder}");
            _log.Info($"Dependencies Url:         {configuration.DependenciesUrl}");
        }

        /// <summary>
        /// Explicitly configures all outgoing network calls to use the latest version of TLS where possible.
        /// c.f https://docs.microsoft.com/en-us/dotnet/framework/network-programming/tls
        /// </summary>
        private static void ConfigureTls()
        {
            // TLS 1.2 is not available by default for version of the frameworks less that .NET 4.6.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}
