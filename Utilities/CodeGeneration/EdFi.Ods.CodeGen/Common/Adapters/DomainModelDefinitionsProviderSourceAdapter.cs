// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Generator.Common.Database.Domain;

namespace EdFi.Ods.CodeGen.Common.Adapters;

/// <summary>
/// Adapts the existing CodeGeneration utility's use of <see cref="IDomainModelDefinitionsProviderProvider" /> class with the similarly
/// defined <see cref="IDomainModelDefinitionsProviderSource" /> interface from the general purpose generator utility code.
/// </summary>
public class DomainModelDefinitionsProviderSourceAdapter : IDomainModelDefinitionsProviderSource
{
    private readonly IDomainModelDefinitionsProviderProvider _domainModelDefinitionsProviderProvider;

    public DomainModelDefinitionsProviderSourceAdapter(
        IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider)
    {
        _domainModelDefinitionsProviderProvider = domainModelDefinitionsProviderProvider;
    }

    public IEnumerable<IDomainModelDefinitionsProvider> GetDomainModelDefinitionProviders()
        => _domainModelDefinitionsProviderProvider.DomainModelDefinitionProviders();
}
