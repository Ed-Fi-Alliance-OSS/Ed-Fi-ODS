// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Models.Definitions;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Models
{
    public class DomainModelDefinitionsJsonEmbeddedResourceProvider : IDomainModelDefinitionsProvider
    {
        private readonly Assembly _sourceAssembly;

        public DomainModelDefinitionsJsonEmbeddedResourceProvider(Assembly sourceAssembly)
        {
            _sourceAssembly = sourceAssembly;
        }

        public DomainModelDefinitions GetDomainModelDefinitions()
        {
            var resourceName = _sourceAssembly.GetManifestResourceNames()
                                              .SingleOrDefault(rn => rn.EndsWith("ApiModel.json") || rn.EndsWith("ApiModel-EXTENSION.json"));

            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new Exception(
                    $"The supplied assembly '{_sourceAssembly.FullName}' did not contain the expected embedded resource for ApiModel.json or ApiModel-EXTENSION.json.  Unable to load domain model definitions.");
            }

            string json;

            using (var stream = _sourceAssembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
            }

            var domainModelDefinitions = JsonConvert.DeserializeObject<DomainModelDefinitions>(json);

            if (domainModelDefinitions == null)
            {
                throw new Exception("Unable to deserialize Domain Model from embedded resource.  Unable to load domain model definitions.");
            }

            return domainModelDefinitions;
        }
    }
}
