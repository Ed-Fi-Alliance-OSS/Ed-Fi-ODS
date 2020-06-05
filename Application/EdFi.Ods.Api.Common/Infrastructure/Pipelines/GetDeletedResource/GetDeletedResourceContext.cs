// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.GetDeletedResource
{
    public class GetDeletedResourceContext<TEntityModel> : IHasIdentifier, IHasPersistentModel<TEntityModel>
        where TEntityModel : class
    {
        public GetDeletedResourceContext(IQueryParameters queryParameters)
        {
            QueryParameters = queryParameters;
        }

        public Guid Id { get; set; }

        public TEntityModel PersistentModel { get; set; }

        public IQueryParameters QueryParameters { get; }
    }
}
