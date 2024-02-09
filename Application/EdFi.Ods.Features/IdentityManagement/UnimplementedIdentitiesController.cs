// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.IdentityManagement.Models;

namespace EdFi.Ods.Features.IdentityManagement;

// Define new controller that derives from the abstract controller that closes the generic types to
// enable ASP.NET to discover and instantiate it. 
public class UnimplementedIdentitiesController
    : IdentitiesControllerBase<IdentityCreateRequest, IdentitySearchRequest, IdentitySearchResponse<IdentityResponse>,
        IdentityResponse>
{
    public UnimplementedIdentitiesController(
        IUnimplementedIdentityService identitySubsystem,
        IUnimplementedIdentityServiceAsync identitySubsystemAsync)
        : base(identitySubsystem, identitySubsystemAsync) { }
}
