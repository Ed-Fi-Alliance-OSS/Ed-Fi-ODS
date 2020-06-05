// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Net.Http;
using EdFi.Ods.Api.Common.Models.Identity;
using EdFi.Ods.Common.Extensions;
using Newtonsoft.Json;

namespace EdFi.Ods.WebService.Tests._Helpers
{
    public class UniqueIdCreator
    {
        public static IdentityCreateRequest InitializeAPersonWithUniqueData()
        {
            return new IdentityCreateRequest
                   {
                       BirthDate = new DateTime(1995, 2, 3), SexType = "Male"
                   };
        }

        public static string ExtractIdFromHttpResponse(HttpResponseMessage responseMessage)
        {
            var uniqueId = Guid.NewGuid()
                               .ToString("N");

            if (!responseMessage.IsSuccessStatusCode)
            {
                return uniqueId;
            }

            var identitySearchResponses = ((IdentitySearchResponse) JsonConvert
               .DeserializeObject(
                    responseMessage.Content.ReadAsStringAsync()
                                   .GetResultSafely(),
                    typeof(IdentitySearchResponse))).SearchResponses.ToList();

            if (!identitySearchResponses.Any())
            {
                return uniqueId;
            }

            var identityResponse = identitySearchResponses.Where(x => x.Responses.Any())
                                                          .SelectMany(x => x.Responses)
                                                          .FirstOrDefault();

            return identityResponse.UniqueId ?? uniqueId;
        }
    }
}
