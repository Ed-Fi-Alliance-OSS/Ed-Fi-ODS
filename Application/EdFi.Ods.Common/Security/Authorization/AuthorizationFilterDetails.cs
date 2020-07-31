// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Contains details related to applying an authorization-based filter to the query for a single set of endpoints of
    /// an authorization segment (i.e. a particular property on the subject resource and a particular property/value on
    /// the API client's claim).
    /// </summary>
    public class AuthorizationFilterDetails
    {
        /// <summary>
        /// Get or sets the name of the filter definition as defined by an <see cref="INHibernateFilterConfigurator" /> implementation. 
        /// </summary>
        public string FilterName { get; set; }
        
        /// <summary>
        /// The property/column of the authorization subject.
        /// </summary>
        public string SubjectEndpointName { get; set; }

        /// <summary>
        /// The property/column of the authorization view for which the API client has a claim value.
        /// </summary>
        public string ClaimEndpointName { get; set; }

        /// <summary>
        /// The values associated with the API client's claim.
        /// </summary>
        public object[] ClaimValues { get; set; }
    }
}