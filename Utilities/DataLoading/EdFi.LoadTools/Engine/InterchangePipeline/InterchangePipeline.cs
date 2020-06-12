// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine.InterchangePipeline
{
    public class InterchangePipeline
    {
        private readonly IInterchangePipelineStep[] _steps;
        private readonly IResourceStreamFactory _streamFactory;
        private readonly IXmlReferenceCacheFactory _xmlReferenceCacheFactory;
        private readonly Lazy<Dictionary<string, List<InterchangeInfo>>> _resourceToInterchangeMap;

        public InterchangePipeline(IResourceStreamFactory streamFactory,
                                   IXmlReferenceCacheFactory xmlReferenceCacheFactory,
                                   IInterchangePipelineStep[] steps,
                                   ResourceToInterchangeMapProvider resourceToInterchangeMapProvider)
        {
            _streamFactory = streamFactory;
            _xmlReferenceCacheFactory = xmlReferenceCacheFactory;
            _steps = steps;
            _resourceToInterchangeMap =
                new Lazy<Dictionary<string, List<InterchangeInfo>>>(resourceToInterchangeMapProvider.GetResourceToInterchangeMap);

        }
        public IEnumerable<ApiLoaderWorkItem> RetrieveResourcesFromInterchange(List<string> resources, int level)
        {
            var interchangeFileNames = GetUniqueInterchangeFiles(resources);

            foreach (var interchangeFileName in interchangeFileNames)
            {
                using (LogContext.SetFileName(interchangeFileName))
                {
                    _xmlReferenceCacheFactory.InitializeCache(interchangeFileName);

                    if (_steps.All(
                        s =>
                        {
                            using (var stream = _streamFactory.GetStream(interchangeFileName))
                            {
                                return s.Process(interchangeFileName, stream);
                            }
                        }))
                    {
                        using (var reader = new XmlTextReader(_streamFactory.GetStream(interchangeFileName)))
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

                                    if (!resources.Any(s => s.Equals(xElement.Name.LocalName,StringComparison.InvariantCultureIgnoreCase)))
                                    {
                                        continue;
                                    }

                                    yield return
                                        new ApiLoaderWorkItem(interchangeFileName, lineNumber, xElement, level);
                                }
                            }
                        }
                    }
                }
            }
        }

        private IEnumerable<string> GetUniqueInterchangeFiles(IEnumerable<string> resources)
        {
            HashSet<string> interchangeFileNames = new HashSet<string>();

            foreach (var resource in resources)
            {
                if (_resourceToInterchangeMap.Value.TryGetValue(resource, out List<InterchangeInfo> interchangeInfoList))
                {
                    interchangeFileNames.UnionWith(interchangeInfoList.SelectMany(s => s.InterchangeFileNames));
                }
            }

            return interchangeFileNames;
        }
    }
}
