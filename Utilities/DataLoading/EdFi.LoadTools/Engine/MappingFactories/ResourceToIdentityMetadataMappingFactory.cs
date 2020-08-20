// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine.Mapping;
using EdFi.Ods.Common.Inflection;

namespace EdFi.LoadTools.Engine.MappingFactories
{
    public class ResourceToIdentityMetadataMappingFactory : MetadataMappingFactoryBase
    {
        private readonly Regex _typeRegex = new Regex(Constants.IdentityTypeRegex);

        public ResourceToIdentityMetadataMappingFactory(
            IEnumerable<XmlModelMetadata> xmlMetadata,
            IEnumerable<JsonModelMetadata> jsonMetadata,
            IEnumerable<IMetadataMapper> mappingStrategies)
            : base(xmlMetadata, jsonMetadata, mappingStrategies) { }

        protected override IList<XmlModelMetadata> FilteredXmlMetadata => XmlMetadata.Where(x => !x.Type.EndsWith("ReferenceType")).ToList();

        protected override IEnumerable<MetadataMapping> CreateMappings()
        {
            Log.Info("Creating XSD Resource to Json Identity data mappings");
            var typeNames = XmlMetadata.Select(x => x.Type).Distinct().Where(x => _typeRegex.IsMatch(x));

            var mappings = typeNames.Select(
                x =>
                {
                    var typeName = _typeRegex.Match(x).Groups["TypeName"].Value;

                    return new MetadataMapping
                           {
                               RootName = typeName, SourceName = x, //xml
                               TargetName = Inflector.MakeInitialLowerCase(typeName) //json
                           };
                }).ToArray();

            return mappings;
        }
    }
}
