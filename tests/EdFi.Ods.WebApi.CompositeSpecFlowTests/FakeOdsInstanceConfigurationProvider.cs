// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests;

public class FakeOdsInstanceConfigurationProvider : IOdsInstanceConfigurationProvider
{
    private readonly IConfiguration _configuration;

    public FakeOdsInstanceConfigurationProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task<OdsInstanceConfiguration> GetByIdAsync(int odsInstanceId) => 
        Task.FromResult(new OdsInstanceConfiguration(
            odsInstanceId,
            (ulong) odsInstanceId,
            _configuration.GetConnectionString("EdFi_Ods"),
            new Dictionary<string, string>(),
            new Dictionary<DerivativeType, string>()
        ));
}
