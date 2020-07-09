// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EdFi.LoadTools.Engine.XmlLookupPipeline
{
    /// <summary>
    ///     resolves the item's GetByExampleXElement to it's ResourceXElement
    /// </summary>
    public class PerformGetByExampleStep : ILookupPipelineStep
    {
        private readonly IOdsRestClient _client;

        // ReSharper disable once InconsistentNaming
        private readonly ILog Log;

        public PerformGetByExampleStep(IOdsRestClient client)
        {
            Log = LogManager.GetLogger(GetType().Name);
            _client = client;
        }

        public async Task<bool> Process(XmlLookupWorkItem item)
        {
            if (item.IdentityXElement != null)
            {
                return true;
            }

            var jsonText = JsonConvert.SerializeXNode(item.GetByExampleXElement);
            var response = await _client.GetResourceByExample(jsonText, item.JsonModelName).ConfigureAwait(false);
            var jsonLookupResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var token = JToken.Parse(jsonLookupResult);

                    if (token is JObject)
                    {
                        item.ResourceXElement = JsonConvert.DeserializeXNode(jsonLookupResult, item.JsonModelName).Root;
                    }
                    else if (token is JArray)
                    {
                        var jArr = token as JArray;

                        if (jArr.Count == 0)
                        {
                            Log.Error($"{item.ResourceName} lookup returned no matching resources");
                            Log.Debug(response.RequestMessage);
                            return false;
                        }

                        if (jArr.Count > 1)
                        {
                            Log.Error($"{item.ResourceName} lookup returned more than one matching resources");
                            Log.Debug(response.RequestMessage);
                            return false;
                        }

                        item.ResourceXElement = JsonConvert.DeserializeXNode(
                            jArr.First.ToString(),
                            item.JsonModelName).Root;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    Log.Fatal(jsonLookupResult, e);
                    throw;
                }
            }

            Log.Error($"{item.ResourceName} lookup error: {response.ReasonPhrase}");
            Log.Info(jsonLookupResult);
            Log.Debug(response.RequestMessage);
            return false;
        }
    }
}
