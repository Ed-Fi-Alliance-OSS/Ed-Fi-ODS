// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Text;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization.EntityAuthorization;

public interface IEntityAuthorizationSqlBuilder
{
    string BuildExistenceCheckSql(AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks);
}

public class EntityAuthorizationSqlBuilder : IEntityAuthorizationSqlBuilder
{
    public string BuildExistenceCheckSql(AuthorizationStrategyFilterResults[] resultsWithPendingExistenceChecks)
    {
        // Build the existence check SQL
        StringBuilder sql = new();

        sql.Append("SELECT CASE WHEN ");
        int initialSqlBuilderLength = sql.Length;
        bool conjunctionRequired = false;
        bool conjunctionStarted = false;

        // Build the AND conditions
        resultsWithPendingExistenceChecks.Where(x => x.Operator == FilterOperator.And)
            .ForEach((x, i, s) =>
            {
                if (i > 0)
                {
                    s.Append(" AND ");
                }

                s.Append('(');

                x.FilterResults.ForEach(
                    (y, j, s) =>
                    {
                        var viewBasedFilterDefinition = y.FilterDefinition as ViewBasedAuthorizationFilterDefinition
                            ?? throw new InvalidOperationException(
                                "Expected a ViewBasedAuthorizationFilterDefinition instance for performing existence checks.");

                        var viewSqlSupport = viewBasedFilterDefinition.ViewBasedSingleItemAuthorizationQuerySupport;

                        if (j > 0)
                        {
                            // NOTE: Individual filters (segments) are always combined with AND
                            s.Append(" AND ");
                        }

                        s.Append("EXISTS (");
                        s.Append(viewSqlSupport.GetItemExistenceCheckSql(viewBasedFilterDefinition, y.FilterContext));
                        s.Append(')');
                    }, s);

                s.Append(')');
            }, sql);

        if (sql.Length > initialSqlBuilderLength)
        {
            conjunctionRequired = true;
        }

        // Build the OR conditions
        resultsWithPendingExistenceChecks.Where(x => x.Operator == FilterOperator.Or)
            .ForEach((x, i, s) =>
            {
                if (i == 0)
                {
                    if (conjunctionRequired)
                    {
                        sql.Append(" AND (");
                        conjunctionStarted = true;
                    }
                }
                else
                {
                    s.Append(" OR ");
                }

                s.Append('(');

                x.FilterResults.ForEach(
                    (y, j, s) =>
                    {
                        var viewBasedFilterDefinition = y.FilterDefinition as ViewBasedAuthorizationFilterDefinition
                            ?? throw new InvalidOperationException(
                                "Expected a ViewBasedAuthorizationFilterDefinition instance for performing existence checks.");

                        var viewSqlSupport = viewBasedFilterDefinition.ViewBasedSingleItemAuthorizationQuerySupport;

                        if (j > 0)
                        {
                            // NOTE: Individual filters (segments) are always combined with AND
                            s.Append(" AND ");
                        }

                        s.Append("EXISTS (");
                        s.Append(viewSqlSupport.GetItemExistenceCheckSql(viewBasedFilterDefinition, y.FilterContext));
                        s.Append(')');
                    }, s);

               s.Append(')');
            }, sql);

        if (conjunctionStarted)
        {
            // Add a final closing parenthesis containing the OR conditions for the wrapping AND condition
            sql.Append(")");
        }

        sql.Append(" THEN 1 ELSE 0 END AS IsAuthorized");

        return sql.ToString();
    }
}
