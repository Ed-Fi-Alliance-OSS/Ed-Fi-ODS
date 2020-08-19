// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    public class EducationOrganizationCacheLookupStep : ILookupPipelineStep
    {
        private readonly IEducationOrganizationIdentityCache _educationOrganizationIdentityCache;

        public EducationOrganizationCacheLookupStep(
            IEducationOrganizationIdentityCache educationOrganizationIdentityCache)
        {
            _educationOrganizationIdentityCache = educationOrganizationIdentityCache;
        }

        public Task<bool> Process(XmlLookupWorkItem item)
        {
            if (item.LookupXElement == null)
            {
                return Task.FromResult(true);
            }

            // Only process EdOrg Lookups
            if (!item.LookupName?.Equals("EducationOrganizationLookup") ?? true)
            {
                return Task.FromResult(true);
            }

            // Recursively build list of lookup properties for EdOrg
            var lookupProperties = GetLookupProperties(item.LookupXElement);

            // Search cache using lookup properties, grouping by name in the case of collections.
            var result = _educationOrganizationIdentityCache.Get(
                                                                 lookupProperties
                                                                    .GroupBy(p => p.Name)
                                                                    .ToDictionary(
                                                                         k => k.Key,
                                                                         v => v.ToList()))
                                                            .ToList();

            // If 0 or more than one EdOrg matches lookup, return.
            if (!result.Any() || result.Count() > 1)
            {
                return Task.FromResult(true);
            }

            item.IdentityXElement =
                new XElement(item.IdentityName, new XElement($"{item.ResourceName}Id", result.First()));

            return Task.FromResult(true);
        }

        private List<LookupProperty> GetLookupProperties(XElement lookupElement)
        {
            return lookupElement.Elements()
                                .Where(e => !e.HasElements)
                                .Select(
                                     e => new LookupProperty
                                          {
                                              Name = e.Name.LocalName, Value = e.Value
                                          })
                                .Concat(
                                     lookupElement.Elements()
                                                  .Where(e => e.HasElements)
                                                  .SelectMany(GetLookupProperties))
                                .ToList();
        }
    }

    public class LookupProperty
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
