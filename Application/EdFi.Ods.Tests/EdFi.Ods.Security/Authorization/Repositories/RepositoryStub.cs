// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization.Repositories
{
    public class RepositoryStub<T> : IGetEntityById<T>
        where T : IHasIdentifier, IDateVersionedEntity
    {
        private readonly T suppliedEntity;

        public RepositoryStub(T suppliedEntity)
        {
            this.suppliedEntity = suppliedEntity;
        }

        public bool GetByIdCalled { get; set; }

        public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            GetByIdCalled = true;

            return Task.FromResult(suppliedEntity);
        }
    }
}
