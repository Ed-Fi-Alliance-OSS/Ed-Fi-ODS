// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine.XmlLookupPipeline;
using Newtonsoft.Json.Linq;
using RestSharp.Extensions;

namespace EdFi.LoadTools.Engine
{
    public class EducationOrganizationIdentityCache : IEducationOrganizationIdentityCache
    {
        private readonly IOdsRestClient _client;
        private readonly Lazy<List<JObject>> _educationOrganizations;
        private readonly XmlSchemaSet _schemaSet;

        public EducationOrganizationIdentityCache(XmlSchemaSet schemaSet, IOdsRestClient client)
        {
            _schemaSet = schemaSet;
            _client = client;
            _educationOrganizations = new Lazy<List<JObject>>(Initialize);
        }

        public IEnumerable<int> Get(Dictionary<string, List<LookupProperty>> lookupPropertyValuesByName)
        {
            // Foreach lookup property entry, find all EdOrgs in cache which satisfy each predicate.
            return _educationOrganizations.Value.Where(
                                               e => GetPropertyPredicates(lookupPropertyValuesByName).All(p => p(e)))
                                          .Select(o => (int) o["educationOrganizationId"]);
        }

        private List<JObject> Initialize()
        {
            var educationOrganizations = new List<JObject>();

            foreach (XmlSchemaType element in _schemaSet.GlobalTypes.Values)

                // For all types derived from EducationOrganization
            {
                if (element.BaseXmlSchemaType?.Name?.Equals("EducationOrganization") ?? false)
                {
                    var offset = 0;

                    while (true)
                    {
                        // Until no results are returned, perform GetAll on type and cache response payloads.
                        var jarrayTask = Task.Run(() => GetElementJArray(element.Name, offset));
                        jarrayTask.Wait();

                        var jArray = jarrayTask.Result;

                        foreach (var jObject in jArray.Children<JObject>())
                        {
                            // Replace EducationOrganizationId with correct Id for type.  SchoolId, LocalEducationAgencyId etc.
                            var educationOrganizationId =
                                (string) jObject[$"{element.Name}Id".ToCamelCase(CultureInfo.CurrentCulture)];

                            jObject.Add(new JProperty("educationOrganizationId", educationOrganizationId));
                            jObject.Remove($"{element.Name}Id".ToCamelCase(CultureInfo.CurrentCulture));
                            educationOrganizations.Add(jObject);
                        }

                        if (jArray.Any())
                        {
                            offset += jArray.Count;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return educationOrganizations;
        }

        private async Task<JArray> GetElementJArray(string elementName, int offset)
        {
            var response = _client.GetAll(elementName, offset).Result;
            var json = await response.Content.ReadAsStringAsync();
            return JArray.Parse(json);
        }

        public IEnumerable<string> ResolveLookupProperty(string lookupPropertyName, JToken jToken)
        {
            // Recursively traverse EdOrg json and discover all property values by name.
            if (jToken.Type == JTokenType.Object)
            {
                foreach (var child in jToken.Children<JProperty>())
                {
                    if (child.Name.Replace("Descriptor", string.Empty)
                             .Equals(lookupPropertyName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        yield return child.Value.Value<string>();
                    }

                    foreach (var property in ResolveLookupProperty(lookupPropertyName, child.Value))
                    {
                        yield return property;
                    }
                }
            }
            else if (jToken.Type == JTokenType.Array)
            {
                foreach (var child in jToken.Children())
                {
                    foreach (var property in ResolveLookupProperty(lookupPropertyName, child))
                    {
                        yield return property;
                    }
                }
            }
        }

        public IList<Func<JObject, bool>> GetPropertyPredicates(
            Dictionary<string, List<LookupProperty>> lookupPropertyValuesByName)
        {
            var conditions = new List<Func<JObject, bool>>();

            foreach (var lookupProperty in lookupPropertyValuesByName)

                // For each EdOrg, resolve lookup property by name.
                // Ensure EdOrg values match lookupProperty values.
            {
                conditions.Add(
                    o => ResolveLookupProperty(lookupProperty.Key, o)
                        .OrderBy(x => x)
                        .SequenceEqual(lookupProperty.Value.Select(lp => lp.Value).OrderBy(x => x)));
            }

            return conditions;
        }
    }
}
