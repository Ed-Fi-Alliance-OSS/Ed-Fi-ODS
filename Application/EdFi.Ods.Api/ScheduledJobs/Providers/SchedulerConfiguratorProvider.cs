// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.ScheduledJobs.Configurators;
using EdFi.Ods.Api.ScheduledJobs.Jobs;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Api.ScheduledJobs.Providers
{
    public class SchedulerConfiguratorProvider : ISchedulerConfiguratorProvider
    {
        private readonly List<ISchedulerConfigurator> _configurators = new()
        {
            new SchedulerConfigurator<DeleteExpiredTokensScheduledJob>("DeleteExpiredTokens"),
            new SchedulerConfigurator<SchedulerStatusScheduledJob>("SchedulerStatus")
        };

        public ISchedulerConfigurator GetSchedulerConfigurator(string name)
        {
            return _configurators.FirstOrDefault(a => a.Name == name);
        }
    }
}