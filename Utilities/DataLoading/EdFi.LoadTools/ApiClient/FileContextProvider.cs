// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using EdFi.LoadTools.Engine;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.LoadTools.ApiClient
{
    public class FileContextProvider : IFileContextProvider
    {
        private readonly IDataConfiguration _dataConfiguration;
        private readonly Regex _interchangeNameRegex = new Regex(Constants.InterchangeNameRegex, RegexOptions.Compiled);
        private readonly ILog _log = LogManager.GetLogger(nameof(FileContextProvider));
        private readonly XmlSchemaSet _xmlSchemaSet;
        private readonly IXsdConfiguration _xsdConfiguration;
        private readonly Lazy<List<FileContext>> _fileContexts;

        public FileContextProvider(XmlSchemaSet xmlSchemaSet, IDataConfiguration dataConfiguration,
            IXsdConfiguration xsdConfiguration)
        {
            _xmlSchemaSet = xmlSchemaSet;
            _dataConfiguration = dataConfiguration;
            _xsdConfiguration = xsdConfiguration;

            _fileContexts = new Lazy<List<FileContext>> (() => CreateFileContexts().Where(x => x.IsValid).ToList());
        }

        public IEnumerable<FileContext> GetFileContexts(List<string> resources)
            => _fileContexts.Value
                .Where(fc => fc.Resources.Any(r => resources.Contains(r, StringComparer.InvariantCultureIgnoreCase)));

        private IEnumerable<FileContext> CreateFileContexts()
        {
            var fileContexts = new HashSet<FileContext>();

            foreach (string file in Directory.GetFiles(_dataConfiguration.Folder, "*.xml", SearchOption.AllDirectories))
            {
                var contextPrefix = LogContext.BuildContextPrefix(Path.GetFileName(file));

                Stopwatch sw = null;

                if (_log.IsDebugEnabled)
                {
                    sw = new Stopwatch();
                    sw.Start();
                }

                _log.Debug($"{contextPrefix} Start processing");

                var fileContext = CreateFileContext(file, contextPrefix);

                fileContexts.Add(fileContext);

                if (_log.IsDebugEnabled)
                {
                    sw.Stop();

                    _log.Debug($"{contextPrefix} Finished processing in {sw.Elapsed.TotalSeconds} seconds.");
                }
            }

            return fileContexts;

            FileContext CreateFileContext(string fileName, string contextPrefix)
            {
                var fileContext = new FileContext {FileName = fileName, Resources = new HashSet<string>()};

                var xmlReaderSettings = new XmlReaderSettings {CloseInput = true};

                if (!_xsdConfiguration.DoNotValidateXml)
                {
                    _log.Debug($"{contextPrefix} XSD validation is enabled.");
                    xmlReaderSettings.Schemas = _xmlSchemaSet;
                    xmlReaderSettings.ValidationType = ValidationType.Schema;

                    xmlReaderSettings.ValidationEventHandler += (s, e) => { _log.Error($"{e.Message}"); };
                }

                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    if (stream.Length == 0)
                    {
                        _log.Warn($"{contextPrefix} Empty file.");
                        return fileContext;
                    }

                    using (var reader = XmlReader.Create(stream, xmlReaderSettings))
                    {
                        // get the interchange name
                        if (reader.MoveToContent() == XmlNodeType.Element)
                        {
                            var match = _interchangeNameRegex.Match(reader.Name);

                            if (match.Success)
                            {
                                fileContext.FileType = match.Groups["InterchangeType"].Value;
                            }
                            else
                            {
                                _log.Warn($"{contextPrefix} Unknown file type");
                                return fileContext;
                            }
                        }

                        _log.Debug($"{contextPrefix} Checking for reference identities and resources");

                        // loop through and count the ids refs
                        while (reader.Read())
                        {
                            if (reader.NodeType != XmlNodeType.Element)
                            {
                                continue;
                            }

                            if (reader.Depth == 1)
                            {
                                fileContext.Resources.Add(reader.Name);
                            }

                            string refId = reader.GetAttribute("ref");

                            if (!string.IsNullOrEmpty(refId))
                            {
                                fileContext.NumberOfIdRefs++;
                            }
                        }

                        fileContext.IsValid = true;
                    }
                }

                if (fileContext.NumberOfIdRefs > 0)
                {
                    _log.Debug($"{contextPrefix} Reference identities exist");
                }

                _log.Debug($"{contextPrefix} Finished processing.");

                if (_xsdConfiguration.DoNotValidateXml)
                {
                    _log.Debug($"{contextPrefix} was not validated with XSD validation.");
                    return fileContext;
                }

                if (fileContext.IsValid)
                {
                    _log.Info($"{contextPrefix} passed XSD validation.");
                }
                else
                {
                    _log.Warn($"{contextPrefix} failed XSD validation.");
                }

                return fileContext;
            }
        }
    }
}