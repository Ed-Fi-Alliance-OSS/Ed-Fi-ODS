// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine.Mapping;

namespace EdFi.LoadTools.Engine.MappingFactories
{
    public class LookupToIdentityMetadataMappingFactory : IMetadataMappingFactory
    {
        private readonly Regex _lookupTypeRegex = new Regex(Constants.LookupTypeRegex);
        private readonly NameMatchingMetadataMapper _metadataMapper;
        private readonly XmlModelMetadata[] _xmlMetadata;

        public LookupToIdentityMetadataMappingFactory(
            IEnumerable<XmlModelMetadata> xmlMetadata,
            NameMatchingMetadataMapper metadataMapper)
        {
            _xmlMetadata = xmlMetadata
                          .Where(x => !x.Type.EndsWith("ReferenceType"))
                          .ToArray();

            _metadataMapper = metadataMapper;
        }

        public IEnumerable<MetadataMapping> GetMetadataMappings()
        {
            var lookupTypeNames = _xmlMetadata.Select(x => x.Type).Distinct().Where(x => _lookupTypeRegex.IsMatch(x));

            var mappings = lookupTypeNames.Select(
                x =>
                {
                    var typeName = _lookupTypeRegex.Match(x).Groups["TypeName"].Value;

                    return new MetadataMapping
                           {
                               RootName = typeName, SourceName = x, TargetName = typeName + "IdentityType"
                           };
                }).ToArray();

            foreach (var metadataMapping in mappings)
            {
                CreateMetadataMappings(metadataMapping);
            }

            return mappings;
        }

        private void CreateMetadataMappings(MetadataMapping mapping)
        {
            var xmlSourceModels = new List<ModelMetadata>();
            MetadataMappingFactoryBase.PopulateModelMetadata(_xmlMetadata, xmlSourceModels, mapping.SourceName);

            var xmlTargetModels = new List<ModelMetadata>();
            MetadataMappingFactoryBase.PopulateModelMetadata(_xmlMetadata, xmlTargetModels, mapping.TargetName);

            _metadataMapper.CreateMetadataMappings(mapping, xmlSourceModels, xmlTargetModels);
        }
    }
}
