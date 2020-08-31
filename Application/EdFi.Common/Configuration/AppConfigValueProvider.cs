// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Microsoft.Extensions.Configuration;

#if NETSTANDARD
namespace EdFi.Ods.Common.Configuration
{
    public class AppConfigValueProvider : IConfigValueProvider
    {
        private readonly IConfigurationRoot _configuration;

        public AppConfigValueProvider(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string name) => _configuration.GetSection(name).Value;
    }
}
#endif
