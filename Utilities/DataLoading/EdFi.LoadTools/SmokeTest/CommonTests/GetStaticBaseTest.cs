// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;

namespace EdFi.LoadTools.SmokeTest.CommonTests
{
    public abstract class GetStaticBaseTest : ITest, ITestGenerator
    {
        private readonly string _url;
        private static HttpClient _httpClient;

        protected GetStaticBaseTest(string url, HttpClient client = null)
        {
            _url = url;
            _httpClient = client;
        }

        private ILog Log => LogManager.GetLogger(GetType().Name);

        protected virtual bool ShouldPerformTest() => !string.IsNullOrWhiteSpace(_url);

        public virtual async Task<bool> PerformTest()
        {
            if (!ShouldPerformTest())
            {
                Log.Info("Skipped");
                return true;
            }

            var uri = new Uri(_url);

            using (LogicalThreadContext.Stacks["NDC"].Push(uri.ToString()))
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient
                    {
                        Timeout = new TimeSpan(0, 0, 5, 0),
                        BaseAddress = uri
                    };
                }

               try
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, uri);
                    var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        Log.Info($"{(int) response.StatusCode} {response.StatusCode}");
                        return true;
                    }

                    Log.Error($"{(int) response.StatusCode} {response.StatusCode}");
                    return false;
                }
                catch (WebException wex)
                {
                    // Handling intermittent network issues
                    Log.Error("Unexpected WebException on resource post", wex);
                    return false;
                }
                catch (TaskCanceledException tex)
                {
                    Log.Error("Http Client timeout.", tex);
                    return false;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    return false;
                }
            }
        }

        public virtual IEnumerable<ITest> GenerateTests()
        {
            yield return this;
        }
    }
}
