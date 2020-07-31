// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;
using EdFi.Ods.Common.Inflection;
using log4net;

namespace EdFi.LoadTools.ApiClient
{
    public class OdsRestClient : IOdsRestClient
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(OdsRestClient));
        private readonly IApiConfiguration _configuration;

        private readonly HttpClient _httpClient;
        private readonly List<string> _schemaNames;
        private readonly OAuthTokenHandler _tokenHandler;
        private string _bearerToken;

        public OdsRestClient(IApiConfiguration configuration, OAuthTokenHandler tokenHandler, List<string> schemaNames)
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ReusePort = true;
            ServicePointManager.DefaultConnectionLimit = configuration.ConnectionLimit;

            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _schemaNames = schemaNames;

            _httpClient = new HttpClient
                          {
                              Timeout = new TimeSpan(0, 0, 5, 0), BaseAddress = new Uri(_configuration.Url.TrimEnd('/'))
                          };
        }

        public async Task<HttpResponseMessage> GetAll(string elementName, int offset = 0)
        {
            var contentType = BuildJsonMimeType(elementName);
            var resource = CompositeTermInflector.MakePlural(elementName);

            var uriBuilder = new UriBuilder(Path.Combine(_configuration.Url, resource, $"?offset={offset}"));

            return await Get(uriBuilder, contentType);
        }

        public async Task<HttpResponseMessage> GetResourceByExample(string json, string elementName)
        {
            var contentType = BuildJsonMimeType(elementName);
            var resource = CompositeTermInflector.MakePlural(elementName);

            var uriBuilder = new UriBuilder(Path.Combine(_configuration.Url, resource))
                             {
                                 Query = Utilities.ConvertJsonToQueryString(json)
                             };

            return await Get(uriBuilder, contentType);
        }

        private async Task<HttpResponseMessage> Get(UriBuilder uriBuilder, string contentType)
        {
            HttpResponseMessage response;

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri.PathAndQuery);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                request.Headers.Authorization = GetAuthHeaderValue();
                response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            }
            catch (WebException ex)
            {
                // Handling intermittent network issues
                _log.Error("Unexpected WebException on resource post", ex);
                response = CreateFakeErrorResponse(HttpStatusCode.ServiceUnavailable);
            }
            catch (TaskCanceledException ex)
            {
                // Handling web timeout
                _log.Error("Http Client timeout.", ex);
                response = CreateFakeErrorResponse(HttpStatusCode.RequestTimeout);
            }

            return response;
        }

        public async Task<HttpResponseMessage> PostResource(string json, string elementName,
                                                            string elementSchemaName = "", bool refreshToken = false)
        {
            var contentType = BuildJsonMimeType(elementName);
            var content = new StringContent(json, Encoding.UTF8, contentType);
            var resource = CompositeTermInflector.MakePlural(elementName);

            if (_log.IsDebugEnabled)
            {
                _log.Debug($"json: {json}");
                _log.Debug($"elementName: {elementName}");
            }

            try
            {
                var uriBuilder =
                    new UriBuilder(Path.Combine(_configuration.Url, GetResourcePath(resource, elementSchemaName)));

                var request = new HttpRequestMessage(HttpMethod.Post, uriBuilder.Uri)
                              {
                                  Content = content
                              };

                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                request.Headers.Authorization = GetAuthHeaderValue(refreshToken);

                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

                return response;
            }
            catch (WebException ex)
            {
                // Handling intermittent network issues
                _log.Error("Unexpected WebException on resource post", ex);
                return CreateFakeErrorResponse(HttpStatusCode.ServiceUnavailable);
            }
            catch (TaskCanceledException ex)
            {
                // Handling web timeout
                _log.Error("Http Client timeout.", ex);
                return CreateFakeErrorResponse(HttpStatusCode.RequestTimeout);
            }
            catch (Exception ex)
            {
                // Handling other issues
                _log.Error("Unexpected Exception on resource post", ex);
                return CreateFakeErrorResponse(HttpStatusCode.SeeOther);
            }
        }

        private string BuildJsonMimeType(string resourceName)
        {
            if (string.IsNullOrEmpty(_configuration.Profile))
            {
                return "application/json";
            }

            return ProfilesContentTypeHelper.CreateContentType(
                resourceName,
                _configuration.Profile,
                ContentTypeUsage.Writable
            );
        }

        private HttpResponseMessage CreateFakeErrorResponse(HttpStatusCode httpStatusCode)
        {
            return new HttpResponseMessage(httpStatusCode);
        }

        private AuthenticationHeaderValue GetAuthHeaderValue(bool refreshToken = false)
        {
            if (_bearerToken == null || refreshToken)
            {
                _bearerToken = _tokenHandler.GetBearerToken();
            }

            return new AuthenticationHeaderValue("Bearer", _bearerToken);
        }

        private string GetResourcePath(string resourceName, string elementSchemaName)
        {
            const string expression = "[^a-zA-Z0-9]+";

            foreach (var schemaName in _schemaNames)
            {
                if (!Regex.Replace(schemaName, expression, "").ToLowerInvariant()
                          .Equals(elementSchemaName.ToLowerInvariant()))
                {
                    continue;
                }

                return $"{schemaName}/{resourceName}";
            }

            return resourceName;
        }
    }
}
