﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Common.Security.Claims
{
    /// <summary>
    /// Defines a method for obtaining a list of claims (and the corresponding authorization strategies) 
    /// that can be used to authorize a resourceUri.
    /// </summary>
    [Intercept(InterceptorCacheKeys.Security)]
    public interface IResourceClaimAuthorizationMetadataLineageProvider
    {
        /// <summary>
        /// Gets the lineage of all resource claims (going up the resource claims taxonomy) that can be used to authorize the 
        /// request for specified resource and action, including the explicitly assigned authorization strategy (if applicable).
        /// </summary>
        /// <param name="resourceClaimUri">The URI representation of the resource associated with the request.</param>
        /// <param name="action">The action associated with the request.</param>
        /// <returns>The lineage of resource claims.</returns>
        IEnumerable<DefaultResourceClaimMetadata> GetAuthorizationLineage(string resourceClaimUri, string action);
    }

    /// <summary>
    /// Provides metadata about a resource claim and the associated authorization strategy name.
    /// </summary>
    public class DefaultResourceClaimMetadata
    {
        /// <summary>
        /// The URI of the claim type.
        /// </summary>
        public string ClaimName { get; set; }

        /// <summary>
        /// The names of the strategies to be used in the authorization decision.
        /// </summary>
        public IReadOnlyList<string> AuthorizationStrategies { get; set; }

        /// <summary>
        /// The name of the validation rule set to be executed during authorization of data modifying operations.
        /// </summary>
        public string ValidationRuleSetName { get; set; }
    }
}
