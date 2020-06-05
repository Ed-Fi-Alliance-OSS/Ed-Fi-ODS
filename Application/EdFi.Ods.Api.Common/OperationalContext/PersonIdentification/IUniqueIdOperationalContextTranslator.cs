// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.OperationalContext.PersonIdentification
{
    /// <summary>
    /// Defines methods for translating unique Id values between host and client operational contexts.
    /// </summary>
    public interface IUniqueIdOperationalContextTranslator
    {
        /// <summary>
        /// Translates a supplied unique Id value to the API's host operational context,
        /// translating (if necessary) from the client's associated person identification system
        /// to the UniqueId stored for the person in the host's API.
        /// </summary>
        /// <param name="personType">The type of person to which the unique Id applies.</param>
        /// <param name="clientUniqueId">The client supplied unique Id value representing the
        /// known identifying value from the client's associated person identification system.</param>
        /// <param name="isLocallyDefined">Indicates whether the UniqueId property is defined on the current resource, or is part of a reference.</param>
        /// <returns>The host's stored unique Id value for the person.</returns>
        /// <exception cref="AmbiguousUniqueIdMatchException">Occurs when the client-supplied unique Id value resolves to multiple people.</exception>
        /// <exception cref="NoUniqueIdMatchException">Occurs when the client-supplied unique Id value cannot be resolved to any person.</exception>
        string TranslateToHostContext(string personType, string clientUniqueId, bool isLocallyDefined);

        /// <summary>
        /// Translates a stored unique Id value to the API's client's operational context,
        /// translating (if necessary) from the host's stored UniqueId value for the person
        /// to the identification code associated with the client's associated person
        /// identification system.
        /// </summary>
        /// <param name="personType">The type of person to which the unique Id applies.</param>
        /// <param name="hostUniqueId">The stored unique Id value stored by the host.</param>
        /// <returns>The identifying value used by the API client based on the client's associated person identification system, or the host's stored value if no identification system has been associated to the client.</returns>
        string TranslateToClientContext(string personType, string hostUniqueId);
    }
}
