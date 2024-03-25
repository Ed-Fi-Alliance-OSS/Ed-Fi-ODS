// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security.Claims;

/// <summary>
/// Indicates the phase of authorization for which the authorization context has been created.
/// </summary>
public enum AuthorizationPhase
{
    ProposedData = 1,
    ExistingData,
}
