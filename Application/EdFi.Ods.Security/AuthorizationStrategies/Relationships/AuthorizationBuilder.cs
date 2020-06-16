// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using log4net;

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Builds segments of endpoints that must be related for making an authorization decision.
    /// </summary>
    /// <typeparam name="TContextData">The Type of <see cref="RelationshipsAuthorizationContextData"/> to be used in the authorization decision.</typeparam>
    public class AuthorizationBuilder<TContextData>
        where TContextData : RelationshipsAuthorizationContextData
    {
        // By making this static, each closed generic version will have its own accessors
        // which is appropriate if we're dealing with different types of TContextData
        private static readonly ConcurrentDictionary<string, object> propertyAccessorsByName
            = new ConcurrentDictionary<string, object>();

        private readonly Lazy<List<Tuple<string, object>>> _claimAuthorizationValues;
        private readonly List<ClaimsAuthorizationSegment> _claimsAuthorizationSegments = new List<ClaimsAuthorizationSegment>();
        private readonly TContextData _contextData;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AuthorizationBuilder<TContextData>));
        private readonly IEnumerable<Claim> _relevantClaims;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationBuilder{TContextData}"/> class using the 
        /// specified <see cref="RelationshipsAuthorizationContextData"/> and collection of <see cref="Claim"/>s.
        /// </summary>
        /// <param name="relevantClaims">The claims that are applicable to the authorization decision.</param>
        /// <param name="educationOrganizationCache">The education organization cache that enables the fast lookup of education organization types from Ids.</param>
        public AuthorizationBuilder(IEnumerable<Claim> relevantClaims, IEducationOrganizationCache educationOrganizationCache)
            : this(educationOrganizationCache)
        {
            _relevantClaims = relevantClaims;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationBuilder{TContextData}"/> class using the 
        /// specified <see cref="RelationshipsAuthorizationContextData"/> and collection of <see cref="Claim"/>s.
        /// </summary>
        /// <param name="relevantClaims">The claims that are applicable to the authorization decision.</param>
        /// <param name="educationOrganizationCache">The education organization cache that enables the fast lookup of education organization types from Ids.</param>
        /// <param name="contextData">The Ed-Fi specific data to be used for authorization.</param>
        public AuthorizationBuilder(
            IEnumerable<Claim> relevantClaims,
            IEducationOrganizationCache educationOrganizationCache,
            TContextData contextData)
            : this(educationOrganizationCache)
        {
            _contextData = contextData;
            _relevantClaims = relevantClaims;
        }

        /// <summary>
        /// Provides shared constructor logic for lazy initialization.
        /// </summary>
        /// <param name="educationOrganizationCache">The education organization cache that enables the fast lookup of education organization types from Ids.</param>
        private AuthorizationBuilder(IEducationOrganizationCache educationOrganizationCache)
        {
            // Lazy initialization
            _claimAuthorizationValues = new Lazy<List<Tuple<string, object>>>(
                () =>
                    GetClaimAuthorizationNameValuePairs(educationOrganizationCache));
        }

        private List<Tuple<string, object>> GetClaimAuthorizationNameValuePairs(
            IEducationOrganizationCache educationOrganizationCache)
        {
            var claimAuthorizationValues = new List<Tuple<string, object>>();

            foreach (Claim claim in _relevantClaims)
            {
                var value = claim.ToEdFiResourceClaimValue();

                if (!value.EducationOrganizationIds.Any())
                {
                    continue;
                }

                foreach (int educationOrganizationId in value.EducationOrganizationIds)
                {
                    var identifiers = educationOrganizationCache.GetEducationOrganizationIdentifiers(
                        educationOrganizationId);

                    // Make sure EdOrg exists on the current ODS connection (where the cache gets its data)
                    if (identifiers == null || identifiers.IsDefault)
                    {
                        _logger.InfoFormat(
                            "Unable to find EducationOrganizationId '{0}' in the education organization cache for the current ODS.",
                            educationOrganizationId);

                        continue;
                    }

                    // NOTE: Embedded convention (Concrete EducationOrganization identifiers use format of "TypeName+Id")
                    var claimNameValueTuple = Tuple.Create(
                        identifiers.EducationOrganizationType + "Id",
                        (object) educationOrganizationId);

                    claimAuthorizationValues.Add(claimNameValueTuple);
                }
            }

            return claimAuthorizationValues;
        }

        /// <summary>
        /// Gets the rules that need to be executed against the source of data for performing the authorization decision.
        /// </summary>
        /// <returns>An enumerable set of AuthorizationRule instances representing the authorization decision.</returns>
        public IReadOnlyList<ClaimsAuthorizationSegment> GetSegments()
        {
            // Make sure no segments had empty values for the claims.
            if (_claimsAuthorizationSegments.Any(x => !x.ClaimsEndpoints.Any()))
            {
                if (_relevantClaims.Any(
                    x => !x.ToEdFiResourceClaimValue()
                           .EducationOrganizationIds.Any()))
                {
                    throw new EdFiSecurityException("The request can not be authorized because there were no education organizations on the claim.");
                }

                throw new EdFiSecurityException(
                    "The request can not be authorized because the education organizations identifiers assigned to the claim did not exist in the underlying ODS.");
            }

            return _claimsAuthorizationSegments.ToArray();
        }

        /// <summary>
        /// Adds a rule that indicates the supplied claims must have values that are associated with a property of the Ed-Fi context data using the optional authorization path modifier, if supplied.
        /// </summary>
        /// <typeparam name="TResult">The Type of the Ed-Fi context data property referenced in the rule.</typeparam>
        /// <param name="propertySelection">An expression that can be evaluated and executed against the Ed-Fi context data.</param>
        /// <param name="authorizationPathModifier">An optional value that identifies an alternative path through the ODS data model for authorization.</param>
        /// <returns>The <see cref="AuthorizationBuilder{TContextData}"/> instance, for chaining methods together.</returns>
        public AuthorizationBuilder<TContextData> ClaimsMustBeAssociatedWith<TResult>(
            Expression<Func<TContextData, TResult>> propertySelection,
            string authorizationPathModifier = null)
        {
            var segmentProperty =
                _contextData == null
                    ? CreateSegment(propertySelection, authorizationPathModifier)
                    : CreateSegmentWithValue(propertySelection, authorizationPathModifier);

            return ClaimsMustBeAssociatedWith(segmentProperty);
        }

        /// <summary>
        /// Indicates that the caller's claims must be associated with the values in the supplied property name 
        /// using the optional authorization path modifier, if supplied.
        /// </summary>
        /// <param name="propertyName">The names of the property with which the claim must be associated.</param>
        /// <param name="authorizationPathModifier">An optional value that identifies an alternative path through the ODS data model for authorization.</param>
        /// <returns>The <see cref="AuthorizationBuilder{TContextData}"/> instance, for chaining methods together.</returns>
        public AuthorizationBuilder<TContextData> ClaimsMustBeAssociatedWith(string propertyName, string authorizationPathModifier = null)
        {
            if (_contextData == null)
            {
                return ClaimsMustBeAssociatedWith(CreateSegment(propertyName, authorizationPathModifier));
            }

            return ClaimsMustBeAssociatedWith(CreateSegmentWithValue(propertyName, authorizationPathModifier));
        }

        /// <summary>
        /// Indicates that the caller's claims must be associated with the values in the supplied property names.
        /// </summary>
        /// <param name="propertyNames">The names of the properties with which the claim must be associated.</param>
        /// <returns>The <see cref="AuthorizationBuilder{TContextData}"/> instance, for chaining methods together.</returns>
        public AuthorizationBuilder<TContextData> ClaimsMustBeAssociatedWith(string[] propertyNames)
        {
            if (_contextData == null)
            {
                return ClaimsMustBeAssociatedWith(
                    propertyNames.Select(pn => CreateSegment(pn, null))
                                 .ToArray());
            }

            return ClaimsMustBeAssociatedWith(
                propertyNames.Select(pn => CreateSegmentWithValue(pn, null))
                             .ToArray());
        }

        /// <summary>
        /// Indicates that the caller's claims must be associated with the values in the supplied segment properties,
        /// allowing for the introduction of an "authorization path modifier", used to change how authorization is performed
        /// against the ODS data.
        /// </summary>
        /// <param name="segmentProperties">An array of <see cref="SegmentProperty"/> instances, providing a property name and authorization path modifier.</param>
        /// <returns>The <see cref="AuthorizationBuilder{TContextData}"/> instance, for chaining methods together.</returns>
        public AuthorizationBuilder<TContextData> ClaimsMustBeAssociatedWith(params SegmentProperty[] segmentProperties)
        {
            if (_contextData == null)
            {
                foreach (var segmentProperty in segmentProperties)
                {
                    _claimsAuthorizationSegments.Add(
                        new ClaimsAuthorizationSegment(
                            _claimAuthorizationValues.Value,
                            new AuthorizationSegmentEndpoint(
                                segmentProperty.PropertyName,
                                segmentProperty.PropertyType),
                            segmentProperty.AuthorizationPathModifier));
                }
            }
            else
            {
                foreach (var segmentProperty in segmentProperties)
                {
                    _claimsAuthorizationSegments.Add(
                        new ClaimsAuthorizationSegment(
                            _claimAuthorizationValues.Value,
                            new AuthorizationSegmentEndpointWithValue(
                                segmentProperty.PropertyName,
                                segmentProperty.PropertyType,
                                segmentProperty.PropertyValue),
                            segmentProperty.AuthorizationPathModifier));
                }
            }

            return this;
        }

        private SegmentProperty CreateSegment(string propertyName, string authorizationPathModifier)
        {
            var propertyInfo = typeof(TContextData).GetProperty(propertyName);

            if (propertyInfo == null)
            {
                throw new Exception(
                    string.Format(
                        "Property '{0}' not found on authorization context data type '{1}'.",
                        propertyName,
                        typeof(TContextData).Name));
            }

            return new SegmentProperty(propertyName, propertyInfo.PropertyType, authorizationPathModifier);
        }

        private SegmentProperty CreateSegmentWithValue(string propertyName, string authorizationPathModifier)
        {
            if (propertyName.EqualsIgnoreCase("EducationOrganizationId")
                && _contextData.ConcreteEducationOrganizationIdPropertyName != null)
            {
                propertyName = _contextData.ConcreteEducationOrganizationIdPropertyName;
            }

            var propertyInfo = typeof(TContextData).GetProperty(propertyName);

            if (propertyInfo == null)
            {
                throw new Exception(
                    string.Format(
                        "Property '{0}' not found on authorization context data type '{1}'.",
                        propertyName,
                        typeof(TContextData).Name));
            }

            return new SegmentProperty(propertyName, propertyInfo.PropertyType, propertyInfo.GetValue(_contextData), authorizationPathModifier);
        }

        private SegmentProperty CreateSegment<TResult1>(Expression<Func<TContextData, TResult1>> propertyExpression, string authorizationPathModifier)
        {
            var expr = propertyExpression.Body as MemberExpression;

            if (expr == null || expr.Member.MemberType != MemberTypes.Property)
            {
                throw new ArgumentException(
                    "Argument must be a MemberExpression referencing a property.",
                    "propertyExpression");
            }

            // Get the name of the property being accessed
            return new SegmentProperty(expr.Member.Name, expr.Type, null, authorizationPathModifier);
        }

        private SegmentProperty CreateSegmentWithValue<TResult>(
            Expression<Func<TContextData, TResult>> propertySelection,
            string authorizationPathModifier)
        {
            var expr = propertySelection.Body as MemberExpression;

            if (expr == null || expr.Member.MemberType != MemberTypes.Property)
            {
                throw new ArgumentException(
                    "Argument must be a MemberExpression referencing a property.",
                    "propertySelection");
            }

            // Get the name of the property being accessed
            string name = expr.Member.Name;

            // Translate resolved EdOrgIds to the appropriate endpoint name
            if (name.EqualsIgnoreCase("EducationOrganizationId")
                && _contextData.ConcreteEducationOrganizationIdPropertyName != null)
            {
                return CreateSegmentWithValue(
                    _contextData.ConcreteEducationOrganizationIdPropertyName,
                    authorizationPathModifier);
            }

            // Get (or save) the compiled Func, by name
            var getValue = (Func<TContextData, TResult>) propertyAccessorsByName
               .GetOrAdd(name, n => propertySelection.Compile());

            // Get the value off the authorization context data instance
            object authorizationValue = _contextData == null
                ? default(TResult)
                : getValue(_contextData);

            // Create a tuple representing the referenced value
            var resultTuple = new SegmentProperty(name, expr.Type, authorizationValue, authorizationPathModifier);

            return resultTuple;
        }
    }
}
