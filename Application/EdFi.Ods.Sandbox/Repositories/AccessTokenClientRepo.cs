// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common;

namespace EdFi.Ods.Sandbox.Repositories
{
    public class AccessTokenClientRepo : IAccessTokenClientRepo
    {
        private readonly IUsersContextFactory _contextFactory;

        public AccessTokenClientRepo(IUsersContextFactory contextFactory)
        {
            _contextFactory = Preconditions.ThrowIfNull(contextFactory, nameof(contextFactory));
        }

        public async Task<IReadOnlyList<OAuthTokenClient>> GetClientForTokenAsync(Guid accessToken)
        {
            using (var context = _contextFactory.CreateContext())
            {
                const string Sql = "SELECT \"Key\", UseSandbox, StudentIdentificationSystemDescriptor, EducationOrganizationId, ClaimSetName, NamespacePrefix, ProfileName, CreatorOwnershipTokenId, OwnershipTokenId FROM dbo.GetClientForToken(@p0);";
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
    }
}
