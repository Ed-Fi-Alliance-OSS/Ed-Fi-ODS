// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common
{
    public interface IQueryParameters
    {
        int? Offset { get; set; }

        int? Limit { get; set; }

        bool TotalCount { get; set; }

        long? MinChangeVersion { get; set; }

        long? MaxChangeVersion { get; set; }

        string Q { get; set; }

        List<IQueryCriteriaBase> QueryCriteria { get; set; }
    }
}
