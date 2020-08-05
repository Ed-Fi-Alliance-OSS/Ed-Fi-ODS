// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using EdFi.LoadTools.Engine.Mapping;
using log4net;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    /// <summary>
    ///     If they've provided the required Identity values in the Lookup, just map them directly
    /// </summary>
    public class DirectLookupToIdentityMappingStep : ILookupPipelineStep
    {
        private readonly MetadataMapping[] _mappings;

        // ReSharper disable once InconsistentNaming
        private readonly ILog Log;

        public DirectLookupToIdentityMappingStep(IMetadataMappingFactory metadataMappingFactory)
        {
            _mappings = metadataMappingFactory.GetMetadataMappings().ToArray();
            Log = LogManager.GetLogger(GetType().Name);
        }

        public Task<bool> Process(XmlLookupWorkItem item)
        {
            if (item.IdentityXElement != null)
            {
                return Task.FromResult(true);
            }

            var map = _mappings.SingleOrDefault(m => m.RootName == item.ResourceName);

            if (map == null)
            {
                Log.Warn($"No mappings for {item.ResourceName} ");
                return Task.FromResult(false);
            }

            if (LookupHasAllValuesInMap(item.LookupXElement, map))
            {
                var identityXElement = new XElement(item.IdentityName);

                foreach (var element in item.LookupXElement.Elements())
                {
                    var mapping = map.Properties.SingleOrDefault(x => x.SourceName == element.Name.LocalName);
                    mapping?.MappingStrategy.MapElement(element, mapping.SourceName, identityXElement);
                }

                item.IdentityXElement = identityXElement;
            }

            return Task.FromResult(true);
        }

        private static bool LookupHasAllValuesInMap(XElement lookupXElement, MetadataMapping map)
        {
            var ns = lookupXElement.Name.Namespace;

            return map.Properties
                      .Select(propertyMapping => lookupXElement.Element(ns + propertyMapping.SourceName))
                      .All(xElement => xElement != null && !xElement.IsEmpty);
        }
    }
}
