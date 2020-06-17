// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics;
using System.IO;
using System.Xml;
using EdFi.LoadTools.ApiClient;
using log4net;

namespace EdFi.LoadTools.Engine.FileImportPipeline
{
    public class FindReferencesStep : IFileImportPipelineStep
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(FindReferencesStep));
        private readonly IXmlReferenceCacheProvider _referenceCacheProvider;

        public FindReferencesStep(IXmlReferenceCacheProvider referenceCacheProvider)
        {
            _referenceCacheProvider = referenceCacheProvider;
        }

        public bool Process(FileContext fileContext, Stream stream)
        {
            var contextPrefix = LogContext.BuildContextPrefix(Path.GetFileNameWithoutExtension(fileContext.FileName));

            if (fileContext.NumberOfIdRefs == 0)
            {
                _log.Debug($"{contextPrefix} No file references are found. Skipping finding references.");
                return true;
            }

            var sw = new Stopwatch();
            sw.Start();

            var total = 0;
            var referenceCache = _referenceCacheProvider.GetXmlReferenceCache(fileContext.FileName);

            using (var reader = new XmlTextReader(stream))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    var refId = reader.GetAttribute("ref");

                    if (!string.IsNullOrEmpty(refId))
                    {
                        referenceCache.LoadReference(refId);
                        total++;
                    }
                }

                _log.Info($"{contextPrefix} {total} references to {referenceCache.NumberOfReferences} resources found");
            }

            sw.Stop();

            _log.Debug($"Finished finding references in {sw.Elapsed.TotalSeconds} seconds.");
            return true;
        }
    }
}
