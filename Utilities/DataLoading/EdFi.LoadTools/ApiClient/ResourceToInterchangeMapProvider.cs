// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.ApiClient
{
    public class ResourceToInterchangeMapProvider
    {
        private XmlSchemaSet _xmlSchemaSet;

        private readonly Dictionary<string, List<InterchangeInfo>> _resourceToInterchangeDictionary = new Dictionary<string, List<InterchangeInfo>>();
        private readonly IResourceStreamFactory _resourceStreamFactory;

        public ResourceToInterchangeMapProvider(XmlSchemaSet xmlSchemaSet, IResourceStreamFactory resourceStreamFactory)
        {
            _xmlSchemaSet = xmlSchemaSet;
            _resourceStreamFactory = resourceStreamFactory;
        }

        public Dictionary<string, List<InterchangeInfo>> GetResourceToInterchangeMap()
        {
            var interchangeToInterchangeFilesMap = _resourceStreamFactory.GetInterchangeToInterchangeFilesMap();

            foreach (XmlSchema schema in _xmlSchemaSet.Schemas())
            {
                foreach (XmlSchemaElement element in schema.Elements.Values)
                {
                    var interchangeName = element.Name;

                    var resources = element.ElementSchemaType.GetUnorderedElementNames().ToList();

                    resources.ForEach(r =>
                    {
                        var resource = r.ToLower();

                        if (!_resourceToInterchangeDictionary.TryGetValue(resource, out List<InterchangeInfo> interchangeInfoList))
                        {
                            interchangeInfoList = _resourceToInterchangeDictionary[resource] = new List<InterchangeInfo>();
                        }

                        if (!interchangeToInterchangeFilesMap.TryGetValue(interchangeName, out List<string> interchangeFileNames))
                        {
                            interchangeFileNames = new List<string>();
                        }

                        interchangeInfoList.Add(new InterchangeInfo
                        {
                            Name = interchangeName,
                            InterchangeFileNames = interchangeFileNames
                        });
                    });
                }
            }

            return _resourceToInterchangeDictionary;
        }
    }

    public class InterchangeInfo
    {
        public string Name { get; set; }
        public List<string> InterchangeFileNames { get; set; } = new List<string>();
    }
}
