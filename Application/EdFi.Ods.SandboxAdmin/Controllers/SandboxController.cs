// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Admin.DataAccess.Utils;
using EdFi.Ods.Sandbox.Provisioners;
using EdFi.Ods.SandboxAdmin.Services.Models.Sandbox;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.SandboxAdmin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SandboxController : Controller
    {
        private readonly IClientAppRepo _clientAppRepo;
        private readonly IDatabaseNameBuilder _databaseNameBuilder;
        private readonly ISandboxProvisioner _sandboxProvisioner;

        public SandboxController(ISandboxProvisioner sandboxProvisioner, IClientAppRepo clientAppRepo, IDatabaseNameBuilder databaseNameBuilder)
        {
            _sandboxProvisioner = sandboxProvisioner;
            _clientAppRepo = clientAppRepo;
            _databaseNameBuilder = databaseNameBuilder;
        }

        [HttpGet]
        public ActionResult Orphans()
        {
            var model = GetSandboxIndexViewModel();
            return View(model);
        }

        private SandboxIndexViewModel GetSandboxIndexViewModel()
        {
            var users = _clientAppRepo.GetUsers();
            var knownSandboxes = new List<SandboxViewModel>();

            foreach (var user in users)
            {
                foreach (var client in user.ApiClients)
                {
                    knownSandboxes.Add(
                        new SandboxViewModel
                        {
                            Client = client.Name,
                            User = user.Email,
                            ApplicationName = client.Application.ApplicationName,
                            Sandbox = _databaseNameBuilder.SandboxNameForKey(client.Key)
                        });
                }
            }

            var sandboxDatabases = _sandboxProvisioner.GetSandboxDatabases();

            var orphans = sandboxDatabases.Where(db => knownSandboxes.All(k => k.Sandbox != db))
                                          .ToArray();

            var ownedSandboxes = knownSandboxes.Where(sb => sandboxDatabases.Contains(sb.Sandbox))
                                               .ToArray();

            var missingSandboxes = knownSandboxes.Except(ownedSandboxes)
                                                 .ToArray();

            var model = new SandboxIndexViewModel
            {
                AllSandboxes = sandboxDatabases,
                OwnedSandboxes = ownedSandboxes,
                OrphanSandboxes = orphans,
                MissingSandboxes = missingSandboxes
            };

            return model;
        }

        [HttpPost]
        public ActionResult RemoveOrphans()
        {
            var message = "success";
            var success = true;

            try
            {
                var orphanKeys = GetSandboxIndexViewModel()
                                .OrphanSandboxes
                                .Select(_databaseNameBuilder.KeyFromSandboxName)
                                .ToArray();

                _sandboxProvisioner.DeleteSandboxes(orphanKeys);
            }
            catch (Exception e)
            {
                message = e.Message;
                success = false;

                //GULP.
                //  Exception swallowed since we just reload the page either way.  We aren't showing error messages here right now.
                //  If we start showing error messages, we should either handled exceptions or stop catching them.
            }

            return Json(
                new
                {
                    success,
                    message
                });
        }
    }
}