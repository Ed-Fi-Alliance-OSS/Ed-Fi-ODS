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
        private static readonly ILog _log = LogManager.GetLogger(typeof(TokenRetriever));
        private readonly IOAuthTokenConfiguration _configuration;
        private readonly HttpClient _client;

        public TokenRetriever(IOAuthTokenConfiguration configuration)
        {
            _configuration = configuration;

            _client = new HttpClient {Timeout = new TimeSpan(0, 0, 5, 0)};

            _client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public async Task<BearerToken> ObtainNewBearerToken()
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded"),
                RequestUri = new Uri(_configuration.Url)
            };

            var plainTextBytes = Encoding.UTF8.GetBytes($"{_configuration.Key}:{_configuration.Secret}");
            var bearerToken = Convert.ToBase64String(plainTextBytes);
            var authHeader = $"Basic {bearerToken}";

            requestMessage.Headers.Authorization = AuthenticationHeaderValue.Parse(authHeader);

            _log.Debug($"Post bearer token to '{_configuration.Url}'");
            var response = await _client.SendAsync(requestMessage).ConfigureAwait(false);

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
