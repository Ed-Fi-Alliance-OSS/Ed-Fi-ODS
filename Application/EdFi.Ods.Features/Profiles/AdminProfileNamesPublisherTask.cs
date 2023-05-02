// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.ExternalTasks;
using EdFi.Ods.Api.Jobs;

namespace EdFi.Ods.Features.Profiles
{
    /// <summary>
    /// Implements a background initialization task that schedules the <see cref="AdminProfileNamesPublisherJob" /> job for execution.
    /// </summary>
    public class AdminProfileNamesPublisherTask : IExternalTask
    {
        private readonly IApiJobScheduler _apiJobScheduler;

        public AdminProfileNamesPublisherTask(IApiJobScheduler apiJobScheduler)
        {
            _apiJobScheduler = apiJobScheduler;
        }
        
        public void Execute()
        {
            _apiJobScheduler.AddSingleExecutionJob<AdminProfileNamesPublisherJob>(nameof(AdminProfileNamesPublisherTask))
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}