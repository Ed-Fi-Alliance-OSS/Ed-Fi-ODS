// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Dapper;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourceDataQuery
{
    /// <summary>
    /// Defines a method for performing querying of a property that requires a join to another
    /// table to resolve its value (e.g. descriptors, uniqueIds, and references).
    /// </summary>
    public interface IResourceDataQueryPropertyExpansion
    {
        /// <summary>
        /// Process the property expansions for the supplied resource class into the query in the supplied <see cref="SqlBuilder" />.
        /// </summary>
        /// <param name="resourceClass">The resource class that is the basis of the current query.</param>
        /// <param name="resourceAlias">The current alias used to reference the underlying table for the resource class in the current query.</param>
        /// <param name="sqlBuilder">The <see cref="SqlBuilder" /> containing the current query.</param>
        /// <param name="aliasGenerator">A generator for creating distinct aliases for additional joins that need to be added to the current query.</param>
        void Process(ResourceClassBase resourceClass, string resourceAlias, SqlBuilder sqlBuilder, AliasGenerator aliasGenerator);
    }
}
