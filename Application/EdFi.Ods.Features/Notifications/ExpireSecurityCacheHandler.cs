// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using Autofac.Features.Indexed;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Caching;
using log4net;
using MediatR;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Handles the <see cref="ExpireSecurityCache" /> notification by clearing the underlying cache for the interceptor that
/// wraps all method invocations related to security metadata.
/// </summary>
public class ExpireSecurityCacheHandler : INotificationHandler<ExpireSecurityCache>
{
    private readonly IClearable _clearable;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ExpireSecurityCacheHandler));
    
    public ExpireSecurityCacheHandler(IIndex<string, IInterceptor> interceptorIndex)
    {
        if (interceptorIndex.TryGetValue("cache-security", out var interceptor))
        {
            _clearable = interceptor as IClearable;
        }
    }

    public Task Handle(ExpireSecurityCache notification, CancellationToken cancellationToken)
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
