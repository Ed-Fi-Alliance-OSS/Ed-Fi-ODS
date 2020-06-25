// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EdFi.LoadTools.ApiClient;
using log4net;

namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    public class SubmitResource : ISubmitResource
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(SubmitResource));
        private readonly IOdsRestClient _poster;
        private int _count;

        public SubmitResource(IOdsRestClient poster)
        {
            _poster = poster;
        }

        public async Task<ApiLoaderWorkItem> ProcessAsync(ApiLoaderWorkItem resourceWorkItem)
        {
            var contextPrefix = LogContext.BuildContextPrefix(resourceWorkItem);

            var count = Interlocked.Increment(ref _count);
            _log.Debug($"{contextPrefix} #{count} submitting");

            var refreshToken = false;

            while (true)
            {
                using (var response = await _poster.PostResource(
                    resourceWorkItem.Json, resourceWorkItem.ElementName,
                    resourceWorkItem.ResourceSchemaName, refreshToken).ConfigureAwait(false))
                {
                    if (response.StatusCode.Equals(HttpStatusCode.Unauthorized)
                        && response.ReasonPhrase.Equals("Invalid token")
                        && !refreshToken)
                    {
                        _log.Info("Expired token detected, refreshing and retrying request.");
                        refreshToken = true;
                        continue;
                    }

                    // if we refreshed the token we should then disable refresh token until it is needed again.
                    if (refreshToken)
                    {
                        refreshToken = false;
                    }

                    resourceWorkItem.AddSubmissionResult(response, count);
                }

                return resourceWorkItem;
            }
        }
    }
}
