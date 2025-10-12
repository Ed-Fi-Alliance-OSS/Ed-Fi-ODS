// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using System.Runtime.Serialization;
using System.Security.Authentication;
using EdFi.OdsApi.Sdk.Client;

namespace EdFi.OdsApi.SdkClient
{
    internal class TokenRetriever(string basePath, string clientKey, string clientSecret)
    {
        public string ObtainNewBearerToken()
        {
            var oauthClient = new ApiClient(basePath);
            return GetBearerToken(oauthClient);
        }

        private string GetBearerToken(ApiClient oauthClient)
        {
            var configuration = new Configuration() { BasePath = basePath };
            var bearerTokenRequestOptions = new RequestOptions() { Operation = String.Empty };
            bearerTokenRequestOptions.FormParameters.Add("Client_id", clientKey);
            bearerTokenRequestOptions.FormParameters.Add("Client_secret", clientSecret);
            bearerTokenRequestOptions.FormParameters.Add("Grant_type", "client_credentials");

            var bearerTokenResponse = oauthClient.Post<BearerTokenResponse>("oauth/token", bearerTokenRequestOptions, configuration);
            if (bearerTokenResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new AuthenticationException("Unable to retrieve an access token. Error message: " +
                                                  bearerTokenResponse.Data.Error);
            }

            if (bearerTokenResponse.Data.Error != null || bearerTokenResponse.Data.TokenType != "bearer")
            {
                throw new AuthenticationException(
                    "Unable to retrieve an access token. Please verify that your application secret is correct.");
            }

            return bearerTokenResponse.Data.AccessToken;
        }
    }

    [DataContract]
    internal class BearerTokenResponse
    {
        [DataMember(Name = "access_token", EmitDefaultValue = false)]
        public required string AccessToken { get; set; }

        [DataMember(Name = "expires_in", EmitDefaultValue = false)]
        public required string ExpiresIn { get; set; }

        [DataMember(Name = "token_type", EmitDefaultValue = false)]
        public required string TokenType { get; set; }

        [DataMember(Name = "error", EmitDefaultValue = false)]
        public required string Error { get; set; }
    }
}