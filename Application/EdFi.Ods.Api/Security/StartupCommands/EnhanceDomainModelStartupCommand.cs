// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Startup;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain.DomainModelEnhancers;

namespace EdFi.Ods.Api.Security.StartupCommands;

public class EnhanceDomainModelStartupCommand : IStartupCommand
{
    private readonly IDomainModelEnhancer[] _domainModelEnhancers;
    private readonly IDomainModelProvider _domainModelProvider;

    public EnhanceDomainModelStartupCommand(IDomainModelEnhancer[] domainModelEnhancers, IDomainModelProvider domainModelProvider)
    {
        _domainModelEnhancers = domainModelEnhancers;
        _domainModelProvider = domainModelProvider;
    }

    public Task ExecuteAsync()
    {
        var domainModel = _domainModelProvider.GetDomainModel();

        foreach (var domainModelEnhancer in _domainModelEnhancers)
        {
            domainModelEnhancer.Enhance(domainModel);
        }

        return Task.CompletedTask;
    }
}
