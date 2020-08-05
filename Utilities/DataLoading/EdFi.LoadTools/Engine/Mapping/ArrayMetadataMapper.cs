// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine.Mapping
{
    public class ArrayMetadataMapper : IMetadataMapper
    {
        public void CreateMetadataMappings(MetadataMapping mapping, List<ModelMetadata> sourceModels,
                                           List<ModelMetadata> targetModels)
        {
            var xModels = sourceModels.Where(x => x.IsArray).ToArray();
            var jModels = targetModels.Where(j => j.IsArray).ToArray();

            var maps = xModels.SelectMany(
                                   x => jModels.Select(
                                       j =>
                                           new
                                           {
                                               x, j, m = ExtensionMethods.PropertyPathPercentMatchTo(x.PropertyPath, j.PropertyPath)
                                           }))
                              .Where(o => o.m > 0)
                              .OrderByDescending(o => o.m)
                              .ToList();

            while (maps.Count > 0)
            {
                var map = maps.First();

                mapping.Properties.Add(
                    new PropertyMapping
                    {
                        SourceName = map.x.PropertyPath, SourceType = map.x.Type, TargetName = map.j.PropertyPath, TargetType = map.j.Type,
                        IsArray = map.x.IsArray, MappingStrategy = new ArrayToArrayMappingStrategy()
                    });

                maps.RemoveAll(m => m.x == map.x || m.j == map.j);
            }
        }
    }
}
