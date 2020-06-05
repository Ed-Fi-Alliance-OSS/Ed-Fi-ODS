// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Services.Providers
{
    public class EnterpriseApiVersionProvider: IApiVersionProvider
    {
        public string Version { get; } = ApiVersionConstants.Version;

        public string InformationalVersion { get; } = ApiVersionConstants.InformationalVersion;

        public string Build { get; } = ApiVersionConstants.Build;

        public string Suite { get; } = ApiVersionConstants.Suite;
    }
}
