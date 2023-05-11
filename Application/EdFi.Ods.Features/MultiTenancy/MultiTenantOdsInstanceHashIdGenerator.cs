// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Implements a hash id generator that incorporates the tenant configuration in context.
/// </summary>
public class MultiTenantOdsInstanceHashIdGenerator : IOdsInstanceHashIdGenerator
{
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

    public MultiTenantOdsInstanceHashIdGenerator(IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    /// <inheritdoc cref="IOdsInstanceHashIdGenerator.GenerateHashId" />
    public ulong GenerateHashId(int odsInstanceId)
    {
        return XxHash3Code.Combine(_tenantConfigurationContextProvider.Get().HashBytes, odsInstanceId);
    }
}
