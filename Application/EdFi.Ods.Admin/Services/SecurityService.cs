// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Web.Security;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Sandbox.Repositories;
using WebMatrix.WebData;

namespace EdFi.Ods.Admin.Services
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

        public static UserLookupResult ForUser(User user)
        {
            var isAdmin = false;

            if (user != null)
            {
                isAdmin = Roles.IsUserInRole(user.Email, "Administrator");
            }

            return new UserLookupResult
                   {
                       CurrentUser = user, IsAdmin = isAdmin
                   };
        }
    }

    public class UserIdLookupResult
    {
        public static readonly UserIdLookupResult Empty = new UserIdLookupResult();

        public int CurrentUserId { get; private set; }

        public bool HasCurrentUser
        {
            get { return CurrentUserId != default(int); }
        }

        public static UserIdLookupResult ForUserId(int id)
        {
            return new UserIdLookupResult
                   {
                       CurrentUserId = id
                   };
        }
    }

    public class SecurityService : ISecurityService
    {
        private readonly IClientAppRepo _clientAppRepo;

        public SecurityService(IClientAppRepo clientAppRepo)
        {
            _clientAppRepo = clientAppRepo;
        }

        public UserLookupResult GetCurrentUser()
        {
            try
            {
                var idLookupResult = GetCurrentUserId();

                if (idLookupResult.HasCurrentUser)
                {
                    var userProfile = _clientAppRepo.GetUser(idLookupResult.CurrentUserId);
                    return UserLookupResult.ForUser(userProfile);
                }
            }
            catch (SqlException)
            {
                //Gulp.  Just return the empty result
            }

            return UserLookupResult.Empty;
        }

        public UserIdLookupResult GetCurrentUserId()
        {
            try
            {
                return UserIdLookupResult.ForUserId(WebSecurity.CurrentUserId);
            }

            catch (InvalidOperationException) //When there isn't a current user...
            {
                return UserIdLookupResult.Empty;
            }
        }
    }
}
