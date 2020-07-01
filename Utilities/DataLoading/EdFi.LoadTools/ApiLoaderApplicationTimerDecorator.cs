// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using EdFi.LoadTools.Engine.ResourcePipeline;
using log4net;

namespace EdFi.LoadTools
{
    public class ApiLoaderApplicationTimerDecorator : IApiLoaderApplication
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(ApiLoaderApplication));
        private readonly IApiLoaderApplication _next;
        private readonly IResourceStatistic _resourceStatistic;

        public ApiLoaderApplicationTimerDecorator(IApiLoaderApplication next, IResourceStatistic resourceStatistic)
        {
            _next = next;
            _resourceStatistic = resourceStatistic;
        }

        public async Task<int> Run()
        {
            var sw = Stopwatch.StartNew();

            var result = await _next.Run().ConfigureAwait(false);

            sw.Stop();

            _log.Info(
                $"{_resourceStatistic.TotalResources()} resources processed in {sw.Elapsed:hh\\:mm\\:ss} with an average of {Math.Round(_resourceStatistic.TotalResources() / _resourceStatistic.TotalSeconds(),3)} resources per second.");

            foreach (string statisticByResource in _resourceStatistic.CreateStatistics())
            {
                _log.Debug(statisticByResource);
            }

            return result;
        }
    }
}
