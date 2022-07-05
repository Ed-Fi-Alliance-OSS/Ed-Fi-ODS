// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
  
namespace EdFi.OdsApi.SdkClient
{
    public class TokenRetriever
    {
        private string oauthUrl;
        private string clientKey;
        private string clientSecret;
  
        /// <summary>
        ///
        /// </summary>
        /// <param name="oauthUrl"></param>
        /// <param name="clientKey"></param>
        /// <param name="clientSecret"></param>
        public TokenRetriever(string oauthUrl, string clientKey, string clientSecret)
        {
            this.oauthUrl = oauthUrl;
            this.clientKey = clientKey;
            this.clientSecret = clientSecret;
        }
  
        public string ObtainNewBearerToken()
        {
            var oauthClient = new RestClient(oauthUrl);
            return GetBearerToken(oauthClient);
        }
  
  
        private string GetBearerToken(IRestClient oauthClient)
        {
            var bearerTokenRequest = new RestRequest("oauth/token", Method.POST);
            bearerTokenRequest.AddParameter("Client_id", clientKey);
            bearerTokenRequest.AddParameter("Client_secret", clientSecret);
            bearerTokenRequest.AddParameter("grant_type", "client_credentials");
  
            var bearerTokenResponse = oauthClient.Execute<BearerTokenResponse>(bearerTokenRequest);
            if (bearerTokenResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new AuthenticationException("Unable to retrieve an access token. Error message: " +
                                                  bearerTokenResponse.ErrorMessage);
            }
  
            if (bearerTokenResponse.Data.Error != null || bearerTokenResponse.Data.TokenType != "bearer")
            {
                throw new AuthenticationException(
                    "Unable to retrieve an access token. Please verify that your application secret is correct.");
            }
  
            return bearerTokenResponse.Data.AccessToken;
        }
    }
  
    internal class BearerTokenResponse
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string Error { get; set; }
    }
}