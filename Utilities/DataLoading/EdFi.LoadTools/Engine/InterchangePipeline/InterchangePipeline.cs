// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine.InterchangePipeline
{
    public class InterchangePipeline
    {
        private readonly Lazy<Dictionary<string, List<FileTypeInfo>>> _resourceByFileTypeInfo;
        private readonly IInterchangePipelineStep[] _steps;
        private readonly IXmlReferenceCacheFactory _xmlReferenceCacheFactory;

        public InterchangePipeline(IXmlReferenceCacheFactory xmlReferenceCacheFactory,
            IInterchangePipelineStep[] steps,
            IResourceToFileTypeInfoProvider resourceToFileTypeInfoProvider)
        {
            _xmlReferenceCacheFactory = xmlReferenceCacheFactory;
            _steps = steps;

            _resourceByFileTypeInfo =
                new Lazy<Dictionary<string, List<FileTypeInfo>>>(resourceToFileTypeInfoProvider.GetResourceByFileTypeInfo);
        }

        public IEnumerable<ApiLoaderWorkItem> RetrieveResourcesFromFiles(List<string> resources, int level)
        {
            var uniqueFileContexts = GetUniqueFileContexts(resources);

            foreach (var fileContext in uniqueFileContexts)
            {
                using (LogContext.SetFileName(Path.GetFileName(fileContext.FileName)))
                {
                    _xmlReferenceCacheFactory.InitializeCache(fileContext.FileName);

                    if (_steps.All(
                        s =>
                        {
                            using (var stream = CreateFileStream(fileContext))
                            {
                                return s.Process(fileContext, stream);
                            }
                        }))
                    {
                        using (var reader = new XmlTextReader(CreateFileStream(fileContext)))
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType != XmlNodeType.Element)
                                {
                                    continue;
                                }

                                if (reader.Name.StartsWith("Interchange"))
                                {
                                    continue;
                                }

                                var lineNumber = reader.LineNumber;

                                using (var r = reader.ReadSubtree())
                                {
                                    var xElement = XElement.Load(r);

                                    if (!resources.Any(
                                        s => s.Equals(xElement.Name.LocalName, StringComparison.InvariantCultureIgnoreCase)))
                                    {
                                        continue;
                                    }

                                    yield return
                                        new ApiLoaderWorkItem(fileContext.FileName, lineNumber, xElement, level);
                                }
                            }
                        }
                    }
                }
            }

            FileStream CreateFileStream(FileContext fileContext)
                => new FileStream(fileContext.FileName, FileMode.Open, FileAccess.Read);
        }

        private IEnumerable<FileContext> GetUniqueFileContexts(IEnumerable<string> resources)
        {
            var fileInfos = new HashSet<FileContext>();

            foreach (var resource in resources)
            {
                if (_resourceByFileTypeInfo.Value.TryGetValue(resource, out List<FileTypeInfo> fileTypeInfos))
                {
                    fileInfos.UnionWith(fileTypeInfos.SelectMany(s => s.FileContexts.Where(f => f.IsValid)));
                }
            }

            return fileInfos;
        }
    }
}
