// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Profiles;
using MediatR;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Implements a notification handler with additional special handling required for the explicit expiration of profile metadata
/// by publishing an <see cref="ProfileMetadataCacheExpired" /> message using MediatR.
/// </summary>
public class ProfilesExpireCacheHandler : INotificationHandler<ExpireCache>
{
    private readonly IMediator _mediator;

    public ProfilesExpireCacheHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(ExpireCache notification, CancellationToken cancellationToken)
    {
        string cacheKey = $"cache-{notification.CacheType?.ToLower()}";

        // If this is not expiring profile metadata, do nothing
        if (cacheKey != InterceptorCacheKeys.ProfileMetadata)
        {
            return;
        }

        // Publish the notification message related specifically to Profiles expiration
        await _mediator.Publish(new ProfileMetadataCacheExpired(), cancellationToken);
    }
}
