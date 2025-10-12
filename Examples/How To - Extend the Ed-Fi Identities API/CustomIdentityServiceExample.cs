// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Container;
using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.IdentityManagement.Models;

namespace CustomIdentityService;

// ----------------------------------------
//            Custom Module
// ----------------------------------------
public class CustomIdentityServiceModule : ConditionalModule, ICustomModule
{
    public CustomIdentityServiceModule(ApiSettings apiSettings)
        : base(apiSettings, nameof(CustomIdentityServiceModule)) { }

    public override bool IsSelected() => IsFeatureEnabled(ApiFeature.IdentityManagement);

    public override void ApplyConfigurationSpecificRegistrations(ContainerBuilder builder)
    {
        builder.RegisterType<CustomIdentityService>()
            .AsImplementedInterfaces()
            .SingleInstance();
    }
}

// ----------------------------------------
//     Custom Request/Response Models
// ----------------------------------------
public class CustomSearchRequest : IdentitySearchRequest
{
    public bool CreateUICOnNoMatch { get; set; }

    public string SchoolFacilityEntityid { get; set; }

    public string OperatingDistrictEntityid { get; set; }

    public string LocalIdentifier { get; set; }
}

public class CustomCreateRequest : IdentityCreateRequest
{
    public string ReasonForRequest { get; set; }

    public string SchoolFacilityEntityid { get; set; }

    public string OperatingDistrictEntityid { get; set; }

    public string LocalIdentifier { get; set; }
}

public class CustomIdentityResponse : IdentityResponse
{
    public string FavoriteColor { get; set; }
}

public class CustomSearchResponse : IdentitySearchResponse<CustomIdentityResponse>
{
    // No additions, and technically not required
}

// ---------------------------------------------------------------------
//  Custom Service Interface (closes generic types with custom models)
// ---------------------------------------------------------------------
public interface IIdentityServiceWithCustomModels
    : IIdentityService<CustomCreateRequest, CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse>,
        IIdentityServiceAsync<CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse> { }

// -------------------------------------------------------------------
//  Custom Controller (closes generic types, discoverable by ASP.NET)
// -------------------------------------------------------------------
public class CustomIdentitiesController
    : IdentitiesControllerBase<CustomCreateRequest, CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse>
{
    public CustomIdentitiesController(
        IIdentityService<CustomCreateRequest, CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse>
            identitySubsystem,
        IIdentityServiceAsync<CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse> identitySubsystemAsync)
        : base(identitySubsystem, identitySubsystemAsync) { }
}

// -------------------------------
//  Custom Service Implementation
// -------------------------------
public class CustomIdentityService : IIdentityServiceWithCustomModels
{
    public IdentityServiceCapabilities IdentityServiceCapabilities { get; } =
        IdentityServiceCapabilities.Create | IdentityServiceCapabilities.Results;

    public Task<IdentityResponseStatus<string>> Create(CustomCreateRequest createRequest)
        => Task.FromResult(
            new IdentityResponseStatus<string>()
            {
                Data = "data",
                StatusCode = IdentityStatusCode.Success,
            });

    Task<IdentityResponseStatus<CustomSearchResponse>>
        IIdentityService<CustomCreateRequest, CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse>.
        Find(params string[] findRequest)
        => Task.FromResult(
            new IdentityResponseStatus<CustomSearchResponse>()
            {
                Data = new CustomSearchResponse()
                {
                    Status = SearchResponseStatus.Complete,
                    SearchResponses = new[]
                    {
                        new IdentitySearchResponses<CustomIdentityResponse>()
                        {
                            Responses = new[]
                            {
                                new CustomIdentityResponse()
                                {
                                    FirstName = "John",
                                    LastSurname = "Doe",
                                    FavoriteColor = "Blue",
                                }
                            }
                        }
                    }
                }
            });

    Task<IdentityResponseStatus<string>> IIdentityServiceAsync<CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse>.
        Search(params CustomSearchRequest[] searchRequest)
        => Task.FromResult(
            new IdentityResponseStatus<string>()
            {
                Data = "data",
                StatusCode = IdentityStatusCode.Success
            });

    public Task<IdentityResponseStatus<CustomSearchResponse>> Response(string requestToken)
        => Task.FromResult(
            new IdentityResponseStatus<CustomSearchResponse>()
            {
                Data = new CustomSearchResponse()
                {
                    Status = SearchResponseStatus.Complete,
                    SearchResponses = new[]
                    {
                        new IdentitySearchResponses<CustomIdentityResponse>()
                        {
                            Responses = new[]
                            {
                                new CustomIdentityResponse()
                                {
                                    FirstName = "John",
                                    LastSurname = "Doe",
                                    FavoriteColor = "Red",
                                }
                            }
                        }
                    }
                }
            });

    Task<IdentityResponseStatus<string>> IIdentityServiceAsync<CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse>.
        Find(params string[] findRequest)
        => Task.FromResult(
            new IdentityResponseStatus<string>()
            {
                Data = "data",
                StatusCode = IdentityStatusCode.Success
            });

    Task<IdentityResponseStatus<CustomSearchResponse>>
        IIdentityService<CustomCreateRequest, CustomSearchRequest, CustomSearchResponse, CustomIdentityResponse>.
        Search(params CustomSearchRequest[] searchRequest)
        => Task.FromResult(
            new IdentityResponseStatus<CustomSearchResponse>()
            {
                Data = new CustomSearchResponse()
                {
                    Status = SearchResponseStatus.Complete,
                    SearchResponses = new[]
                    {
                        new IdentitySearchResponses<CustomIdentityResponse>()
                        {
                            Responses = new[]
                            {
                                new CustomIdentityResponse()
                                {
                                    FirstName = "John",
                                    LastSurname = "Doe",
                                    FavoriteColor = "Green",
                                }
                            }
                        }
                    }
                }
            });
}
