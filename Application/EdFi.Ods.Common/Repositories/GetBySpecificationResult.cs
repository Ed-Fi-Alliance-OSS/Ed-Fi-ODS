// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Repositories
{
    public class GetBySpecificationResult<TEntity>
        where TEntity : IHasIdentifier
    {
        public IList<TEntity> Results { get; set; }

        public ResultMetadata ResultMetadata { get; set; }
    }

    public class ResultMetadata
    {
        public long TotalCount { get; set; }

        public string CurrentPage { get; set; }

        public string NextPage { get; set; }

        public string PreviousPage { get; set; }
    }
}
