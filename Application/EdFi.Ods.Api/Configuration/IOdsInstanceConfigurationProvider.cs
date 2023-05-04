// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Configuration;

/// <summary>
/// Defines a method for obtaining an ODS instance configuration by id.
/// </summary>
/// <remarks>Implementations of this interface must be configured with a named <see cref="IInterceptor" /> registration of "cache-ods-instances".</remarks>
[Intercept("cache-ods-instances")]
public interface IOdsInstanceConfigurationProvider
{
    Task<OdsInstanceConfiguration> GetByIdAsync(int odsInstanceId);
}
