// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Tests.EdFi.Ods.Common._Stubs.Repositories;

namespace EdFi.Ods.Tests._Builders
{
    public static class New
    {
        public static StubRepositoryBuilder<TEntity> StubRepository<TEntity>()
            where TEntity : IHasIdentifier, IDateVersionedEntity
        {
            return new StubRepositoryBuilder<TEntity>();
        }
    }
}
