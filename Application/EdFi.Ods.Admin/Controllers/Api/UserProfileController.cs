// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Sandbox.Repositories;

namespace EdFi.Ods.Admin.Controllers.Api
{
    public class UserProfileController : ApiController
    {
        private readonly IClientAppRepo _clientAppRepo;

        public UserProfileController(IClientAppRepo clientAppRepo)
        {
            _clientAppRepo = clientAppRepo;
        }

        // GET api/userprofile
        public IEnumerable<User> Get()
        {
            var result = _clientAppRepo.GetUsers();
            return result;
        }

        // GET api/userprofile/5
        public User Get(int id)
        {
            var user = _clientAppRepo.GetUser(id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        //// POST api/userprofile
        //public void Post([FromBody]UserProfile value)
        //{
        //}

        // PUT api/userprofile/5
        /// <summary>
        /// Used to enable or disable user, nothing else
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>

        //public void Put(int id, [FromBody]UserProfile value)
        //{
        //    var user = _clientAppRepo.GetUserProfile(id);
        //    if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
        //}

        // DELETE api/userprofile/5
        public void Delete(int id)
        {
            var user = _clientAppRepo.GetUser(id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _clientAppRepo.DeleteUser(user);
        }
    }
}
