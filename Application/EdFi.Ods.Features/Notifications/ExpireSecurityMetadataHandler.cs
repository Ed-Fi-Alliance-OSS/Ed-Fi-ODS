// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Caching;
using log4net;
using MediatR;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Handles the <see cref="ExpireSecurityMetadata" /> notification by clearing the underlying cache for the interceptor that
/// wraps all method invocations related to security metadata.
/// </summary>
public class ExpireSecurityMetadataHandler : INotificationHandler<ExpireSecurityMetadata>
{
    private readonly IClearable _clearable;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ExpireSecurityMetadataHandler));
    
    public ExpireSecurityMetadataHandler([KeyFilter("cache-security")] IInterceptor interceptor)
    {
        _clearable = interceptor as IClearable;
    }

    public Task Handle(ExpireSecurityMetadata notification, CancellationToken cancellationToken)
    {
        if (_clearable == null)
        {
            _logger.Warn($"Notification to clear security metadata was received, but the {nameof(IInterceptor)} (named \"cache-security\") registered with the container was not clearable.");
        }
        else
        {
            try
            {
                _clearable.Clear();
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to clear security metadata.", ex);
            }
        }

        return Task.CompletedTask;
    }
}
