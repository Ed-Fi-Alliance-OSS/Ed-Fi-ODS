// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using EdFi.LoadTools.ApiClient;
using log4net;

namespace EdFi.LoadTools.Engine.FileImportPipeline
{
    public class PreloadReferencesStep : IFileImportPipelineStep
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(PreloadReferencesStep));
        private readonly IXmlReferenceCacheProvider _referenceCacheProvider;

        public PreloadReferencesStep(IXmlReferenceCacheProvider referenceCacheProvider)
        {
            _referenceCacheProvider = referenceCacheProvider;
        }

        public bool Process(FileContext fileContext, Stream stream)
        {
            var contextPrefix = LogContext.BuildContextPrefix(Path.GetFileNameWithoutExtension(fileContext.FileName));

            if (fileContext.NumberOfIdRefs == 0)
            {
                _log.Debug($"{contextPrefix} No file references are found. Skipping preload of references.");
                return true;
            }

            var sw = new Stopwatch();
            sw.Start();

            var referenceCache = _referenceCacheProvider.GetXmlReferenceCache(fileContext.FileName);

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

                _log.Info($"{contextPrefix} {referenceCache.NumberOfLoadedReferences} references preloaded.");
            }

            sw.Stop();

            _log.Debug($"{contextPrefix} finished preloading in {sw.Elapsed.TotalSeconds} seconds.");
            return true;
        }
    }
}
