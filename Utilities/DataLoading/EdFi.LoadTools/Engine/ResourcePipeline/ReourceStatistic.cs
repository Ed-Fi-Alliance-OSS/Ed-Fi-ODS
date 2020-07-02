// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    public class ResourceStatistic : IResourceStatistic
    {
        private readonly IDictionary<string, Statistic> _statisticsByResource = new Dictionary<string, Statistic>();

        public void AddOrUpdate(ApiLoaderWorkItem resourceWorkItem, double milliSeconds)
        {
            if (_statisticsByResource.ContainsKey(resourceWorkItem.ElementName))
            {
                var statistic = _statisticsByResource[resourceWorkItem.ElementName];
                statistic.TotalMilliseconds += milliSeconds;
                statistic.NumberOfResources++;
            }
            else
            {
                var statistic = new Statistic
                {
                    NumberOfResources = 1,
                    TotalMilliseconds = milliSeconds
                };

                _statisticsByResource[resourceWorkItem.ElementName] = statistic;
            }
        }

        public long TotalResources() => _statisticsByResource.Values.Sum(x => x.NumberOfResources);

        public double TotalSeconds() => Math.Round(_statisticsByResource.Values.Sum(x => x.TotalMilliseconds) / 1000, 3);

        public IEnumerable<string> CreateStatistics()
        {
            var sb = new StringBuilder();

            foreach (string key in _statisticsByResource.Keys)
            {
                var stats = _statisticsByResource[key];

                sb.Clear();
                sb.Append($"{{\"resource\": \"{key}\", ");
                sb.Append("\"statistics\": [");
                sb.Append($"{{\"total\": \"{stats.NumberOfResources}\"}}, ");
                sb.Append($"{{\"seconds\": \"{Math.Round(stats.TotalSeconds(), 3)}\"}}, ");
                sb.Append($"{{\"resourcesPerSecond\": \"{stats.AvgResourcesPerSec()}\"}}, ");
                sb.Append($"{{\"millisecondsPerResource\": \"{stats.AvgMillisecondsPerResource()}\"}}");
                sb.Append("]}");

                yield return sb.ToString();
            }
        }

        private class Statistic
        {
            public long NumberOfResources { get; set; }

            public double TotalMilliseconds { get; set; }

            public double TotalSeconds() => TotalMilliseconds / 1000;

            public double AvgResourcesPerSec()
                => TotalMilliseconds != 0
                    ? Math.Round(NumberOfResources / TotalSeconds(), 3)
                    : 0;

            public double AvgMillisecondsPerResource()
                => NumberOfResources != 0
                    ? Math.Round(TotalMilliseconds / NumberOfResources, 3)
                    : 0;
        }
    }
}
