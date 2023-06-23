// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Specifications;

public class PersonTypesProvider : IPersonTypesProvider
{
    private readonly Lazy<string[]> _validPersonTypes;

    public PersonTypesProvider(IDomainModelProvider domainModelProvider)
    {
        _validPersonTypes = new(() => domainModelProvider.GetDomainModel()
            .GetPersonEntities()
            .Select(e => e.Name).ToArray());
    }

    /// <inheritdoc cref="IPersonTypesProvider.PersonTypes" />
    public string[] PersonTypes
    {
        get => _validPersonTypes.Value;
    }
}
