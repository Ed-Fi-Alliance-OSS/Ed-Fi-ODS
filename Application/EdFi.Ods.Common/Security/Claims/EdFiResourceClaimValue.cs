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
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class.
        /// </summary>
        public EdFiResourceClaimValue()
        {
            // JSON.NET uses this for deserialization.  In that situation we want the list to be initialized.
            EducationOrganizationIds = new List<int>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class using the specified action.
        /// </summary>
        /// <param name="action">The action the claim is authorized to perform on the resource.</param>
        public EdFiResourceClaimValue(string action)
            : this(action, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class using the specified action and authorization strategy name override.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="authorizationStrategyNameOverrides">The names of the authorization strategies that should be used for authorization (in lieu of the default for the resource).</param>
        public EdFiResourceClaimValue(string action, IReadOnlyList<string> authorizationStrategyNameOverrides)
            : this(action, null, authorizationStrategyNameOverrides) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class using the specified action and Education Organization ids.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="educationOrganizationIds">The education organization ids to which the claim applies.</param>
        public EdFiResourceClaimValue(string action, List<int> educationOrganizationIds)
            : this(
                action,
                educationOrganizationIds ?? new List<int>(),
                null) // List initialized here to preserve original constructor behavior after introducing authorization strategy overrides.
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class using the specified action, Education Organization ids, and authorization strategy name override.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="educationOrganizationIds">The education organization ids to which the claim applies.</param>
        /// <param name="authorizationStrategyNameOverrides">The names of the authorization strategies that should be used for authorization (in lieu of the default for the resource).</param>
        public EdFiResourceClaimValue(string action, List<int> educationOrganizationIds, IReadOnlyList<string> authorizationStrategyNameOverrides)
        {
            Actions = new[]
                      {
                          new ResourceAction(action, authorizationStrategyNameOverrides)
                      };

            EducationOrganizationIds = educationOrganizationIds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class using the specified action, Education Organization ids, and authorization strategy and validation rule set name overrides.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="educationOrganizationIds">The education organization ids to which the claim applies.</param>
        /// <param name="authorizationStrategyNameOverrides">The names of the authorization strategies that should be used for authorization (in lieu of any default defined for the resource).</param>
        /// <param name="validationRuleSetNameOverride">The name of the validation rule set to be executed during authorization (in lieu of any default defined for the resource).</param>
        public EdFiResourceClaimValue(
            string action,
            List<int> educationOrganizationIds,
            IReadOnlyList<string> authorizationStrategyNameOverrides,
            string validationRuleSetNameOverride)
        {
            Actions = new[]
                      {
                          new ResourceAction(action, authorizationStrategyNameOverrides, validationRuleSetNameOverride)
                      };

            EducationOrganizationIds = educationOrganizationIds;
        }

        /// <summary>
        /// Gets or sets the actions that can be performed by the claim on the resource.
        /// </summary>
        public ResourceAction[] Actions { get; set; }

        /// <summary>
        /// Gets or sets the Education Organization Ids to which the claim applies.
        /// </summary>
        public List<int> EducationOrganizationIds { get; set; }

        /// <summary>
        /// Attempts to obtain the names of the authorization strategy overrides for the specified action.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="authorizationStrategyNameOverrides">If found, will contain the names of the authorization strategies that should be used for authorization (in lieu of the default for the resource).</param>
        /// <returns><b>true</b> if the specified action had authorization strategy overrides; otherwise <b>false</b>.</returns>
        public bool TryGetAuthorizationStrategyOverride(string action, out IReadOnlyList<string> authorizationStrategyNameOverrides)
        {
            authorizationStrategyNameOverrides = GetAuthorizationStrategyNameOverrides(action);

            return authorizationStrategyNameOverrides != null;
        }

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
        /// Initializes a new instance of the <see cref="ResourceAction"/> class using the specified action.
        /// </summary>
        /// <param name="name">The name (URI) of the action.</param>
        public ResourceAction(string name)
            : this(name, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAction"/> class using the specified action and authorization strategy name overrides.
        /// </summary>
        /// <param name="name">The name (URI) of the action.</param>
        /// <param name="authorizationStrategyNameOverrides">The names of the authorization strategies that should be used for authorization (in lieu of the default for the resource).</param>
        public ResourceAction(string name, IReadOnlyList<string> authorizationStrategyNameOverrides)
            : this(name, authorizationStrategyNameOverrides, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAction"/> class using the specified action and overrides for authorization strategy names and and validation rule set name.
        /// </summary>
        /// <param name="name">The name (URI) of the action.</param>
        /// <param name="authorizationStrategyNameOverrides">The names of the authorization strategies that should be used for authorization (in lieu of the default for the resource).</param>
        /// <param name="validationRuleSetNameOverride">The name of the rule set to be executed.</param>
        public ResourceAction(string name, IReadOnlyList<string> authorizationStrategyNameOverrides, string validationRuleSetNameOverride)
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
