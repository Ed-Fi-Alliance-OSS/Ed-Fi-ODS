// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Castle.DynamicProxy;
using EdFi.Common.Security;
using EdFi.Ods.Api.Jobs;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Serialization;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Profiles;
using log4net;
using MediatR;

namespace EdFi.Ods.Features.Profiles;

/// <summary>
/// Handles the notification of profile metadata cache expiration.
/// <list type="bullet">
/// <item>
/// <description>Clears the <see cref="IApiClientDetailsProvider" /> cache.</description>
/// </item>
/// <item>
/// <description>Schedule the <see cref="AdminProfileNamesPublisherJob" /> job for execution.</description>
/// </item>
/// <item>
/// <description>Clears the <see cref="ProfilesAwareContractResolver" /> cache.</description>
/// </item>
/// <item>
/// <description>Clears the <see cref="IOpenApiMetadataCacheProvider" /> cache.</description>
/// </item>
/// <item>
/// <description>Clears the <see cref="IMappingContractProvider" /> cache.</description>
/// </item>
/// </list>
/// </summary>
public class ProfileMetadataCacheExpiredNotificationHandler : INotificationHandler<ProfileMetadataCacheExpired>
{
    private readonly IInterceptor _apiClientDetailsInterceptor;
    private readonly IApiJobScheduler _apiJobScheduler;
    private readonly ProfilesAwareContractResolver _profilesAwareContractResolver;
    private readonly IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
    private readonly IMappingContractProvider _mappingContractProvider;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ProfileMetadataCacheExpiredNotificationHandler));

    public ProfileMetadataCacheExpiredNotificationHandler(
        IIndex<string, IInterceptor> interceptorIndex,
        IApiJobScheduler apiJobScheduler,
        ProfilesAwareContractResolver profilesAwareContractResolver,
        IOpenApiMetadataCacheProvider openApiMetadataCacheProvider,
        IMappingContractProvider mappingContractProvider)
    {
        _apiClientDetailsInterceptor = interceptorIndex[InterceptorCacheKeys.ApiClientDetails];
        _apiJobScheduler = apiJobScheduler;
        _profilesAwareContractResolver = profilesAwareContractResolver;
        _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
        _mappingContractProvider = mappingContractProvider;
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

        _profilesAwareContractResolver.Clear();
        _openApiMetadataCacheProvider.ResetCacheInitialization();
        _mappingContractProvider.Clear();

        // Clears te ApiClientDetails cache, to handle scenarios where a Profile is removed
        // from the database
        (_apiClientDetailsInterceptor as IClearable).Clear();
    }
}
