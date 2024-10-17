// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Extensions;

public static class AuthorizationPhaseExtensions
{
    /// <summary>
    /// Gets one of two possible strings supplied corresponding to the authorization phase of the authorization context.
    /// </summary>
    /// <param name="authorizationPhase">The current authorization phase.</param>
    /// <param name="existingDataText">The text to return if the phase is <see cref="AuthorizationPhase.ExistingData"/></param>
    /// <param name="proposedDataText">The text to return if the phase is <see cref="AuthorizationPhase.ProposedData"/></param>
    /// <returns>The appropriate supplied string.</returns>
    public static string GetPhaseText(
        this AuthorizationPhase authorizationPhase,
        string existingDataText = null,
        string proposedDataText = null)
    {
        return authorizationPhase == AuthorizationPhase.ExistingData
            ? existingDataText
            : proposedDataText;
    }
}
