// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Providers;

namespace EdFi.Ods.Api.Providers
{
    /// <summary>
    /// Implements an IEdFiOdsInstanceIdentificationProvider that returns a stable unsigned-long value based on the
    /// <see cref="OdsInstanceConfiguration.OdsInstanceHashId" /> property.
    /// </summary>
    public class EdFiOdsInstanceIdentificationProvider : IEdFiOdsInstanceIdentificationProvider
    {
        private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationContextProvider;

        public EdFiOdsInstanceIdentificationProvider(
            IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextContextProvider)
        {
            _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextContextProvider;
        }

        /// <inheritdoc cref="IEdFiOdsInstanceIdentificationProvider.GetInstanceIdentification" />
        public ulong GetInstanceIdentification() => _odsInstanceConfigurationContextProvider.Get()?.OdsInstanceHashId ?? throw new InvalidOperationException("No ODS instance configuration has been set in the current context.");
    }
}
