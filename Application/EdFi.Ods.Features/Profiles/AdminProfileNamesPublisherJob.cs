// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Security.Profiles;
using EdFi.Ods.Common.Context;
using log4net;
using Quartz;

namespace EdFi.Ods.Features.Profiles;

/// <summary>
/// Implements a tenant-specific job that publishes profile names to the Admin database.
/// </summary>
public class AdminProfileNamesPublisherJob : TenantSpecificJobBase
{
    private readonly IAdminProfileNamesPublisher _adminProfileNamesPublisher;

    private readonly ILog _logger = LogManager.GetLogger(typeof(AdminProfileNamesPublisherJob));

    public AdminProfileNamesPublisherJob(
        IAdminProfileNamesPublisher adminProfileNamesPublisher,
        IApiJobScheduler apiJobScheduler,
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
        : base(apiJobScheduler, tenantConfigurationContextProvider)
    {
        _adminProfileNamesPublisher = adminProfileNamesPublisher;
    }

    protected override async Task Execute(IJobExecutionContext context)
    {
        try
        {
            await _adminProfileNamesPublisher.PublishProfilesAsync();
        }
        catch (Exception exception)
        {
            // If an exception occurs log it and return false since it is an async call.
            _logger.Error("An error occured when attempting to publish Profiles to the admin database.", exception);
        }
    }
}
