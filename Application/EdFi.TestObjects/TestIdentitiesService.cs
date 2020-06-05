// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EdFi.Ods.Api.Common.Models.Identity;
using EdFi.Ods.Common.Extensions;

namespace EdFi.TestObjects
{
    public class TestIdentitiesService : IIdentityService, IIdentityServiceAsync
    {
        private int _findIndex;
        private int _identityIndex;
        private int _searchIndex;
        public Dictionary<string, string[]> Finds = new Dictionary<string, string[]>();

        public Dictionary<string, IdentityCreateRequest> Identities = new Dictionary<string, IdentityCreateRequest>();
        public Dictionary<string, IdentitySearchRequest[]> Searches = new Dictionary<string, IdentitySearchRequest[]>();
        private static MapperConfiguration _mapperConfig;

        static TestIdentitiesService()
        {
            _mapperConfig = new MapperConfiguration(x => x.CreateMap<IdentityCreateRequest, IdentityResponse>());
        }

        public IdentityServiceCapabilities IdentityServiceCapabilities => IdentityServiceCapabilities.Create
                                                                          | IdentityServiceCapabilities.Find
                                                                          | IdentityServiceCapabilities.Search
                                                                          | IdentityServiceCapabilities.Results;

        public Task<IdentityResponseStatus<string>> Create(IdentityCreateRequest createRequest)
        {
            var id = string.Format("identity{0}", _identityIndex++);
            Identities.Add(id, createRequest);

            return Task.FromResult(
                new IdentityResponseStatus<string>
                {
                    Data = id, StatusCode = IdentityStatusCode.Success
                });
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Find(params string[] findRequest)
        {
            var results = findRequest.Select(
                                          x =>
                                          {
                                              if (!Identities.ContainsKey(x))
                                              {
                                                  return new IdentitySearchResponses
                                                         {
                                                             Responses = new[]
                                                                         {
                                                                             new IdentityResponse()
                                                                         }
                                                         };
                                              }

                                              var mapper = _mapperConfig.CreateMapper();
                                              var tmp = mapper.Map<IdentityResponse>(Identities[x]);
                                              tmp.Score = 100;
                                              tmp.UniqueId = x;

                                              return new IdentitySearchResponses
                                                     {
                                                         Responses = new[]
                                                                     {
                                                                         tmp
                                                                     }
                                                     };
                                          })
                                     .ToArray();

            return Task.FromResult(
                new IdentityResponseStatus<IdentitySearchResponse>
                {
                    Data = new IdentitySearchResponse
                           {
                               Status = SearchResponseStatus.Complete, SearchResponses = results
                           },
                    StatusCode = IdentityStatusCode.Success
                });
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Search(params IdentitySearchRequest[] searchRequest)
        {
            var results = searchRequest.Select(
                                            x =>
                                            {
                                                var identities = Identities.Where(y => y.Value.FirstName == x.FirstName);

                                                return new IdentitySearchResponses
                                                       {
                                                           Responses = identities.Select(
                                                                                      y =>
                                                                                      {
                                                                                          var mapper =
                                                                                              _mapperConfig.CreateMapper();
                                                                                          var tmp = mapper.Map<IdentityResponse>(y.Value);
                                                                                          tmp.Score = 100;
                                                                                          tmp.UniqueId = y.Key;
                                                                                          return tmp;
                                                                                      })
                                                                                 .ToArray()
                                                       };
                                            })
                                       .ToArray();

            return Task.FromResult(
                new IdentityResponseStatus<IdentitySearchResponse>
                {
                    Data = new IdentitySearchResponse
                           {
                               Status = SearchResponseStatus.Complete, SearchResponses = results
                           },
                    StatusCode = IdentityStatusCode.Success
                });
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Search(params IdentitySearchRequest[] searchRequest)
        {
            var token = "searchToken" + _searchIndex++;
            Searches.Add(token, searchRequest);

            return Task.FromResult(
                new IdentityResponseStatus<string>
                {
                    Data = token, StatusCode = IdentityStatusCode.Success
                });
        }

        public Task<IdentityResponseStatus<IdentitySearchResponse>> Response(string requestToken)
        {
            if (Finds.ContainsKey(requestToken))
            {
                var findResult = Find(Finds[requestToken])
                   .GetResultSafely();

                Finds.Remove(requestToken);
                return Task.FromResult(findResult);
            }

            if (Searches.ContainsKey(requestToken))
            {
                var searchResult = Search(Searches[requestToken])
                   .GetResultSafely();

                Searches.Remove(requestToken);
                return Task.FromResult(searchResult);
            }

            return
                Task.FromResult(
                    (IdentityResponseStatus<IdentitySearchResponse>) new IdentityResponseErrorStatus<IdentitySearchResponse>
                                                                     {
                                                                         StatusCode = IdentityStatusCode.NotFound
                                                                     });
        }

        Task<IdentityResponseStatus<string>> IIdentityServiceAsync.Find(params string[] findRequest)
        {
            var token = "findToken" + _findIndex++;
            Finds.Add(token, findRequest);

            return Task.FromResult(
                new IdentityResponseStatus<string>
                {
                    Data = token, StatusCode = IdentityStatusCode.Success
                });
        }
    }
}
