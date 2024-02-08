// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Features.IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;

using TestIdentityService = EdFi.Ods.Features.IdentityManagement.Models.IIdentityService<EdFi.Ods.Features.IdentityManagement.Models.IdentityCreateRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>, EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>; 
using TestIdentityServiceAsync = EdFi.Ods.Features.IdentityManagement.Models.IIdentityServiceAsync<EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchRequest, EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>, EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>; 
using TestIdentityResponseStatus = EdFi.Ods.Features.IdentityManagement.Models.IdentityResponseStatus<EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>>;
using TestIdentitySearchResponse = EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponse<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>;
using TestIdentitySearchResponses = EdFi.Ods.Features.IdentityManagement.Models.IdentitySearchResponses<EdFi.Ods.Features.IdentityManagement.Models.IdentityResponse>;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Helpers
{
    public class TestIdentitiesService : TestIdentityService, TestIdentityServiceAsync  
    {
        public enum ResponseBehaviour
        {
            Success,
            InvalidProperties,
            Incomplete,
            NotFound,
            UnknownStatusCode,
            NullErrorList
        }

        public IdentityServiceCapabilities IdentityServiceCapabilities => IdentityServiceCapabilities.Create
                                                                          | IdentityServiceCapabilities.Find
                                                                          | IdentityServiceCapabilities.Search
                                                                          | IdentityServiceCapabilities.Results;

        private readonly ResponseBehaviour _responseBehaviour;

        public TestIdentitiesService(ResponseBehaviour responseBehaviour)
        {
            _responseBehaviour = responseBehaviour;
        }

        public Task<IdentityResponseStatus<string>> Create(IdentityCreateRequest createRequest)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<string> { StatusCode = IdentityStatusCode.Success, Data = "ignored"}),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<string>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<string>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<string>(),
                ResponseBehaviour.UnknownStatusCode => BuildUnknownResponse<string>(),
                ResponseBehaviour.NullErrorList => Task.FromResult(
                    new IdentityResponseStatus<string>
                    {
                        StatusCode = IdentityStatusCode.Incomplete,
                    }),
                _ => throw new NotImplementedException()
            };
        }

        Task<IdentityResponseStatus<string>> TestIdentityServiceAsync.Find(params string[] findRequest)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<string> { StatusCode = IdentityStatusCode.Success, Data = "ignored" }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<string>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<string>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<string>(),
                _ => throw new NotImplementedException()
            };
        }

        public Task<TestIdentityResponseStatus> Find(params string[] findRequest)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new TestIdentityResponseStatus
                    {
                        Data = new TestIdentitySearchResponse
                        {
                            Status = SearchResponseStatus.Complete,
                            SearchResponses = new TestIdentitySearchResponses[]
                                {
                                    new() {Responses = new[] {new IdentityResponse {Score = 100, UniqueId = "ignored"}}}
                                }
                        },
                        StatusCode = IdentityStatusCode.Success
                    }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<IdentitySearchResponse<IdentityResponse>>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<IdentitySearchResponse<IdentityResponse>>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<IdentitySearchResponse<IdentityResponse>>(),
                _ => throw new NotImplementedException()
            };
        }

        Task<IdentityResponseStatus<string>> TestIdentityServiceAsync.Search(params IdentitySearchRequest[] searchRequest)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<string> { StatusCode = IdentityStatusCode.Success, Data = "ignored" }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<string>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<string>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<string>(),
                _ => throw new NotImplementedException()
            };
        }

        public Task<TestIdentityResponseStatus> Search(params IdentitySearchRequest[] searchRequest)
        {
            throw new NotImplementedException();
        }

        public Task<TestIdentityResponseStatus> Response(string requestToken)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<IdentitySearchResponse<IdentityResponse>>
                    {
                        Data = new IdentitySearchResponse<IdentityResponse>
                        {
                            Status = SearchResponseStatus.Complete,
                            SearchResponses = new IdentitySearchResponses<IdentityResponse>[]
                            {
                                new() {Responses = new[] {new IdentityResponse {Score = 100, UniqueId = "ignored" } }}
                            }
                        },
                        StatusCode = IdentityStatusCode.Success
                    }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<IdentitySearchResponse<IdentityResponse>>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<IdentitySearchResponse<IdentityResponse>>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<IdentitySearchResponse<IdentityResponse>>(),
                _ => throw new NotImplementedException()
            };
        }

        private static Task<IdentityResponseStatus<T>> BuildNotFoundResponse<T>()
        {
            return Task.FromResult(
                new IdentityResponseStatus<T>
                {
                    StatusCode = IdentityStatusCode.NotFound
                });
        }

        private static Task<IdentityResponseStatus<T>> BuildIncompleteResponse<T>()
        {
            return Task.FromResult(
                new IdentityResponseStatus<T>
                {
                    Errors = new[]
                    {
                        new IdentityError
                        {
                            Code = "Incomplete",
                            Description = "The search results are not ready yet"
                        }
                    },
                    StatusCode = IdentityStatusCode.Incomplete
                });
        }

        private static Task<IdentityResponseStatus<T>> BuildInvalidResponse<T>()
        {
            return Task.FromResult(
                new IdentityResponseStatus<T>
                {
                    Errors = new[]
                    {
                        new IdentityError
                        {
                            Code = "InvalidId",
                            Description = "Invalid Id specified"
                        }
                    },
                    StatusCode = IdentityStatusCode.InvalidProperties
                });
        }

        private static Task<IdentityResponseStatus<T>> BuildUnknownResponse<T>()
        {
            return Task.FromResult(
                new IdentityResponseStatus<T>
                {
                    StatusCode = (IdentityStatusCode)int.MaxValue,
                    Errors = new IdentityError[]
                    {
                        new()
                        {
                            Description = "An unknown error occurred"
                        },
                        new()
                        {
                            Description = "An second unknown error occurred"
                        }
                    }
                });
        }
    }
}