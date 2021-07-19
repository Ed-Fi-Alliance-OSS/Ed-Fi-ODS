// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Models.Domain
{
    public class DomainModelProvider : IDomainModelProvider
    {
        private readonly Lazy<DomainModel> _domainModel;

        public DomainModelProvider(
            IEnumerable<IDomainModelDefinitionsProvider> domainModelDefinitionsProviders,
            IDomainModelDefinitionsTransformer[] domainModelDefinitionsTransformers)
        {
            var domainModelBuilder = new DomainModelBuilder();

            var domainModelDefinitions = domainModelDefinitionsProviders
                .Select(p => p.GetDomainModelDefinitions())
                .ToList();

            foreach (var transformer in domainModelDefinitionsTransformers)
            {
                transformer.TransformDefinitions(domainModelDefinitions);
            }
            
            domainModelBuilder.AddDomainModelDefinitionsList(domainModelDefinitions);

            _domainModel = new Lazy<DomainModel>(() => domainModelBuilder.Build());
        }

        public DomainModel GetDomainModel()
        {
            return _domainModel.Value;
        }
    }
}
