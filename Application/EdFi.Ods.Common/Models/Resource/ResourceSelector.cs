// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Models.Resource
{
    public class ResourceSelector : IResourceSelector
    {
        private readonly IDictionary<FullName, Resource> _resourceByFullName;

        public ResourceSelector(IDictionary<FullName, Resource> resourceByFullName)
        {
            _resourceByFullName = resourceByFullName;
        }

        public IReadOnlyList<Resource> GetAll()
        {
            return _resourceByFullName.Values.ToList();
        }

        public Resource GetByName(FullName fullName)
        {
            return _resourceByFullName.GetValueOrThrow(fullName, "FullName {0} was not located in ResourceSelector.");
        }

        public Resource GetBySchemaProperCaseNameAndName(string properCaseName, string name)
        {
            return _resourceByFullName.GetValueOrThrow(new FullName(properCaseName, name), "Resource '{0}' not found.");
        }
    }
}
