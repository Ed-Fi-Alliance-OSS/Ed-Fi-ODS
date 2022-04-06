// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common;
using Microsoft.Extensions.Configuration;

namespace EdFi.Admin.DataAccess.Repositories
{
    public class AccessTokenClientRepo : IAccessTokenClientRepo
    {
        private readonly IUsersContextFactory _contextFactory;
        private readonly Lazy<int> _duration;
        private const int DefaultDuration = 60;

        public AccessTokenClientRepo(
            IUsersContextFactory contextFactory,
            IConfigurationRoot config)
        {
            _contextFactory = Preconditions.ThrowIfNull(contextFactory, nameof(contextFactory));
            _duration = new Lazy<int>(
                () =>
                {
                    // Get the config value, defaulting to 1 hour
                    if (!int.TryParse(
                        config.GetSection("BearerTokenTimeoutMinutes")
                            .Value,
                        out int duration))
                    {
                        duration = DefaultDuration;
                    }

                    return duration;
                });
        }

        public async Task<IReadOnlyList<OAuthTokenClient>> GetClientForTokenAsync(Guid accessToken)
        {
            using (var context = _contextFactory.CreateContext())
            {
                const string Sql = "SELECT \"Key\", UseSandbox, StudentIdentificationSystemDescriptor, EducationOrganizationId, ClaimSetName, NamespacePrefix, ProfileName, CreatorOwnershipTokenId, OwnershipTokenId, Expiration FROM dbo.GetClientForToken(@p0);";
                return await context.ExecuteQueryAsync<OAuthTokenClient>(Sql, accessToken);
            }
        }

        public async Task DeleteExpiredTokensAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                const string Sql = "DELETE FROM dbo.ClientAccessTokens WHERE Expiration <= @p0;";
                await context.ExecuteSqlCommandAsync(Sql, DateTime.UtcNow);
            }
        }

        public async Task<ClientAccessToken> AddClientAccessTokenAsync(int apiClientId, string tokenRequestScope = null)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = await context.Clients.FirstOrDefaultAsync(c => c.ApiClientId == apiClientId);

                if (client == null)
                {
                    throw new InvalidOperationException("Cannot add client access token when the client does not exist.");
                }

                var token = new ClientAccessToken(TimeSpan.FromMinutes(_duration.Value))
                {
                    Scope = string.IsNullOrEmpty(tokenRequestScope)
                        ? null
                        : tokenRequestScope.Trim()
                };

                client.ClientAccessTokens.Add(token);
                await context.SaveChangesAsync();
                return token;
            }
        }

        public ClientAccessToken AddClientAccessToken(int apiClientId, string tokenRequestScope = null)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var client = context.Clients.FirstOrDefault(c => c.ApiClientId == apiClientId);

                if (client == null)
                {
                    throw new InvalidOperationException("Cannot add client access token when the client does not exist.");
                }

                var token = new ClientAccessToken(TimeSpan.FromMinutes(_duration.Value))
                {
                    Scope = string.IsNullOrEmpty(tokenRequestScope)
                        ? null
                        : tokenRequestScope.Trim()
                };

                client.ClientAccessTokens.Add(token);
                context.SaveChanges();
                return token;
            }
        }
    }
}
