// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace GenerateSecurityGraphs.Models.AuthorizationMetadata
{
    public class EffectiveActionAndStrategy
    {
        public EffectiveActionAndStrategy(string resourceName, string actionName)
        {
            ResourceName = resourceName;
            ActionName = actionName;
        }

        public string ResourceName { get; }

        public string ActionName { get; }

        public bool? ActionGranted { get; private set; }

        public bool ActionInherited { get; private set; }

        public string AuthorizationStrategy { get; private set; }

        public string AuthorizationStrategyOriginatingResourceName { get; private set; }

        public bool AuthorizationStrategyInherited { get; private set; }

        public bool AuthorizationStrategyIsDefault { get; private set; }

        //public bool AuthorizationStrategyDefaulted { private set; get; }

        public string OverriddenClaimSetAuthorizationStrategy { get; private set; }

        public string OverriddenClaimSetAuthorizationStrategyOriginatingResourceName { get; private set; }

        public bool OverriddenClaimSetAuthorizationStrategyInherited { get; private set; }

        public string OverriddenDefaultAuthorizationStrategy { get; private set; }

        public string OverriddenDefaultAuthorizationStrategyOriginatingResourceName { get; private set; }

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

        // This method must be called in increasing order of significance

        public bool TrySetAuthorizationStrategy(string strategyName, string originatingResourceName, bool inherited, bool isDefault)
        {
            // Strategy name is required
            if (string.IsNullOrEmpty(strategyName))
            {
                return false;
            }

            // Check for no change in strategy name...
            //if (AuthorizationStrategy == strategyName)
            //    return false;

            // If we already have a strategy, where should it go?
            if (!string.IsNullOrEmpty(AuthorizationStrategy))
            {
                if (AuthorizationStrategyIsDefault)
                {
                    OverriddenDefaultAuthorizationStrategy = AuthorizationStrategy;
                    OverriddenDefaultAuthorizationStrategyInherited = AuthorizationStrategyInherited;

                    if (AuthorizationStrategyInherited)
                    {
                        OverriddenDefaultAuthorizationStrategyOriginatingResourceName =
                            AuthorizationStrategyOriginatingResourceName;
                    }
                }
                else
                {
                    OverriddenClaimSetAuthorizationStrategy = AuthorizationStrategy;
                    OverriddenClaimSetAuthorizationStrategyInherited = AuthorizationStrategyInherited;

                    if (AuthorizationStrategyInherited)
                    {
                        OverriddenClaimSetAuthorizationStrategyOriginatingResourceName =
                            AuthorizationStrategyOriginatingResourceName;
                    }
                }
            }

            AuthorizationStrategy = strategyName;
            AuthorizationStrategyOriginatingResourceName = originatingResourceName;
            AuthorizationStrategyInherited = inherited;
            AuthorizationStrategyIsDefault = isDefault;

            return true;
        }

        public bool IsIndeterminate()
        {
            if (ActionGranted != true // We're not dealing with an actual claim grant
                && (AuthorizationStrategy == null || AuthorizationStrategy != null && AuthorizationStrategyInherited)) // No local authorization
            {
                return true;
            }

            return false;
        }

        public bool TrySetOverriddenDefaultAuthorizationStrategy(string authorizationStrategy)
        {
            if (OverriddenDefaultAuthorizationStrategy != null || AuthorizationStrategy == authorizationStrategy)
            {
                return false;
            }

            OverriddenDefaultAuthorizationStrategy = authorizationStrategy;
            return true;
        }

        public override string ToString()
        {
            return ActionGranted == true
                ? "Granted - "
                  + (string.IsNullOrEmpty(AuthorizationStrategy)
                      ? "*No Strategy*"
                      : AuthorizationStrategy)
                  + " (inherited=" + AuthorizationStrategyInherited
                  + "; isDefault=" + AuthorizationStrategyIsDefault + ")"
                : "Not Granted";
        }
    }
}
