// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine.Mapping;
using RestSharp.Extensions;

namespace EdFi.LoadTools.Engine.MappingFactories
{
    public class LookupToGetByExampleMetadataMappingFactory : MetadataMappingFactoryBase
    {
        private readonly Regex _lookupTypeRegex = new Regex(Constants.LookupTypeRegex);

        public LookupToGetByExampleMetadataMappingFactory(
            List<XmlModelMetadata> xmlMetadata,
            List<JsonModelMetadata> jsonMetadata,
            List<IMetadataMapper> mappingStrategies)
            : base(xmlMetadata, jsonMetadata, mappingStrategies) { }

        protected override IList<XmlModelMetadata> FilteredXmlMetadata => XmlMetadata.Where(x => !x.Type.EndsWith("LookupType")).ToList();

        protected override IEnumerable<MetadataMapping> CreateMappings()
        {
            Log.Info("Creating XSD Lookup to Json data mappings");
            var typeNames = XmlMetadata.Select(x => x.Type).Distinct().Where(x => _lookupTypeRegex.IsMatch(x));

            var mappings = typeNames.Select(
                x => new MetadataMapping
                     {
                         RootName = _lookupTypeRegex.Match(x).Groups["TypeName"].Value, SourceName = x, TargetName =
                             $"edFi_{_lookupTypeRegex.Match(x).Groups["TypeName"].Value.ToCamelCase(CultureInfo.CurrentCulture)}"
                     }).ToArray();

            return mappings;
        }
    }
}
