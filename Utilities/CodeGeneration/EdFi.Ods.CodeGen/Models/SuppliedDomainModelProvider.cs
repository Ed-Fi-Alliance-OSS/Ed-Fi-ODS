// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.CodeGen.Models;

/// <summary>
/// Implements a simple <see cref="IDomainModelProvider" /> that returns the instance supplied to the constructor.
/// </summary>
public class SuppliedDomainModelProvider : IDomainModelProvider
{
    private readonly DomainModel _domainModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuppliedDomainModelProvider"/> class using the supplied domain model.
    /// </summary>
    /// <param name="domainModel">The <see cref="DomainModel" /> instance to be returned from this provider.</param>
    public SuppliedDomainModelProvider(DomainModel domainModel)
    {
        _domainModel = domainModel;
    }

    /// <inheritdoc cref="IDomainModelProvider.GetDomainModel" />
    public DomainModel GetDomainModel() => _domainModel;
}
