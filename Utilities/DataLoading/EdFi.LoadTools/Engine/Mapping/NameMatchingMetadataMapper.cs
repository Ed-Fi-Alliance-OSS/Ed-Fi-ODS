// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using log4net;

namespace EdFi.LoadTools.Engine.Mapping
{
    /// <summary>
    ///     Copy values when attribute types and cardinality are the same
    /// </summary>
    public class NameMatchingMetadataMapper : IMetadataMapper
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(NameMatchingMetadataMapper));

        public void CreateMetadataMappings(MetadataMapping mapping, List<ModelMetadata> sourceModels,
            List<ModelMetadata> targetModels)
        {
            _logger.Debug($"mapping {mapping.RootName} from {mapping.SourceName} to {mapping.TargetName}");

            var maps = sourceModels.SelectMany(
                x => targetModels.Select(
                    j => new
                    {
                        x,
                        j,
                        m = x.IsSimpleType && j.IsSimpleType &&
                            (ExtensionMethods.AreMatchingSimpleTypes(j.Type, x.Type) ||
                             ExtensionMethods.AreMatchingDateTypes(j.Format, x.Type))
                            ? ExtensionMethods.PropertyPathPercentMatchTo(x.PropertyPath, j.PropertyPath)
                            : 0
                    })).Where(o => o.m > 0.001).OrderByDescending(o => o.m).ToList();

            while (maps.Count > 0)
            {
                var map = maps.First();
                MappingStrategy strategy = new CopySimplePropertyMappingStrategy();

                if (map.x.Type == Constants.XmlTypes.Token && map.j.Type == Constants.JsonTypes.Integer &&
                    map.x.Property.EndsWith("SchoolYear"))
                {
                    strategy = new SchoolYearPropertyMappingStrategy();
                }

                if (map.x.Type == Constants.XmlTypes.Boolean && map.j.Type == Constants.JsonTypes.Boolean)
                {
                    strategy = new BooleanPropertyMappingStrategy();
                }

                mapping.Properties.Add(
                    new PropertyMapping
                    {
                        SourceName = map.x.PropertyPath,
                        SourceType = map.x.Type,
                        TargetName = map.j.PropertyPath,
                        TargetType = map.j.Type,
                        IsArray = map.x.IsArray,
                        MappingStrategy = strategy
                    });

                maps.RemoveAll(m => m.j.PropertyPath == map.j.PropertyPath || m.x.PropertyPath == map.x.PropertyPath);
            }
        }
    }
}
