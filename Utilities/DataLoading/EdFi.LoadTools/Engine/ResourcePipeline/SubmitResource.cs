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
    public class SubmitResource
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(SubmitResource));
        private readonly OdsRestClient _poster;
        private int _count;

        public SubmitResource(OdsRestClient poster)
        {
            _poster = poster;
        }

        public async Task<ApiLoaderWorkItem> ProcessAsync(ApiLoaderWorkItem resourceWorkItem)
        {
            var contextPrefix = LogContext.BuildContextPrefix(resourceWorkItem);

            _log.Debug($"\n\r{contextPrefix}{Interlocked.Increment(ref _count)} submitting");

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
                        refreshToken = !refreshToken;
                        continue;
                    }

                    // if we refreshed the token we should then disable refresh token until it is needed again.
                    if (refreshToken)
                    {
                        refreshToken = !refreshToken;
                    }

                    if (_log.IsDebugEnabled)
                    {
                        _log.Debug(
                            $"\n\r{contextPrefix}{_count} xelement:                        {resourceWorkItem.XElement}");

                        _log.Debug(
                            $"\n\r{contextPrefix}{_count} json:                            {resourceWorkItem.Json}");

                        _log.Debug($"\n\r{contextPrefix}{_count} response.Content:                {response.Content}");

                        _log.Debug(
                            $"\n\r{contextPrefix}{_count} response.StatusCode:             {response.StatusCode}");

                        _log.Debug(
                            $"\n\r{contextPrefix}{_count} response.RequestMessage:         {response.RequestMessage}");

                        _log.Debug(
                            $"\n\r{contextPrefix}{_count} response.RequestMessage.Content: {response.RequestMessage?.Content}");

                        _log.Debug(
                            $"\n\r{contextPrefix}{_count} response.ReasonPhrase:           {response.ReasonPhrase}");
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        _log.Info($"{contextPrefix}{_count} {response.ReasonPhrase} - {(int) response.StatusCode} - Level: {resourceWorkItem.Level}");
                    }
                    else
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        _log.Warn($"{contextPrefix}{_count} {response.ReasonPhrase} - {(int) response.StatusCode} {msg} - Level: {resourceWorkItem.Level}");
                    }

                    resourceWorkItem.AddSubmissionResult(response);
                }

                return resourceWorkItem;
            }
        }
    }
}
