﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Repositories
{
    public interface IGetEntitiesBySpecification<TEntity>
        where TEntity : IHasIdentifier, IDateVersionedEntity
    {
        Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(
            TEntity specification,
            IQueryParameters queryParameters,
            IDictionary<string, string> additionalParameters,
            CancellationToken cancellationToken);
    }
}
