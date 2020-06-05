// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Common.Providers
{
    public class EdFiDescriptorReflectionProvider : IEdFiDescriptorReflectionProvider
    {
        private readonly Lazy<IDictionary<string, string>> _descriptorEntityTypeFullNameByEntityName;
        private readonly IDomainModelProvider _domainModelProvider;

        public EdFiDescriptorReflectionProvider(IDomainModelProvider domainModelProvider)
        {
            _domainModelProvider = domainModelProvider;
            _descriptorEntityTypeFullNameByEntityName = new Lazy<IDictionary<string, string>>(LazyInitializeDescriptorEntityTypeFullNameByEntityName);
        }

        public IDictionary<string, string> GetDescriptorEntityNameMapping()
        {
            return _descriptorEntityTypeFullNameByEntityName.Value;
        }

        private IDictionary<string, string> LazyInitializeDescriptorEntityTypeFullNameByEntityName()
        {
            return _domainModelProvider.GetDomainModel()
                                       .Entities.Where(e => e.IsDescriptorEntity)
                                       .ToDictionary(
                                            k => k.Name,
                                            v => v.EntityTypeFullName(v.SchemaProperCaseName()));
        }
    }
}
