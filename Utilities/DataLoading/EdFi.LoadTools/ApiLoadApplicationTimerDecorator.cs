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
    public class ApiLoadApplicationTimerDecorator : IApiLoaderApplication
    {
        private readonly IApiLoaderApplication _next;
        private readonly ResourceStatistic _resourceStatistic;
        private readonly ILog _log = LogManager.GetLogger(nameof(ApiLoaderApplication));

        public ApiLoadApplicationTimerDecorator(IApiLoaderApplication next, ResourceStatistic resourceStatistic)
        {
            _next = next;
            _resourceStatistic = resourceStatistic;
        }

        public async Task<int> Run()
        {
            var sw = Stopwatch.StartNew();

            var result = await _next.Run();

            sw.Stop();

            _log.Info($"{_resourceStatistic.Resources} resources processed in {sw.Elapsed:hh\\:mm\\:ss} with an average of {_resourceStatistic.AvgResourcesPerSec()} resources per second.");

            return result;
        }
    }
}
