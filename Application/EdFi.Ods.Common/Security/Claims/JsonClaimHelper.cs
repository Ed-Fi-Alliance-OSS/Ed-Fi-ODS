// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Claims;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Security.Claims
{
    public static class JsonClaimHelper
    {
        private static readonly JsonSerializerSettings _serializerSettings;

        static JsonClaimHelper()
        {
            _serializerSettings = new JsonSerializerSettings
                                  {
                                      DefaultValueHandling = DefaultValueHandling.Ignore
                                  };
        }

        public static Claim CreateClaim(string claimType, EdFiResourceClaimValue edFiResourceClaimValue)
        {
            var value = JsonConvert.SerializeObject(edFiResourceClaimValue, _serializerSettings);
            var claim = new Claim(claimType, value, "application/json");
            return claim;
        }

        public static EdFiResourceClaimValue ToEdFiResourceClaimValue(this Claim claim)
        {
            if (claim.ValueType != "application/json")
            {
                throw new InvalidOperationException(
                    string.Format("Can NOT deseralize non JSON claim ({0}) of value type ({1})", claim.Type, claim.ValueType));
            }

            return JsonConvert.DeserializeObject<EdFiResourceClaimValue>(claim.Value);
        }
    }
}
