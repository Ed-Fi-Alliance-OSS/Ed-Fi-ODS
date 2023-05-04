// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace EdFi.Ods.Common.Descriptors;

/// <summary>
/// Defines a method for getting the dictionaries that map descriptors to and from DescriptorId and Uri values.
/// </summary>
/// <remarks>Implementations of this interface must be configured with a named <see cref="IInterceptor" /> registration of "cache-descriptors".</remarks>
[Intercept("cache-descriptors")]
public interface IDescriptorMapsProvider
{
    /// <summary>
    /// Gets the dictionaries that map descriptors to and from DescriptorId and Uri values.
    /// </summary>
    /// <returns>The object containing the descriptor maps.</returns>
    DescriptorMaps GetMaps();
}
