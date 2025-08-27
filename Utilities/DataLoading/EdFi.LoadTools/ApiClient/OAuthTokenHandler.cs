// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace EdFi.LoadTools.ApiClient
{
    public interface IOAuthTokenHandler : IDisposable
    {
        string GetBearerToken();
        Task<string> GetBearerTokenAsync();
    }

    public class OAuthTokenHandler : IOAuthTokenHandler, IDisposable
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ITokenRetriever _tokenRetriever;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private string _cachedToken;
        private DateTime _tokenExpiration = DateTime.MinValue;

        // Buffer time before expiration to request a new token (1 minute)
        private static readonly TimeSpan ExpirationBuffer = TimeSpan.FromMinutes(1);

        public OAuthTokenHandler(ITokenRetriever tokenRetriever)
        {
            _tokenRetriever = tokenRetriever;
        }

        public string GetBearerToken()
        {
            return GetBearerTokenAsync().GetAwaiter().GetResult();
        }

        public async Task<string> GetBearerTokenAsync()
        {
            // Check if we have a valid cached token
            if (IsTokenValid())
            {
                _log.Debug("Using cached OAuth token");
                return _cachedToken;
            }

            // Use semaphore to ensure only one thread requests a new token at a time
            await _semaphore.WaitAsync();
            try
            {
                // Double-check pattern: another thread might have refreshed the token while we were waiting
                if (IsTokenValid())
                {
                    _log.Debug("Using cached OAuth token (obtained while waiting)");
                    return _cachedToken;
                }

                _log.Debug("Requesting a new OAuth token");
                var bearerToken = await _tokenRetriever.ObtainNewBearerToken();

                // Cache the new token and calculate expiration time
                _cachedToken = bearerToken.Access_token;
                _tokenExpiration = CalculateTokenExpiration(bearerToken.Expires_in);

                _log.Debug($"New OAuth token cached, expires at: {_tokenExpiration:yyyy-MM-dd HH:mm:ss}");
                return _cachedToken;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private bool IsTokenValid()
        {
            return !string.IsNullOrEmpty(_cachedToken) &&
                   DateTime.UtcNow < _tokenExpiration.Subtract(ExpirationBuffer);
        }

        private static DateTime CalculateTokenExpiration(int? expiresInSeconds)
        {
            // Default to 1 hour if expires_in is not provided
            var expirationSeconds = expiresInSeconds ?? 3600;
            return DateTime.UtcNow.AddSeconds(expirationSeconds);
        }

        public void Dispose()
        {
            _semaphore?.Dispose();
        }
    }
}
