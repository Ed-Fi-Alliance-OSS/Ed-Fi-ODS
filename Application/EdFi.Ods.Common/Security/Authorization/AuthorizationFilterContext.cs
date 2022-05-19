// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Infrastructure.Filtering;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Contains details related to applying an authorization-based filter to the query for a single set of endpoints of
    /// an authorization segment (i.e. a particular property on the subject resource and a particular property/value on
    /// the API client's claim).
    /// </summary>
    public class AuthorizationFilterContext
    {
        /// <summary>
        /// Get or sets the name of the filter definition as defined by an <see cref="IAuthorizationFilterDefinitionsFactory" /> implementation. 
        /// </summary>
        public string FilterName { get; set; }
        
        /// <summary>
        /// The name of the property that is the subject of the authorization filter (may contain a role name).
        /// </summary>
        public string SubjectEndpointName { get; set; }

        /// <summary>
        /// The name of the parameter representing a claim value held by the API client to be used in the query against the authorization view.
        /// </summary>
        public string ClaimParameterName { get; set; }

        /// <summary>
        /// The raw values associated with the API client's claim(s).
        /// </summary>
        public object[] ClaimEndpointValues { get; set; }

        private object[] _claimParameterValues;
        
        /// <summary>
        /// The database parameter values associated with the API client's claim(s).
        /// </summary>
        public object[] ClaimParameterValues {
            get
            {
                if (_claimParameterValues == null)
                {
                    if (ClaimParameterValueMap == null)
                    {
                        _claimParameterValues = ClaimEndpointValues;
                    }
                    else
                    {
                        _claimParameterValues = ClaimEndpointValues.Select(o => ClaimParameterValueMap(o)).ToArray();
                    }
                }

                return _claimParameterValues;
            }
        }

        /// <summary>
        /// Gets or sets a map function to convert the raw claim values to database parameter values (e.g. for values used in a LIKE statement).
        /// </summary>
        public Func<object, object> ClaimParameterValueMap { get; set; }

        /// <summary>
        /// For single item authorization scenarios, gets or sets the value associated with the subject endpoint for authorization.
        /// </summary>
        public object SubjectEndpointValue { get; set; }
    }
}