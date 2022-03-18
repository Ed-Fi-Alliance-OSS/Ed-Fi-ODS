// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Configuration;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace EdFi.Ods.Api.ScheduledJobs.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScheduledJobs(this IServiceCollection services, ApiSettings apiSettings, ILog logger)
        {
            var enabledScheduledJobs =
                apiSettings.ScheduledJobs
                    .Where(a => a.IsEnabled).ToList();

            if (!enabledScheduledJobs.Any())
            {
                logger.Debug($"No scheduled jobs configured, not starting background task scheduling service");
                return;
            }

            services.AddQuartz(
                q => { q.UseMicrosoftDependencyInjectionJobFactory(); });

            services.AddQuartzServer(options => { options.WaitForJobsToComplete = true; });
        }
    }
}
