// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Filtering;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    public class ViewFilterApplicationDetails : FilterApplicationDetails
    {
        public ViewFilterApplicationDetails(
            string filterName,
            string viewName,
            string viewSourceEndpointName,
            string viewTargetEndpointName,
            string subjectEndpointName = null)
            : base(
                filterName,
                $@"{subjectEndpointName ?? viewTargetEndpointName} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointName} 
                    FROM auth.{viewName} {{newAlias1}} 
                    WHERE {{newAlias1}}.{viewSourceEndpointName} IN (:SourceEducationOrganizationId))", // TODO: Rename to :ClaimEducationOrganizationIds 
                $@"{{currentAlias}}.{subjectEndpointName ?? viewTargetEndpointName} IN (
                    SELECT {{newAlias1}}.{viewTargetEndpointName} 
                    FROM " + GetFullNameForView($"auth_{viewName}") + $@" {{newAlias1}} 
                    WHERE {{newAlias1}}.{viewSourceEndpointName} IN (:ClaimEducationOrganizationIds))",
                (c, w, p, jt) => c.ApplyJoinFilter(
                    w,
                    p,
                    viewName,
                    subjectEndpointName ?? viewTargetEndpointName,
                    viewTargetEndpointName,
                    viewSourceEndpointName,
                    jt,
                    Guid.NewGuid().ToString("N")),
                (t, p) => p.HasPropertyNamed(subjectEndpointName ?? viewTargetEndpointName))
        {
            FilterName = filterName;
            ViewName = viewName;
            ViewSourceEndpointName = viewSourceEndpointName;
            ViewTargetEndpointName = viewTargetEndpointName;
            SubjectEndpointName = subjectEndpointName ?? viewTargetEndpointName;
        }

        public string FilterName { get; }

        public string ViewName { get; }

        public string ViewSourceEndpointName { get; }

        public string ViewTargetEndpointName { get; }

        public string SubjectEndpointName { get; }

        private static string GetFullNameForView(string viewName)
        {
            return Namespaces.Entities.NHibernate.QueryModels.GetViewNamespace(viewName);
        }
    }
}
