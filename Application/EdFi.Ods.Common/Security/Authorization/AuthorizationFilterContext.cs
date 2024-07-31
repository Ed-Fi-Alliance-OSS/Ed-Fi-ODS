// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
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
        private string _subjectEndpointName;
        private string[] _subjectEndpointNames;
        private object _subjectEndpointValue;
        private IList<object> _subjectEndpointValues;
        
        /// <summary>
        /// Get or sets the name of the filter definition as defined by an <see cref="IAuthorizationFilterDefinitionsFactory" /> implementation. 
        /// </summary>
        public string FilterName { get; set; }

        /// <summary>
        /// The name of the property that is the subject of the authorization filter (may contain a role name).
        /// </summary>
        /// <remarks>This property is retained for backwards compatibility with authorization scenarios that already exist
        /// that were designed to support a single authorization subject endpoint. Use the <see cref="SubjectEndpointNames" /> property
        /// which uses and array for future implementations.</remarks>
        public string SubjectEndpointName
        {
            get
            {
                // Ensure an error occurs if the single-endpoint property is requested and a multi-item array has been set
                return _subjectEndpointName ?? _subjectEndpointNames?.SingleOrDefault();
            }
            set
            {
                if (_subjectEndpointNames != null)
                {
                    throw new InvalidOperationException("Cannot set SubjectEndpointName when SubjectEndpointNames is already set.");
                }

                _subjectEndpointName = value;
            }
        }

        /// <summary>
        /// The names of the properties that are the subject of the authorization filter (may contain a role names).
        /// </summary>
        public string[] SubjectEndpointNames
        {
            get
            {
                return _subjectEndpointNames ?? new[] { _subjectEndpointName };
            }
            set
            {
                if (_subjectEndpointName != null)
                {
                    throw new InvalidOperationException("Cannot set SubjectEndpointNames when SubjectEndpointName is already set.");
                }

                _subjectEndpointNames = value;
            }
        }

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
        public object[] ClaimParameterValues
        {
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
        /// <remarks>This property is retained for backwards compatibility with authorization scenarios that already exist
        /// that were designed to support a single authorization subject endpoint. Use the <see cref="SubjectEndpointValues" /> property
        /// which uses and array for future implementations.</remarks>
        public object SubjectEndpointValue
        {
            get
            {
                if (_subjectEndpointValues != null)
                {
                    throw new InvalidOperationException("Cannot use SubjectEndpointValue when SubjectEndpointValues is already set.");
                }

                return _subjectEndpointValue;
            }
            set
            {
                if (_subjectEndpointValues != null)
                {
                    throw new InvalidOperationException("Cannot set SubjectEndpointValue when SubjectEndpointValues is already set.");
                }

                _subjectEndpointValue = value;
            }
        }

        /// <summary>
        /// For single item authorization scenarios, gets or sets the values associated with the subject endpoints for authorization.
        /// </summary>
        public IList<object> SubjectEndpointValues
        {
            get
            {
                if (_subjectEndpointValue != null)
                {
                    throw new InvalidOperationException("Cannot use SubjectEndpointValues when SubjectEndpointValue is already set.");
                }

                return _subjectEndpointValues;
            }
            set
            {
                if (_subjectEndpointValue != null)
                {
                    throw new InvalidOperationException("Cannot set SubjectEndpointValues when SubjectEndpointValue is already set.");
                }

                _subjectEndpointValues = value;
            }
        }
    }
}
