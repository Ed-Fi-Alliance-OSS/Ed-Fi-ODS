// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.NHibernate.Architecture.Criteria
{
    /// <summary>
    /// Provides methods for saving and subsequently accessing functions that apply filter criteria to queries using the <see cref="ICriteria"/> API.
    /// </summary>
    public class FilterCriteriaApplicatorProvider : IFilterCriteriaApplicatorProvider
    {
        private readonly ConcurrentDictionary<Tuple<string, Type>, IReadOnlyList<Action<ICriteria, Junction, IDictionary<string, object>, JoinType>>> _applicatorsByEntityType =
            new ConcurrentDictionary<Tuple<string, Type>, IReadOnlyList<Action<ICriteria, Junction, IDictionary<string, object>, JoinType>>>();

        /// <summary>
        /// Adds the supplied <see cref="ICriteria"/> applicator for the specified filter name and entity.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="entityType">The entity to which the filter applies.</param>
        /// <param name="criteriaApplicator">The function that applies the filter's criteria to the <see cref="ICriteria"/> instance.</param>
        public void AddCriteriaApplicator(string filterName, Type entityType, Action<ICriteria, Junction, IDictionary<string, object>, JoinType> criteriaApplicator)
        {
            var key = Tuple.Create(filterName, entityType);

            _applicatorsByEntityType.AddOrUpdate(
                key, 
                new List<Action<ICriteria, Junction, IDictionary<string, object>, JoinType>> { criteriaApplicator },
                (k, v) => v.Concat(new [] {criteriaApplicator}).ToList());
        }

        /// <summary>
        /// Attempts to retrieve the applicator functions for the specified filter name and entity.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="entityType">The entity being queried.</param>
        /// <param name="criteriaApplicators">The functions that apply the filter's criteria to the <see cref="ICriteria"/> instance.</param>
        /// <returns><b>true</b> if any applicators were found; otherwise <b>false</b>.</returns>
        public bool TryGetCriteriaApplicator(string filterName, Type entityType, out IReadOnlyList<Action<ICriteria, Junction, IDictionary<string, object>, JoinType>> criteriaApplicators)
        {
            var key = Tuple.Create(filterName, entityType);

            return _applicatorsByEntityType.TryGetValue(key, out criteriaApplicators);
        }
    }
}