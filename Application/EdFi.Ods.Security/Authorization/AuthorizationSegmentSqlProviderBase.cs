// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Security.Authorization
{
    public abstract class AuthorizationSegmentSqlProviderBase : IAuthorizationSegmentsSqlProvider
    {
        private const string MainTemplate = @"SELECT 1 WHERE EXISTS ({0});";

        // TODO: Embedded convention, append authorization path modifier to view name
        private const string StatementTemplate = "SELECT 1 FROM auth.{0}To{2}{4} a WHERE a.{0}{1} and a.{2}{3}";

        private static readonly Regex _identifierRegex = new Regex(@"^[\w]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public KeyValuePair<string, DbParameter[]> BuildAuthorization(
            AuthorizationSegmentCollection authorizationSegments,
            ref int parameterIndex)
        {
            var segmentStatements = new List<string>();
            var parameters = new List<DbParameter>();

            foreach (var authorizationSegment in authorizationSegments.ClaimsAuthorizationSegments)
            {
                // Within each claim segment, group the values by ed org type, and combine with "OR"
                var claimEndpointsGroupedByName = authorizationSegment.ClaimsEndpoints
                    .GroupBy(ep => ep.Name)
                    .Select(g => g)
                    .ToList();

                var segmentExpressions = new List<string>();

                foreach (var claimEndpointsWithSameName in claimEndpointsGroupedByName)
                {
                    string claimEndpointName = claimEndpointsWithSameName.Key;
                    string targetEndpointName = authorizationSegment.TargetEndpoint.Name;

                    var targetEndpointWithValue =
                        authorizationSegment.TargetEndpoint as AuthorizationSegmentEndpointWithValue;

                    // This should never happen
                    if (targetEndpointWithValue == null)
                    {
                        throw new Exception(
                            "The claims-based authorization segment target endpoint for a single-item authorization was not defined with a value.");
                    }

                    if (targetEndpointWithValue.Value == null)
                    {
                        throw new EdFiSecurityException(
                            $"Access to the resource item could not be authorized because the '{targetEndpointWithValue.Name}' of the resource is empty.");
                    }

                    // Perform defensive checks against the remote possibility of SQL injection attack
                    ValidateTableNameParts(claimEndpointName, targetEndpointName, authorizationSegment.AuthorizationPathModifier);

                    if (string.Compare(
                        targetEndpointName,
                        claimEndpointName,
                        StringComparison.InvariantCultureIgnoreCase) < 0)
                    {
                        segmentExpressions.Add(
                            string.Format(
                                StatementTemplate,
                                targetEndpointName,
                                GetSingleValueCriteriaExpression(targetEndpointWithValue, parameters, ref parameterIndex),
                                claimEndpointName,
                                GetMultiValueCriteriaExpression(
                                    claimEndpointsWithSameName.ToList(),
                                    parameters,
                                    ref parameterIndex),
                                authorizationSegment.AuthorizationPathModifier)
                        );
                    }
                    else
                    {
                        segmentExpressions.Add(
                            string.Format(
                                StatementTemplate,
                                claimEndpointName,
                                GetMultiValueCriteriaExpression(
                                    claimEndpointsWithSameName.ToList(),
                                    parameters,
                                    ref parameterIndex),
                                targetEndpointName,
                                GetSingleValueCriteriaExpression(targetEndpointWithValue, parameters, ref parameterIndex),
                                authorizationSegment.AuthorizationPathModifier)
                        );
                    }
                }

                // Combine multiple statements (resulting from multiple ed org types in claims) using "OR"
                // this is used to support multiple ed org types, but not used for non identifying edorgs
                // for example an lea with three schools.
                // this may still be a YAGNI, but leaving it for now.
                // this is for authorizing claims on multiple types of ed orgs (not supported).
                segmentStatements.Add(
                    string.Join($"){Environment.NewLine}\t OR EXISTS ({Environment.NewLine}\t", segmentExpressions));
            }

            foreach (var authorizationSegment in authorizationSegments.ExistingValuesAuthorizationSegments)
            {
                // This should never happen
                if (authorizationSegment.Endpoints.Count != 2)
                {
                    throw new Exception(
                        "The existing values authorization segment for a single-item authorization did not contain exactly two endpoints.");
                }

                var endpoint1 = authorizationSegment.Endpoints.ElementAt(0) as AuthorizationSegmentEndpointWithValue;
                var endpoint2 = authorizationSegment.Endpoints.ElementAt(1) as AuthorizationSegmentEndpointWithValue;

                // This should never happen
                if (endpoint1 == null || endpoint2 == null)
                {
                    throw new Exception(
                        "One or both of the existing values authorization segment endpoints for a single-item authorization was not defined with a value.");
                }

                // Perform defensive checks against the remote possibility of SQL injection attack
                ValidateTableNameParts(endpoint1.Name, endpoint2.Name, authorizationSegment.AuthorizationPathModifier);

                if (string.Compare(
                    endpoint1.Name,
                    endpoint2.Name,
                    StringComparison.InvariantCultureIgnoreCase) < 0)
                {
                    segmentStatements.Add(
                        string.Format(
                            StatementTemplate,
                            endpoint1.Name,
                            GetSingleValueCriteriaExpression(endpoint1, parameters, ref parameterIndex),
                            endpoint2.Name,
                            GetSingleValueCriteriaExpression(endpoint2, parameters, ref parameterIndex),
                            authorizationSegment.AuthorizationPathModifier)
                    );
                }
                else
                {
                    segmentStatements.Add(
                        string.Format(
                            StatementTemplate,
                            endpoint2.Name,
                            GetSingleValueCriteriaExpression(endpoint2, parameters, ref parameterIndex),
                            endpoint1.Name,
                            GetSingleValueCriteriaExpression(endpoint1, parameters, ref parameterIndex),
                            authorizationSegment.AuthorizationPathModifier)
                    );
                }
            }

            string statements = string.Join($"){Environment.NewLine}\tAND EXISTS (", segmentStatements);

            string sql = string.Format(MainTemplate, statements);

            return new KeyValuePair<string, DbParameter[]>(sql, parameters.ToArray());
        }

        private static void ValidateTableNameParts(
            string claimEndpointName,
            string targetEndpointName,
            string authorizationPathModifier)
        {
            if (!_identifierRegex.IsMatch(claimEndpointName))
            {
                throw new Exception("Claim endpoint name is not safe for use in SQL.");
            }

            if (!_identifierRegex.IsMatch(targetEndpointName))
            {
                throw new Exception("Target endpoint name is not safe for use in SQL.");
            }

            if (!string.IsNullOrEmpty(authorizationPathModifier)
                && !_identifierRegex.IsMatch(authorizationPathModifier))
            {
                throw new Exception("Target endpoint name is not safe for use in SQL.");
            }
        }

        protected abstract DbParameter CreateParameter(
            string parameterName,
            AuthorizationSegmentEndpointWithValue segmentEndpoint);

        protected virtual string GetSingleValueCriteriaExpression(
            AuthorizationSegmentEndpointWithValue segmentEndpoint,
            IList<DbParameter> parameters,
            ref int parameterIndex)
        {
            string parameterName = "@p" + parameterIndex++;

            parameters.Add(CreateParameter(parameterName, segmentEndpoint));

            return " = " + parameterName;
        }

        private string GetMultiValueCriteriaExpression(
            IList<AuthorizationSegmentEndpointWithValue> endpointsWithValues,
            IList<DbParameter> parameters,
            ref int parameterIndex)
        {
            var firstEndpointValue = endpointsWithValues.FirstOrDefault();

            if (firstEndpointValue == null)
            {
                throw new Exception("There were no endpoint values from which to build an authorization query.");
            }

            // If there's only 1 rule, use the single value method
            return endpointsWithValues.Count == 1
                ? GetSingleValueCriteriaExpression(firstEndpointValue, parameters, ref parameterIndex)
                : BuildMultiValueCriteriaExpression(endpointsWithValues, parameters, ref parameterIndex);
        }

        protected virtual string BuildMultiValueCriteriaExpression(
            IList<AuthorizationSegmentEndpointWithValue> endpointsWithValues,
            IList<DbParameter> parameters,
            ref int parameterIndex)
        {
            var sb = new StringBuilder();

            foreach (var endpointWithValue in endpointsWithValues)
            {
                string parameterName = "@p" + parameterIndex++;

                if (sb.Length == 0)
                {
                    sb.Append(parameterName);
                }
                else
                {
                    sb.Append(", " + parameterName);
                }

                parameters.Add(CreateParameter(parameterName, endpointWithValue));
            }

            return " IN (" + sb + ")";
        }
    }
}
