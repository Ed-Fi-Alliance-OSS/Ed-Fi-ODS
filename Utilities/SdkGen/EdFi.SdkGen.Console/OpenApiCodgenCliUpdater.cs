// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using log4net;

namespace EdFi.SdkGen.Console
{
    public class OpenApiCodgenCliUpdater
    {
        /// <summary>
        /// The number of download attempts before giving up.
        /// </summary>
        public const int MaxAttempts = 6;

        /// <summary>
        /// The longest wait honored from a Retry-After header.
        /// </summary>
        public static readonly TimeSpan MaxRetryAfter = TimeSpan.FromSeconds(60);

        /// <summary>
        /// The waits between attempts when the server doesn't send Retry-After. Maven Central can keep
        /// answering 429 to a runner for more than 30 seconds, so the attempts span about two minutes.
        /// </summary>
        public static readonly TimeSpan[] Backoff =
        {
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(20),
            TimeSpan.FromSeconds(40),
            TimeSpan.FromSeconds(60)
        };

        // Up to this fraction is added to each backoff wait, so parallel jobs don't retry together
        private const double MaxJitter = 0.2;

        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Options _options;
        private readonly HttpMessageHandler _httpMessageHandler;
        private readonly Func<TimeSpan, Task> _delay;
        private readonly Func<double> _random;

        public OpenApiCodgenCliUpdater(Options options)
            : this(options, new HttpClientHandler(), Task.Delay, Random.Shared.NextDouble) { }

        public OpenApiCodgenCliUpdater(
            Options options,
            HttpMessageHandler httpMessageHandler,
            Func<TimeSpan, Task> delay,
            Func<double> random)
        {
            _options = options;
            _httpMessageHandler = httpMessageHandler;
            _delay = delay;
            _random = random;
        }

        public void Run()
        {
            if (!ShouldUpdate())
            {
                return;
            }

            // run the task synchronously to avoid collitions to get the jar file.
            DownloadOpenApiCodegenCli().GetAwaiter().GetResult();
        }

        private bool ShouldUpdate()
        {
            _log.Info("Checking if the openapi-codegen-cli is valid");

            if (_options.Force)
            {
                _log.Info($"Force updating {_options.CliExecutableFullName()} to the specific version {_options.CliVersion}.");
                return true;
            }

            if (!File.Exists(_options.CliExecutableFullName()))
            {
                _log.Debug($"{_options.CliExecutableFullName()} does not exist.");
                return true;
            }

            return false;
        }

        private async Task DownloadOpenApiCodegenCli()
        {
            _log.Info($"Downloading a new copy of the {_options.CliExecutableFullName()}");

            var downloadUrl = _options.CliDownloadUrl();
            string lastFailure = null;

            using var httpClient = new HttpClient(_httpMessageHandler, disposeHandler: false);

            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                _log.Debug($"Downloading openApi-codegen-cli.jar from {downloadUrl} (attempt {attempt} of {MaxAttempts})");

                TimeSpan? retryAfter = null;

                try
                {
                    using var response = await httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);

                    if (response.IsSuccessStatusCode)
                    {
                        await SaveAsync(response);
                        return;
                    }

                    lastFailure = $"{(int)response.StatusCode} {response.ReasonPhrase}";

                    if (!IsTransient(response.StatusCode))
                    {
                        throw new InvalidOperationException(
                            $"Could not download the openapi-generator-cli from {downloadUrl}: the server returned {lastFailure}.");
                    }

                    retryAfter = GetRetryAfter(response);
                }
                catch (HttpRequestException e)
                {
                    lastFailure = e.Message;
                }
                catch (IOException e)
                {
                    lastFailure = e.Message;
                }
                catch (TaskCanceledException)
                {
                    lastFailure = "the request timed out";
                }

                if (attempt == MaxAttempts)
                {
                    break;
                }

                var wait = retryAfter ?? Backoff[attempt - 1] * (1 + MaxJitter * _random());

                _log.Warn(
                    $"Downloading the openapi-generator-cli from {downloadUrl} failed ({lastFailure}); retrying in {wait.TotalSeconds:0.#} seconds (attempt {attempt + 1} of {MaxAttempts}).");

                await _delay(wait);
            }

            throw new InvalidOperationException(
                $"Could not download the openapi-generator-cli from {downloadUrl} after {MaxAttempts} attempts. Last failure: {lastFailure}.");
        }

        private async Task SaveAsync(HttpResponseMessage response)
        {
            // save to a temporary file before moving to the final file.
            var fileName = $"{_options.CliExecutableFullName()}.download";

            _log.Debug($"Writing file {fileName}");

            try
            {
                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
                }

                // if download is successful we can then move the temp file to the proper name.
                _log.Debug($"Renaming {fileName} to {_options.CliExecutableFullName()}");
                File.Move(fileName, _options.CliExecutableFullName(), overwrite: true);
            }
            finally
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }

        private static bool IsTransient(HttpStatusCode statusCode)
            => statusCode == HttpStatusCode.TooManyRequests
               || statusCode == HttpStatusCode.RequestTimeout
               || (int)statusCode >= 500;

        private static TimeSpan? GetRetryAfter(HttpResponseMessage response)
        {
            var retryAfter = response.Headers.RetryAfter;

            if (retryAfter == null)
            {
                return null;
            }

            var wait = retryAfter.Delta
                       ?? (retryAfter.Date.HasValue ? retryAfter.Date.Value - DateTimeOffset.UtcNow : (TimeSpan?)null);

            if (wait == null)
            {
                return null;
            }

            if (wait < TimeSpan.Zero)
            {
                return TimeSpan.Zero;
            }

            return wait > MaxRetryAfter
                ? MaxRetryAfter
                : wait;
        }
    }
}
