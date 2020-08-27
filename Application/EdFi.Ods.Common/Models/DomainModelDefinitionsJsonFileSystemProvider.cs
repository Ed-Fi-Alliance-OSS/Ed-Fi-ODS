// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using EdFi.Ods.Common.Models.Definitions;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Models
{
    public class DomainModelDefinitionsJsonFileSystemProvider : IDomainModelDefinitionsProvider
    {
        private readonly string _jsonPath;

        public DomainModelDefinitionsJsonFileSystemProvider(string jsonPath)
        {
            _jsonPath = jsonPath;
        }

        public DomainModelDefinitions GetDomainModelDefinitions()
        {
            var domainModelDefinitions = JsonConvert.DeserializeObject<DomainModelDefinitions>(File.ReadAllText(_jsonPath));

            if (domainModelDefinitions == null)
            {
                throw new Exception($"Unable to deserialize Domain Model from path \"{_jsonPath}\".  Unable to load domain model definitions.");
            }

            return domainModelDefinitions;
        }
    }
}
