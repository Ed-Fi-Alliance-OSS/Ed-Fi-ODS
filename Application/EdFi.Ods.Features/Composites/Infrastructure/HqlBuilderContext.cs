// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Features.Composites.Infrastructure
{
    public class HqlBuilderContext
    {
        public HqlBuilderContext(
            StringBuilder select,
            StringBuilder from,
            StringBuilder where,
            StringBuilder orderBy,
            IDictionary<string, object> parameterValueByName,
            string parentAlias,
            int depth,
            IDictionary<string, CompositeSpecificationParameter> filterCriteria,
            IDictionary<string, object> queryStringParameters,
            IDictionary<string, string> queryRangeParameters,
            AliasGenerator aliasGenerator)
        {
            Select = select;
            From = from;
            OrderBy = orderBy;
            Where = where;
            ParameterValueByName = parameterValueByName;
            ParentAlias = parentAlias;
            Depth = depth;
            FilterCriteria = filterCriteria;
            QueryStringParameters = queryStringParameters;
            QueryRangeParameters = queryRangeParameters;
            AliasGenerator = aliasGenerator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HqlBuilderContext"/> class for use as a snapshot
        /// of the pertinent context needed for parenting (i.e. a baseline for children to build from without
        /// additional changes at the parent level from "bleeding" down).
        /// </summary>
        /// <param name="baseSelect">The <see cref="System.Text.StringBuilder"/> containing the SELECT statement to be snapshotted.</param>
        /// <param name="baseFrom">The <see cref="System.Text.StringBuilder"/> containing the FROM statement to be snapshotted.</param>
        /// <param name="baseWhere">The <see cref="System.Text.StringBuilder"/> containing the WHERE clause to be snapshotted.</param>
        /// <param name="baseOrderBy">The <see cref="System.Text.StringBuilder"/> containing the ORDER BY statement to be snapshotted.</param>
        public HqlBuilderContext(
            StringBuilder baseSelect,
            StringBuilder baseFrom,
            StringBuilder baseWhere,
            StringBuilder baseOrderBy)
        {
            Select = baseSelect;
            From = baseFrom;
            Where = baseWhere;
            OrderBy = baseOrderBy;
        }

        public StringBuilder Select { get; }

        public StringBuilder From { get; }

        public StringBuilder OrderBy { get; }

        public StringBuilder Where { get; }

        public IDictionary<string, object> ParameterValueByName { get; }

        public string ParentAlias { get; }

        public int Depth { get; }

        public IDictionary<string, CompositeSpecificationParameter> FilterCriteria { get; }

        public IDictionary<string, object> QueryStringParameters { get; }

        public IDictionary<string, string> QueryRangeParameters { get; }

        public AliasGenerator AliasGenerator { get; }

        public bool NeedDistinct { get; set; }

        public StringBuilder SpecificationFrom { get; set; }

        public StringBuilder SpecificationWhere { get; set; }

        public string CurrentAlias { get; set; }

        /// <summary>
        /// Represents a snapshotted copy of context for use by children as a baseline for building.
        /// </summary>
        public HqlBuilderContext ParentingContext { get; set; }

        /// <summary>
        /// Get contextual filter parameter values that should be applied to the current query only.
        /// </summary>
        /// <remarks>Contexts created for flattened members share this dictionary with the context of the query
        /// that contains them, so that the parameters they add are bound when that query is executed.</remarks>
        public IDictionary<string, object> CurrentQueryFilterParameterValueByName { get; init; } =
            new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

        public IReadOnlyList<AuthorizationStrategyFiltering> CurrentQueryAuthorizationFiltering { get; set; }

        /// <summary>
        /// Indicates whether the context was created for projecting the properties of a flattened member into the
        /// containing query (see <see cref="ICompositeItemBuilder{TBuilderContext,TBuildResult}.CreateFlattenedMemberContext"/>).
        /// </summary>
        /// <remarks>Flattened members are also applied to the contexts of child queries only to join to the members
        /// they contain, in which case no properties of the flattened member are projected.</remarks>
        public bool IsFlattenedMemberContext { get; init; }

        /// <summary>
        /// Gets or sets the alias of the hidden column projected for a flattened reference that indicates (1 or 0) whether
        /// the API client is authorized to read the referenced resource, or <b>null</b> if no such column was projected.
        /// </summary>
        public string AuthorizationFlagAlias { get; set; }

        /// <summary>
        /// Gets the aliases of the authorization flag columns projected for the flattened references that contain
        /// the member being processed with this context.
        /// </summary>
        public IReadOnlyList<string> InheritedAuthorizationFlagAliases { get; init; } = Array.Empty<string>();

        /// <summary>
        /// Gets the aliases of the authorization flag columns that must all be 1 for each projected field to be returned,
        /// keyed by the field's alias in the query.
        /// </summary>
        /// <remarks>Contexts created for flattened members share this dictionary with the context of the query
        /// that contains them.</remarks>
        public IDictionary<string, string[]> AuthorizationFlagAliasesByFieldAlias { get; init; } =
            new Dictionary<string, string[]>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Indicates whether the context was created for processing the children of a flattened member (see
        /// <see cref="ICompositeItemBuilder{TBuilderContext,TBuildResult}.CreateFlattenedReferenceChildContext"/>).
        /// </summary>
        public bool IsFlattenedReferenceChildContext { get; init; }

        /// <summary>
        /// Gets or sets the authorization filtering of the flattened references that contain the member being processed
        /// with this context, along with the aliases of those references in the query.
        /// </summary>
        /// <remarks>The rows of child queries for the non-aggregate root members (e.g. collections) of a flattened reference
        /// are part of the referenced resource, so they are only returned if the API client is authorized to read it.</remarks>
        public IReadOnlyList<ContainingReferenceAuthorizationFiltering> ContainingReferenceAuthorizations { get; set; } =
            Array.Empty<ContainingReferenceAuthorizationFiltering>();

        /// <summary>
        /// Gets or sets an ordered list of the property projections for this context.
        /// </summary>
        public IList<CompositePropertyProjection> PropertyProjections { get; set; }

        /// <summary>
        /// Indicates whether the current context represents a request with a single item response (GetById or GetByKey patterns).
        /// </summary>
        public bool IsSingleItemResult { get; set; }
    }

    /// <summary>
    /// Captures the authorization filtering of a flattened reference along with the alias of the reference in the query.
    /// </summary>
    /// <param name="Filtering">The authorization filtering of the referenced resource.</param>
    /// <param name="Alias">The alias of the referenced resource's entity in the query.</param>
    public record ContainingReferenceAuthorizationFiltering(
        IReadOnlyList<AuthorizationStrategyFiltering> Filtering,
        string Alias);
}
