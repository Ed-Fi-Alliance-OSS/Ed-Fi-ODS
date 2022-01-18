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
        /// <param name="authorizationStrategyNameOverride">The name of the authorization strategy that should be used for authorization (in lieu of the default for the resource).</param>
        public EdFiResourceClaimValue(string action, string authorizationStrategyNameOverride)
            : this(action, null, authorizationStrategyNameOverride) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class using the specified action and Education Organization ids.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="educationOrganizationIds">The Local Education Agency Ids to which the claim applies.</param>
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
        /// <param name="educationOrganizationIds">The Local Education Agency Ids to which the claim applies.</param>
        /// <param name="authorizationStrategyNameOverride">The name of the authorization strategy that should be used for authorization (in lieu of the default for the resource).</param>
        public EdFiResourceClaimValue(string action, List<int> educationOrganizationIds, string authorizationStrategyNameOverride)
        {
            Actions = new[]
                      {
                          new ResourceAction(action, authorizationStrategyNameOverride)
                      };

            EducationOrganizationIds = educationOrganizationIds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiResourceClaimValue"/> class using the specified action, Education Organization ids, and authorization strategy and validation rule set name overrides.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="educationOrganizationIds">The Local Education Agency Ids to which the claim applies.</param>
        /// <param name="authorizationStrategyNameOverride">The name of the authorization strategy that should be used for authorization (in lieu of any default defined for the resource).</param>
        /// <param name="validationRuleSetNameOverride">The name of the validation rule set to be executed during authorization (in lieu of any default defined for the resource).</param>
        public EdFiResourceClaimValue(
            string action,
            List<int> educationOrganizationIds,
            string authorizationStrategyNameOverride,
            string validationRuleSetNameOverride)
        {
            Actions = new[]
                      {
                          new ResourceAction(action, authorizationStrategyNameOverride, validationRuleSetNameOverride)
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
        /// Attempts to obtain an authorization strategy override for the specified action.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <param name="authorizationStrategyNameOverride">If found, will contain the name of the authorization strategy that should be used for authorization (in lieu of the default for the resource).</param>
        /// <returns><b>true</b> if the specified action had an authorization strategy override; otherwise <b>false</b>.</returns>
        public bool TryGetAuthorizationStrategyOverride(string action, out string authorizationStrategyNameOverride)
        {
            authorizationStrategyNameOverride = GetAuthorizationStrategyNameOverride(action);

            return !string.IsNullOrEmpty(authorizationStrategyNameOverride);
        }

        /// <summary>
        /// Gets the name of authorization strategy override for the specified action, if present.
        /// </summary>
        /// <param name="action">The action URI representing the action that the claim is authorized to perform on the resource.</param>
        /// <returns>The authorization strategy override for the specified action; otherwise <b>null</b>.</returns>
        public string GetAuthorizationStrategyNameOverride(string action)
        {
            return
                Actions.Where(x => x.Name == action)
                       .Select(x => x.AuthorizationStrategyNameOverride)
                       .FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of authorization strategy override for the specified action, if present.
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
        /// Initializes a new instance of the <see cref="ResourceAction"/> class using the specified action and authorization strategy name override.
        /// </summary>
        /// <param name="name">The name (URI) of the action.</param>
        /// <param name="authorizationStrategyNameOverride">The name of the authorization strategy that should be used for authorization (in lieu of the default for the resource).</param>
        public ResourceAction(string name, string authorizationStrategyNameOverride)
            : this(name, authorizationStrategyNameOverride, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAction"/> class using the specified action and overrides for authorization strategy name and validation rule set name.
        /// </summary>
        /// <param name="name">The name (URI) of the action.</param>
        /// <param name="authorizationStrategyNameOverride">The name of the authorization strategy that should be used for authorization (in lieu of the default for the resource).</param>
        /// <param name="validationRuleSetNameOverride">The name of the rule set to be executed.</param>
        public ResourceAction(string name, string authorizationStrategyNameOverride, string validationRuleSetNameOverride)
        {
            Name = name;
            AuthorizationStrategyNameOverride = authorizationStrategyNameOverride;
            ValidationRuleSetNameOverride = validationRuleSetNameOverride;
        }

        /// <summary>
        /// Gets or sets the name (URI) of the action.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the authorization strategy that should be used for authorization (in lieu of the default for the resource).
        /// </summary>
        public string AuthorizationStrategyNameOverride { get; set; }

        /// <summary>
        /// Gets or sets the name of the rule set that should be used to validate the entity for the action.
        /// </summary>
        public string ValidationRuleSetNameOverride { get; set; }
    }
}
