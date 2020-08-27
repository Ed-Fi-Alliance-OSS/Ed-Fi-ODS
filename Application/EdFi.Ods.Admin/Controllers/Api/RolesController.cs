// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Web.Http;
using System.Web.Security;
using EdFi.Ods.Admin.Services;

namespace EdFi.Ods.Admin.Controllers.Api
{
    //[Authorize(Roles="Administrator")]
    public class RolesController : ApiController
    {
        private ISecurityService _securityService;

        public RolesController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public IEnumerable<MembershipUser> Get()
        {
            return null;
        }

        public MembershipUser Get(string id)
        {
            var result = Membership.GetUser(id);
            return result;
        }
    }
}
