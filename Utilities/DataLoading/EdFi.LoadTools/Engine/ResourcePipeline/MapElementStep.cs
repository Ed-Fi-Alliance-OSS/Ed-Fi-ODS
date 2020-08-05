// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Xml.Linq;
using EdFi.LoadTools.Engine.Mapping;

namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    public class MapElementStep : IResourcePipelineStep
    {
        private readonly MetadataMapping[] _mappings;

        public MapElementStep(IMetadataMappingFactory metadataMappingFactory)
        {
            _mappings = metadataMappingFactory.GetMetadataMappings().ToArray();
        }

        public bool Process(ApiLoaderWorkItem resourceWorkItem)
        {
            var values = new[]
                         {
                             $"{resourceWorkItem.ElementName}Extension", resourceWorkItem.ElementName
                         };

            var map = _mappings.SingleOrDefault(m => values.Contains(m.SourceName));

            if (map == null)
            {
                return false;
            }

            var jsonXElement = new XElement(map.TargetName);

            foreach (var element in resourceWorkItem.XElement.Elements())
            {
                var path = element.Name.LocalName;
                PerformElementMapping(map, element, path, jsonXElement);
            }

            resourceWorkItem.SetJsonXElement(jsonXElement);

            return true;
        }

        private void PerformElementMapping(MetadataMapping map, XElement element, string path, XElement jsonXElement)
        {
            var propertyMappings = map.Properties.Where(p => p.SourceName == path);

            foreach (var mapping in propertyMappings)
            {
                mapping.MappingStrategy.MapElement(element, mapping.TargetName, jsonXElement);
            }

            foreach (var ele in element.Elements())
            {
                PerformElementMapping(map, ele, $"{path}/{ele.Name.LocalName}", jsonXElement);
            }
        }
    }
}
