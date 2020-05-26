// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.IO;
using System.Xml;
using System.Xml.Linq;
using log4net;

namespace EdFi.LoadTools.Engine.InterchangePipeline
{
    public class PreloadReferencesStep : IInterchangePipelineStep
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PreloadReferencesStep).Name);
        private readonly IXmlReferenceCacheProvider _referenceCacheProvider;

        public PreloadReferencesStep(IXmlReferenceCacheProvider referenceCacheProvider)
        {
            _referenceCacheProvider = referenceCacheProvider;
        }

        public bool Process(string sourceFileName, Stream stream)
        {
            var referenceCache = _referenceCacheProvider.GetXmlReferenceCache(sourceFileName);

            using (var reader = new XmlTextReader(stream))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    var id = reader.GetAttribute("id");

                    if (string.IsNullOrEmpty(id))
                    {
                        continue;
                    }

                    using (var r = reader.ReadSubtree())
                    {
                        var referenceSource = XElement.Load(r);
                        referenceCache.PreloadReferenceSource(id, referenceSource);
                    }
                }

                Log.Info($"{referenceCache.NumberOfLoadedReferences} references preloaded");
            }

            return true;
        }
    }
}
