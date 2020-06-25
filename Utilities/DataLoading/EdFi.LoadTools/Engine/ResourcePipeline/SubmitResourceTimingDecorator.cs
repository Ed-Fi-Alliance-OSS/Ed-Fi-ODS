// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    public class SubmitResourceTimingDecorator : ISubmitResource
    {
        private readonly ISubmitResource _next;
        private readonly ResourceStatistic _resourceStatistic;
        private readonly ILog _log = LogManager.GetLogger(nameof(ApiLoaderApplication));
        private int _count;

        public SubmitResourceTimingDecorator(ISubmitResource next, ResourceStatistic resourceStatistic)
        {
            _next = next;
            _resourceStatistic = resourceStatistic;
        }

        public async Task<ApiLoaderWorkItem> ProcessAsync(ApiLoaderWorkItem resourceWorkItem)
        {
            var contextPrefix = LogContext.BuildContextPrefix(resourceWorkItem);
            var sw = Stopwatch.StartNew();
            var count = Interlocked.Increment(ref _count);

            var results = await _next.ProcessAsync(resourceWorkItem);
            sw.Stop();

            _log.Debug(
                $"{contextPrefix} #{count} completed in {Math.Round((decimal) sw.Elapsed.TotalMilliseconds, 3)} milliseconds");

            _resourceStatistic.Resources++;
            _resourceStatistic.Milliseconds += sw.ElapsedMilliseconds;

            return results;
        }
    }
}
