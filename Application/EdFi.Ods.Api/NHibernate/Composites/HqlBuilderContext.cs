// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Text;
using EdFi.Ods.Common.Composites;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.NHibernate.Composites
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
        /// <param name="baseSelect">The <see cref="StringBuilder"/> containing the SELECT statement to be snapshotted.</param>
        /// <param name="baseFrom">The <see cref="StringBuilder"/> containing the FROM statement to be snapshotted.</param>
        /// <param name="baseWhere">The <see cref="StringBuilder"/> containing the WHERE clause to be snapshotted.</param>
        /// <param name="baseOrderBy">The <see cref="StringBuilder"/> containing the ORDER BY statement to be snapshotted.</param>
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
        public IDictionary<string, object> CurrentQueryFilterParameterValueByName { get; } =
            new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

        public IDictionary<string, AuthorizationFilterDetails> CurrentQueryFilterByName { get; set; }

        /// <summary>
        /// Gets or sets an ordered list of the property projections for this context.
        /// </summary>
        public IList<CompositePropertyProjection> PropertyProjections { get; set; }

        /// <summary>
        /// Indicates whether the current context represents a request with a single item response (GetById or GetByKey patterns).
        /// </summary>
        public bool IsSingleItemResult { get; set; }
    }
}
