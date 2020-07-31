// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine.Mapping
{
    public abstract class PremappedMetadataMapper : IMetadataMapper
    {
        public void CreateMetadataMappings(MetadataMapping mapping, List<ModelMetadata> sourceModels,
                                           List<ModelMetadata> targetModels)
        {
            var mappings = GetPrematchedMappings().SelectMany(
                p1 => p1.PropertyMappings.Select(
                    p2 =>
                    {
                        var xmlMap = sourceModels.SingleOrDefault(x => x.PropertyPath == p2.X);
                        var jsonMap = targetModels.SingleOrDefault(j => j.PropertyPath == p2.J);

                        if (xmlMap != null && jsonMap != null)
                        {
                            return new PropertyMapping
                                   {
                                       SourceName = xmlMap.PropertyPath, SourceType = xmlMap.Type,
                                       TargetName = jsonMap.PropertyPath, TargetType = jsonMap.Type,
                                       IsArray = xmlMap.IsArray, MappingStrategy = p1.MappingStrategy
                                   };
                        }

                        //log exception
                        return null;
                    })).Where(m => m != null).ToList();

            mapping.Properties.AddRange(mappings);

            sourceModels.RemoveAll(x => mappings.Any(m => x.PropertyPath == m.SourceName));
            targetModels.RemoveAll(j => mappings.Any(m => j.PropertyPath == m.TargetName));
        }

        protected abstract PrematchedMapping[] GetPrematchedMappings();

        protected class PropertyMap
        {
            public PropertyMap(string x, string j)
            {
                X = x;
                J = j;
            }

            public string X { get; }

            public string J { get; }
        }

        protected abstract class PrematchedMapping
        {
            protected PrematchedMapping(string x, string j, params PropertyMap[] p)
            {
                XModel = x;
                JModel = j;
                PropertyMappings = p;
            }

            public string XModel { get; }

            public string JModel { get; }

            public PropertyMap[] PropertyMappings { get; }

            public abstract IMappingStrategy MappingStrategy { get; }
        }

        protected class PrematchedMapping<T> : PrematchedMapping
            where T : IMappingStrategy, new()
        {
            public PrematchedMapping(string x, string j, params PropertyMap[] p)
                : base(x, j, p) { }

            public override IMappingStrategy MappingStrategy => new T();
        }
    }
}
