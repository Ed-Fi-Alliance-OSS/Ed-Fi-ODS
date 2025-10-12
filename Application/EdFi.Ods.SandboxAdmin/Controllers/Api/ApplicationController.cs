// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Linq;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Ods.SandboxAdmin.Services.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.SandboxAdmin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IClientAppRepo _clientAppRepo;

        public ApplicationController(
            IClientAppRepo repository)
        {
            _clientAppRepo = repository;
        }

        [HttpGet]
        public IActionResult GetApplications()
        {
            try
            {
                var applications = _clientAppRepo.GetApplications();
                var models = applications.Select(ToApplicationIndexViewModel)
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

        [HttpPost]
        public IActionResult PostApplication([FromBody] ApplicationCreateModel applicationCreateModel)
        {
            var applications = _clientAppRepo.GetApplications();
            if (applications != null && applications.Any(a => a.ApplicationName == applicationCreateModel.ApplicationName))
            {
                var message = $"The Application {applicationCreateModel.ApplicationName} already exists!";
                return BadRequest(message);
            }
            var vendor = _clientAppRepo.GetVendors().FirstOrDefault(a => a.VendorId == applicationCreateModel.VendorId);
            if (vendor == null)
            {
                return NotFound();
            }
        
            var newApplication = _clientAppRepo.CreateOrGetApplication(vendor.VendorId, applicationCreateModel.ApplicationName, applicationCreateModel.EducationOrganizationIds, "Ed-Fi Sandbox", "uri://ed-fi-api-host.org");
            return Ok(ToApplicationIndexViewModel(newApplication));


        }

        private ApplicationIndexViewModel ToApplicationIndexViewModel(Application application)
        {
            ApplicationIndexViewModel viewModel = new ApplicationIndexViewModel
            {
                ApplicationName =application.ApplicationName,
                EducationOrganizationId = string.Join(", ", application.ApplicationEducationOrganizations.Select(a=>a.EducationOrganizationId).ToArray()),
                VendorName = application.Vendor.VendorName,
                Id=application.ApplicationId,
                IsDefaultVendor = application.Vendor.VendorName.Trim() == "Test Admin" ? true : false
            };

            return viewModel;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApplication(int id)
        {
            var application = _clientAppRepo.GetApplication(id);

            if (application == null)
            {
                return NotFound();
            }
            _clientAppRepo.DeleteApplication(application.ApplicationId);
            return NoContent();
        }
    }
}