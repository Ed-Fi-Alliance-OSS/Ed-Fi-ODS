// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Common.Dtos;

namespace EdFi.Ods.Api.Common.Infrastructure.Extensibility
{
    public interface IEntityExtensionsFactory
    {
        IDictionary<string, object> CreateRequiredEntityExtensions<TEntity>(object parentEntity)
            where TEntity : EntityWithCompositeKey;

        IDictionary<string, object> CreateAggregateExtensions<TEntity>()
            where TEntity : EntityWithCompositeKey;
    }
}
