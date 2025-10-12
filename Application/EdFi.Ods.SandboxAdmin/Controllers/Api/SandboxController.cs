// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Sandbox.Provisioners;
using EdFi.Ods.SandboxAdmin.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.SandboxAdmin.Controllers.Api
{
    public class SandboxDTO
    {
        public string Command { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = SecurityRoles.Administrator)]
    public class SandboxController : ControllerBase
    {
        private readonly ISandboxProvisioner _sandboxProvisioner;

        public SandboxController(ISandboxProvisioner sandboxProvisioner)
        {
            _sandboxProvisioner = sandboxProvisioner;
        }

        /// <summary>
        /// Perform an operation on the shared sandbox
        /// </summary>
        /// <param name="sandboxDTO">"reset" is the only current option</param>
        public void Put(SandboxDTO sandboxDTO)
        {
            switch (sandboxDTO.Command)
            {
                case "reset":
                    _sandboxProvisioner.ResetDemoSandbox();
                    break;
            }
        }
    }
}