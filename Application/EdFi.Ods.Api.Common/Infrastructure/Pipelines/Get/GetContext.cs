// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Get
{
    public class GetContext<TEntityModel> : IHasPersistentModel<TEntityModel>, IHasETag, IHasIdentifier
        where TEntityModel : class
    {
        public GetContext(Guid id, string etag)
        {
            Id = id;
            ETag = etag;
        }

        public string ETag { get; set; }

        public Guid Id { get; set; }

        public TEntityModel PersistentModel { get; set; }
    }
}
