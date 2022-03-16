// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.ScheduledJobs.Configurators;

namespace EdFi.Ods.Api.ScheduledJobs.Factories;

public class ScheduledJobsConfiguratorFactory: IScheduledJobsConfiguratorFactory
{
    private readonly List<IScheduledJobConfigurator> _configurators = new();

    public ScheduledJobsConfiguratorFactory()
    {
        LoadConfigurators();
    }

    public IScheduledJobConfigurator GetScheduledJobsConfigurator(string name)
    {
        if (!_configurators.Any())
        {
            LoadConfigurators();
        }
        
        return _configurators.FirstOrDefault(a => a.Name == name);
    }

    private void LoadConfigurators()
    {
        string configuratorsNamespace = "EdFi.Ods.Api.ScheduledJobs.Configurators";

        var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
            t => String.Equals(t.Namespace, configuratorsNamespace, StringComparison.Ordinal) && 
                 t.GetInterfaces().Contains(typeof(IScheduledJobConfigurator)) &&
                 !t.IsAbstract);
            
        foreach(var assemblyType in assemblyTypes)
        {
            _configurators.Add((IScheduledJobConfigurator) Activator.CreateInstance(assemblyType));
        }
    }
}
