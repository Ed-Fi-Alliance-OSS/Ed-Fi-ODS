// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Security.Principal;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Ods.SandboxAdmin.Services.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace EdFi.Ods.SandboxAdmin.Services
{
    public class UserLookupResult
    {
        public static readonly UserLookupResult Empty = new UserLookupResult();

        public User CurrentUser { get; private set; }

        public bool IsAdmin { get; private set; }

        public bool HasCurrentUser
        {
            get { return CurrentUser != null; }
        }

        public static UserLookupResult ForUser(User user, IPrincipal identity)
        {
            var isAdmin = false;

            if (user != null && identity != null)
            {
                isAdmin = identity.IsInRole(SecurityRoles.Administrator);
            }

            return new UserLookupResult
            {
                CurrentUser = user,
                IsAdmin = isAdmin
            };
        }
    }


    public class SecurityService : ISecurityService
    {
        private readonly IClientAppRepo _clientAppRepo;
        private readonly IIdentityProvider _identityProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecurityService(IHttpContextAccessor httpContextAccessor
            , IClientAppRepo clientAppRepo
            , IIdentityProvider identityProvider)
        {
            _clientAppRepo = clientAppRepo;
            _identityProvider = identityProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserLookupResult GetCurrentUser(string currentUserName)
        {
            try
            {
                if (string.IsNullOrEmpty(currentUserName))
                {
                    return UserLookupResult.Empty;
                }

                var identityUser = _identityProvider.FindUser(currentUserName).Result;

                if (identityUser == null)
                {
                    return UserLookupResult.Empty;
                }

                var userProfile = _clientAppRepo.GetUser(identityUser.Email);
                return UserLookupResult.ForUser(userProfile, _httpContextAccessor.HttpContext.User);
            }
            catch (SqlException)
            {
                //Gulp.  Just return the empty result
            }

            return UserLookupResult.Empty;
        }

    }
}