// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Extensions;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Details
{
    public class RequestAuthorizationDetails
    {
        public RequestAuthorizationDetails(
            string authorizationStrategyName,
            string validationRuleSetName,
            Diagnostics authorizationStrategyDiagnostics,
            Diagnostics validationRuleSetDiagnostics)
        {
            // AuthorizationKey = authorizationKey;
            AuthorizationStrategyName = authorizationStrategyName;
            ValidationRuleSetName = validationRuleSetName;
            AuthorizationStrategyDiagnostics = authorizationStrategyDiagnostics;
            ValidationRuleSetDiagnostics = validationRuleSetDiagnostics;
        }

        public string AuthorizationStrategyName { get; }

        public string ValidationRuleSetName { get; }

        public Diagnostics AuthorizationStrategyDiagnostics { get; }

        public Diagnostics ValidationRuleSetDiagnostics { get; }

        public class Key
        {
            public Key(string resourceClaimUri, string actionUri, string claimSetName)
            {
                ResourceClaimUri = resourceClaimUri;
                ClaimSetName = claimSetName;
                ActionUri = actionUri;
            }

            public string ResourceClaimUri { get; }

            public string ClaimSetName { get; }

            public string ActionUri { get; }

            protected bool Equals(Key other)
                => ResourceClaimUri.EqualsIgnoreCase(other.ResourceClaimUri)
                    && ClaimSetName.EqualsIgnoreCase(other.ClaimSetName)
                    && ActionUri.EqualsIgnoreCase(other.ActionUri);

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }

                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj.GetType() != GetType())
                {
                    return false;
                }

                return Equals((Key) obj);
            }

            public override int GetHashCode() => HashCode.Combine(ResourceClaimUri.ToLower(), ClaimSetName.ToLower(), ActionUri.ToLower());
        }

        public class Diagnostics
        {
            public Diagnostics(string permissionsResourceClaimUri, string defaultsResourceClaimUri)
            {
                PermissionsResourceClaimUri = permissionsResourceClaimUri;
                DefaultsResourceClaimUri = defaultsResourceClaimUri;
            }

            public string PermissionsResourceClaimUri { get; }

            public string DefaultsResourceClaimUri { get; }
        }
    }
}
