// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;

namespace EdFi.LoadTools.Engine.Mapping
{
    public class DescriptorReferenceMetadataMapper : IMetadataMapper
    {
        public void CreateMetadataMappings(MetadataMapping mapping, List<ModelMetadata> sourceModels,
                                           List<ModelMetadata> targetModels)
        {
            var xModels = sourceModels
                         .Where(x => x.TypeName != null && x.TypeName.EndsWith("DescriptorReferenceType"))
                         .Select(
                              x => new
                                   {
                                       model = x, properties = sourceModels.Where(
                                           y =>
                                               y.Model == x.Type && y.PropertyPath.StartsWith(x.PropertyPath))
                                   })
                         .ToList();

            var jModels = targetModels.Where(
                j =>
                    j.Property.EndsWith("descriptor", StringComparison.InvariantCultureIgnoreCase) &&
                    j.Type == Constants.JsonTypes.String).ToList();

            var maps = xModels.SelectMany(
                                   x => jModels.Select(
                                       j =>
                                           new
                                           {
                                               x, j, m = ExtensionMethods.PropertyPathPercentMatchTo(x.model.PropertyPath, j.PropertyPath)
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
                        SourceName = map.x.model.PropertyPath, SourceType = map.x.model.Type, TargetName = map.j.PropertyPath,
                        TargetType = map.j.Type, IsArray = map.x.model.IsArray,
                        MappingStrategy = new DescriptorReferenceTypeToStringMappingStrategy()
                    });

                mapping.Properties.AddRange(
                    map.x.properties.Select(
                        p =>
                            new PropertyMapping
                            {
                                SourceName = p.PropertyPath, SourceType = p.Type, TargetName = "{none}", TargetType = "{none}",
                                IsArray = p.IsArray, MappingStrategy = new NoOperationMappingStrategy()
                            }));

                sourceModels.RemoveAll(x => x == map.x.model || map.x.properties.Any(p => p == x));
                targetModels.RemoveAll(j => j == map.j);

                maps.RemoveAll(m => m.x == map.x || m.j == map.j);
            }
        }
    }
}
