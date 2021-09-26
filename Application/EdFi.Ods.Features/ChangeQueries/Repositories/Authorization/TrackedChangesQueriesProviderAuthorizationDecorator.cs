// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using System.Security;
using System.Security.Claims;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using EdFi.Ods.Generator.Database.NamingConventions;
using log4net;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Authorization
{
    public abstract class TrackedChangesQueriesProviderAuthorizationDecorator : ITrackedChangesQueriesProvider
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IEdFiAuthorizationProvider _edFiAuthorizationProvider;
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly ITrackedChangesQueriesProvider _next;

        private readonly ILog _logger = LogManager.GetLogger(typeof(TrackedChangesQueriesProviderAuthorizationDecorator));

        protected TrackedChangesQueriesProviderAuthorizationDecorator(
            IAuthorizationContextProvider authorizationContextProvider,
            IEdFiAuthorizationProvider edFiAuthorizationProvider,
            IDomainModelProvider domainModelProvider,
            IDomainModelEnhancer domainModelEnhancer,
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesQueriesProvider next)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _edFiAuthorizationProvider = edFiAuthorizationProvider;
            _namingConvention = namingConvention;
            _next = next;

            domainModelEnhancer.Enhance(domainModelProvider.GetDomainModel());
        }

        public TrackedChangesQueries GetQueries(DbConnection connection, Resource resource, IQueryParameters queryParameters)
        {
            var queries = _next.GetQueries(connection, resource, queryParameters);

            if (queries.DataQuery != null)
            {
                ApplyAuthorizationFilters(resource, queries.DataQuery);
            }

            if (queries.CountQuery != null)
            {
                ApplyAuthorizationFilters(resource, queries.CountQuery);
            }

            return queries;
        }

        private void ApplyAuthorizationFilters(Resource resource, Query query)
        {
            Type entityType = ((dynamic)resource.Entity).NHibernateEntityType;

            if (entityType == null)
            {
                throw new SecurityException(
                    $"Unable to perform authorization because entity type for '{resource.Entity.FullName}' could not be identified.");
            }

            var authorizationContext = new EdFiAuthorizationContext(
                ClaimsPrincipal.Current,
                _authorizationContextProvider.GetResourceUris(),
                _authorizationContextProvider.GetAction(),
                entityType);

            var filters = _edFiAuthorizationProvider.GetAuthorizationFilters(authorizationContext);

            var filterIndex = 0;

            // Apply authorization filters
            foreach (var filter in filters)
            {
                // TODO: Decompose this conditional logic into an array of injected IDeletedItemsAuthorizationFilterHandler instances
                if (filter.FilterName == "Namespace")
                {
                    if (filter.ClaimValues.Length == 1)
                    {
                        query.WhereLike("namespace", filter.ClaimValues[0]);
                    }
                    else if (filter.ClaimValues.Length > 1)
                    {
                        query.Where(
                            q => q.Where(
                                q2 =>
                                {
                                    filter.ClaimValues.ForEach(cv => q2.OrWhereLike("namespace", cv));

                                    return q2;
                                }));
                    }
                    else
                    {
                        // This should never happen
                        throw new SecurityException("No namespaces found in claims.");
                    }
                }
                else if (filter.FilterName.Contains("To"))
                {
                    // Generalize relationships-based naming convention
                    query.Join(
                        $"auth.{filter.FilterName.ToLower()} AS rba{filterIndex}",
                        $"c.{_namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{filter.SubjectEndpointName}")}",
                        $"rba{filterIndex}.{_namingConvention.ColumnName(filter.SubjectEndpointName)}");

                    query.WhereIn($"rba{filterIndex}.{_namingConvention.ColumnName(filter.ClaimEndpointName)}", filter.ClaimValues);
                }
                else
                {
                    throw new SecurityException(
                        $"Support for filtering with filter '{filter.FilterName}' has not been implemented.");
                }

                filterIndex++;
            }
        }
    }
}
