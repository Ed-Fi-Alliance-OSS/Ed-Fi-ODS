// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine.Mapping;
using log4net;

namespace EdFi.LoadTools.Engine.MappingFactories
{
    public abstract class MetadataMappingFactoryBase : IMetadataMappingFactory
    {
        protected readonly List<JsonModelMetadata> JsonMetadata;
        protected readonly ILog Log;
        protected readonly IEnumerable<IMetadataMapper> MappingStrategies;
        protected readonly List<XmlModelMetadata> XmlMetadata;

        protected MetadataMappingFactoryBase(
            IEnumerable<XmlModelMetadata> xmlMetadata,
            IEnumerable<JsonModelMetadata> jsonMetadata,
            IEnumerable<IMetadataMapper> mappingStrategies)
        {
            Log = LogManager.GetLogger(GetType().Name);
            MappingStrategies = mappingStrategies;
            JsonMetadata = jsonMetadata.ToList();
            XmlMetadata = xmlMetadata.ToList();
        }

        protected virtual IList<XmlModelMetadata> FilteredXmlMetadata => XmlMetadata;

        protected virtual IList<JsonModelMetadata> FilteredJsonMetadata => JsonMetadata;

        public IEnumerable<MetadataMapping> GetMetadataMappings()
        {
            var mappings = CreateMappings().ToArray();

            foreach (var mapping in mappings)
            {
                CreateMetadataMappings(mapping);
            }

            return mappings;
        }

        protected abstract IEnumerable<MetadataMapping> CreateMappings();

        private void CreateMetadataMappings(MetadataMapping mapping)
        {
            var xmlModels = new List<ModelMetadata>();
            PopulateModelMetadata(FilteredXmlMetadata, xmlModels, mapping.SourceName);

            var jsonModels = new List<ModelMetadata>();
            PopulateModelMetadata(FilteredJsonMetadata, jsonModels, mapping.TargetName);

            foreach (var strategy in MappingStrategies)
            {
                strategy.CreateMetadataMappings(mapping, xmlModels, jsonModels);
            }
        }

        // ReSharper disable once ParameterTypeCanBeEnumerable.Local
        public static void PopulateModelMetadata<T>(IList<T> metadata, ICollection<ModelMetadata> models, string type,
                                                    string prefix = "")
            where T : ModelMetadata
        {
            //var foo = metadata.Select(x => x.Model).Distinct().OrderBy(x => x);

            var items = metadata
                       .Where(m => m.Model == type)
                       .Select(
                            m => new ModelMetadata
                                 {
                                     Model = m.Model, Property = m.Property, Type = m.Type, TypeName = m.TypeName, Format = m.Format,
                                     IsArray = m.IsArray, IsRequired = m.IsRequired, IsSimpleType = m.IsSimpleType, PropertyPath =
                                         string.IsNullOrEmpty(prefix)
                                             ? m.Property
                                             : $"{prefix}/{m.Property}"
                                 })
                       .ToArray();

            foreach (var item in items)
            {
                models.Add(item);

                if (!item.IsSimpleType)
                {
                    PopulateModelMetadata(metadata, models, item.Type, item.PropertyPath);
                }
            }
        }
    }
}
