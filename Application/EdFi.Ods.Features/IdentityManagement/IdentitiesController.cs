// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.IdentityManagement.Models;

namespace EdFi.Ods.Features.IdentityManagement;

/// <summary>
/// Closes the Identities base controller around the default request/response model types to enable ASP.NET to find
/// and instantiate it.
/// </summary>
/// <remarks>You can extend the default Identities request/response models by registering replacement services
/// with different (derived) model types, and then providing a new controller that derives from the <see cref="IdentitiesControllerBase{TCreateRequest,TSearchRequest,TSearchResponse,TIdentityResponse}"/>
/// class and closes the generic type definition so that ASP.NET will locate and instantiate it (instead of the
/// out-of-the-box <see cref="IdentitiesController" />.
/// </remarks>
public class IdentitiesController
    : IdentitiesControllerBase<IdentityCreateRequest, IdentitySearchRequest, IdentitySearchResponse<IdentityResponse>,
        IdentityResponse>
{
    public IdentitiesController(
        IIdentityServiceWithDefaultModels identitySubsystem,
        IIdentityServiceWithDefaultModelsAsync identitySubsystemAsync)
        : base(identitySubsystem, identitySubsystemAsync) { }
}
