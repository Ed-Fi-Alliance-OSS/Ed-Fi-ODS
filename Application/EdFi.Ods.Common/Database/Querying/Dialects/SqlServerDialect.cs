// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using EdFi.Ods.Common.Infrastructure.SqlServer;

namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public class SqlServerDialect : Dialect
    {
        // Must match RelationshipAuthorizationConventions.ClaimsParameterName (in EdFi.Ods.Api, which cannot be
        // referenced from this assembly), prefixed with '@'.
        public const string ClaimsParameterName = "@ClaimEducationOrganizationIds";

        public const string ClaimsTempTableName = "#ClaimEdOrgIds";

        // The DROP guards below are defensive. A temp table created inside an sp_executesql batch is scoped to
        // that batch and disappears with it, so today the CREATE cannot collide; the guard is there so a future
        // change to how these statements are executed does not turn into a runtime failure. Dropping a table that
        // does not exist costs nothing.
        //
        // TVPs carry no statistics on their values, causing the optimizer to catastrophically misestimate the
        // relationship-based authorization joins for large claim lists. Landing the TVP contents into a temp table
        // inside the batch provides the optimizer with statistics, while the TVP remains the transport on the wire
        // (required to stay under the 2,100 parameter limit for clients with very large EdOrg counts).
        //
        // The SELECT is DISTINCT because the temp table has a primary key while the table-valued parameter type
        // does not, so a repeated education organization id in the claim would fail the insert and turn every
        // request from that client into a 500. Nothing in the SQL should depend on the caller having deduplicated.
        public const string ClaimsTempTableLandingSql =
            $"DROP TABLE IF EXISTS {ClaimsTempTableName}; CREATE TABLE {ClaimsTempTableName} (Id BIGINT PRIMARY KEY); INSERT INTO {ClaimsTempTableName} (Id) SELECT DISTINCT Id FROM {ClaimsParameterName};";

        public const string AuthEdOrgsTempTableName = "#AuthEdOrgs";

        // Claim statistics alone leave the ed-org fanout estimated from average density, which is skew-blind:
        // narrow claims on large resources can flip to a row-goal scan that never terminates when few or no rows
        // are authorized. Landing the ed-org EXPANSION (the tuple targets for the claim) gives the optimizer the
        // concrete ed-org ids with value-level statistics. The INSERT is the exact query the authorization CTE
        // for the ed-org view runs today, so consuming this table instead is semantically identical.
        public const string AuthEdOrgsTempTableLandingSql =
            $"DROP TABLE IF EXISTS {AuthEdOrgsTempTableName}; CREATE TABLE {AuthEdOrgsTempTableName} (Id BIGINT PRIMARY KEY); INSERT INTO {AuthEdOrgsTempTableName} (Id) SELECT DISTINCT TargetEducationOrganizationId FROM auth.EducationOrganizationIdToEducationOrganizationId WHERE SourceEducationOrganizationId IN (SELECT Id FROM {ClaimsTempTableName});";

        // Landing the claims alone is not enough on the change query endpoints. There the claim expansion runs
        // through a person view, and giving the optimizer exact claim statistics lowers its estimate of that
        // expansion (measured at 108,140 authorized students estimated as 533), which shrinks the memory grant on a
        // hash join that was already spilling. Landing the person expansion gives that side value-level statistics
        // instead. As with the ed-org expansion, the INSERT is the query the authorization join would run anyway,
        // so consuming this table is semantically identical.
        //
        // The table is named for the view because a single query can expand more than one person type, and person
        // identifiers (USIs) are 32-bit integers throughout the data standard.
        public static string GetAuthPersonsTempTableName(string viewName) => $"#Auth{viewName}";

        /// <summary>
        /// Builds the statement that lands the claim's expansion through a person authorization view.
        /// </summary>
        /// <param name="viewName">The name of the person authorization view to expand.</param>
        /// <param name="sourceColumnName">The view's claim-side column.</param>
        /// <param name="personColumnName">The view's person column.</param>
        /// <param name="trackedChangesTableName">The tracked changes table the query reads, when it is known.</param>
        /// <param name="trackedChangesPersonColumnName">That table's person column.</param>
        /// <param name="trackedChangesCriterion">The criterion selecting the kind of change the query is about.</param>
        /// <remarks>
        /// When the tracked changes table is known the expansion is restricted to the persons that appear in it,
        /// under the same criterion the query itself applies. The query only ever uses this set joined to that same
        /// table under that same criterion, so the restriction cannot change its result, and it keeps the cost
        /// proportional to the change history the request is actually about rather than to the breadth of the
        /// claim: a resource with no matching tracked changes lands nothing instead of the client's entire
        /// authorized population.
        /// </remarks>
        public static string GetAuthPersonsTempTableLandingSql(
            string viewName,
            string sourceColumnName,
            string personColumnName,
            string trackedChangesTableName = null,
            string trackedChangesPersonColumnName = null,
            string trackedChangesCriterion = null)
        {
            string tempTableName = GetAuthPersonsTempTableName(viewName);

            string changeKindCriterion = trackedChangesCriterion == null
                ? string.Empty
                : $" AND tc.{trackedChangesCriterion}";

            string trackedChangesRestriction = trackedChangesTableName == null
                ? string.Empty
                : $" AND EXISTS (SELECT 1 FROM {trackedChangesTableName} AS tc"
                    + $" WHERE tc.{trackedChangesPersonColumnName} = av.{personColumnName}{changeKindCriterion})";

            return $"DROP TABLE IF EXISTS {tempTableName}; CREATE TABLE {tempTableName} ({personColumnName} INT PRIMARY KEY); "
                + $"INSERT INTO {tempTableName} ({personColumnName}) SELECT DISTINCT av.{personColumnName} "
                + $"FROM auth.{viewName} AS av WHERE av.{sourceColumnName} IN (SELECT Id FROM {ClaimsTempTableName})"
                + $"{trackedChangesRestriction};";
        }

        // When a resource's relationship-based authorization runs only through person views (for example
        // StudentUSI), there is no education-organization predicate to narrow the resource, and the optimizer's row
        // goal makes it scan the resource in AggregateId order expecting to fill the page early. On a large resource
        // where the claim authorizes few or no rows, that scan reads the whole table.
        //
        // Whether suppressing the row goal is worth it depends on how many rows the resource holds per authorized
        // person, which is a property of the resource's primary key rather than of the data:
        //
        // - When the person is the resource's entire primary key (Student, Staff, Contact), the resource holds at
        //   most one row per person, so an ordered scan finds authorized rows at the same density the claim
        //   authorizes, and the row goal is what makes the first page instant. The hint is not applied.
        // - When the person is only part of a composite primary key (StudentGradebookEntry,
        //   StudentContactAssociation), the resource holds many rows per person and those rows can be concentrated
        //   in one range of the scan or absent altogether, so the row goal is an unbacked bet. Suppressing it costs
        //   little (the authorized person set is small relative to the resource) and avoids the full scan.
        public const string PersonOnlyAuthorizationQueryHint = "OPTION (USE HINT('DISABLE_OPTIMIZER_ROWGOAL'))";

        public override string GetTemplateString(string sourceTableName)
        {
            return $"/**prologue**/{base.GetTemplateString(sourceTableName)} /**queryhints**/";
        }

        public override string GetCountTemplateString(string countTableCteName)
        {
            return $"/**prologue**/{base.GetCountTemplateString(countTableCteName)} /**queryhints**/";
        }

        public override string GetAuthorizationQueryHint(bool hasEducationOrganizationFilter, bool hasPersonFilter, bool personIsCompleteResourceKey)
        {
            return hasPersonFilter && !hasEducationOrganizationFilter && !personIsCompleteResourceKey
                ? PersonOnlyAuthorizationQueryHint
                : null;
        }

        public override string GetLimitOffsetString(string limitParameter, string offsetParameter)
        {
            if (offsetParameter == null && limitParameter == null)
            {
                return null;
            }

            if (offsetParameter != null && limitParameter != null)
            {
                return $"OFFSET {offsetParameter} ROWS FETCH NEXT {limitParameter} ROWS ONLY";
            }

            if (offsetParameter != null)
            {
                return $"OFFSET {offsetParameter} ROWS";
            }

            return $"OFFSET 0 ROWS FETCH NEXT {limitParameter} ROWS ONLY";
        }

        public override (string sql, object parameters, string prologue) GetInClause(string columnName, string parameterName, IList values)
        {
            // If list is empty, replace the IN clause with literal false condition
            if (values.Count == 0)
            {
                return ("1 = 0", null, null);
            }

            var parameters = CreateTableValuedParameters(parameterName, values);

            if (parameterName == ClaimsParameterName)
            {
                return ($"{columnName} IN (SELECT Id FROM {ClaimsTempTableName})", parameters, ClaimsTempTableLandingSql);
            }

            return ($"{columnName} IN (SELECT Id FROM {parameterName})", parameters, null);
        }

        /// <summary>
        /// Creates the <see cref="DynamicParameters" /> holding the supplied values as a table-valued parameter.
        /// </summary>
        public static DynamicParameters CreateTableValuedParameters(string parameterName, IList values)
        {
            var itemSystemType = values[0].GetType();

            // ODS does not support TVPs using shorts, so use int instead
            if (itemSystemType == typeof(short))
            {
                itemSystemType = typeof(int);
            }

            var tvp = SqlServerTableValuedParameterHelper.CreateIdDataTable(values, itemSystemType)
                .AsTableValuedParameter(SqlServerStructuredMappings.StructuredTypeNameBySystemType[itemSystemType]);

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new[] { new KeyValuePair<string, object>(parameterName, tvp) });

            return parameters;
        }

        public override string GetGreatestString(string expression1, string expression2)
        {
            // For SQL 2022 and later, this override is not need. For SQL 2019 and earlier, CASE must be used
            return $"CASE WHEN {expression1} > {expression2} THEN {expression1} ELSE {expression2} END";
        }

        /// <summary>
        /// Gets the maximum number of allowed parameters for SQL Server (see https://learn.microsoft.com/en-us/sql/sql-server/maximum-capacity-specifications-for-sql-server?view=sql-server-ver16).
        /// </summary>
        /// <returns>2100</returns>
        public override int GetMaxParameterCount() => 2100;

        public override (string keywords, string aliasedExpression) GetCrossJoinString(string expression, string alias, string[] columnNames = null)
        {
            return ("CROSS APPLY", $"{expression} AS {alias}{(columnNames == null ? string.Empty : $"({string.Join(", ", columnNames)})")}");
        }
    }
}
