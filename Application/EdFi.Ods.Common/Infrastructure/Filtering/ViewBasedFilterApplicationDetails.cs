// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using SqlKata;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    public class ViewBasedFilterApplicationDetails : FilterApplicationDetails
    {
        public ViewBasedFilterApplicationDetails(
            string filterName,
            string friendlyDefaultConditionFormat,
            string friendlyHqlConditionFormat,
            Action<ICriteria, Junction, IDictionary<string, object>, JoinType> criteriaApplicator,
            Action<FilterApplicationDetails, AuthorizationFilterDetails, Resource, int, Query> trackedChangesCriteriaApplicator,
            Func<Type, PropertyInfo[], bool> shouldApply,
            string viewName,
            string viewTargetEndpointName,
            string subjectEndpointName)
            : base(
                filterName,
                friendlyDefaultConditionFormat,
                friendlyHqlConditionFormat,
                criteriaApplicator,
                trackedChangesCriteriaApplicator,
                shouldApply)
        {
            ViewName = viewName;
            ViewTargetEndpointName = viewTargetEndpointName;
            SubjectEndpointName = subjectEndpointName;
        }

        public string ViewName { get; }

        public string ViewTargetEndpointName { get; }

        public string SubjectEndpointName { get; }
    }
}
