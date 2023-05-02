// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace EdFi.Ods.Api.Jobs.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScheduledJobs(this IServiceCollection services)
        {
            services.AddQuartz(q => { q.UseMicrosoftDependencyInjectionJobFactory(); });

            services.AddQuartzServer(options => { options.WaitForJobsToComplete = true; });
        }
    }
}
