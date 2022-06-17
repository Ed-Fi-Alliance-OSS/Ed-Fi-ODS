// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Features.IdentityManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class TestIdentitiesService : IIdentityService, IIdentityServiceAsync
    {
        public enum ResponseBehaviour
        {
            Success,
            InvalidProperties,
            Incomplete,
            NotFound
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
                    new IdentityResponseStatus<string> { StatusCode = IdentityStatusCode.Success }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<string>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<string>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<string>(),
                _ => throw new NotImplementedException()
            };
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Find(params string[] findRequest)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<string> { StatusCode = IdentityStatusCode.Success }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<string>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<string>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<string>(),
                _ => throw new NotImplementedException()
            };
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Find(params string[] findRequest)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<IdentitySearchResponse>
                    {
                        Data = new IdentitySearchResponse
                        {
                            Status = SearchResponseStatus.Complete,
                            SearchResponses = new IdentitySearchResponses[]
                                {
                                    new() {Responses = new[] {new IdentityResponse {Score = 100}}}
                                }
                        },
                        StatusCode = IdentityStatusCode.Success
                    }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<IdentitySearchResponse>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<IdentitySearchResponse>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<IdentitySearchResponse>(),
                _ => throw new NotImplementedException()
            };
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Search(params IdentitySearchRequest[] searchRequest)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<string> { StatusCode = IdentityStatusCode.Success }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<string>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<string>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<string>(),
                _ => throw new NotImplementedException()
            };
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Search(params IdentitySearchRequest[] searchRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Response(string requestToken)
        {
            return _responseBehaviour switch
            {
                ResponseBehaviour.Success => Task.FromResult(
                    new IdentityResponseStatus<IdentitySearchResponse>
                    {
                        Data = new IdentitySearchResponse
                        {
                            Status = SearchResponseStatus.Complete,
                            SearchResponses = new IdentitySearchResponses[]
                            {
                                new() {Responses = new[] {new IdentityResponse {Score = 100}}}
                            }
                        },
                        StatusCode = IdentityStatusCode.Success
                    }),
                ResponseBehaviour.InvalidProperties => BuildInvalidResponse<IdentitySearchResponse>(),
                ResponseBehaviour.Incomplete => BuildIncompleteResponse<IdentitySearchResponse>(),
                ResponseBehaviour.NotFound => BuildNotFoundResponse<IdentitySearchResponse>(),
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
    }
}