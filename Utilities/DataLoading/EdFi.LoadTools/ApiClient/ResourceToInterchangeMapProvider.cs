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
using log4net;

namespace EdFi.LoadTools.ApiClient
{
    public interface IResourceToFileTypeInfoProvider
    {
        Dictionary<string, List<FileTypeInfo>> GetResourceByFileTypeInfo();
    }

    public class ResourceToFileTypeInfoProvider : IResourceToFileTypeInfoProvider
    {
        private readonly IDataConfiguration _dataConfiguration;
        private readonly Regex _interchangeNameRegex = new Regex(Constants.InterchangeNameRegex, RegexOptions.Compiled);
        private readonly ILog _log = LogManager.GetLogger(nameof(ResourceToFileTypeInfoProvider));
        private readonly Dictionary<string, List<FileTypeInfo>> _resourceByFileTypeInfo =
            new Dictionary<string, List<FileTypeInfo>>();
        private readonly Lazy<Dictionary<string, List<FileContext>>> _resourceNameByFileContext;
        private readonly XmlSchemaSet _xmlSchemaSet;
        private readonly IXsdConfiguration _xsdConfiguration;

        public ResourceToFileTypeInfoProvider(XmlSchemaSet xmlSchemaSet, IDataConfiguration dataConfiguration,
            IXsdConfiguration xsdConfiguration)
        {
            _xmlSchemaSet = xmlSchemaSet;
            _dataConfiguration = dataConfiguration;
            _xsdConfiguration = xsdConfiguration;

            _resourceNameByFileContext =
                new Lazy<Dictionary<string, List<FileContext>>>(GetFileTypeByFileContext);
        }

        public Dictionary<string, List<FileTypeInfo>> GetResourceByFileTypeInfo()
        {
            foreach (XmlSchema schema in _xmlSchemaSet.Schemas())
            {
                foreach (XmlSchemaElement element in schema.Elements.Values)
                {
                    var fileType = element.Name;

                    var resources = element.ElementSchemaType.GetUnorderedElementNames().ToList();

                    resources.ForEach(
                        r =>
                        {
                            var resource = r.ToLower();

                            if (!_resourceByFileTypeInfo.TryGetValue(resource, out List<FileTypeInfo> fileTypeInfos))
                            {
                                fileTypeInfos = _resourceByFileTypeInfo[resource] = new List<FileTypeInfo>();
                            }

                            if (!_resourceNameByFileContext.Value.TryGetValue(fileType, out List<FileContext> fileContexts))
                            {
                                fileContexts = new List<FileContext>();
                            }

                            fileTypeInfos.Add(
                                new FileTypeInfo
                                {
                                    FileType = fileType,
                                    FileContexts = fileContexts
                                });
                        });
                }
            }

            return _resourceByFileTypeInfo;
        }

        private Dictionary<string, List<FileContext>> GetFileTypeByFileContext()
        {
            var fileTypeByFileContexts = new Dictionary<string, List<FileContext>>();

            foreach (string file in Directory.GetFiles(_dataConfiguration.Folder, "*.xml", SearchOption.AllDirectories))
            {
                var contextPrefix = LogContext.BuildContextPrefix(Path.GetFileName(file));

                var sw = new Stopwatch();
                sw.Start();

                _log.Debug($"{contextPrefix} Start processing");

                FileContext fileContext = CreateFileContext(file, contextPrefix);

                if (!fileContext.IsValid)
                {
                    _log.Warn($"{contextPrefix} Failed Validation");
                    continue;
                }

                if (fileTypeByFileContexts.TryGetValue(fileContext.FileType, out List<FileContext> fileContexts))
                {
                    fileContexts.Add(fileContext);
                }
                else
                {
                    fileTypeByFileContexts[fileContext.FileType] = new List<FileContext> {fileContext};
                }

                sw.Stop();

                _log.Debug($"{contextPrefix} Finished processing in {sw.Elapsed.TotalSeconds} seconds.");
            }

            return fileTypeByFileContexts;

            FileContext CreateFileContext(string fileName, string contextPrefix)
            {
                var fileContext = new FileContext
                {
                    FileName = fileName,
                    IsValid = true
                };

                var xmlReaderSettings = new XmlReaderSettings {CloseInput = true};

                if (!_xsdConfiguration.DoNotValidateXml)
                {
                    _log.Debug($"{contextPrefix} XSD validation is enabled.");
                    xmlReaderSettings.Schemas = _xmlSchemaSet;
                    xmlReaderSettings.ValidationType = ValidationType.Schema;

                    xmlReaderSettings.ValidationEventHandler += (s, e) =>
                    {
                        _log.Error($"{e.Message}");
                        fileContext.IsValid = false;
                    };
                }

                try
                {
                    using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        if (stream.Length == 0)
                        {
                            _log.Warn($"{contextPrefix} Empty file.");
                            throw new FileFormatException($"{contextPrefix} Empty File");
                        }

                        var reader = XmlReader.Create(stream, xmlReaderSettings);

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
                                throw new FileFormatException($"{contextPrefix} Unknown file type");
                            }
                        }

                        _log.Debug($"{contextPrefix} Checking for reference identities");

                        // loop through and count the ids refs
                        while (reader.Read())
                        {
                            if (reader.NodeType != XmlNodeType.Element)
                            {
                                continue;
                            }

                            string refId = reader.GetAttribute("ref");

                            if (!string.IsNullOrEmpty(refId))
                            {
                                fileContext.NumberOfIdRefs++;
                            }
                        }
                    }
                }
                catch (FileFormatException e)
                {
                    _log.Warn(e.Message);
                    fileContext.IsValid = false;
                }
                finally
                {
                    if (fileContext.NumberOfIdRefs > 0)
                    {
                        _log.Debug($"{contextPrefix} Reference identities exist");
                    }

                    _log.Debug($"{contextPrefix} Finished processing.");
                }

                if (!_xsdConfiguration.DoNotValidateXml)
                {
                    _log.Info($"{contextPrefix} passed XSD validation.");
                }

                return fileContext;
            }
        }
    }
}
