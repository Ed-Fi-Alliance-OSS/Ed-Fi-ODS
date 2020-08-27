// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine.Mapping;

namespace EdFi.LoadTools.Engine.MappingFactories
{
    public class ResourceToResourceMetadataMappingFactory : MetadataMappingFactoryBase
    {
        public ResourceToResourceMetadataMappingFactory(
            IEnumerable<XmlModelMetadata> xmlMetadata,
            IEnumerable<JsonModelMetadata> jsonMetadata,
            IEnumerable<IMetadataMapper> mappingStrategies)
            : base(xmlMetadata, jsonMetadata, mappingStrategies) { }

        protected override IEnumerable<MetadataMapping> CreateMappings()
        {
            Log.Info("Creating XSD to Json data mappings");
            var mappings = new List<MetadataMapping>();

            var jsonModels = JsonMetadata.Select(x => x.Model).Distinct()
                                         .Where(x => !JsonMetadata.Select(y => y.Type).Contains(x) && !string.IsNullOrEmpty(x))
                                         .ToArray();

            var xmlModels = XmlMetadata.Select(x => x.Model).Distinct()
                                       .Where(x => !XmlMetadata.Select(y => y.Type).Contains(x))
                                       .ToArray();

            var maps = xmlModels.SelectMany(
                x => jsonModels.Select(
                    j =>
                        new
                        {
                            x, j, m = x.PercentMatchTo(j)
                        }
                )).OrderByDescending(o => o.m).ToList();

            while (maps.Count > 0)
            {
                var map = maps.First();

                // Useful if you want to only look at one mapping
                //if (map.x == "Account")
                //{
                mappings.Add(
                    new MetadataMapping
                    {
                        SourceName = map.x, TargetName = map.j, RootName = map.x
                    });

                //}
                maps.RemoveAll(x => x.x == map.x || x.j == map.j);
            }

            return mappings;
        }
    }
}
