// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Caching;
using log4net;
using MediatR;

namespace EdFi.Ods.Features.Notifications;

/// <summary>
/// Handles the <see cref="ExpireCache" /> notification by clearing the underlying cache for the interceptor that
/// wraps all method invocations related to security metadata.
/// </summary>
public class ExpireCacheHandler : INotificationHandler<ExpireCache>
{
    private readonly IIndex<string, IInterceptor> _interceptorIndex;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ExpireCacheHandler));
    
    public ExpireCacheHandler(IIndex<string, IInterceptor> interceptorIndex)
    {
        _interceptorIndex = interceptorIndex;
    }

    public Task Handle(ExpireCache notification, CancellationToken cancellationToken)
    {
        string cacheKey = $"cache-{notification.CacheType?.ToLower()}";

        if (_interceptorIndex.TryGetValue(cacheKey, out var interceptor))
        {
            if (interceptor is IClearable clearableInterceptor)
            {
                try
                {
                    _logger.Info($"{nameof(ExpireCacheHandler)} is clearing the IInterceptor named '{cacheKey}'...");

                    clearableInterceptor.Clear();
                }
                catch (Exception ex)
                {
                    _logger.Error($"Unable to clear cache.", ex);
                }
            }
            else
            {
                _logger.Warn($"Notification to clear the '{notification.CacheType}' cache was received, but the registered {nameof(IInterceptor)} (named '{cacheKey}') is not clearable...");
            }
        }
        else
        {
            _logger.Warn($"Notification to clear the '{notification.CacheType}' cache was received, but no {nameof(IInterceptor)} has been registered with a name of '{cacheKey}'...");
        }

        return Task.CompletedTask;
    }
}
