// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace GenerateSecurityGraphs.Models.AuthorizationMetadata
{
    public class EffectiveActionAndStrategy
    {
        public EffectiveActionAndStrategy(string claimName, string actionName)
        {
            ClaimName = claimName;
            ActionName = actionName;
        }

        public string ClaimName { get; }

        public string ActionName { get; }

        public bool? ActionGranted { get; private set; }

        public bool ActionInherited { get; private set; }

        public HashSet<string> AuthorizationStrategy { get; private set; }

        public string AuthorizationStrategyOriginatingClaimName { get; private set; }

        public bool AuthorizationStrategyInherited { get; private set; }

        public bool AuthorizationStrategyIsDefault { get; private set; }

        public HashSet<string> OverriddenClaimSetAuthorizationStrategy { get; private set; }

        public string OverriddenClaimSetAuthorizationStrategyOriginatingClaimName { get; private set; }

        public bool OverriddenClaimSetAuthorizationStrategyInherited { get; private set; }

        public HashSet<string> OverriddenDefaultAuthorizationStrategy { get; private set; }

        public string OverriddenDefaultAuthorizationStrategyOriginatingClaimName { get; private set; }

        public bool OverriddenDefaultAuthorizationStrategyInherited { get; private set; }

        public bool TrySetActionGranted(bool inherited)
        {
            if (ActionGranted == true)
            {
                return false;
            }

            ActionGranted = true;
            ActionInherited = inherited;

            return true;
        }

        /// <summary>
        /// Sets the effective authorization strategy.
        /// This method must be called in increasing order of significance.
        /// </summary>
        public bool TrySetAuthorizationStrategy(HashSet<string> strategyName, string originatingClaimName, bool inherited, bool isDefault)
        {
            // Strategy name is required
            if (strategyName == null || strategyName.Count == 0)
            {
                return false;
            }

            // If we already have a strategy, where should it go?
            if (AuthorizationStrategy != null)
            {
                if (AuthorizationStrategyIsDefault)
                {
                    OverriddenDefaultAuthorizationStrategy = AuthorizationStrategy;
                    OverriddenDefaultAuthorizationStrategyInherited = AuthorizationStrategyInherited;

                    if (AuthorizationStrategyInherited)
                    {
                        OverriddenDefaultAuthorizationStrategyOriginatingClaimName =
                            AuthorizationStrategyOriginatingClaimName;
                    }
                }
                else
                {
                    OverriddenClaimSetAuthorizationStrategy = AuthorizationStrategy;
                    OverriddenClaimSetAuthorizationStrategyInherited = AuthorizationStrategyInherited;

                    if (AuthorizationStrategyInherited)
                    {
                        OverriddenClaimSetAuthorizationStrategyOriginatingClaimName =
                            AuthorizationStrategyOriginatingClaimName;
                    }
                }
            }

            AuthorizationStrategy = strategyName;
            AuthorizationStrategyOriginatingClaimName = originatingClaimName;
            AuthorizationStrategyInherited = inherited;
            AuthorizationStrategyIsDefault = isDefault;

            return true;
        }

        public bool IsIndeterminate()
        {
            return ActionGranted != true // We're not dealing with an actual claim grant
                && (AuthorizationStrategy == null || AuthorizationStrategy != null && AuthorizationStrategyInherited); // No local authorization
        }

        public override string ToString()
        {
            return ActionGranted == true 
                ? $"Granted - {(AuthorizationStrategy == null ? "*No Strategy*" : string.Join(", ", AuthorizationStrategy))} (inherited={AuthorizationStrategyInherited}; isDefault={AuthorizationStrategyIsDefault})"
                : "Not Granted";
        }
    }
}
