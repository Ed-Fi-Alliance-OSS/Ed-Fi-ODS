// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;
using log4net;

namespace EdFi.Ods.Api.Caching.Person;

public class PersonMapCacheInitializer : IPersonMapCacheInitializer
{
    private static readonly TimeSpan InitializationTimeout = TimeSpan.FromSeconds(60);

    private readonly IPersonIdentifiersProvider _personIdentifiersProvider;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> _usiByUniqueIdMapCache;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> _uniqueIdByUsiMapCache;
    private readonly IDistributedLockProvider _distributedLockProvider;
    private readonly ILog _logger = LogManager.GetLogger(typeof(PersonMapCacheInitializer));

    public PersonMapCacheInitializer(
        IPersonIdentifiersProvider personIdentifiersProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> uniqueIdByUsiMapCache,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> usiByUniqueIdMapCache,
        IDistributedLockProvider distributedLockProvider)
    {
        _personIdentifiersProvider = personIdentifiersProvider;
        _usiByUniqueIdMapCache = usiByUniqueIdMapCache;
        _uniqueIdByUsiMapCache = uniqueIdByUsiMapCache;
        _distributedLockProvider = distributedLockProvider;
    }

    /// <inheritdoc cref="IPersonMapCacheInitializer.InitializePersonMapAsync" />
    public async Task InitializePersonMapAsync(
        ulong odsInstanceHashId,
        string personType,
        string lockKey,
        CancellationToken cancellationToken = default)
    {
        Stopwatch stopwatch = null;
        using var timeoutCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCancellationTokenSource.CancelAfter(InitializationTimeout);

        try
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"Starting '{personType}' cache initialization for ODS instance '{odsInstanceHashId}'...");
                stopwatch = Stopwatch.StartNew();
            }

            var result = (await _personIdentifiersProvider.GetAllPersonIdentifiersAsync(
                    personType,
                    timeoutCancellationTokenSource.Token))
                .ToArray();

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"Obtained {result.Length:N0} '{personType}' identifiers after {stopwatch?.ElapsedMilliseconds ?? 0:N0} ms...");
            }

            timeoutCancellationTokenSource.Token.ThrowIfCancellationRequested();

            var uniqueIdByUsiCacheEntries = result.Select(v => (v.Usi, v.UniqueId))
                .Concat(
                    new[]
                    {
                        (InitializedReservedKeyForUsi: CacheInitializationConstants.InitializationMarkerKeyForUsi,
                            InitializedKeyForUniqueId: CacheInitializationConstants.InitializationMarkerKeyForUniqueId)
                    })
                .ToArray();

            var usiByUniqueIdCacheEntries = result.Select(v => (v.UniqueId, v.Usi))
                .Concat(
                    new[]
                    {
                        (InitializedKeyForUniqueId: CacheInitializationConstants.InitializationMarkerKeyForUniqueId,
                            InitializedReservedKeyForUsi: CacheInitializationConstants.InitializationMarkerKeyForUsi)
                    })
                .ToArray();

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"Setting '{personType}' map entries into cache for ODS instance '{odsInstanceHashId}'...");
            }

            await Task.WhenAll(
                _uniqueIdByUsiMapCache.SetMapEntriesAsync(
                    (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi),
                    uniqueIdByUsiCacheEntries),
                _usiByUniqueIdMapCache.SetMapEntriesAsync(
                    (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId),
                    usiByUniqueIdCacheEntries));

            if (_logger.IsDebugEnabled)
            {
                stopwatch?.Stop();
                _logger.Debug($"Completed background cache initialization of {uniqueIdByUsiCacheEntries.Length:N0} {personType} entries for ODS instance '{odsInstanceHashId}' in {stopwatch?.ElapsedMilliseconds ?? 0:N0} ms...");
            }
        }
        catch (OperationCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            _logger.Warn(
                $"Background cache initialization of '{personType}' entries for ODS instance '{odsInstanceHashId}' exceeded the {InitializationTimeout.TotalSeconds:N0}-second timeout.",
                ex);

            await ResetInitializationMarkerAsync(odsInstanceHashId, personType);
        }
        catch (Exception ex)
        {
            _logger.Error(
                $"Unable to load '{personType}' mappings from ODS (with OdsInstanceHashId '{odsInstanceHashId}').",
                ex);

            await ResetInitializationMarkerAsync(odsInstanceHashId, personType);
        }
        finally
        {
            try
            {
                await _distributedLockProvider.ReleaseLockAsync(lockKey);
            }
            catch (Exception ex)
            {
                _logger.Error(
                    $"Exception occurred while releasing background initialization lock '{lockKey}' for ODS instance '{odsInstanceHashId}'.",
                    ex);
            }
        }
    }

    private async Task ResetInitializationMarkerAsync(ulong odsInstanceHashId, string personType)
    {
        try
        {
            await Task.WhenAll(
                _uniqueIdByUsiMapCache.SetMapEntriesAsync(
                    (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi),
                    new[] { (CacheInitializationConstants.InitializationMarkerKeyForUsi, default(string)) }),
                _usiByUniqueIdMapCache.SetMapEntriesAsync(
                    (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId),
                    new[] { (CacheInitializationConstants.InitializationMarkerKeyForUniqueId, default(int)) }));
        }
        catch (Exception ex)
        {
            _logger.Warn(
                $"Unable to clear cache initialization markers for '{personType}' in ODS instance '{odsInstanceHashId}'.",
                ex);
        }
    }
}
