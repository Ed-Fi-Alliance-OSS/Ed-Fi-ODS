// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EdFi.LoadTools.Engine;
using log4net;
using Newtonsoft.Json;

namespace EdFi.LoadTools.ApiClient
{
    public interface ITokenRetriever
    {
        Task<BearerToken> ObtainNewBearerToken();
    }

    public class TokenRetriever
        : ITokenRetriever
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IOAuthTokenConfiguration _configuration;

        public TokenRetriever(IOAuthTokenConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<BearerToken> ObtainNewBearerToken()
        {
            var oauthKey = _configuration.Key;
            var oauthSecret = _configuration.Secret;
            var client = GetHttpClient(_configuration.Url);

            return await GetAccessToken(client, oauthKey, oauthSecret).ConfigureAwait(false);
        }

        private static HttpClient GetHttpClient(string url)
        {
            var client = new HttpClient
                         {
                             Timeout = new TimeSpan(0, 0, 5, 0), BaseAddress = new Uri(url)
                         };

            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            return client;
        }

        private static async Task<BearerToken> GetAccessToken(HttpClient client, string clientKey, string clientSecret)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{clientKey}:{clientSecret}");
            var bearerToken = Convert.ToBase64String(plainTextBytes);
            var authHeader = $"Basic {bearerToken}";

            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authHeader);

            var form = "Grant_type=client_credentials";
            var content = new StringContent(form, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await client.PostAsync("oauth/token", content).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var txt = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            _log.Debug($"Received token: {txt}");

            var token = JsonConvert.DeserializeObject<BearerToken>(txt);

            return token;
        }
    }

    public class BearerToken
    {
        public string Access_token { get; set; }

        public string Token_type { get; set; }

        public int? Expires_in { get; set; }
    }
}
