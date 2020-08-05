// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using EdFi.LoadTools.Engine.Mapping;
using log4net;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class MapResourceToIdentityStep : ILookupPipelineStep
    {
        private readonly MetadataMapping[] _mappings;

        // ReSharper disable once InconsistentNaming
        private readonly ILog Log;

        public MapResourceToIdentityStep(IMetadataMappingFactory metadataMappingFactory)
        {
            _mappings = metadataMappingFactory.GetMetadataMappings().ToArray();
            Log = LogManager.GetLogger(GetType().Name);
        }

        public Task<bool> Process(XmlLookupWorkItem item)
        {
            if (item.IdentityXElement != null)
            {
                return Task.FromResult(true);
            }

            var map = _mappings.SingleOrDefault(m => m.RootName == item.ResourceName);

            if (map == null)
            {
                Log.Warn($"No mappings for {item.ResourceName} ");
                return Task.FromResult(false);
            }

            var targetXElement = new XElement(item.IdentityName);

            foreach (var element in item.ResourceXElement.Elements())
            {
                var path = element.Name.LocalName;
                PerformElementReverseMapping(map, element, path, targetXElement);
            }

            item.IdentityXElement = targetXElement;
            return Task.FromResult(true);
        }

        private void PerformElementReverseMapping(MetadataMapping map, XElement sourceElement, string path,
                                                  XElement targetElement)
        {
            var propertyMappings = map.Properties.Where(p => p.TargetName == path);

            foreach (var mapping in propertyMappings)
            {
                mapping.MappingStrategy.ReverseMapElement(sourceElement, mapping.SourceName, targetElement);
            }

            foreach (var ele in sourceElement.Elements())
            {
                PerformElementReverseMapping(map, ele, $"{path}/{ele.Name.LocalName}", targetElement);
            }
        }
    }
}
