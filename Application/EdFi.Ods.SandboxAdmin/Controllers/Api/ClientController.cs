// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Ods.Sandbox;
using EdFi.Ods.Sandbox.Admin.Services.Initialization;
using EdFi.Ods.Sandbox.Provisioners;
using EdFi.Ods.SandboxAdmin.Services.Models.Client;
using EdFi.Ods.SandboxAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.SandboxAdmin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientCreator _clientCreator;
        private readonly IClientAppRepo _repository;
        private readonly ISandboxProvisioner _sandboxProvisioner;
        private readonly ISecurityService _securityService;

        public ClientController(
            IClientAppRepo repository,
            ISandboxProvisioner sandboxProvisioner,
            ISecurityService securityService,
            IClientCreator clientCreator)
        {
            _repository = repository;
            _sandboxProvisioner = sandboxProvisioner;
            _clientCreator = clientCreator;
            _securityService = securityService;
        }

        private User UserProfile
        {
            get
            {
                string currentUserName = User?.Identity?.Name;
                return _securityService.GetCurrentUser(currentUserName)
                                       .CurrentUser;
            }
        }

        private async Task AddClientStatusInfo(ApiClient client)
        {
            if (client.UseSandbox)
            {
                var status = await _sandboxProvisioner.GetSandboxStatusAsync(client.Key);
                client.Status = status.Description;
            }
            else
            {
                client.Status = ApiClientStatus.Online;
            }
        }

        private async Task AddClientStatusInfo(IEnumerable<ApiClient> clients)
        {
            foreach (var client in clients)
            {
                await AddClientStatusInfo(client);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            //TODO: This is an ugly patch for now. We should really do this type of thing in a top-level exception handler.
            try
            {
                var clients = UserProfile.ApiClients;
                await AddClientStatusInfo(clients);

                var models = clients.Select(ToClientIndexViewModel)
                                    .ToArray();

                return Ok(models);
            }
            catch (Exception e)
            {
                var currentException = e;
                var counter = 0;
                var message = string.Empty;

                while (currentException != null)
                {
                    Trace.TraceError("{0}: {1}", currentException.Message, currentException.StackTrace);
                    message += string.Format("{0}:{1}", counter, currentException.Message);
                    counter++;
                    currentException = currentException.InnerException;
                }

                throw new Exception(string.Format("Unhandled exception with these messages: {0}", message));
            }
        }

        private ClientIndexViewModel ToClientIndexViewModel(ApiClient client)
        {
            var apiClientId = client.ApiClientId;

            var application = client.Application ?? new Application
            {
                ApplicationName = "<Empty>"
            };

            var applicationName = application.ApplicationName;
            var name = client.Name;
            var key = client.Key;
            var secret = client.Secret;
            var status = client.Status;
            var sandboxTypeName = client.SandboxTypeName;

            ClientIndexViewModel viewModel = new ClientIndexViewModel
            {
                Id = apiClientId,
                ApplicationName = applicationName,
                Name = name,
                Key = key,
                Secret = secret,
                Status = status,
                SandboxTypeName = sandboxTypeName,
                OperationalContextUri = application.OperationalContextUri
            };

            return viewModel;
        }

        [HttpGet("{id}")]
        public IActionResult GetClient([FromRoute] string id)
        {
            var client = UserProfile.ApiClients.FirstOrDefault(c => c.Key == id);
            return Ok(ToClientIndexViewModel(client));
        }

        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] SandboxClientCreateModel sandboxClient)
        {
            if (ModelState["client.Name"] == null)
            {
                try
                {
                    var profile = _repository.GetUser(UserProfile.Email);
                    var clients = UserProfile.ApiClients;

                    if (clients != null && clients.Any(a => a.Name == sandboxClient.Name))
                    {
                        var message = $"The Sandbox  {sandboxClient.Name} already exists!";
                        return BadRequest(message);
                    }

                    var newClient = _clientCreator.CreateNewSandboxClient(
                        sandboxClient.Name,
                        new SandboxOptions
                        {
                            Type = sandboxClient.SandboxType
                        },
                        profile,
                        sandboxClient.ApplicationId,
                        addRestoredEdOrgIdsToApplication: false);

                    await AddClientStatusInfo(newClient);
                    return Ok(ToClientIndexViewModel(newClient));
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return BadRequest(ex.ParamName);
                }
            }

            return StatusCode((int)HttpStatusCode.NotAcceptable);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(ClientIndexViewModel clientViewModel)
        {
            var client = _repository.GetClientIncludingApplication(clientViewModel.Key);

            if (client == null)
            {
                throw new KeyNotFoundException();
            }

            client.GenerateSecret();
            _repository.UpdateClient(client);
            await AddClientStatusInfo(client);
            return Ok(ToClientIndexViewModel(client));
        }

        [HttpDelete("{id}")]
        public void DeleteClient([FromRoute] string id)
        {
            var client = _repository.GetClient(id);

            if (client == null)
            {
                throw new ArgumentException("NotFound");
            }

            _repository.DeleteClient(id);

            if (client.UseSandbox)
            {
                _sandboxProvisioner.DeleteSandboxes(client.Key);
            }
        }

        [HttpPut("reset")]
        public async Task<IActionResult> ResetClient([FromBody]ClientIndexViewModel clientViewModel)
        {
            if (Enum.TryParse(clientViewModel.SandboxTypeName, out SandboxType type))
            {
                var client = _clientCreator.ResetSandboxClient(
                    clientViewModel.Name, new SandboxOptions()
                    {
                        Key = clientViewModel.Key,
                        Secret = clientViewModel.Secret,
                        Type = type
                    }, UserProfile);

                await AddClientStatusInfo(client);
                return Ok(ToClientIndexViewModel(client));
            }

            return StatusCode((int)HttpStatusCode.NotAcceptable);
        }
    }
}