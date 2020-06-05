// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Api.NetCore.Providers
{
    public class ConfigConnectionStringsProvider : IConfigConnectionStringsProvider
    {

        public ConfigConnectionStringsProvider(IConfiguration config)
        {
            ConnectionStringProviderByName = config.GetSection("ConnectionStrings").GetChildren().ToList()
                .ToDictionary(k => k.Key, v => v.Value);
        }

        public int Count { get => ConnectionStringProviderByName.Keys.Count; }

        public IDictionary<string, string> ConnectionStringProviderByName { get; }

        public string GetConnectionString(string name) => ConnectionStringProviderByName[name];
    }
}
