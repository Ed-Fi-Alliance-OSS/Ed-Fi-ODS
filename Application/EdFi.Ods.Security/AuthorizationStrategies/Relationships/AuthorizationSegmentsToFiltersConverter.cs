// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Authorization;
using NHibernate;
using NHibernate.Metadata;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    public interface IAuthorizationSegmentsToFiltersConverter
    {
        void Convert(Type entityType, AuthorizationSegmentCollection authorizationSegments, ParameterizedFilterBuilder filterBuilder);
    }

    public class AuthorizationSegmentsToFiltersConverter : IAuthorizationSegmentsToFiltersConverter
    {
        private readonly ISessionFactory _sessionFactory;

        public AuthorizationSegmentsToFiltersConverter(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Convert(Type entityType, AuthorizationSegmentCollection authorizationSegments, ParameterizedFilterBuilder filterBuilder)
        {
            if (!authorizationSegments.ClaimsAuthorizationSegments.Any())
            {
                return;
            }

            var classMetadata = _sessionFactory.GetClassMetadata(entityType);

            var valuesByViewName = new Dictionary<string, List<Tuple<string, object>>>(StringComparer.InvariantCultureIgnoreCase);

            // For filter-based authorization, there is no sense/need in incorporating the "existing values" segments, 
            // as they would only serve to further constrain data that is already in the target table.
            foreach (var segment in authorizationSegments.ClaimsAuthorizationSegments)
            {
                var targetEndpointName = segment.TargetEndpoint.Name;

                var claimsEndpointsGroupedByName =
                    (from cep in segment.ClaimsEndpoints
                     group cep by cep.Name
                     into g
                     select g)
                   .ToList();

                // Make sure all the claims are of the same type.  NHibernate filters are combined with AND, 
                // so we only have one representation of the 'OR' nature of the claims values 
                // (via an 'IN' clause in the filter itself)
                if (claimsEndpointsGroupedByName.Count() > 1)
                {
                    throw new NotSupportedException(
                        string.Format(
                            "Filter-based authorization does not support claims containing multiple types of values (e.g. claims associated with multiple types of education organizations).  The claim types found were '{0}'.",
                            string.Join("', '", claimsEndpointsGroupedByName.Select(x => x.Key))));
                }

                var claimEndpoints = claimsEndpointsGroupedByName.Single();

                string claimEndpointName = claimEndpoints.First()
                                                         .Name;

                // Get the name of the view to use for this segment
                string viewName = GetViewName(classMetadata, targetEndpointName, claimEndpointName, segment.AuthorizationPathModifier);

                List<Tuple<string, object>> values;

                if (!valuesByViewName.TryGetValue(viewName, out values))
                {
                    values = new List<Tuple<string, object>>();
                    valuesByViewName[viewName] = values;
                }

                values.AddRange(claimEndpoints.Select(x => Tuple.Create(x.Name, x.Value)));
            }

            foreach (var kvp in valuesByViewName)
            {
                var filterName = kvp.Key;

                var valuesGroupedByName =
                    from x in kvp.Value
                    group x by x.Item1 into g
                    select g;

                var filter = filterBuilder.Filter(filterName);

                // NOTE: For application of NHibernate filters to support SQL Server Table-Valued Parameters correctly,
                // the values for claims-based EducationOrganizationIds must be presented as an array of objects.
                // (See the ApplyFilters method of the NHibernateFilterApplicator class.)
                foreach (var grouping in valuesGroupedByName)
                {
                    filter.Set(
                        grouping.Key,
                        grouping.Select(p => p.Item2)
                                .Distinct()
                                .ToArray());
                }
            }
        }

        private string GetViewName(IClassMetadata classMetadata, string item1Name, string item2Name, string authorizationPathModifier)
        {
            string item1 = ReplaceUniqueIdIfNotInMetadata(classMetadata, item1Name);
            string item2 = ReplaceUniqueIdIfNotInMetadata(classMetadata, item2Name);

            // TODO: Embedded convention, building view name using endpoints sorted alphabetically
            var compareResult = string.Compare(item1, item2, StringComparison.InvariantCultureIgnoreCase);

            var viewPrefix = compareResult < 0
                ? item1
                : item2;

            var viewSuffix = compareResult < 0
                ? item2
                : item1;

            // TODO: Embedded convention (append authorization path modifier to view name)
            string viewName = viewPrefix + "To" + viewSuffix + authorizationPathModifier;

            return viewName;
        }

        private string ReplaceUniqueIdIfNotInMetadata(IClassMetadata classMetadata, string propertyName)
        {
            // TODO: Embedded convention
            return propertyName.EndsWithIgnoreCase("UniqueId") &&
                   !classMetadata.PropertyNames.Contains(propertyName)
                ? propertyName.Replace("UniqueId", "USI")
                : propertyName;
        }
    }
}
