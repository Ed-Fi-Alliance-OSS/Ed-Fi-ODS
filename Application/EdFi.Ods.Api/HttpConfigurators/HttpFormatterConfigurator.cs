// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.HttpConfigurators
{
    public class HttpFormatterConfigurator : IHttpConfigurator
    {
        public void Configure(HttpConfiguration config)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            // Add support for graphml format
            config.Formatters.Insert(0, new GraphMLMediaTypeFormatter());

            HttpConfigHelper.ConfigureJsonFormatter(config);
        }
    }
}
