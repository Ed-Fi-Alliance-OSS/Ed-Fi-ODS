// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.NHibernate.Architecture.Criteria
{
    /// <summary>
    /// Defines methods for saving and subsequently accessing functions that apply filter criteria to queries using the <see cref="ICriteria"/> API.
    /// </summary>
    public interface IFilterCriteriaApplicatorProvider
    {
        /// <summary>
        /// Adds the supplied <see cref="ICriteria"/> applicator for the specified filter name and entity.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="entityType">The entity to which the filter applies.</param>
        /// <param name="criteriaApplicator">The function that applies the filter's criteria to the <see cref="ICriteria"/> instance.</param>
        void AddCriteriaApplicator(string filterName, Type entityType, Action<ICriteria, Junction, IDictionary<string, object>, JoinType> criteriaApplicator);

        /// <summary>
        /// Attempts to retrieve the applicator functions for the specified filter name and entity.
        /// </summary>
        /// <param name="filterName">The name of the filter.</param>
        /// <param name="entityType">The entity being queried.</param>
        /// <param name="criteriaApplicators">The function that applies the filter's criteria to the <see cref="ICriteria"/> instance.</param>
        /// <returns><b>true</b> if an applicator was found; otherwise <b>false</b>.</returns>
        bool TryGetCriteriaApplicator(string filterName, Type entityType, out IReadOnlyList<Action<ICriteria, Junction, IDictionary<string, object>, JoinType>> criteriaApplicators);
    }
}