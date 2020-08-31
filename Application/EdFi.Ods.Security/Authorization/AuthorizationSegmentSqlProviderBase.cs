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
using EdFi.Ods.Security.Utilities;
using log4net;

namespace EdFi.Ods.Security.Authorization
{
    public abstract class AuthorizationSegmentSqlProviderBase : IAuthorizationSegmentsSqlProvider
    {
        private const string MainTemplate =
@"SELECT 1 WHERE
(
{0}
);";
        // TODO: Embedded convention, append authorization path modifier to view name
        private const string StatementTemplate = "EXISTS (SELECT 1 FROM {4} a WHERE a.{0}{1} and a.{2}{3})";

        private readonly Lazy<IReadOnlyList<string>> _supportedAuthorizationViewNames;

        private static readonly Regex _identifierRegex = new Regex(@"^[\w]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly ILog _logger = LogManager.GetLogger(typeof(AuthorizationSegmentSqlProviderBase));

        public AuthorizationSegmentSqlProviderBase(IAuthorizationViewsProvider authorizationViewsProvider)
        {
            _supportedAuthorizationViewNames =
                new Lazy<IReadOnlyList<string>>(() => authorizationViewsProvider.GetAuthorizationViews().ToReadOnlyList());
        }

        public QueryMetadata GetAuthorizationQueryMetadata(
            IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments,
            ref int parameterIndex)
        {
            var segmentStatements = new List<string>();
            var parameters = new List<DbParameter>();

            foreach (var authorizationSegment in authorizationSegments)
            {
                // Within each claim segment, group the values by ed org type, and combine with "OR"
                var claimEndpointsGroupedByName = authorizationSegment.ClaimsEndpoints
                    .GroupBy(ep => ep.Name)
                    .Select(g => g)
                    .ToList();

                var segmentExpressions = new List<string>();

                var unsupportedAuthorizationViews = new List<string>();

                foreach (var claimEndpointsWithSameName in claimEndpointsGroupedByName)
                {
                    string claimEndpointName = claimEndpointsWithSameName.Key;
                    string subjectEndpointName = authorizationSegment.SubjectEndpoint.Name;

                    var subjectEndpointWithValue =
                        authorizationSegment.SubjectEndpoint as AuthorizationSegmentEndpointWithValue;

                    // This should never happen
                    if (subjectEndpointWithValue == null)
                    {
                        throw new Exception(
                            "The claims-based authorization segment subject endpoint for a single-item authorization was not defined with a value.");
                    }

                    if (subjectEndpointWithValue.Value == null)
                    {
                        throw new EdFiSecurityException(
                            $"Access to the resource item could not be authorized because the '{subjectEndpointWithValue.Name}' of the resource is empty.");
                    }

                    // Perform defensive checks against the remote possibility of SQL injection attack
                    ValidateTableNameParts(claimEndpointName, subjectEndpointName, authorizationSegment.AuthorizationPathModifier);

                    string derivedAuthorizationViewName = ViewNameHelper.GetFullyQualifiedAuthorizationViewName(
                        subjectEndpointName,
                        claimEndpointName,
                        authorizationSegment.AuthorizationPathModifier);

                    if (!IsAuthorizationViewSupported(derivedAuthorizationViewName))
                    {
                        unsupportedAuthorizationViews.Add(derivedAuthorizationViewName);

                        continue;
                    }

                    segmentExpressions.Add(CreateSegmentExpression(ref parameterIndex));

                    string CreateSegmentExpression(ref int index)
                    {
                        if (string.Compare(subjectEndpointName, claimEndpointName, StringComparison.InvariantCultureIgnoreCase) < 0)
                        {
                            return string.Format(
                                StatementTemplate,
                                subjectEndpointName,
                                GetSingleValueCriteriaExpression(subjectEndpointWithValue, parameters, ref index),
                                claimEndpointName,
                                GetMultiValueCriteriaExpression(claimEndpointsWithSameName.ToList(), parameters, ref index),
                                derivedAuthorizationViewName);
                        }

                        return string.Format(
                            StatementTemplate,
                            claimEndpointName,
                            GetMultiValueCriteriaExpression(claimEndpointsWithSameName.ToList(), parameters, ref index),
                            subjectEndpointName,
                            GetSingleValueCriteriaExpression(subjectEndpointWithValue, parameters, ref index),
                            derivedAuthorizationViewName);
                    }
                }

                if (!segmentExpressions.Any())
                {
                    _logger.Debug("Unable to authorize resource item because none of the following authorization views exist: "
                        + $"'{string.Join("', '", unsupportedAuthorizationViews)}'");

                    string edOrgTypes = string.Join(
                        "', '",
                        authorizationSegment.ClaimsEndpoints
                            .Select(s => s.Name.TrimSuffix("Id"))
                            .Distinct()
                            .OrderBy(x => x));

                    throw new EdFiSecurityException(
                        $"Unable to authorize the request because there is no authorization support for associating the "
                        + $"API client's associated education organization types ('{edOrgTypes}') with the resource.");
                }

                // Combine multiple statements resulting from multiple EdOrg types in the API client's claims using "OR"
                // (This forces at least 1 of the relationships with the EdOrg types to exist)
                segmentStatements.Add(string.Join($"{Environment.NewLine}OR ", segmentExpressions));
            }

            // Combine multiple authorization segments with AND (forcing all segments to be satisfied)
            string statements = string.Join($"{Environment.NewLine}){Environment.NewLine}AND{Environment.NewLine}({Environment.NewLine}", segmentStatements);

            string sql = string.Format(MainTemplate, statements);

            return new QueryMetadata(sql, parameters.ToArray());
        }

        private static void ValidateTableNameParts(
            string claimEndpointName,
            string subjectEndpointName,
            string authorizationPathModifier)
        {
            if (!_identifierRegex.IsMatch(claimEndpointName))
            {
                throw new Exception("Authorization claim endpoint name is not safe for use in SQL.");
            }

            if (!_identifierRegex.IsMatch(subjectEndpointName))
            {
                throw new Exception("Authorization subject endpoint name is not safe for use in SQL.");
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

        private bool IsAuthorizationViewSupported(string authorizationViewName)
        {
            if (!_supportedAuthorizationViewNames.Value.Any(s => s.Equals(authorizationViewName, StringComparison.InvariantCultureIgnoreCase)))
            {
                _logger.Debug($"Authorization view '{authorizationViewName}' is not supported");

                return false;
            }

            return true;
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
