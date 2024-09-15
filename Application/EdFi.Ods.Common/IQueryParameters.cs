// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common
{
    public interface IQueryParameters
    {
        /// <summary>
        /// The number of items to skip before including items in the results. Used with offset paging.
        /// </summary>
        int? Offset { get; set; }

        /// <summary>
        /// The maximum number of items to be returned in the results. Used with both offset and keyset paging.
        /// </summary>
        int? Limit { get; set; }

        /// <summary>
        /// Indicates whether the total count of the available items should be returned.
        /// </summary>
        bool TotalCount { get; set; }

        /// <summary>
        /// The minimum ChangeVersion value on resource items to be included in the results.
        /// </summary>
        long? MinChangeVersion { get; set; }

        /// <summary>
        /// The maximum ChangeVersion value on resource items to be included in the results.
        /// </summary>
        long? MaxChangeVersion { get; set; }

        string Q { get; set; }

        List<IQueryCriteriaBase> QueryCriteria { get; set; }

        /// <summary>
        /// The inclusive minimum AggregateId to be applied to the query. Used with keyset paging.
        /// </summary>
        int? MinAggregateId { get; set; }

        /// <summary>
        /// The inclusive maximum AggregateId to be applied to the query. Used with keyset paging.
        /// </summary>
        int? MaxAggregateId { get; set; }
    }
}
