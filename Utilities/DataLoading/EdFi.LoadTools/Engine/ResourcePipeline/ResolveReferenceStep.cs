// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.LoadTools.ApiClient;
using log4net;

namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    /// <summary>
    ///     Resolve references. This goes before the mapper and after the unneeded
    ///     elements have been filtered out, and obviously after we've created the reference.
    /// </summary>
    public class ResolveReferenceStep : IResourcePipelineStep
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ResolveReferenceStep).Name);
        private readonly XmlModelMetadata[] _metadata;
        private readonly IXmlReferenceCacheProvider _referenceCacheProvider;

        public ResolveReferenceStep(IXmlReferenceCacheProvider referenceCacheProvider,
                                    IEnumerable<XmlModelMetadata> metadata)
        {
            _referenceCacheProvider = referenceCacheProvider;
            _metadata = metadata.ToArray();
        }

        public bool Process(ApiLoaderWorkItem resourceWorkItem)
        {
            var values = new[]
                         {
                             $"{resourceWorkItem.ElementName}Extension", resourceWorkItem.ElementName
                         };

            var xmlModelMetadata = _metadata.FirstOrDefault(x => values.Contains(x.Model));

            if (xmlModelMetadata == null)
            {
                return false;
            }

            var targetModel = xmlModelMetadata.Model;

            var referenceCache =
                new Lazy<IXmlReferenceCache>(
                    () =>
                        _referenceCacheProvider.GetXmlReferenceCache(resourceWorkItem.SourceFileName));

            ResolveReferences(referenceCache, resourceWorkItem.XElement, targetModel);
            return true;
        }

        private void ResolveReferences(Lazy<IXmlReferenceCache> referenceCache, XElement element, string targetModel)
        {
            var targets = element.Elements().Where(
                x =>
                    x.Name.LocalName.EndsWith("Reference") &&
                    x.Attribute("ref") != null);

            foreach (var target in targets)
            {
                var id = target.Attribute("ref").Value;
                var source = referenceCache.Value.VisitReference(id);

                if (source == null)
                {
                    Log.Error($"A resource with id='{id}' was not found in the reference cache.");
                    continue;
                }

                var map = _metadata.FirstOrDefault(x => x.Model == targetModel && x.Property == target.Name.LocalName);

                if (map == null)
                {
                    Log.Error(
                        $"No replacement mapping could be found for model '{targetModel}' and property '{target.Name.LocalName}'");

                    continue;
                }

                PerformMapping(source, target, map.Type);
            }

            foreach (var childElement in element.Elements())
            {
                var metadata = _metadata.FirstOrDefault(
                    x =>
                        x.Model == targetModel && x.Property == childElement.Name.LocalName);

                if (metadata != null)
                {
                    var modelName = metadata.Type;
                    ResolveReferences(referenceCache, childElement, modelName);
                }
            }
        }

        private void PerformMapping(XElement source, XElement target, string targetModel)
        {
            var ns = target.Name.Namespace;
            var targetModels = _metadata.Where(x => x.Model == targetModel);

            var maps = targetModels.SelectMany(
                                        t => source.Elements().Select(
                                            s =>
                                                new
                                                {
                                                    s, t, m = t.Property.PercentMatchTo(s.Name.LocalName)
                                                }))
                                   .OrderByDescending(o => o.m)
                                   .ToList();

            while (maps.Count > 0)
            {
                var map = maps.First();

                if (map.s.HasElements)
                {
                    var targetChild = new XElement(ns + map.t.Property);
                    target.Add(targetChild);
                    PerformMapping(map.s, targetChild, map.t.Type);
                }
                else
                {
                    target.Add(new XElement(ns + map.t.Property, map.s.Value));
                }

                maps.RemoveAll(m => m.s == map.s || m.t == map.t);
            }
        }
    }
}
