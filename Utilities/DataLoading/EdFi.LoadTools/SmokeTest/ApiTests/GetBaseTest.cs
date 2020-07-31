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
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using EdFi.LoadTools.Engine;
using EdFi.Ods.Common.Inflection;
using log4net;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger;

namespace EdFi.LoadTools.SmokeTest.ApiTests
{
    public abstract class GetBaseTest : ITest
    {
        protected readonly IApiConfiguration Configuration;
        protected readonly Resource Resource;
        protected readonly Dictionary<string, JArray> ResultsDictionary;
        protected readonly IOAuthTokenHandler TokenHandler;

        static GetBaseTest()
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ReusePort = true;
        }

        protected GetBaseTest(
            Resource resource,
            Dictionary<string, JArray> resultsDictionary,
            IApiConfiguration configuration,
            IOAuthTokenHandler tokenHandler)
        {
            Resource = resource;
            ResultsDictionary = resultsDictionary;
            Configuration = configuration;
            TokenHandler = tokenHandler;
        }

        protected ILog Log => LogManager.GetLogger(GetType().Name);

        protected Operation Operation => Resource.Path.get;

        protected virtual bool NoDataAvailableForTheResource => GetResult() == null;

        public virtual async Task<bool> PerformTest()
        {
            if (!ShouldPerformTest())
            {
                // This represents a scenario where this test should not have been generated
                // because it isn't actually valid for the given resource.
                // Long term this should be fixed by introducing a level of grouping by resource
                // and aligning the specific test types with the incoming resources
                // but for now the logging has been removed here to reduce noise.
                // See ODS-3070 for the long term solution.
                return true;
            }

            try
            {
                using (LogicalThreadContext.Stacks["NDC"].Push(Resource.Name))
                {
                    if (NoDataAvailableForTheResource)
                    {
                        Log.Info("Skipped");
                        return true;
                    }

                    using (var client = GetHttpClient())
                    {
                        var path = GetPath().PathAndQuery;
                        var response = await client.GetAsync(path).ConfigureAwait(false);
                        JArray results = null;

                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();

                            if (Resource.Path.get.responses["200"].schema.type == "array")
                            {
                                results = JArray.Parse(jsonString);
                                ResultsDictionary[Resource.Name] = results;
                            }
                        }

                        if (IsExpectedResponse(response, results))
                        {
                            Log.Info($"{(int)response.StatusCode} {response.StatusCode}");
                            return true;
                        }

                        Log.Error($"{path} - {(int)response.StatusCode} {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (WebException ex)
            {
                // Handling intermittent network issues
                Log.Error("Unexpected WebException on resource Get", ex);
                return false;
            }
            catch (TaskCanceledException ex)
            {
                // Handling web timeout
                Log.Error("Http Client timeout.", ex);
                return false;
            }
        }

        protected JObject GetResult()
        {
            var obj = ResultsDictionary.FirstOrDefault(r => Resource.Name == r.Key);

            return string.IsNullOrEmpty(obj.Key)
                ? null
                : obj.Value.OfType<JObject>().FirstOrDefault();
        }

        private HttpClient GetHttpClient()
        {
            var contentType = BuildJsonMimeType(Inflector.MakeSingular(Resource.Name));

            var client = new HttpClient
                         {
                             Timeout = new TimeSpan(0, 0, 5, 0), BaseAddress = new Uri(Configuration.Url)
                         };

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", TokenHandler.GetBearerToken());

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            return client;
        }

        private static string BuildJsonMimeType(string elementName, string profile = null)
        {
            return string.IsNullOrEmpty(profile)
                ? "application/json"
                : ProfilesContentTypeHelper.CreateContentType(elementName, profile, ContentTypeUsage.Writable);
        }

        private Uri GetPath()
        {
            var path = Resource.BasePath
                               .AddPath(Resource.Name);

            path = OnGetPath(path);

            var uri = new Uri(new Uri(Configuration.Url), path);
            return uri;
        }

        protected virtual bool ShouldPerformTest()
        {
            return false;
        }

        protected virtual string OnGetPath(string path)
        {
            return path;
        }

        protected JObject Flatten(JObject jObject)
        {
            var result = new JObject();
            var queue = new Queue<JProperty>(jObject.Properties());

            while (queue.Count > 0)
            {
                var tmp = queue.Dequeue();

                switch (tmp.Value.Type)
                {
                    case JTokenType.Comment:
                    case JTokenType.Constructor:
                    case JTokenType.None:
                    case JTokenType.Null:
                    case JTokenType.Undefined:
                        break;
                    case JTokenType.Property:
                        queue.Enqueue((JProperty) tmp.Value);
                        break;
                    case JTokenType.Object:

                        foreach (var prop in ((JObject) tmp.Value).Properties())
                        {
                            queue.Enqueue(prop);
                        }

                        break;
                    case JTokenType.Array:

                        foreach (var prop in ((JArray) tmp.Value).SelectMany(x => ((JObject) x).Properties()))
                        {
                            queue.Enqueue(prop);
                        }

                        break;
                    default:

                        if (result[tmp.Name] == null)
                        {
                            result.Add(tmp);
                        }

                        break;
                }
            }

            return result;
        }

        protected virtual bool IsExpectedResponse(HttpResponseMessage response, JArray results)
        {
            return response.IsSuccessStatusCode;
        }
    }
}
