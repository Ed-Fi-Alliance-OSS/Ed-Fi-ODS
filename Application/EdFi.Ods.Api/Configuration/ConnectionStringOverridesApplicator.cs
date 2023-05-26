// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Configuration;

public class ConnectionStringOverridesApplicator : IConnectionStringOverridesApplicator
{
    private readonly IOptionsMonitor<OdsInstancesSection> _odsInstancesConfigurationOptions;

    public ConnectionStringOverridesApplicator(IOptionsMonitor<OdsInstancesSection> odsInstancesConfigurationOptions)
    {
        _odsInstancesConfigurationOptions = odsInstancesConfigurationOptions;
    }
    
    public void ApplyOverrides(OdsInstanceConfiguration odsInstanceConfiguration)
    {
        var odsInstances = _odsInstancesConfigurationOptions.CurrentValue.OdsInstances;
        odsInstanceConfiguration.ApplyOdsConnectionStringOverrides(odsInstances);
    }
}
