// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;

namespace EdFi.Ods.Api.Configuration;

public static class OdsInstanceConfigurationExtensions
{
    public static void ApplyOdsConnectionStringOverrides(
        this OdsInstanceConfiguration baseOdsInstanceConfiguration,
        Dictionary<string, OdsInstance> odsInstances)
    {
        if (odsInstances.TryGetValue(baseOdsInstanceConfiguration.OdsInstanceId.ToString(), out var odsInstance))
        {
            if (!string.IsNullOrEmpty(odsInstance.ConnectionString))
            {
                baseOdsInstanceConfiguration.ConnectionString = odsInstance.ConnectionString;
            }

            foreach (var derivativeType in DerivativeType.GetAll())
            {
                string derivativeConnectionString =
                    odsInstance.ConnectionStringByDerivativeType.GetValueOrDefault(derivativeType.DisplayName);

                if (!string.IsNullOrEmpty(derivativeConnectionString))
                {
                    baseOdsInstanceConfiguration.ConnectionStringByDerivativeType[derivativeType] = derivativeConnectionString;
                }
            }
        }
    }
}
