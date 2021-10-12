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
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Api.Security.Utilities;
using log4net;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.Authorization
{
    public abstract class AuthorizationSegmentSqlProviderBase : IAuthorizationSegmentsSqlProvider
    {
        private const string MainTemplate =
@"SELECT 1 WHERE
(
{0}
);";
        // TODO: Embedded convention, append authorization path modifier to view name
        private const string StatementTemplate = "EXISTS (SELECT 1 FROM {3} a WHERE a.SourceEducationOrganizationId{0} and a.{1}{2})";

        private readonly Lazy<IReadOnlyList<string>> _supportedAuthorizationViewNames;

        private static readonly Regex _identifierRegex = new Regex(@"^[\w]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly ILog _logger = LogManager.GetLogger(typeof(AuthorizationSegmentSqlProviderBase));

        public AuthorizationSegmentSqlProviderBase(IAuthorizationTablesAndViewsProvider authorizationTablesAndViewsProvider)
        {
            _supportedAuthorizationViewNames =
                new Lazy<IReadOnlyList<string>>(() => authorizationTablesAndViewsProvider.GetAuthorizationTablesAndViews().ToReadOnlyList());
        }

        public QueryMetadata GetAuthorizationQueryMetadata(
            IReadOnlyList<ClaimsAuthorizationSegment> authorizationSegments,
            ref int parameterIndex)
        {
            var segmentStatements = new List<string>();
            var parameters = new List<DbParameter>();
            var unsupportedAuthorizationViews = new List<string>();
            var authorizationPathModifiers = new List<string>();

            // Perform defensive check against non-EdOrg-based claim endpoints
            // NOTE: Assumption here is that the claims endpoints will only contain identifiers for EdOrg-derived entities.
            var unsupportedClaimEndpointNames = authorizationSegments.First()
                .ClaimsEndpoints.Select(x => x.Name)
                .Distinct()
                .Where(x => !EducationOrganizationEntitySpecification.IsEducationOrganizationIdentifier(x))
                .ToArray();

            if (unsupportedClaimEndpointNames.Any())
            {
                throw new NotSupportedException($"Claim endpoint names of '{string.Join("', '", unsupportedClaimEndpointNames)}' are not supported for authorization.");
            }

            foreach (var authorizationSegment in authorizationSegments)
            {
                string claimEndpointName = "EducationOrganizationId";

                string subjectEndpointName = EducationOrganizationEntitySpecification.IsEducationOrganizationIdentifier(authorizationSegment.SubjectEndpoint.Name)
                        ? "EducationOrganizationId"
                        : authorizationSegment.SubjectEndpoint.Name;

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
                    claimEndpointName,
                    subjectEndpointName,
                    authorizationSegment.AuthorizationPathModifier);

                if (!IsAuthorizationViewSupported(derivedAuthorizationViewName))
                {
                    unsupportedAuthorizationViews.Add(derivedAuthorizationViewName);

                    authorizationPathModifiers.Add(authorizationSegment.AuthorizationPathModifier);                    

                    continue;
                }

                segmentStatements.Add(CreateSegmentExpression(ref parameterIndex));

                string CreateSegmentExpression(ref int index)
                {
                    return string.Format(
                        StatementTemplate,
                        GetMultiValueCriteriaExpression(authorizationSegment.ClaimsEndpoints.ToList(), parameters, ref index),
                        subjectEndpointName.EqualsIgnoreCase("EducationOrganizationId")
                        ? "TargetEducationOrganizationId"
                        : subjectEndpointName,
                        GetSingleValueCriteriaExpression(subjectEndpointWithValue, parameters, ref index),
                        derivedAuthorizationViewName);
                }
            }

            if (unsupportedAuthorizationViews.Any())
            {
                var authorizationPathModifierValues = string.Join("', '", authorizationPathModifiers.Distinct().OrderBy(x => x));

                _logger.Debug($"Unable to authorize resource item because '{authorizationPathModifierValues}' AuthorizationPathModifier is invalid.");

                throw new EdFiSecurityException(
                    $"Unable to authorize the request because there is no authorization support for the associated '{authorizationPathModifierValues}' authorizationPathModifier " +
                    $"with the resource.");
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
