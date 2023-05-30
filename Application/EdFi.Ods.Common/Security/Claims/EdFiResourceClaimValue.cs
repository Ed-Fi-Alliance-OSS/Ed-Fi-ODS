// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Security.Claims
{
    /// <summary>
    /// Provides a concrete model for creating and accessing the serialized JSON of the Ed-Fi resource claim values.
    /// </summary>
    public class EdFiResourceClaimValue
    {
        /// <summary>
        /// Gets or sets the actions that can be performed by the claim on the resource.
        /// </summary>
        public ResourceAction[] Actions { get; set; }

        /// <summary>
        /// Gets the names of authorization strategy overrides for the specified action, if present.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <returns>The authorization strategy override for the specified action; otherwise <b>null</b>.</returns>
        public IReadOnlyList<string> GetAuthorizationStrategyNameOverrides(string action)
        {
            return
                Actions.FirstOrDefault(x => x.Name == action)
                       ?.AuthorizationStrategyNameOverrides;
        }

        /// <summary>
        /// Gets the names of the authorization strategy overrides for the specified action, if present.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <returns>The authorization validation rule set name override for the specified action; otherwise <b>null</b>.</returns>
        public string GetAuthorizationValidationRuleSetNameOverride(string action)
        {
            return
                Actions.Where(x => x.Name == action)
                       .Select(x => x.ValidationRuleSetNameOverride)
                       .FirstOrDefault();
        }
    }

    /// <summary>
    /// Defines properties for identifying the action and (possibly) authorization strategy name override.
    /// </summary>
    public class ResourceAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAction"/> class.
        /// </summary>
        public ResourceAction() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAction"/> class using the specified action and overrides for authorization strategy names and and validation rule set name.
        /// </summary>
        /// <param name="name">The name (URI) of the action.</param>
        /// <param name="authorizationStrategyNameOverrides">The names of the authorization strategies that should be used for authorization (in lieu of the default for the resource).</param>
        /// <param name="validationRuleSetNameOverride">The name of the rule set to be executed.</param>
        public ResourceAction(string name, IReadOnlyList<string> authorizationStrategyNameOverrides = null, string validationRuleSetNameOverride = null)
        {
            Name = name;
            AuthorizationStrategyNameOverrides = authorizationStrategyNameOverrides;
            ValidationRuleSetNameOverride = validationRuleSetNameOverride;
        }

        /// <summary>
        /// Gets or sets the name (URI) of the action.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the names of the authorization strategies that should be used for authorization (in lieu of the default for the resource).
        /// </summary>
        public IReadOnlyList<string> AuthorizationStrategyNameOverrides { get; set; }

        /// <summary>
        /// Gets or sets the name of the rule set that should be used to validate the entity for the action.
        /// </summary>
        public string ValidationRuleSetNameOverride { get; set; }
    }
}
