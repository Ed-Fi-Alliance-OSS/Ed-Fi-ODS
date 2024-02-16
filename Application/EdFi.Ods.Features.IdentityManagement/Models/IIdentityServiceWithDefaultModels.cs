// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.IdentityManagement.Models;

/// <summary>
/// Defines an interface that closes the generic types of the <see cref="IIdentityService{TCreateRequest,TSearchRequest,TSearchResponse,TIdentityResponse}" />
/// with the default Identities request/response models.
/// </summary>
public interface IIdentityServiceWithDefaultModels
    : IIdentityService<IdentityCreateRequest, IdentitySearchRequest, IdentitySearchResponse<IdentityResponse>,
        IdentityResponse> { };
