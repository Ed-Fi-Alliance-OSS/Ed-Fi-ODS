// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Common.Profiles;
using log4net;
using MediatR;

namespace EdFi.Ods.Features.Profiles;

/// <summary>
/// Handles the notification of profile metadata cache expiration to schedule the <see cref="AdminProfileNamesPublisherJob" />
/// job for execution.
/// </summary>
public class ProfileMetadataCacheExpiredNotificationHandler : INotificationHandler<ProfileMetadataCacheExpired>
{
    private readonly IApiJobScheduler _apiJobScheduler;
    private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileMetadataCacheExpiredNotificationHandler));

    public ProfileMetadataCacheExpiredNotificationHandler(IApiJobScheduler apiJobScheduler)
    {
        _apiJobScheduler = apiJobScheduler;
    }

    /// <inheritdoc cref="INotificationHandler{TNotification}.Handle" />
    public async Task Handle(ProfileMetadataCacheExpired notification, CancellationToken cancellationToken)
    {
        if (_logger.IsDebugEnabled)
        {
            _logger.Debug(
                "Reevaluating Profiles for possible publishing to Admin database due to profile metadata cache expiration...");
        }

        await _apiJobScheduler.AddSingleExecutionJob<AdminProfileNamesPublisherJob>(
            nameof(ProfileMetadataCacheExpiredNotificationHandler));
    }
}
